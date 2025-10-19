namespace MarcusMedina.Fluent.Algebra.Expressions;

using MarcusMedina.Fluent.Algebra.Interfaces;

/// <summary>
/// Represents a unary operation (e.g., negation, absolute value)
/// </summary>
public sealed class UnaryExpression : IAlgebraExpression
{
    public IAlgebraExpression Operand { get; }
    public UnaryOperator Operator { get; }

    public UnaryExpression(UnaryOperator op, IAlgebraExpression operand)
    {
        Operator = op;
        Operand = operand;
    }

    public double Evaluate(Dictionary<string, double>? variables = null)
    {
        var value = Operand.Evaluate(variables);

        return Operator switch
        {
            UnaryOperator.Negate => -value,
            UnaryOperator.Abs => Math.Abs(value),
            _ => throw new NotImplementedException($"Operator {Operator} not implemented")
        };
    }

    public override string ToString()
    {
        return Operator switch
        {
            UnaryOperator.Negate => $"-{Operand}",
            UnaryOperator.Abs => $"|{Operand}|",
            _ => $"?({Operand})"
        };
    }

    public string ToLaTeX()
    {
        return Operator switch
        {
            UnaryOperator.Negate => $"-{Operand.ToLaTeX()}",
            UnaryOperator.Abs => $@"\left|{Operand.ToLaTeX()}\right|",
            _ => $"?({Operand.ToLaTeX()})"
        };
    }

    public IAlgebraExpression Substitute(string variable, double value)
    {
        return new UnaryExpression(Operator, Operand.Substitute(variable, value));
    }

    public IAlgebraExpression Substitute(string variable, IAlgebraExpression expression)
    {
        return new UnaryExpression(Operator, Operand.Substitute(variable, expression));
    }

    public IAlgebraExpression Simplify()
    {
        var operand = Operand.Simplify();

        if (operand is ConstantExpression constant)
        {
            return new ConstantExpression(new UnaryExpression(Operator, constant).Evaluate());
        }

        return new UnaryExpression(Operator, operand);
    }
}

/// <summary>
/// Unary operators
/// </summary>
public enum UnaryOperator
{
    Negate,
    Abs
}
