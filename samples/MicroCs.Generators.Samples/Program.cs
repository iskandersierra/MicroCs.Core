using System;
using System.Linq;
using MicroCs.Generators.Aop;
using MicroCs.Generators.Samples.BeforeAfterAllCall;
using MicroCs.Generators.Samples.BeforeCall;

//var attr = new InterceptBeforeAttribute();
//ListAllLoadedAssemblies();

//await BeforeCallSample.Run();
await BeforeAfterAllCallSample.Run();

void ListAllLoadedAssemblies()
{
    var assemblies = AppDomain.CurrentDomain.GetAssemblies();
    foreach (var assembly in assemblies.OrderBy(a => a.FullName))
    {
        Console.WriteLine(assembly.FullName);
    }
}
