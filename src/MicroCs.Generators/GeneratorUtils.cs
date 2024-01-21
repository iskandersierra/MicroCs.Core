using Scriban;
using System.Collections.Concurrent;
using System.Reflection;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MicroCs.Generators;

internal static class GeneratorUtils
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
                if (semanticModel.GetSymbolInfo(attributeSyntax).Symbol
                    is not IMethodSymbol attrCtorSymbol)
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
        syntax.GetAttributes()
            .HasAttribute(attributeTypeFullName, semanticModel, format);

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

    #endregion [ Semantics ]
}
