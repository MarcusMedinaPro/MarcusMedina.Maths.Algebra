namespace MarcusMedina.Fluent.Maths.Algebra.Extensions;

using MarcusMedina.Fluent.Maths.Algebra.Expressions;
using MarcusMedina.Fluent.Maths.Algebra.Interfaces;

/// <summary>
/// Extension methods for fluent algebraic operations
/// </summary>
public static class AlgebraExtensions
{
    /// <summary>
    /// Adds two expressions
    /// </summary>
    public static IAlgebraExpression Add(this IAlgebraExpression left, IAlgebraExpression right)
        => new BinaryExpression(left, BinaryOperator.Add, right);

    /// <summary>
    /// Adds a constant to an expression
    /// </summary>
    public static IAlgebraExpression Add(this IAlgebraExpression left, double right)
        => new BinaryExpression(left, BinaryOperator.Add, new ConstantExpression(right));

    /// <summary>
    /// Subtracts two expressions
    /// </summary>
    public static IAlgebraExpression Subtract(this IAlgebraExpression left, IAlgebraExpression right)
        => new BinaryExpression(left, BinaryOperator.Subtract, right);

    /// <summary>
    /// Subtracts a constant from an expression
    /// </summary>
    public static IAlgebraExpression Subtract(this IAlgebraExpression left, double right)
        => new BinaryExpression(left, BinaryOperator.Subtract, new ConstantExpression(right));

    /// <summary>
    /// Multiplies two expressions
    /// </summary>
    public static IAlgebraExpression Multiply(this IAlgebraExpression left, IAlgebraExpression right)
        => new BinaryExpression(left, BinaryOperator.Multiply, right);

    /// <summary>
    /// Multiplies an expression by a constant
    /// </summary>
    public static IAlgebraExpression Multiply(this IAlgebraExpression left, double right)
        => new BinaryExpression(left, BinaryOperator.Multiply, new ConstantExpression(right));

    /// <summary>
    /// Divides two expressions
    /// </summary>
    public static IAlgebraExpression Divide(this IAlgebraExpression left, IAlgebraExpression right)
        => new BinaryExpression(left, BinaryOperator.Divide, right);

    /// <summary>
    /// Divides an expression by a constant
    /// </summary>
    public static IAlgebraExpression Divide(this IAlgebraExpression left, double right)
        => new BinaryExpression(left, BinaryOperator.Divide, new ConstantExpression(right));

    /// <summary>
    /// Raises an expression to a power
    /// </summary>
    public static IAlgebraExpression Power(this IAlgebraExpression @base, IAlgebraExpression exponent)
        => new BinaryExpression(@base, BinaryOperator.Power, exponent);

    /// <summary>
    /// Raises an expression to a constant power
    /// </summary>
    public static IAlgebraExpression Power(this IAlgebraExpression @base, double exponent)
        => new BinaryExpression(@base, BinaryOperator.Power, new ConstantExpression(exponent));

    /// <summary>
    /// Squares an expression
    /// </summary>
    public static IAlgebraExpression Square(this IAlgebraExpression expression)
        => new BinaryExpression(expression, BinaryOperator.Power, new ConstantExpression(2));

    /// <summary>
    /// Negates an expression
    /// </summary>
    public static IAlgebraExpression Negate(this IAlgebraExpression expression)
        => new UnaryExpression(UnaryOperator.Negate, expression);
}
