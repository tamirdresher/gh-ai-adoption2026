# Raj — History

## Project Context
- **Project:** Universal shopping cart CLI — add products from any marketplace (Amazon, eBay, etc.)
- **Stack:** CLI tool, Azure backend, marketplace integrations
- **User:** Copilot
- **Source Control:** GitHub

## Learnings

### 2025-07-17 — Issue #9: Testing Framework Setup

- **What worked:** Creating test projects with `dotnet new xunit` and adding NuGet packages via `dotnet add package` was straightforward. Builder pattern for test data (CartItemBuilder, ProductBuilder) immediately proved useful — every test used them.
- **What didn't:** The scaffolding branch (squad/1) wasn't ready when I started, so I created the source project stubs myself. The CLI project (from squad/2) had pre-existing build errors (`SetAction` API mismatch with System.CommandLine beta). Those are not test-related — filed as a known issue.
- **Key decisions:** Chose Moq over NSubstitute (wider adoption), FluentAssertions for readable assertions, and coverlet.collector for coverage. Created a shared TestHelpers project to avoid test data duplication.
- **Coverage targets:** 80% overall, with higher targets (90%) for core models. These are enforced in CI once pipeline is set up.
- **17 tests passing** across 4 test projects: Core (10), Api (2), Connectors (3), Cli (2).
