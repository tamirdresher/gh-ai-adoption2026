# UniCart — Universal Shopping Cart CLI

A command-line tool that lets you add products from any online marketplace (Amazon, eBay, Walmart, etc.) into a unified shopping cart. Compare prices, track availability, and manage purchases across platforms — all from your terminal.

## Architecture

```
┌──────────────────────────────────────────────────────────┐
│                        CLI Layer                          │
│  ┌──────────┐  ┌──────────┐  ┌──────────┐  ┌──────────┐ │
│  │ add cmd  │  │ list cmd │  │remove cmd│  │checkout  │ │
│  └────┬─────┘  └────┬─────┘  └────┬─────┘  └────┬─────┘ │
│       └──────────────┴──────────────┴──────────────┘      │
│                         │                                  │
│              ┌──────────▼──────────┐                      │
│              │  HTTP Client SDK    │                      │
│              └──────────┬──────────┘                      │
└─────────────────────────┼────────────────────────────────┘
                          │ HTTPS + JWT
┌─────────────────────────▼────────────────────────────────┐
│                   Azure Functions API                     │
│  ┌────────────┐  ┌────────────┐  ┌────────────────────┐  │
│  │ Cart API   │  │ Auth       │  │ Connector          │  │
│  │ (CRUD)     │  │ Middleware │  │ Orchestrator       │  │
│  └─────┬──────┘  └────────────┘  └────────┬───────────┘  │
│        │                                   │              │
│  ┌─────▼──────┐              ┌─────────────▼───────────┐ │
│  │ Cosmos DB  │              │ Marketplace Connectors  │ │
│  │ Repository │              │ (Amazon, eBay, etc.)    │ │
│  └────────────┘              └─────────────────────────┘ │
└──────────────────────────────────────────────────────────┘
```

## Tech Stack

| Component | Technology |
|-----------|-----------|
| CLI | .NET 8 + System.CommandLine |
| Backend API | Azure Functions (isolated worker, .NET 8) |
| Database | Azure Cosmos DB (serverless) |
| IaC | Bicep + Azure Developer CLI |
| CI/CD | GitHub Actions |
| Auth | Azure Entra ID + JWT |

## Project Structure

```
/src
  /UniCart.Cli          — CLI application
  /UniCart.Api          — Azure Functions project
  /UniCart.Core         — Shared models, interfaces, DTOs
  /UniCart.Connectors   — Marketplace connector implementations
/tests
  /UniCart.Cli.Tests
  /UniCart.Api.Tests
  /UniCart.Core.Tests
  /UniCart.Connectors.Tests
/infra                  — Bicep templates
/docs                   — Architecture docs, ADRs
```

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Azure Functions Core Tools v4](https://learn.microsoft.com/azure/azure-functions/functions-run-local)
- [Azure CLI](https://learn.microsoft.com/cli/azure/install-azure-cli) (for deployment)

## Getting Started

```bash
# Clone the repo
git clone https://github.com/tamirdresher/gh-ai-adoption2026.git
cd gh-ai-adoption2026

# Restore and build
dotnet restore
dotnet build

# Run tests
dotnet test

# Run the CLI
dotnet run --project src/UniCart.Cli
```

## Contributing

1. Create a feature branch from `main`
2. Make your changes
3. Ensure all tests pass: `dotnet test`
4. Submit a pull request

## Team

| Role | Member |
|------|--------|
| Lead / Architect | Sheldon |
| Backend Dev | Leonard |
| CLI Dev | Howard |
| Tester | Raj |
| Azure Security | Bernadette |
| Customer Representative | Mats Willemsen |

## License

See [LICENSE](LICENSE) for details.
