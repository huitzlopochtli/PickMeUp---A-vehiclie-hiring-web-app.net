using PickMeUp.Entity;
using PickMeUp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Repository
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public Vehicle GetVehicleByDriver(Driver driver)
        {
            var vehicle = Context.Vehicles.Where(v => v.Driver == driver).SingleOrDefault();
            return vehicle;
        }

        public Vehicle GetVehicleByDriverId(int id)
        {
            var vehicle = Context.Vehicles.Where(v => v.DriverId == id).SingleOrDefault();
            return vehicle;
        }
    }
}
