using System.Reflection;
using MicroCs.Generators.Aop;

namespace MicroCs.Generators.Lib.Samples.BeforeCall;

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
        [InterceptedParameters] object?[] parameters,
        [InterceptedParameter(Type = typeof(string))] string? stringParameter)
    {
        return default!;
    }

    public struct Data(long StartTimestamp);
}
