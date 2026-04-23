# Decision: Test Strategy and Framework Setup

**Author:** Raj (Tester/QA)
**Date:** 2025-07-17
**Status:** Proposed

---

## Decision

Adopt xUnit + Moq + FluentAssertions as the test stack, with coverlet for code coverage, a shared TestHelpers project for builders and mocks, and an 80% overall coverage target.

## Context

Issue #9 requires establishing the testing infrastructure for UniCart. The architecture (per Sheldon's decision) uses .NET 8, a plugin-based connector model, and a repository pattern — all of which need clear testing strategies.

## Key Choices

### Framework: xUnit over NUnit/MSTest
- xUnit is the .NET community standard; best tooling support in CI
- Constructor-based test setup encourages proper isolation
- `IAsyncLifetime` fits our async connector/repository patterns

### Mocking: Moq over NSubstitute
- Moq has the largest community and documentation base
- Familiar `Setup`/`Verify` API for the team
- Sufficient for our interface-driven architecture

### Assertions: FluentAssertions
- Readable, expressive assertion syntax
- Better error messages than raw xUnit `Assert.*`
- Extensive collection and async support

### Shared TestHelpers Project
- Builder pattern for `CartItem` and `Product` — avoids duplicated test data
- `InMemoryCartRepository` fake for repository tests without Cosmos DB
- `MarketplaceConnectorTestBase` for standardized connector validation

### Coverage: 80% Overall Target
- Core models: 90% (critical path)
- Connectors: 85% (each must have URL + fetch tests)
- API: 80% (endpoints + middleware)
- CLI: 75% (output formatting hard to unit test)

## Risks

| Risk | Mitigation |
|------|-----------|
| Moq doesn't support `sealed` classes | Use wrapper interfaces; consider NSubstitute later if needed |
| Coverage gaming (testing trivial code) | Review test quality in PRs, not just coverage numbers |
| Slow integration tests | Categorize with `[Trait]`; run unit tests on PR, integration on merge |

## Alternatives Considered

- **NSubstitute:** Cleaner syntax but smaller community; Moq is more widely known
- **MSTest:** Microsoft-maintained but less flexible than xUnit
- **No shared TestHelpers:** Would lead to copy-paste test data across projects
