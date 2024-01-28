using MicroCs.Generators.Aop;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace MicroCs.Generators.Lib.Samples.InterceptorIsNotNamedType
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

namespace MicroCs.Generators.Samples.InterceptorIsNotNamedType
{
    using MicroCs.Generators.Lib.Samples.InterceptorIsNotNamedType;

    [GenerateProxy]
    public partial class LoggingProxyGeneratorClass :
        IProxyGeneratorInterface
    {
        [Interceptor]
        private readonly object[] interceptors;
    }
}
