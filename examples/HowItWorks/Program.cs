using MarcusMedina.Fluent.Maths.Algebra.Builders;
using MarcusMedina.Fluent.Maths.Algebra.Extensions;
using MarcusMedina.Fluent.Maths.Algebra.Expressions;
using MarcusMedina.Fluent.Maths.Algebra.Evaluators;

Console.OutputEncoding = System.Text.Encoding.UTF8; // Enable emoji support

Console.WriteLine("🎓 How Fluent.Algebra Works - Under The Hood\n");
Console.WriteLine("═══════════════════════════════════════════════════════════\n");

// ══════════════════════════════════════════════════════════════
// THE MAGIC: Expression Trees
// ══════════════════════════════════════════════════════════════

Console.WriteLine("📚 CONCEPT: Expression Trees\n");
Console.WriteLine("When you write: var expr = Algebra.X.Add(5);");
Console.WriteLine("You're NOT calculating x+5 immediately!");
Console.WriteLine("You're building a TREE structure:\n");

Console.WriteLine("      BinaryExpression");
Console.WriteLine("           (+)");
Console.WriteLine("          /   \\");
Console.WriteLine("    Variable  Constant");
Console.WriteLine("       (x)      (5)");
Console.WriteLine();

// Let's prove it!
var step1 = Algebra.X;                    // VariableExpression("x")
var step2 = step1.Add(5);                 // BinaryExpression(x, Add, 5)

Console.WriteLine($"Step 1 type: {step1.GetType().Name}");
Console.WriteLine($"Step 2 type: {step2.GetType().Name}");
Console.WriteLine();

Console.WriteLine("═══════════════════════════════════════════════════════════\n");

// ══════════════════════════════════════════════════════════════
// IMMUTABILITY: Each operation returns NEW expression
// ══════════════════════════════════════════════════════════════

Console.WriteLine("📚 CONCEPT: Immutability\n");
Console.WriteLine("Original expressions are NEVER modified:");

var x = Algebra.X;
var expr1 = x.Add(5);     // x + 5
var expr2 = x.Multiply(2); // 2x

Console.WriteLine($"x stays as: {x}");
Console.WriteLine($"expr1: {expr1}");
Console.WriteLine($"expr2: {expr2}");
Console.WriteLine("\nAll three are DIFFERENT objects!");
Console.WriteLine();

Console.WriteLine("═══════════════════════════════════════════════════════════\n");

// ══════════════════════════════════════════════════════════════
// CHAINING: How .Add().Multiply() works
// ══════════════════════════════════════════════════════════════

Console.WriteLine("📚 CONCEPT: Method Chaining\n");
Console.WriteLine("Let's build (x + 2)²:\n");

var chainStep1 = Algebra.X;                // Step 1: x
Console.WriteLine($"Step 1: {chainStep1}");
Console.WriteLine($"        Type: {chainStep1.GetType().Name}\n");

var chainStep2 = chainStep1.Add(2);       // Step 2: x + 2
Console.WriteLine($"Step 2: {chainStep2}");
Console.WriteLine($"        Type: {chainStep2.GetType().Name}");
Console.WriteLine($"        Tree: BinaryExpression(x, Add, 2)\n");

var chainStep3 = chainStep2.Square();     // Step 3: (x+2)²
Console.WriteLine($"Step 3: {chainStep3}");
Console.WriteLine($"        Type: {chainStep3.GetType().Name}");
Console.WriteLine($"        Tree: BinaryExpression((x+2), Power, 2)\n");

Console.WriteLine("═══════════════════════════════════════════════════════════\n");

// ══════════════════════════════════════════════════════════════
// LAZY EVALUATION: Nothing happens until .Evaluate()
// ══════════════════════════════════════════════════════════════

Console.WriteLine("📚 CONCEPT: Lazy Evaluation\n");
Console.WriteLine("Building the expression is FAST - no math yet!");

var lazyExpr = Algebra.X.Add(2).Multiply(3).Divide(4).Power(2);
Console.WriteLine($"Built expression: {lazyExpr}");
Console.WriteLine("No calculations performed yet!\n");

Console.WriteLine("Now let's evaluate with x=5:");
var result = lazyExpr.Evaluate("x", 5);
Console.WriteLine($"Result: {result}");
Console.WriteLine("\nCalculation: ((5+2)*3/4)² = (7*3/4)² = (5.25)² = 27.5625\n");

Console.WriteLine("═══════════════════════════════════════════════════════════\n");

// ══════════════════════════════════════════════════════════════
// TREE TRAVERSAL: How .Evaluate() walks the tree
// ══════════════════════════════════════════════════════════════

Console.WriteLine("📚 CONCEPT: Tree Traversal (Evaluation)\n");
Console.WriteLine("Expression: (x + 2)² with x=5\n");

var treeExpr = Algebra.X.Add(2).Square();

Console.WriteLine("Tree structure:");
Console.WriteLine("        Power(^)");
Console.WriteLine("         /    \\");
Console.WriteLine("      Add(+)   2");
Console.WriteLine("      /   \\");
Console.WriteLine("     x     2");
Console.WriteLine();

Console.WriteLine("Evaluation steps:");
Console.WriteLine("1. Start at root: Power node");
Console.WriteLine("2. Evaluate left child (Add node):");
Console.WriteLine("   a. Evaluate x → 5");
Console.WriteLine("   b. Evaluate 2 → 2");
Console.WriteLine("   c. Calculate: 5 + 2 = 7");
Console.WriteLine("3. Evaluate right child: 2 → 2");
Console.WriteLine("4. Calculate: 7² = 49");
Console.WriteLine();
Console.WriteLine($"Final result: {treeExpr.Evaluate("x", 5)}");
Console.WriteLine();

Console.WriteLine("═══════════════════════════════════════════════════════════\n");

// ══════════════════════════════════════════════════════════════
// SUBSTITUTION: Replacing nodes in the tree
// ══════════════════════════════════════════════════════════════

Console.WriteLine("📚 CONCEPT: Substitution (Tree Transformation)\n");

var original = Algebra.X.Square().Add(Algebra.X.Multiply(2));
Console.WriteLine($"Original expression: {original}");
Console.WriteLine("Tree before substitution:");
Console.WriteLine("        Add(+)");
Console.WriteLine("       /      \\");
Console.WriteLine("   Power(^)   Mult(*)");
Console.WriteLine("    /   \\      /   \\");
Console.WriteLine("   x     2    x     2");
Console.WriteLine();

var substituted = original.Substitute("x", 3);
Console.WriteLine($"After x=3: {substituted}");
Console.WriteLine("Tree after substitution:");
Console.WriteLine("        Add(+)");
Console.WriteLine("       /      \\");
Console.WriteLine("   Power(^)   Mult(*)");
Console.WriteLine("    /   \\      /   \\");
Console.WriteLine("   3     2    3     2");
Console.WriteLine();
Console.WriteLine($"Evaluation: {substituted.Evaluate()}");
Console.WriteLine("              3² + 3*2 = 9 + 6 = 15");
Console.WriteLine();

Console.WriteLine("═══════════════════════════════════════════════════════════\n");

// ══════════════════════════════════════════════════════════════
// SIMPLIFICATION: Tree optimization
// ══════════════════════════════════════════════════════════════

Console.WriteLine("📚 CONCEPT: Simplification (Tree Optimization)\n");

var messy = Algebra.X.Multiply(1).Add(0).Multiply(2);
Console.WriteLine($"Original: {messy}");
Console.WriteLine("Original tree:");
Console.WriteLine("        Mult(*)");
Console.WriteLine("         /    \\");
Console.WriteLine("      Add(+)   2");
Console.WriteLine("      /   \\");
Console.WriteLine("  Mult(*)  0");
Console.WriteLine("   /   \\");
Console.WriteLine("  x     1");
Console.WriteLine();

var clean = messy.Simplify();
Console.WriteLine($"Simplified: {clean}");
Console.WriteLine("Simplified tree:");
Console.WriteLine("    Mult(*)");
Console.WriteLine("     /   \\");
Console.WriteLine("    x     2");
Console.WriteLine();
Console.WriteLine("Rules applied:");
Console.WriteLine("1. x * 1 = x     (identity)");
Console.WriteLine("2. x + 0 = x     (identity)");
Console.WriteLine("3. Final: 2x");
Console.WriteLine();

Console.WriteLine("═══════════════════════════════════════════════════════════\n");

// ══════════════════════════════════════════════════════════════
// FORMATTERS: Different tree representations
// ══════════════════════════════════════════════════════════════

Console.WriteLine("📚 CONCEPT: Multiple Representations\n");
Console.WriteLine("Same tree, different formats:\n");

var formatExpr = Algebra.X.Add(2).Power(2).Divide(3);
Console.WriteLine("Tree structure:");
Console.WriteLine("        Div(/)");
Console.WriteLine("         /    \\");
Console.WriteLine("    Power(^)   3");
Console.WriteLine("     /    \\");
Console.WriteLine("  Add(+)   2");
Console.WriteLine("   /   \\");
Console.WriteLine("  x     2");
Console.WriteLine();

Console.WriteLine($"ToString():  {formatExpr}");
Console.WriteLine($"ToLaTeX():   {formatExpr.ToLaTeX()}");
Console.WriteLine($"Evaluate(5): {formatExpr.Evaluate("x", 5)}");
Console.WriteLine();

Console.WriteLine("═══════════════════════════════════════════════════════════\n");

// ══════════════════════════════════════════════════════════════
// THE BIG PICTURE
// ══════════════════════════════════════════════════════════════

Console.WriteLine("🎯 THE BIG PICTURE\n");
Console.WriteLine("1. BUILDING: Create expression tree (fast, no math)");
Console.WriteLine("2. TRANSFORMING: Substitute, simplify (tree operations)");
Console.WriteLine("3. REPRESENTING: ToString, LaTeX (tree traversal)");
Console.WriteLine("4. EVALUATING: Calculate result (tree traversal)");
Console.WriteLine();

Console.WriteLine("Why this is powerful:");
Console.WriteLine("✅ Separation of concerns (build vs calculate)");
Console.WriteLine("✅ Can manipulate expressions symbolically");
Console.WriteLine("✅ Can optimize before evaluation");
Console.WriteLine("✅ Can generate multiple representations");
Console.WriteLine("✅ Same code works for any expression complexity");
Console.WriteLine();

Console.WriteLine("═══════════════════════════════════════════════════════════\n");

Console.WriteLine("🧠 Core Design Patterns Used:");
Console.WriteLine("• Composite Pattern (expression tree)");
Console.WriteLine("• Builder Pattern (fluent API)");
Console.WriteLine("• Visitor Pattern (evaluation/formatting)");
Console.WriteLine("• Immutable Objects (functional style)");
Console.WriteLine();

Console.WriteLine("✨ That's the magic! It's all about TREES! 🌳");
