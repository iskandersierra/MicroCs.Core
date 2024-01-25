using MicroCs.Generators.Aop;
using System.Reflection;

namespace MicroCs.Generators.Tests.Aop.BeforeCall;

//public interface IProxyGeneratorInterface
//{
//    void MyMethod();
//}

//public class LoggingInterceptors
//{
//    [InterceptBefore]
//    public void BeforeCall(
//        [InterceptedProxy] Type proxyType,
//        [InterceptedProxyInstance] object proxyInstance,
//        [InterceptedInstance] IProxyGeneratorInterface instance,
//        [InterceptedTarget] Type targetType,
//        [InterceptedMember] MethodInfo methodInfo,
//        [InterceptedParameters(CouldChange = false)] object[] parameters)
//    {
//        Console.WriteLine($"BeforeCall: {proxyType} {proxyInstance} {instance} {targetType} {methodInfo} {parameters}");
//    }
//}

//[GenerateProxy]
//public partial class LoggingProxyGeneratorClass :
//    IProxyGeneratorInterface
//{
//    [Interceptor]
//    private readonly LoggingInterceptors interceptors;
//}
