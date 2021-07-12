using SafeFoods.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeFoods.Models.IngredientTagModels
{
    public class IngredientTagDetail
    {
        [Display(Name = "Ingredient Tag ID")]
        public int IngredientTagId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Created on")]
        public DateTimeOffset DateAdded { get; set; }
        [Display(Name = "Modified On")]
        public DateTimeOffset? DateModified { get; set; }
        public List<Recipe> RecipeList { get; set; }


    }
}
