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
        await GeneratorTestUtils.Verify<ProxyGenerator>($"{AssetsPath}.BeforeCall.cs");
    }

    [Fact]
    public async Task BeforeAfterCall()
    {
        await GeneratorTestUtils.Verify<ProxyGenerator>($"{AssetsPath}.BeforeAfterCall.cs");
    }

    [Fact]
    public async Task BeforeAfterSuccessCall()
    {
        await GeneratorTestUtils.Verify<ProxyGenerator>($"{AssetsPath}.BeforeAfterSuccessCall.cs");
    }

    [Fact]
    public async Task BeforeAfterFailureCall()
    {
        await GeneratorTestUtils.Verify<ProxyGenerator>($"{AssetsPath}.BeforeAfterFailureCall.cs");
    }

    [Fact]
    public async Task BeforeNoAfterCall()
    {
        await GeneratorTestUtils.Verify<ProxyGenerator>($"{AssetsPath}.BeforeNoAfterCall.cs");
    }

    [Fact]
    public async Task BeforeNoAfterSuccessCall()
    {
        await GeneratorTestUtils.Verify<ProxyGenerator>($"{AssetsPath}.BeforeNoAfterSuccessCall.cs");
    }

    [Fact]
    public async Task BeforeNoAfterFailureCall()
    {
        await GeneratorTestUtils.Verify<ProxyGenerator>($"{AssetsPath}.BeforeNoAfterFailureCall.cs");
    }

    [Fact]
    public async Task BeforeAfterAllCall()
    {
        await GeneratorTestUtils.Verify<ProxyGenerator>($"{AssetsPath}.BeforeAfterAllCall.cs");
    }

    [Fact]
    public async Task WithoutNamespace()
    {
        await GeneratorTestUtils.Verify<ProxyGenerator>($"{AssetsPath}.WithoutNamespace.cs");
    }

    [Fact]
    public async Task ParametersAllowChanges()
    {
        await GeneratorTestUtils.Verify<ProxyGenerator>($"{AssetsPath}.ParametersAllowChanges.cs");
    }

    // Diagnostic errors

    [Fact]
    public async Task UnexpectedTypeOnSymbol()
    {
        // MC0001
        await GeneratorTestUtils.Verify<ProxyGenerator>($"{AssetsPath}.UnexpectedTypeOnSymbol.cs");
    }

    [Fact]
    public async Task HasNoInterfaces()
    {
        // MCAOP0001
        await GeneratorTestUtils.Verify<ProxyGenerator>($"{AssetsPath}.HasNoInterfaces.cs");
    }

    [Fact]
    public async Task HasNoInterceptor()
    {
        // MCAOP0002
        await GeneratorTestUtils.Verify<ProxyGenerator>($"{AssetsPath}.HasNoInterceptor.cs");
    }

    [Fact]
    public async Task HasMultipleInterceptors()
    {
        // MCAOP0003
        await GeneratorTestUtils.Verify<ProxyGenerator>($"{AssetsPath}.HasMultipleInterceptors.cs");
    }

    [Fact]
    public async Task InterceptorIsNotNamedType()
    {
        // MCAOP0004
        await GeneratorTestUtils.Verify<ProxyGenerator>($"{AssetsPath}.InterceptorIsNotNamedType.cs");
    }

    [Fact]
    public async Task MultipleInterceptionAttributes()
    {
        // MCAOP0004
        await GeneratorTestUtils.Verify<ProxyGenerator>($"{AssetsPath}.MultipleInterceptionAttributes.cs");
    }

    [Fact]
    public async Task NoInterceptionAttributes()
    {
        // MCAOP0005
        await GeneratorTestUtils.Verify<ProxyGenerator>($"{AssetsPath}.NoInterceptionAttributes.cs");
    }
}
