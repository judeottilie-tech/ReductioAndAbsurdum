// See https://aka.ms/new-console-template for more information
List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType() { Id = 1, Name = "Apparel" },
    new ProductType() { Id = 2, Name = "Potions" },
    new ProductType() { Id = 3, Name = "Enchanted Objects" },
    new ProductType() { Id = 4, Name = "Wands" }
};

List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Wizard Hat",
        Price = 10.00M,
        Sold = true,
        ProductTypeId = 1,
        DateEntered = new DateTime(2026, 2, 28)
    },
    new Product()
    {
        Name = "Purple Cloak",
        Price = 50.00M,
        Sold = false,
        ProductTypeId = 1,
        DateEntered = new DateTime(2026, 1, 30)
    },
    new Product()
    {
        Name = "Birch Wand",
        Price = 20.00M,
        Sold = true,
        ProductTypeId = 4,
        DateEntered = new DateTime(2026, 3, 12)
    },
    new Product()
    {
        Name = "Potion of Invisibility",
        Price = 5.00M,
        Sold = true,
        ProductTypeId = 2,
        DateEntered = new DateTime(2025, 11, 22)
    },
    new Product()
    {
        Name = "Love Potion",
        Price = 500.00M,
        Sold = true,
        ProductTypeId = 2,
        DateEntered = new DateTime(2026, 5, 1)
    },
    new Product()
    {
        Name = "Lucky Charm",
        Price = 10.00M,
        Sold = true,
        ProductTypeId = 3,
        DateEntered = new DateTime(2026, 5, 1)
    },
    
};

string greeting = @"Welcome to Reductio & Absurdum!
Providing high-quality magical supplies to the wizarding community for nearly 1000 years at their shop on Calendula Road.";
Console.WriteLine(greeting);


string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"
Menu:
0. Exit
1. View All Products
2. View Products for a Category
3. Add a Product to the Inventory
4. Delete a Product from the Inventory
5. Update a Product's Details");

/*
0. Exit
1. Apparel
2. Potion
3. Enchanted Item
4. Wand


 */

choice = Console.ReadLine().Trim();

    if (choice == "0")
    {
        Console.WriteLine("Goodbye");
    }
    else if (choice == "1")
    {
        ListProducts();
    }
   
    else if (choice == "2")
    {
        ViewByCategory();
    }

     /*
    else if (choice == "3")
    {
        AddProduct();
    }
    else if (choice == "4")
    {
        DeleteProduct();
    }
    else if (choice == "5")
    {
        UpdateProduct();
    }
    */
}

void ListProducts()
{
    Console.WriteLine($"Products:");

    for (int i = 0; i < products.Count; i++)
    {
    Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
}

void ViewByCategory()
{
    Console.WriteLine($"Item Categories:");

    for (int i = 0; i < productTypes.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {productTypes[i].Name}");
    };

    Console.WriteLine("Enter category number: ");
    int response = int.Parse(Console.ReadLine().Trim());

    while (response > productTypes.Count || response < 1)
    {
    Console.WriteLine($"Choose a number between 1 and {productTypes.Count}!");
    response = int.Parse(Console.ReadLine().Trim());
    };

    List<Product> filtered = products.Where(product => product.ProductTypeId == productTypes[response - 1].Id).ToList();

    if (filtered.Count == 0)
    {
        Console.WriteLine("No products in this category");
        return;
    }

    ProductType selectedType = productTypes[response - 1];
    Console.WriteLine($"{selectedType.Name}:");
    foreach (Product product in filtered)
    {
        Console.WriteLine($"{product.Name}, ${product.Price}, {product.DaysOnShelf} days on shelf");
    }
}

//NOTE: need to work on add, delete, update next. sorts by categories now. 


/*
   products.Where(p => p.ProductTypeId == productTypes[catChoice - 1].Id).ToList();

    if (filtered.Count == 0)
    {
        Console.WriteLine("No products in that category");
    }

    Console.WriteLine($"{type.Name}, ${type.Price}, ${type.DaysOnShelf} days on shelf");

    string productTypeNames productTypes.Where(t => t.Name()).ToList();

    foreach (string ProductType in productTypeNames)
    {
        Console.WriteLine(ProductType);
    }
    */


    



/*
Console.WriteLine(@"Products:
1 apparel
2. potions
3. enchanted objects
4. wands
5. dog");

Console.WriteLine("Please enter a category number: ");

int response = int.Parse(Console.ReadLine().Trim());

while (response > products.Count || response < 1)
{
    Console.WriteLine($"Choose a number between 1 and {products.Count}!");
    response = int.Parse(Console.ReadLine().Trim());
}

Product chosenProduct = products[response - 1];

DateTime now = DateTime.Now;

TimeSpan timeInStock = now - chosenProduct.DateEntered;


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
