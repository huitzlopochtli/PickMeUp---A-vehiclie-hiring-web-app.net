using PickMeUp.Entity;
using PickMeUp.Models.Admin;
using PickMeUp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PickMeUp.Controllers
{
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
        public ActionResult Create(VehicleTypeViewModel model)
        {
            VehicleType vehicleType = new VehicleType() { FareRate = model.FareRate, Name = model.Name };
            _vehicleTypeRepository.Add(vehicleType);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var vehicleType = _vehicleTypeRepository.Get(id);
            return View(new VehicleTypeViewModel(vehicleType));
        }
        [HttpPost]
        public ActionResult Edit(VehicleTypeViewModel model)
        {
            VehicleType vehicleType = new VehicleType() { Name = model.Name, FareRate = model.FareRate, Id = model.Id };
            _vehicleTypeRepository.Update(vehicleType);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            VehicleType vehicleType = _vehicleTypeRepository.Get(id);
            return View(new VehicleTypeViewModel(vehicleType));
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            VehicleType vehicleType = _vehicleTypeRepository.Get(id);
            return View(new VehicleTypeViewModel(vehicleType));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _vehicleTypeRepository.Remove(id);
            return RedirectToAction("Index");
        }
    }
}