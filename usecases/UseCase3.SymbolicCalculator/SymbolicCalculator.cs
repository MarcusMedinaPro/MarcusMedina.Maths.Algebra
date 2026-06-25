using MarcusMedina.Fluent.Algebra;

/// <summary>
/// A symbolic calculator that stores and manages algebraic expressions
/// </summary>
public class SymbolicCalculator
{
    private readonly Dictionary<string, IExpression> _expressions = [];

    /// <summary>
    /// Store an expression with a name
    /// </summary>
    public void Store(string name, IExpression expression)
    {
        _expressions[name] = expression;
    }

    /// <summary>
    /// Retrieve a stored expression
    /// </summary>
    public IExpression? Get(string name)
    {
        return _expressions.TryGetValue(name, out var expr) ? expr : null;
    }

    /// <summary>
    /// Evaluate a stored expression
    /// </summary>
    public double Evaluate(string name, double x)
    {
        var expr = Get(name);
        if (expr == null)
            throw new InvalidOperationException($"Expression '{name}' not found");

        return expr.Evaluate(x: x);
    }

    /// <summary>
    /// Get the LaTeX representation of a stored expression
    /// </summary>
    public string GetLaTeX(string name)
    {
        var expr = Get(name);
        if (expr == null)
            throw new InvalidOperationException($"Expression '{name}' not found");

        return expr.ToLatex();
    }

    /// <summary>
    /// Get all stored expression names
    /// </summary>
    public IEnumerable<string> GetNames() => _expressions.Keys;

    /// <summary>
    /// Print all stored expressions
    /// </summary>
    public void PrintAll()
    {
        Console.WriteLine("Stored Expressions:");
        foreach (var (name, expr) in _expressions)
        {
            Console.WriteLine($"  {name}: {expr.ToLatex()}");
        }
    }
}
