using MicroCs.Generators.Aop;
using MicroCs.Generators.Lib.Samples.BeforeAfterAllCall;

namespace MicroCs.Generators.Samples.BeforeAfterAllCall;

[GenerateProxy]
public partial class LoggingProxyGeneratorClass :
   IProxyGeneratorInterface
{
   [Interceptor]
   private readonly LoggingInterceptors interceptors;
}
