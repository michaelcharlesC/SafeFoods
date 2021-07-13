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
    }

    }

