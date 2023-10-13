using System.ComponentModel;

namespace FundamentalsChallenge.Models
{
    public class Utils
    {
        public static void PressKeyToContinue () {
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }

        // Based on https://stackoverflow.com/a/35554808
        public static void GetAndConvertValue<T> (out T valor, string message) {
            bool success = false;
            valor = default;

            while (!success) {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
                
                if (converter != null) {
                    try {
                        Console.WriteLine(message);
                        valor = (T)converter.ConvertFromString(Console.ReadLine());
                        success = true;
                    } catch (Exception) {
                        Console.WriteLine("Invalid value! Try again.");
                        PressKeyToContinue();
                    }
                } else {
                    throw new ArgumentException("Invalid value type", typeof(T).Name);
                }
            }
        }

        #nullable enable
        public static string CheckNullish (string? text) {
        #nullable disable
            if (String.IsNullOrWhiteSpace(text?.Trim())) {
                throw new ArgumentException("You need to input a value!");
            }
            return text!;
        }
    }
}