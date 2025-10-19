namespace MarcusMedina.Fluent.Algebra.Expressions;

using MarcusMedina.Fluent.Algebra.Interfaces;

/// <summary>
/// Represents a constant numeric value
/// </summary>
public sealed class ConstantExpression : IAlgebraExpression
{
    public double Value { get; }

    public ConstantExpression(double value)
    {
        Value = value;
    }

    public double Evaluate(Dictionary<string, double>? variables = null) => Value;

    public override string ToString() => Value.ToString("G");

    public string ToLaTeX() => Value.ToString("G");

    public IAlgebraExpression Substitute(string variable, double value) => this;

    public IAlgebraExpression Substitute(string variable, IAlgebraExpression expression) => this;

    public IAlgebraExpression Simplify() => this;

    public static implicit operator ConstantExpression(double value) => new(value);
    public static implicit operator ConstantExpression(int value) => new(value);
}
