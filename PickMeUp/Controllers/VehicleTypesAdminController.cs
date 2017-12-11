using PickMeUp.Entity;
using PickMeUp.Models.Admin;
using PickMeUp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PickMeUp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class VehicleTypesController : Controller
    {
        private IVehicleTypeRepository _vehicleTypeRepository;

        public VehicleTypesController()
        {
        }

        public VehicleTypesController(IVehicleTypeRepository vehicleTypeRepository)
        {
            _vehicleTypeRepository = vehicleTypeRepository;
        }


        public ActionResult Index()
        {
            var vehicleTypes = _vehicleTypeRepository.GetAll();

            List<VehicleTypeViewModel> VehicleTypeViewModelList = new List<VehicleTypeViewModel>();

            foreach (var vehicleType in vehicleTypes)
            {
                VehicleTypeViewModelList.Add(new VehicleTypeViewModel(vehicleType));
            }
            return View(VehicleTypeViewModelList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                VehicleType vehicleType = new VehicleType() { FareRate = model.FareRate, Name = model.Name };
                _vehicleTypeRepository.Add(vehicleType);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vehicleType = _vehicleTypeRepository.Get(id);
            if (vehicleType == null)
            {
                return HttpNotFound();
            }

            return View(new VehicleTypeViewModel(vehicleType));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VehicleTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                VehicleType vehicleType = new VehicleType() { Name = model.Name, FareRate = model.FareRate, Id = model.Id };
                _vehicleTypeRepository.Update(vehicleType);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleType vehicleType = _vehicleTypeRepository.Get(id);
            if (vehicleType == null)
            {
                return HttpNotFound();
            }
            return View(new VehicleTypeViewModel(vehicleType));
        }


        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleType vehicleType = _vehicleTypeRepository.Get(id);
            if (vehicleType == null)
            {
                return HttpNotFound();
            }
            return View(new VehicleTypeViewModel(vehicleType));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {

            _vehicleTypeRepository.Remove(id);
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _vehicleTypeRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}