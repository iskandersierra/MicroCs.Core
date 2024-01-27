using System;
using System.Threading;
using System.Threading.Tasks;
using MicroCs.Generators.Lib.Samples.BeforeCall;

namespace MicroCs.Generators.Samples.BeforeCall;

public static class BeforeCallSample
{
    public static async Task Run()
    {
        IProxyGeneratorInterface instance = new SampleProxyGeneratorInterface();
        var interceptors = new LoggingInterceptors();
        IProxyGeneratorInterface proxy = instance;
        // IProxyGeneratorInterface proxy = new LoggingProxyGeneratorClass(instance, interceptors);

        Console.WriteLine("Running MyMethod_0:");
        proxy.MyMethod();
        Console.WriteLine();

        Console.WriteLine("Running MyMethod_1:");
        var result_1 = proxy.MyMethod("input1", 42);
        Console.WriteLine("Result: {0}", result_1);
        Console.WriteLine();

        Console.WriteLine("Running MyMethod_2:");
        var result_2 = proxy.MyMethod("input1", DateTime.Now);
        Console.WriteLine("Result: {0}", result_2);
        Console.WriteLine();

        Console.WriteLine("Running MyMethod_3:");
        await proxy.MyMethod(42, CancellationToken.None);
        Console.WriteLine();

        Console.WriteLine("Running MyMethod_4:");
        var result_4 = await proxy.MyMethod(42, "input2", CancellationToken.None);
        Console.WriteLine("Result: {0}", result_4);
        Console.WriteLine();
    }
}