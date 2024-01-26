namespace MicroCs.Generators.Aop;

/// <summary>
/// Marks a parameter to receive the exception that was thrown by the intercepted method.
/// It is only valid for methods that have the <see cref="InterceptAfterFailureAttribute"/> attribute.
/// The type of the parameter must be assignable from <see cref="Exception"/>.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter, Inherited = false, AllowMultiple = false)]
public sealed class InterceptedExceptionAttribute : Attribute
{
}