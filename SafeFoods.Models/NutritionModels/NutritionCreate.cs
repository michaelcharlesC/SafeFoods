﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeFoods.Models.NutritionModels
{
    public class NutritionCreate
    {
        //[Required]
        //[Display(Name = "Recipe ID")]
        //public int RecipeID { get; set; }
        [Required]
        [Display(Name = "Grams of Carbohydrates")]
        public int? Carbohydrates { get; set; }
        [Required]
        [Display(Name = "Grams of Calories")]
        public int? Calories { get; set; }
        [Required]
        [Display(Name = "Grams of Fat")]
        public int? FatGram { get; set; }
        [Required]
        [Display(Name = "Grams of Protein")]
        public int? Protein { get; set; }
        [Required]
        [Display(Name = "Grams of Fiber")]
        public int? Fiber { get; set; }
    }
}
