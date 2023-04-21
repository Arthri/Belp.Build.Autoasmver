# NuGet Source
Belp uses a temporary NuGet source "`tmp`" to push and pull development versions of packages for testing end-user experience.

## Creation
1. Create a new folder for the NuGet source.
1. `dotnet nuget add source <SOURCE_PATH> --name tmp`. Replace `<SOURCE_PATH>` with the full path of the folder created earlier.

## Pushing
There are multiple ways to push to the temporary NuGet source:
- `dotnet build <PROJECT> -p:DevelopmentNuGet=true`.
- (cmd)`set DevelopmentNuGet=true`, then `dotnet build <PROJECT>`.
- (sh)`export DevelopmentNuGet=true`, then `dotnet build <PROJECT>`.
- (sh)`DevelopmentNuGet=true dotnet build <PROJECT>`.

!!! note
    The package's version must not be a published version.

## Deletion
The "`tmp`" NuGet Source and its folder can be deleted after development.
