using MicroCs.Generators.Aop;
using System;
using System.Linq;
using System.Reflection;

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
        [InterceptedParameters] object?[] parameters)
    {
        Console.WriteLine("Before Call");
        Console.WriteLine("  - Proxy Type: {0}", proxyType);
        Console.WriteLine("  - Proxy Type Name: {0}", proxyTypeName);
        Console.WriteLine("  - Proxy Instance: {0}", proxyInstance);
        Console.WriteLine("  - Instance: {0}", instance);
        Console.WriteLine("  - Target Type: {0}", targetType);
        Console.WriteLine("  - Target Type Name: {0}", targetTypeName);
        Console.WriteLine("  - Method Info: {0}", methodInfo);
        Console.WriteLine("  - Method Name: {0}", methodName);
        Console.WriteLine("  - Parameters: {0}", arg0: string.Join(", ", parameters.Select(e => $"{e}")));
        return default!;
    }

    public struct Data(long StartTimestamp);
}
