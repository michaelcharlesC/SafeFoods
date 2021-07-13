﻿using SafeFoods.Models;
using SafeFoods.Models.RecipeModels;
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
            var model = new RecipeListItem[0];
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecipeCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}