namespace MicroCs.Generators.Aop;

internal class ProxyGeneratorAttributesModel
{
    public string Namespace { get; set; } = default!;
}

internal class ProxyGeneratorClassModel : NamedTypeModel
{
    public bool ShouldGenerateCode => true;

    public IReadOnlyList<ProxyGeneratorInterfaceModel> Interfaces { get; set; } = default!;
    public IEnumerable<string> ConstructorParameters
    {
        get
        {
            foreach (var @interface in Interfaces)
            {
                yield return $"{@interface.InterfaceType.FullName} {@interface.ParameterName}";
            }

            yield return $"{Interceptor.InterceptorType.FullName} {Interceptor.ParameterName}";
        }
    }

    public ProxyGeneratorInterceptorModel Interceptor { get; set; } = default!;
}

internal class ProxyGeneratorInterfaceModel
{
    public string ParameterName { get; set; } = default!;
    public InterfaceModel InterfaceType { get; set; } = default!;
}

internal class ProxyGeneratorInterceptorModel
{
    public string ParameterName { get; set; } = default!;
    public ClassModel InterceptorType { get; set; } = default!;
    public ProxyInterceptorDataModel InterceptorData { get; set; } = default!;
}

internal class ProxyInterceptorDataModel
{
}
