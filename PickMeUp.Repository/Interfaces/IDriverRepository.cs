using PickMeUp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Repository.Interfaces
{
    public interface IDriverRepository : IRepository<Driver>
    {
        IEnumerable<Driver> GetAllAvalible(string vehicleType);

        
    }
}
