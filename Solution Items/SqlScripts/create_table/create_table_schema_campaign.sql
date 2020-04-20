drop table if exists campaign.user cascade;
create table campaign.user (
	id uuid PRIMARY key default uuid_generate_v4(),
	firstname text NULL,
	lastname text NULL,
	email text NOT NULL,
	emailconfirmed bool NOT NULL,
	passwordhash text NULL,
	yearofbirth date NULL,
	experience text NULL,
	isdeleted bool NOT null,
	createdon timestamp,
	UNIQUE(firstname, lastname) -- must use email?
);
----------------------------------------------------------------------------------------------------------------------------------
drop table if exists campaign.campaign cascade;
create table if not exists campaign.campaign (
	id uuid PRIMARY key DEFAULT uuid_generate_v4(),
	locomotion text NOT NULL,
	isaidriven bool,
	remark text NULL,
	id_ref_user_fk uuid references campaign.user(id),
	riverside text,
	container_url text,
	blob_name text,
	id_ref_model_fk 		uuid references campaign.model(id) ,
	createdon                timestamp
);
----------------------------------------------------------------------------------------------------------------------------------
drop table if exists campaign.model cascade;
create table campaign.model (

	id uuid primary key default uuid_generate_v4(),
	version integer,
	createdon timestamp
);
----------------------------------------------------------------------------------------------------------------------------------
drop table if exists campaign.trajectory_point cascade;
create table if not exists campaign.trajectory_point (

	id uuid not null primary key default uuid_generate_v4(),
	the_geom geometry CONSTRAINT enforce_srid_geom    CHECK (st_srid(the_geom) = 2154),
	id_ref_campaign_fk uuid not null references campaign.campaign(id),
	elevation float,
	distance float,
	time_diff interval,
	time timestamp,
	speed float,
	lat float,
	lon float,
	createdon timestamp

);
----------------------------------------------------------------------------------------------------------------------------------
DROP TABLE IF EXISTS campaign.image cascade;
CREATE TABLE  campaign.image(
	id uuid  PRIMARY KEY,
	filename text NOT NULL,
	blobname text NOT NULL,
	containerurl text NOT NULL,
	createdby text NOT NULL,
	isdeleted bit NOT null,
	version integer not null,
	id_ref_campaign_fk uuid references campaign.campaign(id),
  id_ref_trajectory_points_fk uuid references campaign.trajectory_point(id),
  time timestamp,
	createdon timestamp
);

----------------------------------------------------------------------------------------------------------------------------------
drop table if exists campaign.trash_type CASCADE;
CREATE TABLE campaign.trash_type (
   id  SERIAL PRIMARY KEY,
   type TEXT unique,
   brand text
);
----------------------------------------------------------------------------------------------------------------------------------
DROP TABLE IF EXISTS campaign.trash CASCADE;
CREATE TABLE campaign.trash (
	id 						uuid not null primary key default uuid_generate_v4(),
	id_ref_campaign_fk 		uuid NOT null references campaign.campaign(id),
	the_geom geometry CONSTRAINT enforce_srid_geom    CHECK (st_srid(the_geom) = 2154),
	elevation 				float,
	id_ref_trash_type_fk 	int NOT null references campaign.trash_type(id) ,
	precision 				double precision NULL,
	id_ref_model_fk 		uuid references campaign.model(id) ,
	brand_type 				text NULL,
	id_ref_image_fk 		uuid references campaign.image(id),
	time					timestamp,
	lat                     float,
	lon                     float,
	createdon 				timestamp

);