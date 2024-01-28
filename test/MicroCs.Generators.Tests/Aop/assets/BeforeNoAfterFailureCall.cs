using MicroCs.Generators.Aop;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace MicroCs.Generators.Lib.Samples.BeforeNoAfterFailureCall
{
    public interface IProxyGeneratorInterface
    {
        void MyMethod();
        string MyMethod(string input1, int input2 = 42) => $"{input1}: {input2}";
        (string, DateTime) MyMethod(string input1, DateTime input2);
        Task MyMethod(int input1, CancellationToken cancel);
        Task<string> MyMethod(int input1, string? input2 = "default", CancellationToken cancel = default);
    }

    public class LoggingInterceptors
    {
        [InterceptBefore()]
        public Data BeforeCall(
            [InterceptedProxyType] Type proxyType,
            [InterceptedProxyType] string proxyTypeName,
            [InterceptedProxyInstance] object proxyInstance,
            [InterceptedInstance] IProxyGeneratorInterface instance,
            [InterceptedTargetType] Type targetType,
            [InterceptedTargetType] string targetTypeName,
            [InterceptedMember] MethodInfo methodInfo,
            [InterceptedMember] string methodName,
            [InterceptedParameters] object?[] parameters)
        {
            return default!;
        }

        [InterceptAfterSuccess()]
        public void AfterSuccessCall(
            [InterceptedProxyType] Type proxyType,
            [InterceptedProxyType] string proxyTypeName,
            [InterceptedProxyInstance] object proxyInstance,
            [InterceptedInstance] IProxyGeneratorInterface instance,
            [InterceptedTargetType] Type targetType,
            [InterceptedTargetType] string targetTypeName,
            [InterceptedMember] MethodInfo methodInfo,
            [InterceptedMember] string methodName,
            [InterceptedParameters] object?[] parameters,
            [InterceptedResult] object? result,
            [InterceptedException] Exception? exception,
            [InterceptedState] Data state)
        {
        }

        [InterceptAfter()]
        public void AfterCall(
            [InterceptedProxyType] Type proxyType,
            [InterceptedProxyType] string proxyTypeName,
            [InterceptedProxyInstance] object proxyInstance,
            [InterceptedInstance] IProxyGeneratorInterface instance,
            [InterceptedTargetType] Type targetType,
            [InterceptedTargetType] string targetTypeName,
            [InterceptedMember] MethodInfo methodInfo,
            [InterceptedMember] string methodName,
            [InterceptedParameters] object?[] parameters,
            [InterceptedResult] object? result,
            [InterceptedException] Exception? exception,
            [InterceptedState] Data state)
        {
        }

        public struct Data(long StartTimestamp);
    }
}

namespace MicroCs.Generators.Samples.BeforeNoAfterFailureCall
{
    using MicroCs.Generators.Lib.Samples.BeforeNoAfterFailureCall;

    [GenerateProxy]
    public partial class LoggingProxyGeneratorClass :
        IProxyGeneratorInterface
    {
        [Interceptor]
        private readonly LoggingInterceptors interceptors;
    }
}
