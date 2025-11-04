namespace MarcusMedina.Fluent.Algebra.Expressions;

using MarcusMedina.Fluent.Algebra.Interfaces;

/// <summary>
/// Represents a constant numeric value in an algebraic expression.
/// Use this to represent numbers like 2, 3.14, or -7 in symbolic math.
/// </summary>
public sealed class ConstantExpression(double value) : IAlgebraExpression
{
    /// <summary>
    /// Gets the numeric value of the constant.
    /// </summary>
    public double Value { get; } = value;

    /// <summary>
    /// Evaluates the constant expression. Always returns the stored value, regardless of variables.
    /// </summary>
    /// <param name="variables">Variable substitutions (ignored for constants).</param>
    /// <returns>The numeric value of the constant.</returns>
    public double Evaluate(Dictionary<string, double>? variables = null) => Value;

    /// <summary>
    /// Returns a string representation of the constant, suitable for code or math output.
    /// </summary>
    /// <returns>The value as a string.</returns>
    public override string ToString() => Value.ToString("G");

    /// <summary>
    /// Returns a LaTeX representation of the constant for mathematical typesetting.
    /// </summary>
    /// <returns>The value as a LaTeX string.</returns>
    public string ToLaTeX() => Value.ToString("G");

    /// <summary>
    /// Substitutes a variable with a value. For constants, this returns itself (no effect).
    /// </summary>
    /// <param name="variable">The variable name to substitute (ignored).</param>
    /// <param name="value">The value to substitute (ignored).</param>
    /// <returns>This constant expression.</returns>
    public IAlgebraExpression Substitute(string variable, double value) => this;

    /// <summary>
    /// Substitutes a variable with another expression. For constants, this returns itself (no effect).
    /// </summary>
    /// <param name="variable">The variable name to substitute (ignored).</param>
    /// <param name="expression">The expression to substitute (ignored).</param>
    /// <returns>This constant expression.</returns>
    public IAlgebraExpression Substitute(string variable, IAlgebraExpression expression) => this;

    /// <summary>
    /// Simplifies the constant expression. For constants, this returns itself (already simplest form).
    /// </summary>
    /// <returns>This constant expression.</returns>
    public IAlgebraExpression Simplify() => this;

    /// <summary>
    /// Implicitly converts a double value to a <see cref="ConstantExpression"/>.
    /// This allows you to use numbers directly in algebraic expressions.
    /// </summary>
    /// <param name="value">The double value to convert.</param>
    public static implicit operator ConstantExpression(double value) => new(value);
    /// <summary>
    /// Implicitly converts an int value to a <see cref="ConstantExpression"/>.
    /// </summary>
    /// <param name="value">The int value to convert.</param>
    public static implicit operator ConstantExpression(int value) => new(value);
}
