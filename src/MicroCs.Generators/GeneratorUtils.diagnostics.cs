using Microsoft.CodeAnalysis;

namespace MicroCs.Generators;

partial class GeneratorUtils
{

    public static class DiagnosticDescriptors
    {
        public static readonly DiagnosticDescriptor UnexpectedTypeOnSymbol = new(
            id: "MC0001",
            title: "Unexpected type on symbol",
            messageFormat: "Unexpected type on symbol {0}",
            category: "MicroCs.Generators",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        public static readonly DiagnosticDescriptor UnexpectedMemberOnSymbol = new(
            id: "MC0002",
            title: "Unexpected member on symbol",
            messageFormat: "Unexpected member on symbol {0}",
            category: "MicroCs.Generators",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);
    }
}