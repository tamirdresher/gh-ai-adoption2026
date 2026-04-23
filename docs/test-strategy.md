# UniCart Test Strategy

## Overview

This document defines the test strategy for the UniCart (Universal Shopping Cart) CLI project. Our goal is to maintain high code quality, prevent regressions, and ensure marketplace connectors work reliably across all supported platforms.

## Test Layers

### 1. Unit Tests
**Scope:** Individual classes, methods, and logic in isolation.
**Framework:** xUnit + Moq + FluentAssertions
**Location:** `tests/UniCart.{Component}.Tests/`

| Project | Tests For |
|---------|-----------|
| `UniCart.Core.Tests` | Models, DTOs, interfaces, shared logic |
| `UniCart.Cli.Tests` | CLI commands, argument parsing, output formatting |
| `UniCart.Api.Tests` | API endpoints, request handling, DI configuration |
| `UniCart.Connectors.Tests` | Marketplace connectors, URL matching, product parsing |

**Conventions:**
- Test class name: `{ClassUnderTest}Tests`
- Test method name: `{Method}_{Scenario}_{ExpectedResult}` (e.g., `AddItem_ValidProduct_ReturnsSuccess`)
- One assertion concept per test (use multiple `Should()` calls for the same concept)
- Use `CartItemBuilder` / `ProductBuilder` from `UniCart.TestHelpers` for test data
- Prefer `FluentAssertions` over raw `Assert.*`

### 2. Integration Tests
**Scope:** Component interactions, API pipeline, data persistence.
**Framework:** xUnit + `Microsoft.AspNetCore.Mvc.Testing` (when API is ready)

**Patterns:**
- Use `WebApplicationFactory<T>` for API integration tests
- Use `InMemoryCartRepository` from `UniCart.TestHelpers` for data layer tests
- Test the full request/response cycle through the API pipeline
- Verify DI container wiring and middleware behavior

### 3. End-to-End (E2E) Tests
**Scope:** Full CLI command execution against mocked backends.
**Approach:**
- Invoke CLI commands as processes
- Mock marketplace HTTP responses with test fixtures
- Verify CLI output and exit codes

## Marketplace Mocking Approach

### Connector Testing
All marketplace connectors implement `IMarketplaceConnector`. For testing:

1. **Unit tests:** Use `Moq` to mock the interface for consumers (API, CLI)
2. **Connector tests:** Extend `MarketplaceConnectorTestBase` from TestHelpers to validate URL matching
3. **HTTP mocking:** Use mocked `HttpClient` / `HttpMessageHandler` for HTTP-level tests
4. **Test data:** Use `ProductBuilder` to create consistent test products

```csharp
// Example: Testing a connector's URL matching
public class AmazonConnectorTests : MarketplaceConnectorTestBase
{
    protected override IMarketplaceConnector Connector => new AmazonConnector();
    protected override IEnumerable<string> ValidUrls => new[]
    {
        "https://www.amazon.com/dp/B00TEST123",
        "https://amazon.com/product/123"
    };
    protected override IEnumerable<string> InvalidUrls => new[]
    {
        "https://ebay.com/item/123",
        "https://google.com"
    };
}
```

## Shared Test Utilities

Located in `tests/UniCart.TestHelpers/`:

| Utility | Purpose |
|---------|---------|
| `Builders/CartItemBuilder` | Fluent builder for `CartItem` test data |
| `Builders/ProductBuilder` | Fluent builder for `Product` test data |
| `Mocks/InMemoryCartRepository` | In-memory `ICartRepository` for testing |
| `Mocks/MarketplaceConnectorTestBase` | Base class for connector URL-matching tests |

## CI Test Execution Plan

### Pull Request Pipeline
```yaml
- dotnet restore
- dotnet build --no-restore
- dotnet test --no-build --collect:"XPlat Code Coverage"
- Report coverage to PR comment
```

### Test Execution Rules
- All tests must pass before merge
- New code must include tests
- Coverage must not decrease on PRs

### Test Categorization (Traits)
```csharp
[Trait("Category", "Unit")]        // Fast, isolated tests
[Trait("Category", "Integration")] // Component interaction tests
[Trait("Category", "E2E")]         // Full system tests
```

CI runs all `Unit` tests on every PR. `Integration` and `E2E` tests run on merges to `main`.

## Coverage Targets

| Component | Target | Rationale |
|-----------|--------|-----------|
| `UniCart.Core` | ≥ 90% | Core models and interfaces — critical path |
| `UniCart.Connectors` | ≥ 85% | Each connector must have URL matching + product fetch tests |
| `UniCart.Api` | ≥ 80% | API endpoints and middleware |
| `UniCart.Cli` | ≥ 75% | CLI commands (some output formatting hard to test) |
| **Overall** | **≥ 80%** | Project-wide minimum threshold |

### Coverage Tooling
- **Collector:** `coverlet.collector` (included in all test projects)
- **Report format:** Cobertura XML for CI integration
- **Local viewing:** `dotnet tool install -g dotnet-reportgenerator-globaltool`

```bash
# Generate coverage report locally
dotnet test --collect:"XPlat Code Coverage"
reportgenerator -reports:"**/coverage.cobertura.xml" -targetdir:"coveragereport"
```

## Quality Gates

1. **Pre-commit:** All unit tests pass locally
2. **PR:** Full test suite passes + coverage threshold met
3. **Main branch:** Integration + E2E tests pass
4. **Release:** Manual smoke test of CLI commands against live marketplaces (staging)

## Test Data Management

- Use builder pattern (`CartItemBuilder`, `ProductBuilder`) for all test data
- Never use production URLs or real marketplace data in tests
- Use deterministic IDs in tests (avoid `Guid.NewGuid()` in assertions)
- Keep test data in the test project, not in shared fixtures (unless truly shared)
