namespace MicroCs.Generators.Aop;

/// <summary>
/// Marks a method in an interceptor class to be called before the intercepted method.
/// If the method returns a value, it is used as an interception state, that can be used
/// later when any of the <code>After</code> methods are called.
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public sealed class InterceptBeforeAttribute : Attribute
{
    // TODO: Allow the before interception to prevent the call to the intercepted method.
    // TODO: Allow the interceptor methods to be async.
}
