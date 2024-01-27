namespace MicroCs.Generators.Aop;

/// <summary>
/// Marks a parameter to receive an intercepted parameter.
/// The parameter type must be assignable from the type of the intercepted parameter.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter)]
public sealed class InterceptedParameterAttribute : Attribute
{
    /// <summary>
    /// Assign this property when the position of the parameter in the intercepted method
    /// is used to determine which parameter to receive.
    /// </summary>
    public int? Position { get; set; }

    /// <summary>
    /// Assign this property when the name of the parameter in the intercepted method
    /// is used to determine which parameter to receive.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Assign this property when the type of the parameter in the intercepted method
    /// is used to determine which parameter to receive.
    /// </summary>
    public string? TypeName { get; set; }

    /// <summary>
    /// Assign this property when the namespace of the type of the parameter in the intercepted method
    /// is used to determine which parameter to receive.
    /// </summary>
    public string? TypeNamespace { get; set; }

    /// <summary>
    /// Assign this property when the full name of the type of the parameter in the intercepted method
    /// is used to determine which parameter to receive.
    /// </summary>
    public string? TypeFullName { get; set; }

    /// <summary>
    /// Assign this property when the type of the parameter in the intercepted method
    /// is used to determine which parameter to receive.
    /// </summary>
    public Type? Type { get; set; }

    /// <summary>
    /// Assign this property when a predicate in the interceptor class is used to determine
    /// which parameter to receive.
    /// The predicate must be a public method receiving the parameter type and the
    /// parameter name and the parameter value. It should return a boolean value, indicating
    /// whether the parameter should be received.
    /// The predicate could have only partial parameters, but the types <see cref="Type"/>,
    /// <see cref="string"/> and <see cref="object"/> should be used to determine the role of
    /// each parameter.
    /// </summary>
    public string? Predicate { get; set; }
}
