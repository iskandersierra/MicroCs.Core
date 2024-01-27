namespace MicroCs.Generators.Aop;

/// <summary>
/// Marks a parameter to receive the intercepted state.
/// This attribute is only valid on interceptor methods marked with any of the after interceptors.
/// It only makes sense when the before interceptor returns a state object.
/// The type of the parameter must be the same as the type of the state object.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter)]
public sealed class InterceptedStateAttribute : Attribute
{
}
