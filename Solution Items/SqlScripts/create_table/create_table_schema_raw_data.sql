-- SCHEMA RAW_DATA

-- detai hydrographique
DROP TABLE IF EXISTS raw_data.detail_hydrographique;
CREATE TABLE raw_data.detail_hydrographique (id text,nature text,nat_detail text,toponyme text,statut_top text,importance text,etat text,date_creat text,date_maj text,date_app text,date_conf text,source text,id_source text,prec_plani text,geometry geometry);

--epci
DROP TABLE IF EXISTS raw_data.epci;
CREATE TABLE raw_data.epci (id text,code_epci text,nom_epci text,type_epci text,geometry geometry);

-- bassin versant topographique
DROP TABLE IF EXISTS raw_data.bassin_versant_topographique;
CREATE TABLE raw_data.bassin_versant_topographique (id text,code_hydro text,toponyme text,bass_hydro text,date_creat text,date_maj text,date_app text,date_conf text,source text,id_source text,prec_plani text,src_coord text,statut text,b_fluvial text,origine text,comment text,code_bh text,code_carth text,id_c_eau text,geometry geometry);

-- troncon hydrographique
DROP TABLE IF EXISTS raw_data.troncon_hydrographique;
CREATE TABLE raw_data.troncon_hydrographique (id text,code_hydro text,code_pays text,nature text,fictif text,pos_sol text,etat text,date_creat text,date_maj text,date_app text,date_conf text,source text,id_source text,prec_plani text,prec_alti text,src_coord text,src_alti text,statut text,persistanc text,fosse text,navigabl text,salinite text,num_ordre text,cla_ordre text,origine text,per_ordre text,sens_ecoul text,res_coulan text,delimit text,largeur text,bras text,comment text,code_carth text,id_c_eau text,id_s_hydro text,id_ent_tr text,nom_c_eau text,nom_ent_tr text,geometry geometry);

-- department
DROP TABLE IF EXISTS raw_data.departement;
CREATE TABLE raw_data.departement (id text,nom_dep text,insee_dep text,insee_reg text,geometry geometry);

-- surface_hydrographique
DROP TABLE IF EXISTS raw_data.surface_hydrographique;
CREATE TABLE raw_data.surface_hydrographique (id text,code_hydro text,code_pays text,nature text,pos_sol text,etat text,date_creat text,date_maj text,date_app text,date_conf text,source text,id_source text,prec_plani text,prec_alti text,src_coord text,src_alti text,statut text,persistanc text,salinite text,origine text,comment text,id_p_eau text,id_c_eau text,id_ent_tr text,nom_p_eau text,nom_c_eau text,nom_ent_tr text,geometry geometry);

-- limite terre mer
DROP TABLE IF EXISTS raw_data.limite_terre_mer;
CREATE TABLE raw_data.limite_terre_mer (id text,code_hydro text,code_pays text,type_limit text,niveau text,date_creat text,date_maj text,date_app text,date_conf text,source text,id_source text,prec_plani text,src_coord text,statut text,origine text,comment text,geometry geometry);

-- arrondissement departemental
DROP TABLE IF EXISTS raw_data.arrondissement_departemental;
CREATE TABLE raw_data.arrondissement_departemental (id text,insee_arr text,insee_dep text,insee_reg text,geometry geometry);

-- region
DROP TABLE IF EXISTS raw_data.region;
CREATE TABLE raw_data.region (id text,nom_reg text,insee_reg text,geometry geometry);

-- commune
DROP TABLE IF EXISTS raw_data.commune;
CREATE TABLE raw_data.commune (id text,statut text,insee_com text,nom_com text,insee_arr text,nom_dep text,insee_dep text,nom_reg text,insee_reg text,code_epci text,nom_com_m text,population text,geometry geometry);

-- chef lieu
DROP TABLE IF EXISTS raw_data.chef_lieu;
CREATE TABLE raw_data.chef_lieu (id text,nom_chf text,statut text,insee_com text,geometry geometry);

-- plan d eau
DROP TABLE IF EXISTS raw_data.plan_d_eau;
CREATE TABLE raw_data.plan_d_eau (id text,code_hydro text,nature text,toponyme text,statut_top text,importance text,date_creat text,date_maj text,date_app text,date_conf text,source text,id_source text,statut text,maree text,permanent text,z_moy text,ref_z_moy text,mode_z_moy text,prec_z_moy text,haut_max text,obt_ht_max text,comment text,geometry geometry);

-- toponymie hydrographique
DROP TABLE IF EXISTS raw_data.toponymie_hydrographie;
CREATE TABLE raw_data.toponymie_hydrographie (id text,classe text,nature text,graphie text,source text,statut_top text,date_top text,geometry geometry);

-- noeud hydrographique
DROP TABLE IF EXISTS raw_data.noeud_hydrographique;
CREATE TABLE raw_data.noeud_hydrographique (id text,code_hydro text,code_pays text,categorie text,toponyme text,statut_top text,date_creat text,date_maj text,date_app text,date_conf text,source text,id_source text,prec_plani text,prec_alti text,src_coord text,src_alti text,statut text,comment text,id_ce_amon text,id_ce_aval text,geometry geometry);

-- courd d'eau
DROP TABLE IF EXISTS raw_data.cours_d_eau;
CREATE TABLE raw_data.cours_d_eau (id text,code_hydro text,toponyme text,statut_top text,importance text,date_creat text,date_maj text,date_app text,date_conf text,source text,id_source text,statut text,maree text,permanent text,comment text,geometry geometry);

-- trash
DROP TABLE IF EXISTS raw_data.trash;
CREATE TABLE raw_data.trash (elevation float, latitude float,longitude float,object text,time text,file text,campaign_id float,locomotion text,method text,riverside text,river text,user_first_name text,user_last_name text);

-- traces
DROP TABLE IF EXISTS raw_data.traces;
CREATE TABLE raw_data.traces (elevation float, latitude float,longitude float,time text,file text,campaign_id float,locomotion text,method text,riverside text,river text,user_first_name text,user_last_name text);


UPDATE  raw_data.trash set user_first_name = 'jérôme ' WHERE user_first_name = 'jérome';
UPDATE  raw_data.traces set user_first_name = 'jérôme' WHERE user_first_name = 'jérome';


alter table raw_data.trash add the_geom geometry ;
update raw_data.trash set the_geom = ST_SETSRID(ST_TRANSFORM(ST_SETSRID(ST_MAKEPOINT(longitude, latitude), 4326), 2154), 2154);


-- update tables
UPDATE    raw_data.troncon_hydrographique SET geometry=st_setsrid(geometry, 2154);
UPDATE    raw_data.departement SET geometry=st_setsrid(geometry, 2154);
UPDATE    raw_data.region SET geometry=st_setsrid(geometry, 2154);
UPDATE    raw_data.limite_terre_mer SET geometry=st_setsrid(geometry, 2154);
UPDATE    raw_data.noeud_hydrographique SET geometry=st_setsrid(geometry, 2154);
UPDATE    raw_data.cours_d_eau SET geometry=st_setsrid(geometry, 2154);


-- create index
drop index if exists raw_data_troncon_hydrographique_geometry;
create index raw_data_troncon_hydrographique_geometry on raw_data.troncon_hydrographique using GIST(geometry);

drop index if exists raw_data_departement_geometry;
create index raw_data_departement_geometry on raw_data.departement using GIST(geometry);

drop index if exists raw_data_region_geometry;
create index raw_data_region_geometry on raw_data.region using GIST(geometry);

drop index if exists raw_data_limite_terre_mer_geometry;
create index raw_data_limite_terre_mer_geometry on raw_data.limite_terre_mer using GIST(geometry);

drop index if exists raw_data_noeud_hydrographique_geometry;
create index raw_data_noeud_hydrographique_geometry on raw_data.noeud_hydrographique using GIST(geometry);

drop index if exists raw_data_cours_d_eau_geometry;
create index raw_data_cours_d_eau_geometry on raw_data.cours_d_eau using GIST(geometry); 
