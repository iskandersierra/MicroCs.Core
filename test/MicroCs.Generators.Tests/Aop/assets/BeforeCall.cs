﻿using MicroCs.Generators.Aop;
using System.Reflection;

namespace Sample.BeforeCall;

public interface IProxyGeneratorInterface
{
    void MyMethod();
}

public class LoggingInterceptors
{
    [BeforeInterceptor]
    public void BeforeCall(
        [InterceptedProxy] Type proxyType,
        [InterceptedProxyInstance] object proxyInstance,
        [InterceptedInstance] IProxyGeneratorInterface instance,
        [InterceptedTarget] Type targetType,
        [InterceptedMember] MethodInfo methodInfo,
        [InterceptedParameters] object[] parameters)
    {
        Console.WriteLine($"BeforeCall: {proxyType} {proxyInstance} {instance} {targetType} {methodInfo} {parameters}");
    }
}

[GenerateProxy]
public partial class LoggingProxyGeneratorClass :
    IProxyGeneratorInterface
{
    [Interceptor]
    private readonly LoggingInterceptors interceptors;
}