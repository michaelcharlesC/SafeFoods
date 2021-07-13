using Microsoft.AspNet.Identity;
using SafeFoods.Models.NutritionModels;
using SafeFoods.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SafeFoods.WebMVC.Controllers
{
    public class NutritionController : Controller
    {
        // GET: Nutrition
        public ActionResult Index()
        {
            NutritionService service = CreateNutritionService();
            var model = service.GetNutritions();
            return View(model);
        }

        private NutritionService CreateNutritionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NutritionService(userId);
            return service;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NutritionCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateNutritionService();

            if (service.CreateNutrition(model))
            {
                return RedirectToAction("Index");
            };

            return View(model);

        }

        public ActionResult Details(int id)
        {
            var svc = CreateNutritionService();

            var model = svc.GetNutritionById(id);

            return View(model);
        }
    }
}
