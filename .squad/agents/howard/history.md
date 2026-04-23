# Howard — History

## Project Context
- **Project:** Universal shopping cart CLI — add products from any marketplace (Amazon, eBay, etc.)
- **Stack:** CLI tool, Azure backend, marketplace integrations
- **User:** Copilot
- **Source Control:** GitHub

## Learnings

### 2025-07-23 — CLI Framework Setup (Issue #2, PR #12)
- **System.CommandLine 3.0 preview API changes**: The `Argument<T>` and `Option<T>` constructors no longer accept a `description` parameter — use the `Description` property setter instead. Aliases for options go in the constructor (e.g., `new Option<string>("--marketplace", "-m")`), not via `AddAlias()`. Invocation is via `rootCommand.Parse(args).InvokeAsync()` not `rootCommand.InvokeAsync(args)`.
- **Branch from scaffolding**: The `squad/1-project-scaffolding` branch had the project structure with net10.0 targets and a UniCart.Core project reference already in the CLI csproj. Always check what exists before overwriting.
- **Shared worktree hazard**: Other agents can switch branches on the shared repo. Always verify you're on the right branch before committing.
- **Package versions**: When targeting net10.0, use the latest stable versions of Microsoft.Extensions.* packages that support it (e.g., 9.0.5+).
