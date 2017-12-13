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
    public class RideRepository : Repository<Ride>, IRideRepository
    {
        public void AcceptRide(Ride ride, Driver driver)
        {
            ride.DriverId = driver.Id;
            Context.Rides.Attach(ride);
            Context.Entry(ride).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void AcceptRide(int? id, int? driverId)
        {
            var ride = Context.Rides.Find(id);
            ride.DriverId = driverId;
            Context.Rides.Attach(ride);
            Context.Entry(ride).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void CancelRideByPassenger(Ride ride)
        {
            ride.RideStatus = RideStatus.Cancelled;
            Context.Rides.Attach(ride);
            Context.Entry(ride).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void CancelRideByPassengerId(int? id)
        {
            var ride = Context.Rides.Find(id);
            ride.RideStatus = RideStatus.Cancelled;
            Context.Rides.Attach(ride);
            Context.Entry(ride).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public IEnumerable<Ride> GetRidesForDriver(RideStatus rideStatus, int vehicleTypeId)
        {
            return Context.Rides.Include("Payment").Where(vt => vt.RideStatus == rideStatus && vt.VehicleTypeId == vehicleTypeId).ToList();
        }

        public Ride GetWithPayment(int? id)
        {
            return Context.Rides.Include("Payment").Where(r => r.Id == id).SingleOrDefault();
        }

        public void StartRide(Ride ride)
        {
            ride.StartTime = System.DateTime.Now;
            ride.RideStatus = RideStatus.OnGoing;
            Context.Rides.Attach(ride);
            Context.Entry(ride).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void StartRideById(int? rideId)
        {
            var ride = Context.Rides.Find(rideId);
            ride.StartTime = System.DateTime.Now;
            Context.Rides.Attach(ride);
            Context.Entry(ride).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void StopRide(Ride ride)
        {
            ride.EndTime = System.DateTime.Now;
            ride.RideStatus = RideStatus.Finished;
            Context.Rides.Attach(ride);
            Context.Entry(ride).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void StopRideById(int? rideId)
        {
            var ride = Context.Rides.Find(rideId);

            ride.EndTime = System.DateTime.Now;
            ride.RideStatus = RideStatus.Finished;
            Context.Rides.Attach(ride);
            Context.Entry(ride).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
