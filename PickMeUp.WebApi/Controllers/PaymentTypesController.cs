using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using PickMeUp.Data;
using PickMeUp.Entity;
using PickMeUp.Repository.Interfaces;

namespace PickMeUp.WebApi.Controllers
{
    [EnableCorsAttribute("*","*","*")]
    public class PaymentTypesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly IPaymentTypeRepository _paymentTypeRepository;

        public PaymentTypesController()
        {
            
        }

        public PaymentTypesController(IPaymentTypeRepository paymentTypeRepository)
        {
            _paymentTypeRepository = paymentTypeRepository;
        }

        // GET: api/PaymentTypes
        public IHttpActionResult GetPaymentType()
        {
            //return db.PaymentType;

            return  Ok(_paymentTypeRepository.GetAll());
        }

        // GET: api/PaymentTypes/5
        [ResponseType(typeof(PaymentType))]
        public IHttpActionResult GetPaymentType(int id)
        {
            //PaymentType paymentType = db.PaymentType.Find(id);
            PaymentType paymentType = _paymentTypeRepository.Get(id);
            if (paymentType == null)
            {
                return NotFound();
            }

            return Ok(paymentType);
        }

        // PUT: api/PaymentTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPaymentType(int id, PaymentType paymentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paymentType.Id)
            {
                return BadRequest();
            }

            //db.Entry(paymentType).State = EntityState.Modified;

            try
            {
                _paymentTypeRepository.Update(paymentType);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PaymentTypes
        [ResponseType(typeof(PaymentType))]
        public IHttpActionResult PostPaymentType(PaymentType paymentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //db.PaymentType.Add(paymentType);
            //db.SaveChanges();
            _paymentTypeRepository.Add(paymentType);

            return CreatedAtRoute("DefaultApi", new { id = paymentType.Id }, paymentType);
        }

        // DELETE: api/PaymentTypes/5
        [ResponseType(typeof(PaymentType))]
        public IHttpActionResult DeletePaymentType(int id)
        {
            //PaymentType paymentType = db.PaymentType.Find(id);
            PaymentType paymentType = _paymentTypeRepository.Get(id);
            if (paymentType == null)
            {
                return NotFound();
            }

            //db.PaymentType.Remove(paymentType);
            //db.SaveChanges();

            _paymentTypeRepository.Remove(paymentType);

            return Ok(paymentType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _paymentTypeRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PaymentTypeExists(int id)
        {
            return _paymentTypeRepository.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}