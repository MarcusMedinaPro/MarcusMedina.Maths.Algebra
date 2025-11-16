namespace MarcusMedina.Fluent.Maths.Algebra.Expressions;

using MarcusMedina.Fluent.Maths.Algebra.Interfaces;

/// <summary>
/// Represents a binary operation (e.g., addition, multiplication) in an algebraic expression.
/// </summary>
public sealed class BinaryExpression : IAlgebraExpression
{
    /// <summary>
    /// Gets the left operand of the binary operation.
    /// </summary>
    public IAlgebraExpression Left { get; }

    /// <summary>
    /// Gets the right operand of the binary operation.
    /// </summary>
    public IAlgebraExpression Right { get; }

    /// <summary>
    /// Gets the binary operator (Add, Subtract, Multiply, Divide, Power).
    /// </summary>
    public BinaryOperator Operator { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="BinaryExpression"/> class.
    /// </summary>
    /// <param name="left">The left operand expression.</param>
    /// <param name="op">The binary operator to apply.</param>
    /// <param name="right">The right operand expression.</param>
    public BinaryExpression(IAlgebraExpression left, BinaryOperator op, IAlgebraExpression right)
        => (Left, Operator, Right) = (left, op, right);

    /// <inheritdoc/>
    public double Evaluate(Dictionary<string, double>? variables = null)
    {
        var leftVal = Left.Evaluate(variables);
        var rightVal = Right.Evaluate(variables);
        return Operator switch
        {
            BinaryOperator.Add => leftVal + rightVal,
            BinaryOperator.Subtract => leftVal - rightVal,
            BinaryOperator.Multiply => leftVal * rightVal,
            BinaryOperator.Divide => rightVal != 0 ? leftVal / rightVal : throw new DivideByZeroException(),
            BinaryOperator.Power => Math.Pow(leftVal, rightVal),
            _ => throw new NotImplementedException($"Operator {Operator} not implemented")
        };
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        var op = Operator switch
        {
            BinaryOperator.Add => "+",
            BinaryOperator.Subtract => "-",
            BinaryOperator.Multiply => "*",
            BinaryOperator.Divide => "/",
            BinaryOperator.Power => "^",
            _ => "?"
        };
        return $"({Left} {op} {Right})";
    }

    /// <inheritdoc/>
    public string ToLaTeX()
        => Operator switch
        {
            BinaryOperator.Divide => $@"\frac{{{Left.ToLaTeX()}}}{{{Right.ToLaTeX()}}}",
            BinaryOperator.Power => $"{{{Left.ToLaTeX()}}}^{{{Right.ToLaTeX()}}}",
            _ => $"({Left.ToLaTeX()} {GetLatexOperator()} {Right.ToLaTeX()})"
        };

    private string GetLatexOperator() => Operator switch
    {
        BinaryOperator.Add => "+",
        BinaryOperator.Subtract => "-",
        BinaryOperator.Multiply => @"\cdot",
        _ => "?",
    };

    /// <inheritdoc/>
    public IAlgebraExpression Substitute(string variable, double value)
        => new BinaryExpression(
            Left.Substitute(variable, value),
            Operator,
            Right.Substitute(variable, value)
        );

    /// <inheritdoc/>
    public IAlgebraExpression Substitute(string variable, IAlgebraExpression expression)
        => new BinaryExpression(
            Left.Substitute(variable, expression),
            Operator,
            Right.Substitute(variable, expression)
        );

    /// <inheritdoc/>
    public IAlgebraExpression Simplify()
    {
        var left = Left.Simplify();
        var right = Right.Simplify();

        // Constant folding
        if (left is ConstantExpression leftConst && right is ConstantExpression rightConst)
        {
            return new ConstantExpression(
                new BinaryExpression(leftConst, Operator, rightConst).Evaluate()
            );
        }

        // Identity rules
        if (right is ConstantExpression rightC)
        {
            if (Operator == BinaryOperator.Add && rightC.Value == 0)
            {
                return left;
            }

            if (Operator == BinaryOperator.Multiply && rightC.Value == 1)
            {
                return left;
            }

            if (Operator == BinaryOperator.Multiply && rightC.Value == 0)
            {
                return new ConstantExpression(0);
            }
        }

        if (left is ConstantExpression leftC)
        {
            if (Operator == BinaryOperator.Add && leftC.Value == 0)
            {
                return right;
            }

            if (Operator == BinaryOperator.Multiply && leftC.Value == 1)
            {
                return right;
            }

            if (Operator == BinaryOperator.Multiply && leftC.Value == 0)
            {
                return new ConstantExpression(0);
            }
        }

        return new BinaryExpression(left, Operator, right);
    }
}

/// <summary>
/// Binary operators for algebraic expressions.
/// </summary>
/// <summary>
/// Binary operators for algebraic expressions.
/// </summary>
public enum BinaryOperator
{
    /// <summary>Addition operator (+)</summary>
    /// <summary>Addition operator (+)</summary>
    Add,
    /// <summary>Subtraction operator (-)</summary>
    /// <summary>Subtraction operator (-)</summary>
    Subtract,
    /// <summary>Multiplication operator (*)</summary>
    /// <summary>Multiplication operator (*)</summary>
    Multiply,
    /// <summary>Division operator (/)</summary>
    /// <summary>Division operator (/)</summary>
    Divide,
    /// <summary>Exponentiation operator (^)</summary>
    /// <summary>Exponentiation operator (^)</summary>
    Power
}
