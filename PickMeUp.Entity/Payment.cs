using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Entity
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        public float Amount { get; set; }

        public bool Payed { get; set; }

        public Passenger Passenger { get; set; }
        [ForeignKey("Passenger")]
        public int PassengerId { get; set; }
    }

    public class PaymentType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
