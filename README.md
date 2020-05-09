# Database description

## Access management
| Role name            | PRIVILEGES  | Group name       | Users            |
|  ----------------| ---------------  | -------- | -------- |
|r_reader | SELECT | g_reader |reader_user|
| r_writer| SELECT, INSERT, UPDATE, DELETE | g_writer |writer_user|
| r_manager| ALL | g_manager |manager_user|

Following scripts have been used to generate user accesses : 

```plsql
CREATE ROLE r_reader NOSUPERUSER INHERIT NOCREATEDB NOCREATEROLE NOREPLICATION;
GRANT USAGE ON SCHEMA public, campaign, bi, referential to r_reader;
GRANT SELECT ON ALL TABLES IN SCHEMA public, campaign, bi, referential to r_reader;
ALTER DEFAULT PRIVILEGES IN SCHEMA public, campaign, bi, referential GRANT SELECT ON TABLES TO r_reader;
CREATE ROLE g_reader NOSUPERUSER INHERIT NOCREATEDB NOCREATEROLE NOREPLICATION;
GRANT r_reader to g_reader;
CREATE ROLE reader_user WITH LOGIN ;
ALTER ROLE reader_user WITH PASSWORD '****' ;
ALTER ROLE reader_user VALID UNTIL 'infinity' ;
GRANT g_reader TO reader_user;
```

```plsql
CREATE ROLE r_writer NOSUPERUSER INHERIT NOCREATEDB NOCREATEROLE NOREPLICATION;
GRANT USAGE ON SCHEMA public, campaign, bi, referential to r_writer;
GRANT SELECT, INSERT, UPDATE, DELETE ON ALL TABLES IN SCHEMA public, campaign, bi, referential to r_writer;
ALTER DEFAULT PRIVILEGES IN SCHEMA public, campaign, bi, referential GRANT SELECT, INSERT, UPDATE, DELETE ON TABLES TO r_writer;
CREATE ROLE g_writer NOSUPERUSER INHERIT NOCREATEDB NOCREATEROLE NOREPLICATION;
GRANT r_writer to g_writer;
CREATE ROLE writer_user WITH LOGIN ;
ALTER ROLE writer_user WITH PASSWORD '****' ;
ALTER ROLE writer_user VALID UNTIL 'infinity' ;
GRANT g_writer TO writer_user;
```


```plsql
CREATE ROLE r_manager NOSUPERUSER INHERIT NOREPLICATION;
GRANT USAGE ON SCHEMA public, campaign, bi, referential to r_manager;
GRANT ALL ON ALL TABLES IN SCHEMA public, campaign, bi, referential to r_manager;
ALTER DEFAULT PRIVILEGES IN SCHEMA public, campaign, bi, referential GRANT ALL ON TABLES TO r_manager;
CREATE ROLE g_manager NOSUPERUSER INHERIT NOREPLICATION;
GRANT r_manager to g_manager;
CREATE ROLE manager_user WITH LOGIN ;
ALTER ROLE manager_user WITH PASSWORD '****' ;
ALTER ROLE manager_user VALID UNTIL 'infinity' ;
GRANT g_manager TO manager_user;
```



# Code - EF.Core

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
> dotnet ef migrations add NameOfMyMigration --context MyDbContext -o WhereMyMigrationWillBeStored

This will create a Migration class that describes our changes over the database.
Note that all tables of all schema are stored in the Models folder. Same for migrations, all stored under Migrations folder.
Example : 

> dotnet ef migrations add initPublicSchema --context PlasticoDbContext -o Migrations


Then update the db according to this migration
> dotnet ef database update

## How to edit the database/tables/columns?

1. Create a new git branch (never work directly on master)

2. Edit the entities (= tables) the say you want. They are stored in Models folder.

3. Edit the PlasticoDbContext.cs file. It represents the whole database and links all the entities (= tables) together.

4. When all edit is done, generate the corresponding Migration with command below : 

   > dotnet ef migrations add initPublicSchema --context PlasticoDbContext -o Migrations

5. If everything looks fine, create the pull request.

6. As soon as the PR is merged, the build pipeline (Azure DevOps) will generate the migration script (sql) and pass it to the Release pipeline.

   Another way of doing it is by executing the migration directly from your local computer via command below : 

   > dotnet ef database update

   EF.Core will detect automatically which migrations it needs to run (only the one not runned already).

## Scaffolding

Scaffolding is the fact or reverse engineer an existing database. This is the way we used to create our entities, as the database already existed.
To target a particular database schema, we run the following command : 
> dotnet-ef dbcontext scaffold "My Connection String" Npgsql.EntityFrameworkCore.PostgreSQL -o OutputDir -c ContextName --schema SchemaName
