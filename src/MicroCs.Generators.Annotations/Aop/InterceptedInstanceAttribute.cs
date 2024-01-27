namespace MicroCs.Generators.Aop;

/// <summary>
/// Marks a parameter to receive the intercepted instance.
/// The parameter type must be assignable from the type of the intercepted instance.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter)]
public sealed class InterceptedInstanceAttribute : Attribute
{
}