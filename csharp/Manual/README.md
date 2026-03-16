# MarcusMedina.Fluent.Algebra Manual

Complete documentation for the Fluent Algebra API.

---

## 📚 Table of Contents

1. **[Getting Started](./GettingStarted.md)** - Installation and first steps (5 min read)
   - Installation instructions
   - Your first expression
   - Basic operations

2. **[Examples](./Examples/)** - Detailed usage examples
   - Example 1: Building Expressions
   - Example 2: Variable Substitution
   - Example 3: LaTeX Export
   - Example 4: Simplification
   - Example 5: Advanced Usage

3. **[Advanced Topics](./Advanced.md)** - Deep dive into advanced features
   - Custom functions and operators
   - Performance optimization
   - Expression analysis
   - Integration with other libraries

4. **[API Reference](./API.md)** - Complete API documentation
   - Classes and interfaces
   - Methods and properties
   - Extension methods
   - Enums and types

---

## 🎯 Quick Navigation

**I want to...**

- **Get started quickly** → [Getting Started](./GettingStarted.md)
- **See working code examples** → [Examples](./Examples/)
- **Understand the API** → [API Reference](./API.md)
- **Learn advanced techniques** → [Advanced Topics](./Advanced.md)
- **Find a specific feature** → Use Ctrl+F or see [API Reference](./API.md)

---

## 📖 Documentation Structure

### Getting Started (5 minutes)
Perfect for new users. Covers:
- How to install the package
- Creating your first expression
- Basic operations (Add, Multiply, etc.)
- Evaluating expressions

### Examples (20-30 minutes)
Practical examples showing real usage:
- Building simple and complex expressions
- Working with multiple variables
- Converting to LaTeX
- Simplifying expressions
- Combining operations

### Advanced Topics (30+ minutes)
For users wanting to master the library:
- Creating custom functions
- Performance tuning
- Expression analysis
- Integration strategies
- Best practices

### API Reference (Reference)
Complete documentation of every class, method, and property:
- `Algebra` static builder
- Expression classes
- Extension methods
- Helper types
- Return types and behaviors

---

## 🚀 Common Workflows

### Workflow 1: Build → Evaluate
```csharp
var expr = Algebra.X.Add(5).Square();
double result = expr.Evaluate(x: 2);
```
See: [Getting Started](./GettingStarted.md)

### Workflow 2: Build → Export to LaTeX
```csharp
var expr = Algebra.X.Multiply(2).Add(3);
string latex = expr.ToLatex();
```
See: [Examples/LaTeX Export](./Examples/Example3_LaTeXExport.md)

### Workflow 3: Symbolic Manipulation
```csharp
var expr = Algebra.X.Square().Add(Algebra.X).Add(1);
var simplified = expr.Simplify();
```
See: [Examples/Simplification](./Examples/Example4_Simplification.md)

---

## 💡 Key Concepts

### Expressions
- Build mathematical expressions using fluent API
- Expressions are immutable
- Chain operations naturally
- Type-safe by default

### Variables
- Use `Algebra.X`, `Algebra.Y`, etc. for named variables
- Create custom variables with `new Variable("name")`
- Multiple variables supported

### Evaluation
- Replace variables with numeric values
- Built-in for common operations
- Extensible for custom operations

### Simplification
- Automatic constant folding
- Identity rule application
- Optional: user-triggered simplification
- Can be extended with custom rules

---

## 🔍 Troubleshooting

### Expression won't build
- Check syntax matches fluent API pattern
- Ensure all operations are valid
- See [API Reference](./API.md) for available methods

### LaTeX output unexpected
- Review [LaTeX Export example](./Examples/Example3_LaTeXExport.md)
- Check expression structure is as expected
- Enable debugging to see intermediate steps

### Performance issues
- See [Advanced Topics - Performance](./Advanced.md#performance)
- Consider expression caching
- Profile before optimizing

---

## 📞 Getting Help

- **Stuck?** Check the [Examples](./Examples/) folder
- **Need API details?** See [API Reference](./API.md)
- **Want best practices?** Read [Advanced Topics](./Advanced.md)
- **Found a bug?** Report on GitHub Issues

---

## 📝 Document Index

| Document | Purpose | Read Time |
|----------|---------|-----------|
| Getting Started | Installation & basics | 5 min |
| Examples | Practical usage | 20-30 min |
| Advanced Topics | Master the library | 30+ min |
| API Reference | Complete documentation | As needed |

---

**Last Updated:** 2025-03-16
**Version:** 0.2.0
**License:** MIT
