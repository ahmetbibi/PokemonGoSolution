using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PokemonGo.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PointType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    PointTypeId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Points_PointType_PointTypeId",
                        column: x => x.PointTypeId,
                        principalTable: "PointType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "42g2b8ve-232r-76ju-q432-8756refa9tg5", "0ea7ff26-8d8e-4bbc-aea2-993a1bdd261f", "Admin", "ADMIN" },
                    { "52f2b8ve-454t-88to-d286-9246pazo3yh8", "2463f7a6-7df5-429a-a360-452fd11586ac", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "09f1d0ca-181d-42fe-a015-6534acae8ed1", 0, "ee7a2a2b-e481-4730-8cc9-1dc8f9dd6237", "admin@pogoreeshof.nl", true, true, null, "ADMIN@POGOREESHOF.NL", "ADMIN@POGOREESHOF.NL", "AQAAAAEAACcQAAAAEBuf27pyvZdJ6aaQzmKdTbL0Jzs2zl6R0Yv2BGmGx4tYh8XHon9fECpK0q61XC/dlA==", null, false, "c3d24cf4-fcda-4cc5-87d3-4a3ea38774a8", false, "Admin" },
                    { "42g3r3bu-434s-24qe-b120-3201ijia9ac0", 0, "fc609269-0994-420f-aff7-58140beab168", "manager@pogoreeshof.nl", true, true, null, "MANAGER@POGOREESHOF.NL", "MANAGER@POGOREESHOF.NL", "AQAAAAEAACcQAAAAEP/x3AsuC7sufetPqbBLVpj9gdNC6VfeyYHRyzZ2NUT7iagypOE7DVT936fcUYpr2Q==", null, false, "8fbf5c24-a0fe-42d7-9cc2-9bde755755b4", false, "Manager" }
                });

            migrationBuilder.InsertData(
                table: "PointType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "GYM" },
                    { 2, "EX GYM" },
                    { 3, "STOP" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "42g2b8ve-232r-76ju-q432-8756refa9tg5", "09f1d0ca-181d-42fe-a015-6534acae8ed1" },
                    { "52f2b8ve-454t-88to-d286-9246pazo3yh8", "42g3r3bu-434s-24qe-b120-3201ijia9ac0" }
                });

            migrationBuilder.InsertData(
                table: "Points",
                columns: new[] { "Id", "CreatedAt", "Latitude", "Longitude", "PointTypeId", "Title" },
                values: new object[,]
                {
                    { 149, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3870), 51.582982999999999, 4.997967, 3, "Playground Heteren" },
                    { 150, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3874), 51.587916999999997, 4.9991110000000001, 3, "Luijkgestel playground" },
                    { 151, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3879), 51.588254999999997, 5.0026219999999997, 3, "Lothumse playground" },
                    { 152, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3885), 51.586472999999998, 5.0037450000000003, 3, "Speeltuin Lochemstraat" },
                    { 153, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3889), 51.585681000000001, 5.0036610000000001, 3, "The Jagged Wall" },
                    { 154, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3892), 51.583984000000001, 5.0029909999999997, 3, "Playground Holten" },
                    { 155, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3896), 51.583404000000002, 5.0053039999999998, 3, "Playground Hulsberg" },
                    { 156, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3900), 51.582372999999997, 5.0031970000000001, 3, "Playground Hontenisse" },
                    { 157, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3904), 51.580174999999997, 5.0038270000000002, 3, "Playground Horn" },
                    { 158, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3909), 51.582487, 4.9917720000000001, 3, "Move Your Body" },
                    { 159, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3913), 51.582084000000002, 4.9953479999999999, 3, "Skate Park" },
                    { 160, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3918), 51.582203, 4.9961029999999997, 3, "Reeshofpark Noord ingang" },
                    { 161, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3922), 51.581263999999997, 4.9962200000000001, 3, "Stop De Bende art" },
                    { 162, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3927), 51.580224000000001, 4.9983610000000001, 3, "The Big Circle" },
                    { 163, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3931), 51.579175999999997, 4.9996289999999997, 3, "Cruyff Court" },
                    { 164, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3938), 51.579017999999998, 5.0003359999999999, 3, "Basketbalveld" },
                    { 165, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3942), 51.579011999999999, 4.997166, 3, "Reeshofpark Zuid" },
                    { 166, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3946), 51.579020999999997, 4.9961419999999999, 3, "Speeltuin Reeshofpark" },
                    { 167, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3951), 51.579200999999998, 4.9952079999999999, 3, "Fietsroutenetwerk midden Brabant Knooppunt 56" },
                    { 168, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3955), 51.571720999999997, 5.0014799999999999, 3, "Playground koewachtpad" },
                    { 169, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3960), 51.571886999999997, 4.9970600000000003, 3, "Playground Wijboschstraat" },
                    { 170, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3965), 51.575215999999998, 4.9925290000000002, 3, "Speeltuin Obdamstraat" },
                    { 171, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3970), 51.575681000000003, 4.9896479999999999, 3, "Speeltuin Ockenburg" },
                    { 172, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3975), 51.577061, 4.9779059999999999, 3, "Wip en hobbelpaard" },
                    { 173, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3980), 51.579948999999999, 4.9760010000000001, 3, "Betonnen tafeltennistafel" },
                    { 148, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3864), 51.585521, 4.9970189999999999, 3, "Peerkes Playground" },
                    { 147, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3860), 51.586033, 4.9898129999999998, 3, "Playground Nieuwkoopplein" },
                    { 146, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3855), 51.588014999999999, 4.9903579999999996, 3, "Sun is Time" },
                    { 145, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3851), 51.589089999999999, 4.9914490000000002, 3, "Playground On Hill" },
                    { 119, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3731), 51.587896999999998, 4.9782950000000001, 3, "Playground Ruimelsingel" },
                    { 120, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3735), 51.585265, 4.9782339999999996, 3, "Heart Statue" },
                    { 121, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3740), 51.585315000000001, 4.9810140000000001, 3, "Speeltuin Ridderkerkerf" },
                    { 122, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3744), 51.590314999999997, 4.9820529999999996, 3, "Playground Ruitenveenstraat" },
                    { 123, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3749), 51.590961999999998, 4.9843010000000003, 3, "Puzzle Play" },
                    { 124, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3753), 51.591608000000001, 4.9857089999999999, 3, "Slinger De Slurf" },
                    { 125, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3758), 51.589005, 4.9837109999999996, 3, "Informatiebord Natuurgebied De Dongevallei" },
                    { 126, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3762), 51.589081999999998, 4.9848460000000001, 3, "Diving duck plate" },
                    { 127, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3767), 51.588794999999998, 4.9869500000000002, 3, "Little Playground Bijsterveldenlaan" },
                    { 128, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3772), 51.587297999999997, 4.9839630000000001, 3, "Sprinkhanen" },
                    { 129, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3777), 51.586278, 4.9835310000000002, 3, "Informatiebord: Brandnetel" }
                });

            migrationBuilder.InsertData(
                table: "Points",
                columns: new[] { "Id", "CreatedAt", "Latitude", "Longitude", "PointTypeId", "Title" },
                values: new object[,]
                {
                    { 130, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3781), 51.585684999999998, 4.9841620000000004, 3, "Informatiebord: Distel Bloem" },
                    { 174, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3984), 51.583272999999998, 4.9826750000000004, 3, "Wooden Playground" },
                    { 131, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3786), 51.585177999999999, 4.9843539999999997, 3, "Dongevallei Ridderkerksingel" },
                    { 133, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3795), 51.583413, 4.9803179999999996, 3, "Playground Schipluidenlaan" },
                    { 134, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3799), 51.579217999999997, 4.9781560000000002, 3, "Four Ribs" },
                    { 135, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3804), 51.583112999999997, 4.9844739999999996, 3, "Stengels" },
                    { 136, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3808), 51.581426, 4.9887050000000004, 3, "Color Playground" },
                    { 137, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3812), 51.579935999999996, 4.9840099999999996, 3, "Nature Graffiti" },
                    { 138, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3817), 51.579666000000003, 4.9849009999999998, 3, "Vierteenschildpad" },
                    { 139, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3821), 51.579473999999998, 4.9876800000000001, 3, "Fietsersbrug Sneekpad" },
                    { 140, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3826), 51.578919999999997, 4.990202, 3, "Speeltuin Ossendrechtstraat" },
                    { 141, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3832), 51.576031999999998, 4.9821869999999997, 3, "Playground Reeshof Krajicek" },
                    { 142, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3836), 51.576399000000002, 4.9829220000000003, 3, "Hulky Face Mural" },
                    { 143, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3841), 51.576121000000001, 4.9855260000000001, 3, "Verlanding" },
                    { 144, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3845), 51.590229000000001, 4.9935260000000001, 3, "Speeltuin Margratenplein" },
                    { 132, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3790), 51.584398, 4.9843019999999996, 3, "Informatiebord: Watervogels" },
                    { 175, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3989), 51.593373999999997, 4.9872050000000003, 3, "Playground Mingersbergstraat" },
                    { 176, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3993), 51.595095999999998, 4.9857659999999999, 3, "Speeltuin Midslandstraat" },
                    { 177, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3997), 51.579020999999997, 4.9961419999999999, 3, "Three Tol Playground" },
                    { 208, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4193), 51.589413, 4.9950020000000004, 3, "Playground Moerdijkerf" },
                    { 209, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4197), 51.588160999999999, 4.9944100000000002, 3, "Voetbalveldje Maalbergenpad" },
                    { 210, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4202), 51.584968000000003, 4.9961010000000003, 3, "Voetbalveldje Nootdorpstraat" },
                    { 211, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4206), 51.588275000000003, 5.0058939999999996, 3, "Voetbalveld Bijsterveldenlaan" },
                    { 212, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4210), 51.586226000000003, 5.0135680000000002, 3, "Playground Besoijenpad" },
                    { 213, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4215), 51.585743000000001, 5.0149840000000001, 3, "Voetbalveld Besoijenpad" },
                    { 214, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4220), 51.578273000000003, 5.0124510000000004, 3, "Voetbalveld Huibenvenpark" },
                    { 215, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4225), 51.580472, 5.0241749999999996, 3, "insectenhotel" },
                    { 216, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4229), 51.580416999999997, 5.0065650000000002, 3, "Social Sofa Hipo" },
                    { 217, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4233), 51.576075000000003, 4.9989670000000004, 3, "De roestuil" },
                    { 218, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4237), 51.575353999999997, 4.9781680000000001, 3, "Playground Voerendaalstraat" },
                    { 219, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4241), 51.573928000000002, 5.0029839999999997, 3, "Playground Krommeniestraat" },
                    { 220, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4244), 51.574393999999998, 5.0063219999999999, 3, "Reeshofbos map" },
                    { 221, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4248), 51.582393000000003, 5.0071269999999997, 3, "Kwiek Beweegroute (Gendringenlaan)" },
                    { 222, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4253), 51.579459999999997, 5.0071329999999996, 3, "Zwembad Reeshof" },
                    { 223, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4257), 51.592855999999998, 5.001417, 3, "CA bridge." },
                    { 224, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4262), 51.573861000000001, 4.9862450000000003, 3, "Zoek de Beer!" },
                    { 225, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4266), 51.573048, 4.9747300000000001, 3, "Speelhoek Koolhovenlaan" },
                    { 226, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4271), 51.581290000000003, 4.9799449999999998, 3, "Klimmen en klauteren" },
                    { 227, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4276), 51.583455000000001, 4.9739440000000004, 3, "Glijbaan in het park" },
                    { 228, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4280), 51.591512999999999, 4.9782529999999996, 3, "Playground Ravensteinerf" },
                    { 229, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4285), 51.599910999999999, 4.9793890000000003, 3, "Rustplaats Wilhelminakanaal" },
                    { 230, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4290), 51.583753000000002, 4.9919339999999996, 3, "Rode Maanwippert" }
                });

            migrationBuilder.InsertData(
                table: "Points",
                columns: new[] { "Id", "CreatedAt", "Latitude", "Longitude", "PointTypeId", "Title" },
                values: new object[,]
                {
                    { 231, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4295), 51.578288000000001, 4.9902420000000003, 3, "Voetbalveld Ossendrecht" },
                    { 232, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4300), 51.595931, 4.9905590000000002, 3, "Mini soccerfield menaldumstraat" },
                    { 207, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4189), 51.595219999999998, 4.991473, 3, "Spying Man" },
                    { 206, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4183), 51.585925000000003, 4.9785310000000003, 3, "Schommelding Ruimelplein" },
                    { 205, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4179), 51.583317000000001, 4.9811189999999996, 3, "Lets play football" },
                    { 204, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4175), 51.579245999999998, 4.9759370000000001, 3, "De 3 rekstokjes" },
                    { 178, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4002), 51.596153000000001, 4.9868269999999999, 3, "Hangaround" },
                    { 179, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4008), 51.579020999999997, 4.9961419999999999, 3, "Speeltuin Reeshofpark" },
                    { 180, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4012), 51.571434000000004, 4.9996049999999999, 3, "Kabelbaan Witbrand" },
                    { 181, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4016), 51.570639, 4.970402, 3, "Minibieb Vlodropstraat" },
                    { 182, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4021), 51.573785000000001, 4.9712009999999998, 3, "Plattegrond Reeshof" },
                    { 183, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4025), 51.577061, 4.9779059999999999, 3, "Wip en hobbelpaard" },
                    { 184, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4030), 51.582214, 4.9768210000000002, 3, "Goals!!!!" },
                    { 185, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4035), 51.582543999999999, 4.982361, 3, "Kids playground" },
                    { 186, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4039), 51.592044000000001, 4.9829040000000004, 3, "Gele wipkip." },
                    { 187, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4044), 51.593057999999999, 4.9815659999999999, 3, "Playground Marlestraat" },
                    { 188, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4049), 51.594917000000002, 4.9833530000000001, 3, "3 red Puppets" },
                    { 189, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4053), 51.583714999999998, 4.999136, 3, "Heerevelden" },
                    { 118, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3726), 51.585490999999998, 4.9774620000000001, 3, "Playground Randwijkstraat" },
                    { 190, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4057), 51.568953999999998, 4.9863039999999996, 3, "Wandelbord C Koolhoven Buiten" },
                    { 192, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4087), 51.570585000000001, 5.0023239999999998, 3, "Stone Pingpong Table Witbrant West" },
                    { 193, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4092), 51.569203000000002, 5.006945, 3, "Natural Soccer Playground" },
                    { 194, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4096), 51.56982, 5.0087320000000002, 3, "Kabelbaan Witbrant Oost" },
                    { 195, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4101), 51.569141999999999, 5.0107850000000003, 3, "Jeux de Boule Witbrant Oost" },
                    { 196, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4105), 51.568626999999999, 5.0114520000000002, 3, "Playground Witbrant Oost" },
                    { 197, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4109), 51.568587000000001, 5.0134239999999997, 3, "Stone PingPong Table Witbrant Oost" },
                    { 198, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4114), 51.568733999999999, 5.0137710000000002, 3, "Wooden Play Structure" },
                    { 199, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4118), 51.574781000000002, 4.9971870000000003, 3, "Playground Knegselstraat" },
                    { 200, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4123), 51.574323, 5.0001189999999998, 3, "Playground Kalkwijkstraat" },
                    { 201, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4127), 51.577824, 4.9928850000000002, 3, "Playground Overlangelstraat" },
                    { 202, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4164), 51.576552999999997, 4.9775679999999998, 3, "Fietskaart Tilburg" },
                    { 203, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4169), 51.579008000000002, 4.9792990000000001, 3, "Klimtoestel" },
                    { 191, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4083), 51.570478000000001, 4.9966460000000001, 3, "Jeu de boules Witbrant West" },
                    { 117, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3722), 51.5916, 4.9978309999999997, 3, "Kids Delight" },
                    { 116, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3716), 51.593876999999999, 4.9977999999999998, 3, "Rivier Brug" },
                    { 115, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3711), 51.594755999999997, 4.9947419999999996, 3, "Poles 2" },
                    { 31, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3279), 51.583696000000003, 4.9757150000000001, 2, "JOP Dalemdreef" },
                    { 32, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3284), 51.594620999999997, 4.9880680000000002, 2, "Speeltuin Munnikeburenstraat" },
                    { 33, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3289), 51.573763999999997, 4.9769480000000001, 2, "Speeltuin Varsseveldstraat" },
                    { 34, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3294), 51.582295000000002, 4.9900770000000003, 2, "Reeshofpark West" },
                    { 35, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3298), 51.578598, 5.0016720000000001, 2, "Reeshofpark Oost Ingang" },
                    { 36, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3303), 51.575617000000001, 5.0050460000000001, 2, "Speeltuin Kortgenestraat" }
                });

            migrationBuilder.InsertData(
                table: "Points",
                columns: new[] { "Id", "CreatedAt", "Latitude", "Longitude", "PointTypeId", "Title" },
                values: new object[,]
                {
                    { 37, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3308), 51.580835, 5.0191470000000002, 2, "Play Area Fountain" },
                    { 38, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3313), 51.591949999999997, 4.9887509999999997, 2, "Artpiece Around The World" },
                    { 39, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3317), 51.593153999999998, 4.983733, 2, "Speeltuin Metslawierstraat" },
                    { 40, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3322), 51.573016000000003, 5.020632, 2, "Reeshofbos Speelbos" },
                    { 41, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3326), 51.569809999999997, 5.0019200000000001, 2, "Climbstone" },
                    { 42, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3331), 51.588607000000003, 4.9842529999999998, 2, "Fietsersbrug Mariaradevonder" },
                    { 43, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3335), 51.587265000000002, 4.9829800000000004, 2, "Rode Olifant Wip Op Speelplein" },
                    { 44, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3340), 51.578778, 5.0217580000000002, 2, "Wall Mural" },
                    { 45, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3344), 51.575764999999997, 5.0097519999999998, 2, "Wooden Owl" },
                    { 46, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3349), 51.577441999999998, 4.9863010000000001, 2, "Torenvalk Dongevallei" },
                    { 47, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3353), 51.576573000000003, 4.9808389999999996, 2, "Rectangular Panoramic Window Art" },
                    { 48, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3358), 51.577924000000003, 4.9746569999999997, 2, "Gudok" },
                    { 49, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3362), 51.579977, 4.9955870000000004, 2, "Geef Om Een Ander" },
                    { 50, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3366), 51.585420999999997, 5.0032240000000003, 2, "Social Sofa Winnen doen we samen" },
                    { 51, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3371), 51.579650999999998, 5.0138340000000001, 2, "Artpiece into the Sky" },
                    { 52, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3376), 51.576715999999998, 4.9943460000000002, 2, "Sleepy Social Sofa" },
                    { 53, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3380), 51.577863000000001, 4.9948969999999999, 2, "Social Sofa Beatrix College" },
                    { 54, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3385), 51.571268000000003, 4.9758529999999999, 2, "Referee" },
                    { 55, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3389), 51.584276000000003, 4.9879179999999996, 2, "Portrait Mural" },
                    { 30, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3275), 51.582931000000002, 4.979177, 2, "Social Sofa Schipluidenlaan" },
                    { 29, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3270), 51.584470000000003, 5.0003390000000003, 2, "Playground Hoevelaken" },
                    { 28, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3265), 51.585991999999997, 5.0055820000000004, 2, "Up Mushroom" },
                    { 27, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3261), 51.589204000000002, 5.000623, 2, "Loosduinenhof playground" },
                    { 1, new DateTime(2021, 4, 11, 12, 58, 34, 631, DateTimeKind.Local).AddTicks(4390), 51.57105, 4.9996530000000003, 1, "Stone benches playground" },
                    { 2, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3063), 51.593226999999999, 4.9977130000000001, 1, "Tilburg Landmerk" },
                    { 3, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3111), 51.584330999999999, 4.9818930000000003, 1, "Dragon Eating Fish" },
                    { 4, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3118), 51.580278999999997, 4.9841980000000001, 1, "Make it Count" },
                    { 5, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3123), 51.572660999999997, 4.9963689999999996, 1, "Zwaaiend Mannetje" },
                    { 6, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3127), 51.573771999999998, 4.9935919999999996, 1, "Station Tilburg Reeshof" },
                    { 7, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3133), 51.577547000000003, 5.0043730000000002, 1, "Social Sofa Heyhoef" },
                    { 8, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3138), 51.577840000000002, 5.0062110000000004, 1, "Feestornament Bij Winkelcentrum Heijhoef" },
                    { 9, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3158), 51.586196000000001, 5.0153910000000002, 1, "Caterpillar Climbing Structure" },
                    { 10, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3163), 51.589790000000001, 4.9970720000000002, 1, "Midwolde playground" },
                    { 11, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3167), 51.585734000000002, 4.997185, 1, "Peerkes Hoeve" },
                    { 12, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3172), 51.583528000000001, 5.0213070000000002, 1, "Hoops for 2" },
                    { 56, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3394), 51.571213, 4.9831200000000004, 2, "Speeltuin Zelhemstraat" },
                    { 13, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3178), 51.58211, 5.0193409999999998, 1, "Social Sofa Buurmalsenplein" },
                    { 15, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3185), 51.570307999999997, 5.0108370000000004, 1, "Art stones suburb Witbrand Oost" },
                    { 16, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3188), 51.581468000000001, 4.9792329999999998, 1, "Round And Round" },
                    { 17, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3193), 51.584361000000001, 4.9758310000000003, 1, "Skatepark Soerendonklaan" },
                    { 18, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3197), 51.592115, 4.998011, 1, "Mini soccerfield Middelharnisstraat" },
                    { 19, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3201), 51.587992999999997, 5.0065929999999996, 1, "Basketbal Bijsterveldenlaan" }
                });

            migrationBuilder.InsertData(
                table: "Points",
                columns: new[] { "Id", "CreatedAt", "Latitude", "Longitude", "PointTypeId", "Title" },
                values: new object[,]
                {
                    { 20, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3206), 51.586466999999999, 5.0145080000000002, 1, "Sitting Room" },
                    { 21, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3210), 51.581321000000003, 5.0141520000000002, 1, "St. Antonius van Paduakerk - Emmausparochie Tilburg" },
                    { 22, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3215), 51.580924000000003, 5.0234800000000002, 1, "walking around" },
                    { 23, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3219), 51.577503, 4.9870570000000001, 1, "Plekgedicht fietserbrug" },
                    { 24, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3247), 51.591194999999999, 4.9794770000000002, 1, "Playground Reeswoude" },
                    { 25, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3252), 51.595889, 4.9919919999999998, 1, "Sluis Wilhelminakanaal" },
                    { 26, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3257), 51.587898000000003, 5.0151820000000003, 1, "historische kanaalbrug reeshof" },
                    { 14, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3181), 51.572761, 5.0018549999999999, 1, "Voetbalveld SV Reeshof" },
                    { 233, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4305), 51.595931, 4.9905590000000002, 3, "Mini soccerfield menaldumstraat" },
                    { 57, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3399), 51.594065999999998, 4.9808979999999998, 2, "De Dongevallei" },
                    { 59, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3407), 51.569289900000001, 4.9793250000000002, 2, "Minispeeltuin In Vlagtwedde" },
                    { 90, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3546), 51.574618999999998, 5.0142090000000001, 3, "Reeshofbos Noord" },
                    { 91, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3551), 51.573053999999999, 5.0193989999999999, 3, "Reeshofbos Oost" },
                    { 92, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3555), 51.580351999999998, 5.0056839999999996, 3, "Kwiek Beweegroute (Heerenveldendreef)" },
                    { 93, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3560), 51.579053000000002, 5.0060219999999997, 3, "Sportcentrum Tilburg Reeshof" },
                    { 94, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3564), 51.581088999999999, 5.006653, 3, "Reeshof Huibeven" },
                    { 95, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3569), 51.584384, 5.0092309999999998, 3, "Zinloos" },
                    { 96, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3573), 51.585057999999997, 5.011673, 3, "Speeltuintje Aan Biervlietplein" },
                    { 97, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3578), 51.587898000000003, 5.0151820000000003, 3, "historische kanaalbrug reeshof" },
                    { 98, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3582), 51.581682999999998, 5.0126999999999997, 3, "Playground Groenlo" },
                    { 99, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3587), 51.579199000000003, 5.0130530000000002, 3, "Playground Huibeven" },
                    { 100, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3637), 51.583464999999997, 5.0147539999999999, 3, "Batenburg Playground" },
                    { 101, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3644), 51.580725999999999, 5.0149140000000001, 3, "Social Sofa Helen Parkhurst" },
                    { 102, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3649), 51.584710999999999, 5.0174240000000001, 3, "Playground Besoijenstraat" },
                    { 103, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3653), 51.583250999999997, 5.0199350000000003, 3, "Gedenksteen Plan Reeshof" },
                    { 104, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3658), 51.582746, 5.0200709999999997, 3, "Smile" },
                    { 105, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3662), 51.582459999999998, 5.0193240000000001, 3, "Colorful Caterpillar Portal Buurmalsenplein" },
                    { 106, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3667), 51.581150000000001, 5.0187499999999998, 3, "Children Times Ten Portal" },
                    { 107, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3671), 51.580401000000002, 5.018033, 3, "Bloemenbankje" },
                    { 108, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3676), 51.578484000000003, 5.018141, 3, "Playground Dwingelo" },
                    { 109, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3681), 51.577095999999997, 5.0195999999999996, 3, "Totem Palen" },
                    { 110, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3689), 51.582898999999998, 5.0277669999999999, 3, "R'hof Beam Bridge for Bikes" },
                    { 111, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3693), 51.597408999999999, 4.984477, 3, "Playground Mijnden" },
                    { 112, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3698), 51.597161999999997, 4.989306, 3, "Voldijkbrug" },
                    { 113, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3702), 51.595948999999997, 4.9895769999999997, 3, "Pole Art Menaldumstraat" },
                    { 114, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3707), 51.593144000000002, 4.9918490000000002, 3, "Pole Art Mosselhoekplein" },
                    { 89, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3542), 51.573332999999998, 5.0133330000000003, 3, "vos poeky" },
                    { 88, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3537), 51.574288000000003, 5.0121599999999997, 3, "Konijnen HOST" },
                    { 87, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3534), 51.573611, 5.0091659999999996, 3, "Specht poeky" },
                    { 86, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3530), 51.574677000000001, 5.008165, 3, "Eekhoorn" },
                    { 60, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3412), 51.567763999999997, 5.0128500000000003, 2, "Social Sofa Abcoudestraat" },
                    { 61, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3416), 51.593249, 4.9911789999999998, 2, "Blue Puppet" }
                });

            migrationBuilder.InsertData(
                table: "Points",
                columns: new[] { "Id", "CreatedAt", "Latitude", "Longitude", "PointTypeId", "Title" },
                values: new object[,]
                {
                    { 62, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3421), 51.601768999999997, 4.9769360000000002, 2, "Burgemeester Letscherbrug" },
                    { 63, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3425), 51.583277000000002, 4.9780899999999999, 2, "Up and Down Structure" },
                    { 64, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3430), 51.567833, 5.0048000000000004, 3, "De Gaas" },
                    { 65, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3434), 51.568916999999999, 5.0052789999999998, 3, "Mozaïc Bankje" },
                    { 66, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3439), 51.564746999999997, 4.9931200000000002, 3, "Fietskaart Oude Rielse Baan" },
                    { 67, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3444), 51.572657999999997, 4.9967420000000002, 3, "Men In Glass" },
                    { 68, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3448), 51.573431999999997, 4.9932080000000001, 3, "Vlinder Sociaal Sofa" },
                    { 69, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3452), 51.574131000000001, 4.9934519999999996, 3, "Social Sofa Stadsplein" },
                    { 70, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3457), 51.574182999999998, 4.9938549999999999, 3, "Social Sofa I Love Holland" },
                    { 71, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3462), 51.573430000000002, 4.9895529999999999, 3, "Wandelbord F -Koolhoven Buiten" },
                    { 58, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3403), 51.579217999999997, 4.9987459999999997, 2, "Charles Rey de Carle" },
                    { 72, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3467), 51.571455999999998, 4.9862169999999999, 3, "Wandelbord C Koolhoven Buiten" },
                    { 74, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3476), 51.572035999999997, 4.981789, 3, "Speeltuin Koolhovenlaan" },
                    { 75, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3480), 51.574821, 4.980721, 3, "Living Colors Playground" },
                    { 76, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3485), 51.574874000000001, 4.9794320000000001, 3, "Zonnewijzer" },
                    { 77, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3490), 51.571587999999998, 4.9755929999999999, 3, "Fluit Stoeltje" },
                    { 78, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3494), 51.575761, 4.974634, 3, "Speeltuin Valkenswaard Vierhouten" },
                    { 79, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3499), 51.570231999999997, 4.9714080000000003, 3, "Speeltuin Camping Vlagtwedde" },
                    { 80, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3503), 51.577357999999997, 4.9936879999999997, 3, "Sporthal Dongewijk" },
                    { 81, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3507), 51.577731999999997, 4.9937490000000002, 3, "Minaret" },
                    { 82, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3512), 51.576906999999999, 4.9973739999999998, 3, "Playground Kralingenstraat" },
                    { 83, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3516), 51.575975999999997, 5.000216, 3, "Playground Kalkwijk" },
                    { 84, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3521), 51.578254000000001, 5.0060890000000002, 3, "Library Heyhoef" },
                    { 85, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3525), 51.577185999999998, 5.0094820000000002, 3, "Honing-Etende Beer Standbeeldje" },
                    { 73, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(3471), 51.573509000000001, 4.984356, 3, "Zaltbommelse Lange Klimtuin" },
                    { 234, new DateTime(2021, 4, 11, 12, 58, 34, 634, DateTimeKind.Local).AddTicks(4309), 51.583889999999997, 5.0165709999999999, 3, "Wipstoel Pacman" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Points_PointTypeId",
                table: "Points",
                column: "PointTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Points");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PointType");
        }
    }
}
