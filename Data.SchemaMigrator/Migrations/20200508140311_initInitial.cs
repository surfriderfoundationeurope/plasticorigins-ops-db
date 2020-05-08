using System;
using System.Collections;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.SchemaMigrator.Migrations
{
    public partial class initInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "campaign");

            migrationBuilder.EnsureSchema(
                name: "raw_data");

            migrationBuilder.EnsureSchema(
                name: "bi");

            migrationBuilder.EnsureSchema(
                name: "referential");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:pg_buffercache", ",,")
                .Annotation("Npgsql:PostgresExtension:pg_stat_statements", ",,")
                .Annotation("Npgsql:PostgresExtension:pgcrypto", ",,")
                .Annotation("Npgsql:PostgresExtension:pgrouting", ",,")
                .Annotation("Npgsql:PostgresExtension:postgis", ",,")
                .Annotation("Npgsql:PostgresExtension:postgis_topology", ",,")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");


            migrationBuilder.CreateTable(
                name: "campaign",
                schema: "bi",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_ref_campaign_fk = table.Column<Guid>(nullable: true),
                    locomotion = table.Column<string>(nullable: true),
                    isaidriven = table.Column<bool>(nullable: true),
                    remark = table.Column<string>(nullable: true),
                    id_ref_user_fk = table.Column<Guid>(nullable: true),
                    riverside = table.Column<string>(nullable: true),
                    container_url = table.Column<string>(nullable: true),
                    blob_name = table.Column<string>(nullable: true),
                    id_ref_model_fk = table.Column<Guid>(nullable: true),
                    start_date = table.Column<DateTime>(type: "date", nullable: true),
                    end_date = table.Column<DateTime>(type: "date", nullable: true),
                    start_point = table.Column<Geometry>(nullable: true),
                    end_point = table.Column<Geometry>(nullable: true),
                    total_distance = table.Column<double>(nullable: true),
                    avg_speed = table.Column<int>(nullable: true),
                    duration = table.Column<TimeSpan>(nullable: true),
                    start_point_distance_sea = table.Column<double>(nullable: true),
                    end_point_distance_sea = table.Column<double>(nullable: true),
                    trash_count = table.Column<int>(nullable: true),
                    distance_start_end = table.Column<double>(nullable: true),
                    createdon = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_campaign", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "campaign_river",
                schema: "bi",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_ref_campaign_fk = table.Column<Guid>(nullable: true),
                    river_name = table.Column<string>(nullable: true),
                    distance = table.Column<decimal>(type: "numeric", nullable: true),
                    the_geom = table.Column<Geometry>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_campaign_river", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "logs",
                schema: "bi",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    initiated_on = table.Column<DateTime>(type: "date", nullable: false),
                    finished_on = table.Column<DateTime>(type: "date", nullable: false),
                    elapsed_time = table.Column<double>(nullable: true),
                    status = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "river",
                schema: "bi",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: true),
                    the_geom = table.Column<Geometry>(nullable: true),
                    length = table.Column<double>(nullable: true),
                    count_unique_trash = table.Column<double>(nullable: true),
                    count_trash = table.Column<double>(nullable: true),
                    distance_monitored = table.Column<double>(nullable: true),
                    the_geom_monitored = table.Column<Geometry>(nullable: true),
                    trash_per_km = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_river", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "trajectory_point",
                schema: "bi",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: true),
                    the_geom = table.Column<Geometry>(nullable: true),
                    id_ref_campaign_fk = table.Column<Guid>(nullable: true),
                    elevation = table.Column<double>(nullable: true),
                    distance = table.Column<double>(nullable: true),
                    time_diff = table.Column<TimeSpan>(nullable: true),
                    time = table.Column<DateTime>(nullable: true),
                    speed = table.Column<double>(nullable: true),
                    lat = table.Column<double>(nullable: true),
                    lon = table.Column<double>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "trajectory_point_river",
                schema: "bi",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_ref_trajectory_point_fk = table.Column<Guid>(nullable: false),
                    id_ref_campaign_fk = table.Column<Guid>(nullable: false),
                    id_ref_river_fk = table.Column<int>(nullable: false),
                    trajectory_point_the_geom = table.Column<Geometry>(nullable: false),
                    river_the_geom = table.Column<Geometry>(nullable: false),
                    closest_point_the_geom = table.Column<Geometry>(nullable: false),
                    distance_river_trajectory_point = table.Column<double>(nullable: false),
                    projection_trajectory_point_river_the_geom = table.Column<Geometry>(nullable: false),
                    importance = table.Column<int>(nullable: true),
                    river_name = table.Column<string>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trajectory_point_river", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "trash_river",
                schema: "bi",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_ref_trash_fk = table.Column<Guid>(nullable: false),
                    id_ref_campaign_fk = table.Column<Guid>(nullable: false),
                    id_ref_river_fk = table.Column<int>(nullable: false),
                    trash_the_geom = table.Column<Geometry>(nullable: false),
                    river_the_geom = table.Column<Geometry>(nullable: false),
                    closest_point_the_geom = table.Column<Geometry>(nullable: false),
                    distance_river_trash = table.Column<double>(nullable: false),
                    projection_trash_river_the_geom = table.Column<Geometry>(nullable: false),
                    importance = table.Column<int>(nullable: true),
                    river_name = table.Column<string>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trash_river", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "model",
                schema: "campaign",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    version = table.Column<int>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_model", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "trash_type",
                schema: "campaign",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(nullable: true),
                    brand = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trash_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                schema: "campaign",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    firstname = table.Column<string>(nullable: true),
                    lastname = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: false),
                    emailconfirmed = table.Column<bool>(nullable: false),
                    passwordhash = table.Column<string>(nullable: true),
                    yearofbirth = table.Column<DateTime>(type: "date", nullable: true),
                    experience = table.Column<string>(nullable: true),
                    isdeleted = table.Column<bool>(nullable: false),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "arrondissement_departemental",
                schema: "raw_data",
                columns: table => new
                {
                    id = table.Column<string>(nullable: true),
                    insee_arr = table.Column<string>(nullable: true),
                    insee_dep = table.Column<string>(nullable: true),
                    insee_reg = table.Column<string>(nullable: true),
                    geometry = table.Column<Geometry>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "bassin_versant_topographique",
                schema: "raw_data",
                columns: table => new
                {
                    id = table.Column<string>(nullable: true),
                    code_hydro = table.Column<string>(nullable: true),
                    toponyme = table.Column<string>(nullable: true),
                    bass_hydro = table.Column<string>(nullable: true),
                    date_creat = table.Column<string>(nullable: true),
                    date_maj = table.Column<string>(nullable: true),
                    date_app = table.Column<string>(nullable: true),
                    date_conf = table.Column<string>(nullable: true),
                    source = table.Column<string>(nullable: true),
                    id_source = table.Column<string>(nullable: true),
                    prec_plani = table.Column<string>(nullable: true),
                    src_coord = table.Column<string>(nullable: true),
                    statut = table.Column<string>(nullable: true),
                    b_fluvial = table.Column<string>(nullable: true),
                    origine = table.Column<string>(nullable: true),
                    comment = table.Column<string>(nullable: true),
                    code_bh = table.Column<string>(nullable: true),
                    code_carth = table.Column<string>(nullable: true),
                    id_c_eau = table.Column<string>(nullable: true),
                    geometry = table.Column<Geometry>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "chef_lieu",
                schema: "raw_data",
                columns: table => new
                {
                    id = table.Column<string>(nullable: true),
                    nom_chf = table.Column<string>(nullable: true),
                    statut = table.Column<string>(nullable: true),
                    insee_com = table.Column<string>(nullable: true),
                    geometry = table.Column<Geometry>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "commune",
                schema: "raw_data",
                columns: table => new
                {
                    id = table.Column<string>(nullable: true),
                    statut = table.Column<string>(nullable: true),
                    insee_com = table.Column<string>(nullable: true),
                    nom_com = table.Column<string>(nullable: true),
                    insee_arr = table.Column<string>(nullable: true),
                    nom_dep = table.Column<string>(nullable: true),
                    insee_dep = table.Column<string>(nullable: true),
                    nom_reg = table.Column<string>(nullable: true),
                    insee_reg = table.Column<string>(nullable: true),
                    code_epci = table.Column<string>(nullable: true),
                    nom_com_m = table.Column<string>(nullable: true),
                    population = table.Column<string>(nullable: true),
                    geometry = table.Column<Geometry>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "cours_d_eau",
                schema: "raw_data",
                columns: table => new
                {
                    id = table.Column<string>(nullable: true),
                    code_hydro = table.Column<string>(nullable: true),
                    toponyme = table.Column<string>(nullable: true),
                    statut_top = table.Column<string>(nullable: true),
                    importance = table.Column<string>(nullable: true),
                    date_creat = table.Column<string>(nullable: true),
                    date_maj = table.Column<string>(nullable: true),
                    date_app = table.Column<string>(nullable: true),
                    date_conf = table.Column<string>(nullable: true),
                    source = table.Column<string>(nullable: true),
                    id_source = table.Column<string>(nullable: true),
                    statut = table.Column<string>(nullable: true),
                    maree = table.Column<string>(nullable: true),
                    permanent = table.Column<string>(nullable: true),
                    comment = table.Column<string>(nullable: true),
                    geometry = table.Column<Geometry>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "departement",
                schema: "raw_data",
                columns: table => new
                {
                    id = table.Column<string>(nullable: true),
                    nom_dep = table.Column<string>(nullable: true),
                    insee_dep = table.Column<string>(nullable: true),
                    insee_reg = table.Column<string>(nullable: true),
                    geometry = table.Column<Geometry>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "detail_hydrographique",
                schema: "raw_data",
                columns: table => new
                {
                    id = table.Column<string>(nullable: true),
                    nature = table.Column<string>(nullable: true),
                    nat_detail = table.Column<string>(nullable: true),
                    toponyme = table.Column<string>(nullable: true),
                    statut_top = table.Column<string>(nullable: true),
                    importance = table.Column<string>(nullable: true),
                    etat = table.Column<string>(nullable: true),
                    date_creat = table.Column<string>(nullable: true),
                    date_maj = table.Column<string>(nullable: true),
                    date_app = table.Column<string>(nullable: true),
                    date_conf = table.Column<string>(nullable: true),
                    source = table.Column<string>(nullable: true),
                    id_source = table.Column<string>(nullable: true),
                    prec_plani = table.Column<string>(nullable: true),
                    geometry = table.Column<Geometry>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "epci",
                schema: "raw_data",
                columns: table => new
                {
                    id = table.Column<string>(nullable: true),
                    code_epci = table.Column<string>(nullable: true),
                    nom_epci = table.Column<string>(nullable: true),
                    type_epci = table.Column<string>(nullable: true),
                    geometry = table.Column<Geometry>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "limite_terre_mer",
                schema: "raw_data",
                columns: table => new
                {
                    id = table.Column<string>(nullable: true),
                    code_hydro = table.Column<string>(nullable: true),
                    code_pays = table.Column<string>(nullable: true),
                    type_limit = table.Column<string>(nullable: true),
                    niveau = table.Column<string>(nullable: true),
                    date_creat = table.Column<string>(nullable: true),
                    date_maj = table.Column<string>(nullable: true),
                    date_app = table.Column<string>(nullable: true),
                    date_conf = table.Column<string>(nullable: true),
                    source = table.Column<string>(nullable: true),
                    id_source = table.Column<string>(nullable: true),
                    prec_plani = table.Column<string>(nullable: true),
                    src_coord = table.Column<string>(nullable: true),
                    statut = table.Column<string>(nullable: true),
                    origine = table.Column<string>(nullable: true),
                    comment = table.Column<string>(nullable: true),
                    geometry = table.Column<Geometry>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "noeud_hydrographique",
                schema: "raw_data",
                columns: table => new
                {
                    id = table.Column<string>(nullable: true),
                    code_hydro = table.Column<string>(nullable: true),
                    code_pays = table.Column<string>(nullable: true),
                    categorie = table.Column<string>(nullable: true),
                    toponyme = table.Column<string>(nullable: true),
                    statut_top = table.Column<string>(nullable: true),
                    date_creat = table.Column<string>(nullable: true),
                    date_maj = table.Column<string>(nullable: true),
                    date_app = table.Column<string>(nullable: true),
                    date_conf = table.Column<string>(nullable: true),
                    source = table.Column<string>(nullable: true),
                    id_source = table.Column<string>(nullable: true),
                    prec_plani = table.Column<string>(nullable: true),
                    prec_alti = table.Column<string>(nullable: true),
                    src_coord = table.Column<string>(nullable: true),
                    src_alti = table.Column<string>(nullable: true),
                    statut = table.Column<string>(nullable: true),
                    comment = table.Column<string>(nullable: true),
                    id_ce_amon = table.Column<string>(nullable: true),
                    id_ce_aval = table.Column<string>(nullable: true),
                    geometry = table.Column<Geometry>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "plan_d_eau",
                schema: "raw_data",
                columns: table => new
                {
                    id = table.Column<string>(nullable: true),
                    code_hydro = table.Column<string>(nullable: true),
                    nature = table.Column<string>(nullable: true),
                    toponyme = table.Column<string>(nullable: true),
                    statut_top = table.Column<string>(nullable: true),
                    importance = table.Column<string>(nullable: true),
                    date_creat = table.Column<string>(nullable: true),
                    date_maj = table.Column<string>(nullable: true),
                    date_app = table.Column<string>(nullable: true),
                    date_conf = table.Column<string>(nullable: true),
                    source = table.Column<string>(nullable: true),
                    id_source = table.Column<string>(nullable: true),
                    statut = table.Column<string>(nullable: true),
                    maree = table.Column<string>(nullable: true),
                    permanent = table.Column<string>(nullable: true),
                    z_moy = table.Column<string>(nullable: true),
                    ref_z_moy = table.Column<string>(nullable: true),
                    mode_z_moy = table.Column<string>(nullable: true),
                    prec_z_moy = table.Column<string>(nullable: true),
                    haut_max = table.Column<string>(nullable: true),
                    obt_ht_max = table.Column<string>(nullable: true),
                    comment = table.Column<string>(nullable: true),
                    geometry = table.Column<Geometry>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "region",
                schema: "raw_data",
                columns: table => new
                {
                    id = table.Column<string>(nullable: true),
                    nom_reg = table.Column<string>(nullable: true),
                    insee_reg = table.Column<string>(nullable: true),
                    geometry = table.Column<Geometry>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "surface_hydrographique",
                schema: "raw_data",
                columns: table => new
                {
                    id = table.Column<string>(nullable: true),
                    code_hydro = table.Column<string>(nullable: true),
                    code_pays = table.Column<string>(nullable: true),
                    nature = table.Column<string>(nullable: true),
                    pos_sol = table.Column<string>(nullable: true),
                    etat = table.Column<string>(nullable: true),
                    date_creat = table.Column<string>(nullable: true),
                    date_maj = table.Column<string>(nullable: true),
                    date_app = table.Column<string>(nullable: true),
                    date_conf = table.Column<string>(nullable: true),
                    source = table.Column<string>(nullable: true),
                    id_source = table.Column<string>(nullable: true),
                    prec_plani = table.Column<string>(nullable: true),
                    prec_alti = table.Column<string>(nullable: true),
                    src_coord = table.Column<string>(nullable: true),
                    src_alti = table.Column<string>(nullable: true),
                    statut = table.Column<string>(nullable: true),
                    persistanc = table.Column<string>(nullable: true),
                    salinite = table.Column<string>(nullable: true),
                    origine = table.Column<string>(nullable: true),
                    comment = table.Column<string>(nullable: true),
                    id_p_eau = table.Column<string>(nullable: true),
                    id_c_eau = table.Column<string>(nullable: true),
                    id_ent_tr = table.Column<string>(nullable: true),
                    nom_p_eau = table.Column<string>(nullable: true),
                    nom_c_eau = table.Column<string>(nullable: true),
                    nom_ent_tr = table.Column<string>(nullable: true),
                    geometry = table.Column<Geometry>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "toponymie_hydrographie",
                schema: "raw_data",
                columns: table => new
                {
                    id = table.Column<string>(nullable: true),
                    classe = table.Column<string>(nullable: true),
                    nature = table.Column<string>(nullable: true),
                    graphie = table.Column<string>(nullable: true),
                    source = table.Column<string>(nullable: true),
                    statut_top = table.Column<string>(nullable: true),
                    date_top = table.Column<string>(nullable: true),
                    geometry = table.Column<Geometry>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "traces",
                schema: "raw_data",
                columns: table => new
                {
                    elevation = table.Column<double>(nullable: true),
                    latitude = table.Column<double>(nullable: true),
                    longitude = table.Column<double>(nullable: true),
                    time = table.Column<string>(nullable: true),
                    file = table.Column<string>(nullable: true),
                    campaign_id = table.Column<double>(nullable: true),
                    locomotion = table.Column<string>(nullable: true),
                    method = table.Column<string>(nullable: true),
                    riverside = table.Column<string>(nullable: true),
                    river = table.Column<string>(nullable: true),
                    user_first_name = table.Column<string>(nullable: true),
                    user_last_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "trash",
                schema: "raw_data",
                columns: table => new
                {
                    elevation = table.Column<double>(nullable: true),
                    latitude = table.Column<double>(nullable: true),
                    longitude = table.Column<double>(nullable: true),
                    @object = table.Column<string>(name: "object", nullable: true),
                    time = table.Column<string>(nullable: true),
                    file = table.Column<string>(nullable: true),
                    campaign_id = table.Column<double>(nullable: true),
                    locomotion = table.Column<string>(nullable: true),
                    method = table.Column<string>(nullable: true),
                    riverside = table.Column<string>(nullable: true),
                    river = table.Column<string>(nullable: true),
                    user_first_name = table.Column<string>(nullable: true),
                    user_last_name = table.Column<string>(nullable: true),
                    the_geom = table.Column<Geometry>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "troncon_hydrographique",
                schema: "raw_data",
                columns: table => new
                {
                    id = table.Column<string>(nullable: true),
                    code_hydro = table.Column<string>(nullable: true),
                    code_pays = table.Column<string>(nullable: true),
                    nature = table.Column<string>(nullable: true),
                    fictif = table.Column<string>(nullable: true),
                    pos_sol = table.Column<string>(nullable: true),
                    etat = table.Column<string>(nullable: true),
                    date_creat = table.Column<string>(nullable: true),
                    date_maj = table.Column<string>(nullable: true),
                    date_app = table.Column<string>(nullable: true),
                    date_conf = table.Column<string>(nullable: true),
                    source = table.Column<string>(nullable: true),
                    id_source = table.Column<string>(nullable: true),
                    prec_plani = table.Column<string>(nullable: true),
                    prec_alti = table.Column<string>(nullable: true),
                    src_coord = table.Column<string>(nullable: true),
                    src_alti = table.Column<string>(nullable: true),
                    statut = table.Column<string>(nullable: true),
                    persistanc = table.Column<string>(nullable: true),
                    fosse = table.Column<string>(nullable: true),
                    navigabl = table.Column<string>(nullable: true),
                    salinite = table.Column<string>(nullable: true),
                    num_ordre = table.Column<string>(nullable: true),
                    cla_ordre = table.Column<string>(nullable: true),
                    origine = table.Column<string>(nullable: true),
                    per_ordre = table.Column<string>(nullable: true),
                    sens_ecoul = table.Column<string>(nullable: true),
                    res_coulan = table.Column<string>(nullable: true),
                    delimit = table.Column<string>(nullable: true),
                    largeur = table.Column<string>(nullable: true),
                    bras = table.Column<string>(nullable: true),
                    comment = table.Column<string>(nullable: true),
                    code_carth = table.Column<string>(nullable: true),
                    id_c_eau = table.Column<string>(nullable: true),
                    id_s_hydro = table.Column<string>(nullable: true),
                    id_ent_tr = table.Column<string>(nullable: true),
                    nom_c_eau = table.Column<string>(nullable: true),
                    nom_ent_tr = table.Column<string>(nullable: true),
                    geometry = table.Column<Geometry>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "country",
                schema: "referential",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    the_geom = table.Column<Geometry>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.id);
                });


            migrationBuilder.CreateTable(
                name: "trash",
                schema: "bi",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    id_ref_campaign_fk = table.Column<string[]>(nullable: true),
                    the_geom = table.Column<Geometry>(nullable: true),
                    elevation = table.Column<double>(nullable: true),
                    id_ref_trash_type_fk = table.Column<int>(nullable: false),
                    precision = table.Column<double>(nullable: true),
                    id_ref_model_fk = table.Column<string[]>(nullable: true),
                    brand_type = table.Column<string>(nullable: true),
                    id_ref_image_fk = table.Column<string[]>(nullable: true),
                    time = table.Column<DateTime[]>(nullable: true),
                    lat = table.Column<double>(nullable: true),
                    lon = table.Column<double>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trash", x => x.id);
                    table.ForeignKey(
                        name: "trash_id_ref_trash_type_fk_fkey",
                        column: x => x.id_ref_trash_type_fk,
                        principalSchema: "campaign",
                        principalTable: "trash_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "campaign",
                schema: "campaign",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    locomotion = table.Column<string>(nullable: false),
                    isaidriven = table.Column<bool>(nullable: true),
                    remark = table.Column<string>(nullable: true),
                    id_ref_user_fk = table.Column<Guid>(nullable: true),
                    riverside = table.Column<string>(nullable: true),
                    container_url = table.Column<string>(nullable: true),
                    blob_name = table.Column<string>(nullable: true),
                    id_ref_model_fk = table.Column<Guid>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_campaign", x => x.id);
                    table.ForeignKey(
                        name: "campaign_id_ref_model_fk_fkey",
                        column: x => x.id_ref_model_fk,
                        principalSchema: "campaign",
                        principalTable: "model",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "campaign_id_ref_user_fk_fkey",
                        column: x => x.id_ref_user_fk,
                        principalSchema: "campaign",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "limits_land_sea",
                schema: "referential",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    the_geom = table.Column<Geometry>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    id_source = table.Column<string>(nullable: true),
                    nature = table.Column<string>(nullable: true),
                    origine = table.Column<string>(nullable: true),
                    code_hydro = table.Column<string>(nullable: true),
                    id_ref_country_fk = table.Column<int>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_limits_land_sea", x => x.id);
                    table.ForeignKey(
                        name: "limits_land_sea_id_ref_country_fk_fkey",
                        column: x => x.id_ref_country_fk,
                        principalSchema: "referential",
                        principalTable: "country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "river",
                schema: "referential",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    the_geom = table.Column<Geometry>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    nature = table.Column<string>(nullable: true),
                    importance = table.Column<int>(nullable: true),
                    origine = table.Column<string>(nullable: true),
                    code_hydro = table.Column<string>(nullable: true),
                    id_ref_country_fk = table.Column<int>(nullable: true),
                    bras = table.Column<string>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_river", x => x.id);
                    table.ForeignKey(
                        name: "river_id_ref_country_fk_fkey",
                        column: x => x.id_ref_country_fk,
                        principalSchema: "referential",
                        principalTable: "country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "state",
                schema: "referential",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    the_geom = table.Column<Geometry>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    id_source = table.Column<string>(nullable: true),
                    id_ref_country_fk = table.Column<int>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_state", x => x.id);
                    table.ForeignKey(
                        name: "state_id_ref_country_fk_fkey",
                        column: x => x.id_ref_country_fk,
                        principalSchema: "referential",
                        principalTable: "country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });


            migrationBuilder.CreateTable(
                name: "trajectory_point",
                schema: "campaign",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    the_geom = table.Column<Geometry>(nullable: true),
                    id_ref_campaign_fk = table.Column<Guid>(nullable: false),
                    elevation = table.Column<double>(nullable: true),
                    distance = table.Column<double>(nullable: true),
                    time_diff = table.Column<TimeSpan>(nullable: true),
                    time = table.Column<DateTime>(nullable: true),
                    speed = table.Column<double>(nullable: true),
                    lat = table.Column<double>(nullable: true),
                    lon = table.Column<double>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trajectory_point", x => x.id);
                    table.ForeignKey(
                        name: "trajectory_point_id_ref_campaign_fk_fkey",
                        column: x => x.id_ref_campaign_fk,
                        principalSchema: "campaign",
                        principalTable: "campaign",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "department",
                schema: "referential",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    the_geom = table.Column<Geometry>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    id_source = table.Column<string>(nullable: true),
                    id_ref_state_fk = table.Column<int>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.id);
                    table.ForeignKey(
                        name: "department_id_ref_state_fk_fkey",
                        column: x => x.id_ref_state_fk,
                        principalSchema: "referential",
                        principalTable: "state",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "image",
                schema: "campaign",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    filename = table.Column<string>(nullable: false),
                    blobname = table.Column<string>(nullable: false),
                    containerurl = table.Column<string>(nullable: false),
                    createdby = table.Column<string>(nullable: false),
                    isdeleted = table.Column<BitArray>(type: "bit(1)", nullable: false),
                    version = table.Column<int>(nullable: false),
                    id_ref_campaign_fk = table.Column<Guid>(nullable: true),
                    id_ref_trajectory_points_fk = table.Column<Guid>(nullable: true),
                    time = table.Column<DateTime>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_image", x => x.id);
                    table.ForeignKey(
                        name: "image_id_ref_campaign_fk_fkey",
                        column: x => x.id_ref_campaign_fk,
                        principalSchema: "campaign",
                        principalTable: "campaign",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "image_id_ref_trajectory_points_fk_fkey",
                        column: x => x.id_ref_trajectory_points_fk,
                        principalSchema: "campaign",
                        principalTable: "trajectory_point",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "municipality",
                schema: "referential",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    the_geom = table.Column<Geometry>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    id_source = table.Column<string>(nullable: true),
                    id_ref_department_fk = table.Column<int>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_municipality", x => x.id);
                    table.ForeignKey(
                        name: "municipality_id_ref_department_fk_fkey",
                        column: x => x.id_ref_department_fk,
                        principalSchema: "referential",
                        principalTable: "department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trash",
                schema: "campaign",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    id_ref_campaign_fk = table.Column<Guid>(nullable: false),
                    the_geom = table.Column<Geometry>(nullable: true),
                    elevation = table.Column<double>(nullable: true),
                    id_ref_trash_type_fk = table.Column<int>(nullable: false),
                    precision = table.Column<double>(nullable: true),
                    id_ref_model_fk = table.Column<Guid>(nullable: true),
                    brand_type = table.Column<string>(nullable: true),
                    id_ref_image_fk = table.Column<Guid>(nullable: true),
                    time = table.Column<DateTime>(nullable: true),
                    lat = table.Column<double>(nullable: true),
                    lon = table.Column<double>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trash", x => x.id);
                    table.ForeignKey(
                        name: "trash_id_ref_campaign_fk_fkey",
                        column: x => x.id_ref_campaign_fk,
                        principalSchema: "campaign",
                        principalTable: "campaign",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "trash_id_ref_image_fk_fkey",
                        column: x => x.id_ref_image_fk,
                        principalSchema: "campaign",
                        principalTable: "image",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "trash_id_ref_model_fk_fkey",
                        column: x => x.id_ref_model_fk,
                        principalSchema: "campaign",
                        principalTable: "model",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "trash_id_ref_trash_type_fk_fkey",
                        column: x => x.id_ref_trash_type_fk,
                        principalSchema: "campaign",
                        principalTable: "trash_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "campaign_end_point",
                schema: "bi",
                table: "campaign",
                column: "end_point")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "campaign_id_ref_campaign_fk",
                schema: "bi",
                table: "campaign",
                column: "id_ref_campaign_fk");

            migrationBuilder.CreateIndex(
                name: "campaign_start_point",
                schema: "bi",
                table: "campaign",
                column: "start_point")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "river_name",
                schema: "bi",
                table: "river",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "river_the_geom",
                schema: "bi",
                table: "river",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "trajectory_point_river_id_ref_trajectory_point_fk",
                schema: "bi",
                table: "trajectory_point_river",
                column: "id_ref_trajectory_point_fk");

            migrationBuilder.CreateIndex(
                name: "IX_trash_id_ref_trash_type_fk",
                schema: "bi",
                table: "trash",
                column: "id_ref_trash_type_fk");

            migrationBuilder.CreateIndex(
                name: "trash_river_closest_point_the_geom",
                schema: "bi",
                table: "trash_river",
                column: "closest_point_the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "campaign_id",
                schema: "campaign",
                table: "campaign",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_campaign_id_ref_model_fk",
                schema: "campaign",
                table: "campaign",
                column: "id_ref_model_fk");

            migrationBuilder.CreateIndex(
                name: "IX_campaign_id_ref_user_fk",
                schema: "campaign",
                table: "campaign",
                column: "id_ref_user_fk");

            migrationBuilder.CreateIndex(
                name: "IX_image_id_ref_campaign_fk",
                schema: "campaign",
                table: "image",
                column: "id_ref_campaign_fk");

            migrationBuilder.CreateIndex(
                name: "IX_image_id_ref_trajectory_points_fk",
                schema: "campaign",
                table: "image",
                column: "id_ref_trajectory_points_fk");

            migrationBuilder.CreateIndex(
                name: "IX_trajectory_point_id_ref_campaign_fk",
                schema: "campaign",
                table: "trajectory_point",
                column: "id_ref_campaign_fk");

            migrationBuilder.CreateIndex(
                name: "trajectory_point_the_geom",
                schema: "campaign",
                table: "trajectory_point",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "IX_trash_id_ref_campaign_fk",
                schema: "campaign",
                table: "trash",
                column: "id_ref_campaign_fk");

            migrationBuilder.CreateIndex(
                name: "IX_trash_id_ref_image_fk",
                schema: "campaign",
                table: "trash",
                column: "id_ref_image_fk");

            migrationBuilder.CreateIndex(
                name: "IX_trash_id_ref_model_fk",
                schema: "campaign",
                table: "trash",
                column: "id_ref_model_fk");

            migrationBuilder.CreateIndex(
                name: "IX_trash_id_ref_trash_type_fk1",
                schema: "campaign",
                table: "trash",
                column: "id_ref_trash_type_fk");

            migrationBuilder.CreateIndex(
                name: "trash_the_geom",
                schema: "campaign",
                table: "trash",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "trash_type_type_key",
                schema: "campaign",
                table: "trash_type",
                column: "type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "user_firstname",
                schema: "campaign",
                table: "user",
                column: "firstname");

            migrationBuilder.CreateIndex(
                name: "user_lastname",
                schema: "campaign",
                table: "user",
                column: "lastname");

            migrationBuilder.CreateIndex(
                name: "user_firstname_lastname_key",
                schema: "campaign",
                table: "user",
                columns: new[] { "firstname", "lastname" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "raw_data_cours_d_eau_geometry",
                schema: "raw_data",
                table: "cours_d_eau",
                column: "geometry")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "raw_data_departement_geometry",
                schema: "raw_data",
                table: "departement",
                column: "geometry")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "raw_data_limite_terre_mer_geometry",
                schema: "raw_data",
                table: "limite_terre_mer",
                column: "geometry")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "raw_data_noeud_hydrographique_geometry",
                schema: "raw_data",
                table: "noeud_hydrographique",
                column: "geometry")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "raw_data_region_geometry",
                schema: "raw_data",
                table: "region",
                column: "geometry")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "raw_data_troncon_hydrographique_geometry",
                schema: "raw_data",
                table: "troncon_hydrographique",
                column: "geometry")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "country_code",
                schema: "referential",
                table: "country",
                column: "code");

            migrationBuilder.CreateIndex(
                name: "country_name_key",
                schema: "referential",
                table: "country",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "country_the_geom",
                schema: "referential",
                table: "country",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "referential_department_code",
                schema: "referential",
                table: "department",
                column: "code");

            migrationBuilder.CreateIndex(
                name: "IX_department_id_ref_state_fk",
                schema: "referential",
                table: "department",
                column: "id_ref_state_fk");

            migrationBuilder.CreateIndex(
                name: "department_name_key",
                schema: "referential",
                table: "department",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "referential_department_the_geom",
                schema: "referential",
                table: "department",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "IX_limits_land_sea_id_ref_country_fk",
                schema: "referential",
                table: "limits_land_sea",
                column: "id_ref_country_fk");

            migrationBuilder.CreateIndex(
                name: "limits_land_sea_the_geom",
                schema: "referential",
                table: "limits_land_sea",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "municipality_code",
                schema: "referential",
                table: "municipality",
                column: "code");

            migrationBuilder.CreateIndex(
                name: "IX_municipality_id_ref_department_fk",
                schema: "referential",
                table: "municipality",
                column: "id_ref_department_fk");

            migrationBuilder.CreateIndex(
                name: "municipality_the_geom",
                schema: "referential",
                table: "municipality",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "IX_river_id_ref_country_fk",
                schema: "referential",
                table: "river",
                column: "id_ref_country_fk");

            migrationBuilder.CreateIndex(
                name: "river_importance",
                schema: "referential",
                table: "river",
                column: "importance");

            migrationBuilder.CreateIndex(
                name: "river_name",
                schema: "referential",
                table: "river",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "river_the_geom",
                schema: "referential",
                table: "river",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "state_code",
                schema: "referential",
                table: "state",
                column: "code");

            migrationBuilder.CreateIndex(
                name: "IX_state_id_ref_country_fk",
                schema: "referential",
                table: "state",
                column: "id_ref_country_fk");

            migrationBuilder.CreateIndex(
                name: "state_name_key",
                schema: "referential",
                table: "state",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "state_the_geom",
                schema: "referential",
                table: "state",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "campaign",
                schema: "bi");

            migrationBuilder.DropTable(
                name: "campaign_river",
                schema: "bi");

            migrationBuilder.DropTable(
                name: "logs",
                schema: "bi");

            migrationBuilder.DropTable(
                name: "river",
                schema: "bi");

            migrationBuilder.DropTable(
                name: "trajectory_point",
                schema: "bi");

            migrationBuilder.DropTable(
                name: "trajectory_point_river",
                schema: "bi");

            migrationBuilder.DropTable(
                name: "trash",
                schema: "bi");

            migrationBuilder.DropTable(
                name: "trash_river",
                schema: "bi");

            migrationBuilder.DropTable(
                name: "trash",
                schema: "campaign");

            migrationBuilder.DropTable(
                name: "arrondissement_departemental",
                schema: "raw_data");

            migrationBuilder.DropTable(
                name: "bassin_versant_topographique",
                schema: "raw_data");

            migrationBuilder.DropTable(
                name: "chef_lieu",
                schema: "raw_data");

            migrationBuilder.DropTable(
                name: "commune",
                schema: "raw_data");

            migrationBuilder.DropTable(
                name: "cours_d_eau",
                schema: "raw_data");

            migrationBuilder.DropTable(
                name: "departement",
                schema: "raw_data");

            migrationBuilder.DropTable(
                name: "detail_hydrographique",
                schema: "raw_data");

            migrationBuilder.DropTable(
                name: "epci",
                schema: "raw_data");

            migrationBuilder.DropTable(
                name: "limite_terre_mer",
                schema: "raw_data");

            migrationBuilder.DropTable(
                name: "noeud_hydrographique",
                schema: "raw_data");

            migrationBuilder.DropTable(
                name: "plan_d_eau",
                schema: "raw_data");

            migrationBuilder.DropTable(
                name: "region",
                schema: "raw_data");

            migrationBuilder.DropTable(
                name: "surface_hydrographique",
                schema: "raw_data");

            migrationBuilder.DropTable(
                name: "toponymie_hydrographie",
                schema: "raw_data");

            migrationBuilder.DropTable(
                name: "traces",
                schema: "raw_data");

            migrationBuilder.DropTable(
                name: "trash",
                schema: "raw_data");

            migrationBuilder.DropTable(
                name: "troncon_hydrographique",
                schema: "raw_data");

            migrationBuilder.DropTable(
                name: "limits_land_sea",
                schema: "referential");

            migrationBuilder.DropTable(
                name: "municipality",
                schema: "referential");

            migrationBuilder.DropTable(
                name: "river",
                schema: "referential");

            migrationBuilder.DropTable(
                name: "image",
                schema: "campaign");

            migrationBuilder.DropTable(
                name: "trash_type",
                schema: "campaign");

            migrationBuilder.DropTable(
                name: "department",
                schema: "referential");

            migrationBuilder.DropTable(
                name: "trajectory_point",
                schema: "campaign");

            migrationBuilder.DropTable(
                name: "state",
                schema: "referential");

            migrationBuilder.DropTable(
                name: "campaign",
                schema: "campaign");

            migrationBuilder.DropTable(
                name: "country",
                schema: "referential");

            migrationBuilder.DropTable(
                name: "model",
                schema: "campaign");

            migrationBuilder.DropTable(
                name: "user",
                schema: "campaign");
        }
    }
}
