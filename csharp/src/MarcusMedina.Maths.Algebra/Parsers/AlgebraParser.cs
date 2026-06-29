namespace MarcusMedina.Maths.Algebra.Parsers;

using MarcusMedina.Maths.Algebra.Expressions;
using MarcusMedina.Maths.Algebra.Extensions;
using MarcusMedina.Maths.Algebra.Interfaces;

/// <summary>
/// Parses algebraic expressions from string notation into expression trees.
/// Supports: +, -, *, /, ^ (power), parentheses, variables, constants, and math functions.
/// Example: "2*x^2 + 3*x + 1" or "sin(x) + cos(y)"
/// </summary>
public static class AlgebraParser
{
    private class Token
    {
        public enum TokenType { Number, Variable, Operator, LeftParen, RightParen, Function, End }
        public TokenType Type { get; set; }
        public string Value { get; set; } = "";
    }

    private class ParserImpl
    {
        private readonly List<Token> _tokens;
        private int _current = 0;

        public ParserImpl(List<Token> tokens) => _tokens = tokens;

        public IAlgebraExpression Parse()
        {
            var expr = ParseExpression();
            if (!IsAtEnd())
                throw new InvalidOperationException("Unexpected tokens after expression");
            return expr;
        }

        private IAlgebraExpression ParseExpression() => ParseAdditive();

        private IAlgebraExpression ParseAdditive()
        {
            var expr = ParseMultiplicative();
            while (MatchOperator("+", "-"))
            {
                var op = Previous().Value;
                var right = ParseMultiplicative();
                expr = op == "+" ? expr.Add(right) : expr.Subtract(right);
            }
            return expr;
        }

        private IAlgebraExpression ParseMultiplicative()
        {
            var expr = ParsePower();
            while (MatchOperator("*", "/"))
            {
                var op = Previous().Value;
                var right = ParsePower();
                expr = op == "*" ? expr.Multiply(right) : expr.Divide(right);
            }
            return expr;
        }

        private IAlgebraExpression ParsePower()
        {
            var expr = ParseUnary();
            if (MatchOperator("^"))
            {
                var right = ParsePower();
                expr = expr.Power(right);
            }
            return expr;
        }

        private IAlgebraExpression ParseUnary()
        {
            if (MatchOperator("-"))
            {
                var expr = ParseUnary();
                return new ConstantExpression(-1).Multiply(expr);
            }
            if (MatchOperator("+"))
                return ParseUnary();
            return ParsePrimary();
        }

        private IAlgebraExpression ParsePrimary()
        {
            // Number
            if (CheckType(Token.TokenType.Number))
            {
                var value = double.Parse(Advance().Value);
                return new ConstantExpression(value);
            }

            // Variable
            if (CheckType(Token.TokenType.Variable))
            {
                var name = Advance().Value;
                return GetVariableExpression(name);
            }

            // Function
            if (CheckType(Token.TokenType.Function))
            {
                var funcName = Advance().Value;
                ConsumeType(Token.TokenType.LeftParen, $"Expected '(' after {funcName}");
                var arg = ParseExpression();
                ConsumeType(Token.TokenType.RightParen, "Expected ')' after function argument");
                return new FunctionExpression(funcName, arg);
            }

            // Parentheses
            if (MatchOperator("("))
            {
                var expr = ParseExpression();
                ConsumeType(Token.TokenType.RightParen, "Expected ')' after expression");
                return expr;
            }

            throw new InvalidOperationException($"Unexpected token: {Peek().Value}");
        }

        private static IAlgebraExpression GetVariableExpression(string name) =>
            name.ToLower() switch
            {
                "x" => new VariableExpression("x"),
                "y" => new VariableExpression("y"),
                "z" => new VariableExpression("z"),
                _ => new VariableExpression(name)
            };

        private bool MatchOperator(params string[] ops)
        {
            foreach (var op in ops)
            {
                if (CheckValue(op))
                {
                    Advance();
                    return true;
                }
            }
            return false;
        }

        private bool CheckValue(string value) => !IsAtEnd() && Peek().Value == value;
        private bool CheckType(Token.TokenType type) => !IsAtEnd() && Peek().Type == type;
        private Token Advance() { if (!IsAtEnd()) _current++; return Previous(); }
        private bool IsAtEnd() => Peek().Type == Token.TokenType.End;
        private Token Peek() => _current < _tokens.Count ? _tokens[_current] : new Token { Type = Token.TokenType.End };
        private Token Previous() => _tokens[_current - 1];

        private void ConsumeType(Token.TokenType type, string msg)
        {
            if (CheckType(type)) { Advance(); return; }
            throw new InvalidOperationException(msg);
        }
    }

    /// <summary>
    /// Parses an algebraic expression string into an expression tree.
    /// </summary>
    /// <param name="expression">The expression string to parse, e.g. "2*x^2 + 3*x + 1".</param>
    /// <returns>An <see cref="IAlgebraExpression"/> representing the parsed expression tree.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="expression"/> is null or whitespace.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the expression cannot be parsed.</exception>
    public static IAlgebraExpression Parse(string expression)
    {
        if (string.IsNullOrWhiteSpace(expression))
            throw new ArgumentException("Expression cannot be empty");
        var tokens = Tokenize(expression);
        return new ParserImpl(tokens).Parse();
    }

    private static List<Token> Tokenize(string input)
    {
        var tokens = new List<Token>();
        input = input.Replace(" ", "");
        var funcs = new[] { "ceiling", "floor", "log10", "asin", "acos", "atan", "sqrt", "sin", "cos", "tan", "exp", "log", "ln", "abs" };
        var i = 0;

        while (i < input.Length)
        {
            var matched = false;
            foreach (var f in funcs)
            {
                if (input.Substring(i).StartsWith(f, StringComparison.OrdinalIgnoreCase))
                {
                    tokens.Add(new Token { Type = Token.TokenType.Function, Value = f.ToLower() });
                    i += f.Length;
                    matched = true;
                    break;
                }
            }
            if (matched) continue;

            var ch = input[i];
            if (char.IsDigit(ch) || (ch == '.' && i + 1 < input.Length && char.IsDigit(input[i + 1])))
            {
                var start = i;
                while (i < input.Length && (char.IsDigit(input[i]) || input[i] == '.'))
                    i++;
                tokens.Add(new Token { Type = Token.TokenType.Number, Value = input.Substring(start, i - start) });
            }
            else if (char.IsLetter(ch))
            {
                var start = i;
                while (i < input.Length && char.IsLetterOrDigit(input[i]))
                    i++;
                tokens.Add(new Token { Type = Token.TokenType.Variable, Value = input.Substring(start, i - start) });
            }
            else if (ch == '(')
            {
                tokens.Add(new Token { Type = Token.TokenType.LeftParen, Value = "(" });
                i++;
            }
            else if (ch == ')')
            {
                tokens.Add(new Token { Type = Token.TokenType.RightParen, Value = ")" });
                i++;
            }
            else if ("+-*/^".Contains(ch))
            {
                tokens.Add(new Token { Type = Token.TokenType.Operator, Value = ch.ToString() });
                i++;
            }
            else
            {
                throw new InvalidOperationException($"Unexpected character: {ch}");
            }
        }
        tokens.Add(new Token { Type = Token.TokenType.End });
        return tokens;
    }
}
