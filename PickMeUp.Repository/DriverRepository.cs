using PickMeUp.Entity;
using PickMeUp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Repository
{
    public class DriverRepository : Repository<Driver>, IDriverRepository
    {
        public IEnumerable<Driver> GetAllAvalible(string vehicleType)
        {
            var vehiclesDriverId = Context.Vehicles.Where(v => v.VehicleType.Name == vehicleType).Select(v => v.DriverId).ToList();
            return Context.Drivers.Where(d => d.Status == Status.Availble && vehiclesDriverId.Contains(d.Id)).ToList();
        }

        
    }
}
