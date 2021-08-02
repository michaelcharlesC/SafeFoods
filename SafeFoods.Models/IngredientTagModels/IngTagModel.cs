using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeFoods.Models.IngredientTagModels
{
    public class IngTagModel
    {
        
        [Display(Name = " Ingredient One")]
        public int ingredientTagOneId { get; set; }
        public string ingredientTagOneName { get; set; }
        [Display(Name = " Ingredient Two")]
        public int ingredientTagTwoId { get; set; }
        public string ingredientTagTwoName { get; set; }
        [Display(Name = " Ingredient Three")]
        public int ingredientTagThreeId { get; set; }
        public string ingredientTagThreeName { get; set; }
        [Display(Name = " Ingredient Four")]
        public int ingredientTagFourId { get; set; }
        public string ingredientTagFourName { get; set; }
    }
}

