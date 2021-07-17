using SafeFoods.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeFoods.Models.RecipeModels
{
    public class RecipeFridgeSearch
    {
        public IngredientTag tagOne { get; set; }
        public IngredientTag tagTwo { get; set; }
        public IngredientTag tagThree { get; set; }
        public IngredientTag tagFour { get; set; }
    }
}
