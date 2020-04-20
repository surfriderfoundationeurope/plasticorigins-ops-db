--------------------------------------------------------------------------------
INSERT INTO campaign.user (
	firstname,
	lastname,
	email,
	emailconfirmed,
	passwordhash,
	yearofbirth,
	experience,
	isdeleted,
	createdon)
SELECT
DISTINCT ON (user_first_name, user_last_name)
	user_first_name,
	user_last_name,
	'fake@gmail.com',
	true,
	'kdjkdsjs',
	'01/02/2000'::date,
	'advanced',
	TRUE,
	current_timestamp
FROM
raw_data.trash  t

WHERE t.user_first_name is not null
;

drop index if exists campaign.user_firstname;
create index user_firstname on campaign.user (firstname);

drop index if exists campaign.user_lastname;
create index user_lastname on campaign.user (lastname);

--------------------------------------------------------------------------------

INSERT INTO campaign.campaign (locomotion, remark, id_ref_user_fk, riverside, isaidriven, blob_name,  createdon)
SELECT

	distinct on (t."file")
	locomotion,
	'river: '||river || ' riverside: ' || riverside,
	uc.id,
	riverside,
	FALSE,
	t."file",
	current_timestamp
FROM
	raw_data.traces t

INNER JOIN  campaign.user  uc ON uc.firstname = t.user_first_name and uc.lastname = t.user_last_name
;

drop index if exists campaign.campaign_id;
create index campaign_id on campaign.campaign (id);
--------------------------------------------------------------------------------

INSERT INTO campaign.trajectory_point (the_geom, id_ref_campaign_fk,elevation, time, distance, time_diff, createdon)
WITH CTE AS(
SELECT
	st_setsrid(st_transform(st_setsrid(st_makepoint(longitude, latitude), 4326), 2154), 2154) the_geom,
	c.id id_ref_campaign_fk,
	elevation,
	left(time, 19)::timestamp "time"

FROM
	raw_data.traces t

INNER JOIN campaign.campaign c ON c.blob_name = t.file
)
  SELECT
	*,
	st_distance(the_geom, lag(the_geom) over( partition by id_ref_campaign_fk order by time asc )),
	age("time", lag("time") over( partition by id_ref_campaign_fk order by time asc )),
	current_timestamp

	FROM
		cte
;

--------------------------------------------------------------------------------

DROP INDEX IF EXISTS campaign.trajectory_point_the_geom;
CREATE INDEX trajectory_point_the_geom ON campaign.trajectory_point USING gist(the_geom);

--------------------------------------------------------------------------------

INSERT INTO campaign.trash_type(type)
SELECT
DISTINCT object
FROM raw_data.trash t
;

--------------------------------------------------------------------------------

INSERT INTO campaign.trash (id_ref_campaign_fk, the_geom, elevation,  time, id_ref_trash_type_fk)

SELECT
	c.id,
	st_setsrid(st_transform(st_setsrid(st_makepoint(longitude, latitude), 4326), 2154), 2154),
	elevation,
	left(time, 19)::timestamp,
	tt.id

FROM
	raw_data.trash t

INNER JOIN campaign.trash_type tt on tt.type = t.object
INNER JOIN campaign.user uc on t.user_last_name = uc.lastname and t.user_first_name = uc.firstname
INNER JOIN campaign.campaign c on c.id_ref_user_fk = uc.id and c.blob_name = t.file ;


drop index if exists campaign.trash_the_geom;
create index trash_the_geom on campaign.trash using gist(the_geom);
