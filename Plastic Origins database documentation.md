<h1 align="left">Plastic Origins database documentation</h1>

<a href="https://www.plasticorigins.eu/"><img width="110px" src="https://github.com/surfriderfoundationeurope/The-Plastic-Origins-Project/blob/master/assets/PlasticOrigins_logo.png" width="50%" height="50%" align="left" hspace="0" vspace="0"></a>

  <p align="justify">Plastico is a sample open source object-relational PostgreSQL database of the <a href="https://github.com/surfriderfoundationeurope/The-Plastic-Origins-Project">Surfrider Plastic Origins project</a>.</p>

| | |
|:-|:-|
|**Host** | pgdb-plastico-prod-fras.postgres.database.azure.com |
|**Database** | plastico-prod |
| **DBMS**| PostgreSQL|

This is a documentation of this database created in [DBeaver Community](https://dbeaver.io/).

## Campaign Schema

Campaign schema holds information about the campaigns and their media, trajectory points of monitoring, data about trash, model of used AI and users who have collected the data.

<details>
<summary markdown="span">`campaign` ER Diagram</summary>

<p align="left">
   <img src="assets/[Plastico DB] campaign schema ERD.png" width="80%" height="80%">
 </p>

</details>

<details>
<summary markdown="span">`campaign` Tables</summary>

<details>
<summary markdown="span">Table `campaign.campaign`</summary>

| Column Name                               | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :---------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                        | uuid        |           |           | Generated ID                                                 |
| locomotion                                | text        |           | API       | How the data was collected (by foot, kayak, drone, etc.)     |
| isaidriven                                | bool        |yes/no     | API       | Whether wastes have been detected and counted using AI or observed by human observators |
| remark                                    | text        |           | API       | Remarks sent by users after data collection                  |
| id_ref_user_fk                            | uuid        |foreign key| API       | ID of the user who has collected the data                    |
| riverside                                 | text        |right/left | API       | River bank monitored (either right or left). The right river bank is at your right when looking downstream. |
| id_ref_model_fk                           | uuid        |foreign key|           | ID that indicates AI version used together with BI scripts version |
| createdon                                 | timestamp   |           | ETL       | Info to be extracted from video or GPX                       |
| has_been_computed                         | bool        |true/false |           |                                                              |

</details>

<details>
<summary markdown="span">Table `campaign.media`</summary>
  
| Column Name                               | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :---------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                        | uuid        |           |           | Generated ID                                                 |
| filename                                  | text        |           | API       | Name (given or generated) of the file (mp4, json, jpeg, jpg) |
| createdby                                 | text        |           |           | Information about file's creator (given or generated)        |
| isdeleted                                 | bit         |           |           |                                                              |
| id_ref_campaign_fk                        | uuid        |foreign key|           | Campaign ID                                                  |
| id_ref_trajectory_points_fk               | uuid        |           |           | Note: should it be removed?                                  |
| time                                      | timestamp   |           |           |                                                              |
| createdon                                 | timestamp   |           |           | Note: Is it useful because already in campaign.campaign?     |
| blob_url                                  | varchar     |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `campaign.model`</summary>
  
<!---Note: potentially to be removed - to confirm with Christophe --->

| Column Name                               | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :---------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                        | uuid        |           |           | Generated ID                                                   |
| version                                   | int4        |           | Manually  | Updated manually when we decide to upgrade to a new AI version |
| createdon                                 | timestamp   |           | Manually  | Updated manually when we decide to upgrade to a new AI version |

</details>

<details>
<summary markdown="span">Table `campaign.trajectory_point`</summary>

| Column Name                               | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :---------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                        | uuid        |           |           | Generated ID                                                 |
| the_geom                                  | geometry    |           |           | GPS coordinates for segment corresponding to the monitoring  |
| id_ref_campaign_fk                        | uuid        |foreign key|           | Campaign ID                                                  |
| elevation                                 | float8      |numeric (meters)| ETL  | Elevation given for each track point of the campaign (Note: Is it really necessary?)|
| time                                      | timestamp   |           | ETL       |                                                              |
| speed                                     | float8      |numeric (m/s)|         | Speed between track points (Note: This is calculated data, right?) |
| lat                                       | float8      |numeric    |           | Latitude for each track points                               |
| lon                                       | float8      |numeric    |           | Longitude for each track points                              |
| createdon                                 | timestamp   |           |           | Note: Is it useful because already in campaign.campaign?     |

</details>

<details>
<summary markdown="span">Table `campaign.trash`</summary>

| Column Name                               | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :---------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                        | uuid        |           |           | Generated ID                                                 |
| id_ref_campaign_fk                        | uuid        |foreign key|           | Campaign ID                                                  |
| the_geom                                  | geometry    |           |           | GPS coordinates for each trash                               |
| elevation                                 | float8      |numeric (meters)| ETL  | Elevation for each trash represented by a GPS point (Note: Is it really necessary?)|
| id_ref_trash_type_fk                      | int4        |foreign key|           | Trash type ID                                                |
| precision                                 | float8      |numeric (meters)| ETL  | Precision of GPS                                             |
| id_ref_model_fk                           | uuid        |foreign key|           | ID that indicates AI version used together with BI scripts version |
| id_ref_image_fk                           | uuid        |foreign key|           | Image ID (Note: This field becomes if_ref_media_fk???)       |
| time                                      | timestamp   |           | ETL       |                                                              |
| createdon                                 | timestamp   |           |           | Note: Is it useful because already in campaign.campaign?     |
| frame_2_box                               | json        |list       | ETL       | Given the number of frames on which the same trash is observed. This field looks like - Frame2box = {1: [200, 230, 402, 450], 3: [200, 240, 300, 345]} |

</details>

<details>
<summary markdown="span">Table `campaign.trash_type`</summary>

| Column Name                               | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :---------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                        | serial      |           |           | Generated ID                                                 |
| name                                      | text        |           | Manually  | Trash type name (Note: Need to add trash type of AI and manual version) |

</details>

<details>
<summary markdown="span">Table `campaign.user`</summary>

| Column Name                               | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :---------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                        | uuid        |           |           | Generated ID                                                 |
| firstname                                 | text        |           | API       | User first name                                              |
| lastname                                  | text        |           | API       | User last name                                               |
| email                                     | text        |           | API       | User email                                                   |
| emailconfirmed                            | bool        |           |           | User email confirmation                                      |
| passwordhash                              | text        |           | API       | User password                                                |
| yearofbirth                               | date        |           | API       | User year of birth                                           |
| experience                                | text        |           | Manually  | User experience (advance etc.)                               |
| isdeleted                                 | bool        |           |           |                                                              |
| createdon                                 | timestamp   |           | API       | Timestamp of a given user creation                           |
| lastloggedon                              | timestamp   |           | API       | Timestamp of the last login of a given user                  |                                                          |
| nickname                                  | text        |           | bi???     | User Nickname                                                |

</details>
</details>

## BI Schema

BI schema holds aggregated data about the campaigns and tracked rivers.

<details>
<summary markdown="span">`bi` ER Diagram</summary>

<p align="left">
   <img src="assets/[Plastico DB] bi schema ERD.png" width="100%" height="100%">
 </p>

</details>

<details>
<summary markdown="span">`bi` Tables</summary>

<details>
<summary markdown="span">Table `bi.campaign`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | uuid        |           |           | Generated ID                                                 |
| locomotion                                 | text        |           | API       | How the data was collected (by foot, kayak, drone, etc.)     |
| isaidriven                                 | bool        |yes/no     | API       | Whether wastes have been detected and counted using AI or observed by human observators |
| remark                                     | text        |           | API       | Remarks sent by users after data collection                  |
| id_ref_user_fk                             | uuid        |foreign key| API       | ID of the user who has collected the data                    |
| riverside                                  | text        |right/left | API       | River bank monitored (either right or left). The right river bank is at your right when looking downstream. |
| start_date                                 | date        |           |           | Start date and time of the campaign                          |
| end_date                                   | date        |           |           | End date and time of the campaign                            |
| start_point                                | geometry    |list ?     |           | Lat/Lon where the campaign has started                       |
| end_point                                  | geometry    |list ?     |           | Lat/Lon where the campaign has ended                         |
| total_distance                             | float8      |numeric (meters)|      | Distance traveled during the campaign (projected on river segment) |
| avg_speed                                  | int4        |numeric (m/s)|         | Average displacement speed during the campaign               |
| duration                                   | interval    |numeric (seconds?)|    | Duration of the campaign                                     |
| start_point_distance_sea                   | float8      |numeric (meters)|      | Distance from the start point of the campaign to the river estuary |
| end_point_distance_sea                     | float8      |numeric (meters)|      | Distance from the end point of the campaign to the river estuary |
| trash_count                                | int4        |integer    |           | Number of trash counted during the campaign                  |
| distance_start_end                         | float8      |numeric (meters)|      | Distance traveled during the campaign (real distance traveled including zigzags if any) |
| id_re_model_fk                             | uuid        |foreign key|           | ID that indicates AI version used together with BI scripts version |
| createdon                                  | date        |           |           | Date of the campaign                                         |

</details>

<details>
<summary markdown="span">Table `bi.campaign_river`</summary>
	
| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | int4        |           |           | Generated ID                                                 |
| id_ref_campaign_fk                         | uuid        |foreign key|           | Campaign ID                                                  |
| river_name                                 | text        |           |           | River name                                                   |
| distance                                   | numeric     | meters    |           | Distance monitored on each river                             |
| the_geom                                   | geometry    |           |           | GPS coordinates for river segment/track                      |
| createdon                                  | timestamp   |date       |           |                                                              |		
| id_ref_river_fk                            | int4        |foreign key|           | River ID                                                     |	
| trash_count                            | int4        |integer|           | River ID                                                     |	
| trash_per_km                            | int4        |numeric|           | River ID                                                     |	
| disabled                            | int4        |yes/no|           | Script that disabled campaign with poor quality data                                                    |	

</details>

<details>
<summary markdown="span">Table `bi.river`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| name                                       | text        |           |           | River name                                                   |
| the_geom                                   | geometry    |           |           | GPS coordinates for river segment/track                      |
| length                                     | float8      |numeric (meters)|      | River length                                                 |
| count_unique_trash                         | float8      |integer    |           | Sum of all trash counted on this river exept ... ?           |
| count_trash                                | float8      |integer    |           | Sum of all trash counted on this river                       |
| distance_monitored                         | float8      |           |           | Monitored distance                                           |
| the_geom_monitored                         | geometry    |           |           | GPS coordinates for monitored distance                       |
| trash_per_km                               | numeric     |           |           |                                                              |
| id                                         | serial      |           |           | Generated ID                                                 |

</details>

<details>
<summary markdown="span">Table `bi.trajectory_point`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | uuid        |           |           | Generated ID                                                 |
| the_geom                                   | geometry    |           |           | Segment corresponding to the monitoring                      |
| id_ref_campaign_fk                         | uuid        |foreign key|           | Campaign ID                                                  |
| elevation                                  | float8      |numeric (meters)|      | Elevation given for each track point of the campaign         |
| distance                                   | float8      |numeric (meters)|      | Distance between track points ???                            |
| time_diff                                  | interval    |numeric (seconds)|     | Time difference between track points ???                     |
| time                                       | timestamp   |           |           |                                                              |
| speed                                      | float8      |numeric (m/s)|         | Speed between track points                                   |
| lat                                        | float8      |numeric    |           | Latitude for each track points                               |
| lon                                        | float8      |numeric    |           | Longitude for each track points                              |
| createdon                                  | timestamp   |date       |           | Date of the campaign ?                                       |

</details>

<details>
<summary markdown="span">Table `bi.trajectory_point_river`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | int4        |           |           | Generated ID                                                 |
| id_ref_trajectory_point_fk                 | uuid        |foreign key|           | ID of trajectory point                                       |
| id_ref_campaign_fk                         | uuid        |foreign key|           | Campaign ID                                                  |
| id_ref_river_fk                            | int4        |foreign key|           | River ID                                                     |
| trajectory_point_the_geom                  | geometry    |           |           | Segment corresponding to the monitoring projected on river   |
| river_the_geom                             | geometry    |           |           | Segment/track of river                                       |
| closest_point_the_geom                     | geometry    |           |           | For a given trajectory point of a campaign, the closest point on a river segment |
| distance_river_trajectory_point            | float8      |           |           | Distance between trajectory point and closest point on a river segment |
| projection_trajectory_point_river_the_geom | geometry    |           |           |                                                              |
| importance                                 | int4        |integer    |           | [Classic stream order](https://en.wikipedia.org/wiki/Stream_order#Classic_stream_order) |
| river_name                                 | text        |           |           | River name                                                   |
| createdon                                  | timestamp   |date       |           | Date of the campaign ???                                     |

</details>

<details>
<summary markdown="span">Table `bi.trash`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | uuid        |           |           | Generated ID                                                 |
| id_ref_campaign_fk                         | uuid        |foreign key|           | Campaign ID                                                  |
| the_geom                                   | geometry    |           |           | GPS coordinates for each trash                               |
| elevation                                  | float8      |numeric (meters)| ETL  | Elevation for each trash represented by a GPS point          |
| id_ref_trash_type_fk                       | int4        |foreign key|           | Trash type ID                                                |
| precision                                  | float8      |numeric (meters)| ETL  | Precision of GPS                                             |
| id_ref_model_fk                            | uuid        |foreign key|           | ID that indicates AI version used together with BI scripts version |
| id_ref_image_fk                            | uuid        |foreign key|           | Image ID                                                     |
| time                                       | timestamp   |date       |           | Date of the campaign                                         |
| createdon                                  | timestamp   |date       |           |                                                              |
| frame_2_box                                | json        |list       | ETL       | Give the number of frames on which the same trash is observed. This field looks like - Frame2box = {1: [200, 230, 402, 450], 3: [200, 240, 300, 345]} |
| lon                                        | float8      |numeric    |           | Longitude of each trash                                      |
| lat                                        | float8      |numeric    |           | Latitude of each trash                                       |
| municipality_code                          | text        | integer   |           | Municipality on which the trash was detected                 |
| municipality_name                          | text        |           |           | Municipality on which the trash was detected                 |
| department_code                            | text        | integer   |           | Department on which the trash was detected                   |
| department_name                            | text        |           |           | Department on which the trash was detected                   |
| state_code                                 | text        | integer   |           | State on which the trash was detected                        |
| state_name                                 | text        |           |           | State on which the trash was detected                        |
| country_code                               | text        | integer   |           | Country on which the trash was detected                      |
| country_name                               | text        |           |           | Country on which the trash was detected                      |

</details>

<details>
<summary markdown="span">Table `bi.trash_for_arcgis`</summary>

<ArcGIS is a geographic information system for working with maps and geographic information maintained by the Environmental Systems Research Institute.>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | int8        |           |           |                                                              |
| trash_type                                 | text        |           |           |                                                              |
| id_campaign                                | uuid        |           |           |                                                              |
| user_nickname                              | text        |           |           |                                                              |
| locomotion_mode                            | text        |           |           | How the data was collected (by foot, kayak, drone, etc.)     |
| river_side                                 | text        |           |           |                                                              |
| river_name                                 | text        |           |           |                                                              |
| ai_driven                                  | bool        |           |           |                                                              |
| detection_date                             | timestamp   |           |           |                                                              |
| latitude                                   | float8      |numeric    |           |                                                              |
| longitude                                  | float8      |numeric    |           |                                                              |
| altitude                                   | float8      |numeric    |           |                                                              |
| municipality_name                          | text        |           |           | Municipality on which the trash was detected                 |
| municipality_code                          | text        | integer   |           | Municipality on which the trash was detected                 |
| province_name                              | text        |           |           | Province on which the trash was detected                     |
| province_code                              | text        | integer   |           | Province on which the trash was detected                     |
| country_code                               | text        | integer   |           | Country on which the trash was detected                      |
| country_name                               | text        |           |           | Country on which the trash was detected                      |

</details>

<details>
<summary markdown="span">Table `bi.trash_river`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | int4        |           |           | Generated ID                                                 |
| id_ref_trash_fk                            | uuid        |foreign key|           | Trash ID                                                     |
| id_ref_campaign_fk                         | uuid        |foreign key|           | Campaign ID                                                  |
| id_ref_river_fk                            | int4        |foreign key|           | River ID                                                     |
| trash_the_geom                             | geometry    |           |           | GPS coordinates for each trash                               |
| river_the_geom                             | geometry    |           |           | GPS coordinates for a segment/track of river                 |
| closest_point_the_geom                     | geometry    |           |           | For a given trash point of a campaign, the closest point on a river segment |
| distance_river_trash                       | float8      |           |           | Distance between a trash and the closest point on a river segment |
| projection_trash_river_the_geom            | geometry    |           |           |                                                              |
| importance                                 | int4        |integer    |           | [Classic stream order](https://en.wikipedia.org/wiki/Stream_order#Classic_stream_order) |
| river_name                                 | text        |           |           | River name                                                   |
| createdon                                  | timestamp   | date      |           |                                                              |

</details>

<details>
<summary markdown="span">Table `bi.trash_type`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | int4        |           |           | Generated ID                                                 |
| name                                       | text        |           |           | Name of trash types currently used by AI model               |

</details>

<details>
<summary markdown="span">Table `bi.user`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id_ref_user_fk                             | uuid        |foreign key| API       | ID of the user who has collected the data                    |
| nickname                                   | text        |           |           | User Nickname                                                |
| trash_count                                | int8        |integer    |           | Total number of trash observed/detected by a user            |
| total_distance                             | float8      |numeric (meters)|      | Total distance traveled by a given user                      |
| total_duration                             | interval    |numeric (seconds)|     | Total duration of monitoring for a given user                |
| lastloggedon                               | timestamp   | date      |           | Timestamp of the last login of a given user                  |

</details>
</details>

## BI_temp Schema

BI_temp schema is used as a temporary store of BI data ( for testing before actual update of BI data). 

<details>
<summary markdown="span">`bi_temp` ER Diagram</summary>

<p align="left">
   <img src="assets/[Plastico DB] bi_temp schema ERD.png" width="100%" height="100%">
 </p>

</details>

<details>
<summary markdown="span">`bi_temp` Tables</summary>

<details>
<summary markdown="span">Table `bi_temp.campaign`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | uuid        |           |           | Generated ID                                                 |
| locomotion                                 | text        |           | API       | How the data was collected (by foot, kayak, drone, etc.)     |
| isaidriven                                 | bool        |yes/no     | API       | Whether wastes have been detected and counted using AI or observed by human observators |
| remark                                     | text        |           | API       | Remarks sent by users after data collection                  |
| id_ref_user_fk                             | uuid        |foreign key|           | ID of the user who has collected the data                    |
| riverside                                  | text        |right/left | API       | River bank monitored (either right or left). The right river bank is at your right when looking downstream. |
| start_date                                 | date        |           |           | Start date and time of the campaign                          |
| end_date                                   | date        |           |           | End date and time of the campaign                            |
| start_point                                | geometry    |list ?     |           | Lat/Lon where the campaign has started                       |
| end_point                                  | geometry    |list ?     |           | Lat/Lon where the campaign has ended                         |
| total_distance                             | float8      |numeric (meters)|      | Distance traveled during the campaign (projected on river segment) |
| avg_speed                                  | int4        |numeric (m/s)|         | Average displacement speed during the campaign               |
| duration                                   | interval    |numeric (seconds?)|    | Duration of the campaign                                     |
| start_point_distance_sea                   | float8      |numeric (meters)|      | Distance from the start point of the campaign to the river estuary |
| end_point_distance_sea                     | float8      |numeric (meters)|      | Distance from the end point of the campaign to the river estuary |
| trash_count                                | int4        |integer    |           | Number of trash counted during the campaign                  |
| distance_start_end                         | float8      |numeric (meters)|      | Distance traveled during the campaign (real distance traveled including zigzags if any) |
| id_re_model_fk                             | uuid        |foreign key|           | ID that indicates AI version used together with BI scripts version |
| createdon                                  | date        |           |           | Date of the campaign                                         |
| pipeline_id                                | uuid        |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `bi_temp.campaign_river`</summary>
	
| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | serial      |           |           | Generated ID                                                 |
| id_ref_campaign_fk                         | uuid        |foreign key|           | Campaign ID                                                  |
| river_name                                 | text        |           |           | River name                                                   |
| id_ref_river_fk                            | int4        |foreign key|           | River ID                                                     |	
| distance                                   | numeric     | meters    |           | Distance monitored on each river                             |
| the_geom                                   | geometry    |           |           | GPS coordinates for a segment/track of river                 |
| createdon                                  | timestamp   |date       |           |                                                              |			
| pipeline_id                                | uuid        |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `bi_temp.pipelines`</summary>
	
| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | uuid        |           |           | Generated ID                                                 |
| campaign_id                                | uuid        |           |           | Campaign ID ? Note: Is it id_ref_campaign_fk ?               |
| campaign_has_been_computed                 | bool        |           |           |                                                              |
| river_has_been_computed                    | bool        |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `bi_temp.river`</summary>
	
| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| name                                       | text        |           |           | River name                                                   |
| the_geom                                   | geometry    |           |           | River segment/track                                          |
| length                                     | float8      |numeric (meters)|      | River length                                                 |
| count_unique_trash                         | float8      |integer    |           | Sum of all trash counted on this river exept ... ?           |
| count_trash                                | float8      |integer    |           | Sum of all trash counted on this river                       |
| distance_monitored                         | float8      |           |           | Monitored distance                                           |
| the_geom_monitored                         | geometry    |           |           | GPS coordinates for monitored distance                       |
| trash_per_km                               | numeric     |           |           |                                                              |
| id                                         | int4        |           |           | Generated ID                                                 |

</details>

<details>
<summary markdown="span">Table `bi_temp.trajectory_point`</summary>
	
| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | uuid        |           |           | Generated ID                                                 |
| the_geom                                   | geometry    |           |           | Segment corresponding to the monitoring                      |
| id_ref_campaign_fk                         | uuid        |foreign key|           | Campaign ID                                                  |
| elevation                                  | numeric     |meters     |           | Elevation given for each track point of the campaign         |
| distance                                   | numeric     |meters     |           | Distance between track points ???                            |
| time_diff                                  | interval    |numeric (seconds)|     | Time difference between track points ???                     |
| time                                       | timestamp   |           |           |                                                              |
| speed                                      | numeric     |m/s        |           | Speed between track points                                   |
| lat                                        | numeric     |           |           | Latitude for each track points                               |
| lon                                        | numeric     |           |           | Longitude for each track points                              |
| createdon                                  | timestamp   |date       |           | Date of the campaign ?                                       |
| pipeline_id                                | uuid        |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `bi_temp.trajectory_point_river`</summary>
	
| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | serial      |           |           | Generated ID                                                 |
| id_ref_trajectory_point_fk                 | uuid        |foreign key|           | ID of trajectory point                                       |
| id_ref_campaign_fk                         | uuid        |foreign key|           | Campaign ID                                                  |
| id_ref_river_fk                            | int4        |foreign key|           | River ID                                                     |
| trajectory_point_the_geom                  | geometry    |           |           | Segment corresponding to the monitoring projected on river   |
| river_the_geom                             | geometry    |           |           | Segment/track of river                                       |
| closest_point_the_geom                     | geometry    |           |           | For a given trajectory point of a campaign, the closest point on a river segment |
| distance_river_trajectory_point            | float8      |           |           | Distance between trajectory point and closest point on a river segment |
| projection_trajectory_point_river_the_geom | geometry    |           |           |                                                              |
| importance                                 | int4        |integer    |           | [Classic stream order](https://en.wikipedia.org/wiki/Stream_order#Classic_stream_order) |
| river_name                                 | text        |           |           | River name                                                   |
| createdon                                  | timestamp   |date       |           | Date of the campaign ???                                     |
| pipeline_id                                | uuid        |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `bi_temp.trash`</summary>
	
| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | uuid        |           |           | Generated ID                                                 |
| id_ref_campaign_fk                         | uuid        |foreign key|           | Campaign ID                                                  |
| the_geom                                   | geometry    |           |           | GPS coordinates for each trash                               |
| elevation                                  | float8      |numeric (meters)|      | Elevation for each trash represented by a GPS point          |
| id_ref_trash_type_fk                       | int4        |foreign key|           | Trash type ID                                                |
| precision                                  | float8      |numeric (meters)|      | Precision of GPS                                             |
| id_ref_model_fk                            | uuid        |foreign key|           | ID that indicates AI version used together with BI scripts version |
| brand_type                                 | text        |           |           |                                                              |
| id_ref_media_fk                            | _text       |           |           |                                                              |
| time                                       | timestamp   |date       |           | Date of the campaign                                         |
| lat                                        | float8      |numeric    |           | Latitude of each trash                                       |
| lon                                        | float8      |numeric    |           | Longitude of each trash                                      |
| municipality_code                          | text        | integer   |           | Code of municipality on which the trash was detected         |
| municipality_name                          | text        |           |           | Name of municipality on which the trash was detected         |
| department_code                            | text        | integer   |           | Code of department on which the trash was detected           |
| department_name                            | text        |           |           | Name of department on which the trash was detected           |
| state_code                                 | text        | integer   |           | Code of state on which the trash was detected                |
| state_name                                 | text        |           |           | Name of state on which the trash was detected                |
| country_code                               | text        | integer   |           | Code of country on which the trash was detected              |
| country_name                               | text        |           |           | Name of country on which the trash was detected              |
| createdon                                  | timestamp   |date       |           |                                                              |
| pipeline_id                                | uuid        |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `bi_temp.trash_river`</summary>
	
| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | serial      |           |           | Generated ID                                                 |
| id_ref_trash_fk                            | uuid        |foreign key|           | Trash ID                                                     |
| id_ref_campaign_fk                         | uuid        |foreign key|           | Campaign ID                                                  |
| id_ref_river_fk                            | int4        |foreign key|           | River ID                                                     |
| trash_the_geom                             | geometry    |           |           | GPS coordinates for each trash                               |
| river_the_geom                             | geometry    |           |           | Segment/track of river                                       |
| closest_point_the_geom                     | geometry    |           |           | For a given trash point of a campaign, the closest point on a river segment |
| distance_river_trash                       | float8      |           |           | Distance between a trash and the closest point on a river segment |
| projection_trash_river_the_geom            | geometry    |           |           |                                                              |
| importance                                 | int4        |integer    |           | [Classic stream order](https://en.wikipedia.org/wiki/Stream_order#Classic_stream_order) |
| river_name                                 | text        |           |           | River name                                                   |
| createdon                                  | timestamp   | date      |           |                                                              |
| pipeline_id                                | uuid        |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `bi_temp.trash_type`</summary>
	
| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | int4        |           |           | Generated ID                                                 |
| name                                       | text        |           |           | Name of the trash types currently used by AI model           |

</details>

<details>
<summary markdown="span">Table `bi_temp.user`</summary>
	
| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | uuid        |           |           | Generated ID                                                 |
| nickname                                   | text        |           |           | User Nickname                                                |
| trash_count                                | int4        |integer    |           | Total number of trash observed/detected by a user            |
| total_distance                             | numeric     |meters     |           | Total distance traveled by a given user                      |
| total_duration                             | numeric     |seconds    |           | Total duration of monitoring for a given user                |
| lastloggedon                               | timestamp   | date      |           | Last login of a given user                                   |
| createdon                                  | timestamp   | date      |           |                                                              |	

</details>
</details>
 
## CMS Schema

CMS schema holds information about the Plastic Origins website.

<details>
<summary markdown="span">`cms` ER Diagram</summary>

<p align="left">
   <img src="assets/[Plastico DB] cms schema ERD.png" width="15%" height="15%">
 </p>

</details>

<details>
<summary markdown="span">`cms` Tables</summary>

<details>
<summary markdown="span">Table `cms.tutorials`</summary>

| Column Name                               | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :---------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                        | int4        |           |           | Generated ID                                                 |
| tutorial_name                             | text        |           |           |                                                              |

</details>
</details>

## Label Schema

Label schema holds information about the bounding boxes of the images for labelling.

<details>
<summary markdown="span">`label` ER Diagram</summary>

<p align="left">
   <img src="assets/[Plastico DB] label schema ERD.png" width="35%" height="35%">
 </p>

</details>

<details>
<summary markdown="span">`label` Tables</summary>  

<details>
<summary markdown="span">Table `label.bounding_boxes`</summary>

| Column Name                               | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :---------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                        | uuid        |           |           | Generated ID                                                 |
| id_creator_fk                             | uuid        |           |           |                   |
| createdon                                 | timestamp   |           |           |                   |
| id_ref_trash_type_fk                      | int4        |foreign key|           | Trash type ID                                                |
| id_ref_images_for_labelling               | uuid        |           |           |                   |
| location_x                                | int4        |           |           |                   |
| location_y                                | int4        |           |           |                   |
| width                                     | int4        |           |           |                   |
| height                                    | int4        |           |           |                   |

</details>

<details>
<summary markdown="span">Table `label.images_for_labelling`</summary>

| Column Name                               | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :---------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                        | uuid        |           |           | Generated ID                                                 |
| id_creator_fk                             | uuid        |           |           |                   |
| createdon                                 | timestamp   |           |           |                   |
| filename                                  | text        |           | API       | Name (given or generated) of the file (mp4, json, jpeg, jpg) |
| view                                      | text        |           |           |                   |
| image_quality                             | text        |           |           |                   |
| context                                   | text        |           |           |                   |
| container_url                             | text        |           |           |                   |
| blob_name                                 | text        |           |           |                   |

</details>
</details>

## Logs Schema

Logs schema holds information about the status (success /fails) of BI and  ETL processes.

<details>
<summary markdown="span">`logs` ER Diagram</summary>

<p align="left">
   <img src="assets/[Plastico DB] logs schema ERD.png" width="25%" height="25%">
 </p>

</details>

<details>
<summary markdown="span">`logs` Tables</summary>  

<details>
<summary markdown="span">Table `logs.bi`</summary>

| Column Name                               | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :---------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                        | uuid        |           |           | Generated ID                                                 |
| campaign_id                               | uuid        |           |           | Campaign ID ? Note: Is it id_ref_campaign_fk ?               |
| initiated_on                              | date        |           |           |                   |
| finished_on                               | date        |           |           |                   |
| elapsed_time                              | float8      |           |           |                   |
| status                                    | text        |           |           |                   |
| reason                                    | text        |           |           |                   |
| script_version                            | text        |           |           |                   |
| failed_step                               | text        |           |           |                   |

</details>

<details>
<summary markdown="span">Table `logs.etl`</summary>

| Column Name                               | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :---------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                        | uuid        |           |           |                   |
| campaign_id                               | uuid        |           |           | Campaign ID ? Note: Is it id_ref_campaign_fk ?               |
| media_id                                  | uuid        |           |           |                   |
| media_name                                | text        |           |           |                   |
| initiated_on                              | date        |           |           |                   |
| finished_on                               | date        |           |           |                   |
| elapsed_time                              | float8      |           |           |                   |
| status                                    | text        |           |           |                   |
| reason                                    | text        |           |           |                   |
| script_version                            | text        |           |           |                   |

</details>
</details>

## Public Schema

Public schema is used for testing purposes.

<details>
<summary markdown="span">`public` ER Diagram</summary>

<p align="left">
   <img src="assets/[Plastico DB] public schema ERD.png" width="100%" height="100%">
 </p>

</details>

<details>
<summary markdown="span">`public` Tables</summary>  

<details>
<summary markdown="span">Table `public.__EFMigrationsHistory`</summary>

| Column Name                               | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :---------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| MigrationId                               | varchar     |           |           |                   |
| ProductVersion                            | varchar     |           |           |                   |

</details>

<details>
<summary markdown="span">Table `public.bi_river`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| name                                       | text        |           |           | River name                                                   |
| the_geom                                   | geometry    |           |           | River segment/track                                          |
| length                                     | float8      |numeric (meters)|      | River length                                                 |
| count_unique_trash                         | float8      |integer    |           | Sum of all trash counted on this river exept ... ?           |
| count_trash                                | float8      |integer    |           | Sum of all trash counted on this river                       |
| distance_monitored                         | float8      |           |           | Monitored distance                                           |
| the_geom_monitored                         | geometry    |           |           | GPS coordinates for monitored distance                       |
| trash_per_km                               | numeric     |           |           |                                                              |
| id                                         | int4        |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `public.ecrin_ecrgaz_spatial_ref_sys`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| index                                      | int8        |           |           |                                                              |
| srid                                       | int8        |           |           |                                                              |
| auth_name                                  | text        |           |           |                                                              |
| auth_srid                                  | int8        |           |           |                                                              |
| ref_sys_name                               | text        |           |           |                                                              |
| proj4text                                  | text        |           |           |                                                              |
| srs_wkt                                    | text        |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `public.referential_river`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | int4        |           |           |                   |
| the_geom                                   | geometry    |           |           |                   |
| code                                       | text        |           |           |                   |
| name                                       | text        |           |           |                   |
| nature                                     | text        |           |           |                   |
| importance                                 | int4        |           |           |                   |
| origine                                    | text        |           |           |                   |
| code_hydro                                 | text        |           |           |                   |
| id_ref_country_fk                          | int4        |           |           |                   |
| bras                                       | text        |           |           |                   |
| createdon                                  | timestamp   |           |           |                   |

</details>

<details>
<summary markdown="span">Table `public.referential_river_api`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | int4        |           |           |                   |
| the_geom                                   | geometry    |           |           |                   |
| code                                       | text        |           |           |                   |
| name                                       | text        |           |           |                   |
| nature                                     | text        |           |           |                   |
| importance                                 | int4        |           |           |                   |
| origine                                    | text        |           |           |                   |
| code_hydro                                 | text        |           |           |                   |
| id_ref_country_fk                          | int4        |           |           |                   |
| bras                                       | text        |           |           |                   |
| createdon                                  | timestamp   |           |           |                   |

</details>


<details>
<summary markdown="span">Table `public.river`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | int4        |           |           |                   |
| the_geom                                   | geometry    |           |           |                   |
| code                                       | text        |           |           |                   |
| name                                       | text        |           |           |                   |
| nature                                     | text        |           |           |                   |
| importance                                 | int4        |           |           |                   |
| origine                                    | text        |           |           |                   |
| code_hydro                                 | text        |           |           |                   |
| id_ref_country_fk                          | int4        |           |           |                   |
| bras                                       | text        |           |           |                   |
| createdon                                  | timestamp   |           |           |                   |

</details>

<details>
<summary markdown="span">Table `public.spatial_ref_sys`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| srid                                       | int4        |           |           |                                                              |
| auth_name                                  | varchar     |           |           |                                                              |
| auth_srid                                  | int4        |           |           |                                                              |
| srtext                                     | varchar     |           |           |                                                              |
| proj4text                                  | varchar     |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `public.test_ma_table`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| colonne                                    | int4        |           |           |                                                              |

</details>
</details>

## Raw_data Schema

Raw_data schema is used for testing purposes.

<details>
<summary markdown="span">`raw_data` ER Diagram</summary>

<p align="left">
   <img src="assets/[Plastico DB] raw_data schema ERD.png" width="100%" height="100%">
 </p>

</details>

<details>
<summary markdown="span">`raw_data` Tables</summary>  

<details>
<summary markdown="span">Table `raw_data.arrondissement_departemental`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | text        |           |           |                                                              |
| insee_arr                                  | text        |           |           |                                                              |
| insee_dep                                  | text        |           |           |                                                              |
| insee_reg                                  | text        |           |           |                                                              |
| geometry                                   | geometry    |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `raw_data.bassin_versant_topographique`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | text        |           |           |                                                              |
| code_hydro                                 | text        |           |           |                                                              |
| toponyme                                   | text        |           |           |                                                              |
| bass_hydro                                 | text        |           |           |                                                              |
| date_creat                                 | text        |           |           |                                                              |
| date_maj                                   | text        |           |           |                                                              |
| date_app                                   | text        |           |           |                                                              |
| date_conf                                  | text        |           |           |                                                              |
| source                                     | text        |           |           |                                                              |
| id_source                                  | text        |           |           |                                                              |
| prec_plani                                 | text        |           |           |                                                              |
| src_coord                                  | text        |           |           |                                                              |
| statut                                     | text        |           |           |                                                              |
| b_fluvial                                  | text        |           |           |                                                              |
| origine                                    | text        |           |           |                                                              |
| comment                                    | text        |           |           |                                                              |
| code_bh                                    | text        |           |           |                                                              |
| code_carth                                 | text        |           |           |                                                              |
| id_c_eau                                   | text        |           |           |                                                              |
| geometry                                   | geometry    |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `raw_data.chef_lieu`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | text        |           |           |                                                              |
| nom_chf                                    | text        |           |           |                                                              |
| statut                                     | text        |           |           |                                                              |
| insee_com                                  | text        |           |           |                                                              |
| geometry                                   | geometry    |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `raw_data.commune`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | text        |           |           |                                                              |
| statut                                     | text        |           |           |                                                              |
| insee_com                                  | text        |           |           |                                                              |
| nom_com                                    | text        |           |           |                                                              |
| insee_arr                                  | text        |           |           |                                                              |
| nom_dep                                    | text        |           |           |                                                              |
| insee_dep                                  | text        |           |           |                                                              |
| nom_reg                                    | text        |           |           |                                                              |
| insee_reg                                  | text        |           |           |                                                              |
| code_epci                                  | text        |           |           |                                                              |
| nom_com_m                                  | text        |           |           |                                                              |
| population                                 | text        |           |           |                                                              |
| geometry                                   | geometry    |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `raw_data.cours_d_eau`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | text        |           |           |                                                              |
| code_hydro                                 | text        |           |           |                                                              |
| toponyme                                   | text        |           |           |                                                              |
| statut_top                                 | text        |           |           |                                                              |
| importance                                 | text        |           |           |                                                              |
| date_creat                                 | text        |           |           |                                                              |
| date_maj                                   | text        |           |           |                                                              |
| date_app                                   | text        |           |           |                                                              |
| date_conf                                  | text        |           |           |                                                              |
| source                                     | text        |           |           |                                                              |
| id_source                                  | text        |           |           |                                                              |
| statut                                     | text        |           |           |                                                              |
| maree                                      | text        |           |           |                                                              |
| permanent                                  | text        |           |           |                                                              |
| comment                                    | text        |           |           |                                                              |
| geometry                                   | geometry    |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `raw_data.departement`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | text        |           |           |                                                              |
| nom_dep                                    | text        |           |           |                                                              |
| insee_dep                                  | text        |           |           |                                                              |
| insee_reg                                  | text        |           |           |                                                              |
| geometry                                   | geometry    |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `raw_data.detail_hydrographique`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | text        |           |           |                                                              |
| nature                                     | text        |           |           |                                                              |
| nat_detail                                 | text        |           |           |                                                              |
| toponyme                                   | text        |           |           |                                                              |
| statut_top                                 | text        |           |           |                                                              |
| importance                                 | text        |           |           |                                                              |
| etat                                       | text        |           |           |                                                              |
| date_creat                                 | text        |           |           |                                                              |
| date_maj                                   | text        |           |           |                                                              |
| date_app                                   | text        |           |           |                                                              |
| date_conf                                  | text        |           |           |                                                              |
| source                                     | text        |           |           |                                                              |
| id_source                                  | text        |           |           |                                                              |
| prec_plani                                 | text        |           |           |                                                              |
| geometry                                   | geometry    |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `raw_data.epci`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | text        |           |           |                                                              |
| code_epci                                  | text        |           |           |                                                              |
| nom_epci                                   | text        |           |           |                                                              |
| type_epci                                  | text        |           |           |                                                              |
| geometry                                   | geometry    |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `raw_data.limite_terre_mer`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | text        |           |           |                                                              |
| code_hydro                                 | text        |           |           |                                                              |
| code_pays                                  | text        |           |           |                                                              |
| type_limit                                 | text        |           |           |                                                              |
| niveau                                     | text        |           |           |                                                              |
| date_creat                                 | text        |           |           |                                                              |
| date_maj                                   | text        |           |           |                                                              |
| date_app                                   | text        |           |           |                                                              |
| date_conf                                  | text        |           |           |                                                              |
| source                                     | text        |           |           |                                                              |
| id_source                                  | text        |           |           |                                                              |
| prec_plani                                 | text        |           |           |                                                              |
| src_coord                                  | text        |           |           |                                                              |
| statut                                     | text        |           |           |                                                              |
| origine                                    | text        |           |           |                                                              |
| comment                                    | text        |           |           |                                                              |
| geometry                                   | geometry    |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `raw_data.noeud_hydrographique`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | text        |           |           |                                                              |
| code_hydro                                 | text        |           |           |                                                              |
| code_pays                                  | text        |           |           |                                                              |
| categorie                                  | text        |           |           |                                                              |
| toponyme                                   | text        |           |           |                                                              |
| statut_top                                 | text        |           |           |                                                              |
| date_creat                                 | text        |           |           |                                                              |
| date_maj                                   | text        |           |           |                                                              |
| date_app                                   | text        |           |           |                                                              |
| date_conf                                  | text        |           |           |                                                              |
| source                                     | text        |           |           |                                                              |
| id_source                                  | text        |           |           |                                                              |
| prec_plani                                 | text        |           |           |                                                              |
| prec_alti                                  | text        |           |           |                                                              |
| src_coord                                  | text        |           |           |                                                              |
| src_alti                                   | text        |           |           |                                                              |
| statut                                     | text        |           |           |                                                              |
| comment                                    | text        |           |           |                                                              |
| id_ce_amon                                 | text        |           |           |                                                              |
| id_ce_aval                                 | text        |           |           |                                                              |
| geometry                                   | geometry    |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `raw_data.plan_d_eau`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | text        |           |           |                                                              |
| code_hydro                                 | text        |           |           |                                                              |
| nature                                     | text        |           |           |                                                              |
| toponyme                                   | text        |           |           |                                                              |
| statut_top                                 | text        |           |           |                                                              |
| importance                                 | text        |           |           |                                                              |
| date_creat                                 | text        |           |           |                                                              |
| date_maj                                   | text        |           |           |                                                              |
| date_app                                   | text        |           |           |                                                              |
| date_conf                                  | text        |           |           |                                                              |
| source                                     | text        |           |           |                                                              |
| id_source                                  | text        |           |           |                                                              |
| statut                                     | text        |           |           |                                                              |
| maree                                      | text        |           |           |                                                              |
| permanent                                  | text        |           |           |                                                              |
| z_moy                                      | text        |           |           |                                                              |
| ref_z_moy                                  | text        |           |           |                                                              |
| mode_z_moy                                 | text        |           |           |                                                              |
| prec_z_moy                                 | text        |           |           |                                                              |
| haut_max                                   | text        |           |           |                                                              |
| obt_ht_max                                 | text        |           |           |                                                              |
| comment                                    | text        |           |           |                                                              |
| geometry                                   | geometry    |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `raw_data.region`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | text        |           |           |                                                              |
| nom_reg                                    | text        |           |           |                                                              |
| insee_reg                                  | text        |           |           |                                                              |
| geometry                                   | geometry    |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `raw_data.surface_hydrographique`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | text        |           |           |                                                              |
| code_hydro                                 | text        |           |           |                                                              |
| code_pays                                  | text        |           |           |                                                              |
| nature                                     | text        |           |           |                                                              |
| pos_sol                                    | text        |           |           |                                                              |
| etat                                       | text        |           |           |                                                              |
| date_creat                                 | text        |           |           |                                                              |
| date_maj                                   | text        |           |           |                                                              |
| date_app                                   | text        |           |           |                                                              |
| date_conf                                  | text        |           |           |                                                              |
| source                                     | text        |           |           |                                                              |
| id_source                                  | text        |           |           |                                                              |
| prec_plani                                 | text        |           |           |                                                              |
| prec_alti                                  | text        |           |           |                                                              |
| src_coord                                  | text        |           |           |                                                              |
| src_alti                                   | text        |           |           |                                                              |
| statut                                     | text        |           |           |                                                              |
| persistanc                                 | text        |           |           |                                                              |
| salinite                                   | text        |           |           |                                                              |
| origine                                    | text        |           |           |                                                              |
| comment                                    | text        |           |           |                                                              |
| id_p_eau                                   | text        |           |           |                                                              |
| id_c_eau                                   | text        |           |           |                                                              |
| id_ent_tr                                  | text        |           |           |                                                              |
| nom_p_eau                                  | text        |           |           |                                                              |
| nom_c_eau                                  | text        |           |           |                                                              |
| nom_ent_tr                                 | text        |           |           |                                                              |
| geometry                                   | geometry    |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `raw_data.toponymie_hydrographie`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | text        |           |           |                                                              |
| classe                                     | text        |           |           |                                                              |
| nature                                     | text        |           |           |                                                              |
| graphie                                    | text        |           |           |                                                              |
| source                                     | text        |           |           |                                                              |
| statut_top                                 | text        |           |           |                                                              |
| date_top                                   | text        |           |           |                                                              |
| geometry                                   | geometry    |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `raw_data.traces`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| elevation                                  | float8      |           |           |                                                              |
| latitude                                   | float8      |           |           |                                                              |
| longitude                                  | float8      |           |           |                                                              |
| time                                       | text        |           |           |                                                              |
| file                                       | text        |           |           |                                                              |
| campaign_id                                | float8      |           |           |                                                              |
| locomotion                                 | text        |           | API       | How the data was collected (by foot, kayak, drone, etc.)     |
| method                                     | text        |           |           |                                                              |
| riverside                                  | text        |right/left | API       | River bank monitored (either right or left). The right river bank is at your right when looking downstream. |
| river                                      | text        |           |           |                                                              |
| user_first_name                            | text        |           |           |                                                              |
| user_last_name                             | text        |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `raw_data.trash`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| elevation                                  | float8      |           |           |                                                              |
| latitude                                   | float8      |           |           |                                                              |
| longitude                                  | float8      |           |           |                                                              |
| object                                     | text        |           |           |                                                              |
| time                                       | text        |           |           |                                                              |
| file                                       | text        |           |           |                                                              |
| campaign_id                                | float8      |           |           |                                                              |
| locomotion                                 | text        |           | API       | How the data was collected (by foot, kayak, drone, etc.)     |
| method                                     | text        |           |           |                                                              |
| riverside                                  | text        |right/left | API       | River bank monitored (either right or left). The right river bank is at your right when looking downstream. |
| river                                      | text        |           |           |                                                              |
| user_first_name                            | text        |           |           |                                                              |
| user_last_name                             | text        |           |           |                                                              |
| the_geom                                   | geometry    |           |           |                                                              |
| object_type                                | text        |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `raw_data.troncon_hydrographique`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | text        |           |           |                                                              |
| code_hydro                                 | text        |           |           |                                                              |
| code_pays                                  | text        |           |           |                                                              |
| nature                                     | text        |           |           |                                                              |
| fictif                                     | text        |           |           |                                                              |
| pos_sol                                    | text        |           |           |                                                              |
| etat                                       | text        |           |           |                                                              |
| date_creat                                 | text        |           |           |                                                              |
| date_maj                                   | text        |           |           |                                                              |
| date_app                                   | text        |           |           |                                                              |
| date_conf                                  | text        |           |           |                                                              |
| source                                     | text        |           |           |                                                              |
| id_source                                  | text        |           |           |                                                              |
| prec_plani                                 | text        |           |           |                                                              |
| prec_alti                                  | text        |           |           |                                                              |
| src_coord                                  | text        |           |           |                                                              |
| src_alti                                   | text        |           |           |                                                              |
| statut                                     | text        |           |           |                                                              |
| persistanc                                 | text        |           |           |                                                              |
| fosse                                      | text        |           |           |                                                              |
| navigabl                                   | text        |           |           |                                                              |
| salinite                                   | text        |           |           |                                                              |
| num_ordre                                  | text        |           |           |                                                              |
| cla_ordre                                  | text        |           |           |                                                              |
| origine                                    | text        |           |           |                                                              |
| per_ordre                                  | text        |           |           |                                                              |
| sens_ecoul                                 | text        |           |           |                                                              |
| res_coulan                                 | text        |           |           |                                                              |
| delimit                                    | text        |           |           |                                                              |
| largeur                                    | text        |           |           |                                                              |
| bras                                       | text        |           |           |                                                              |
| comment                                    | text        |           |           |                                                              |
| code_carth                                 | text        |           |           |                                                              |
| id_c_eau                                   | text        |           |           |                                                              |
| id_s_hydro                                 | text        |           |           |                                                              |
| id_ent_tr                                  | text        |           |           |                                                              |
| nom_c_eau                                  | text        |           |           |                                                              |
| nom_ent_tr                                 | text        |           |           |                                                              |
| geometry                                   | geometry    |           |           |                                                              |

</details>
</details>

## Referential Schema

Referential schema holds information about the geographic location (municipality – department – state –  country) of tracked rivers and coastlines (the boundary between land and sea).

<details>
<summary markdown="span">`referential` ER Diagram</summary>

<p align="left">
   <img src="assets/[Plastico DB] referential schema ERD.png" width="50%" height="50%">
 </p>

</details>

<details>
<summary markdown="span">`referential` Tables</summary>  

<details>
<summary markdown="span">Table `referential.country`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | int4        |           |           | Generated ID                                                 |
| the_geom                                   | geometry    |           |           | GPS coordinates                                              |
| code	                                     | text        |           |           | ISO code of country (2 letters)                              |
| name	                                     | text        |           |           | Country name                                                             |
| createdon                                  | timestamp   |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `referential.department`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | int4        |           |           | Generated ID                                                 |
| the_geom                                   | geometry    |           |           | GPS coordinates                                              |
| code	                                     | text        |           |           | Department code                                              |
| name	                                     | text        |           |           | Department name                                              |                                                             |
| id_source                                  | text        |           |           |                                                              |
| id_ref_state_fk                            | int4        |           |           |                                                              |
| createdon                                  | timestamp   |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `referential.limits_land_sea`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | int4        |           |           | Generated ID                                                 |
| the_geom                                   | geometry    |           |           | GPS coordinates                                              |
| code	                                     | text        |           |           |                                                              |
| name	                                     | text        |           |           |                                                              |
| id_source                                  | text        |           |           |                                                              |
| nature                                     | text        |           |           |                                                              |
| origine                                    | text        |           |           |                                                              |
| code_hydro                                 | text        |           |           |                                                              |
| id_ref_country_fk                          | int4        |           |           |                                                              |
| createdon                                  | timestamp   |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `referential.municipality`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | int4        |           |           | Generated ID                                                 |
| the_geom                                   | geometry    |           |           | GPS coordinates                                              |
| code	                                     | text        |           |           | Municipality code                                            |
| name	                                     | text        |           |           | Municipality name                                            |
| id_source                                  | text        |           |           |                                                              |
| id_ref_department_fk                       | int4        |           |           |                                                              |
| createdon                                  | timestamp   |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `referential.river`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | int4        |           |           | Generated ID                                                 |
| the_geom                                   | geometry    |           |           | GPS coordinates                                              |
| code	                                     | text        |           |           |                                                              |
| name	                                     | text        |           |           |                                                              |
| nature                                     | text        |           |           |                                                              |
| importance                                 | int4        |           |           |                                                              |
| origine                                    | text        |           |           |                                                              |
| code_hydro                                 | text        |           |           |                                                              |
| id_ref_country_fk                          | int4        |           |           |                                                              |
| bras                                       | text        |           |           |                                                              |
| createdon                                  | timestamp   |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `referential.state`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | int4        |           |           | Generated ID                                                 |
| the_geom                                   | geometry    |           |           | GPS coordinates                                              |
| code	                                     | text        |           |           | State code                                                   |
| name	                                     | text        |           |           | State name                                                   |
| id_source                                  | text        |           |           |                                                              |
| id_ref_country_fk                          | int4        |           |           |                                                              |
| createdon                                  | timestamp   |           |           |                                                              |

</details>
</details>

## Referential_dev Schema

Referential_dev schema is used for testing purposes.

<details>
<summary markdown="span">`referential_dev` ER Diagram</summary>

<p align="left">
   <img src="assets/[Plastico DB] referential_dev schema ERD.png" width="100%" height="100%">
 </p>

</details>

<details>
<summary markdown="span">`referential_dev` Tables</summary>  

<details>
<summary markdown="span">Table `referential_dev.basin`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| basin_id                                   | text        |           |           |                                                              |
| geom	                                     | geometry    |           |           |                                                              |
| fec_count	                                 | int8        |           |           |                                                              |
| basin_name1	                             | text        |           |           |                                                              |
| basin_name2	                             | text        |           |           |                                                              |
| country_code1	                             | text        |           |           |                                                              |
| country_code2	                             | text        |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `referential_dev.basin_test`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| basin_id                                   | text        |           |           |                                                              |
| geom	                                     | geometry    |           |           |                                                              |
| fec_count	                                 | int8        |           |           |                                                              |
| basin_name1	                             | text        |           |           |                                                              |
| basin_name2	                             | text        |           |           |                                                              |
| country_code1	                             | text        |           |           |                                                              |
| country_code2	                             | text        |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `referential_dev.catchments`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| index                                      | int8        |           |           |                                                              |
| fec_id	                                 | text        |           |           |                                                              |
| basin_id   	                             | text        |           |           |                                                              |
| basin_name 	                             | text        |           |           |                                                              |
| country_code	                             | text        |           |           |                                                              |
| geom	                                     | geometry    |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `referential_dev.country`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | int8        |           |           |                                                              |
| the_geom                                   | geometry    |           |           |                                                              |
| code	                                     | text        |           |           |                                                              |
| name	                                     | text        |           |           |                                                              |
| createdon                                  | timestamp   |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `referential_dev.country_old`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| index                                      | int8        |           |           |                                                              |
| iso3_code                                  | text        |           |           |                                                              |
| name	                                     | text        |           |           |                                                              |
| french_name                                | text        |           |           |                                                              |
| region                                     | text        |           |           |                                                              |
| continent                                  | text        |           |           |                                                              |
| geom                                       | geometry    |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `referential_dev.ecrin_catchments`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| index                                      | int8        |           |           |                                                              |
| fec_id	                                 | text        |           |           |                                                              |
| basin_id   	                             | text        |           |           |                                                              |
| basin_name 	                             | text        |           |           |                                                              |
| country_code	                             | text        |           |           |                                                              |
| geom	                                     | geometry    |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `referential_dev.ecrin_nodes`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | int8        |           |           |                                                              |
| node_id                                    | text        |           |           |                                                              |
| node_type                                  | text        |           |           |                                                              |
| geom	                                     | geometry    |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `referential_dev.ecrin_nodes_segments`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| id                                         | int8        |           |           |                                                              |
| node_id                                    | text        |           |           |                                                              |
| downstream_segment_id                      | text        |           |           |                                                              |
| upstream_segment_id                        | text        |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `referential_dev.ecrin_referential_catchments`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| index                                      | int8        |           |           |                                                              |
| fec_id	                                 | text        |           |           |                                                              |
| basin_id   	                             | text        |           |           |                                                              |
| basin_name 	                             | text        |           |           |                                                              |
| country_code	                             | text        |           |           |                                                              |
| geom	                                     | geometry    |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `referential_dev.ecrin_segments`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| index                                      | int8        |           |           |                                                              |
| segement_id                                | text        |           |           |                                                              |
| river_id	                                 | text        |           |           |                                                              |
| river_class                                | int4        |           |           |                                                              |
| strahler_rank                              | int4        |           |           |                                                              |
| geom	                                     | geometry    |           |           |                                                              |
| segment_length                             | float8      |           |           |                                                              |
| river_name	                             | text        |           |           |                                                              |
| country_code	                             | text        |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `referential_dev.nodes`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| index                                      | int8        |           |           |                                                              |
| node_id                                    | text        |           |           |                                                              |
| node_type                                  | text        |           |           |                                                              |
| geom	                                     | geometry    |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `referential_dev.river`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| river_id	                                 | text        |           |           |                                                              |
| geom	                                     | geometry    |           |           |                                                              |
| river_length                               | float8      |           |           |                                                              |
| river_name	                             | text        |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `referential_dev.river_test`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| river_id	                                 | text        |           |           |                                                              |
| geom	                                     | geometry    |           |           |                                                              |
| river_length                               | float8      |           |           |                                                              |
| river_name	                             | text        |           |           |                                                              |

</details>

<details>
<summary markdown="span">Table `referential_dev.segments`</summary>

| Column Name                                | Data type   | Unit      | References (filled by) | Description &nbsp; |
| :----------------------------------------- | :---------- | :-------- | :-------- | :---------------- |
| index                                      | int8        |           |           |                                                              |
| segement_id                                | text        |           |           |                                                              |
| river_id	                                 | text        |           |           |                                                              |
| river_class                                | int4        |           |           |                                                              |
| strahler_rank                              | int4        |           |           |                                                              |
| geom	                                     | geometry    |           |           |                                                              |
| segment_length                             | float8      |           |           |                                                              |
| river_name	                             | text        |           |           |                                                              |
| country_code	                             | text        |           |           |                                                              |

</details>
</details>
