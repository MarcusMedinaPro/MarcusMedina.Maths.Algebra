namespace MarcusMedina.Fluent.Maths.Algebra.Extensions;

using MarcusMedina.Fluent.Maths.Algebra.Expressions;
using MarcusMedina.Fluent.Maths.Algebra.Interfaces;

/// <summary>
/// Mathematical function extensions for algebraic expressions
/// Uses .NET Math class for all trigonometric and logarithmic functions
/// </summary>
public static class MathExtensions
{
    /// <summary>
    /// Returns the square root of an expression
    /// </summary>
    public static IAlgebraExpression Sqrt(this IAlgebraExpression expression)
        => new FunctionExpression("sqrt", expression);

    /// <summary>
    /// Returns the absolute value of an expression
    /// </summary>
    public static IAlgebraExpression AbsoluteValue(this IAlgebraExpression expression)
        => new FunctionExpression("abs", expression);

    /// <summary>
    /// Returns the sine of an expression (argument in radians)
    /// </summary>
    public static IAlgebraExpression Sin(this IAlgebraExpression expression)
        => new FunctionExpression("sin", expression);

    /// <summary>
    /// Returns the cosine of an expression (argument in radians)
    /// </summary>
    public static IAlgebraExpression Cos(this IAlgebraExpression expression)
        => new FunctionExpression("cos", expression);

    /// <summary>
    /// Returns the tangent of an expression (argument in radians)
    /// </summary>
    public static IAlgebraExpression Tan(this IAlgebraExpression expression)
        => new FunctionExpression("tan", expression);

    /// <summary>
    /// Returns the natural logarithm (base e) of an expression
    /// </summary>
    public static IAlgebraExpression Log(this IAlgebraExpression expression)
        => new FunctionExpression("ln", expression);

    /// <summary>
    /// Returns the base-10 logarithm of an expression
    /// </summary>
    public static IAlgebraExpression Log10(this IAlgebraExpression expression)
        => new FunctionExpression("log10", expression);

    /// <summary>
    /// Returns e raised to the power of the expression
    /// </summary>
    public static IAlgebraExpression Exp(this IAlgebraExpression expression)
        => new FunctionExpression("exp", expression);

    /// <summary>
    /// Returns the floor (greatest integer less than or equal) of an expression
    /// </summary>
    public static IAlgebraExpression Floor(this IAlgebraExpression expression)
        => new FunctionExpression("floor", expression);

    /// <summary>
    /// Returns the ceiling (smallest integer greater than or equal) of an expression
    /// </summary>
    public static IAlgebraExpression Ceiling(this IAlgebraExpression expression)
        => new FunctionExpression("ceiling", expression);

    /// <summary>
    /// Returns the arcsine of an expression (result in radians)
    /// </summary>
    public static IAlgebraExpression ArcSin(this IAlgebraExpression expression)
        => new FunctionExpression("asin", expression);

    /// <summary>
    /// Returns the arccosine of an expression (result in radians)
    /// </summary>
    public static IAlgebraExpression ArcCos(this IAlgebraExpression expression)
        => new FunctionExpression("acos", expression);

    /// <summary>
    /// Returns the arctangent of an expression (result in radians)
    /// </summary>
    public static IAlgebraExpression ArcTan(this IAlgebraExpression expression)
        => new FunctionExpression("atan", expression);
}
