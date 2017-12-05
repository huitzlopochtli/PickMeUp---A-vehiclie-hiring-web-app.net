using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Entity
{
    public class VehicleType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public float FareRate { get; set; }
    }
}
