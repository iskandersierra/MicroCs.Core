using MicroCs.Generators.Aop;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace MicroCs.Generators.Lib.Samples.WithoutNamespace
{
    public interface IProxyGeneratorInterface
    {
        void MyMethod();
    }

    public class LoggingInterceptors
    {
        [InterceptBefore()]
        public void BeforeCall()
        {
        }
    }
}

[GenerateProxy]
public partial class LoggingProxyGeneratorClass :
    MicroCs.Generators.Lib.Samples.WithoutNamespace.IProxyGeneratorInterface
{
    [Interceptor]
    private readonly MicroCs.Generators.Lib.Samples.WithoutNamespace.LoggingInterceptors interceptors;
}
