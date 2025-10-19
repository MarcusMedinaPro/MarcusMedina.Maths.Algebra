namespace MarcusMedina.Fluent.Algebra.Expressions;

using MarcusMedina.Fluent.Algebra.Interfaces;

/// <summary>
/// Represents a variable (e.g., x, y, z)
/// </summary>
public sealed class VariableExpression : IAlgebraExpression
{
    public string Name { get; }

    public VariableExpression(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Variable name cannot be empty", nameof(name));

        Name = name;
    }

    public double Evaluate(Dictionary<string, double>? variables = null)
    {
        if (variables == null || !variables.TryGetValue(Name, out var value))
            throw new InvalidOperationException($"Variable '{Name}' is not defined");

        return value;
    }

    public override string ToString() => Name;

    public string ToLaTeX() => Name;

    public IAlgebraExpression Substitute(string variable, double value)
    {
        return Name == variable ? new ConstantExpression(value) : this;
    }

    public IAlgebraExpression Substitute(string variable, IAlgebraExpression expression)
    {
        return Name == variable ? expression : this;
    }

    public IAlgebraExpression Simplify() => this;
}
