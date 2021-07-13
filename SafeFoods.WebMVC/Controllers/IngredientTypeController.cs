using Microsoft.AspNet.Identity;
using SafeFoods.Models.IngredientTagModels;
using SafeFoods.Models.IngredientTypeModels;
using SafeFoods.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SafeFoods.WebMVC.Controllers
{
    public class IngredientTypeController : Controller
    {
        // GET: IngredientType
        public ActionResult Index()
        {
            IngredientTypeService service = CreateIngredientTypeService();
            var model = service.GetIngredientTypes();
            return View(model);
        }

        private IngredientTypeService CreateIngredientTypeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new IngredientTypeService(userId);
            return service;
        }
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create(IngredientTypeCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new IngredientTypeService(userId);

            service.CreateIngredientType(model);

            return RedirectToAction("Index");
        }
    }
}
}