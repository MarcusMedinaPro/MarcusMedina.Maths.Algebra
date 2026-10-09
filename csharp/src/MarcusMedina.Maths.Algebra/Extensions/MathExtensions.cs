namespace MarcusMedina.Maths.Algebra.Extensions;

using MarcusMedina.Maths.Algebra.Expressions;
using MarcusMedina.Maths.Algebra.Interfaces;

/// <summary>
/// Mathematical function extensions for algebraic expressions
/// Uses .NET Math class for all trigonometric and logarithmic functions
/// </summary>
public static class MathExtensions
{
    extension(IAlgebraExpression expression)
    {
        /// <summary>
        /// Returns the square root of an expression
        /// </summary>
        public IAlgebraExpression Sqrt()
            => new FunctionExpression("sqrt", expression);
        /// <summary>
        /// Returns the absolute value of an expression
        /// </summary>
        public IAlgebraExpression AbsoluteValue()
            => new FunctionExpression("abs", expression);
        /// <summary>
        /// Returns the sine of an expression (argument in radians)
        /// </summary>
        public IAlgebraExpression Sin()
            => new FunctionExpression("sin", expression);
        /// <summary>
        /// Returns the cosine of an expression (argument in radians)
        /// </summary>
        public IAlgebraExpression Cos()
            => new FunctionExpression("cos", expression);
        /// <summary>
        /// Returns the tangent of an expression (argument in radians)
        /// </summary>
        public IAlgebraExpression Tan()
            => new FunctionExpression("tan", expression);
        /// <summary>
        /// Returns the natural logarithm (base e) of an expression
        /// </summary>
        public IAlgebraExpression Log()
            => new FunctionExpression("ln", expression);
        /// <summary>
        /// Returns the base-10 logarithm of an expression
        /// </summary>
        public IAlgebraExpression Log10()
            => new FunctionExpression("log10", expression);
        /// <summary>
        /// Returns e raised to the power of the expression
        /// </summary>
        public IAlgebraExpression Exp()
            => new FunctionExpression("exp", expression);
        /// <summary>
        /// Returns the floor (greatest integer less than or equal) of an expression
        /// </summary>
        public IAlgebraExpression Floor()
            => new FunctionExpression("floor", expression);
        /// <summary>
        /// Returns the ceiling (smallest integer greater than or equal) of an expression
        /// </summary>
        public IAlgebraExpression Ceiling()
            => new FunctionExpression("ceiling", expression);
        /// <summary>
        /// Returns the arcsine of an expression (result in radians)
        /// </summary>
        public IAlgebraExpression ArcSin()
            => new FunctionExpression("asin", expression);
        /// <summary>
        /// Returns the arccosine of an expression (result in radians)
        /// </summary>
        public IAlgebraExpression ArcCos()
            => new FunctionExpression("acos", expression);
        /// <summary>
        /// Returns the arctangent of an expression (result in radians)
        /// </summary>
        public IAlgebraExpression ArcTan()
            => new FunctionExpression("atan", expression);
    }
}
