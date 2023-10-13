using System.Text.RegularExpressions;

namespace FundamentalsChallenge.Models
{
    public class ParkingLot
    {
        private decimal starterFare = 0;
        private decimal hourlyRate = 0;
        private List<string> vehicles = new();
        private readonly Regex oldRegex = new(@"^[a-z]{3}-?\d{4}$", RegexOptions.IgnoreCase);
        private readonly Regex mercosulRegex = new(@"^[a-z]{3}[0-9][0-9a-z][0-9]{2}$", RegexOptions.IgnoreCase);

        public ParkingLot(decimal starterFare, decimal hourlyRate)
        {
            this.starterFare = starterFare;
            this.hourlyRate = hourlyRate;
        }

        #nullable enable
        private string CheckAndFormatPlate(string? plate) {
        #nullable disable
            switch (Utils.CheckNullish(plate).ToUpper())
            {
                case var oldFormat when oldRegex.IsMatch(oldFormat!):
                    if (!oldFormat.Contains('-')) {
                        return oldFormat.Insert(3, "-");
                    }
                    return oldFormat;
                case var mercosulFormat when mercosulRegex.IsMatch(mercosulFormat):
                    return mercosulFormat;
                default:
                    throw new ArgumentException($"Invalid license plate: {plate}");
            }
        }

        public void AddVehicle()
        {
            Console.WriteLine("Type in the license plate of the vehicle to be parked:");

            try {
                string input = Console.ReadLine();
                string plate = CheckAndFormatPlate(input);

                if (vehicles.Any(x => x == plate)) {
                    throw new Exception($"There's already a parked car with the following license plate: {plate}");
                }
                vehicles.Add(plate);
            } catch (Exception err) {
                Console.WriteLine(err.Message);
            }
        }

        public void RemoveVehicle() {
            try {
                Console.WriteLine("Type in the license plate of the vehicle to be removed:");

                string input = Console.ReadLine();
                string plate = CheckAndFormatPlate(input);

                // Checks whether the vehicle exists
                if (vehicles.Any(x => x == plate)) {
                    Utils.GetAndConvertValue(out int horas, "Type in the amount of hours the vehicle has been parked for:");

                    decimal valorTotal = starterFare + hourlyRate * horas; 

                    vehicles.Remove(plate);

                    Console.WriteLine($"The vehicle with the {plate} license plate has been removed, and the total amount to pay is: R$ {valorTotal}");
                } else {
                    Console.WriteLine("Sorry, this vehicle isn't parked here. Please check whether the license plate has been correctly typed.");
                }
            } catch (Exception err) {
                Console.WriteLine(err.Message);
            }
        }

        public void ListVehicles() {
            // Checks whether there are vehicles in the parking lot
            if (vehicles.Any()) {
                Console.WriteLine("The currently parked vehicles are:");
                
                foreach (var item in vehicles) {
                    Console.WriteLine($"- {item}");
                }
            } else {
                Console.WriteLine("There are no currently parked vehicles.");
            }
        }
    }
}
