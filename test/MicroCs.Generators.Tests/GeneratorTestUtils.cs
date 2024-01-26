using DiffEngine;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Reflection;
using System.Runtime.CompilerServices;
// ReSharper disable ExplicitCallerInfoArgument

namespace MicroCs.Generators.Tests;

internal enum SourceType
{
    EmbeddedResource,
    Code,
}

internal class GeneratorTestUtils
{
    private static readonly Assembly ThisAssembly = typeof(GeneratorTestUtils).Assembly;

    [ModuleInitializer]
    public static void Init()
    {
        VerifySourceGenerators.Initialize();
        //DiffRunner.Disabled = true;
        DiffTools.UseOrder(false, DiffTool.VisualStudioCode);
    }

    private static string LoadEmbeddedResource(string resourceName)
    {
        using var stream = ThisAssembly.GetManifestResourceStream(resourceName);

        if (stream is null)
        {
            throw new InvalidOperationException(
                $"Could not find embedded resource {resourceName}");
        }

        using var reader = new StreamReader(stream!);

        return reader.ReadToEnd();
    }

    private static string LoadSourceCode(string source, SourceType sourceType)
    {
        return sourceType switch
        {
            SourceType.EmbeddedResource => LoadEmbeddedResource(source),
            SourceType.Code => source,
            _ => throw new ArgumentOutOfRangeException(nameof(sourceType), sourceType, null),
        };
    }

    public static async Task Verify<TGenerator>(
        string[] sources,
        SourceType sourceType = SourceType.EmbeddedResource,
        [CallerFilePath] string sourceFile = "")
        where TGenerator : IIncrementalGenerator, new()
    {
        var syntaxTrees =
            sources
                .Select(source => LoadSourceCode(source, sourceType))
                .Select(source => CSharpSyntaxTree.ParseText(source))
                .ToArray();

        var compilation = CSharpCompilation.Create(
            assemblyName: "MicroCs.Generators.Tests.Generated",
            syntaxTrees: syntaxTrees,
            references: GetReferences());

        var generator = new TGenerator();

        GeneratorDriver driver = CSharpGeneratorDriver.Create(generator);

        driver = driver.RunGenerators(compilation);

        await Verifier.Verify(driver, sourceFile: sourceFile);
    }

    public static Task Verify<TGenerator>(
        string source,
        SourceType sourceType = SourceType.EmbeddedResource,
        [CallerFilePath] string sourceFile = "")
        where TGenerator : IIncrementalGenerator, new() =>
        Verify<TGenerator>([source], sourceType, sourceFile);

    private static IEnumerable<MetadataReference> GetReferences()
    {
        string dotNet = Path.GetDirectoryName(typeof(object).Assembly.Location)!;
        string locals = Path.GetDirectoryName(typeof(GeneratorTestUtils).Assembly.Location)!;

        return new[]
            {
                (folder: dotNet, name: "mscorlib.dll"),
                (folder: dotNet, name: "netstandard.dll"),
                (folder: dotNet, name: "System.dll"),
                (folder: dotNet, name: "System.Core.dll"),
                (folder: dotNet, name: "System.Runtime.dll"),
                (folder: dotNet, name: "System.Private.CoreLib.dll"),

                (folder: locals, name: "MicroCs.Generators.Annotations.dll"),
            }
            .Select(a => MetadataReference.CreateFromFile(Path.Combine(a.folder, a.name)));
    }
}
