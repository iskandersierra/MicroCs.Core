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
    public async Task BeforeCall_SyncVoid_NoParam()
    {
        await GeneratorTestUtils.Verify<ProxyGenerator>($"{AssetsPath}.BeforeCall.cs");
    }
}
