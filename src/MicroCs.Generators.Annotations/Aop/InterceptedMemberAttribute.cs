namespace MicroCs.Generators.Aop;

/// <summary>
/// Marks a parameter to receive the intercepted member.
/// The parameter type must be either <see cref="System.Reflection.MemberInfo"/> or <see cref="string"/>.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter, Inherited = false, AllowMultiple = false)]
public sealed class InterceptedMemberAttribute : Attribute
{
}