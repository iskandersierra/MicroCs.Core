using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MicroCs.Generators.Aop;

internal static class ProxyGeneratorUtils
{
    #region [ Template Paths ]

    private const string AttributesTemplatePath =
        $"{AopGeneratorUtils.AssetsFolder}.ProxyGenerator.Attributes.scriban.cs";

    private const string ClassTemplatePath =
        $"{AopGeneratorUtils.AssetsFolder}.ProxyGenerator.Class.scriban.cs";
    
    #endregion [ Template Paths ]
    
    #region [ Attributes Full Names ]

    private const string GenerateProxyAttributeFullName =
        $"{AopGeneratorUtils.MainNamespace}.GenerateProxyAttribute";

    private const string InterceptorAttributeFullName =
        $"{AopGeneratorUtils.MainNamespace}.InterceptorAttribute";

    #endregion [ Attributes Full Names ]

    #region [ RegisterProxyAttributes ]

    public static void RegisterProxyAttributes(
        this IncrementalGeneratorInitializationContext context) =>
        context.RegisterPostInitializationOutput(AddAttributesSource);

    private static void AddAttributesSource(
        IncrementalGeneratorPostInitializationContext context)
    {
        var model = new ProxyGeneratorAttributesModel
        {
            Namespace = AopGeneratorUtils.MainNamespace,
        };

        var attributesSource = GeneratorUtils
            .RenderSource(AttributesTemplatePath, model);

        context.AddSource("ProxyGeneratorAttributes.g.cs", attributesSource);
    }

    #endregion [ RegisterProxyAttributes ]

    #region [ RegisterProxyClasses ]

    public static void RegisterProxyClasses(
        this IncrementalGeneratorInitializationContext context)
    {
        var classes = context.SyntaxProvider
            .CreateSyntaxProvider(
                PartialClassWithBaseTypesAndAttributes,
                HasGenerateProxyAttribute)
            .Where(e => e is not null);

        context.RegisterSourceOutput(
            context.CompilationProvider.Combine(classes.Collect()),
            GenerateProxyClasses);
    }

    private static bool PartialClassWithBaseTypesAndAttributes(
        SyntaxNode node,
        CancellationToken cancel)
    {
        return node is ClassDeclarationSyntax {AttributeLists.Count: > 0} @class &&
               @class.Modifiers.Any(SyntaxKind.PartialKeyword) &&
               !@class.Modifiers.Any(SyntaxKind.StaticKeyword) &&
               @class.BaseList?.Types is {Count: > 0};
    }

    private static ClassDeclarationSyntax? HasGenerateProxyAttribute(
        GeneratorSyntaxContext context,
        CancellationToken cancel)
    {
        if (context.Node is not ClassDeclarationSyntax @class) return null;

        var hasGenerateProxyAttribute = @class
            .HasAttribute(GenerateProxyAttributeFullName, context.SemanticModel);

        return hasGenerateProxyAttribute ? @class : null;
    }

    private static void GenerateProxyClasses(
        SourceProductionContext context,
        (Compilation compilation, ImmutableArray<ClassDeclarationSyntax?> classes) data)
    {
        var models = ExtractClassModels(context, data.compilation, data.classes);

        for (int i = 0; i < models.Count; i++)
        {
            var model = models[i];
            if (!model.ShouldGenerateCode) continue;
            var fileName = $"{model.Name}.{i}.g.cs";
            var source = GeneratorUtils.RenderSource(ClassTemplatePath, model);
            context.AddSource(fileName, source);
        }
    }

    private static IReadOnlyList<ProxyGeneratorClassModel> ExtractClassModels(
        SourceProductionContext context,
        Compilation compilation,
        ImmutableArray<ClassDeclarationSyntax?> classes)
    {
        return classes
            .Select(classSyntax => ExtractClassModel(context, compilation, classSyntax))
            .Where(model => model is not null)
            .Select(model => model!)
            .ToArray();
    }

    private static ProxyGeneratorClassModel? ExtractClassModel(
        SourceProductionContext context,
        Compilation compilation,
        ClassDeclarationSyntax classSyntax)
    {
        var semanticModel = compilation.GetSemanticModel(classSyntax.SyntaxTree);

        if (semanticModel.GetDeclaredSymbol(classSyntax) is not { } classSymbol)
            return null;

        var className = classSymbol.Name;
        var @namespace = classSymbol.ContainingNamespace?.ToDisplayString();

        var interfaces = classSymbol.AllInterfaces
            .Select(interfaceSymbol => ExtractInterfaceModel(context, compilation, interfaceSymbol))
            .Where(model => model is not null)
            .Select(model => model!)
            .ToArray();

        if (interfaces.Length == 0)
        {
            context.ReportDiagnostic(
                Diagnostic.Create(
                    AopGeneratorUtils.DiagnosticDescriptors.GeneratedProxyHasNoInterfaces,
                    classSyntax.GetLocation(),
                    className));
            return null;
        }

        var interceptor = ExtractInterceptorModel(context, compilation, classSymbol);

        if (interceptor is null) return null;

        return new ProxyGeneratorClassModel
        {
            Namespace = @namespace,
            Name = className,
            Interfaces = interfaces,
            Interceptor = interceptor,
        };
    }

    private static ProxyGeneratorInterfaceModel? ExtractInterfaceModel(
        SourceProductionContext context,
        Compilation compilation,
        INamedTypeSymbol interfaceSymbol)
    {
        return new ProxyGeneratorInterfaceModel
        {
            ParameterName = interfaceSymbol.Name.ToLowerInvariant(),
            InterfaceType = new InterfaceModel
            {
                FullName = interfaceSymbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat),
                Name = interfaceSymbol.Name,
            },
        };
    }

    private static ProxyGeneratorInterceptorModel? ExtractInterceptorModel(
        SourceProductionContext context,
        Compilation compilation,
        INamedTypeSymbol classSymbol)
    {
        var interceptorFields = classSymbol.GetMembers()
            .OfType<IFieldSymbol>()
            .Where(field => field.HasAttribute(InterceptorAttributeFullName))
            .ToArray();

        if (interceptorFields.Length == 0)
        {
            context.ReportDiagnostic(
                Diagnostic.Create(
                    AopGeneratorUtils.DiagnosticDescriptors.GeneratedProxyHasNoInterceptor,
                    classSymbol.Locations[0],
                    classSymbol.Name));
            return null;
        }

        if (interceptorFields.Length > 1)
        {
            context.ReportDiagnostic(
                Diagnostic.Create(
                    AopGeneratorUtils.DiagnosticDescriptors.GeneratedProxyHasMultipleInterceptors,
                    interceptorFields[1].Locations[0],
                    classSymbol.Name));
            return null;
        }

        var interceptorField = interceptorFields[0];

        if (interceptorField.Type is not { } interceptorTypeSymbol) return null;

        return new ProxyGeneratorInterceptorModel
        {
            ParameterName = interceptorField.Name.ToLowerInvariant(),
            InterceptorType = new ClassModel
            {
                FullName = interceptorTypeSymbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat),
                Name = interceptorTypeSymbol.Name,
            },
        };
    }

    #endregion [ RegisterProxyClasses ]
}
