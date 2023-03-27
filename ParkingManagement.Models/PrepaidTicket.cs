using System;

namespace ParkingManagement.Models
{
    public class PrepaidTicket
    {
        public int RegistrationNumber { get; set; }
        public decimal PricePerMonths { get; set; }

        public DateTime ValidFrom { get; set; }
        public int MonthsValid { get; set; }


        public bool IsValid(DateTime currentDate)
        {
            return currentDate < ValidFrom.AddMonths(MonthsValid);
        }
    }
}
