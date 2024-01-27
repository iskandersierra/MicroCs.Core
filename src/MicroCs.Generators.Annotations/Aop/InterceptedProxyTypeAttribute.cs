namespace MicroCs.Generators.Aop;

/// <summary>
/// Marks a parameter to receive the intercepted proxy type.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter)]
public sealed class InterceptedProxyTypeAttribute : Attribute
{
}