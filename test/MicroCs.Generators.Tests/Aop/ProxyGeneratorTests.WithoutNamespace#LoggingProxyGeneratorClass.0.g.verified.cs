﻿//HintName: LoggingProxyGeneratorClass.0.g.cs
// <auto-generated />
#nullable enable
partial class LoggingProxyGeneratorClass
{
    public LoggingProxyGeneratorClass(global::MicroCs.Generators.Lib.Samples.WithoutNamespace.IProxyGeneratorInterface iProxyGeneratorInterface, global::MicroCs.Generators.Lib.Samples.WithoutNamespace.LoggingInterceptors interceptors)
    {
        this.iProxyGeneratorInterface = iProxyGeneratorInterface;
        this.interceptors = interceptors;
    }

    static LoggingProxyGeneratorClass()
    {
    }

    private readonly global::MicroCs.Generators.Lib.Samples.WithoutNamespace.IProxyGeneratorInterface iProxyGeneratorInterface;
    void global::MicroCs.Generators.Lib.Samples.WithoutNamespace.IProxyGeneratorInterface.MyMethod()
    {
        interceptors.BeforeCall();
        iProxyGeneratorInterface.MyMethod();
    }
}