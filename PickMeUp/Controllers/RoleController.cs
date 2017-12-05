using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using PickMeUp.Models.Admin;
using System.Threading.Tasks;
using PickMeUp.Entity;
using PickMeUp.Repository.Interfaces;

namespace PickMeUp.Controllers
{
    public class RoleController : Controller
    {
        private ApplicationRoleManager  _roleManager;

        public RoleController()
        {
        }

        public RoleController(ApplicationRoleManager roleManager)
        {
            RoleManager = roleManager;
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }



        //Contoller Actions Starts from Here : ---------->
        // GET: Role
        public ActionResult Index()
        {
            List<RoleViewModel> roles = new List<RoleViewModel>();
            foreach (var role in RoleManager.Roles)
                roles.Add(new RoleViewModel(role));
            return View(roles);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Create(RoleViewModel model)
        {
            var role = new Role() { Name = model.Name};
            await RoleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            return View(new RoleViewModel(role));
        }
        [HttpPost]
        public async Task<ActionResult> Edit(RoleViewModel roleView)
        {
            var role = new Role() { Name = roleView.Name , Id = roleView.Id};
            await RoleManager.UpdateAsync(role);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<ActionResult> Details(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            return View(new RoleViewModel(role));
        }


        [HttpGet]
        public async Task<ActionResult> Delete(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            return View(new RoleViewModel(role));
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            await RoleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }
    }

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

            foreach(var vehicleType in vehicleTypes)
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
            VehicleType vehicleType = new VehicleType() { FareRate = model.FareRate , Name = model.Name};
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
            VehicleType vehicleType = new VehicleType() { Name = model.Name, FareRate = model.FareRate, Id = model.Id};
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