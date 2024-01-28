using MicroCs.Generators.Aop;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace MicroCs.Generators.Lib.Samples.HasNoInterfaces
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

namespace MicroCs.Generators.Samples.HasNoInterfaces
{
    using MicroCs.Generators.Lib.Samples.HasNoInterfaces;

    [GenerateProxy]
    public partial class LoggingProxyGeneratorClass
    {
        [Interceptor]
        private readonly LoggingInterceptors interceptors;
    }
}
