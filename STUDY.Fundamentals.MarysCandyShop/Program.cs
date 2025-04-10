﻿var isMenuRunning = true;
string docPath = @"C:\Users\LAMPROS\Desktop\C# Academy\StudyProjects\STUDY.Fundamentals.MarysCanhdyShop\STUDY.Fundamentals.MarysCandyShop\history.txt";
string[] candyNames = { "Rainbow Lollipops", "Cotton Candy Clouds", "Choco-Caramel Delights", "Gummy Bear Bonanza", "Minty Chocolate Truffles", "Jellybean Jamboree", "Fruity Taffy Twists", "Sour Patch Surprise", "Crispy Peanut Butter Cups", "Rock Candy Crystals" };

var products = new Dictionary<int, string>();

var divide = "---------------------------------";

//SeedData();

//if (File.Exists(docPath))
//{
//    LoadData();
//}

LoadData();

while (isMenuRunning)
{
    PrintHeader();

    var usersChoice = Console.ReadLine().Trim().ToUpper();
    var menuMessage = "Press Any Key To Go Back to Menu";

    switch (usersChoice)
    {
        case "A":
            AddProduct();
            break;
        case "D":
            DeleteProduct("User chose D");
            break;
        case "V":
            ViewProducts();
            break;
        case "U":
            UpdateProduct("User chose U");
            break;
        case "Q":
            menuMessage = "Goodbye";
            SaveProducts();
            isMenuRunning = false;
            break;
        default:
            Console.WriteLine("Invalid choice. Please choose one of the above");
            break;
    }

    Console.WriteLine(menuMessage);
    Console.ReadLine();
    Console.Clear();
}

void SeedData()
{
    for (int i = 0; i < candyNames.Length; i++)
    {
        products.Add(i + 1, candyNames[i]);
    }
}

void AddProduct()
{
    Console.WriteLine("Product name:");
    var product = Console.ReadLine();
    var index = products.Count();
    products.Add(index, product.Trim());
}

void DeleteProduct(string message)
{
    Console.WriteLine(message);
}

void UpdateProduct(string message)
{
    Console.WriteLine(message);
}

void ViewProducts()
{
    Console.WriteLine(divide);
    foreach (var product in products)
    {
        Console.WriteLine($"{product.Key}: {product.Value}");
    }
    Console.WriteLine(divide);
}

void PrintHeader()
{
    var title = "Mary's Candy Shop";
    var divide = "---------------------------------";
    var dateTime = DateTime.Now;
    var daysSinceOpening = GetDaysSinceOpening();
    var todaysProfit = 5.5m;
    var targetAchieved = false;
    string menu = GetMenu();

    Console.WriteLine(@$"{title}
{divide}
Today's date: {dateTime}
Days since opening: {daysSinceOpening}
Today's profit: {todaysProfit}$
Today's target achieved: {targetAchieved}
{divide}
{menu}");
}

string GetMenu()
{
    return "Choose one option:\n"
        + 'V' + " to view products\n"
        + 'A' + " to add product\n"
        + 'D' + " to delete product\n"
        + 'U' + " to update product\n"
        + 'Q' + " to quit the program\n";
}

int GetDaysSinceOpening()
{
    var openingDate = new DateTime(2023, 1, 1);
    var days = DateTime.Now - openingDate;

    return days.Days;
}

void SaveProducts()
{
    try
    {
        using (StreamWriter outputFile = new StreamWriter(docPath))
        {
            foreach (KeyValuePair<int, string> product in products)
            {
                outputFile.WriteLine($"{product.Key}, {product.Value}");
            }
        }
        Console.WriteLine("Products saved");
    }
    catch (Exception ex)
    {
        Console.WriteLine("There was an error when trying to save products: " + ex.Message);
        Console.WriteLine(divide);
        
    }
    
}

void LoadData()
{
    try
    {
        using (StreamReader reader = new(docPath))
        {
            var line = reader.ReadLine();

            while (line != null)
            {
                string[] parts = line.Split(',');
                products.Add(int.Parse(parts[0]), parts[1]);
                line = reader.ReadLine();
            }
        }
    }
    catch (Exception ex) 
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine(divide);
    }
    
}