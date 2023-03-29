using ParkingManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingManagement.Repositories
{
    public class PrepaidTicketRepository
    {
        public PrepaidTicketRepository()
        {
            Data = new List<PrepaidTicket>();
        }
        private List<PrepaidTicket> Data { get; set; }

        public void Create(PrepaidTicket prepaidticket)
        {
            prepaidticket.Id = GenerateId();
            Data.Add(prepaidticket);
        }
        public PrepaidTicket GetValidByRegNumber(string userInputRegistrationNumber)
        {
           return Data.FirstOrDefault(x => x.RegistrationNumber == userInputRegistrationNumber && x.IsValid(DateTime.Now));
        }

        private int GenerateId()
        {
            var newId = 0;
            if (Data.Any())
            {
                newId = Data.Max(x => x.Id);
            }
            return newId + 1;
        }

       
    }


}
