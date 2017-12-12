using PickMeUp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Repository.Interfaces
{
    public interface IPassengerRepository : IRepository<Passenger>
    {
        Passenger GetPassengerByUser(string userId);
    }
}
