using PickMeUp.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PickMeUp.Models.Admin
{
    public class VehicleTypeViewModel
    {
        public VehicleTypeViewModel()
        {

        }
        public VehicleTypeViewModel(VehicleType vehicleType)
        {
            Id = vehicleType.Id;
            Name = vehicleType.Name;
            FareRate = vehicleType.FareRate;
        }


        public int Id { get; set; }

        [Required]
        [Display(Name = "Vehicle Type")]
        public string Name { get; set; }


        [Required]
        [Display(Name = "Fare rate")]
        public float  FareRate { get; set; }
    }
}