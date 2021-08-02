﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeFoods.Models.IngredientTypeModels
{
    public class IngredientTypeEdit
    {
        [Required]
        [Display(Name = "Ingredient Type ID")]
        public int IngredientTypeId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
