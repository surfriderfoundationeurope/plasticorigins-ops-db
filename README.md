# Schema

<insert database schema image>

Logs : all log entries have default status = HARD_FAIL

We define 3 different status : 

* SUCCESS
* GRACEFULL_FAIL : we know the reason why it failed
* HARD_FAIL : something unexpected happened

# Database description
## How to edit the database/tables/columns?
Create a new git branch (never work directly on master)

Edit the entities (= tables) the say you want. They are stored in Models folder.

Edit the PlasticoDbContext.cs file. It represents the whole database and links all the entities (= tables) together.

When all edit is done, generate the corresponding Migration with command below :

dotnet ef migrations add PlaceHereNameOfMigration --context PlasticoDbContext -o Migrations

If everything looks fine, create the pull request.

As soon as the PR is merged, the build pipeline (Azure DevOps) will generate the migration script (sql) and pass it to the Release pipeline.

Another way of doing it is by executing the migration directly from your local computer via command below :

dotnet ef database update

EF.Core will detect automatically which migrations it needs to run (only the one not runned already).
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
> dotnet ef migrations add NameOfMyMigration --context MyDbContext -o WhereMyMigrationWillBeStored -idempotent

This will create a Migration class that describes our changes over the database.
Note that all tables of all schema are stored in the Models folder. Same for migrations, all stored under Migrations folder.
Example : 

> dotnet ef migrations add initPublicSchema --context PlasticoDbContext -o Migrations -idempotent


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

# Description of DB content
### BI schema

| Tables                    | Fields                                     | Type        | Unit      | What it is                                                   |
| ------------------------- | ------------------------------------------ | ----------- | --------- | ------------------------------------------------------------ |
| bi.campaign               | id                                         |             |           |                                                              |
|                           | id_ref_campaign_fk                         | foreign key |           | Campaign ID                                                  |
|                           | locomotion                                 | text        |           | How the data was collected (by foot, kayak, drone, etc.)     |
|                           | isaidriven                                 | yes/no      |           | Whether wastes have been detected and counted using AI or observed by human observators |
|                           | remark                                     | text        |           | Remarks sent by users after data collection                  |
|                           | id_ref_user_fk                             | foreign key |           | ID of the user who has collected the data                    |
|                           | riverside                                  | right/left  |           | River bank monitored (either right or left). The right river bank is at your right when looking downstream. |
|                           | container_url                              |             |           | Container where raw data are stored (video and/or GPX files) |
|                           | blob_name                                  |             |           | Blob storage where raw data are stored (video and/or GPX files) |
|                           | id_re_model_fk                             | foreign key |           | ID that indicates AI version used together with BI scripts version |
|                           | start_date                                 | date        |           | Start date and time of the campaign                          |
|                           | end_date                                   | date        |           | End date and time of the campaign                            |
|                           | start_point                                | list ?      |           | Lat/Lon where the campaign has started                       |
|                           | end_point                                  | list ?      |           | Lat/Lon where the campaign has ended                         |
|                           | total_distance                             | numeric     | meters    | Distance traveled during the campaign (projected on river segment) |
|                           | avg_speed                                  | numeric     | m/s       | Average displacement speed during the campaign               |
|                           | duration                                   | numeric     | seconds ? | Duration of the campaign                                     |
|                           | start_point_distance_sea                   | numeric     | meters    | Distance from the start point of the campaign to the river estuary |
|                           | end_point_distance_sea                     | numeric     | meters    | Distance from the end point of the campaign to the river estuary |
|                           | trash_count                                | integer     |           | Number of trash counted during the campaign                  |
|                           | distance_start_end                         | numeric     | meters    | Distance traveled during the campaign (real distance traveled including zigzags if any) |
|                           | createdon                                  | date        |           | Date of the campaign                                         |
| bi.campaign_river         | id                                         |             |           |                                                              |
|                           | id_ref_campaign_fk                         | foreign key |           | Campaign ID                                                  |
|                           | river_name                                 | text        |           | River name                                                   |
|                           | distance                                   | numeric     | meters    | Distance monitored on each river                             |
|                           | the_geom                                   |             |           | River segment/track                                          |
|                           | createdon                                  | date        |           | ?                                                            |
| bi.river                  | name                                       | text        |           | River name                                                   |
|                           | the_geom                                   |             |           | River segment/track                                          |
|                           | length                                     | numeric     | meters    | River length                                                 |
|                           | count_unique_trash                         | integer     |           | Sum of all trash counted on this river exept ... ?           |
|                           | count_trash                                | integer     |           | Sum of all trash counted on this river                       |
| bi.trajectory_point       | id                                         |             |           |                                                              |
|                           | the_geom                                   |             |           | Segment corresponding to the monitoring                      |
|                           | id_ref_campaign_fk                         | foreign key |           | Campaign ID                                                  |
|                           | elevation                                  | numeric     | meters    | Elevation given for each track point of the campaign         |
|                           | distance                                   | numeric     | meters    | Distance between track points ???                            |
|                           | time_diff                                  | numeric     | seconds   | Time difference between track points ???                     |
|                           | speed                                      | numeric     | m/s       | Speed between track points                                   |
|                           | lat                                        | numeric     |           | Latitude for each track points                               |
|                           | lon                                        | numeric     |           | Longitude for each track points                              |
|                           | createdon                                  | date        |           | Date of the campaign ?                                       |
| bi.trajectory_point_river | id                                         |             |           |                                                              |
|                           | id_ref_trajectory_point_fk                 | foreign key |           | ID of trajectory point                                       |
|                           | id_ref_campaign_fk                         | foreign key |           | Campaign ID                                                  |
|                           | id_ref_river_fk                            | foreign key |           | River ID                                                     |
|                           | trajectory_point_the_geom                  |             |           | Segment corresponding to the monitoring projected on river   |
|                           | river_the_geom                             |             |           | Segment/track of river                                       |
|                           | closest_point_the_geom                     |             |           | For a given trajectory point of a campaign, the closest point on a river segment |
|                           | distance_river_trajectory_point            |             |           | Distance between trajectory point and closest point on a river segment |
|                           | projection_trajectory_point_river_the_geom |             |           | ???                                                          |
|                           | importance                                 | integer     |           | [Classic stream order](https://en.wikipedia.org/wiki/Stream_order#Classic_stream_order) |
|                           | river_name                                 | text        |           | River name                                                   |
|                           | createdon                                  | date        |           | Date of the campaign ???                                     |
| bi.trash                  | id                                         |             |           |                                                              |
|                           | id_ref_campaign_fk                         | foreign key |           | Campaign ID                                                  |
|                           | the_geom                                   |             |           | GPS coordinates for each trash                               |
|                           | elevation                                  | numeric     | meters    | Elevation for each trash represented by a GPS point          |
|                           | id_ref_trash_type_fk                       | foreign key |           | Trash type ID                                                |
|                           | precision                                  | numeric     | meters    | Precision of GPS                                             |
|                           | id_ref_model_fk                            | foreign key |           | ID that indicates AI version used together with BI scripts version |
|                           | id_ref_image_fk                            | foreign key |           | Image ID                                                     |
|                           | time                                       | date        |           | Date of the campaign                                         |
|                           | createdon                                  | date        |           | ???                                                          |
|                           | frame_2_box                                | list        |           | Give the number of frames on which the same trash is observed. This field looks like - Frame2box = {1: [200, 230, 402, 450], 3: [200, 240, 300, 345]} |
|                           | lon                                        | numeric     |           | Longitude of each trash                                      |
|                           | lat                                        | numeric     |           | Latitude of each trash                                       |
|                           | municipality_code                          | integer     |           | Municipality on which the trash was detected                 |
|                           | municipality_name                          | text        |           | Municipality on which the trash was detected                 |
|                           | department_code                            | integer     |           | Department on which the trash was detected                   |
|                           | department_name                            | text        |           | Department on which the trash was detected                   |
|                           | state_code                                 | integer     |           | State on which the trash was detected                        |
|                           | state_name                                 | text        |           | State on which the trash was detected                        |
|                           | country_code                               | integer     |           | Country on which the trash was detected                      |
|                           | country_name                               | text        |           | Country on which the trash was detected                      |
|                           | distance_to_sea                            | numeric     | meters    | Distance between a given trash and the estuary               |
|                           | path_to_sea_the_geom                       |             |           | Segment of river between a given trash and the estuary       |
| bi.trash_river            | id                                         |             |           |                                                              |
|                           | id_ref_trash_fk                            | foreign key |           | Trash ID                                                     |
|                           | id_ref_campaign_fk                         | foreign key |           | Campaign ID                                                  |
|                           | id_ref_river_fk                            | foreign key |           | River ID                                                     |
|                           | trash_the_geom                             |             |           | GPS coordinates for each trash                               |
|                           | river_the_geom                             |             |           | Segment/track of river                                       |
|                           | closest_point_the_geom                     |             |           | For a given trash point of a campaign, the closest point on a river segment |
|                           | distance_river_trash                       |             |           | Distance between a trash and the closest point on a river segment |
|                           | projection_trash_river_the_geom            |             |           |                                                              |
|                           | importance                                 | integer     |           | [Classic stream order](https://en.wikipedia.org/wiki/Stream_order#Classic_stream_order) |
|                           | river_name                                 | text        |           | River name                                                   |
|                           | createdon                                  | date        |           | ???                                                          |
| bi.trash_type             | id                                         |             |           |                                                              |
|                           | name                                       | text        |           | Trash types currently used by AI model                       |
| bi.user                   | id_ref_user_fk                             |             |           | ID user                                                      |
|                           | nickname                                   | text        |           | User Nickname                                                |
|                           | trash_count                                | integer     |           | Total number of trash observed/detected by a user            |
|                           | total_distance                             | numeric     | meters    | Total distance traveled by a given user                      |
|                           | total_duration                             | numeric     | seconds ? | Total duration of monitoring for a given user                |
|                           | lastloggedon                               | date        |           | Last login of a given user                                   |
