namespace MicroCs.Generators.Aop;

internal class ProxyGeneratorAttributesModel
{
    public string Namespace { get; set; } = default!;
}

internal class ProxyGeneratorClassModel : TypeModel
{
    public bool ShouldGenerateCode => true;
    public string ProxyTypeCacheName => "ProxyType_Cache";
    public bool ShouldGenerateProxyTypeCache => true;

    public IReadOnlyList<ProxyGeneratorInterfaceModel> Interfaces { get; set; } = default!;
    public ProxyGeneratorInterceptorModel Interceptor { get; set; } = default!;
}

internal class ProxyGeneratorInterfaceModel
{
    public bool ShouldGenerateTargetTypeCache => true;
    public string ParameterName { get; set; } = default!;
    public TypeWithMembersModel Type { get; set; } = default!;
    public string TargetTypeCacheName => $"{Type.Name}_TargetType_Cache";
    public IReadOnlyList<ProxyGeneratorInterfaceMethodModel> Methods { get; set; } = default!;
}

internal class ProxyGeneratorInterfaceMethodModel
{
    public MethodModel Method { get; set; } = default!;
    public int Index { get; set; } = default!;
    public bool IsAsync { get; set; } = default!;
    public TypeModel ResultType { get; set; } = default!;
    public string MethodNameConstName => $"{Method.Name}_{Index}_Name";
    public string MethodCacheName => $"{Method.Name}_{Index}_Cache";
}

internal class ProxyGeneratorInterceptorModel
{
    public string ParameterName { get; set; } = default!;
    public TypeWithMembersModel Type { get; set; } = default!;

    public bool HasState => BeforeCall?.HasState ?? false;

    public ProxyBeforeCallModel? BeforeCall { get; set; }
}

internal abstract class ProxyInterceptorCallModel
{
    public MethodModel Method { get; set; } = default!;
    public string Name => Method.Name;
}

internal class ProxyBeforeCallModel : ProxyInterceptorCallModel
{
    public bool HasState => !Method.ReturnType.IsVoid;
}
