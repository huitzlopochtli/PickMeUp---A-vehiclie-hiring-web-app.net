using PickMeUp.Entity;
using PickMeUp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Repository
{
    public class PassengerRepository : Repository<Passenger>, IPassengerRepository
    {
        public Passenger GetPassengerByUser(string userId)
        {
            return Context.Passengers.Where(p => p.UserId == userId).SingleOrDefault();
        }
    }
}
