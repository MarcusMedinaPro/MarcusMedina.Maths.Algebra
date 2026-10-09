namespace MarcusMedina.Maths.Algebra.Extensions;

using MarcusMedina.Maths.Algebra.Expressions;
using MarcusMedina.Maths.Algebra.Interfaces;

/// <summary>
/// Extension methods for fluent algebraic operations
/// </summary>
public static class AlgebraExtensions
{
    extension(IAlgebraExpression left)
    {
        /// <summary>
        /// Adds two expressions
        /// </summary>
        public IAlgebraExpression Add(IAlgebraExpression right)
            => new BinaryExpression(left, BinaryOperator.Add, right);
        /// <summary>
        /// Adds a constant to an expression
        /// </summary>
        public IAlgebraExpression Add(double right)
            => new BinaryExpression(left, BinaryOperator.Add, new ConstantExpression(right));
        /// <summary>
        /// Subtracts two expressions
        /// </summary>
        public IAlgebraExpression Subtract(IAlgebraExpression right)
            => new BinaryExpression(left, BinaryOperator.Subtract, right);
        /// <summary>
        /// Subtracts a constant from an expression
        /// </summary>
        public IAlgebraExpression Subtract(double right)
            => new BinaryExpression(left, BinaryOperator.Subtract, new ConstantExpression(right));
        /// <summary>
        /// Multiplies two expressions
        /// </summary>
        public IAlgebraExpression Multiply(IAlgebraExpression right)
            => new BinaryExpression(left, BinaryOperator.Multiply, right);
        /// <summary>
        /// Multiplies an expression by a constant
        /// </summary>
        public IAlgebraExpression Multiply(double right)
            => new BinaryExpression(left, BinaryOperator.Multiply, new ConstantExpression(right));
        /// <summary>
        /// Divides two expressions
        /// </summary>
        public IAlgebraExpression Divide(IAlgebraExpression right)
            => new BinaryExpression(left, BinaryOperator.Divide, right);
        /// <summary>
        /// Divides an expression by a constant
        /// </summary>
        public IAlgebraExpression Divide(double right)
            => new BinaryExpression(left, BinaryOperator.Divide, new ConstantExpression(right));
    }

    extension(IAlgebraExpression @base)
    {
        /// <summary>
        /// Raises an expression to a power
        /// </summary>
        public IAlgebraExpression Power(IAlgebraExpression exponent)
            => new BinaryExpression(@base, BinaryOperator.Power, exponent);
        /// <summary>
        /// Raises an expression to a constant power
        /// </summary>
        public IAlgebraExpression Power(double exponent)
            => new BinaryExpression(@base, BinaryOperator.Power, new ConstantExpression(exponent));
    }

    extension(IAlgebraExpression expression)
    {
        /// <summary>
        /// Squares an expression
        /// </summary>
        public IAlgebraExpression Square()
            => new BinaryExpression(expression, BinaryOperator.Power, new ConstantExpression(2));
        /// <summary>
        /// Negates an expression
        /// </summary>
        public IAlgebraExpression Negate()
            => new UnaryExpression(UnaryOperator.Negate, expression);
    }
}
