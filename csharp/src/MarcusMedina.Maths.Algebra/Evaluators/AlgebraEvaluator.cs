namespace MarcusMedina.Maths.Algebra.Evaluators;

using MarcusMedina.Maths.Algebra.Interfaces;

/// <summary>
/// Utility class for evaluating algebraic expressions
/// </summary>
public static class AlgebraEvaluator
{
    /// <summary>
    /// Evaluates an expression with the given variables
    /// </summary>
    public static double Evaluate(this IAlgebraExpression expression, Dictionary<string, double>? variables = null)
        => expression.Evaluate(variables);

    /// <summary>
    /// Evaluates an expression with a single variable
    /// </summary>
    public static double Evaluate(this IAlgebraExpression expression, string variable, double value)
        => expression.Evaluate(new Dictionary<string, double> { { variable, value } });

    /// <summary>
    /// Evaluates an expression at multiple points
    /// </summary>
    public static IEnumerable<double> EvaluateRange(
        this IAlgebraExpression expression,
        string variable,
        double start,
        double end,
        int steps)
    {
        var stepSize = (end - start) / (steps - 1);

        for (var i = 0; i < steps; i++)
        {
            var value = start + (i * stepSize);
            yield return expression.Evaluate(variable, value);
        }
    }
}
