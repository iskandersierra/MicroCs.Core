namespace MicroCs.Generators.Aop;

public class ProxyGeneratorAttributesModel
{
    public string Namespace { get; set; }
}

public class ProxyGeneratorClassModel : NamedTypeModel
{
    public bool ShouldGenerateCode => true;

    public IReadOnlyList<ProxyGeneratorInterfaceModel> Interfaces { get; set; }
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

    public ProxyGeneratorInterceptorModel Interceptor { get; set; }
}

public class ProxyGeneratorInterfaceModel
{
    public string ParameterName { get; set; }
    public InterfaceModel InterfaceType { get; set; }
}

public class ProxyGeneratorInterceptorModel
{
    public string ParameterName { get; set; }
    public ClassModel InterceptorType { get; set; }
}

// Shared types

public class NamedTypeModel
{
    public string? Namespace { get; set; }
    public bool HasNamespace => !string.IsNullOrWhiteSpace(Namespace);
    public string FullName { get; set; }
    public string Name { get; set; }
}

public class ClassBaseModel : NamedTypeModel
{
}

public class InterfaceModel : ClassBaseModel
{
}

public class ClassModel : ClassBaseModel
{
}
