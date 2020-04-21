----------------------------------------------------------------------------------------------------------------------------------
drop table if exists bi.trash_river;
create table bi.trash_river (

						  id 						SERIAL primary key,
						  id_ref_trash_fk	 		uuid NOT null references campaign.trash(id) ,
						  id_ref_campaign_fk	 								uuid NOT null references campaign.campaign(id) ,
						  id_ref_river_fk 			int NOT null references referential.river(id) ,
						  trash_the_geom  			geometry not null,
						  river_the_geom  			geometry not null,
						  closest_point_the_geom 	geometry not null,
						  distance_river_trash   	float not null,
						  projection_trash_river_the_geom geometry not null,
						  importance 				integer,
						  river_name				text,
						  createdon 				timestamp

						  );

----------------------------------------------------------------------------------------------------------------------------------

drop table if exists bi.trajectory_point_river;
create table bi.trajectory_point_river (

						  id 											SERIAL primary key,
						  id_ref_trajectory_point_fk	 				uuid NOT null references campaign.trajectory_point(id) ,
						  id_ref_campaign_fk	 								uuid NOT null references campaign.campaign(id) ,
						  id_ref_river_fk 								int NOT null references referential.river(id) ,
						  trajectory_point_the_geom  					geometry not null,
						  river_the_geom  								geometry not null,
						  closest_point_the_geom 						geometry not null,
						  distance_river_trajectory_point   			float not null,
						  projection_trajectory_point_river_the_geom	geometry not null,
						  importance 									integer,
						  river_name										text,
						  createdon 									timestamp

						  );
----------------------------------------------------------------------------------------------------------------------------------
drop table if exists bi.campaign_river;
create table bi.campaign_river (

						  id 											SERIAL primary key,
						  id_ref_campaign_fk	 				        uuid NOT null references campaign.campaign(id) ,
						  id_ref_river_fk 								int NOT null references referential.river(id) ,
						  campaign_the_geom  	        				geometry not null,
						  river_the_geom  								geometry not null,
						  closest_point_the_geom 						geometry not null,
						  distance_river_campaign            			float not null,
						  projection_campaign_river_the_geom        	geometry not null,
						  importance 									integer,
						  createdon 									timestamp

						  );
*/
----------------------------------------------------------------------------------------------------------------------------------
drop table if exists bi.campaign cascade;
create table if not exists bi.campaign (

	id uuid PRIMARY key DEFAULT uuid_generate_v4(),
	id_ref_campaign_fk uuid references campaign.campaign(id),
	duration  interval,
	starting_point_the_geom geometry,
	ending_point_the_geom geometry,
	startdate timestamp,
	enddate   timestamp,
	distance_start_end float,
	total_distance float,
	avg_speed float,
    starting_point_lat float,
    starting_point_lon float,
    ending_point_lat float,
    ending_point_lon float,
	createdon timestamp

    );




/* Ajouter le script de la table campaign_river */
/* ajouter le script de la table river */