# plasticorigins-ops-db
## Goal
Goal here is to manage database directly from code.

## Setup the project
The project can connect both to local and distant db. It first reads the connection strings contained in the appsettings.local.json file, then in your local environnement variable.

You need to store your local db connection string to appsettings.local.json by replacing the existing.
If you want to connect to distant db, do not store the connection string in the code. Instead, set the connection string in your environnement variable.
To do that, cf https://docs.microsoft.com/en-us/azure/azure-app-configuration/quickstart-dotnet-core-app#build-and-run-the-app-locally

## Principles
Every database table is represented by a C# class.

Everytime we need to make some changes over the database schema, we need to create a EFCore "Migration"
> dotnet ef migrations add NameOfMyMigration

This will create a Migration class that describes our changes over the database.

Then update the db according to this migration
> dotnet ef database update

