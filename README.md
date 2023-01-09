# Cookbook
Shell application used for an intro course to Entity Framework Core

## Tooling
Tooling setup:
`dotnet tool install --global dotnet-ef`
alternatively, if you prefer a specific version:
`dotnet tool install --global dotnet-ef --version 6.0.1` if you get an unauthorized exception append `--ignore-failed-sources`
`dotnet ef` (See the unicorn?)

Migrations:
`dotnet ef migrations add <name_of_migration>`

Database Update:
`dotnet ef database update`

Other useful commands:
`dotnet ef database update <name_of_migration>` rolls your database back to the specified migration thus allowing you to revert a migration like this
`dotnet ef migrations remove` removes the last migration

`dotnet ef database drop` drops your database. Useful if you have messed up somehow and cannot be bothered trying to fix it
