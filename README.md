# Community.PowerToys.Run.Plugin.Templates

[![build](https://github.com/hlaueriksson/Community.PowerToys.Run.Plugin.Templates/actions/workflows/build.yml/badge.svg)](https://github.com/hlaueriksson/Community.PowerToys.Run.Plugin.Templates/actions/workflows/build.yml)
[![Community.PowerToys.Run.Plugin.Templates](https://img.shields.io/nuget/v/Community.PowerToys.Run.Plugin.Templates.svg?label=Community.PowerToys.Run.Plugin.Templates)](https://www.nuget.org/packages/Community.PowerToys.Run.Plugin.Templates)

This dotnet new template simplifies creating PowerToys Run Plugin projects.

## Installation

Install:

```cmd
dotnet new install Community.PowerToys.Run.Plugin.Templates
```

Update installed templates:

```cmd
dotnet new update
```

Uninstall:

```cmd
dotnet new uninstall Community.PowerToys.Run.Plugin.Templates
```

## Usage

Help:

```cmd
dotnet new ptrun --help
```

Create a project in the output directory `MyPlugin` and with the name `MyPlugin`:

```cmd
dotnet new ptrun -o MyPlugin -n MyPlugin
```

Create a project in the output directory `MyPlugin`:

```cmd
dotnet new ptrun -o MyPlugin
```

Create a directory and then a project:

```cmd
mkdir MyPlugin
cd MyPlugin
dotnet new ptrun
```

Create a solution and add projects:

```cmd
dotnet new sln
dotnet sln add (ls -r **/*.csproj)
```

Plugin author:

```cmd
dotnet new ptrun --plugin-author octocat
```

Test project:

```cmd
dotnet new ptrun --test-project false
```

## Disclaimer

This is not an official Microsoft PowerToys template.
