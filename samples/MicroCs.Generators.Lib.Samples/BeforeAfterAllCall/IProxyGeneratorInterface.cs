using System;
using System.Threading;
using System.Threading.Tasks;

namespace MicroCs.Generators.Lib.Samples.BeforeCall;

public interface IProxyGeneratorInterface
{
    void MyMethod();
    public string MyMethod(string input1, int input2 = 42);
    public (string, DateTime) MyMethod(string input1, DateTime input2);
    public Task MyMethod(int input1, CancellationToken cancel);
    public Task<string> MyMethod(int input1, string? input2 = "default", CancellationToken cancel = default);
}
