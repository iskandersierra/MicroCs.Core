namespace MicroCs.Generators.Aop;

/// <summary>
/// Marks a parameter to receive the list of parameters passed to the intercepted method.
/// The type of the parameter must be <code>object?[]</code>.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter)]
public sealed class InterceptedParametersAttribute : Attribute
{
    /// <summary>
    /// When this property is set to true, the list of parameters could be modified in the interceptor
    /// before the intercepted method is called. The modified values will be passed to the intercepted method.
    /// If the value of this property is false, the original values will be passed to the intercepted method,
    /// even if the list of parameters is modified in the interceptor.
    /// </summary>
    public bool AllowChanges { get; set; }
}
