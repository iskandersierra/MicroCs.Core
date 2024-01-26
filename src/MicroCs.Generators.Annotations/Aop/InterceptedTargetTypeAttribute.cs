namespace MicroCs.Generators.Aop;

/// <summary>
/// Marks a parameter to receive the target or intercepted type.
/// The parameter type must be either <see cref="Type"/> or <see cref="string"/>.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter, Inherited = false, AllowMultiple = false)]
public sealed class InterceptedTargetTypeAttribute : Attribute
{
}