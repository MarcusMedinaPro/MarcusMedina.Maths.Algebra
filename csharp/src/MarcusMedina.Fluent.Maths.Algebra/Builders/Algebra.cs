namespace MarcusMedina.Fluent.Maths.Algebra.Builders;

using MarcusMedina.Fluent.Maths.Algebra.Expressions;
using MarcusMedina.Fluent.Maths.Algebra.Interfaces;

/// <summary>
/// Fluent builder for algebraic expressions
/// </summary>
public static class Algebra
{
    /// <summary>
    /// Creates a constant expression
    /// </summary>
    public static IAlgebraExpression Constant(double value) => new ConstantExpression(value);

    /// <summary>
    /// Creates a variable expression
    /// </summary>
    public static IAlgebraExpression Variable(string name) => new VariableExpression(name);

    /// <summary>
    /// Creates a variable expression (shorthand)
    /// </summary>
    public static IAlgebraExpression Var(string name) => new VariableExpression(name);

    /// <summary>
    /// Common variable: x
    /// </summary>
    public static IAlgebraExpression X => new VariableExpression("x");

    /// <summary>
    /// Common variable: y
    /// </summary>
    public static IAlgebraExpression Y => new VariableExpression("y");

    /// <summary>
    /// Common variable: z
    /// </summary>
    public static IAlgebraExpression Z => new VariableExpression("z");

    /// <summary>
    /// Creates an addition expression
    /// </summary>
    public static IAlgebraExpression Add(IAlgebraExpression left, IAlgebraExpression right)
        => new BinaryExpression(left, BinaryOperator.Add, right);

    /// <summary>
    /// Creates a subtraction expression
    /// </summary>
    public static IAlgebraExpression Subtract(IAlgebraExpression left, IAlgebraExpression right)
        => new BinaryExpression(left, BinaryOperator.Subtract, right);

    /// <summary>
    /// Creates a multiplication expression
    /// </summary>
    public static IAlgebraExpression Multiply(IAlgebraExpression left, IAlgebraExpression right)
        => new BinaryExpression(left, BinaryOperator.Multiply, right);

    /// <summary>
    /// Creates a division expression
    /// </summary>
    public static IAlgebraExpression Divide(IAlgebraExpression left, IAlgebraExpression right)
        => new BinaryExpression(left, BinaryOperator.Divide, right);

    /// <summary>
    /// Creates a power expression
    /// </summary>
    public static IAlgebraExpression Power(IAlgebraExpression @base, IAlgebraExpression exponent)
        => new BinaryExpression(@base, BinaryOperator.Power, exponent);

    /// <summary>
    /// Creates a square root expression
    /// </summary>
    public static IAlgebraExpression Sqrt(IAlgebraExpression expression)
        => new FunctionExpression("sqrt", expression);

    /// <summary>
    /// Creates a sine expression
    /// </summary>
    public static IAlgebraExpression Sin(IAlgebraExpression expression)
        => new FunctionExpression("sin", expression);

    /// <summary>
    /// Creates a cosine expression
    /// </summary>
    public static IAlgebraExpression Cos(IAlgebraExpression expression)
        => new FunctionExpression("cos", expression);

    /// <summary>
    /// Creates a natural logarithm expression
    /// </summary>
    public static IAlgebraExpression Ln(IAlgebraExpression expression)
        => new FunctionExpression("ln", expression);

    /// <summary>
    /// Creates an absolute value expression
    /// </summary>
    public static IAlgebraExpression Abs(IAlgebraExpression expression)
        => new UnaryExpression(UnaryOperator.Abs, expression);

    /// <summary>
    /// Creates a negation expression
    /// </summary>
    public static IAlgebraExpression Negate(IAlgebraExpression expression)
        => new UnaryExpression(UnaryOperator.Negate, expression);
}
