using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeFoods.Data
{
    public class Nutrition
    {
        [Key,ForeignKey(nameof(Recipe))]
        public int RecipeID { get; set; }
        public virtual Recipe Recipe { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        public int? Carbohydrates { get; set; }
        public int? Calories { get; set; }
        [Display(Name = "Grams of Fat")]
        public int? FatGram { get; set; }
        public int? Protein { get; set; }
        public int? Fiber { get; set; }
    }
}
