namespace MicroCs.Generators.Aop;

[AttributeUsage(AttributeTargets.Parameter, Inherited = false, AllowMultiple = false)]
public sealed class InterceptedParameterAttribute : Attribute
{
    public InterceptedParameterAttribute(int position)
    {
        Position = position;
    }

    public InterceptedParameterAttribute(string name)
    {
        Name = name;
    }

    public InterceptedParameterAttribute(Type type)
    {
        Type = type;
    }

    public int? Position { get; }
    public string? Name { get; }
    public Type? Type { get; }
}
