﻿using Microsoft.AspNet.Identity;
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
        public ActionResult Create(int recipeId,NutritionCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateNutritionService();

            if (service.CreateNutrition(recipeId,model))
            {
                return RedirectToAction("Index");
            };

            return View(model);

        }
        [ActionName("Details")]
        public ActionResult Details(int recipeId)
        {
            var svc = CreateNutritionService();

            var model = svc.GetNutritionById(recipeId);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateNutritionService();

            var detail = service.GetNutritionById(id);
            var model = new NutritionEdit
            {
                RecipeID = detail.RecipeID,
                Carbohydrates = detail.Carbohydrates,
                Calories = detail.Calories,
                FatGram = detail.FatGram,
                Protein = detail.Protein,
                Fiber = detail.Fiber
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, NutritionEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.RecipeID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateNutritionService();

            if (service.UpdateNutrition(model))
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateNutritionService();

            var model = svc.GetNutritionById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateNutritionService();
            service.DeleteNutrition(id);
            return RedirectToAction("Index");
        }

        //public ActionResult GetNutritionById(int recipeId)
        //{
        //    var svc = CreateNutritionService();
        //    var model = svc.GetNutritionById(recipeId);
        //    return View(model);
        //}
    }
}
