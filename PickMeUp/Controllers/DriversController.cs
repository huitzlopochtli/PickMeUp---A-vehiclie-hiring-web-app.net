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

        
    }
}