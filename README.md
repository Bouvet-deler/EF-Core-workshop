# Cookbook
Shell application used for an intro course to Entity Framework Core

## Setup

Tooling setup:
```ps
dotnet tool install --global dotnet-ef
```

Alternatively, if you prefer a specific version:
```ps
dotnet tool install --global dotnet-ef --version 9.0.5
```
If you get an unauthorized exception append `--ignore-failed-sources`

Check the installation:

```ps
dotnet ef
```
See the unicorn?

## Tasks

Do the tasks [here](./Tasks.md).


## Useful commands

Add a new migration:
```ps
dotnet ef migrations add name_of_migration
```

Update the database to the latest migration:
```ps
dotnet ef database update
```

Update the database to a specific migration:
```ps
dotnet ef database update name_of_migration
```

This will revert the database to the specified migration if it is older than the current migration, 
or apply all migrations between the current migration and the target if it is newer.

Remove the last migration file:
```ps
dotnet ef migrations remove
```

Drops your database:
```
dotnet ef database drop
``` 
Useful if you have messed up somehow and cannot be bothered trying to fix it.