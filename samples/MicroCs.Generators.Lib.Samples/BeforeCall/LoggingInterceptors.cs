using System.Reflection;
using MicroCs.Generators.Aop;

namespace MicroCs.Generators.Lib.Samples.BeforeCall;

public class LoggingInterceptors
{
    [InterceptBefore()]
    public void BeforeCall(
        [InterceptedProxy] Type proxyType,
        [InterceptedProxy] string proxyTypeName,
        [InterceptedProxyInstance] object proxyInstance,
        [InterceptedInstance] IProxyGeneratorInterface instance,
        [InterceptedTarget] Type targetType,
        [InterceptedTarget] string targetTypeName,
        [InterceptedMember] MethodInfo methodInfo,
        [InterceptedMember] string methodName,
        [InterceptedParameters] object[] parameters)
    {
        Console.WriteLine($"BeforeCall: {proxyType} {proxyInstance} {instance} {targetType} {methodInfo} {parameters}");
    }
}
