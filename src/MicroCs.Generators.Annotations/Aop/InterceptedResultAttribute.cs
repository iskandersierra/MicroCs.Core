﻿namespace MicroCs.Generators.Aop;

/// <summary>
/// Marks a parameter to receive the intercepted result.
/// This attribute is only valid on interceptor methods marked with the <see cref="InterceptAfterSuccessAttribute"/>.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter, Inherited = false, AllowMultiple = false)]
public sealed class InterceptedResultAttribute : Attribute
{
}