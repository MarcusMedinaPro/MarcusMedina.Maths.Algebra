namespace MarcusMedina.Fluent.Maths.Algebra.Formatters;

using MarcusMedina.Fluent.Maths.Algebra.Interfaces;

/// <summary>
/// Formats expressions as standard mathematical notation
/// </summary>
public static class StringFormatter
{
    /// <summary>
    /// Converts expression to string representation
    /// </summary>
    public static string Format(IAlgebraExpression expression)
    {
        return expression.ToString();
    }
}
