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
        
        [Required]
        [Display(Name = "Start Location : ")]
        public string StartLocation { get; set; }

        [Required]
        [Display(Name = "End Location : ")]
        public string EndLocation { get; set; }

        [Required]
        [Display(Name = "Distance : ")]
        public float Distance { get; set; }

        
        [Display(Name = "Expense : ")]
        public float Expense { get; set; }

        [Required]
        [Display(Name = "Select a Vehicle type : ")]
        public string VehicleType { get; set; }

        
        [Display(Name = "Fare Rate : ")]
        public float FareRate { get; set; }
        
        [Required]
        [Display(Name = "Select a Payment type")]
        public string PaymentType { get; set; }

    }
}