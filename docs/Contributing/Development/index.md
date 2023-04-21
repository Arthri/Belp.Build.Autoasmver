# Development

## Prerequisites

### Windows
- Visual Studio 2022(17.0) or above.
- .NET 7 SDK.

### MacOS / OSX
Not supported.

### Linux
- .NET 7 SDK.

## Building
1. Clone the project.
1. `dotnet build`. Building a project may vary from case to case; hence, consult the relevant project's documentation for more details.

## Publishing

### NuGet
Pushing packages to NuGet is exclusively done by GitHub Actions.
1. Send a pull request to the branch `release/nuget`.
1. Merge the pull request.
1. Approve the workflow for usage of the `NuGet` environment.
1. Create a new release and tag on the `release/nuget` branch.
