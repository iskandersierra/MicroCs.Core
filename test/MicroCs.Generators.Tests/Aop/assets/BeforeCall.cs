using MicroCs.Generators.Aop;
using System.Reflection;

namespace Sample.BeforeCall;

public interface IProxyGeneratorInterface
{
    void MyMethod();
    public string MyMethod(string input1, int input2) => $"{input1}: {input2}";
    public (string, DateTime) MyMethod(string input1, DateTime input2);
}

public class LoggingInterceptors
{
    [BeforeInterceptor]
    public Data BeforeCall(
        [InterceptedProxy] Type proxyType,
        [InterceptedProxyInstance] object proxyInstance,
        [InterceptedInstance] IProxyGeneratorInterface instance,
        [InterceptedTarget] Type targetType,
        [InterceptedMember] MethodInfo methodInfo,
        [InterceptedParameters] object[] parameters)
    {
        Console.WriteLine($"BeforeCall: {proxyType} {proxyInstance} {instance} {targetType} {methodInfo} {parameters}");
    }

    public struct Data(long StartTimestamp);
}

[GenerateProxy]
public partial class LoggingProxyGeneratorClass :
    IProxyGeneratorInterface
{
    [Interceptor]
    private readonly LoggingInterceptors interceptors;
}
