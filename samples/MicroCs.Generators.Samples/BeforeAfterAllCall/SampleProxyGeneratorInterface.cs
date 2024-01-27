using System;
using System.Threading;
using System.Threading.Tasks;
using MicroCs.Generators.Lib.Samples.BeforeAfterAllCall;

namespace MicroCs.Generators.Samples.BeforeAfterAllCall;

public class SampleProxyGeneratorInterface :
    IProxyGeneratorInterface
{
    public void MyMethod()
    {
        Console.WriteLine("Executed MyMethod_0");
    }

    public string MyMethod(string input1, int input2 = 42)
    {
        Console.WriteLine("Executed MyMethod_1: {0}, {1}", input1, input2);
        return $"{input1}: {input2}";
    }

    public (string, DateTime) MyMethod(string input1, DateTime input2)
    {
        Console.WriteLine("Executed MyMethod_1: {0}, {1}", input1, input2);
        return (input1, input2);
    }

    public async Task MyMethod(int input1, CancellationToken cancel)
    {
        Console.WriteLine("Executed MyMethod_2: {0}", input1);
        await Task.CompletedTask;
    }

    public async Task<string> MyMethod(int input1, string? input2 = "default", CancellationToken cancel = default)
    {
        Console.WriteLine("Executed MyMethod_3: {0}, {1}", input1, input2);
        await Task.CompletedTask;
        return $"{input1}: {input2}";
    }
}
