using PickMeUp.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PickMeUp.Models.Passenger
{
    public class PassengersViewModel
    {

        public PassengersViewModel()
        {

        }

        public PassengersViewModel(PickMeUp.Entity.Passenger passenger, Ride ride, PaymentType paymentType, VehicleType vehicleType)
        {
            Id = passenger.Id;
            RideId = ride.Id;
            StartLocation = ride.StartLocation;
            EndLoaction = ride.EndLocation;
            VehicleTypeId = vehicleType.Id;
            VehicleType = vehicleType.Name;
            FareRate = vehicleType.FareRate;
            PaymentTypeId = paymentType.Id;
            PaymentType = paymentType.Name;
        }


        public int Id { get; set; }

        public int RideId { get; set; }

        [Required]
        [Display(Name = "Start Location : ")]
        public string StartLocation { get; set; }

        [Required]
        [Display(Name = "End Location : ")]
        public string EndLoaction { get; set; }

        [Display(Name = "Distance : ")]
        public float Distance { get; set; }

        [Display(Name = "Expense : ")]
        public float Expense { get; set; }


        public int VehicleTypeId { get; set; }
        [Required]
        [Display(Name = "Select a Vehicle type : ")]
        public string VehicleType { get; set; }

        [Display(Name = "Fare Rate : ")]
        public float FareRate { get; set; }

        public int PaymentTypeId { get; set; }
        [Required]
        [Display(Name = "Select a Payment type")]
        public string PaymentType { get; set; }

    }
}