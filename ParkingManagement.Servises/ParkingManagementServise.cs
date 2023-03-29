using Newtonsoft.Json;
using ParkingManagement.Common;
using ParkingManagement.Models;
using ParkingManagement.Repositories;
using System;
using System.Collections.Generic;
using System.IO;

namespace ParkingManagement.Servises
{
    public class ParkingManagementServise
    {
        public ParkingManagementServise()
        {
            var config =  File.ReadAllText("ConfigFile.txt");
            var parsedConfig = JsonConvert.DeserializeObject<Config>(config);
            PricePerMonth = parsedConfig.PricePerMonth;
            PrepaidTicketRepository = new PrepaidTicketRepository();
        }

        private PrepaidTicketRepository PrepaidTicketRepository { get; set; }

       
        private decimal PricePerMonth { get; set; }
        public void BuyPrepaidTicket()
        {
            Console.WriteLine("Please enter registration number");
            var userInputRegistrationNumber = Console.ReadLine();
            ValidateRegistrationNumber(userInputRegistrationNumber);

            var ticket = PrepaidTicketRepository.GetValidByRegNumber(userInputRegistrationNumber);
            if (ticket != null)
            {
                throw new ParkingManagementException($"Valid ticket alredy exist with id{ticket.Id}");
            }

            Console.WriteLine("How manu months would you like?Max 12 months");
            var userInputMonthsWant = Console.ReadLine();
            var numberOfMonths =  ValidateInputMonths(userInputMonthsWant);

            var prepaidticket = new PrepaidTicket();

            prepaidticket.DateCreated = DateTime.Now;
            prepaidticket.RegistrationNumber = userInputRegistrationNumber;
            prepaidticket.NumberOfMonthsValid = numberOfMonths;
            prepaidticket.PricePerMonths = PricePerMonth;

            prepaidTicketRepository.Create(prepaidticket);
           

            Console.WriteLine($"The price of the ticket is {prepaidticket.CalculatePrice()}");
        }


        private int ValidateInputMonths(string monthsInput)
        {
            var validInt = int.TryParse(monthsInput, out int numberOfMonths);
            if (!validInt || numberOfMonths <= 0 || numberOfMonths > 12)
            {
                throw new ParkingManagementException("Invalid Input");
            }
            return numberOfMonths;
        }

        private void ValidateRegistrationNumber(string inputNumber)
        {
            if (inputNumber.Length > 12 || inputNumber.Length < 6)
            {
                throw new ParkingManagementException("Invalid plate number");
            }
        }
    }
}
