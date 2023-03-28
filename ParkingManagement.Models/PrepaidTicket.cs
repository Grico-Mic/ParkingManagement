using System;

namespace ParkingManagement.Models
{
    public class PrepaidTicket
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public decimal PricePerMonths { get; set; }

        public DateTime DateCreated { get; set; }
        public int NumberOfMonthsValid { get; set; }


        public bool IsValid(DateTime currentDate)
        {
            return currentDate < DateCreated.AddMonths(NumberOfMonthsValid);
        }

        public decimal CalculatePrice()
        {
            return PricePerMonths * NumberOfMonthsValid;
        }
    }
}
