using FundamentalsChallenge.Models;

// Sets encoding as UTF8 in order to display accentuation
Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Welcome to the parking lot system!");

Utils.GetAndConvertValue(out decimal starterFare, "Type in the starter fare:");

Utils.GetAndConvertValue(out decimal hourlyRate, "Now type in the hourly rate:");

// Instantiates the ParkingLot class with the previously obtained values
ParkingLot es = new(starterFare, hourlyRate);

bool displayMenu = true;

// Performs the menu loop
while (displayMenu)
{
    Console.Clear();
    Console.WriteLine("Type in your option:");
    Console.WriteLine("1 - Register vehicle");
    Console.WriteLine("2 - Remove vehicle");
    Console.WriteLine("3 - List vehicles");
    Console.WriteLine("4 - Close");

    switch (Console.ReadLine())
    {
        case "1":
            es.AddVehicle();
            break;

        case "2":
            es.RemoveVehicle();
            break;

        case "3":
            es.ListVehicles();
            break;

        case "4":
            displayMenu = false;
            break;

        default:
            Console.WriteLine("Invalid option");
            break;
    }

    Utils.PressKeyToContinue();
}

Console.WriteLine("The program has shut down");
