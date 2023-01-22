using System.Text;

namespace Belp.CodeAnalysis.ManifestResourceGenerators;

internal ref struct IndentedStringBuilder
{
    private readonly StringBuilder _builder;

    public int CurrentIndent { get; init; }

    public string LineEnding { get; init; } = "\r\n";

    public IndentedStringBuilder(StringBuilder builder, int currentIndent = 0)
    {
        _builder = builder;
        CurrentIndent = currentIndent;
    }

    /// <inheritdoc cref="StringBuilder.AppendLine()" />
    public IndentedStringBuilder AppendLine()
    {
        _ = _builder
            .Append(' ', CurrentIndent)
            .Append(LineEnding)
            ;

        return this;
    }

    /// <inheritdoc cref="StringBuilder.AppendLine(string)" />
    public IndentedStringBuilder AppendLine(string value)
    {
        _ = _builder
            .Append(' ', CurrentIndent)
            .AppendLine(value)
            .Append(LineEnding)
            ;

        return this;
    }

    /// <inheritdoc cref="StringBuilder.AppendLine(string)" />
    public IndentedStringBuilder AppendLine<T>(T value)
        where T : notnull
    {
        _ = _builder
            .Append(' ', CurrentIndent)
            .AppendLine(value.ToString())
            .Append(LineEnding)
            ;

        return this;
    }

    /// <inheritdoc cref="StringBuilder.ToString()" />
    public override string ToString()
    {
        return _builder.ToString();
    }
}
