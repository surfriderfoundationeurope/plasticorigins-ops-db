drop table if exists referential.country cascade;
create table referential.country (id SERIAL primary key,
					 the_geom geometry not null,
					 code text unique, name text unique,
					 createdon timestamp
					);
----------------------------------------------------------------------------------------------------------------------------------
drop table if exists referential.state cascade;
create table referential.state (id SERIAL primary key,
					  the_geom geometry not null,
				    code text unique,
				   	name text unique,
				    id_source text,
				    id_ref_country_fk integer references referential.country(id),
				    createdon timestamp
				   );
----------------------------------------------------------------------------------------------------------------------------------
drop table if exists referential.department cascade;
create table referential.department (id SERIAL primary key,
						 the_geom geometry not null,
						 code text unique, name text unique,
						 id_source text,
						 id_ref_state_fk integer references referential.state(id),
					     createdon timestamp
						);
----------------------------------------------------------------------------------------------------------------------------------
drop table if exists referential.municipality cascade;
create table referential.municipality (id SERIAL primary key,
						   the_geom geometry not null,
						   code text unique, name text,
						   id_source text,
						   id_ref_department_fk integer references referential.department(id),
						   createdon timestamp

						   );
----------------------------------------------------------------------------------------------------------------------------------
drop table if exists referential.river CASCADE;
create table referential.river (id SERIAL primary key,
					the_geom geometry not null,
					code text,
					name text,
					nature text,
					importance integer,
					origine text,
					code_hydro text,
					id_ref_country_fk integer references referential.country(id),
					bras text,
					createdon timestamp
				);
----------------------------------------------------------------------------------------------------------------------------------
drop table if exists referential.limits_land_sea;
create table referential.limits_land_sea (id SERIAL primary key,
							  the_geom geometry not null,
							  code text, name text,
							  id_source text,
							  nature text,
							  origine text,
							  code_hydro text,
							  id_ref_country_fk integer references referential.country(id),
						   	  createdon timestamp
							 );
----------------------------------------------------------------------------------------------------------------------------------
--- INDEX CREATION
drop index if exists referential.limits_land_sea_the_geom;
create index limits_land_sea_the_geom on referential.limits_land_sea using gist(the_geom);

drop index if exists referential.river_the_geom;
create index river_the_geom on referential.river using gist(the_geom);

drop index if exists referential.municipality_code;
create index municipality_code on referential.municipality (code);

drop index if exists referential.municipality_the_geom;
create index municipality_the_geom on referential.municipality using gist(the_geom);

drop index if exists referential.state_the_geom;
create index state_the_geom on referential.state using gist(the_geom);

drop index if exists referential.state_code;
create index state_code on referential.state (code);

drop index if exists referential.department_the_geom;
create index department_the_geom on referential.department using gist(the_geom);

drop index if exists referential.department_code;
create index department_code on referential.department (code);

drop index if exists referential.country_the_geom;
create index country_the_geom on referential.country using gist(the_geom);

drop index if exists referential.country_code;
create index country_code on referential.country (code);