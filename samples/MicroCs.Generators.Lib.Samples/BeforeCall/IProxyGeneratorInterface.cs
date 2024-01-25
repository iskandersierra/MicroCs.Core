namespace MicroCs.Generators.Lib.Samples.BeforeCall;

public interface IProxyGeneratorInterface
{
    void MyMethod();
    public string MyMethod(string input1, int input2) => $"{input1}: {input2}";
    public (string, DateTime) MyMethod(string input1, DateTime input2);
}