using MicroCs.Generators.Aop;
using Microsoft.CodeAnalysis;

namespace MicroCs.Generators;

internal class TypeModel
{
    public string? Namespace { get; set; }
    public bool HasNamespace => !string.IsNullOrWhiteSpace(Namespace);
    public string FullName { get; set; } = default!;
    public string Name { get; set; } = default!;

    public bool IsVoid => string.Equals(FullName, "void", StringComparison.Ordinal);
    public ITypeSymbol Symbol { get; set; } = default!;
}

internal class TypeWithMembersModel : TypeModel
{
    public IReadOnlyList<MethodModel> Methods { get; set; } = default!;
}

internal abstract class MemberBaseModel
{
}

internal class MethodModel : MemberBaseModel
{
    public string Name { get; set; } = default!;
    public IReadOnlyList<MethodParameterModel> Parameters { get; set; } = default!;
    public TypeModel ReturnType { get; set; } = default!;
    public IMethodSymbol Symbol { get; set; } = default!;
    public bool ShouldGenerateMethodCache => true;
}

internal class MethodParameterModel
{
    public string Name { get; set; } = default!;
    public TypeModel Type { get; set; } = default!;
    public IParameterSymbol Symbol { get; set; } = default!;
}

internal class AsyncTypeInfo
{
    public bool IsAsync { get; set; }
    public TypeModel? InnerType { get; set; }
}
