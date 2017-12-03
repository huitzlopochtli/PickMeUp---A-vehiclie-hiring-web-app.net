using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using PickMeUp.Models.Admin;
using System.Threading.Tasks;
using PickMeUp.Entity;

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
}