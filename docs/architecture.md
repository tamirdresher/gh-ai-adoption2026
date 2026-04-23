# Architecture

For the full architecture decision record, see:
[`.squad/decisions/inbox/sheldon-initial-architecture.md`](../.squad/decisions/inbox/sheldon-initial-architecture.md)

## Summary

UniCart uses a .NET 8 stack with:
- **CLI** — `System.CommandLine` based terminal app
- **API** — Azure Functions v4 isolated worker
- **Data** — Azure Cosmos DB (serverless)
- **Connectors** — Plugin-based `IMarketplaceConnector` pattern

## Key Design Decisions

1. **.NET 8** — Type safety, cross-platform, unified language across CLI and API
2. **Plugin-based connectors** — Each marketplace implements `IMarketplaceConnector`, registered via DI
3. **Azure Functions over App Service** — Serverless pricing for bursty, early-stage workload
4. **Cosmos DB** — Flexible schema for varied product metadata; serverless tier keeps costs low
5. **Repository pattern** — Abstracts data access for testability
