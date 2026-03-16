using MarcusMedina.Fluent.Algebra;
using MarcusMedina.Fluent.Maths.Algebra.Builders;
using MarcusMedina.Fluent.Maths.Algebra.Evaluators;

// Problem: Interactive symbolic mathematics calculator
// This demonstrates building a calculator that manipulates expressions symbolically

Console.OutputEncoding = System.Text.Encoding.UTF8; // Enable emoji support

Console.WriteLine("=== Symbolic Mathematics Calculator ===\n");

// Create a calculator that tracks expressions and their properties
var calculator = new SymbolicCalculator();

// Example 1: Linear equation
Console.WriteLine("--- Scenario 1: Cost Analysis ---");
Console.WriteLine("Problem: Total cost = 50 (fixed) + 12x (per unit)");

var costExpr = Algebra.X.Multiply(12).Add(50);
calculator.Store("TotalCost", costExpr);

Console.WriteLine($"Expression: {costExpr.ToLatex()}\n");

Console.WriteLine("Cost for different quantities:");
for (int units = 0; units <= 10; units += 2)
{
    double cost = costExpr.Evaluate(x: units);
    Console.WriteLine($"  {units} units: ${cost}");
}
Console.WriteLine();

// Example 2: Revenue equation
Console.WriteLine("--- Scenario 2: Revenue Calculation ---");
Console.WriteLine("Problem: Revenue = 25x (price per unit)");

var revenueExpr = Algebra.X.Multiply(25);
calculator.Store("Revenue", revenueExpr);

Console.WriteLine($"Expression: {revenueExpr.ToLatex()}\n");

// Example 3: Profit = Revenue - Cost
Console.WriteLine("--- Scenario 3: Profit Analysis ---");
var profitExpr = revenueExpr.Subtract(costExpr);
calculator.Store("Profit", profitExpr);

Console.WriteLine($"Profit = Revenue - Cost");
Console.WriteLine($"       = {revenueExpr.ToLatex()} - ({costExpr.ToLatex()})");
Console.WriteLine($"       = {profitExpr.ToLatex()}\n");

Console.WriteLine("Profit analysis:");
for (int units = 0; units <= 20; units += 5)
{
    double revenue = revenueExpr.Evaluate(x: units);
    double cost = costExpr.Evaluate(x: units);
    double profit = profitExpr.Evaluate(x: units);
    Console.WriteLine($"  {units} units: Revenue=${revenue}, Cost=${cost}, Profit=${profit}");
}
Console.WriteLine();

// Find break-even point
Console.WriteLine("--- Break-even Analysis ---");
// Break-even when Profit = 0, so Revenue = Cost
// 25x = 12x + 50
// 13x = 50
// x = 50/13 ≈ 3.85
var breakEvenX = 50.0 / 13.0;
Console.WriteLine($"Break-even point: x = {breakEvenX:F2} units");
Console.WriteLine($"Verification: Profit = {profitExpr.Evaluate(x: breakEvenX):F2}\n");

// Example 4: Substitution
Console.WriteLine("--- Variable Substitution ---");
Console.WriteLine("Original: Revenue = 25x");

// Increase price to 30
var newPrice = 30.0;
var newRevenueExpr = Algebra.X.Multiply(newPrice);
calculator.Store("RevenueNew", newRevenueExpr);

Console.WriteLine($"New price: ${newPrice}");
Console.WriteLine($"New Revenue: {newRevenueExpr.ToLatex()}\n");

// Example 5: Polynomial (inventory)
Console.WriteLine("--- Inventory Optimization ---");
Console.WriteLine("Problem: Cost function = x² - 10x + 100 (inventory management)");

var inventoryExpr = Algebra.X.Square().Subtract(Algebra.X.Multiply(10)).Add(100);
calculator.Store("InventoryCost", inventoryExpr);

Console.WriteLine($"Expression: {inventoryExpr.ToLatex()}\n");

// Find minimum cost
Console.WriteLine("Cost at different inventory levels:");
var minCost = double.MaxValue;
var optimalLevel = 0.0;

for (double x = 0; x <= 20; x += 1)
{
    double cost = inventoryExpr.Evaluate(x: x);
    Console.WriteLine($"  Level {x:F0}: Cost = {cost:F2}");

    if (cost < minCost)
    {
        minCost = cost;
        optimalLevel = x;
    }
}

Console.WriteLine($"\nOptimal inventory level: {optimalLevel:F0} units");
Console.WriteLine($"Minimum cost: ${minCost:F2}\n");

// Summary
Console.WriteLine("--- Stored Expressions ---");
calculator.PrintAll();
