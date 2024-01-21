using Microsoft.CodeAnalysis;

namespace MicroCs.Generators.Aop;

[Generator(LanguageNames.CSharp)]
public class ProxyGenerator :
    IIncrementalGenerator
{
    public void Initialize(
        IncrementalGeneratorInitializationContext context)
    {
        context.RegisterProxyAttributes();

        context.RegisterProxyClasses();
    }
}
