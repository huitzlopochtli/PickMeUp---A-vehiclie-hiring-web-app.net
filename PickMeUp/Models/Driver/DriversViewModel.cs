using PickMeUp.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PickMeUp.Models.Driver
{
    public class DriversViewModel
    {

        public DriversViewModel()
        {

        }

        public DriversViewModel(Ride ride)
        {
            Id = ride.Id;
            StartLocation = ride.StartLocation;
            EndLocation = ride.EndLocation;
            Payed = ride.Payment.Payed;
            Amount = ride.Payment.Amount;
        }

        public int Id { get; set; }

        [Display(Name = "Start Location")]
        public string StartLocation { get; set; }
        [Display(Name = "End Location")]
        public string EndLocation { get; set; }

        [Display(Name = "Is Ride Payed")]
        public bool Payed { get; set; }

        [Display(Name = "Charge")]
        public float Amount { get; set; }
    }
}