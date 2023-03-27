using System;

namespace ParkingManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("     WELCOME TO OUR PARKING");
            Console.WriteLine("--------------------------------------");


            do
            {
                Console.WriteLine("Please choose one of the options:");
                Console.WriteLine("1.Park");
                Console.WriteLine("2.Leave from the parking");
                Console.WriteLine("3.Buy your prepaid ticket");

                var userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Implement Park");
                        break;
                    case "2":
                        Console.WriteLine("Implement Leaving from parking");
                        break;
                    case "3":
                        Console.WriteLine("Implement Buying prepaid ticket");
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
                Console.WriteLine("Would you want to continue?Enter no for exit.");
                var input = Console.ReadLine();
                if (input.ToLower().Trim() == "no")
                {
                    break;
                }
            } while (true);
        }
    }
}
