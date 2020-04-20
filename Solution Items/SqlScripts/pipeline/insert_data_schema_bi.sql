UPDATE bi.campaign c
SET startdate = min_time, enddate = max_time
FROM (SELECT id_ref_campaign_fk, min(time) min_time, max(time) max_time from campaign.trajectory_point group by id_ref_campaign_fk) tp
WHERE tp.id_ref_campaign_fk = c.id AND c.startdate IS NULL;
----------------------------------------------------------------------------------------------------------------------------------
UPDATE bi.campaign c SET duration = age(c.enddate, c.startdate) where duration is null;
----------------------------------------------------------------------------------------------------------------------------------
UPDATE  bi.campaign
SET starting_point_the_geom = t_start.the_geom
FROM campaign.trajectory_point t_start
WHERE t_start.id_ref_campaign_fk = campaign.id  AND campaign.startdate = t_start.time and campaign.starting_point_the_geom is null;
----------------------------------------------------------------------------------------------------------------------------------
UPDATE  bi.campaign
SET ending_point_the_geom = t_end.the_geom
FROM campaign.trajectory_point t_end
WHERE t_end.id_ref_campaign_fk = campaign.id  AND campaign.enddate = t_end.time and campaign.ending_point_the_geom is null;
----------------------------------------------------------------------------------------------------------------------------------
UPDATE bi.campaign c
SET distance_start_end = st_distance(c.starting_point_the_geom, ending_point_the_geom)
WHERE distance_start_end is null;
----------------------------------------------------------------------------------------------------------------------------------
UPDATE referential.trajectory_point
set speed = (distance/extract(epoch from time_diff))*3.6
where speed is null and extract(epoch from time_diff) > 0 and distance > 0;
----------------------------------------------------------------------------------------------------------------------------------
update bi.campaign
set avg_speed = agg_tp.avg_speed, total_distance = agg_tp.total_distance
from (
	select
		id_ref_campaign_fk,
		sum(distance) total_distance,
		avg(speed) avg_speed
	FROM referential.trajectory_point tp
	where distance > 0
	group by id_ref_campaign_fk
) agg_tp
where (campaign.avg_speed is null or campaign.total_distance is null) and campaign.id = agg_tp.id_ref_campaign_fk
;
----------------------------------------------------------------------------------------------------------------------------------
insert into bi.trash_river (id_ref_trash_fk, id_ref_river_fk, trash_the_geom, river_the_geom, distance_river_trash, projection_trash_river_the_geom, closest_point_the_geom, importance, createdon)
WITH subquery_1 AS (

SELECT
	t.id id_ref_trash_fk,
	closest_r.id id_ref_river_fk,
	t.the_geom trash_the_geom,
	closest_r.the_geom river_the_geom,
	st_closestpoint(closest_r.the_geom, t.the_geom) closest_point_the_geom,
	closest_r.importance

from
	campaign.trash t

inner join lateral (

	select
	*
	from
	referential.river r
	where name is not null

	order by r.the_geom <-> t.the_geom
	limit 1
	) closest_r on TRUE


)
SELECT
	id_ref_trash_fk,
	id_ref_river_fk,
	trash_the_geom,
	river_the_geom,
	st_distance(closest_point_the_geom, trash_the_geom) distance_river_trash,
	st_makeline(trash_the_geom, closest_point_the_geom) projection_trash_river_the_geom,
	closest_point_the_geom,
	importance,
	current_timestamp
FROM
	subquery_1;
----------------------------------------------------------------------------------------------------------------------------------
DROP INDEX IF EXISTS bi_trash_river_closest_point_the_geom;
CREATE INDEX bi_trash_river_closest_point_the_geom on bi.trash_river using gist(closest_point_the_geom);
----------------------------------------------------------------------------------------------------------------------------------
 ---> THIS QUERY MUST BE REPLACED BY LUCA SCRIPT
INSERT INTO bi.trajectory_point_river (id_ref_trajectory_point_fk, id_ref_river_fk, trajectory_point_the_geom, river_the_geom, distance_river_trajectory_point, projection_trajectory_point_river_the_geom, closest_point_the_geom, importance, createdon)
/*
WITH subquery_1 AS (

SELECT
	t.id id_ref_trajectory_point_fk,
	closest_r.id id_ref_river_fk,
	t.the_geom trajectory_point_the_geom,
	closest_r.the_geom river_the_geom,
	st_closestpoint(closest_r.the_geom, t.the_geom) closest_point_the_geom,
	closest_r.importance

from
	campaign.trajectory_point t

inner join lateral (

	select
	*
	from
	referential.river r
	order by r.the_geom <-> t.the_geom
	limit 1
	) closest_r on TRUE

)
SELECT
	id_ref_trajectory_point_fk,
	id_ref_river_fk,
	trajectory_point_the_geom,
	river_the_geom,
	st_distance(closest_point_the_geom, trajectory_point_the_geom) distance_river_trajectory_point,
	st_makeline(trajectory_point_the_geom, closest_point_the_geom) projection_trajectory_point_river_the_geom,
	closest_point_the_geom,
	importance,
	current_timestamp
FROM
	subquery_1;
*/