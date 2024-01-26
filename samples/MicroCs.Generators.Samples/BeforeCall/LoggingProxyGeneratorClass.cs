﻿using MicroCs.Generators.Aop;
using MicroCs.Generators.Lib.Samples.BeforeCall;

namespace MicroCs.Generators.Samples.BeforeCall;

// [GenerateProxy]
public partial class LoggingProxyGeneratorClass :
    IProxyGeneratorInterface
{
    [Interceptor]
    private readonly LoggingInterceptors interceptors;
}

partial class LoggingProxyGeneratorClass
{
    private const string ProxyType_Name = nameof(LoggingProxyGeneratorClass);
    private static readonly System.Type ProxyType_Cache;
    public LoggingProxyGeneratorClass(global::MicroCs.Generators.Lib.Samples.BeforeCall.IProxyGeneratorInterface iProxyGeneratorInterface, global::MicroCs.Generators.Lib.Samples.BeforeCall.LoggingInterceptors interceptors)
    {
        this.iProxyGeneratorInterface = iProxyGeneratorInterface;
        this.interceptors = interceptors;
    }

    static LoggingProxyGeneratorClass()
    {
        ProxyType_Cache = typeof(LoggingProxyGeneratorClass);
        IProxyGeneratorInterface_TargetType_Cache = typeof(global::MicroCs.Generators.Lib.Samples.BeforeCall.IProxyGeneratorInterface);
        MyMethod_0_Cache = IProxyGeneratorInterface_TargetType_Cache!.GetMethod(name: MyMethod_0_Name, bindingAttr: System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance, binder: null, genericParameterCount: 0, callConvention: System.Reflection.CallingConventions.Any, types: System.Array.Empty<System.Type>(), modifiers: null)!;
        MyMethod_1_Cache = IProxyGeneratorInterface_TargetType_Cache!.GetMethod(name: MyMethod_1_Name, bindingAttr: System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance, binder: null, genericParameterCount: 0, callConvention: System.Reflection.CallingConventions.Any, types: new System.Type[] { typeof(string), typeof(int) }, modifiers: null)!;
        MyMethod_2_Cache = IProxyGeneratorInterface_TargetType_Cache!.GetMethod(name: MyMethod_2_Name, bindingAttr: System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance, binder: null, genericParameterCount: 0, callConvention: System.Reflection.CallingConventions.Any, types: new System.Type[] { typeof(string), typeof(System.DateTime) }, modifiers: null)!;
        MyMethod_3_Cache = IProxyGeneratorInterface_TargetType_Cache!.GetMethod(name: MyMethod_3_Name, bindingAttr: System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance, binder: null, genericParameterCount: 0, callConvention: System.Reflection.CallingConventions.Any, types: new System.Type[] { typeof(int), typeof(System.Threading.CancellationToken) }, modifiers: null)!;
        MyMethod_4_Cache = IProxyGeneratorInterface_TargetType_Cache!.GetMethod(name: MyMethod_4_Name, bindingAttr: System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance, binder: null, genericParameterCount: 0, callConvention: System.Reflection.CallingConventions.Any, types: new System.Type[] { typeof(int), typeof(string), typeof(System.Threading.CancellationToken) }, modifiers: null)!;
    }

    private readonly global::MicroCs.Generators.Lib.Samples.BeforeCall.IProxyGeneratorInterface iProxyGeneratorInterface;
    private const string IProxyGeneratorInterface_TargetType_Name = nameof(global::MicroCs.Generators.Lib.Samples.BeforeCall.IProxyGeneratorInterface);
    private static readonly System.Type IProxyGeneratorInterface_TargetType_Cache;
    private const string MyMethod_0_Name = nameof(global::MicroCs.Generators.Lib.Samples.BeforeCall.IProxyGeneratorInterface.MyMethod);
    private static readonly System.Reflection.MethodInfo MyMethod_0_Cache;
    void global::MicroCs.Generators.Lib.Samples.BeforeCall.IProxyGeneratorInterface.MyMethod()
    {
        var parameters = new object?[]
        {
        };
        interceptors.BeforeCall(proxyType: ProxyType_Cache, proxyTypeName: ProxyType_Name, proxyInstance: this, instance: iProxyGeneratorInterface, targetType: IProxyGeneratorInterface_TargetType_Cache, targetTypeName: IProxyGeneratorInterface_TargetType_Name, methodInfo: MyMethod_0_Cache, methodName: MyMethod_0_Name, parameters: parameters, stringParameter: default);
        iProxyGeneratorInterface.MyMethod();
    }

    private const string MyMethod_1_Name = nameof(global::MicroCs.Generators.Lib.Samples.BeforeCall.IProxyGeneratorInterface.MyMethod);
    private static readonly System.Reflection.MethodInfo MyMethod_1_Cache;  
    string global::MicroCs.Generators.Lib.Samples.BeforeCall.IProxyGeneratorInterface.MyMethod(string input1, int input2)
    {
        var parameters = new object?[]
        {
            input1,
            input2
        };
        interceptors.BeforeCall(proxyType: ProxyType_Cache, proxyTypeName: ProxyType_Name, proxyInstance: this, instance: iProxyGeneratorInterface, targetType: IProxyGeneratorInterface_TargetType_Cache, targetTypeName: IProxyGeneratorInterface_TargetType_Name, methodInfo: MyMethod_1_Cache, methodName: MyMethod_1_Name, parameters: parameters, stringParameter: default);
        return iProxyGeneratorInterface.MyMethod((string)parameters[0], (int)parameters[1]);
    }

    private const string MyMethod_2_Name = nameof(global::MicroCs.Generators.Lib.Samples.BeforeCall.IProxyGeneratorInterface.MyMethod);
    private static readonly System.Reflection.MethodInfo MyMethod_2_Cache;
    (string, System.DateTime) global::MicroCs.Generators.Lib.Samples.BeforeCall.IProxyGeneratorInterface.MyMethod(string input1, System.DateTime input2)
    {
        var parameters = new object?[]
        {
            input1,
            input2
        };
        interceptors.BeforeCall(proxyType: ProxyType_Cache, proxyTypeName: ProxyType_Name, proxyInstance: this, instance: iProxyGeneratorInterface, targetType: IProxyGeneratorInterface_TargetType_Cache, targetTypeName: IProxyGeneratorInterface_TargetType_Name, methodInfo: MyMethod_2_Cache, methodName: MyMethod_2_Name, parameters: parameters, stringParameter: default);
        return iProxyGeneratorInterface.MyMethod((string)parameters[0], (System.DateTime)parameters[1]);
    }

    private const string MyMethod_3_Name = nameof(global::MicroCs.Generators.Lib.Samples.BeforeCall.IProxyGeneratorInterface.MyMethod);
    private static readonly System.Reflection.MethodInfo MyMethod_3_Cache;
    async System.Threading.Tasks.Task global::MicroCs.Generators.Lib.Samples.BeforeCall.IProxyGeneratorInterface.MyMethod(int input1, System.Threading.CancellationToken cancel)
    {
        var parameters = new object?[]
        {
            input1,
            cancel
        };
        interceptors.BeforeCall(proxyType: ProxyType_Cache, proxyTypeName: ProxyType_Name, proxyInstance: this, instance: iProxyGeneratorInterface, targetType: IProxyGeneratorInterface_TargetType_Cache, targetTypeName: IProxyGeneratorInterface_TargetType_Name, methodInfo: MyMethod_3_Cache, methodName: MyMethod_3_Name, parameters: parameters, stringParameter: default);
        await iProxyGeneratorInterface.MyMethod((int)parameters[0], (System.Threading.CancellationToken)parameters[1]);
    }

    private const string MyMethod_4_Name = nameof(global::MicroCs.Generators.Lib.Samples.BeforeCall.IProxyGeneratorInterface.MyMethod);
    private static readonly System.Reflection.MethodInfo MyMethod_4_Cache;
    async System.Threading.Tasks.Task<string> global::MicroCs.Generators.Lib.Samples.BeforeCall.IProxyGeneratorInterface.MyMethod(int input1, string? input2, System.Threading.CancellationToken cancel)
    {
        var parameters = new object?[]
        {
            input1,
            input2,
            cancel
        };
        interceptors.BeforeCall(proxyType: ProxyType_Cache, proxyTypeName: ProxyType_Name, proxyInstance: this, instance: iProxyGeneratorInterface, targetType: IProxyGeneratorInterface_TargetType_Cache, targetTypeName: IProxyGeneratorInterface_TargetType_Name, methodInfo: MyMethod_4_Cache, methodName: MyMethod_4_Name, parameters: parameters, stringParameter: default);
        return await iProxyGeneratorInterface.MyMethod((int)parameters[0], (string?)parameters[1], (System.Threading.CancellationToken)parameters[2]);
    }
}