// See https://aka.ms/new-console-template for more information
List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Wizard Hat",
        Price = 10,
        Sold = true,
        //ProductTypeId = ,
        DaysOnShelf = new DateTime(2026, 1, 1)
    },
    new Product()
    {
        Name = "Purple Cloak",
        Price = 50,
        Sold = true,
   //     ProductTypeId = ,
        DaysOnShelf = new DateTime(2026, 1, 1)
    },
    new Product()
    {
        Name = "Birch Wand",
        Price = 20,
        Sold = false,
        //ProductTypeId = ,
        DaysOnShelf = new DateTime(2026, 1, 1)
    },
    new Product()
    {
        Name = "Potion of Invisibility",
        Price = 5,
        Sold = true,
        //ProductTypeId = ,
        DaysOnShelf = new DateTime(2026, 1, 1)
    },
    new Product()
    {
        Name = "Love Potion",
        Price = 500,
        Sold = true,
        //ProductTypeId = ,
        DaysOnShelf = new DateTime(2026, 1, 1)
    },
    new Product()
    {
        Name = "Lucky Charm",
        Price = 10,
        Sold = true,
        //ProductTypeId = ,
        DaysOnShelf = new DateTime(2026, 1, 1)
    },
    
};

string greeting = @"Welcome to Reductio & Absurdum!
Providing high-quality magical supplies to the wizarding community for nearly 1000 years at their shop on Calendula Road.";
Console.WriteLine(greeting);

/*
Console.WriteLine(@"
Menu:
0. Exit
1. View All Products
2. View Products for a Category
3. Add a Product  to the Inventory
4. Delete a Product from the Inventory
5. Update a Product's Details");

Console.WriteLine(@"Products:
1 apparel
2. potions
3. enchanted objects
4. wands
5. dog");*/

Console.WriteLine("Products:");

for (int i = 0; i < products.Count; i++)
{
    Console.WriteLine($"{i + 1}. {products[i].Name}");
}

Console.WriteLine("Please enter a product number: ");
int response = int.Parse(Console.ReadLine().Trim());

    Product chosenProduct = products[response - 1];

while (response > products.Count || response < 1)
{
    Console.WriteLine("Choose a number between 1 and 5!");
    response = int.Parse(Console.ReadLine().Trim());
}

DateTime now = DateTime.Now;

TimeSpan timeInStock = now - chosenProduct.DaysOnShelf;


    Console.WriteLine($"You chose: {chosenProduct.Name}, which costs {chosenProduct.Price} dollars and is {(chosenProduct.Sold ? "" : "not ")}sold.");

/*
string response = Console.ReadLine().Trim();


while (string.IsNullOrEmpty(response))
{
    Console.WriteLine("You didn't choose anything!");
    response = Console.ReadLine().Trim();
}
    Console.WriteLine(@$"You chose: {response}.
Thank you for your input!");
*/
