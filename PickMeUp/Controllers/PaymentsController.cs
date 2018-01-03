using PickMeUp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PickMeUp.Controllers
{
    public class PaymentsController : Controller
    {
        private IPaymentRepository _paymentRepository;

        public PaymentsController()
        {
                
        }

        public PaymentsController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        // GET: Payments
        public ActionResult Index()
        {
            var b = _paymentRepository.GetAllWithPaymentType();
            return View(b);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            return View();
        }
    }
}