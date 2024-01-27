namespace MicroCs.Generators.Aop;

/// <summary>
/// Marks a method in an interceptor class to be called after the intercepted method.
/// The method is called even if the intercepted method throws an exception.
/// It is called in a finally block.
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public sealed class InterceptAfterAttribute : Attribute
{
}
