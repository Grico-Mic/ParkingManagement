using ParkingManagement.Models;
using System;
using System.Collections.Generic;

namespace ParkingManagement.Repositories
{
    public class PrepaidTicketRepository
    {
        public PrepaidTicketRepository()
        {
            Data = new List<PrepaidTicket>();
        }
        public List<PrepaidTicket> Data { get; set; }

        public void Create(PrepaidTicket prepaidticket)
        {
            Data.Add(prepaidticket);
        }
    }
}
