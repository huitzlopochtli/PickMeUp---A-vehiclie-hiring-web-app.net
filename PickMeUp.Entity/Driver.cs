using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Entity
{
    public class Driver
    {
        [Key]
        public int  Id { get; set; }

        [Index(IsUnique = true)]
        [StringLength(200)]
        public string DrivingLicence { get; set; }

        public User User { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }

        public float Earnings { get; set; }

        public int TotalRides { get; set; }

        public Status Status { get; set; }

    }

    public enum Status
    {
        Availble = 0,
        Driving = 1,
        Unavailable = 2
    }
}
 