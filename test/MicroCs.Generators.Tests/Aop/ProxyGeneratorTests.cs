using MicroCs.Generators.Aop;

namespace MicroCs.Generators.Tests.Aop;

[UsesVerify]
public class ProxyGeneratorTests
{
    private const string AssetsPath = "MicroCs.Generators.Tests.Aop.assets";

    [Fact]
    public async Task EmptySource()
    {
        await GeneratorTestUtils.Verify<ProxyGenerator>($"{AssetsPath}.EmptySource.cs");
    }

    [Fact]
    public async Task BeforeCall()
    {
        await GeneratorTestUtils.Verify<ProxyGenerator>(
            new []
            {
                $"{AssetsPath}.BeforeCall.cs",
                $"{AssetsPath}.BeforeCall.Interface.cs",
                $"{AssetsPath}.BeforeCall.Interceptor.cs",
            });
    }

    [Fact]
    public async Task BeforeAfterAllCall()
    {
        await GeneratorTestUtils.Verify<ProxyGenerator>($"{AssetsPath}.BeforeAfterAllCall.cs");
    }
}
