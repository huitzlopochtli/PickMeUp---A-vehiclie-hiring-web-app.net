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
        void StopRideById(int? rideId);

        void AcceptRide(Ride ride, Driver driver);
        void AcceptRide(int? id, int? driverId);

        void StartRide(Ride ride);
        void StartRideById(int? rideId);

        void CancelRideByPassenger(Ride ride);
        void CancelRideByPassengerId(int? id);

        IEnumerable<Ride> GetRidesForDriver(RideStatus rideStatus, int vehicleTypeId);

        Ride GetWithPayment(int? id);

        IEnumerable<Ride> GetAllRidesForDriver(int? id);
        IEnumerable<Ride> GetAllRidesForPassenger(int? id);

        //Ride RequestRideByPassenger(int passengerId, string startLoc, string endLoc, VehicleType vehicleType);
        //RideStatus TrackRide(int passengerId);
    }
}
