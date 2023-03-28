using System;

namespace ParkingManagement.Models
{
    public class PrepaidTicket
    {
        public int RegistrationNumber { get; set; }
        public decimal PricePerMonths { get; set; }

        public DateTime ValidFrom { get; set; }
        public int NumberOfMonthsValid { get; set; }


        public bool IsValid(DateTime currentDate)
        {
            return currentDate < ValidFrom.AddMonths(NumberOfMonthsValid);
        }

        public decimal CalculatePrice(int userInput )
        {
            return PricePerMonths * NumberOfMonthsValid;
        }
    }
}
