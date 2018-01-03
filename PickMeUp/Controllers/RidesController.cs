using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PickMeUp.Data;
using PickMeUp.Entity;
using PickMeUp.Repository.Interfaces;

namespace PickMeUp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RidesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private IRideRepository _rideRepository;

        public RidesController(IRideRepository rideRepository)
        {
            _rideRepository = rideRepository;
        }

        // GET: Rides
        public ActionResult Index()
        {
            var rides = _rideRepository.GetAllRidesAdmin();
            return View(rides.ToList());
        }

        // GET: Rides/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ride ride = db.Rides.Find(id);
            if (ride == null)
            {
                return HttpNotFound();
            }
            return View(ride);
        }

        

        
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
