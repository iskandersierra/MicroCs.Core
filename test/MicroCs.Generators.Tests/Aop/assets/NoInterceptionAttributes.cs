using MicroCs.Generators.Aop;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace MicroCs.Generators.Lib.Samples.NoInterceptionAttributes
{
    public interface IProxyGeneratorInterface
    {
        void MyMethod();
    }

    public class LoggingInterceptors
    {
        [InterceptBefore()]
        public void BeforeCall(string methodName)
        {
        }
        [InterceptAfter()]
        public void AfterCall(string methodName)
        {
        }
        [InterceptAfterSuccess()]
        public void AfterSuccessCall(string methodName)
        {
        }
        [InterceptAfterFailure()]
        public void AfterFailureCall(string methodName)
        {
        }
    }
}

namespace MicroCs.Generators.Samples.NoInterceptionAttributes
{
    using MicroCs.Generators.Lib.Samples.NoInterceptionAttributes;

    [GenerateProxy]
    public partial class LoggingProxyGeneratorClass :
        IProxyGeneratorInterface
    {
        [Interceptor]
        private readonly LoggingInterceptors interceptors;
    }
}
