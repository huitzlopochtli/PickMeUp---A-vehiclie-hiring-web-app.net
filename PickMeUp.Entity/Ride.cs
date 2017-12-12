using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Entity
{
    public class Ride
    {
        public int Id { get; set; }

        public Driver Driver { get; set; }
        [ForeignKey("Driver")]
        public int? DriverId { get; set; }

        public Passenger Passenger { get; set; }
        [ForeignKey("Passenger")]
        public int PassengerId { get; set; }

        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public string StartLocation { get; set; }
        public string EndLocation { get; set; }

        public Payment Payment { get; set; }
        [ForeignKey("Payment")]
        public int PaymentId { get; set; }

        public RideStatus RideStatus { get; set; }

    }

    public enum RideStatus
    {
        Finished = 1,
        Cancelled = 2,
        OnGoing = 3,
        NotAccepted = 0
    }
}
