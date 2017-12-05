using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Entity
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }

        public string ModelName { get; set; }

        public string CompanyName { get; set; }

        public string Color { get; set; }

        public string RegNumber { get; set; }

        public DateTime RegDate { get; set; }

        public Driver Driver { get; set; }
        [ForeignKey("Driver")]
        public int DriverId { get; set; }

        public VehicleType VehicleType { get; set; }
        [ForeignKey("VehicleType")]
        public int VehicleId { get; set; }
    }
}
