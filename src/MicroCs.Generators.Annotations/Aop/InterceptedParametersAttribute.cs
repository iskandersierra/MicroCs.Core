namespace MicroCs.Generators.Aop;

[AttributeUsage(AttributeTargets.Parameter, Inherited = false, AllowMultiple = false)]
public sealed class InterceptedParametersAttribute : Attribute
{
    public bool CouldChange { get; set; }
}