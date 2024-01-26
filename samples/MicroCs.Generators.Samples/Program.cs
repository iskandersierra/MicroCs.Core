// See https://aka.ms/new-console-template for more information

using MicroCs.Generators.Aop;

var attr = new InterceptBeforeAttribute();
ListAllLoadedAssemblies();

void ListAllLoadedAssemblies()
{
    var assemblies = AppDomain.CurrentDomain.GetAssemblies();
    foreach (var assembly in assemblies.OrderBy(a => a.FullName))
    {
        Console.WriteLine(assembly.FullName);
    }
}