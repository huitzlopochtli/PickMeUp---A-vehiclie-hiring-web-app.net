using PickMeUp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Repository.Interfaces
{
    public interface IRideRepository : IRepository<Ride>
    {
        void StopRide(Ride ride);
        void StopRideById(int rideId);

        void StartRide(Ride ride);
        void StartRideById(int rideId);

        //Ride RequestRideByPassenger(int passengerId, string startLoc, string endLoc, VehicleType vehicleType);
        //RideStatus TrackRide(int passengerId);
    }
}
