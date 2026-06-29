namespace MarcusMedina.Maths.Algebra.Interfaces;

/// <summary>
/// Base interface for all algebraic expressions
/// </summary>
public interface IAlgebraExpression
{
    /// <summary>
    /// Evaluates the expression with given variable substitutions
    /// </summary>
    /// <param name="variables">Variable name-value pairs</param>
    /// <returns>Numeric result</returns>
    double Evaluate(Dictionary<string, double>? variables = null);

    /// <summary>
    /// Returns a string representation of the expression
    /// </summary>
    string ToString();

    /// <summary>
    /// Returns LaTeX representation of the expression
    /// </summary>
    string ToLaTeX();

    /// <summary>
    /// Creates a copy of this expression with a variable substituted
    /// </summary>
    IAlgebraExpression Substitute(string variable, double value);

    /// <summary>
    /// Creates a copy of this expression with a variable substituted by another expression
    /// </summary>
    IAlgebraExpression Substitute(string variable, IAlgebraExpression expression);

    /// <summary>
    /// Simplifies the expression
    /// </summary>
    IAlgebraExpression Simplify();
}
