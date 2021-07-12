using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeFoods.Models.IngredientTagModels
{
    public class IngredientTagCreate
    {
        [Required]
        [MaxLength(15, ErrorMessage = " There are too many characters in this field.")]
        [MinLength(2, ErrorMessage = "Please add at least 2 characters")]
        public string Name { get; set; }
        public DateTimeOffset DateAdded { get; set; }
    }
}
