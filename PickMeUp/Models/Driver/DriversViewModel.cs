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


        public string StartLocation { get; set; }

        public string EndLocation { get; set; }

        public bool Payed { get; set; }

        public float Amount { get; set; }
    }
}