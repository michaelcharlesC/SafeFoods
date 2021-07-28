using Microsoft.AspNet.Identity;
using SafeFoods.Data;
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

        public ActionResult IndexOwner()
        {
            RecipeService service = CreateRecipeService();
            var model = service.GetRecipesForOwner();
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
        
        public ActionResult FridgeSearch()
        {

            ViewBag.RecipeFridgeSearch = new IngredientTagService().GetIngredientTags();
            return View();
        }

        [HttpPost]
        //[ActionName("FridgeSearchFunctionality")]
        public ActionResult FridgeSearch(RecipeFridgeSearch model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateRecipeService();

            var result = service.FridgeSearch(model);

            if (result != null)
            {
                return View(result);
            }

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateRecipeService();

            var model = svc.GetRecipeById(id);

            return View(model);
        }

        public ActionResult GetAllByTag(int tagId)
        {
            var service = CreateRecipeService();
            var details = service.GetRecipesByIngredientId(tagId);

            return View(details);


        }

        public ActionResult Edit(int id)
        {
            var service = CreateRecipeService();

            var detail = service.GetRecipeById(id);
            var model = new RecipeEdit
            {
                RecipeId = detail.RecipeId,
                Name = detail.Name,
                Description = detail.Description,
                Instructions = detail.Instructions,
                PrepTime = detail.PrepTime,
                CookTime = detail.CookTime
            };
            return View(model);
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,RecipeEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.RecipeId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateRecipeService();

            if (service.UpdateRecipe(model))
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete (int id)
        {
            var svc = CreateRecipeService();

            var model = svc.GetRecipeById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateRecipeService();
            service.DeleteRecipe(id);
            return RedirectToAction("Index");
        }


    }
}