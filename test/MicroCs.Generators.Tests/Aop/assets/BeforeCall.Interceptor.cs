using MicroCs.Generators.Aop;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace MicroCs.Generators.Lib.Samples.BeforeCall
{
    public class LoggingInterceptors
    {
        [InterceptBefore()]
        public Data BeforeCall(
            [InterceptedProxyType] Type proxyType,
            [InterceptedProxyType] string proxyTypeName,
            [InterceptedProxyInstance] object proxyInstance,
            [InterceptedInstance] IProxyGeneratorInterface instance,
            [InterceptedTargetType] Type targetType,
            [InterceptedTargetType] string targetTypeName,
            [InterceptedMember] MethodInfo methodInfo,
            [InterceptedMember] string methodName,
            [InterceptedParameters] object?[] parameters)
        {
            return default!;
        }

        public struct Data(long StartTimestamp);
    }
}
