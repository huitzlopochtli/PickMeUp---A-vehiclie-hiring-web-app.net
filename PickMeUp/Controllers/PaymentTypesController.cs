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
    [Authorize(Roles ="Admin")]
    public class PaymentTypesController : Controller
    {
        private IPaymentTypeRepository _paymentTypeRepository;

        public PaymentTypesController()
        {

        }

        public PaymentTypesController(IPaymentTypeRepository paymentTypeRepository)
        {
            _paymentTypeRepository = paymentTypeRepository;
        }

        // GET: PaymentTypes
        public ActionResult Index()
        {
            return View();
        }

        // GET: PaymentTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentType paymentType = _paymentTypeRepository.Get(id);
                //db.PaymentType.Find(id);
            if (paymentType == null)
            {
                return HttpNotFound();
            }
            return View(paymentType);
        }

        // GET: PaymentTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] PaymentType paymentType)
        {
            if (ModelState.IsValid)
            {
                //db.PaymentType.Add(paymentType);
                //db.SaveChanges();
                _paymentTypeRepository.Add(paymentType);

                return RedirectToAction("Index");
            }

            return View(paymentType);
        }

        // GET: PaymentTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentType paymentType = _paymentTypeRepository.Get(id);
                //db.PaymentType.Find(id);
            if (paymentType == null)
            {
                return HttpNotFound();
            }
            return View(paymentType);
        }

        // POST: PaymentTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] PaymentType paymentType)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(paymentType).State = EntityState.Modified;
                //db.SaveChanges();
                _paymentTypeRepository.Update(paymentType);
                return RedirectToAction("Index");
            }
            return View(paymentType);
        }

        // GET: PaymentTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentType paymentType = _paymentTypeRepository.Get(id);
                //db.PaymentType.Find(id);
            if (paymentType == null)
            {
                return HttpNotFound();
            }
            return View(paymentType);
        }

        // POST: PaymentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            PaymentType paymentType = _paymentTypeRepository.Get(id);
            _paymentTypeRepository.Remove(paymentType);
            //db.PaymentType.Find(id);
            //db.PaymentType.Remove(paymentType);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _paymentTypeRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
