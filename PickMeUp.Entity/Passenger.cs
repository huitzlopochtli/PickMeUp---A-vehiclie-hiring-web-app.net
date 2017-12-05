using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PickMeUp.Entity
{
    public class Passenger
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public User User { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }

        public float WalletBalance { get; set; }

        public int TotalRides { get; set; }

        public float RewordPoint { get; set; }
    }
}
