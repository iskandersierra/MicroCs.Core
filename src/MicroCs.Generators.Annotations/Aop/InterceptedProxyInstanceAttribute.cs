﻿namespace MicroCs.Generators.Aop;

/// <summary>
/// Marks a parameter to receive the intercepted proxy instance.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter, Inherited = false, AllowMultiple = false)]
public sealed class InterceptedProxyInstanceAttribute : Attribute
{
}