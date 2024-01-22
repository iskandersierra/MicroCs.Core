using Microsoft.CodeAnalysis;

namespace MicroCs.Generators.Aop;

internal static partial class AopGeneratorUtils
{
    public const string MainNamespace =
        $"{GeneratorUtils.MainNamespace}.Aop";

    public const string AssetsFolder = $"{MainNamespace}.assets";
}
