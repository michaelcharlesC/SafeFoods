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

        public ActionResult Create(NutritionCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NutritionService(userId);

            service.CreateNutrition(model);

            return RedirectToAction("Index");
        }
    }
}
}