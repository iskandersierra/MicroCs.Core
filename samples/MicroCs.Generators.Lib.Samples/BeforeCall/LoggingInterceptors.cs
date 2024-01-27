using MicroCs.Generators.Aop;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace MicroCs.Generators.Lib.Samples.BeforeAfterAllCall;

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
        return new Data(Stopwatch.GetTimestamp());
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
        var elapsedMilliseconds = Stopwatch.GetElapsedTime(state.StartTimestamp);
        
        Console.WriteLine("After Success Call");
        Console.WriteLine("  - Proxy Type: {0}", proxyType);
        Console.WriteLine("  - Proxy Type Name: {0}", proxyTypeName);
        Console.WriteLine("  - Proxy Instance: {0}", proxyInstance);
        Console.WriteLine("  - Instance: {0}", instance);
        Console.WriteLine("  - Target Type: {0}", targetType);
        Console.WriteLine("  - Target Type Name: {0}", targetTypeName);
        Console.WriteLine("  - Method Info: {0}", methodInfo);
        Console.WriteLine("  - Method Name: {0}", methodName);
        Console.WriteLine("  - Parameters: {0}", arg0: string.Join(", ", parameters.Select(e => $"{e}")));
        Console.WriteLine("  - Result: {0}", result);
        Console.WriteLine("  - Exception: {0}", exception);
        Console.WriteLine("  - Elapsed Milliseconds: {0}", elapsedMilliseconds);
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
        var elapsedMilliseconds = Stopwatch.GetElapsedTime(state.StartTimestamp);
        
        Console.WriteLine("After Call");
        Console.WriteLine("  - Proxy Type: {0}", proxyType);
        Console.WriteLine("  - Proxy Type Name: {0}", proxyTypeName);
        Console.WriteLine("  - Proxy Instance: {0}", proxyInstance);
        Console.WriteLine("  - Instance: {0}", instance);
        Console.WriteLine("  - Target Type: {0}", targetType);
        Console.WriteLine("  - Target Type Name: {0}", targetTypeName);
        Console.WriteLine("  - Method Info: {0}", methodInfo);
        Console.WriteLine("  - Method Name: {0}", methodName);
        Console.WriteLine("  - Parameters: {0}", arg0: string.Join(", ", parameters.Select(e => $"{e}")));
        Console.WriteLine("  - Result: {0}", result);
        Console.WriteLine("  - Exception: {0}", exception);
        Console.WriteLine("  - Elapsed Milliseconds: {0}", elapsedMilliseconds);
    }

    [InterceptAfterFailure()]
    public void AfterFailureCall(
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
        var elapsedMilliseconds = Stopwatch.GetElapsedTime(state.StartTimestamp);
        
        Console.WriteLine("After Failure Call");
        Console.WriteLine("  - Proxy Type: {0}", proxyType);
        Console.WriteLine("  - Proxy Type Name: {0}", proxyTypeName);
        Console.WriteLine("  - Proxy Instance: {0}", proxyInstance);
        Console.WriteLine("  - Instance: {0}", instance);
        Console.WriteLine("  - Target Type: {0}", targetType);
        Console.WriteLine("  - Target Type Name: {0}", targetTypeName);
        Console.WriteLine("  - Method Info: {0}", methodInfo);
        Console.WriteLine("  - Method Name: {0}", methodName);
        Console.WriteLine("  - Parameters: {0}", arg0: string.Join(", ", parameters.Select(e => $"{e}")));
        Console.WriteLine("  - Result: {0}", result);
        Console.WriteLine("  - Exception: {0}", exception);
        Console.WriteLine("  - Elapsed Milliseconds: {0}", elapsedMilliseconds);
    }

    public record struct Data(long StartTimestamp);
}
