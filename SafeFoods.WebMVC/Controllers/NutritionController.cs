using SafeFoods.Models.NutritionModels;
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
            var model = new NutritionListItem[0];
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}