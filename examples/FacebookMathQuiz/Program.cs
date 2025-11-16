using MarcusMedina.Fluent.Maths.Algebra.Builders;
using MarcusMedina.Fluent.Maths.Algebra.Extensions;

// UTF-8 Encoding for console
Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("════════════════════════════════════════════════════════════");
Console.WriteLine("   📱 Facebook Math Quiz - The Ones That Break The Internet");
Console.WriteLine("════════════════════════════════════════════════════════════");
Console.WriteLine();
Console.WriteLine("These are the classic Facebook math problems that cause");
Console.WriteLine("thousands of comments arguing about the \"correct\" answer.");
Console.WriteLine("Let's solve them with Fluent.Algebra and show WHY they work!");
Console.WriteLine();

// ══════════════════════════════════════════════════════════════
// Problem 1: The Zero Trap
// ══════════════════════════════════════════════════════════════
Console.WriteLine("┌─────────────────────────────────────────────────────────┐");
Console.WriteLine("│ Problem 1: 1 + 2 × 3 × 0                                │");
Console.WriteLine("└─────────────────────────────────────────────────────────┘");
Console.WriteLine("❌ Wrong answer (many people): 0 or 9");
Console.WriteLine("✅ Correct answer: 1");
Console.WriteLine();

var quiz1 = Algebra.Constant(1)
    .Add(Algebra.Constant(2).Multiply(3).Multiply(0));

Console.WriteLine($"Expression tree: {quiz1}");
Console.WriteLine($"LaTeX: {quiz1.ToLaTeX()}");
Console.WriteLine();
Console.WriteLine("Step-by-step (PEMDAS/BODMAS):");
Console.WriteLine("1. Multiplication first: 2 × 3 = 6");
Console.WriteLine("2. Continue multiplication: 6 × 0 = 0");
Console.WriteLine("3. Addition last: 1 + 0 = 1");
Console.WriteLine($"Result: {quiz1.Evaluate()}");
Console.WriteLine();

// ══════════════════════════════════════════════════════════════
// Problem 2: The Division Controversy
// ══════════════════════════════════════════════════════════════
Console.WriteLine("┌─────────────────────────────────────────────────────────┐");
Console.WriteLine("│ Problem 2: 6 ÷ 2(1+2)                                   │");
Console.WriteLine("└─────────────────────────────────────────────────────────┘");
Console.WriteLine("🔥 THE MOST CONTROVERSIAL ONE! 🔥");
Console.WriteLine("❌ Many say: 1 (treating 2(1+2) as implicit multiplication with higher precedence)");
Console.WriteLine("✅ Modern convention: 9 (left-to-right evaluation)");
Console.WriteLine();

// Modern interpretation: 6 ÷ 2 × (1+2)
var quiz2 = Algebra.Constant(6)
    .Divide(2)
    .Multiply(Algebra.Constant(1).Add(2));

Console.WriteLine($"Expression tree: {quiz2}");
Console.WriteLine($"LaTeX: {quiz2.ToLaTeX()}");
Console.WriteLine();
Console.WriteLine("Step-by-step (left-to-right for ×÷):");
Console.WriteLine("1. Parentheses first: (1+2) = 3");
Console.WriteLine("2. Division (left-to-right): 6 ÷ 2 = 3");
Console.WriteLine("3. Multiplication: 3 × 3 = 9");
Console.WriteLine($"Result: {quiz2.Evaluate()}");
Console.WriteLine();
Console.WriteLine("💡 Note: In modern mathematics, implied multiplication");
Console.WriteLine("   (2(3)) has the SAME precedence as explicit (2×3).");
Console.WriteLine("   Older conventions treated it differently!");
Console.WriteLine();

// ══════════════════════════════════════════════════════════════
// Problem 3: Mixed Operations
// ══════════════════════════════════════════════════════════════
Console.WriteLine("┌─────────────────────────────────────────────────────────┐");
Console.WriteLine("│ Problem 3: 8 + 8 ÷ 8 + 8 × 8 - 8                        │");
Console.WriteLine("└─────────────────────────────────────────────────────────┘");
Console.WriteLine("❌ Common wrong answer: 16 or 8");
Console.WriteLine("✅ Correct answer: 65");
Console.WriteLine();

var quiz3 = Algebra.Constant(8)
    .Add(Algebra.Constant(8).Divide(8))
    .Add(Algebra.Constant(8).Multiply(8))
    .Subtract(8);

Console.WriteLine($"Expression tree: {quiz3}");
Console.WriteLine($"LaTeX: {quiz3.ToLaTeX()}");
Console.WriteLine();
Console.WriteLine("Step-by-step (×÷ before +-):");
Console.WriteLine("1. Division: 8 ÷ 8 = 1");
Console.WriteLine("2. Multiplication: 8 × 8 = 64");
Console.WriteLine("3. Now: 8 + 1 + 64 - 8");
Console.WriteLine("4. Left-to-right: 8 + 1 = 9");
Console.WriteLine("5. Continue: 9 + 64 = 73");
Console.WriteLine("6. Final: 73 - 8 = 65");
Console.WriteLine($"Result: {quiz3.Evaluate()}");
Console.WriteLine();

// ══════════════════════════════════════════════════════════════
// Problem 4: The All-Zero Trap
// ══════════════════════════════════════════════════════════════
Console.WriteLine("┌─────────────────────────────────────────────────────────┐");
Console.WriteLine("│ Problem 4: 0 + 0 × 6 ÷ 2                                │");
Console.WriteLine("└─────────────────────────────────────────────────────────┘");
Console.WriteLine("❌ People overthink this one!");
Console.WriteLine("✅ Correct answer: 0");
Console.WriteLine();

var quiz4 = Algebra.Constant(0)
    .Add(Algebra.Constant(0).Multiply(6).Divide(2));

Console.WriteLine($"Expression tree: {quiz4}");
Console.WriteLine($"LaTeX: {quiz4.ToLaTeX()}");
Console.WriteLine();
Console.WriteLine("Step-by-step:");
Console.WriteLine("1. Multiplication: 0 × 6 = 0");
Console.WriteLine("2. Division: 0 ÷ 2 = 0");
Console.WriteLine("3. Addition: 0 + 0 = 0");
Console.WriteLine($"Result: {quiz4.Evaluate()}");
Console.WriteLine("💡 Anything times zero is zero. Simple!");
Console.WriteLine();

// ══════════════════════════════════════════════════════════════
// Problem 5: Negative Territory
// ══════════════════════════════════════════════════════════════
Console.WriteLine("┌─────────────────────────────────────────────────────────┐");
Console.WriteLine("│ Problem 5: 3 - 3 × 6 + 2                                │");
Console.WriteLine("└─────────────────────────────────────────────────────────┘");
Console.WriteLine("❌ Common wrong answer: 2 or 8");
Console.WriteLine("✅ Correct answer: -13");
Console.WriteLine();

var quiz5 = Algebra.Constant(3)
    .Subtract(Algebra.Constant(3).Multiply(6))
    .Add(2);

Console.WriteLine($"Expression tree: {quiz5}");
Console.WriteLine($"LaTeX: {quiz5.ToLaTeX()}");
Console.WriteLine();
Console.WriteLine("Step-by-step:");
Console.WriteLine("1. Multiplication: 3 × 6 = 18");
Console.WriteLine("2. Now: 3 - 18 + 2");
Console.WriteLine("3. Left-to-right: 3 - 18 = -15");
Console.WriteLine("4. Continue: -15 + 2 = -13");
Console.WriteLine($"Result: {quiz5.Evaluate()}");
Console.WriteLine();

// ══════════════════════════════════════════════════════════════
// Problem 6: Another Mixed Bag
// ══════════════════════════════════════════════════════════════
Console.WriteLine("┌─────────────────────────────────────────────────────────┐");
Console.WriteLine("│ Problem 6: 7 + 7 ÷ 7 + 7 × 7 - 7                        │");
Console.WriteLine("└─────────────────────────────────────────────────────────┘");
Console.WriteLine("❌ Common wrong answer: 14 or 42");
Console.WriteLine("✅ Correct answer: 50");
Console.WriteLine();

var quiz6 = Algebra.Constant(7)
    .Add(Algebra.Constant(7).Divide(7))
    .Add(Algebra.Constant(7).Multiply(7))
    .Subtract(7);

Console.WriteLine($"Expression tree: {quiz6}");
Console.WriteLine($"LaTeX: {quiz6.ToLaTeX()}");
Console.WriteLine();
Console.WriteLine("Step-by-step:");
Console.WriteLine("1. Division: 7 ÷ 7 = 1");
Console.WriteLine("2. Multiplication: 7 × 7 = 49");
Console.WriteLine("3. Now: 7 + 1 + 49 - 7");
Console.WriteLine("4. Left-to-right: 7 + 1 = 8");
Console.WriteLine("5. Continue: 8 + 49 = 57");
Console.WriteLine("6. Final: 57 - 7 = 50");
Console.WriteLine($"Result: {quiz6.Evaluate()}");
Console.WriteLine();

// ══════════════════════════════════════════════════════════════
// Problem 7: Fraction Division
// ══════════════════════════════════════════════════════════════
Console.WriteLine("┌─────────────────────────────────────────────────────────┐");
Console.WriteLine("│ Problem 7: 9 - 3 ÷ 1/3 + 1                              │");
Console.WriteLine("└─────────────────────────────────────────────────────────┘");
Console.WriteLine("❌ Many forget: dividing by 1/3 = multiplying by 3");
Console.WriteLine("✅ Correct answer: 1");
Console.WriteLine();

// 3 ÷ (1/3) = 3 × 3 = 9
var quiz7 = Algebra.Constant(9)
    .Subtract(Algebra.Constant(3).Divide(1.0/3.0))
    .Add(1);

Console.WriteLine($"Expression tree: {quiz7}");
Console.WriteLine($"LaTeX: {quiz7.ToLaTeX()}");
Console.WriteLine();
Console.WriteLine("Step-by-step:");
Console.WriteLine("1. Division by fraction: 3 ÷ (1/3) = 3 × 3 = 9");
Console.WriteLine("2. Now: 9 - 9 + 1");
Console.WriteLine("3. Left-to-right: 9 - 9 = 0");
Console.WriteLine("4. Final: 0 + 1 = 1");
Console.WriteLine($"Result: {quiz7.Evaluate()}");
Console.WriteLine();

// ══════════════════════════════════════════════════════════════
// Problem 8: The Viral Classic
// ══════════════════════════════════════════════════════════════
Console.WriteLine("┌─────────────────────────────────────────────────────────┐");
Console.WriteLine("│ Problem 8: 5 + 5 + 5 × 0 + 5                            │");
Console.WriteLine("└─────────────────────────────────────────────────────────┘");
Console.WriteLine("🔥 MOST SHARED FACEBOOK POST! 🔥");
Console.WriteLine("❌ Many say: 0 or 20 or 25");
Console.WriteLine("✅ Correct answer: 15");
Console.WriteLine();

var quiz8 = Algebra.Constant(5)
    .Add(5)
    .Add(Algebra.Constant(5).Multiply(0))
    .Add(5);

Console.WriteLine($"Expression tree: {quiz8}");
Console.WriteLine($"LaTeX: {quiz8.ToLaTeX()}");
Console.WriteLine();
Console.WriteLine("Step-by-step:");
Console.WriteLine("1. Multiplication ONLY: 5 × 0 = 0");
Console.WriteLine("2. Now: 5 + 5 + 0 + 5");
Console.WriteLine("3. Left-to-right addition: 15");
Console.WriteLine($"Result: {quiz8.Evaluate()}");
Console.WriteLine();
Console.WriteLine("💡 People who get 0: Multiplied EVERYTHING by zero");
Console.WriteLine("   People who get 20: Added before multiplying");
Console.WriteLine();

// ══════════════════════════════════════════════════════════════
// Problem 9: Double Zero
// ══════════════════════════════════════════════════════════════
Console.WriteLine("┌─────────────────────────────────────────────────────────┐");
Console.WriteLine("│ Problem 9: 50 + 50 × 0 + 2 + 2 × 0                      │");
Console.WriteLine("└─────────────────────────────────────────────────────────┘");
Console.WriteLine("❌ Common wrong answer: 0 or 104");
Console.WriteLine("✅ Correct answer: 52");
Console.WriteLine();

var quiz9 = Algebra.Constant(50)
    .Add(Algebra.Constant(50).Multiply(0))
    .Add(2)
    .Add(Algebra.Constant(2).Multiply(0));

Console.WriteLine($"Expression tree: {quiz9}");
Console.WriteLine($"LaTeX: {quiz9.ToLaTeX()}");
Console.WriteLine();
Console.WriteLine("Step-by-step:");
Console.WriteLine("1. Multiplication: 50 × 0 = 0");
Console.WriteLine("2. Multiplication: 2 × 0 = 0");
Console.WriteLine("3. Now: 50 + 0 + 2 + 0");
Console.WriteLine("4. Result: 52");
Console.WriteLine($"Result: {quiz9.Evaluate()}");
Console.WriteLine();

// ══════════════════════════════════════════════════════════════
// Problem 10: The Simple One That Isn't
// ══════════════════════════════════════════════════════════════
Console.WriteLine("┌─────────────────────────────────────────────────────────┐");
Console.WriteLine("│ Problem 10: 1 + 1 + 1 + 1 × 0 + 1                       │");
Console.WriteLine("└─────────────────────────────────────────────────────────┘");
Console.WriteLine("❌ People rush and say: 0 or 5");
Console.WriteLine("✅ Correct answer: 4");
Console.WriteLine();

var quiz10 = Algebra.Constant(1)
    .Add(1)
    .Add(1)
    .Add(Algebra.Constant(1).Multiply(0))
    .Add(1);

Console.WriteLine($"Expression tree: {quiz10}");
Console.WriteLine($"LaTeX: {quiz10.ToLaTeX()}");
Console.WriteLine();
Console.WriteLine("Step-by-step:");
Console.WriteLine("1. Multiplication: 1 × 0 = 0");
Console.WriteLine("2. Now: 1 + 1 + 1 + 0 + 1");
Console.WriteLine("3. Addition: 4");
Console.WriteLine($"Result: {quiz10.Evaluate()}");
Console.WriteLine();

// ══════════════════════════════════════════════════════════════
// Summary
// ══════════════════════════════════════════════════════════════
Console.WriteLine("════════════════════════════════════════════════════════════");
Console.WriteLine("                  🎓 WHAT WE LEARNED");
Console.WriteLine("════════════════════════════════════════════════════════════");
Console.WriteLine();
Console.WriteLine("The Golden Rule: PEMDAS / BODMAS");
Console.WriteLine("  P/B - Parentheses/Brackets");
Console.WriteLine("  E/O - Exponents/Orders");
Console.WriteLine("  MD  - Multiplication & Division (LEFT TO RIGHT)");
Console.WriteLine("  AS  - Addition & Subtraction (LEFT TO RIGHT)");
Console.WriteLine();
Console.WriteLine("Common Mistakes:");
Console.WriteLine("  ❌ Adding before multiplying");
Console.WriteLine("  ❌ Multiplying everything when you see ×0");
Console.WriteLine("  ❌ Forgetting left-to-right for same precedence");
Console.WriteLine("  ❌ Treating implicit multiplication (2(3)) as higher priority");
Console.WriteLine();
Console.WriteLine("Why Fluent.Algebra is perfect for this:");
Console.WriteLine("  ✅ Builds correct expression trees automatically");
Console.WriteLine("  ✅ Respects mathematical precedence rules");
Console.WriteLine("  ✅ Makes the order of operations explicit");
Console.WriteLine("  ✅ Can show LaTeX for educational purposes");
Console.WriteLine();
Console.WriteLine("════════════════════════════════════════════════════════════");
Console.WriteLine();
Console.WriteLine("💡 Want to create your own viral math puzzles?");
Console.WriteLine("   Just build expressions with Fluent.Algebra and");
Console.WriteLine("   let people argue in the comments! 😄");
Console.WriteLine();
