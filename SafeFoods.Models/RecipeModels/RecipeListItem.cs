using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeFoods.Models
{
    public class RecipeListItem
    {
        [Display(Name = "Recipe ID")]
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public int? Rating { get; set; }
        [Display(Name = "Created On")]
        public DateTimeOffset DateAdded { get; set; }


    }
}
