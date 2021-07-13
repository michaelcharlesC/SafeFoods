using SafeFoods.Models.IngredientTagModels;
using SafeFoods.Models.IngredientTypeModels;
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
            var model = new IngredientTypeListItem[0];
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create(IngredientTypeCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}
}