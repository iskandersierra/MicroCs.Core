namespace MicroCs.Generators.Aop;

internal class ProxyGeneratorAttributesModel
{
    public string Namespace { get; set; } = default!;
}

internal class ProxyGeneratorClassModel : TypeModel
{
    public bool ShouldGenerateCode => true;
    public string ProxyTypeNameName => "ProxyType_Name";
    public string ProxyTypeCacheName => "ProxyType_Cache";

    public bool HasParameterWith(
        Func<ProxyInterceptorCallParameterModel, bool> predicate)
    {
        return Interceptor.Calls
            .SelectMany(c => c.Parameters)
            .Any(predicate);
    }

    public bool ShouldGenerateProxyTypeCache =>
        HasParameterWith(p => p.InterceptedProxyType is not null);
    public bool ShouldGenerateProxyTypeName => ShouldGenerateProxyTypeCache;

    public IReadOnlyList<ProxyGeneratorInterfaceModel> Interfaces { get; set; } = default!;
    public ProxyGeneratorInterceptorModel Interceptor { get; set; } = default!;
}

internal class ProxyGeneratorInterfaceModel
{
    public ProxyGeneratorClassModel DeclaringClass { get; set; } = default!;
    public string ParameterName { get; set; } = default!;
    public TypeWithMembersModel Type { get; set; } = default!;
    public string TargetTypeNameName => $"{Type.Name}_TargetType_Name";
    public string TargetTypeCacheName => $"{Type.Name}_TargetType_Cache";
    public bool ShouldGenerateTargetTypeCache =>
        DeclaringClass.HasParameterWith(p => p.InterceptedTargetType is not null);
    public bool ShouldGenerateTargetTypeName => ShouldGenerateTargetTypeCache;
    public IReadOnlyList<ProxyGeneratorInterfaceMethodModel> Methods { get; set; } = default!;
}

internal class ProxyGeneratorInterfaceMethodModel
{
    public ProxyGeneratorInterfaceModel DeclaringInterface { get; set; } = default!;
    public MethodModel Method { get; set; } = default!;
    public int Index { get; set; } = default!;
    public bool IsAsync { get; set; } = default!;
    public TypeModel ResultType { get; set; } = default!;
    public string MethodNameConstName => $"{Method.Name}_{Index}_Name";
    public string MethodCacheName => $"{Method.Name}_{Index}_Cache";
    public bool ShouldGenerateMethodCache =>
        DeclaringInterface.DeclaringClass
            .HasParameterWith(p => p.InterceptedMember is not null);
    public bool ShouldGenerateMethodName => ShouldGenerateMethodCache;
}

internal class ProxyGeneratorInterceptorModel
{
    public ProxyGeneratorClassModel DeclaringClass { get; set; } = default!;
    public string ParameterName { get; set; } = default!;
    public TypeWithMembersModel Type { get; set; } = default!;

    public bool HasState => (BeforeCall?.HasState ?? false) && HasAfterCalls;
    public bool HasAfterCalls => AfterCall is not null || AfterSuccessCall is not null || AfterFailureCall is not null;

    public bool HasParametersArgument =>
        (BeforeCall?.HasParametersArgument ?? false) ||
        (AfterCall?.HasParametersArgument ?? false) ||
        (AfterSuccessCall?.HasParametersArgument ?? false) ||
        (AfterFailureCall?.HasParametersArgument ?? false);

    public ProxyBeforeCallModel? BeforeCall { get; set; }
    public ProxyAfterCallModel? AfterCall { get; set; }
    public ProxyAfterSuccessCallModel? AfterSuccessCall { get; set; }
    public ProxyAfterFailureCallModel? AfterFailureCall { get; set; }

    public IEnumerable<ProxyInterceptorCallModel> Calls =>
        new ProxyInterceptorCallModel?[]
            {
                BeforeCall,
                AfterCall,
                AfterSuccessCall,
                AfterFailureCall,
            }
            .Where(c => c is not null)
            .Cast<ProxyInterceptorCallModel>();
}

internal abstract class ProxyInterceptorCallModel
{
    public MethodModel Method { get; set; } = default!;
    public string Name => Method.Name;
    public IReadOnlyList<ProxyInterceptorCallParameterModel> Parameters { get; set; } = default!;

    public ProxyInterceptorCallParameterModel? ParametersArgument =>
        Parameters.FirstOrDefault(p => p.InterceptedParameters is not null);
    public bool HasParametersArgument => ParametersArgument is not null;
}

internal class ProxyBeforeCallModel : ProxyInterceptorCallModel
{
    public bool HasState => !Method.ReturnType.IsVoid;
}

internal class ProxyAfterCallModel : ProxyInterceptorCallModel
{
}

internal class ProxyAfterSuccessCallModel : ProxyInterceptorCallModel
{
}

internal class ProxyAfterFailureCallModel : ProxyInterceptorCallModel
{
}

internal class ProxyInterceptorCallParameterModel
{
    public MethodParameterModel Parameter { get; set; } = default!;

    public string Name => Parameter.Name;

    public ProxyInterceptorAttributeModel? InterceptedException { get; set; }
    public ProxyInterceptorAttributeModel? InterceptedInstance { get; set; }
    public ProxyInterceptorInterceptedMemberAttributeModel? InterceptedMember { get; set; }
    public ProxyInterceptorInterceptedParameterAttributeModel? InterceptedParameter { get; set; }
    public ProxyInterceptorInterceptedParametersAttributeModel? InterceptedParameters { get; set; }
    public ProxyInterceptorAttributeModel? InterceptedProxyInstance { get; set; }
    public ProxyInterceptorInterceptedProxyTypeAttributeModel? InterceptedProxyType { get; set; }
    public ProxyInterceptorAttributeModel? InterceptedResult { get; set; }
    public ProxyInterceptorAttributeModel? InterceptedState { get; set; }
    public ProxyInterceptorInterceptedTargetTypeAttributeModel? InterceptedTargetType { get; set; }
}

internal class ProxyInterceptorAttributeModel
{
    public static readonly ProxyInterceptorAttributeModel Default = new();
}

internal enum TypeReferenceKind
{
    Type,
    String,
}

internal enum MemberReferenceKind
{
    MethodInfo,
    String,
}

internal class ProxyInterceptorInterceptedProxyTypeAttributeModel :
    ProxyInterceptorAttributeModel
{
    public TypeReferenceKind ReferenceKind { get; set; }
}

internal class ProxyInterceptorInterceptedTargetTypeAttributeModel :
    ProxyInterceptorAttributeModel
{
    public TypeReferenceKind ReferenceKind { get; set; }
}

internal class ProxyInterceptorInterceptedMemberAttributeModel :
    ProxyInterceptorAttributeModel
{
    public MemberReferenceKind ReferenceKind { get; set; }
}

internal class ProxyInterceptorInterceptedParametersAttributeModel :
    ProxyInterceptorAttributeModel
{
    public bool AllowChanges { get; set; }
}

internal class ProxyInterceptorInterceptedParameterAttributeModel :
    ProxyInterceptorAttributeModel
{
    public int? Position { get; set; }
    public string? Name { get; set; }
    public string? TypeName { get; set; }
    public string? TypeNamespace { get; set; }
    public string? TypeFullName { get; set; }
    public TypeModel? Type { get; set; }
    public string? Predicate { get; set; }
}
