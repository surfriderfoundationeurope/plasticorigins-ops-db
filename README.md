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
> dotnet ef migrations add NameOfMyMigration --context MyDbContext -o WhereMyContextIsStored

This will create a Migration class that describes our changes over the database.
Note that we precise which context we are working on, and where to store the Migration files. For the sake of simplicity, we will organize Migrations folders the same way we organize contexts.
Example : 
> dotnet ef migrations add initPublicSchema --context Pg_PublicDataContext -o Migrations/Pg/Public


Then update the db according to this migration
> dotnet ef database update

## Scaffolding
Scaffolding is the fact or reverse engineer an existing database. This is the way we used to create our entities, as the database already existed.
To target a particular database schema, we run the following command : 
> dotnet-ef dbcontext scaffold "My Connection String" Npgsql.EntityFrameworkCore.PostgreSQL -o OutputDir -c ContextName --schema SchemaName
