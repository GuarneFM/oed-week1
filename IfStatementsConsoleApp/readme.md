# About

- Using `if` statements
- [Pattern matching](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/pattern-matching) and [Discards](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/discards) 

# Misc

Directs tracing or debugging output to a file

Discussion point `app.config`

```xml
<system.diagnostics>
	<trace autoflush="true">
		<listeners>
			<add name="textListener"
				    type="System.Diagnostics.TextWriterTraceListener"
				    initializeData="trace.log" />
			<remove name="Default" />
		</listeners>
	</trace>
</system.diagnostics>
```