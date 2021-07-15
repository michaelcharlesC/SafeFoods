using Microsoft.AspNet.Identity;
using SafeFoods.Models;
using SafeFoods.Models.IngredientTagModels;
using SafeFoods.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SafeFoods.WebMVC.Controllers
{
    public class IngredientTagController : Controller
    {
        // GET: IngredientTag
        public ActionResult Index()
        {
            IngredientTagService service = CreateIngredientTagService();
            var model = service.GetIngredientTags();
            return View(model);
        }

        private IngredientTagService CreateIngredientTagService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new IngredientTagService(userId);
            return service;
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IngredientTagCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateIngredientTagService();
            if (service.CreateIngredientTag(model))
            {
                return RedirectToAction("Index");
            };

            return View(model);
            
        }

        public ActionResult Details(int id)
        {
            var svc = CreateIngredientTagService();

            var model = svc.GetIngredientTagById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateIngredientTagService();

            var detail = service.GetIngredientTagById(id);
            var model = new IngredientTagEdit
            {
                IngredientTagId = detail.IngredientTagId,
                Name = detail.Name,
                DateModified = detail.DateModified

            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IngredientTagEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.IngredientTagId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateIngredientTagService();

            if (service.UpdateIngredientTag(model))
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateIngredientTagService();

            var model = svc.GetIngredientTagById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateIngredientTagService();
            service.DeleteIngredientTag(id);
            return RedirectToAction("Index");
        }
    }

    }

