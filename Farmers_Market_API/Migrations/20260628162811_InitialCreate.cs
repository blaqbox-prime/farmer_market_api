using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Farmers_Market_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BuyerType = table.Column<int>(type: "integer", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Farmers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Province = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<double>(type: "double precision", nullable: false),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false),
                    FarmName = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProduceListings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FarmerId = table.Column<int>(type: "integer", nullable: false),
                    ProduceName = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    PricePerKg = table.Column<double>(type: "double precision", nullable: false),
                    QuantityKg = table.Column<double>(type: "double precision", nullable: false),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    HarvestDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateListed = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduceListings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProduceListings_Farmers_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BuyerId = table.Column<int>(type: "integer", nullable: false),
                    FarmerId = table.Column<int>(type: "integer", nullable: false),
                    ListingId = table.Column<int>(type: "integer", nullable: false),
                    QuantityOrdered = table.Column<double>(type: "double precision", nullable: false),
                    TotalPrice = table.Column<double>(type: "double precision", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CollectionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Buyers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Buyers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Farmers_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_ProduceListings_ListingId",
                        column: x => x.ListingId,
                        principalTable: "ProduceListings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Buyers",
                columns: new[] { "Id", "BuyerType", "Email", "FullName", "Location", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 0, "anele@example.com", "Anele Mokoena", "Cape Town", "071-000-0001" },
                    { 2, 1, "lerato@example.com", "Lerato Ndlovu", "Johannesburg", "071-000-0002" },
                    { 3, 2, "thabo@example.com", "Thabo Nkosi", "Durban", "071-000-0003" },
                    { 4, 3, "nandi@example.com", "Nandi Dlamini", "Pretoria", "071-000-0004" },
                    { 5, 0, "sipho@example.com", "Sipho Mabaso", "Bloemfontein", "071-000-0005" },
                    { 6, 1, "maya@example.com", "Maya van Rensburg", "Stellenbosch", "071-000-0006" },
                    { 7, 4, "kuhle@example.com", "Kuhle Khumalo", "Gqeberha", "071-000-0007" },
                    { 8, 2, "zama@example.com", "Zama Patel", "Polokwane", "071-000-0008" },
                    { 9, 0, "johan@example.com", "Johan Botha", "Welkom", "071-000-0009" },
                    { 10, 1, "sonto@example.com", "Sonto Molefe", "Mbombela", "071-000-0010" }
                });

            migrationBuilder.InsertData(
                table: "Farmers",
                columns: new[] { "Id", "Email", "FarmName", "FullName", "IsVerified", "Location", "PhoneNumber", "Province", "Rating" },
                values: new object[,]
                {
                    { 1, "kobus@example.com", "Farm A", "Kobus", true, "Location A", "123-456-7890", "Province A", 4.5 },
                    { 2, "tyrique@example.com", "Farm B", "Tyrique", true, "Location B", "098-765-4321", "Province B", 4.0 },
                    { 3, "zandre@example.com", "Farm C", "Zandre", true, "Location C", "555-555-5555", "Province C", 4.7999999999999998 },
                    { 4, "aisha@example.com", "Farm D", "Aisha", true, "Location D", "111-222-3333", "Province D", 4.2000000000000002 },
                    { 5, "bongani@example.com", "Farm E", "Bongani", false, "Location E", "222-333-4444", "Province E", 3.8999999999999999 },
                    { 6, "carmen@example.com", "Farm F", "Carmen", true, "Location F", "333-444-5555", "Province F", 4.7000000000000002 },
                    { 7, "daniel@example.com", "Farm G", "Daniel", true, "Location G", "444-555-6666", "Province G", 4.0999999999999996 },
                    { 8, "elena@example.com", "Farm H", "Elena", false, "Location H", "555-666-7777", "Province H", 3.7999999999999998 },
                    { 9, "farid@example.com", "Farm I", "Farid", true, "Location I", "666-777-8888", "Province I", 4.5999999999999996 },
                    { 10, "grace@example.com", "Farm J", "Grace", true, "Location J", "777-888-9999", "Province J", 4.2999999999999998 },
                    { 11, "hendrik@example.com", "Farm K", "Hendrik", false, "Location K", "888-999-0000", "Province K", 3.7000000000000002 },
                    { 12, "imani@example.com", "Farm L", "Imani", true, "Location L", "101-202-3030", "Province L", 4.4000000000000004 },
                    { 13, "jabulani@example.com", "Farm M", "Jabulani", true, "Location M", "121-212-1212", "Province M", 4.0 },
                    { 14, "keisha@example.com", "Farm N", "Keisha", false, "Location N", "131-313-1313", "Province N", 3.6000000000000001 },
                    { 15, "lungile@example.com", "Farm O", "Lungile", true, "Location O", "141-414-1414", "Province O", 4.9000000000000004 },
                    { 16, "mpho@example.com", "Farm P", "Mpho", true, "Location P", "151-515-1515", "Province P", 4.2000000000000002 },
                    { 17, "nokuthula@example.com", "Farm Q", "Nokuthula", false, "Location Q", "161-616-1616", "Province Q", 3.5 },
                    { 18, "omar@example.com", "Farm R", "Omar", true, "Location R", "171-717-1717", "Province R", 4.0999999999999996 },
                    { 19, "palesa@example.com", "Farm S", "Palesa", true, "Location S", "181-818-1818", "Province S", 4.0 },
                    { 20, "quentin@example.com", "Farm T", "Quentin", false, "Location T", "191-919-1919", "Province T", 3.8999999999999999 }
                });

            migrationBuilder.InsertData(
                table: "ProduceListings",
                columns: new[] { "Id", "Category", "DateListed", "Description", "FarmerId", "HarvestDate", "IsAvailable", "PricePerKg", "ProduceName", "QuantityKg" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2026, 6, 23, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(1163), "Freshly harvested tomatoes.", 1, new DateTime(2026, 6, 18, 18, 28, 11, 179, DateTimeKind.Local).AddTicks(3088), false, 2.5, "Tomatoes", 100.0 },
                    { 2, 1, new DateTime(2026, 6, 21, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4867), "Crisp and sweet apples.", 2, new DateTime(2026, 6, 13, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4862), true, 3.0, "Apples", 50.0 },
                    { 3, 0, new DateTime(2026, 6, 18, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4876), "Organic carrots from our farm.", 3, new DateTime(2026, 6, 8, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4875), true, 1.8, "Carrots", 200.0 },
                    { 4, 0, new DateTime(2026, 6, 25, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4878), "Crisp green lettuce leaves.", 1, new DateTime(2026, 6, 20, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4878), true, 2.0, "Lettuce", 75.0 },
                    { 5, 1, new DateTime(2026, 6, 22, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4880), "Juicy navel oranges.", 2, new DateTime(2026, 6, 16, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4879), false, 2.7999999999999998, "Oranges", 60.0 },
                    { 6, 0, new DateTime(2026, 6, 16, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4889), "Fresh russet potatoes.", 3, new DateTime(2026, 6, 3, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4889), true, 1.5, "Potatoes", 150.0 },
                    { 7, 1, new DateTime(2026, 6, 26, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4916), "Sweet seasonal strawberries.", 1, new DateTime(2026, 6, 23, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4916), false, 4.5, "Strawberries", 30.0 },
                    { 8, 0, new DateTime(2026, 6, 24, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4920), "Nutritious broccoli florets.", 2, new DateTime(2026, 6, 21, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4919), false, 3.2000000000000002, "Broccoli", 40.0 },
                    { 9, 1, new DateTime(2026, 6, 19, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4922), "Ripe yellow bananas.", 3, new DateTime(2026, 6, 10, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4921), true, 1.2, "Bananas", 80.0 },
                    { 10, 0, new DateTime(2026, 6, 25, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4925), "Fresh baby spinach leaves.", 1, new DateTime(2026, 6, 22, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4925), true, 2.2999999999999998, "Spinach", 55.0 },
                    { 11, 0, new DateTime(2026, 6, 26, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4927), "Crisp garden cucumbers.", 2, new DateTime(2026, 6, 24, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4927), true, 1.8999999999999999, "Cucumbers", 90.0 },
                    { 12, 1, new DateTime(2026, 6, 27, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4929), "Plump wild blueberries.", 3, new DateTime(2026, 6, 25, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4929), false, 5.0, "Blueberries", 25.0 },
                    { 13, 0, new DateTime(2026, 6, 13, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4931), "Aromatic garlic bulbs.", 1, new DateTime(2026, 5, 29, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4930), true, 4.0, "Garlic", 15.0 },
                    { 14, 0, new DateTime(2026, 6, 18, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4933), "Sweet yellow onions.", 2, new DateTime(2026, 6, 8, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4932), true, 1.6000000000000001, "Onions", 120.0 },
                    { 15, 0, new DateTime(2026, 6, 24, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4934), "Mixed-color bell peppers.", 3, new DateTime(2026, 6, 19, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4934), true, 3.5, "Bell Peppers", 45.0 },
                    { 16, 0, new DateTime(2026, 5, 29, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4936), "Large carving pumpkins.", 1, new DateTime(2026, 5, 19, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4936), false, 0.90000000000000002, "Pumpkins", 60.0 },
                    { 17, 2, new DateTime(2026, 6, 25, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4938), "Sweet corn on the cob.", 2, new DateTime(2026, 6, 21, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4938), true, 1.2, "Corn", 200.0 },
                    { 18, 2, new DateTime(2026, 5, 14, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4949), "Whole wheat grain.", 3, new DateTime(2026, 4, 29, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4949), true, 0.80000000000000004, "Wheat (Bulk)", 500.0 },
                    { 19, 2, new DateTime(2026, 6, 3, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4951), "Rolled oats for baking.", 1, new DateTime(2026, 5, 9, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4951), true, 1.1000000000000001, "Oats", 350.0 },
                    { 20, 3, new DateTime(2026, 6, 27, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4953), "Fresh whole milk (per liter equivalent).", 2, new DateTime(2026, 6, 26, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4953), true, 0.94999999999999996, "Milk", 200.0 },
                    { 21, 3, new DateTime(2026, 6, 21, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4956), "Aged farmhouse cheddar.", 3, new DateTime(2026, 6, 14, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4955), true, 8.5, "Cheese", 20.0 },
                    { 22, 3, new DateTime(2026, 6, 26, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4958), "Creamy plain yogurt.", 1, new DateTime(2026, 6, 23, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4957), true, 3.2000000000000002, "Yogurt", 40.0 },
                    { 23, 4, new DateTime(2026, 6, 25, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4959), "Pasture-raised whole chicken.", 2, new DateTime(2026, 6, 22, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4959), true, 6.5, "Chicken (Whole)", 35.0 },
                    { 24, 4, new DateTime(2026, 6, 24, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4961), "Lean ground beef.", 3, new DateTime(2026, 6, 20, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4961), true, 9.0, "Beef (Ground)", 25.0 },
                    { 25, 4, new DateTime(2026, 6, 23, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4963), "Fresh pork chops.", 1, new DateTime(2026, 6, 18, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4963), true, 7.2000000000000002, "Pork (Chops)", 30.0 },
                    { 26, 5, new DateTime(2026, 6, 28, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4965), "Free-range brown eggs.", 2, new DateTime(2026, 6, 27, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4964), true, 2.5, "Eggs (Dozen)", 150.0 },
                    { 27, 6, new DateTime(2026, 4, 29, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4967), "Raw wildflower honey.", 3, new DateTime(2026, 2, 28, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4966), true, 6.0, "Honey", 18.0 },
                    { 28, 6, new DateTime(2026, 6, 27, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4968), "Fresh basil bunches.", 1, new DateTime(2026, 6, 26, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4968), true, 12.0, "Basil", 5.0 },
                    { 29, 6, new DateTime(2026, 6, 27, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4970), "Curly parsley bunches.", 2, new DateTime(2026, 6, 25, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4970), true, 4.0, "Parsley", 12.0 },
                    { 30, 6, new DateTime(2026, 6, 25, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4980), "Fresh ginger roots.", 3, new DateTime(2026, 6, 21, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4979), true, 9.0, "Ginger", 8.0 },
                    { 31, 0, new DateTime(2026, 6, 19, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4982), "Orange-fleshed sweet potatoes.", 1, new DateTime(2026, 6, 10, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4982), true, 2.2000000000000002, "Sweet Potatoes", 80.0 },
                    { 32, 0, new DateTime(2026, 6, 26, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4984), "Fresh curly kale.", 2, new DateTime(2026, 6, 24, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4983), true, 3.0, "Kale", 30.0 },
                    { 33, 0, new DateTime(2026, 6, 25, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4986), "Green zucchinis.", 3, new DateTime(2026, 6, 22, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4985), true, 1.7, "Zucchini", 60.0 },
                    { 34, 1, new DateTime(2026, 6, 22, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4989), "Juicy Bartlett pears.", 1, new DateTime(2026, 6, 16, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4988), true, 2.8999999999999999, "Pears", 40.0 },
                    { 35, 1, new DateTime(2026, 6, 24, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4993), "Sweet red plums.", 2, new DateTime(2026, 6, 19, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4992), false, 3.2999999999999998, "Plums", 28.0 },
                    { 36, 1, new DateTime(2026, 6, 23, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4995), "Seedless table grapes.", 3, new DateTime(2026, 6, 17, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4994), true, 4.0999999999999996, "Grapes", 35.0 },
                    { 37, 1, new DateTime(2026, 6, 26, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4996), "Hass avocados.", 1, new DateTime(2026, 6, 21, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4996), false, 2.75, "Avocados", 22.0 },
                    { 38, 1, new DateTime(2026, 6, 21, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4998), "Tropical pineapples.", 2, new DateTime(2026, 6, 14, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(4998), true, 3.7999999999999998, "Pineapple", 10.0 },
                    { 39, 0, new DateTime(2026, 6, 20, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(5000), "Green and red cabbages.", 3, new DateTime(2026, 6, 12, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(5000), true, 1.3999999999999999, "Cabbage", 48.0 },
                    { 40, 0, new DateTime(2026, 6, 27, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(5002), "Crisp radish bunches.", 1, new DateTime(2026, 6, 26, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(5001), true, 2.0, "Radishes", 22.0 },
                    { 41, 0, new DateTime(2026, 6, 21, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(5011), "Earthy red beets.", 2, new DateTime(2026, 6, 14, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(5003), true, 2.5, "Beets", 26.0 },
                    { 42, 0, new DateTime(2026, 6, 26, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(5014), "Crunchy celery stalks.", 3, new DateTime(2026, 6, 23, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(5013), true, 1.8, "Celery", 20.0 },
                    { 43, 0, new DateTime(2026, 6, 25, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(5015), "Fresh snap beans.", 1, new DateTime(2026, 6, 22, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(5015), true, 3.1000000000000001, "Green Beans", 34.0 },
                    { 44, 1, new DateTime(2026, 6, 24, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(5017), "Juicy summer peaches.", 2, new DateTime(2026, 6, 20, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(5017), true, 3.6000000000000001, "Peaches", 27.0 },
                    { 45, 1, new DateTime(2026, 6, 23, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(5019), "Sweet nectarines.", 3, new DateTime(2026, 6, 18, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(5019), false, 3.7000000000000002, "Nectarines", 18.0 },
                    { 46, 1, new DateTime(2026, 6, 24, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(5021), "Sun-ripened apricots.", 1, new DateTime(2026, 6, 19, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(5020), true, 4.2000000000000002, "Apricots", 12.0 },
                    { 47, 6, new DateTime(2026, 6, 27, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(5023), "Bunches of mixed culinary herbs.", 2, new DateTime(2026, 6, 26, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(5022), true, 10.0, "Mixed Herbs", 6.0 },
                    { 48, 6, new DateTime(2026, 3, 20, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(5024), "Locally grown almonds.", 3, new DateTime(2025, 12, 10, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(5024), true, 12.5, "Almonds (Shelled)", 14.0 },
                    { 49, 2, new DateTime(2026, 5, 14, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(5026), "Dry lentils for cooking.", 1, new DateTime(2026, 3, 30, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(5026), true, 1.6000000000000001, "Lentils (Bulk)", 220.0 },
                    { 50, 6, new DateTime(2026, 6, 27, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(5028), "Freshly made soybean tofu.", 2, new DateTime(2026, 6, 25, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(5028), true, 4.5, "Tofu (Fresh)", 30.0 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "BuyerId", "CollectionDate", "FarmerId", "ListingId", "Notes", "OrderDate", "QuantityOrdered", "Status", "TotalPrice" },
                values: new object[,]
                {
                    { 1, 1, null, 1, 1, "Pickup in the morning", new DateTime(2026, 6, 28, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(6330), 5.0, 0, 12.5 },
                    { 2, 2, null, 2, 2, "Please pack separately", new DateTime(2026, 6, 28, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(8945), 3.0, 1, 9.0 },
                    { 3, 3, null, 3, 3, "", new DateTime(2026, 6, 28, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(8955), 8.0, 0, 14.4 },
                    { 4, 4, new DateTime(2026, 6, 27, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(8956), 1, 4, "", new DateTime(2026, 6, 28, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(9053), 2.0, 2, 4.0 },
                    { 5, 5, null, 2, 5, "Customer cancelled", new DateTime(2026, 6, 28, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(9055), 4.0, 3, 11.199999999999999 },
                    { 6, 6, null, 3, 6, "Deliver before noon", new DateTime(2026, 6, 28, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(9062), 6.0, 0, 9.0 },
                    { 7, 7, null, 1, 7, "Gift packaging requested", new DateTime(2026, 6, 28, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(9064), 2.0, 1, 9.0 },
                    { 8, 8, null, 2, 8, "", new DateTime(2026, 6, 28, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(9065), 5.0, 0, 16.0 },
                    { 9, 9, new DateTime(2026, 6, 26, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(9067), 3, 9, "", new DateTime(2026, 6, 28, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(9068), 10.0, 2, 12.0 },
                    { 10, 10, null, 1, 10, "Leave at the front desk", new DateTime(2026, 6, 28, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(9070), 3.0, 1, 6.8999999999999995 },
                    { 11, 1, null, 2, 11, "", new DateTime(2026, 6, 28, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(9072), 4.0, 0, 7.5999999999999996 },
                    { 12, 2, null, 3, 12, "Extra careful handling", new DateTime(2026, 6, 28, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(9073), 2.0, 1, 10.0 },
                    { 13, 3, null, 1, 13, "", new DateTime(2026, 6, 28, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(9074), 7.0, 0, 28.0 },
                    { 14, 4, new DateTime(2026, 6, 25, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(9075), 2, 14, "", new DateTime(2026, 6, 28, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(9076), 6.0, 2, 9.6000000000000014 },
                    { 15, 5, null, 3, 15, "Order cancelled by buyer", new DateTime(2026, 6, 28, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(9077), 9.0, 3, 31.5 },
                    { 16, 6, null, 1, 16, "", new DateTime(2026, 6, 28, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(9078), 3.0, 0, 2.7000000000000002 },
                    { 17, 7, null, 2, 17, "", new DateTime(2026, 6, 28, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(9080), 5.0, 1, 6.0 },
                    { 18, 8, null, 3, 18, "Urgent pickup", new DateTime(2026, 6, 28, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(9082), 4.0, 0, 3.2000000000000002 },
                    { 19, 9, null, 1, 19, "", new DateTime(2026, 6, 28, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(9103), 8.0, 1, 8.8000000000000007 },
                    { 20, 10, null, 2, 20, "Morning delivery", new DateTime(2026, 6, 28, 18, 28, 11, 180, DateTimeKind.Local).AddTicks(9105), 2.0, 0, 1.8999999999999999 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BuyerId",
                table: "Orders",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FarmerId",
                table: "Orders",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ListingId",
                table: "Orders",
                column: "ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_ProduceListings_FarmerId",
                table: "ProduceListings",
                column: "FarmerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Buyers");

            migrationBuilder.DropTable(
                name: "ProduceListings");

            migrationBuilder.DropTable(
                name: "Farmers");
        }
    }
}
