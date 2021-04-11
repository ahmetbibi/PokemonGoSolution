using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using PokemonGo.Data;
using System.IO;
using System.Text.Json;
using PokemonGo.Models;

namespace PokemonGo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Point> Points { get; set; }
        public DbSet<PointType> PointType { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Point>(p =>
            {
                p.HasKey(p => p.Id);
                p.Property(p => p.Latitude).IsRequired();
                p.Property(p => p.Longitude).IsRequired();
                p.Property(p => p.Title).IsRequired();

                p.HasOne<PointType>(p => p.PointType)
                    .WithMany(pt => pt.Points)
                    .HasForeignKey(p => p.PointTypeId);

                //p.HasOne<IdentityUser>()
                //    .WithMany()
                //    .HasForeignKey(p => p.UserId);
            });

            builder.Entity<PointType>(pt =>
            {
                pt.Property(pt => pt.Name).IsRequired();
            });

            // Add admin user to DB            
            var hasher = new PasswordHasher<IdentityUser>();

            builder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "09f1d0ca-181d-42fe-a015-6534acae8ed1",
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN@POGOREESHOF.NL",
                    Email = "admin@pogoreeshof.nl",
                    NormalizedEmail = "ADMIN@POGOREESHOF.NL",
                    PasswordHash = hasher.HashPassword(null, "Pa$$w0rd"),
                    EmailConfirmed = true,
                    LockoutEnabled = true
                },
                new IdentityUser
                {
                    Id = "42g3r3bu-434s-24qe-b120-3201ijia9ac0",
                    UserName = "Manager",
                    NormalizedUserName = "MANAGER@POGOREESHOF.NL",
                    Email = "manager@pogoreeshof.nl",
                    NormalizedEmail = "MANAGER@POGOREESHOF.NL",
                    PasswordHash = hasher.HashPassword(null, "Pa$$w0rd"),
                    EmailConfirmed = true,
                    LockoutEnabled = true
                }
                );

            builder.Entity<IdentityRole>().HasData(
                    new IdentityRole
                    {
                        Id = "42g2b8ve-232r-76ju-q432-8756refa9tg5",
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    },
                    new IdentityRole
                    {
                        Id = "52f2b8ve-454t-88to-d286-9246pazo3yh8",
                        Name = "Manager",
                        NormalizedName = "MANAGER"
                    }
                );

            builder.Entity<IdentityUserRole<string>>().HasData(
                    new IdentityUserRole<string>
                    {
                        UserId = "09f1d0ca-181d-42fe-a015-6534acae8ed1",
                        RoleId = "42g2b8ve-232r-76ju-q432-8756refa9tg5"
                    },
                    new IdentityUserRole<string>
                    {
                        UserId = "42g3r3bu-434s-24qe-b120-3201ijia9ac0",
                        RoleId = "52f2b8ve-454t-88to-d286-9246pazo3yh8"
                    }
                );


            // Add point types to DB as PointType class
            builder.Entity<PointType>().HasData(
                new PointType { Id = 1, Name = "GYM" },
                new PointType { Id = 2, Name = "EX GYM" },
                new PointType { Id = 3, Name = "STOP" }
                );

            // Add points to DB as Point class
            builder.Entity<Point>().HasData(
                new Point { Id = 1, PointTypeId = 1, Latitude = 51.571050, Longitude = 4.999653, Title = "Stone benches playground" },
                new Point { Id = 2, PointTypeId = 1, Latitude = 51.593227, Longitude = 4.997713, Title = "Tilburg Landmerk" },
                new Point { Id = 3, PointTypeId = 1, Latitude = 51.584331, Longitude = 4.981893, Title = "Dragon Eating Fish" },
                new Point { Id = 4, PointTypeId = 1, Latitude = 51.580279, Longitude = 4.984198, Title = "Make it Count" },
                new Point { Id = 5, PointTypeId = 1, Latitude = 51.572661, Longitude = 4.996369, Title = "Zwaaiend Mannetje" },
                new Point { Id = 6, PointTypeId = 1, Latitude = 51.573772, Longitude = 4.993592, Title = "Station Tilburg Reeshof" },
                new Point { Id = 7, PointTypeId = 1, Latitude = 51.577547, Longitude = 5.004373, Title = "Social Sofa Heyhoef" },
                new Point { Id = 8, PointTypeId = 1, Latitude = 51.577840, Longitude = 5.006211, Title = "Feestornament Bij Winkelcentrum Heijhoef" },
                new Point { Id = 9, PointTypeId = 1, Latitude = 51.586196, Longitude = 5.015391, Title = "Caterpillar Climbing Structure" },
                new Point { Id = 10, PointTypeId = 1, Latitude = 51.589790, Longitude = 4.997072, Title = "Midwolde playground" },
                new Point { Id = 11, PointTypeId = 1, Latitude = 51.585734, Longitude = 4.997185, Title = "Peerkes Hoeve" },
                new Point { Id = 12, PointTypeId = 1, Latitude = 51.583528, Longitude = 5.021307, Title = "Hoops for 2" },
                new Point { Id = 13, PointTypeId = 1, Latitude = 51.582110, Longitude = 5.019341, Title = "Social Sofa Buurmalsenplein" },
                new Point { Id = 14, PointTypeId = 1, Latitude = 51.572761, Longitude = 5.001855, Title = "Voetbalveld SV Reeshof" },
                new Point { Id = 15, PointTypeId = 1, Latitude = 51.570308, Longitude = 5.010837, Title = "Art stones suburb Witbrand Oost" },
                new Point { Id = 16, PointTypeId = 1, Latitude = 51.581468, Longitude = 4.979233, Title = "Round And Round" },
                new Point { Id = 17, PointTypeId = 1, Latitude = 51.584361, Longitude = 4.975831, Title = "Skatepark Soerendonklaan" },
                new Point { Id = 18, PointTypeId = 1, Latitude = 51.592115, Longitude = 4.998011, Title = "Mini soccerfield Middelharnisstraat" },
                new Point { Id = 19, PointTypeId = 1, Latitude = 51.587993, Longitude = 5.006593, Title = "Basketbal Bijsterveldenlaan" },
                new Point { Id = 20, PointTypeId = 1, Latitude = 51.586467, Longitude = 5.014508, Title = "Sitting Room" },
                new Point { Id = 21, PointTypeId = 1, Latitude = 51.581321, Longitude = 5.014152, Title = "St. Antonius van Paduakerk - Emmausparochie Tilburg" },
                new Point { Id = 22, PointTypeId = 1, Latitude = 51.580924, Longitude = 5.023480, Title = "walking around" },
                new Point { Id = 23, PointTypeId = 1, Latitude = 51.577503, Longitude = 4.987057, Title = "Plekgedicht fietserbrug" },
                new Point { Id = 24, PointTypeId = 1, Latitude = 51.591195, Longitude = 4.979477, Title = "Playground Reeswoude" },
                new Point { Id = 25, PointTypeId = 1, Latitude = 51.595889, Longitude = 4.991992, Title = "Sluis Wilhelminakanaal" },
                new Point { Id = 26, PointTypeId = 1, Latitude = 51.587898, Longitude = 5.015182, Title = "historische kanaalbrug reeshof" },
                new Point { Id = 27, PointTypeId = 2, Latitude = 51.589204, Longitude = 5.0006230, Title = "Loosduinenhof playground" },
                new Point { Id = 28, PointTypeId = 2, Latitude = 51.585992, Longitude = 5.0055820, Title = "Up Mushroom" },
                new Point { Id = 29, PointTypeId = 2, Latitude = 51.584470, Longitude = 5.0003390, Title = "Playground Hoevelaken" },
                new Point { Id = 30, PointTypeId = 2, Latitude = 51.582931, Longitude = 4.9791770, Title = "Social Sofa Schipluidenlaan" },
                new Point { Id = 31, PointTypeId = 2, Latitude = 51.583696, Longitude = 4.9757150, Title = "JOP Dalemdreef" },
                new Point { Id = 32, PointTypeId = 2, Latitude = 51.594621, Longitude = 4.9880680, Title = "Speeltuin Munnikeburenstraat" },
                new Point { Id = 33, PointTypeId = 2, Latitude = 51.573764, Longitude = 4.9769480, Title = "Speeltuin Varsseveldstraat" },
                new Point { Id = 34, PointTypeId = 2, Latitude = 51.582295, Longitude = 4.9900770, Title = "Reeshofpark West" },
                new Point { Id = 35, PointTypeId = 2, Latitude = 51.578598, Longitude = 5.0016720, Title = "Reeshofpark Oost Ingang" },
                new Point { Id = 36, PointTypeId = 2, Latitude = 51.575617, Longitude = 5.0050460, Title = "Speeltuin Kortgenestraat" },
                new Point { Id = 37, PointTypeId = 2, Latitude = 51.580835, Longitude = 5.0191470, Title = "Play Area Fountain" },
                new Point { Id = 38, PointTypeId = 2, Latitude = 51.591950, Longitude = 4.9887510, Title = "Artpiece Around The World" },
                new Point { Id = 39, PointTypeId = 2, Latitude = 51.593154, Longitude = 4.983733, Title = "Speeltuin Metslawierstraat" },
                new Point { Id = 40, PointTypeId = 2, Latitude = 51.573016, Longitude = 5.020632, Title = "Reeshofbos Speelbos" },
                new Point { Id = 41, PointTypeId = 2, Latitude = 51.569810, Longitude = 5.0019200, Title = "Climbstone" },
                new Point { Id = 42, PointTypeId = 2, Latitude = 51.588607, Longitude = 4.9842530, Title = "Fietsersbrug Mariaradevonder" },
                new Point { Id = 43, PointTypeId = 2, Latitude = 51.587265, Longitude = 4.9829800, Title = "Rode Olifant Wip Op Speelplein" },
                new Point { Id = 44, PointTypeId = 2, Latitude = 51.578778, Longitude = 5.0217580, Title = "Wall Mural" },
                new Point { Id = 45, PointTypeId = 2, Latitude = 51.575765, Longitude = 5.0097520, Title = "Wooden Owl" },
                new Point { Id = 46, PointTypeId = 2, Latitude = 51.577442, Longitude = 4.9863010, Title = "Torenvalk Dongevallei" },
                new Point { Id = 47, PointTypeId = 2, Latitude = 51.576573, Longitude = 4.9808390, Title = "Rectangular Panoramic Window Art" },
                new Point { Id = 48, PointTypeId = 2, Latitude = 51.577924, Longitude = 4.9746570, Title = "Gudok" },
                new Point { Id = 49, PointTypeId = 2, Latitude = 51.579977, Longitude = 4.9955870, Title = "Geef Om Een Ander" },
                new Point { Id = 50, PointTypeId = 2, Latitude = 51.585421, Longitude = 5.0032240, Title = "Social Sofa Winnen doen we samen" },
                new Point { Id = 51, PointTypeId = 2, Latitude = 51.579651, Longitude = 5.0138340, Title = "Artpiece into the Sky" },
                new Point { Id = 52, PointTypeId = 2, Latitude = 51.576716, Longitude = 4.9943460, Title = "Sleepy Social Sofa" },
                new Point { Id = 53, PointTypeId = 2, Latitude = 51.577863, Longitude = 4.9948970, Title = "Social Sofa Beatrix College" },
                new Point { Id = 54, PointTypeId = 2, Latitude = 51.571268, Longitude = 4.9758530, Title = "Referee" },
                new Point { Id = 55, PointTypeId = 2, Latitude = 51.584276, Longitude = 4.9879180, Title = "Portrait Mural" },
                new Point { Id = 56, PointTypeId = 2, Latitude = 51.571213, Longitude = 4.9831200, Title = "Speeltuin Zelhemstraat" },
                new Point { Id = 57, PointTypeId = 2, Latitude = 51.594066, Longitude = 4.9808980, Title = "De Dongevallei" },
                new Point { Id = 58, PointTypeId = 2, Latitude = 51.579218, Longitude = 4.9987460, Title = "Charles Rey de Carle" },
                new Point { Id = 59, PointTypeId = 2, Latitude = 51.5692899, Longitude = 4.979325, Title = "Minispeeltuin In Vlagtwedde" },
                new Point { Id = 60, PointTypeId = 2, Latitude = 51.567764, Longitude = 5.01285, Title = "Social Sofa Abcoudestraat" },
                new Point { Id = 61, PointTypeId = 2, Latitude = 51.593249, Longitude = 4.991179, Title = "Blue Puppet" },
                new Point { Id = 62, PointTypeId = 2, Latitude = 51.601769, Longitude = 4.9769360, Title = "Burgemeester Letscherbrug" },
                new Point { Id = 63, PointTypeId = 2, Latitude = 51.583277, Longitude = 4.97809, Title = "Up and Down Structure" },
                new Point { Id = 64, PointTypeId = 3, Latitude = 51.567833, Longitude = 5.0048, Title = "De Gaas" },
                new Point { Id = 65, PointTypeId = 3, Latitude = 51.568917, Longitude = 5.005279, Title = "Mozaïc Bankje" },
                new Point { Id = 66, PointTypeId = 3, Latitude = 51.564747, Longitude = 4.99312, Title = "Fietskaart Oude Rielse Baan" },
                new Point { Id = 67, PointTypeId = 3, Latitude = 51.572658, Longitude = 4.996742, Title = "Men In Glass" },
                new Point { Id = 68, PointTypeId = 3, Latitude = 51.573432, Longitude = 4.993208, Title = "Vlinder Sociaal Sofa" },
                new Point { Id = 69, PointTypeId = 3, Latitude = 51.574131, Longitude = 4.993452, Title = "Social Sofa Stadsplein" },
                new Point { Id = 70, PointTypeId = 3, Latitude = 51.574183, Longitude = 4.993855, Title = "Social Sofa I Love Holland" },
                new Point { Id = 71, PointTypeId = 3, Latitude = 51.573430, Longitude = 4.989553, Title = "Wandelbord F -Koolhoven Buiten" },
                new Point { Id = 72, PointTypeId = 3, Latitude = 51.571456, Longitude = 4.986217, Title = "Wandelbord C Koolhoven Buiten" },
                new Point { Id = 73, PointTypeId = 3, Latitude = 51.573509, Longitude = 4.984356, Title = "Zaltbommelse Lange Klimtuin" },
                new Point { Id = 74, PointTypeId = 3, Latitude = 51.572036, Longitude = 4.981789, Title = "Speeltuin Koolhovenlaan" },
                new Point { Id = 75, PointTypeId = 3, Latitude = 51.574821, Longitude = 4.980721, Title = "Living Colors Playground" },
                new Point { Id = 76, PointTypeId = 3, Latitude = 51.574874, Longitude = 4.979432, Title = "Zonnewijzer" },
                new Point { Id = 77, PointTypeId = 3, Latitude = 51.571588, Longitude = 4.975593, Title = "Fluit Stoeltje" },
                new Point { Id = 78, PointTypeId = 3, Latitude = 51.575761, Longitude = 4.974634, Title = "Speeltuin Valkenswaard Vierhouten" },
                new Point { Id = 79, PointTypeId = 3, Latitude = 51.570232, Longitude = 4.971408, Title = "Speeltuin Camping Vlagtwedde" },
                new Point { Id = 80, PointTypeId = 3, Latitude = 51.577358, Longitude = 4.993688, Title = "Sporthal Dongewijk" },
                new Point { Id = 81, PointTypeId = 3, Latitude = 51.577732, Longitude = 4.993749, Title = "Minaret" },
                new Point { Id = 82, PointTypeId = 3, Latitude = 51.576907, Longitude = 4.997374, Title = "Playground Kralingenstraat" },
                new Point { Id = 83, PointTypeId = 3, Latitude = 51.575976, Longitude = 5.000216, Title = "Playground Kalkwijk" },
                new Point { Id = 84, PointTypeId = 3, Latitude = 51.578254, Longitude = 5.006089, Title = "Library Heyhoef" },
                new Point { Id = 85, PointTypeId = 3, Latitude = 51.577186, Longitude = 5.009482, Title = "Honing-Etende Beer Standbeeldje" },
                new Point { Id = 86, PointTypeId = 3, Latitude = 51.574677, Longitude = 5.008165, Title = "Eekhoorn" },
                new Point { Id = 87, PointTypeId = 3, Latitude = 51.573611, Longitude = 5.009166, Title = "Specht poeky" },
                new Point { Id = 88, PointTypeId = 3, Latitude = 51.574288, Longitude = 5.01216, Title = "Konijnen HOST" },
                new Point { Id = 89, PointTypeId = 3, Latitude = 51.573333, Longitude = 5.013333, Title = "vos poeky" },
                new Point { Id = 90, PointTypeId = 3, Latitude = 51.574619, Longitude = 5.014209, Title = "Reeshofbos Noord" },
                new Point { Id = 91, PointTypeId = 3, Latitude = 51.573054, Longitude = 5.019399, Title = "Reeshofbos Oost" },
                new Point { Id = 92, PointTypeId = 3, Latitude = 51.580352, Longitude = 5.005684, Title = "Kwiek Beweegroute (Heerenveldendreef)" },
                new Point { Id = 93, PointTypeId = 3, Latitude = 51.579053, Longitude = 5.006022, Title = "Sportcentrum Tilburg Reeshof" },
                new Point { Id = 94, PointTypeId = 3, Latitude = 51.581089, Longitude = 5.006653, Title = "Reeshof Huibeven" },
                new Point { Id = 95, PointTypeId = 3, Latitude = 51.584384, Longitude = 5.009231, Title = "Zinloos" },
                new Point { Id = 96, PointTypeId = 3, Latitude = 51.585058, Longitude = 5.011673, Title = "Speeltuintje Aan Biervlietplein" },
                new Point { Id = 97, PointTypeId = 3, Latitude = 51.587898, Longitude = 5.015182, Title = "historische kanaalbrug reeshof" },
                new Point { Id = 98, PointTypeId = 3, Latitude = 51.581683, Longitude = 5.0127, Title = "Playground Groenlo" },
                new Point { Id = 99, PointTypeId = 3, Latitude = 51.579199, Longitude = 5.013053, Title = "Playground Huibeven" },
                new Point { Id = 100, PointTypeId = 3, Latitude = 51.583465, Longitude = 5.014754, Title = "Batenburg Playground" },
                new Point { Id = 101, PointTypeId = 3, Latitude = 51.580726, Longitude = 5.014914, Title = "Social Sofa Helen Parkhurst" },
                new Point { Id = 102, PointTypeId = 3, Latitude = 51.584711, Longitude = 5.017424, Title = "Playground Besoijenstraat" },
                new Point { Id = 103, PointTypeId = 3, Latitude = 51.583251, Longitude = 5.019935, Title = "Gedenksteen Plan Reeshof" },
                new Point { Id = 104, PointTypeId = 3, Latitude = 51.582746, Longitude = 5.020071, Title = "Smile" },
                new Point { Id = 105, PointTypeId = 3, Latitude = 51.582460, Longitude = 5.019324, Title = "Colorful Caterpillar Portal Buurmalsenplein" },
                new Point { Id = 106, PointTypeId = 3, Latitude = 51.581150, Longitude = 5.01875, Title = "Children Times Ten Portal" },
                new Point { Id = 107, PointTypeId = 3, Latitude = 51.580401, Longitude = 5.018033, Title = "Bloemenbankje" },
                new Point { Id = 108, PointTypeId = 3, Latitude = 51.578484, Longitude = 5.018141, Title = "Playground Dwingelo" },
                new Point { Id = 109, PointTypeId = 3, Latitude = 51.577096, Longitude = 5.0196, Title = "Totem Palen" },
                new Point { Id = 110, PointTypeId = 3, Latitude = 51.582899, Longitude = 5.027767, Title = "R'hof Beam Bridge for Bikes" },
                new Point { Id = 111, PointTypeId = 3, Latitude = 51.597409, Longitude = 4.984477, Title = "Playground Mijnden" },
                new Point { Id = 112, PointTypeId = 3, Latitude = 51.597162, Longitude = 4.989306, Title = "Voldijkbrug" },
                new Point { Id = 113, PointTypeId = 3, Latitude = 51.595949, Longitude = 4.989577, Title = "Pole Art Menaldumstraat" },
                new Point { Id = 114, PointTypeId = 3, Latitude = 51.593144, Longitude = 4.991849, Title = "Pole Art Mosselhoekplein" },
                new Point { Id = 115, PointTypeId = 3, Latitude = 51.594756, Longitude = 4.994742, Title = "Poles 2" },
                new Point { Id = 116, PointTypeId = 3, Latitude = 51.593877, Longitude = 4.9978, Title = "Rivier Brug" },
                new Point { Id = 117, PointTypeId = 3, Latitude = 51.591600, Longitude = 4.997831, Title = "Kids Delight" },
                new Point { Id = 118, PointTypeId = 3, Latitude = 51.585491, Longitude = 4.977462, Title = "Playground Randwijkstraat" },
                new Point { Id = 119, PointTypeId = 3, Latitude = 51.587897, Longitude = 4.978295, Title = "Playground Ruimelsingel" },
                new Point { Id = 120, PointTypeId = 3, Latitude = 51.585265, Longitude = 4.978234, Title = "Heart Statue" },
                new Point { Id = 121, PointTypeId = 3, Latitude = 51.585315, Longitude = 4.981014, Title = "Speeltuin Ridderkerkerf" },
                new Point { Id = 122, PointTypeId = 3, Latitude = 51.590315, Longitude = 4.982053, Title = "Playground Ruitenveenstraat" },
                new Point { Id = 123, PointTypeId = 3, Latitude = 51.590962, Longitude = 4.984301, Title = "Puzzle Play" },
                new Point { Id = 124, PointTypeId = 3, Latitude = 51.591608, Longitude = 4.985709, Title = "Slinger De Slurf" },
                new Point { Id = 125, PointTypeId = 3, Latitude = 51.589005, Longitude = 4.983711, Title = "Informatiebord Natuurgebied De Dongevallei" },
                new Point { Id = 126, PointTypeId = 3, Latitude = 51.589082, Longitude = 4.984846, Title = "Diving duck plate" },
                new Point { Id = 127, PointTypeId = 3, Latitude = 51.588795, Longitude = 4.98695, Title = "Little Playground Bijsterveldenlaan" },
                new Point { Id = 128, PointTypeId = 3, Latitude = 51.587298, Longitude = 4.983963, Title = "Sprinkhanen" },
                new Point { Id = 129, PointTypeId = 3, Latitude = 51.586278, Longitude = 4.983531, Title = "Informatiebord: Brandnetel" },
                new Point { Id = 130, PointTypeId = 3, Latitude = 51.585685, Longitude = 4.984162, Title = "Informatiebord: Distel Bloem" },
                new Point { Id = 131, PointTypeId = 3, Latitude = 51.585178, Longitude = 4.984354, Title = "Dongevallei Ridderkerksingel" },
                new Point { Id = 132, PointTypeId = 3, Latitude = 51.584398, Longitude = 4.984302, Title = "Informatiebord: Watervogels" },
                new Point { Id = 133, PointTypeId = 3, Latitude = 51.583413, Longitude = 4.980318, Title = "Playground Schipluidenlaan" },
                new Point { Id = 134, PointTypeId = 3, Latitude = 51.579218, Longitude = 4.978156, Title = "Four Ribs" },
                new Point { Id = 135, PointTypeId = 3, Latitude = 51.583113, Longitude = 4.984474, Title = "Stengels" },
                new Point { Id = 136, PointTypeId = 3, Latitude = 51.581426, Longitude = 4.988705, Title = "Color Playground" },
                new Point { Id = 137, PointTypeId = 3, Latitude = 51.579936, Longitude = 4.98401, Title = "Nature Graffiti" },
                new Point { Id = 138, PointTypeId = 3, Latitude = 51.579666, Longitude = 4.984901, Title = "Vierteenschildpad" },
                new Point { Id = 139, PointTypeId = 3, Latitude = 51.579474, Longitude = 4.98768, Title = "Fietsersbrug Sneekpad" },
                new Point { Id = 140, PointTypeId = 3, Latitude = 51.578920, Longitude = 4.990202, Title = "Speeltuin Ossendrechtstraat" },
                new Point { Id = 141, PointTypeId = 3, Latitude = 51.576032, Longitude = 4.982187, Title = "Playground Reeshof Krajicek" },
                new Point { Id = 142, PointTypeId = 3, Latitude = 51.576399, Longitude = 4.982922, Title = "Hulky Face Mural" },
                new Point { Id = 143, PointTypeId = 3, Latitude = 51.576121, Longitude = 4.985526, Title = "Verlanding" },
                new Point { Id = 144, PointTypeId = 3, Latitude = 51.590229, Longitude = 4.993526, Title = "Speeltuin Margratenplein" },
                new Point { Id = 145, PointTypeId = 3, Latitude = 51.589090, Longitude = 4.991449, Title = "Playground On Hill" },
                new Point { Id = 146, PointTypeId = 3, Latitude = 51.588015, Longitude = 4.990358, Title = "Sun is Time" },
                new Point { Id = 147, PointTypeId = 3, Latitude = 51.586033, Longitude = 4.989813, Title = "Playground Nieuwkoopplein" },
                new Point { Id = 148, PointTypeId = 3, Latitude = 51.585521, Longitude = 4.997019, Title = "Peerkes Playground" },
                new Point { Id = 149, PointTypeId = 3, Latitude = 51.582983, Longitude = 4.997967, Title = "Playground Heteren" },
                new Point { Id = 150, PointTypeId = 3, Latitude = 51.587917, Longitude = 4.999111, Title = "Luijkgestel playground" },
                new Point { Id = 151, PointTypeId = 3, Latitude = 51.588255, Longitude = 5.002622, Title = "Lothumse playground" },
                new Point { Id = 152, PointTypeId = 3, Latitude = 51.586473, Longitude = 5.003745, Title = "Speeltuin Lochemstraat" },
                new Point { Id = 153, PointTypeId = 3, Latitude = 51.585681, Longitude = 5.003661, Title = "The Jagged Wall" },
                new Point { Id = 154, PointTypeId = 3, Latitude = 51.583984, Longitude = 5.002991, Title = "Playground Holten" },
                new Point { Id = 155, PointTypeId = 3, Latitude = 51.583404, Longitude = 5.005304, Title = "Playground Hulsberg" },
                new Point { Id = 156, PointTypeId = 3, Latitude = 51.582373, Longitude = 5.003197, Title = "Playground Hontenisse" },
                new Point { Id = 157, PointTypeId = 3, Latitude = 51.580175, Longitude = 5.003827, Title = "Playground Horn" },
                new Point { Id = 158, PointTypeId = 3, Latitude = 51.582487, Longitude = 4.991772, Title = "Move Your Body" },
                new Point { Id = 159, PointTypeId = 3, Latitude = 51.582084, Longitude = 4.995348, Title = "Skate Park" },
                new Point { Id = 160, PointTypeId = 3, Latitude = 51.582203, Longitude = 4.996103, Title = "Reeshofpark Noord ingang" },
                new Point { Id = 161, PointTypeId = 3, Latitude = 51.581264, Longitude = 4.99622, Title = "Stop De Bende art" },
                new Point { Id = 162, PointTypeId = 3, Latitude = 51.580224, Longitude = 4.998361, Title = "The Big Circle" },
                new Point { Id = 163, PointTypeId = 3, Latitude = 51.579176, Longitude = 4.999629, Title = "Cruyff Court" },
                new Point { Id = 164, PointTypeId = 3, Latitude = 51.579018, Longitude = 5.000336, Title = "Basketbalveld" },
                new Point { Id = 165, PointTypeId = 3, Latitude = 51.579012, Longitude = 4.997166, Title = "Reeshofpark Zuid" },
                new Point { Id = 166, PointTypeId = 3, Latitude = 51.579021, Longitude = 4.996142, Title = "Speeltuin Reeshofpark" },
                new Point { Id = 167, PointTypeId = 3, Latitude = 51.579201, Longitude = 4.995208, Title = "Fietsroutenetwerk midden Brabant Knooppunt 56" },
                new Point { Id = 168, PointTypeId = 3, Latitude = 51.571721, Longitude = 5.00148, Title = "Playground koewachtpad" },
                new Point { Id = 169, PointTypeId = 3, Latitude = 51.571887, Longitude = 4.99706, Title = "Playground Wijboschstraat" },
                new Point { Id = 170, PointTypeId = 3, Latitude = 51.575216, Longitude = 4.992529, Title = "Speeltuin Obdamstraat" },
                new Point { Id = 171, PointTypeId = 3, Latitude = 51.575681, Longitude = 4.989648, Title = "Speeltuin Ockenburg" },
                new Point { Id = 172, PointTypeId = 3, Latitude = 51.577061, Longitude = 4.977906, Title = "Wip en hobbelpaard" },
                new Point { Id = 173, PointTypeId = 3, Latitude = 51.579949, Longitude = 4.976001, Title = "Betonnen tafeltennistafel" },
                new Point { Id = 174, PointTypeId = 3, Latitude = 51.583273, Longitude = 4.982675, Title = "Wooden Playground" },
                new Point { Id = 175, PointTypeId = 3, Latitude = 51.593374, Longitude = 4.987205, Title = "Playground Mingersbergstraat" },
                new Point { Id = 176, PointTypeId = 3, Latitude = 51.595096, Longitude = 4.985766, Title = "Speeltuin Midslandstraat" },
                new Point { Id = 177, PointTypeId = 3, Latitude = 51.579021, Longitude = 4.996142, Title = "Three Tol Playground" },
                new Point { Id = 178, PointTypeId = 3, Latitude = 51.596153, Longitude = 4.986827, Title = "Hangaround" },
                new Point { Id = 179, PointTypeId = 3, Latitude = 51.579021, Longitude = 4.996142, Title = "Speeltuin Reeshofpark" },
                new Point { Id = 180, PointTypeId = 3, Latitude = 51.571434, Longitude = 4.999605, Title = "Kabelbaan Witbrand" },
                new Point { Id = 181, PointTypeId = 3, Latitude = 51.570639, Longitude = 4.970402, Title = "Minibieb Vlodropstraat" },
                new Point { Id = 182, PointTypeId = 3, Latitude = 51.573785, Longitude = 4.971201, Title = "Plattegrond Reeshof" },
                new Point { Id = 183, PointTypeId = 3, Latitude = 51.577061, Longitude = 4.977906, Title = "Wip en hobbelpaard" },
                new Point { Id = 184, PointTypeId = 3, Latitude = 51.582214, Longitude = 4.976821, Title = "Goals!!!!" },
                new Point { Id = 185, PointTypeId = 3, Latitude = 51.582544, Longitude = 4.982361, Title = "Kids playground" },
                new Point { Id = 186, PointTypeId = 3, Latitude = 51.592044, Longitude = 4.982904, Title = "Gele wipkip." },
                new Point { Id = 187, PointTypeId = 3, Latitude = 51.593058, Longitude = 4.981566, Title = "Playground Marlestraat" },
                new Point { Id = 188, PointTypeId = 3, Latitude = 51.594917, Longitude = 4.983353, Title = "3 red Puppets" },
                new Point { Id = 189, PointTypeId = 3, Latitude = 51.583715, Longitude = 4.999136, Title = "Heerevelden" },
                new Point { Id = 190, PointTypeId = 3, Latitude = 51.568954, Longitude = 4.986304, Title = "Wandelbord C Koolhoven Buiten" },
                new Point { Id = 191, PointTypeId = 3, Latitude = 51.570478, Longitude = 4.996646, Title = "Jeu de boules Witbrant West" },
                new Point { Id = 192, PointTypeId = 3, Latitude = 51.570585, Longitude = 5.002324, Title = "Stone Pingpong Table Witbrant West" },
                new Point { Id = 193, PointTypeId = 3, Latitude = 51.569203, Longitude = 5.006945, Title = "Natural Soccer Playground" },
                new Point { Id = 194, PointTypeId = 3, Latitude = 51.569820, Longitude = 5.008732, Title = "Kabelbaan Witbrant Oost" },
                new Point { Id = 195, PointTypeId = 3, Latitude = 51.569142, Longitude = 5.010785, Title = "Jeux de Boule Witbrant Oost" },
                new Point { Id = 196, PointTypeId = 3, Latitude = 51.568627, Longitude = 5.011452, Title = "Playground Witbrant Oost" },
                new Point { Id = 197, PointTypeId = 3, Latitude = 51.568587, Longitude = 5.013424, Title = "Stone PingPong Table Witbrant Oost" },
                new Point { Id = 198, PointTypeId = 3, Latitude = 51.568734, Longitude = 5.013771, Title = "Wooden Play Structure" },
                new Point { Id = 199, PointTypeId = 3, Latitude = 51.574781, Longitude = 4.997187, Title = "Playground Knegselstraat" },
                new Point { Id = 200, PointTypeId = 3, Latitude = 51.574323, Longitude = 5.000119, Title = "Playground Kalkwijkstraat" },
                new Point { Id = 201, PointTypeId = 3, Latitude = 51.577824, Longitude = 4.992885, Title = "Playground Overlangelstraat" },
                new Point { Id = 202, PointTypeId = 3, Latitude = 51.576553, Longitude = 4.977568, Title = "Fietskaart Tilburg" },
                new Point { Id = 203, PointTypeId = 3, Latitude = 51.579008, Longitude = 4.979299, Title = "Klimtoestel" },
                new Point { Id = 204, PointTypeId = 3, Latitude = 51.579246, Longitude = 4.975937, Title = "De 3 rekstokjes" },
                new Point { Id = 205, PointTypeId = 3, Latitude = 51.583317, Longitude = 4.981119, Title = "Lets play football" },
                new Point { Id = 206, PointTypeId = 3, Latitude = 51.585925, Longitude = 4.978531, Title = "Schommelding Ruimelplein" },
                new Point { Id = 207, PointTypeId = 3, Latitude = 51.595220, Longitude = 4.991473, Title = "Spying Man" },
                new Point { Id = 208, PointTypeId = 3, Latitude = 51.589413, Longitude = 4.995002, Title = "Playground Moerdijkerf" },
                new Point { Id = 209, PointTypeId = 3, Latitude = 51.588161, Longitude = 4.99441, Title = "Voetbalveldje Maalbergenpad" },
                new Point { Id = 210, PointTypeId = 3, Latitude = 51.584968, Longitude = 4.996101, Title = "Voetbalveldje Nootdorpstraat" },
                new Point { Id = 211, PointTypeId = 3, Latitude = 51.588275, Longitude = 5.005894, Title = "Voetbalveld Bijsterveldenlaan" },
                new Point { Id = 212, PointTypeId = 3, Latitude = 51.586226, Longitude = 5.013568, Title = "Playground Besoijenpad" },
                new Point { Id = 213, PointTypeId = 3, Latitude = 51.585743, Longitude = 5.014984, Title = "Voetbalveld Besoijenpad" },
                new Point { Id = 214, PointTypeId = 3, Latitude = 51.578273, Longitude = 5.012451, Title = "Voetbalveld Huibenvenpark" },
                new Point { Id = 215, PointTypeId = 3, Latitude = 51.580472, Longitude = 5.024175, Title = "insectenhotel" },
                new Point { Id = 216, PointTypeId = 3, Latitude = 51.580417, Longitude = 5.006565, Title = "Social Sofa Hipo" },
                new Point { Id = 217, PointTypeId = 3, Latitude = 51.576075, Longitude = 4.998967, Title = "De roestuil" },
                new Point { Id = 218, PointTypeId = 3, Latitude = 51.575354, Longitude = 4.978168, Title = "Playground Voerendaalstraat" },
                new Point { Id = 219, PointTypeId = 3, Latitude = 51.573928, Longitude = 5.002984, Title = "Playground Krommeniestraat" },
                new Point { Id = 220, PointTypeId = 3, Latitude = 51.574394, Longitude = 5.006322, Title = "Reeshofbos map" },
                new Point { Id = 221, PointTypeId = 3, Latitude = 51.582393, Longitude = 5.007127, Title = "Kwiek Beweegroute (Gendringenlaan)" },
                new Point { Id = 222, PointTypeId = 3, Latitude = 51.579460, Longitude = 5.007133, Title = "Zwembad Reeshof" },
                new Point { Id = 223, PointTypeId = 3, Latitude = 51.592856, Longitude = 5.001417, Title = "CA bridge." },
                new Point { Id = 224, PointTypeId = 3, Latitude = 51.573861, Longitude = 4.986245, Title = "Zoek de Beer!" },
                new Point { Id = 225, PointTypeId = 3, Latitude = 51.573048, Longitude = 4.97473, Title = "Speelhoek Koolhovenlaan" },
                new Point { Id = 226, PointTypeId = 3, Latitude = 51.581290, Longitude = 4.979945, Title = "Klimmen en klauteren" },
                new Point { Id = 227, PointTypeId = 3, Latitude = 51.583455, Longitude = 4.973944, Title = "Glijbaan in het park" },
                new Point { Id = 228, PointTypeId = 3, Latitude = 51.591513, Longitude = 4.978253, Title = "Playground Ravensteinerf" },
                new Point { Id = 229, PointTypeId = 3, Latitude = 51.599911, Longitude = 4.979389, Title = "Rustplaats Wilhelminakanaal" },
                new Point { Id = 230, PointTypeId = 3, Latitude = 51.583753, Longitude = 4.991934, Title = "Rode Maanwippert" },
                new Point { Id = 231, PointTypeId = 3, Latitude = 51.578288, Longitude = 4.990242, Title = "Voetbalveld Ossendrecht" },
                new Point { Id = 232, PointTypeId = 3, Latitude = 51.595931, Longitude = 4.990559, Title = "Mini soccerfield menaldumstraat" },
                new Point { Id = 233, PointTypeId = 3, Latitude = 51.595931, Longitude = 4.990559, Title = "Mini soccerfield menaldumstraat" },
                new Point { Id = 234, PointTypeId = 3, Latitude = 51.583890, Longitude = 5.016571, Title = "Wipstoel Pacman" }
            );


            //// seeding          
            //builder.Entity<IdentityRole>().HasData(
            //    new IdentityRole
            //    {
            //        Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
            //        Name = "Administrator",
            //        NormalizedName = "ADMINISTRATOR".ToUpper()
            //    },
            //    new IdentityRole
            //    {
            //        Id = "2c5e174e-3b0e-446f-86af-483d56fd7211",
            //        Name = "waypointmanager",
            //        NormalizedName = "waypointmanager".ToUpper()
            //    }
            //    );

            ////a hasher to hash the password before seeding the user to the db
            ////var hasher = new PasswordHasher<IdentityUser>();

            ////Seeding the User to AspNetUsers table
            //builder.Entity<IdentityUser>().HasData(
            //    new IdentityUser
            //    {
            //        Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
            //        UserName = "isaac@poke.nl",
            //        NormalizedUserName = "ISAAC@POKE.NL",
            //        NormalizedEmail = "ISAAC@POKE.NL",
            //        PasswordHash = hasher.HashPassword(null, "Pa$$w0rd"),
            //        Email = "isaac@poke.nl",
            //        EmailConfirmed = true,
            //        LockoutEnabled = true
            //    },
            //    new IdentityUser
            //    {
            //        Id = "8e445865-a24d-4543-a6c6-9443d048cdc8", // primary key
            //        UserName = "john@poke.nl",
            //        NormalizedUserName = "JOHN@POKE.NL",
            //        NormalizedEmail = "JOHN@POKE.NL",
            //        PasswordHash = hasher.HashPassword(null, "Pa$$w0rd"),
            //        Email = "john@poke.nl",
            //        EmailConfirmed = true,
            //        LockoutEnabled = true
            //    }
            //);


            ////Seeding the relation between our user and role to AspNetUserRoles table
            //builder.Entity<IdentityUserRole<string>>().HasData(
            //    new IdentityUserRole<string>
            //    {
            //        RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
            //        UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
            //    },
            //     new IdentityUserRole<string>
            //     {
            //         RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7211",
            //         UserId = "8e445865-a24d-4543-a6c6-9443d048cdc8"
            //     },
            //      new IdentityUserRole<string>
            //      {
            //          RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7212",
            //          UserId = "8e445865-a24d-4543-a6c6-9443d048cdd7"
            //      }
            //);





        }
    }
}
