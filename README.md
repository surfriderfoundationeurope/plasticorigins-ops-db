<h1 align="left">Plastic Origins OPS DB</h1>

<a href="https://www.plasticorigins.eu/"><img width="80px" src="https://github.com/surfriderfoundationeurope/The-Plastic-Origins-Project/blob/master/assets/PlasticOrigins_logo.png" width="5%" height="5%" align="left" hspace="0" vspace="0"></a>

  <p align="justify">Proudly Powered by <a href="https://surfrider.eu/">SURFRIDER Foundation Europe</a>, this open-source initiative is a part of the <a href="https://www.plasticorigins.eu/">PLASTIC ORIGINS</a> project - a citizen science project that uses AI to map plastic pollution in European rivers and share its data publicly. Browse the <a href="https://github.com/surfriderfoundationeurope/The-Plastic-Origins-Project">project repository</a> to know more about its initiatives and how you can get involved. Please consider starring :star: the project's repositories to show your interest and support. We rely on YOU for making this project a success and thank you in advance for your contributions.</p>

_________________

<!--- OPTIONAL: You can add badges and shields to reflect the current status of the project, the licence it uses and if any dependencies it uses are up-to-date. Plus they look pretty cool! You can find a list of badges or design your own at https://shields.io/ --->

# Database configuration
Several extension need to be installed on our PostGre SQL database : 
* postgis
* postgis_topology
* pg_routing

# Database description
## How to edit the database/tables/columns?
Create a new git branch (never work directly on master)

<!--- PLEASE check the following and COMPLETE using the following example: Welcome to **'Name'**, a `<utility/tool/feature>` that allows `<insert_target_audience>` to do `<action/task_it_does>`--->
Welcome to **'Plastic Origins OPS DB'**, a database management (access, code, etc) that uses EF.Core to manage database directly from code.

## Getting Started
<!--- This section guides users through getting your code up and running on their own system.--->

### Prerequisites

Before you begin, ensure you have met the following requirements:
<!--- These are just EXAMPLE requirements copied from another project's repos: add or remove as required --->
* You have installed [`.Net Core 3.1 or lastest`](https://dotnet.microsoft.com/download/dotnet/3.1)
* You have installed the latest version of [`Azure Emulator`](https://docs.microsoft.com/en-us/azure/storage/common/storage-use-emulator) if you want to use on your local machine
* You have a `PostgreSQL 11.6 minimum` database for local use on your machine OR `Microsoft Azure PostgreSQL` (you can create a free account [here](https://azure.microsoft.com/fr-fr/services/postgresql/))
* You have `Visul Studio 2019` (or latest version)
  or you have latest version of `Visual code`.

#### Technical stack
<!--- These are just EXAMPLE copied from another project's repos: add or remove as required --->
* Language: `C#`
* Framework: `.Net Core`
* Functionality : `Azure function`
* Unit test framework: `XUnit`

<!---The information below is copied from the current repo's README file: if not placed correctly, move to the appropriate section. --->

### Schema

<insert database schema image>

Logs : all log entries have default status = HARD_FAIL

We define 3 different status :

* SUCCESS
* GRACEFULL_FAIL : we know the reason why it failed
* HARD_FAIL : something unexpected happened

For more details, check `Plastic Origins database documentation` file.

### Access management

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

### Installation
<!--- TODO: It's a code block illustrating how to install. Include any system-specific information needed for installation. If there are multiple versions which the user may interface with, an updating section would be useful. Add Dependencies subsection if there are unusual dependencies or dependencies that must be manually installed.--->

<!---The information below is copied from the current repo's README file: if not placed correctly, move to the appropriate section. --->

#### Setup the project

The project can connect both to local and distant db. It first reads the connection strings contained in the appsettings.local.json file, then in your local environnement variable.

You need to store your local db connection string to appsettings.local.json by replacing the existing.
If you want to connect to distant db, do not store the connection string in the code. Instead, set the connection string in your environnement variable.
To do that, cf https://docs.microsoft.com/en-us/azure/azure-app-configuration/quickstart-dotnet-core-app#build-and-run-the-app-locally

### Usage
<!---TODO: It's a code block illustrating common usage that might cover basic choices that may affect usage (for instance, if JavaScript, cover promises/callbacks, ES6). If CLI importable, code block indicating both import functionality and usage (if CLI functionality exists, add CLI subsection).If relevant, point to a runnable file for the usage code. In this section add run commands and examples you think users will find useful--->

<!---The information below is copied from the current repo's README file: if not placed correctly, move to the appropriate section. --->

#### Principles

Every database table is represented by a C# class.

Everytime we need to make some changes over the database schema, we need to create a EFCore "Migration"
> dotnet ef migrations add NameOfMyMigration --context MyDbContext -o WhereMyMigrationWillBeStored -idempotent

This will create a Migration class that describes our changes over the database.
Note that all tables of all schema are stored in the Models folder. Same for migrations, all stored under Migrations folder.
Example :

> dotnet ef migrations add initPublicSchema --context PlasticoDbContext -o Migrations -idempotent

Then update the db according to this migration
> dotnet ef database update

<!--- If needed add here any Extra Sections (must have their own titles).Specifically, the Security section should be here if it wasn't important enough to be placed above.-->

<!--- ### API references --->
<!---TODO: Describe exported functions and objects. Describe signatures, return types, callbacks, and events. Cover types covered where not obvious. Describe caveats. If using an external API generator (like go-doc, js-doc, or so on), point to an external API.md file. This can be the only item in the section, if present. Add information or remove this section if not applicable.--->

<!--- If an external API file is work in progress and/or you are planning to host API specification in the Swagger documentation, you can use the text below as EXAMPLE (add or remove as required): *SOON: To see API specification used by this repository browse to the Swagger documentation (currently not available).* -->

## **Build and Test**
<!---TODO: Describe and show how to build your code and run the tests. Add information or remove this section if not applicable. --->

<!---The information below is copied from the current repo's README file: if not placed correctly, move to the appropriate section. --->

### How to edit the database/tables/columns?

1. Create a new git branch (never work directly on master)

2. Edit the entities (= tables) the way you want. They are stored in Models folder.

3. Edit the PlasticoDbContext.cs file. It represents the whole database and links all the entities (= tables) together.

4. When all edit is done, generate the corresponding Migration with command below : 

   > dotnet ef migrations add initPublicSchema --context PlasticoDbContext -o Migrations

5. If everything looks fine, create the pull request.

6. As soon as the PR is merged, the build pipeline (Azure DevOps) will generate the migration script (sql) and pass it to the Release pipeline.

   Another way of doing it is by executing the migration directly from your local computer via command below : 

   > dotnet ef database update

   EF.Core will detect automatically which migrations it needs to run (only the one not runned already).

### Scaffolding

Scaffolding is the fact or reverse engineer an existing database. This is the way we used to create our entities, as the database already existed.
To target a particular database schema, we run the following command :

> dotnet-ef dbcontext scaffold "My Connection String" Npgsql.EntityFrameworkCore.PostgreSQL -o OutputDir -c ContextName --schema SchemaName

## Contributing

It's great to have you here! We welcome any help and thank you in advance for your contributions.

* Feel free to **report a problem/bug** or **propose an improvement** by creating a [new issue](https://github.com/surfriderfoundationeurope/plasticorigins-ops-db/issues). Please document as much as possible the steps to reproduce your problem (even better with screenshots). If you think you discovered a security vulnerability, please contact directly our [Maintainers](##Maintainers).

* Take a look at the [open issues](https://github.com/surfriderfoundationeurope/plasticorigins-ops-db/issues) labeled as `help wanted`, feel free to **comment** to share your ideas or **submit a** [**pull request**](https://github.com/surfriderfoundationeurope/plasticorigins-ops-db/pulls) if you feel that you can fix the issue yourself. Please document any relevant changes.

## Maintainers

If you experience any problems, please don't hesitate to ping:
<!--- Need to check the full list of Maintainers and their GIThub contacts -->
* [@ChristopheHvd](https://github.com/ChristopheHvd)

Special thanks to all our [Contributors](https://github.com/orgs/surfriderfoundationeurope/people).

## License

We’re using the `MIT` License. For more details, check [`LICENSE`](https://github.com/surfriderfoundationeurope/plasticorigins-ops-db/blob/master/LICENSE) file.

# Azure Deployment

You can use [shell.azure.com](https://shell.azure.com) to execute the following commands: 

```bash
git clone https://github.com/surfriderfoundationeurope/plasticorigins-ops-db.git
./plasticorigins-ops-db/infrastructure/deploy-prod.sh
```
