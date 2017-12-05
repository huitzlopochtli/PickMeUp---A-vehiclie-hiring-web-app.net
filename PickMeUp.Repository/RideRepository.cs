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
        public void StartRide(Ride ride)
        {
            ride.StartTime = System.DateTime.Now;
            ride.RideStatus = RideStatus.OnGoing;
            Context.Rides.Attach(ride);
            Context.Entry(ride).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void StartRideById(int rideId)
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

        public void StopRideById(int rideId)
        {
            var ride = Context.Rides.Find(rideId);

            ride.EndTime = System.DateTime.Now;
            ride.RideStatus = RideStatus.Finished;
            Context.Rides.Attach(ride);
            Context.Entry(ride).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void StopForDriver(Ride ride)
        {
            ride.EndTime = System.DateTime.Now;
            ride.RideStatus = RideStatus.NotAccepted;
            Context.Rides.Attach(ride);
            Context.Entry(ride).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void StopForDriver(int rideId)
        {
            var ride = Context.Rides.Find(rideId);

            ride.EndTime = System.DateTime.Now;
            ride.RideStatus = RideStatus.NotAccepted;
            Context.Rides.Attach(ride);
            Context.Entry(ride).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
