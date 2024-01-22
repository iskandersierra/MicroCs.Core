﻿// <auto-generated />

#nullable enable

{{~ if HasNamespace ~}}
namespace {{Namespace}};
{{~ end ~}}

partial class {{Name}}
{
    private static readonly global::System.Type ProxyType_Cache;

    public {{Name}}(
        {{~ for interf in Interfaces ~}}
        {{interf.InterfaceType.FullName}} {{interf.ParameterName}},
        {{~ end ~}}
        {{Interceptor.InterceptorType.FullName}} {{Interceptor.ParameterName}})
    {
        {{~ for interf in Interfaces ~}}
        this.{{interf.ParameterName}} = {{interf.ParameterName}};
        {{~ end ~}}
        this.{{Interceptor.ParameterName}} = {{Interceptor.ParameterName}};
    }

    static {{Name}}()
    {
        ProxyType_Cache = typeof({{Name}});
        {{~ for interf in Interfaces ~}}

        // {{interf.InterfaceType.Name}}

        {{interf.InterfaceType.Name}}_TargetType_Cache = typeof({{interf.InterfaceType.FullName}});
        {{~ for method in interf.InterfaceType.Methods ~}}

        {{method.Name}}_{{for.index}}_Cache =
            IProxyGeneratorInterface_TargetType_Cache!.GetMethod(
                name: {{method.Name}}_{{for.index}}_Name,
                bindingAttr: global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.Instance,
                binder: null,
                genericParameterCount: 0,
                callConvention: global::System.Reflection.CallingConventions.Any,
                {{~ if (method.Parameters | array.size) == 0 ~}}
                types: global::System.Array.Empty<global::System.Type>(),
                {{~ else ~}}
                types: new global::System.Type[] {
                    {{~ for param in method.Parameters ~}}
                    typeof({{param.Type.FullName}}),
                    {{~ end ~}}
                },
                {{~ end ~}}
                modifiers: null)!;
        {{~ end ~}}
        {{~ end ~}}
    }
    {{~ for interf in Interfaces ~}}

    #region [ {{interf.InterfaceType.Name}} ]

    private readonly {{interf.InterfaceType.FullName}} {{interf.ParameterName}};

    private static readonly global::System.Type {{interf.InterfaceType.Name}}_TargetType_Cache;
    {{~ for method in interf.InterfaceType.Methods ~}}

    #region [ {{method.Name}} ]

    private const string {{method.Name}}_{{for.index}}_Name = nameof({{interf.InterfaceType.FullName}}.{{method.Name}});

    private static readonly global::System.Reflection.MethodInfo {{method.Name}}_{{for.index}}_Cache;

    {{method.ReturnType.FullName}} {{interf.InterfaceType.FullName}}.{{method.Name}}()
    {
        {{ if method.ReturnType.FullName != "void" }}return {{ end -}}
        {{interf.ParameterName}}.{{method.Name}}();
    }

    #endregion [ {{method.Name}} ]
    {{~ end ~}}

    #endregion [ {{interf.InterfaceType.Name}} ]
    {{~ end ~}}
}
