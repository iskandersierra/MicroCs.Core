﻿//HintName: LoggingProxyGeneratorClass.0.g.cs
// <auto-generated />

#nullable enable

namespace Sample.BeforeCall;

partial class LoggingProxyGeneratorClass
{
    private static readonly global::System.Type ProxyType_Cache;

    public LoggingProxyGeneratorClass(
        global::Sample.BeforeCall.IProxyGeneratorInterface iproxygeneratorinterface,
        global::Sample.BeforeCall.LoggingInterceptors interceptors)
    {
        this.iproxygeneratorinterface = iproxygeneratorinterface;
        this.interceptors = interceptors;
    }

    static LoggingProxyGeneratorClass()
    {
        ProxyType_Cache = typeof(LoggingProxyGeneratorClass);

        // IProxyGeneratorInterface

        IProxyGeneratorInterface_TargetType_Cache = typeof(global::Sample.BeforeCall.IProxyGeneratorInterface);

        MyMethod_0_Cache =
            IProxyGeneratorInterface_TargetType_Cache!.GetMethod(
                name: MyMethod_0_Name,
                bindingAttr: global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.Instance,
                binder: null,
                genericParameterCount: 0,
                callConvention: global::System.Reflection.CallingConventions.Any,
                types: global::System.Array.Empty<global::System.Type>(),
                modifiers: null)!;

        MyMethod_1_Cache =
            IProxyGeneratorInterface_TargetType_Cache!.GetMethod(
                name: MyMethod_1_Name,
                bindingAttr: global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.Instance,
                binder: null,
                genericParameterCount: 0,
                callConvention: global::System.Reflection.CallingConventions.Any,
                types: new global::System.Type[] {
                    typeof(string),
                    typeof(int),
                },
                modifiers: null)!;

        MyMethod_2_Cache =
            IProxyGeneratorInterface_TargetType_Cache!.GetMethod(
                name: MyMethod_2_Name,
                bindingAttr: global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.Instance,
                binder: null,
                genericParameterCount: 0,
                callConvention: global::System.Reflection.CallingConventions.Any,
                types: new global::System.Type[] {
                    typeof(string),
                    typeof(DateTime),
                },
                modifiers: null)!;
    }

    #region [ IProxyGeneratorInterface ]

    private readonly global::Sample.BeforeCall.IProxyGeneratorInterface iproxygeneratorinterface;

    private static readonly global::System.Type IProxyGeneratorInterface_TargetType_Cache;

    #region [ MyMethod ]

    private const string MyMethod_0_Name = nameof(global::Sample.BeforeCall.IProxyGeneratorInterface.MyMethod);

    private static readonly global::System.Reflection.MethodInfo MyMethod_0_Cache;

    void global::Sample.BeforeCall.IProxyGeneratorInterface.MyMethod()
    {
        iproxygeneratorinterface.MyMethod();
    }

    #endregion [ MyMethod ]

    #region [ MyMethod ]

    private const string MyMethod_1_Name = nameof(global::Sample.BeforeCall.IProxyGeneratorInterface.MyMethod);

    private static readonly global::System.Reflection.MethodInfo MyMethod_1_Cache;

    string global::Sample.BeforeCall.IProxyGeneratorInterface.MyMethod()
    {
        return iproxygeneratorinterface.MyMethod();
    }

    #endregion [ MyMethod ]

    #region [ MyMethod ]

    private const string MyMethod_2_Name = nameof(global::Sample.BeforeCall.IProxyGeneratorInterface.MyMethod);

    private static readonly global::System.Reflection.MethodInfo MyMethod_2_Cache;

    (string, DateTime) global::Sample.BeforeCall.IProxyGeneratorInterface.MyMethod()
    {
        return iproxygeneratorinterface.MyMethod();
    }

    #endregion [ MyMethod ]

    #endregion [ IProxyGeneratorInterface ]
}
