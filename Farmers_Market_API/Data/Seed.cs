using Farmers_Market_API.Models;
using Farmers_Market_API.Enums;
using Microsoft.EntityFrameworkCore;
namespace Farmers_Market_API.Data;

public class Seed
{
    // Farmer Seed
    private static readonly List<Farmer> FarmersSeed = new List<Farmer> {
            new Farmer(1, "Kobus", "kobus@example.com", "123-456-7890", "Location A", "Province A", 4.5, true, "Farm A"),
            new Farmer(2, "Tyrique", "tyrique@example.com", "098-765-4321", "Location B", "Province B", 4.0, true, "Farm B"),
            new Farmer(3, "Zandre", "zandre@example.com", "555-555-5555", "Location C", "Province C", 4.8, true, "Farm C"),
            new Farmer(4, "Aisha", "aisha@example.com", "111-222-3333", "Location D", "Province D", 4.2, true, "Farm D"),
            new Farmer(5, "Bongani", "bongani@example.com", "222-333-4444", "Location E", "Province E", 3.9, false, "Farm E"),
            new Farmer(6, "Carmen", "carmen@example.com", "333-444-5555", "Location F", "Province F", 4.7, true, "Farm F"),
            new Farmer(7, "Daniel", "daniel@example.com", "444-555-6666", "Location G", "Province G", 4.1, true, "Farm G"),
            new Farmer(8, "Elena", "elena@example.com", "555-666-7777", "Location H", "Province H", 3.8, false, "Farm H"),
            new Farmer(9, "Farid", "farid@example.com", "666-777-8888", "Location I", "Province I", 4.6, true, "Farm I"),
            new Farmer(10, "Grace", "grace@example.com", "777-888-9999", "Location J", "Province J", 4.3, true, "Farm J"),
            new Farmer(11, "Hendrik", "hendrik@example.com", "888-999-0000", "Location K", "Province K", 3.7, false, "Farm K"),
            new Farmer(12, "Imani", "imani@example.com", "101-202-3030", "Location L", "Province L", 4.4, true, "Farm L"),
            new Farmer(13, "Jabulani", "jabulani@example.com", "121-212-1212", "Location M", "Province M", 4.0, true, "Farm M"),
            new Farmer(14, "Keisha", "keisha@example.com", "131-313-1313", "Location N", "Province N", 3.6, false, "Farm N"),
            new Farmer(15, "Lungile", "lungile@example.com", "141-414-1414", "Location O", "Province O", 4.9, true, "Farm O"),
            new Farmer(16, "Mpho", "mpho@example.com", "151-515-1515", "Location P", "Province P", 4.2, true, "Farm P"),
            new Farmer(17, "Nokuthula", "nokuthula@example.com", "161-616-1616", "Location Q", "Province Q", 3.5, false, "Farm Q"),
            new Farmer(18, "Omar", "omar@example.com", "171-717-1717", "Location R", "Province R", 4.1, true, "Farm R"),
            new Farmer(19, "Palesa", "palesa@example.com", "181-818-1818", "Location S", "Province S", 4.0, true, "Farm S"),
            new Farmer(20, "Quentin", "quentin@example.com", "191-919-1919", "Location T", "Province T", 3.9, false, "Farm T")
            };

    // Buyer Seed
    private static readonly List<Buyer> BuyersSeed = new()
    {
        new Buyer(1, "Anele Mokoena", "anele@example.com", "071-000-0001", BuyerType.Individual, "Cape Town"),
        new Buyer(2, "Lerato Ndlovu", "lerato@example.com", "071-000-0002", BuyerType.Business, "Johannesburg"),
        new Buyer(3, "Thabo Nkosi", "thabo@example.com", "071-000-0003", BuyerType.Restaurant, "Durban"),
        new Buyer(4, "Nandi Dlamini", "nandi@example.com", "071-000-0004", BuyerType.School, "Pretoria"),
        new Buyer(5, "Sipho Mabaso", "sipho@example.com", "071-000-0005", BuyerType.Individual, "Bloemfontein"),
        new Buyer(6, "Maya van Rensburg", "maya@example.com", "071-000-0006", BuyerType.Business, "Stellenbosch"),
        new Buyer(7, "Kuhle Khumalo", "kuhle@example.com", "071-000-0007", BuyerType.Other, "Gqeberha"),
        new Buyer(8, "Zama Patel", "zama@example.com", "071-000-0008", BuyerType.Restaurant, "Polokwane"),
        new Buyer(9, "Johan Botha", "johan@example.com", "071-000-0009", BuyerType.Individual, "Welkom"),
        new Buyer(10, "Sonto Molefe", "sonto@example.com", "071-000-0010", BuyerType.Business, "Mbombela")
    };

    // Produce Seed
    private static readonly List<ProduceListing> ProduceListingsSeed = new()
        {
            new ProduceListing(1, 1, "Tomatoes", Category.Vegetables, 2.5, 100, false, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-5), "Freshly harvested tomatoes."),
            new ProduceListing(2, 2, "Apples", Category.Fruit, 3.0, 50, true, DateTime.Now.AddDays(-15), DateTime.Now.AddDays(-7), "Crisp and sweet apples."),
            new ProduceListing(3, 3, "Carrots", Category.Vegetables, 1.8, 200, true, DateTime.Now.AddDays(-20), DateTime.Now.AddDays(-10), "Organic carrots from our farm."),
            new ProduceListing(4, 1, "Lettuce", Category.Vegetables, 2.0, 75, true, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-3), "Crisp green lettuce leaves."),
            new ProduceListing(5, 2, "Oranges", Category.Fruit, 2.8, 60, false, DateTime.Now.AddDays(-12), DateTime.Now.AddDays(-6), "Juicy navel oranges."),
            new ProduceListing(6, 3, "Potatoes", Category.Vegetables, 1.5, 150, true, DateTime.Now.AddDays(-25), DateTime.Now.AddDays(-12), "Fresh russet potatoes."),
            new ProduceListing(7, 1, "Strawberries", Category.Fruit, 4.5, 30, false, DateTime.Now.AddDays(-5), DateTime.Now.AddDays(-2), "Sweet seasonal strawberries."),
            new ProduceListing(8, 2, "Broccoli", Category.Vegetables, 3.2, 40, false, DateTime.Now.AddDays(-7), DateTime.Now.AddDays(-4), "Nutritious broccoli florets."),
            new ProduceListing(9, 3, "Bananas", Category.Fruit, 1.2, 80, true, DateTime.Now.AddDays(-18), DateTime.Now.AddDays(-9), "Ripe yellow bananas."),
            new ProduceListing(10, 1, "Spinach", Category.Vegetables, 2.3, 55, true, DateTime.Now.AddDays(-6), DateTime.Now.AddDays(-3), "Fresh baby spinach leaves."),

            new ProduceListing(11, 2, "Cucumbers", Category.Vegetables, 1.9, 90, true, DateTime.Now.AddDays(-4), DateTime.Now.AddDays(-2), "Crisp garden cucumbers."),
            new ProduceListing(12, 3, "Blueberries", Category.Fruit, 5.0, 25, false, DateTime.Now.AddDays(-3), DateTime.Now.AddDays(-1), "Plump wild blueberries."),
            new ProduceListing(13, 1, "Garlic", Category.Vegetables, 4.0, 15, true, DateTime.Now.AddDays(-30), DateTime.Now.AddDays(-15), "Aromatic garlic bulbs."),
            new ProduceListing(14, 2, "Onions", Category.Vegetables, 1.6, 120, true, DateTime.Now.AddDays(-20), DateTime.Now.AddDays(-10), "Sweet yellow onions."),
            new ProduceListing(15, 3, "Bell Peppers", Category.Vegetables, 3.5, 45, true, DateTime.Now.AddDays(-9), DateTime.Now.AddDays(-4), "Mixed-color bell peppers."),
            new ProduceListing(16, 1, "Pumpkins", Category.Vegetables, 0.9, 60, false, DateTime.Now.AddDays(-40), DateTime.Now.AddDays(-30), "Large carving pumpkins."),
            new ProduceListing(17, 2, "Corn", Category.Grain, 1.2, 200, true, DateTime.Now.AddDays(-7), DateTime.Now.AddDays(-3), "Sweet corn on the cob."),
            new ProduceListing(18, 3, "Wheat (Bulk)", Category.Grain, 0.8, 500, true, DateTime.Now.AddDays(-60), DateTime.Now.AddDays(-45), "Whole wheat grain."),
            new ProduceListing(19, 1, "Oats", Category.Grain, 1.1, 350, true, DateTime.Now.AddDays(-50), DateTime.Now.AddDays(-25), "Rolled oats for baking."),
            new ProduceListing(20, 2, "Milk", Category.Dairy, 0.95, 200, true, DateTime.Now.AddDays(-2), DateTime.Now.AddDays(-1), "Fresh whole milk (per liter equivalent)."),

            new ProduceListing(21, 3, "Cheese", Category.Dairy, 8.5, 20, true, DateTime.Now.AddDays(-14), DateTime.Now.AddDays(-7), "Aged farmhouse cheddar."),
            new ProduceListing(22, 1, "Yogurt", Category.Dairy, 3.2, 40, true, DateTime.Now.AddDays(-5), DateTime.Now.AddDays(-2), "Creamy plain yogurt."),
            new ProduceListing(23, 2, "Chicken (Whole)", Category.Meat, 6.5, 35, true, DateTime.Now.AddDays(-6), DateTime.Now.AddDays(-3), "Pasture-raised whole chicken."),
            new ProduceListing(24, 3, "Beef (Ground)", Category.Meat, 9.0, 25, true, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-4), "Lean ground beef."),
            new ProduceListing(25, 1, "Pork (Chops)", Category.Meat, 7.2, 30, true, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-5), "Fresh pork chops."),
            new ProduceListing(26, 2, "Eggs (Dozen)", Category.Eggs, 2.5, 150, true, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(0), "Free-range brown eggs."),
            new ProduceListing(27, 3, "Honey", Category.Other, 6.0, 18, true, DateTime.Now.AddDays(-120), DateTime.Now.AddDays(-60), "Raw wildflower honey."),
            new ProduceListing(28, 1, "Basil", Category.Other, 12.0, 5, true, DateTime.Now.AddDays(-2), DateTime.Now.AddDays(-1), "Fresh basil bunches."),
            new ProduceListing(29, 2, "Parsley", Category.Other, 4.0, 12, true, DateTime.Now.AddDays(-3), DateTime.Now.AddDays(-1), "Curly parsley bunches."),
            new ProduceListing(30, 3, "Ginger", Category.Other, 9.0, 8, true, DateTime.Now.AddDays(-7), DateTime.Now.AddDays(-3), "Fresh ginger roots."),

            new ProduceListing(31, 1, "Sweet Potatoes", Category.Vegetables, 2.2, 80, true, DateTime.Now.AddDays(-18), DateTime.Now.AddDays(-9), "Orange-fleshed sweet potatoes."),
            new ProduceListing(32, 2, "Kale", Category.Vegetables, 3.0, 30, true, DateTime.Now.AddDays(-4), DateTime.Now.AddDays(-2), "Fresh curly kale."),
            new ProduceListing(33, 3, "Zucchini", Category.Vegetables, 1.7, 60, true, DateTime.Now.AddDays(-6), DateTime.Now.AddDays(-3), "Green zucchinis."),
            new ProduceListing(34, 1, "Pears", Category.Fruit, 2.9, 40, true, DateTime.Now.AddDays(-12), DateTime.Now.AddDays(-6), "Juicy Bartlett pears."),
            new ProduceListing(35, 2, "Plums", Category.Fruit, 3.3, 28, false, DateTime.Now.AddDays(-9), DateTime.Now.AddDays(-4), "Sweet red plums."),
            new ProduceListing(36, 3, "Grapes", Category.Fruit, 4.1, 35, true, DateTime.Now.AddDays(-11), DateTime.Now.AddDays(-5), "Seedless table grapes."),
            new ProduceListing(37, 1, "Avocados", Category.Fruit, 2.75, 22, false, DateTime.Now.AddDays(-7), DateTime.Now.AddDays(-2), "Hass avocados."),
            new ProduceListing(38, 2, "Pineapple", Category.Fruit, 3.8, 10, true, DateTime.Now.AddDays(-14), DateTime.Now.AddDays(-7), "Tropical pineapples."),
            new ProduceListing(39, 3, "Cabbage", Category.Vegetables, 1.4, 48, true, DateTime.Now.AddDays(-16), DateTime.Now.AddDays(-8), "Green and red cabbages."),
            new ProduceListing(40, 1, "Radishes", Category.Vegetables, 2.0, 22, true, DateTime.Now.AddDays(-2), DateTime.Now.AddDays(-1), "Crisp radish bunches."),

            new ProduceListing(41, 2, "Beets", Category.Vegetables, 2.5, 26, true, DateTime.Now.AddDays(-14), DateTime.Now.AddDays(-7), "Earthy red beets."),
            new ProduceListing(42, 3, "Celery", Category.Vegetables, 1.8, 20, true, DateTime.Now.AddDays(-5), DateTime.Now.AddDays(-2), "Crunchy celery stalks."),
            new ProduceListing(43, 1, "Green Beans", Category.Vegetables, 3.1, 34, true, DateTime.Now.AddDays(-6), DateTime.Now.AddDays(-3), "Fresh snap beans."),
            new ProduceListing(44, 2, "Peaches", Category.Fruit, 3.6, 27, true, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-4), "Juicy summer peaches."),
            new ProduceListing(45, 3, "Nectarines", Category.Fruit, 3.7, 18, false, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-5), "Sweet nectarines."),
            new ProduceListing(46, 1, "Apricots", Category.Fruit, 4.2, 12, true, DateTime.Now.AddDays(-9), DateTime.Now.AddDays(-4), "Sun-ripened apricots."),
            new ProduceListing(47, 2, "Mixed Herbs", Category.Other, 10.0, 6, true, DateTime.Now.AddDays(-2), DateTime.Now.AddDays(-1), "Bunches of mixed culinary herbs."),
            new ProduceListing(48, 3, "Almonds (Shelled)", Category.Other, 12.5, 14, true, DateTime.Now.AddDays(-200), DateTime.Now.AddDays(-100), "Locally grown almonds."),
            new ProduceListing(49, 1, "Lentils (Bulk)", Category.Grain, 1.6, 220, true, DateTime.Now.AddDays(-90), DateTime.Now.AddDays(-45), "Dry lentils for cooking."),
            new ProduceListing(50, 2, "Tofu (Fresh)", Category.Other, 4.5, 30, true, DateTime.Now.AddDays(-3), DateTime.Now.AddDays(-1), "Freshly made soybean tofu.")
        };

    private static readonly List<Order> OrdersSeed = new()
    {
        new Order(1, 1, 1, ProduceListingsSeed[0], 5, OrderStatus.Pending, notes: "Pickup in the morning"),
        new Order(2, 2, 2, ProduceListingsSeed[1], 3, OrderStatus.Confirmed, notes: "Please pack separately"),
        new Order(3, 3, 3, ProduceListingsSeed[2], 8, OrderStatus.Pending),
        new Order(4, 4, 1, ProduceListingsSeed[3], 2, OrderStatus.Collected, collectionDate: DateTime.Now.AddDays(-1)),
        new Order(5, 5, 2, ProduceListingsSeed[4], 4, OrderStatus.Cancelled, notes: "Customer cancelled"),
        new Order(6, 6, 3, ProduceListingsSeed[5], 6, OrderStatus.Pending, notes: "Deliver before noon"),
        new Order(7, 7, 1, ProduceListingsSeed[6], 2, OrderStatus.Confirmed, notes: "Gift packaging requested"),
        new Order(8, 8, 2, ProduceListingsSeed[7], 5, OrderStatus.Pending),
        new Order(9, 9, 3, ProduceListingsSeed[8], 10, OrderStatus.Collected, collectionDate: DateTime.Now.AddDays(-2)),
        new Order(10, 10, 1, ProduceListingsSeed[9], 3, OrderStatus.Confirmed, notes: "Leave at the front desk"),
        new Order(11, 1, 2, ProduceListingsSeed[10], 4, OrderStatus.Pending),
        new Order(12, 2, 3, ProduceListingsSeed[11], 2, OrderStatus.Confirmed, notes: "Extra careful handling"),
        new Order(13, 3, 1, ProduceListingsSeed[12], 7, OrderStatus.Pending),
        new Order(14, 4, 2, ProduceListingsSeed[13], 6, OrderStatus.Collected, collectionDate: DateTime.Now.AddDays(-3)),
        new Order(15, 5, 3, ProduceListingsSeed[14], 9, OrderStatus.Cancelled, notes: "Order cancelled by buyer"),
        new Order(16, 6, 1, ProduceListingsSeed[15], 3, OrderStatus.Pending),
        new Order(17, 7, 2, ProduceListingsSeed[16], 5, OrderStatus.Confirmed),
        new Order(18, 8, 3, ProduceListingsSeed[17], 4, OrderStatus.Pending, notes: "Urgent pickup"),
        new Order(19, 9, 1, ProduceListingsSeed[18], 8, OrderStatus.Confirmed),
        new Order(20, 10, 2, ProduceListingsSeed[19], 2, OrderStatus.Pending, notes: "Morning delivery")
    };

    public static void SeedData(ModelBuilder modelBuilder)
    {
       modelBuilder.Entity<Farmer>().HasData(FarmersSeed);
       modelBuilder.Entity<Buyer>().HasData(BuyersSeed);
       modelBuilder.Entity<ProduceListing>().HasData(ProduceListingsSeed);
       modelBuilder.Entity<Order>().HasData(OrdersSeed);
    }
}
