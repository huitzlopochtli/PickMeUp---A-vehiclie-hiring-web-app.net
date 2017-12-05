using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PickMeUp.Controllers
{
    public class DriversController : Controller
    {
        // GET: Drivers
        public ActionResult Index()
        {
            return View();
        }
    }
}