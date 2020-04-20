INSERT INTO referential.country (the_geom, code, name, createdon)
SELECT
	st_union(st_setsrid(ST_Force2D(geometry), 2154)),
	'FR',
	'France',
	current_timestamp
FROM
	raw_data.region;

drop index if exists referential.country_the_geom;
create index country_the_geom on referential.country using gist(the_geom);

drop index if exists referential.country_code;
create index country_code on referential.country (code);
----------------------------------------------------------------------------------------------------------------------------------

INSERT INTO referential.state (the_geom, code, name, id_source, id_ref_country_fk, createdon)
SELECT
	st_setsrid(ST_Force2D(geometry), 2154),
	insee_reg,
	nom_reg,
	r.id,
	c.id,
	current_timestamp
FROM
	raw_data.region r
INNER JOIN referential.country c on c.code = 'FR'
;

drop index if exists referential.state_the_geom;
create index state_the_geom on referential.state using gist(the_geom);

drop index if exists referential.state_code;
create index state_code on referential.state (code);
----------------------------------------------------------------------------------------------------------------------------------

INSERT INTO referential.department (the_geom, code, name, id_source, id_ref_state_fk, createdon)
SELECT
	st_setsrid(ST_Force2D(geometry), 2154),
	insee_dep,
	nom_dep,
	d.id,
	r.id,
	current_timestamp
FROM
	raw_data.departement d
INNER JOIN referential.state r ON r.code = d.insee_reg
;

drop index if exists referential_department_the_geom;
create index referential_department_the_geom on referential.department using gist(the_geom);

drop index if exists referential_department_code;
create index referential_department_code on referential.department (code);
----------------------------------------------------------------------------------------------------------------------------------

INSERT INTO referential.municipality (the_geom, code, name, id_source, id_ref_department_fk, createdon)
SELECT
	st_setsrid(ST_Force2D(geometry), 2154),
	insee_com,
	nom_com,
	c.id,
	r.id,
	current_timestamp
FROM
	raw_data.commune c
INNER JOIN referential.department r ON r.code = c.insee_dep
;

drop index if exists referential.municipality_code;
create index municipality_code on referential.municipality (code);

drop index if exists referential.municipality_the_geom;
create index municipality_the_geom on referential.municipality using gist(the_geom);
----------------------------------------------------------------------------------------------------------------------------------

INSERT INTO referential.river (the_geom, code, nature, origine, code_hydro, id_ref_country_fk, importance, name, bras, createdon)
SELECT
	st_setsrid(ST_Force2D(th.geometry), 2154),
	th.id,
	th.nature,
	th.origine,
	th.code_hydro,
	c.id,
	ce.importance::int,
	th.nom_c_eau,
	th.bras,
	current_timestamp
FROM
	raw_data.troncon_hydrographique th
INNER JOIN referential.country c on c.code = th.code_pays
LEFT join raw_data.cours_d_eau  ce on ce.id = th.id_c_eau
;

drop index if exists referential.river_the_geom;
create index river_the_geom on referential.river using gist(the_geom);

drop index if exists referential.river_importance;
create index river_importance on referential.river (importance);

drop index if exists referential.river_name;
create index river_name on referential.river (name);


------------------------------------------------------------------------------------------------------------------------

INSERT INTO referential.limits_land_sea (the_geom, id_ref_country_fk, createdon)
SELECT
	st_setsrid(ST_Force2D(geometry), 2154),
	c.id,
	current_timestamp
FROM
	raw_data.limite_terre_mer ltm
INNER JOIN referential.country c on c.code = ltm.code_pays
;

drop index if exists referential.limits_land_sea_the_geom;
create index limits_land_sea_the_geom on referential.limits_land_sea using gist(the_geom);

------------------------------------------------------------------------------------------------------------------------