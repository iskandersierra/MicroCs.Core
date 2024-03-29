﻿using Microsoft.CodeAnalysis;

namespace MicroCs.Generators.Aop;

partial class AopGeneratorUtils
{
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

        public static readonly DiagnosticDescriptor GeneratedProxyInterceptorIsNotNamedType = new(
            id: "MCAOP0004",
            title: "Generated proxy interceptor is not named type",
            messageFormat: "Generated proxy interceptor [{0}: {1}] is not named type",
            category: "MicroCs.Generators.Aop",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        public static readonly DiagnosticDescriptor MultipleInterceptionAttributes = new(
            id: "MCAOP0005",
            title: "Multiple interception attributes",
            messageFormat: "Multiple interception attributes",
            category: "MicroCs.Generators.Aop",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        public static readonly DiagnosticDescriptor NoInterceptionAttributes = new(
            id: "MCAOP0006",
            title: "No interception attributes",
            messageFormat: "No interception attributes",
            category: "MicroCs.Generators.Aop",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        public static readonly DiagnosticDescriptor InterceptedMemberParameterTypeIsInvalid = new(
            id: "MCAOP0007",
            title: "Intercepted member parameter type is invalid",
            messageFormat: "Intercepted member parameter {0} type {1} is invalid. Must be either string or MethodInfo",
            category: "MicroCs.Generators.Aop",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        public static readonly DiagnosticDescriptor InterceptedTypeParameterTypeIsInvalid = new(
            id: "MCAOP0008",
            title: "Intercepted type parameter type is invalid",
            messageFormat: "Intercepted type parameter {0} type {1} is invalid. Must be either string or Type",
            category: "MicroCs.Generators.Aop",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);
    }
}
