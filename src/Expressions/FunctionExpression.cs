namespace MarcusMedina.Fluent.Algebra.Expressions;

using MarcusMedina.Fluent.Algebra.Interfaces;

/// <summary>
/// Represents a function call (e.g., sin, cos, sqrt)
/// </summary>
public sealed class FunctionExpression : IAlgebraExpression
{
    public string FunctionName { get; }
    public IAlgebraExpression Argument { get; }

    public FunctionExpression(string functionName, IAlgebraExpression argument)
    {
        FunctionName = functionName;
        Argument = argument;
    }

    public double Evaluate(Dictionary<string, double>? variables = null)
    {
        var argValue = Argument.Evaluate(variables);

        return FunctionName.ToLower() switch
        {
            "sin" => Math.Sin(argValue),
            "cos" => Math.Cos(argValue),
            "tan" => Math.Tan(argValue),
            "sqrt" => Math.Sqrt(argValue),
            "ln" => Math.Log(argValue),
            "log" => Math.Log10(argValue),
            "exp" => Math.Exp(argValue),
            _ => throw new NotImplementedException($"Function {FunctionName} not implemented")
        };
    }

    public override string ToString() => $"{FunctionName}({Argument})";

    public string ToLaTeX()
    {
        return FunctionName.ToLower() switch
        {
            "sqrt" => $@"\sqrt{{{Argument.ToLaTeX()}}}",
            _ => $@"\{FunctionName}({Argument.ToLaTeX()})"
        };
    }

    public IAlgebraExpression Substitute(string variable, double value)
    {
        return new FunctionExpression(FunctionName, Argument.Substitute(variable, value));
    }

    public IAlgebraExpression Substitute(string variable, IAlgebraExpression expression)
    {
        return new FunctionExpression(FunctionName, Argument.Substitute(variable, expression));
    }

    public IAlgebraExpression Simplify()
    {
        var arg = Argument.Simplify();

        if (arg is ConstantExpression constant)
        {
            return new ConstantExpression(new FunctionExpression(FunctionName, constant).Evaluate());
        }

        return new FunctionExpression(FunctionName, arg);
    }
}
