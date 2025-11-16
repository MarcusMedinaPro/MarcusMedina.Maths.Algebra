namespace MarcusMedina.Fluent.Maths.Algebra.Expressions;

using MarcusMedina.Fluent.Maths.Algebra.Interfaces;

/// <summary>
/// Represents a mathematical function call (such as sin, cos, sqrt) in an algebraic expression.
/// This allows you to build and evaluate expressions like sin(x), sqrt(2), or log(y).
/// </summary>
public sealed class FunctionExpression(string functionName, IAlgebraExpression argument) : IAlgebraExpression
{
    /// <summary>
    /// Gets the name of the mathematical function (e.g., 'sin', 'cos', 'sqrt').
    /// </summary>
    public string FunctionName { get; } = functionName;

    /// <summary>
    /// Gets the argument (input) to the function. For example, in sin(x), the argument is x.
    /// </summary>
    public IAlgebraExpression Argument { get; } = argument;

    /// <summary>
    /// Evaluates the function expression by evaluating its argument and applying the function.
    /// </summary>
    /// <param name="variables">Variable substitutions for evaluation.</param>
    /// <returns>The numeric result of the function applied to the argument.</returns>
    public double Evaluate(Dictionary<string, double>? variables = null)
        => FunctionName.ToLower() switch
        {
            "sin" => Math.Sin(Argument.Evaluate(variables)),
            "cos" => Math.Cos(Argument.Evaluate(variables)),
            "tan" => Math.Tan(Argument.Evaluate(variables)),
            "sqrt" => Math.Sqrt(Argument.Evaluate(variables)),
            "ln" => Math.Log(Argument.Evaluate(variables)),
            "log" => Math.Log10(Argument.Evaluate(variables)),
            "exp" => Math.Exp(Argument.Evaluate(variables)),
            _ => throw new NotImplementedException($"Function {FunctionName} not implemented")
        };

    /// <summary>
    /// Returns a string representation of the function expression, such as 'sin(x)'.
    /// </summary>
    /// <returns>The function as a string.</returns>
    public override string ToString() => $"{FunctionName}({Argument})";

    /// <summary>
    /// Returns a LaTeX representation of the function expression for mathematical typesetting.
    /// </summary>
    /// <returns>The function as a LaTeX string.</returns>
    public string ToLaTeX()
        => FunctionName.ToLower() switch
        {
            "sqrt" => $@"\sqrt{{{Argument.ToLaTeX()}}}",
            _ => $@"\{FunctionName}({Argument.ToLaTeX()})"
        };

    /// <summary>
    /// Substitutes a variable with a value in the argument of the function.
    /// </summary>
    /// <param name="variable">The variable name to substitute.</param>
    /// <param name="value">The value to substitute.</param>
    /// <returns>A new function expression with the substitution applied.</returns>
    public IAlgebraExpression Substitute(string variable, double value)
        => new FunctionExpression(FunctionName, Argument.Substitute(variable, value));

    /// <summary>
    /// Substitutes a variable with another expression in the argument of the function.
    /// </summary>
    /// <param name="variable">The variable name to substitute.</param>
    /// <param name="expression">The expression to substitute.</param>
    /// <returns>A new function expression with the substitution applied.</returns>
    public IAlgebraExpression Substitute(string variable, IAlgebraExpression expression)
        => new FunctionExpression(FunctionName, Argument.Substitute(variable, expression));

    /// <summary>
    /// Simplifies the function expression by simplifying its argument and evaluating if possible.
    /// </summary>
    /// <returns>A simplified function expression or a constant if fully evaluable.</returns>
    public IAlgebraExpression Simplify()
    {
        var arg = Argument.Simplify();
        return arg is ConstantExpression constant
            ? new ConstantExpression(new FunctionExpression(FunctionName, constant).Evaluate())
            : new FunctionExpression(FunctionName, arg);
    }
}
