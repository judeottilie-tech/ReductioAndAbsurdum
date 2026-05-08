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
}

void ListProducts()
{
    Console.WriteLine("Products:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
}

void ViewByCategory()
{
    Console.WriteLine("Item Categories:");
    for (int i = 0; i < productTypes.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {productTypes[i].Name}");
    }

    Product chosenType = null;
    while (chosenType == null)
    {
        Console.WriteLine("Enter category number: ");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenType = new Product() { ProductTypeId = productTypes[response - 1].Id };

            List<Product> filtered = products.Where(product => product.ProductTypeId == chosenType.ProductTypeId).ToList();

            if (filtered.Count == 0)
            {
                Console.WriteLine("No products in this category.");
                return;
            }

            ProductType selectedType = productTypes[response - 1];
            Console.WriteLine($"{selectedType.Name}:");
            foreach (Product product in filtered)
            {
                Console.WriteLine($"{product.Name}, ${product.Price}, {product.DaysOnShelf} days on shelf");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing category only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do better!");
        }
    }
}

void AddProduct()
{
    Console.WriteLine("Enter product name: ");
    string name = Console.ReadLine().Trim();

    Console.WriteLine("Enter price: ");
    decimal price = 0;
    try
    {
        price = decimal.Parse(Console.ReadLine().Trim());
    }
    catch (FormatException)
    {
        Console.WriteLine("Please type only numbers!");
        return;
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
        Console.WriteLine("Do better!");
        return;
    }

    Console.WriteLine("Categories: ");
    for (int i = 0; i < productTypes.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {productTypes[i].Name}");
    }

    Console.WriteLine("Enter category number: ");
    try
    {
        int response = int.Parse(Console.ReadLine().Trim());
        products.Add(new Product()
        {
            Name = name,
            Price = price,
            Sold = false,
            ProductTypeId = productTypes[response - 1].Id,
            DateEntered = DateTime.Now
        });
        Console.WriteLine($"{name} added!");
    }
    catch (FormatException)
    {
        Console.WriteLine("Please type only integers!");
    }
    catch (ArgumentOutOfRangeException)
    {
        Console.WriteLine("Please choose an existing category only!");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
        Console.WriteLine("Do better!");
    }
}

void DeleteProduct()
{
    ListProducts();
    Product chosenProduct = null;
    while (chosenProduct == null)
    {
        Console.WriteLine("Which product do you want to remove? ");
        try
        {
            int removeItem = int.Parse(Console.ReadLine().Trim());
            Product removeProduct = products[removeItem - 1];
            products.Remove(removeProduct);
            Console.WriteLine($"{removeProduct.Name} has been removed.");
            chosenProduct = removeProduct;
        }
        catch (FormatException)
        {
            Console.WriteLine("Please only enter a number");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please only choose an existing menu item");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("There was an error. Please try again.");
        }
    }
}

void UpdateProduct()
{
    ListProducts();

    Product toUpdate = null;
    while (toUpdate == null)
    {
        Console.WriteLine("Enter the number of the product you want to update: ");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            toUpdate = products[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do better!");
        }
    }

    Console.WriteLine(@$"Current details:
    Name: {toUpdate.Name}
    Price: {toUpdate.Price}
    Category: {toUpdate.ProductTypeId}");

    Console.WriteLine($"Current name: {toUpdate.Name}. New name: ");
    string newName = Console.ReadLine().Trim();
    if (!string.IsNullOrEmpty(newName))
    {
        toUpdate.Name = newName;
    }

    Console.WriteLine($"Current price: {toUpdate.Price}. New price: ");
    string newPrice = Console.ReadLine().Trim();
    if (!string.IsNullOrEmpty(newPrice))
    {
        try
        {
            toUpdate.Price = decimal.Parse(newPrice);
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only numbers! Keeping current price.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do better!");
        }
    }

    Console.WriteLine("Categories:");
    for (int i = 0; i < productTypes.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {productTypes[i].Name}");
    }

    Console.WriteLine($"Current category: {toUpdate.ProductTypeId}. Choose a new category number: ");
    try
    {
        int newCategory = int.Parse(Console.ReadLine().Trim());
        toUpdate.ProductTypeId = productTypes[newCategory - 1].Id;
    }
    catch (FormatException)
    {
        Console.WriteLine("Please type only integers! Keeping current category.");
    }
    catch (ArgumentOutOfRangeException)
    {
        Console.WriteLine("Please choose an existing category only! Keeping current category.");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
        Console.WriteLine("Do better!");
    }

    Console.WriteLine(@$"Updated details:
    Name: {toUpdate.Name}
    Price: {toUpdate.Price}
    Category: {toUpdate.ProductTypeId}
    
    Product updated!");
}

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
