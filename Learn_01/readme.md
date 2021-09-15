# About

This branch will carry on for several weeks.

## Special topics

Talk about [Discards](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/discards) and [Deconstructing tuples and other types](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct)

[Example](https://github.com/karenpayneoregon/windows-forms-csharp/blob/Version1/CustomersDemo/ListBoxSaveForm.cs#L65)

```csharp
var (success, exception) = _customersBindingList.JsonToFile("CustomersSaved.json");
MessageBox.Show(exception is null ? "Saved" : $"Failed\n{exception.Message}");
```

---

| Operators  | Defintion|
| :--- |:--- |
| [=>](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-operator) operator (C# reference) | In lambda expressions, the lambda operator => separates the input parameters on the left side from the lambda body on the right side.|
| ! ([null-forgiving](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-forgiving)) operator | Available in C# 8.0 and later, the unary postfix ! operator is the null-forgiving, or null-suppression, operator. In an enabled nullable annotation context, you use the null-forgiving operator to declare that expression x of a reference type isn't null: x!. The unary prefix ! operator is the logical negation operator. |
| [?? and ??=](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-coalescing-operator) operators  | The null-coalescing operator ?? returns the value of its left-hand operand if it isn't null; otherwise, it evaluates the right-hand operand and returns its result. The ?? operator doesn't evaluate its right-hand operand if the left-hand operand evaluates to non-null.|
| [?:](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator) operator | The conditional operator ?:, also known as the ternary conditional operator, evaluates a Boolean expression and returns the result of one of the two expressions, depending on whether the Boolean expression evaluates to true or false,|

# Pattern matching enhancements

C# 9 includes [new pattern matching improvements](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#pattern-matching-enhancements):

- Type patterns match a variable is a type
- Parenthesized patterns enforce or emphasize the precedence of pattern combinations
- Conjunctive and patterns require both patterns to match
- Disjunctive or patterns require either pattern to match
- Negated not patterns require that a pattern doesn't match
- Relational patterns require the input be less than, greater than, less than or equal, or greater than or equal to a given constant.

##  Null check

`Readable` is null assertion

```csharp
if (customer is null)
{
    // ...
}
```

`Less readable` is null assertion

```csharp
if (customer.Value is { })
{
    // 
}
```

Easy to read `generic` language extensions

```csharp
public static bool IsNull<T>(this T senderInstance) where T : new() => senderInstance is null;
public static bool IsNotNull<T>(this T senderInstance) where T : new() => !senderInstance.IsNull();
```