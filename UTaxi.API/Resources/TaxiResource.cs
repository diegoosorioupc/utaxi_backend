﻿namespace UTaxi.API.Resources
{
    public class TaxiResource
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int RegistrationNumber { get; set; }
        public string VehicleStatus { get; set; }
        public int Capacity { get; set; }
    }
}