using MicroCs.Generators.Aop;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace MicroCs.Generators.Lib.Samples.HasNoInterceptor
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

namespace MicroCs.Generators.Samples.HasNoInterceptor
{
    using MicroCs.Generators.Lib.Samples.HasNoInterceptor;

    [GenerateProxy]
    public partial class LoggingProxyGeneratorClass :
        IProxyGeneratorInterface
    {
    }
}
