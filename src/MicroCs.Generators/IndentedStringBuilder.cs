using System.Runtime.CompilerServices;
using System.Text;

namespace MicroCs.Generators;

internal class IndentedStringBuilder
{
    private readonly StringBuilder builder = new();
    private readonly string indentContent;
    private readonly List<string> indentContents;
    private int indentLevel;
    private bool atLineStart = true;

    public IndentedStringBuilder(string indentContent = "    ")
    {
        this.indentContent = indentContent ?? throw new ArgumentNullException(nameof(indentContent));
        indentContents = new List<string> {string.Empty};
    }

    private void WriteSingleLineContent(ReadOnlySpan<char> content)
    {
        if (content.Length == 0) return;

        WriteIndentString();
        // builder.EnsureCapacity(builder.Length + content.Length);

        // TODO: Optimize this using any type of marshaling of the builder as a span
        // Not available in netstandard2.0 😓
        builder.Append(content.ToArray());
    }

    private void WriteMultiLineContent(ReadOnlySpan<char> content)
    {
        if (content.Length == 0) return;

        var initPos = 0;
        for (int i = 0; i < content.Length; i++)
        {
            var ch = content[i];
            if (ch == '\r' || ch == '\n')
            {
                if (i > initPos)
                    WriteSingleLineContent(content.Slice(initPos, i - initPos));
                if (ch == '\r' && i + 1 < content.Length && content[i + 1] == '\n')
                    i++;
                initPos = i + 1;
                builder.AppendLine();
                atLineStart = true;
            }
        }

        if (content.Length > initPos)
            WriteSingleLineContent(content.Slice(initPos));
    }

    private void WriteIndentString()
    {
        if (atLineStart && indentLevel > 0 && indentContent.Length > 0)
        {
            var indent = EnsureIndentString();
            builder.Append(indent);
            atLineStart = false;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private string EnsureIndentString()
    {
        while (indentContents.Count <= indentLevel)
        {
            indentContents.Add(indentContents[indentContents.Count - 1] + indentContent);
        }
        return indentContents[indentLevel];
    }

    public IndentedStringBuilder Append(string value)
    {
        WriteMultiLineContent(value.AsSpan());
        return this;
    }

    public IndentedStringBuilder AppendLine()
    {
        builder.AppendLine();
        atLineStart = true;
        return this;
    }

    public IndentedStringBuilder AppendLine(string value)
    {
        WriteMultiLineContent(value.AsSpan());
        builder.AppendLine();
        atLineStart = true;
        return this;
    }

    public IndentedState Indent(int amount = 1)
    {
        if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount));
        return new IndentedState(this, amount);
    }

    public override string ToString()
    {
        return builder.ToString();
    }

    public struct IndentedState : IDisposable
    {
        private readonly IndentedStringBuilder builder;
        private readonly int indentLevel;
        private bool disposed;

        public IndentedState(IndentedStringBuilder builder, int amount)
        {
            this.indentLevel = builder.indentLevel;
            builder.indentLevel += amount;
            this.builder = builder;
        }

        public void Dispose()
        {
            if (disposed) return;
            builder.indentLevel = indentLevel;
            disposed = true;
        }
    }
}
