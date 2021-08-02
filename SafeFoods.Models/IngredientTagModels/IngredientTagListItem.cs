using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeFoods.Models
{
    public class IngredientTagListItem
    {
        [Display(Name = "Ingredient Tag ID")]
        public int IngredientTagId { get; set; }
        public string Name { get; set; }
        
    }
}
