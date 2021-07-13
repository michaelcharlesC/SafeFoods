using Microsoft.AspNet.Identity;
using SafeFoods.Models;
using SafeFoods.Models.RecipeModels;
using SafeFoods.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SafeFoods.WebMVC.Controllers
{
    [Authorize]
    public class RecipeController : Controller
    {
        // GET: Recipe
        public ActionResult Index()
        {
            RecipeService service = CreateRecipeService();
            var model = service.GetRecipes();
            return View(model);
        }

        private RecipeService CreateRecipeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RecipeService(userId);
            return service;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecipeCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateRecipeService();

            if (service.CreateRecipe(model))
            {
                return RedirectToAction("Index");
            };


            return View(model);

        }
        public ActionResult Details(int id)
        {
            var svc = CreateRecipeService();

            var model = svc.GetRecipeById(id);

            return View(model);
        }


    }
}