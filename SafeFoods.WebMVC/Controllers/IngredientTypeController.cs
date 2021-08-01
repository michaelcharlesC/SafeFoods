using Microsoft.AspNet.Identity;
using SafeFoods.Data;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IngredientTypeCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateIngredientTypeService();

            if (service.CreateIngredientType(model))
            {
                return RedirectToAction("Index");
            };

            return View(model);

        }

        public ActionResult Details(int id)
        {
            var svc = CreateIngredientTypeService();

            var model = svc.GetIngredientTypeById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateIngredientTypeService();

            var detail = service.GetIngredientTypeById(id);
            var model = new IngredientTypeEdit
            {
                IngredientTypeId = detail.IngredientTypeId,
                Name = detail.Name
                
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IngredientTypeEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.IngredientTypeId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateIngredientTypeService();

            if (service.UpdateIngredientType(model))
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateIngredientTypeService();

            var model = svc.GetIngredientTypeById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateIngredientTypeService();
            service.DeleteIngredientType(id);
            return RedirectToAction("Index");
        }




    }
}
