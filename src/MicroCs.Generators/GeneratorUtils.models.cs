namespace MicroCs.Generators;

internal class NamedTypeModel
{
    public string? Namespace { get; set; }
    public bool HasNamespace => !string.IsNullOrWhiteSpace(Namespace);
    public string FullName { get; set; } = default!;
    public string Name { get; set; } = default!;
}

internal abstract class MemberContainerModel : NamedTypeModel
{
    public IReadOnlyList<MemberBaseModel> Members { get; set; } = default!;
    public IReadOnlyList<MethodModel> Methods => Members.OfType<MethodModel>().ToArray();
}

internal class InterfaceModel : MemberContainerModel
{
}

internal class ClassModel : MemberContainerModel
{
}

internal abstract class MemberBaseModel
{
}

internal class MethodModel : MemberBaseModel
{
    public string Name { get; set; } = default!;
    public IReadOnlyList<MethodParameterModel> Parameters { get; set; } = default!;
    public NamedTypeModel ReturnType { get; set; } = default!;
}

internal class MethodParameterModel
{
    public string Name { get; set; } = default!;
    public NamedTypeModel Type { get; set; } = default!;
}
