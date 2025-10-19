namespace MarcusMedina.Fluent.Algebra.Expressions;

using MarcusMedina.Fluent.Algebra.Interfaces;

/// <summary>
/// Represents a binary operation (e.g., addition, multiplication)
/// </summary>
public sealed class BinaryExpression : IAlgebraExpression
{
    public IAlgebraExpression Left { get; }
    public IAlgebraExpression Right { get; }
    public BinaryOperator Operator { get; }

    public BinaryExpression(IAlgebraExpression left, BinaryOperator op, IAlgebraExpression right)
    {
        Left = left;
        Operator = op;
        Right = right;
    }

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

    public string ToLaTeX()
    {
        return Operator switch
        {
            BinaryOperator.Divide => $@"\frac{{{Left.ToLaTeX()}}}{{{Right.ToLaTeX()}}}",
            BinaryOperator.Power => $"{{{Left.ToLaTeX()}}}^{{{Right.ToLaTeX()}}}",
            _ => $"({Left.ToLaTeX()} {GetLatexOperator()} {Right.ToLaTeX()})"
        };
    }

    private string GetLatexOperator() => Operator switch
    {
        BinaryOperator.Add => "+",
        BinaryOperator.Subtract => "-",
        BinaryOperator.Multiply => @"\cdot",
        _ => "?"
    };

    public IAlgebraExpression Substitute(string variable, double value)
    {
        return new BinaryExpression(
            Left.Substitute(variable, value),
            Operator,
            Right.Substitute(variable, value)
        );
    }

    public IAlgebraExpression Substitute(string variable, IAlgebraExpression expression)
    {
        return new BinaryExpression(
            Left.Substitute(variable, expression),
            Operator,
            Right.Substitute(variable, expression)
        );
    }

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
            if (Operator == BinaryOperator.Add && rightC.Value == 0) return left;
            if (Operator == BinaryOperator.Multiply && rightC.Value == 1) return left;
            if (Operator == BinaryOperator.Multiply && rightC.Value == 0) return new ConstantExpression(0);
        }

        if (left is ConstantExpression leftC)
        {
            if (Operator == BinaryOperator.Add && leftC.Value == 0) return right;
            if (Operator == BinaryOperator.Multiply && leftC.Value == 1) return right;
            if (Operator == BinaryOperator.Multiply && leftC.Value == 0) return new ConstantExpression(0);
        }

        return new BinaryExpression(left, Operator, right);
    }
}

/// <summary>
/// Binary operators
/// </summary>
public enum BinaryOperator
{
    Add,
    Subtract,
    Multiply,
    Divide,
    Power
}
