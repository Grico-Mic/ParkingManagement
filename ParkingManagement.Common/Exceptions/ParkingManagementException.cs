using System;

namespace ParkingManagement.Common
{
    public class ParkingManagementException : Exception
    {
        public ParkingManagementException(string message) : base (message)
        {

        }
    }
}
