using Scriban;
using System.Collections.Concurrent;
using System.Reflection;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MicroCs.Generators;

internal static partial class GeneratorUtils
{
    public const string MainNamespace = "MicroCs.Generators";

    private static readonly Assembly ThisAssembly = typeof(GeneratorUtils).Assembly;
    private static readonly ConcurrentDictionary<string, Template> TemplateCache = new();

    #region [ Template Rendering ]

    private static Template LoadTemplate(string resourcePath)
    {
        using var stream = ThisAssembly.GetManifestResourceStream(resourcePath);

        if (stream is null)
        {
            throw new InvalidOperationException(
                $"Could not find template {resourcePath}");
        }

        using var reader = new StreamReader(stream!);

        var template = Template.Parse(reader.ReadToEnd(), resourcePath);

        if (template.HasErrors)
        {
            var errors = new StringBuilder();

            foreach (var message in template.Messages)
            {
                errors.AppendLine(message.ToString());
            }

            throw new InvalidOperationException(
                $"Could not parse template {resourcePath}:\n{errors}");
        }

        return template;
    }

    private static Template GetTemplate(string resourcePath)
    {
        if (TemplateCache.TryGetValue(resourcePath, out var result))
        {
            return result;
        }

        var template = LoadTemplate(resourcePath);

        TemplateCache.TryAdd(resourcePath, template);

        return template;
    }

    public static string RenderString(string resourcePath, object model)
    {
        var template = GetTemplate(resourcePath);

        return template.Render(model, member => member.Name, _ => true);
    }

    public static SourceText RenderSource(
        string resourcePath, object model, Encoding? encoding = null)
    {
        var text = RenderString(resourcePath, model);

        return SourceText.From(text, encoding ?? Encoding.UTF8);
    }

    #endregion [ Template Rendering ]

    #region [ Syntax ]

    #region [ Attributes ]

    public static IEnumerable<AttributeSyntax> GetAttributes(
        this MemberDeclarationSyntax syntax) =>
        syntax.AttributeLists
            .SelectMany(list => list.Attributes);

    public static bool HasAttribute(
        this IEnumerable<AttributeSyntax> attributes,
        string attributeTypeFullName,
        SemanticModel semanticModel,
        SymbolDisplayFormat? format = null) =>
        attributes
            .Any(attributeSyntax =>
            {
                var symbolInfo = semanticModel.GetSymbolInfo(attributeSyntax);

                if (symbolInfo.Symbol is not IMethodSymbol attrCtorSymbol)
                    return false;

                if (attrCtorSymbol.ContainingType
                    is not { } attrTypeSymbol)
                    return false;

                var attrFullName = attrTypeSymbol.ToDisplayString(format);

                return string.Equals(attrFullName, attributeTypeFullName, StringComparison.Ordinal);
            });

    public static bool HasAttribute(
        this MemberDeclarationSyntax syntax,
        string attributeTypeFullName,
        SemanticModel semanticModel,
        SymbolDisplayFormat? format = null) =>
        syntax.GetAttributes().HasAttribute(attributeTypeFullName, semanticModel, format);

    #endregion [ Attributes ]

    #endregion [ Syntax ]

    #region [ Semantics ]

    #region [ Attributes ]

    public static bool HasAttribute(
        this ISymbol symbol,
        string attributeTypeFullName,
        SymbolDisplayFormat? format = null) =>
        symbol.GetAttributes()
            .Select(a => a.AttributeClass?.ToDisplayString(format))
            .Where(e => e is not null)
            .Any(e => string.Equals(e, attributeTypeFullName, StringComparison.Ordinal));

    #endregion [ Attributes ]

    #region [ Types ]

    public static NamedTypeModel ToNamedTypeModel(
        this INamedTypeSymbol symbol)
    {
        return new NamedTypeModel
        {
            Namespace = symbol.ContainingNamespace.ToDisplayString(),
            FullName = symbol.ToDisplayString(),
            Name = symbol.Name,
        };
    }

    public static NamedTypeModel? ToNamedTypeModel(
        this ITypeSymbol symbol,
        SourceProductionContext context,
        Compilation compilation)
    {
        switch (symbol)
        {
            case INamedTypeSymbol namedTypeSymbol:
                return namedTypeSymbol.ToNamedTypeModel();

            default:
            {
                context.ReportDiagnostic(
                    Diagnostic.Create(
                        DiagnosticDescriptors.UnexpectedTypeOnSymbol,
                        symbol.Locations[0],
                        symbol.ToDisplayString()));

                return null;
            }
        }
    }

    #endregion [ Types ]

    #region [ Members ]

    public static MethodModel? ToMethodModel(
        this IMethodSymbol symbol,
        SourceProductionContext context,
        Compilation compilation)
    {
        var parameters = symbol.Parameters
            .Select(p =>
            {
                var typeModel = p.Type.ToNamedTypeModel(context, compilation);

                if (typeModel is null) return null;

                return new MethodParameterModel
                {
                    Name = p.Name,
                    Type = typeModel,
                };
            })
            .Where(p => p is not null)
            .Select(p => p!)
            .ToList();

        var returnType = symbol.ReturnType.ToNamedTypeModel(context, compilation);

        if (returnType is null || parameters.Count != symbol.Parameters.Length)
            return null;

        return new MethodModel
        {
            Name = symbol.Name,
            Parameters = parameters,
            ReturnType = returnType,
        };
    }

    public static MemberBaseModel? ToMemberBaseModel(
        this ISymbol symbol,
        SourceProductionContext context,
        Compilation compilation)
    {
        switch (symbol)
        {
            case IMethodSymbol methodSymbol:
                return methodSymbol.ToMethodModel(context, compilation);

            default:
            {
                context.ReportDiagnostic(
                    Diagnostic.Create(
                        DiagnosticDescriptors.UnexpectedMemberOnSymbol,
                        symbol.Locations[0],
                        symbol.ToDisplayString()));

                return null;
            }
        }
    }
    
    public static IReadOnlyList<MemberBaseModel>? ExtractMembers(
        this INamedTypeSymbol symbol,
        SourceProductionContext context,
        Compilation compilation)
    {
        var result = symbol.GetMembers()
            .Select(m => m.ToMemberBaseModel(context, compilation))
            .Where(m => m is not null)
            .Select(m => m!)
            .ToList();

        if (result.Count != symbol.GetMembers().Length) return null;

        return result;
    }

    #endregion [ Members ]

    #endregion [ Semantics ]
}
