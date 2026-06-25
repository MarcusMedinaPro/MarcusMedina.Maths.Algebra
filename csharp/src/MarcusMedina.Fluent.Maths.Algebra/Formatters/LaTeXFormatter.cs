namespace MarcusMedina.Fluent.Maths.Algebra.Formatters;

using MarcusMedina.Fluent.Maths.Algebra.Interfaces;

/// <summary>
/// Formats expressions as LaTeX notation
/// </summary>
public static class LaTeXFormatter
{
    /// <summary>
    /// Converts expression to LaTeX representation
    /// </summary>
    public static string Format(IAlgebraExpression expression)
    {
        return expression.ToLaTeX();
    }
}
