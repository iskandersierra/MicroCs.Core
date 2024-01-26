namespace MicroCs.Generators.Aop;

/// <summary>
/// Marks a method in an interceptor class to be called after the intercepted method.
/// The method is called only if the intercepted method throws an exception.
/// It is called after the intercepted method throws an exception.
/// If the marked method returns a value, it is used as the return value of the intercepted method.
/// </summary>
[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
public sealed class InterceptAfterFailureAttribute : Attribute
{
}
