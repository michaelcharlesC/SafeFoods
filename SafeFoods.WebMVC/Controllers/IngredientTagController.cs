﻿using SafeFoods.Models;
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
            var model = new IngredientTagListItem[0];
            return View();
        }
    }
}