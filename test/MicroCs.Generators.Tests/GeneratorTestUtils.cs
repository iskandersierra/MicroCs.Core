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
        string dotNetAssemblyPath = Path.GetDirectoryName(typeof(object).Assembly.Location)!;

        return new[]
            {
                "mscorlib.dll",
                "System.dll",
                "System.Core.dll",
                "System.Runtime.dll",
                "System.Private.CoreLib.dll",
            }
            .Select(a => MetadataReference.CreateFromFile(Path.Combine(dotNetAssemblyPath, a)));
    }
}
