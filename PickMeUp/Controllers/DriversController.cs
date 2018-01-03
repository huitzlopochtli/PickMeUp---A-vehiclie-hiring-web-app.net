using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PickMeUp.Entity;
using PickMeUp.Models.Driver;
using PickMeUp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PickMeUp.Controllers
{
    [Authorize(Roles = "Driver")]
    public class DriversController : Controller
    {
        private IRideRepository _rideRepository;
        private IPaymentRepository _paymentRepository;
        private IDriverRepository _driverRepository;
        private IVehicleRepository _vehicleRepository;
        private IVehicleTypeRepository _vehicleTypeRepository;
        User user;
        

        public DriversController()
        {

        }

        public DriversController(IRideRepository rideRepository, IPaymentRepository paymentRepository, IDriverRepository driverRepository, IVehicleRepository vehicleRepository, IVehicleTypeRepository vehicleTypeRepository)
        {
            _rideRepository = rideRepository;
            _paymentRepository = paymentRepository;
            _driverRepository = driverRepository;
            _vehicleRepository = vehicleRepository;
            _vehicleTypeRepository = vehicleTypeRepository;
            user = System.Web.HttpContext.Current.GetOwinContext()
                            .GetUserManager<ApplicationUserManager>()
                            .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            
        }

        // GET: Drivers
        public ActionResult Index()
        {
            Driver driver = _driverRepository.GetDriverByUserId(user.Id);
            Vehicle vehicle = _vehicleRepository.GetVehicleByDriverId(driver.Id);


            VehicleType vehicleType = _vehicleTypeRepository.Get(vehicle.VehicleTypeId);


            var RidesForDriver = _rideRepository.GetRidesForDriver(RideStatus.NotAccepted, vehicleType.Id);

            var ListRide = new List<DriversViewModel>();

            foreach (var ride in RidesForDriver)
                ListRide.Add(new DriversViewModel(ride));


            return View(ListRide);
        }

        public ActionResult Accept(int? id)
        {
            DriversViewModel model = new DriversViewModel(_rideRepository.GetWithPayment(id));
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Accept(DriversViewModel model)
        {
            Driver driver = _driverRepository.GetDriverByUserId(user.Id);

            if(driver.Status == Status.Driving)
            {
                return RedirectToAction("Error");
            }
            driver.Status = Status.Driving;
            _driverRepository.Update(driver);

            Ride ride = _rideRepository.Get(model.Id);

            model.Amount = _paymentRepository.Get(ride.PaymentId).Amount;

            ride.DriverId = driver.Id;
            ride.RideStatus = RideStatus.OnGoing;
            ride.StartTime = System.DateTime.Now;

            _rideRepository.Update(ride);


            return RedirectToAction("AcceptedRide", "Drivers", model);
        }

        public ActionResult AcceptedRide(DriversViewModel model)
        {
            return View(model);
        }

        public ActionResult FinishRide(int? id)
        {
            Ride ride = _rideRepository.Get(id);
            ride.RideStatus = RideStatus.Finished;
            ride.EndTime = System.DateTime.Now;
            _rideRepository.Update(ride);

            Driver driver = _driverRepository.GetDriverByUserId(user.Id);
            driver.Status = Status.Availble;
            _driverRepository.Update(driver);

            Payment payment = _paymentRepository.Get(ride.PaymentId);
            payment.Payed = true;
            _paymentRepository.Update(payment);





            return RedirectToAction("Index");
        }

        public ActionResult AllRides()
        {
            Driver driver = _driverRepository.GetDriverByUserId(user.Id);


            var rides = _rideRepository.GetAllRidesForDriver(driver.Id);
            ViewBag.TotalAmount = 0;


            foreach (var r in rides)
            {
                if (r.RideStatus == RideStatus.Finished)
                    ViewBag.TotalAmount += r.Payment.Amount;
            }

            return View(rides);
        }
    }
}