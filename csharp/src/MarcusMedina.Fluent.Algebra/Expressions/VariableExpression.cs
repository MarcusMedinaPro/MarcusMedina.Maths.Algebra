namespace MarcusMedina.Fluent.Algebra.Expressions;

using MarcusMedina.Fluent.Algebra.Interfaces;

/// <summary>
/// Represents a variable in an algebraic expression, such as x, y, or z.
/// Variables are placeholders for values that can be substituted or evaluated.
/// </summary>
public sealed class VariableExpression : IAlgebraExpression
{
    /// <summary>
    /// Gets the name of the variable (e.g., 'x', 'y', 'z').
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="VariableExpression"/> class with the specified variable name.
    /// </summary>
    /// <param name="name">The name of the variable.</param>
    /// <exception cref="ArgumentException">Thrown if the variable name is empty or whitespace.</exception>
    public VariableExpression(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Variable name cannot be empty", nameof(name));
        Name = name;
    }

    /// <summary>
    /// Evaluates the variable expression by looking up its value in the provided dictionary.
    /// </summary>
    /// <param name="variables">A dictionary of variable names and their values.</param>
    /// <returns>The value of the variable.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the variable is not defined in the dictionary.</exception>
    public double Evaluate(Dictionary<string, double>? variables = null)
        => variables is { } && variables.TryGetValue(Name, out var value)
            ? value
            : throw new InvalidOperationException($"Variable '{Name}' is not defined");

    /// <summary>
    /// Returns the variable name as a string.
    /// </summary>
    /// <returns>The variable name.</returns>
    public override string ToString() => Name;

    /// <summary>
    /// Returns the variable name as a LaTeX string.
    /// </summary>
    /// <returns>The variable name for LaTeX output.</returns>
    public string ToLaTeX() => Name;

    /// <summary>
    /// Substitutes the variable with a constant value if the name matches; otherwise returns itself.
    /// </summary>
    /// <param name="variable">The variable name to substitute.</param>
    /// <param name="value">The value to substitute.</param>
    /// <returns>A constant expression if the name matches, otherwise this variable expression.</returns>
    public IAlgebraExpression Substitute(string variable, double value)
        => Name == variable ? new ConstantExpression(value) : this;

    /// <summary>
    /// Substitutes the variable with another expression if the name matches; otherwise returns itself.
    /// </summary>
    /// <param name="variable">The variable name to substitute.</param>
    /// <param name="expression">The expression to substitute.</param>
    /// <returns>The substituted expression or this variable expression.</returns>
    public IAlgebraExpression Substitute(string variable, IAlgebraExpression expression)
        => Name == variable ? expression : this;

    /// <summary>
    /// Simplifies the variable expression. For variables, this returns itself.
    /// </summary>
    /// <returns>This variable expression.</returns>
    public IAlgebraExpression Simplify() => this;
}
