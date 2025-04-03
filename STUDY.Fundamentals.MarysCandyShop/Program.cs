PrintHeader();

var usersChoice = Console.ReadLine().Trim().ToUpper();

switch (usersChoice)
{
    case "V":
        ViewProduct("User chose V");
        break;
    case "A":
        AddProduct("User chose A");
        break;
    case "D":
        DeleteProduct("User chose D");
        break;
    case "U":
        UpdateProduct("User chose U");
        break;
    default:
        Console.WriteLine("Invalid choice. Please choose one of the above");
        break;
}


void AddProduct(string message)
{
    Console.WriteLine(message);
}

void ViewProduct(string message)
{
    Console.WriteLine(message);
}

void DeleteProduct(string message)
{
    Console.WriteLine(message);
}

void UpdateProduct(string message)
{
    Console.WriteLine(message);
}
void PrintHeader()
{
    var title = "Mary's Candy Shop";
    var divide = "---------------------------------";
    var dateTime = DateTime.Now;
    var todaysProfit = 5.5m;
    var daysSinceOpening = GetDaysSinceOpening();
    var targetAchieved = false;
    var menu = GetMenu();

    Console.WriteLine($@"{title}
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
    + 'A' + " to add products\n"
    + 'D' + " to delete products\n"
    + 'U' + " to update products\n";
}

int GetDaysSinceOpening()
{
    var openingDate = new DateTime(2025, 1, 1);
    TimeSpan timeDifference = DateTime.Now - openingDate; // returns the time in nanoseconds.
    return timeDifference.Days; // returns an int with the time in days (____.Days method) 


}

