using MicroCs.Generators.Aop;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace MicroCs.Generators.Lib.Samples.HasMultipleInterceptors
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

namespace MicroCs.Generators.Samples.HasMultipleInterceptors
{
    using MicroCs.Generators.Lib.Samples.HasMultipleInterceptors;

    [GenerateProxy]
    public partial class LoggingProxyGeneratorClass :
        IProxyGeneratorInterface
    {
        [Interceptor]
        private readonly LoggingInterceptors interceptors1;

        [Interceptor]
        private readonly LoggingInterceptors interceptors2;
    }
}
