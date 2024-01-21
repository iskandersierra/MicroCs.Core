﻿using Microsoft.CodeAnalysis;

namespace MicroCs.Generators.Aop;

internal static class AopGeneratorUtils
{
    public const string MainNamespace =
        $"{GeneratorUtils.MainNamespace}.Aop";

    public const string AssetsFolder = $"{MainNamespace}.assets";

    public static class DiagnosticDescriptors
    {
        public static readonly DiagnosticDescriptor GeneratedProxyHasNoInterfaces = new(
            id: "MCAOP0001",
            title: "Generated proxy has no interfaces",
            messageFormat: "Generated proxy {0} has no interfaces",
            category: "MicroCs.Generators.Aop",
            DiagnosticSeverity.Warning,
            isEnabledByDefault: true);
        
        public static readonly DiagnosticDescriptor GeneratedProxyHasNoInterceptor = new(
            id: "MCAOP0002",
            title: "Generated proxy has no interceptor",
            messageFormat: "Generated proxy {0} has no interceptor",
            category: "MicroCs.Generators.Aop",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        public static readonly DiagnosticDescriptor GeneratedProxyHasMultipleInterceptors = new(
            id: "MCAOP0003",
            title: "Generated proxy has multiple interceptors",
            messageFormat: "Generated proxy {0} has multiple interceptors",
            category: "MicroCs.Generators.Aop",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);
    }
}
