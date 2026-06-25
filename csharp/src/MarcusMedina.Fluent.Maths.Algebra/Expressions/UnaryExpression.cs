namespace MarcusMedina.Fluent.Maths.Algebra.Expressions;

using MarcusMedina.Fluent.Maths.Algebra.Interfaces;

/// <summary>
/// Represents a unary operation (such as negation or absolute value) in an algebraic expression.
/// </summary>
public sealed class UnaryExpression(UnaryOperator op, IAlgebraExpression operand) : IAlgebraExpression
{
    /// <summary>
    /// Gets the operand expression that the operator is applied to.
    /// </summary>
    public IAlgebraExpression Operand { get; } = operand;

    /// <summary>
    /// Gets the unary operator (Negate, Abs).
    /// </summary>
    public UnaryOperator Operator { get; } = op;

    /// <inheritdoc/>
    public double Evaluate(Dictionary<string, double>? variables = null)
        => Operator switch
        {
            UnaryOperator.Negate => -Operand.Evaluate(variables),
            UnaryOperator.Abs => Math.Abs(Operand.Evaluate(variables)),
            _ => throw new NotImplementedException($"Operator {Operator} not implemented")
        };

    /// <inheritdoc/>
    public override string ToString()
        => Operator switch
        {
            UnaryOperator.Negate => $"-{Operand}",
            UnaryOperator.Abs => $"|{Operand}|",
            _ => $"?({Operand})"
        };

    /// <inheritdoc/>
    public string ToLaTeX()
        => Operator switch
        {
            UnaryOperator.Negate => $"-{Operand.ToLaTeX()}",
            UnaryOperator.Abs => $@"\left|{Operand.ToLaTeX()}\right|",
            _ => $"?({Operand.ToLaTeX()})"
        };

    /// <inheritdoc/>
    public IAlgebraExpression Substitute(string variable, double value)
        => new UnaryExpression(Operator, Operand.Substitute(variable, value));

    /// <inheritdoc/>
    public IAlgebraExpression Substitute(string variable, IAlgebraExpression expression)
        => new UnaryExpression(Operator, Operand.Substitute(variable, expression));

    /// <inheritdoc/>
    public IAlgebraExpression Simplify()
    {
        var operand = Operand.Simplify();
        return operand is ConstantExpression constant
            ? new ConstantExpression(new UnaryExpression(Operator, constant).Evaluate())
            : new UnaryExpression(Operator, operand);
    }
}

/// <summary>
/// Specifies the type of unary operation to perform in a <see cref="UnaryExpression"/>.
/// </summary>
/// <summary>
/// Unary operators for algebraic expressions.
/// </summary>
/// <summary>
/// Unary operators for algebraic expressions.
/// </summary>
public enum UnaryOperator
{
    /// <summary>
    /// Negates the operand (changes its sign). For example, -x.
    /// </summary>
    /// <summary>Negation operator (-x)</summary>
    /// <summary>Negation operator (-x)</summary>
    Negate,
    /// <summary>
    /// Takes the absolute value of the operand. For example, |x|.
    /// </summary>
    /// <summary>Absolute value operator (|x|)</summary>
    /// <summary>Absolute value operator (|x|)</summary>
    Abs
}
