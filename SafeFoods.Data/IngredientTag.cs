using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeFoods.Data
{
 
    public class IngredientTag
    {
        [Key]
        public int IngredientTagId { get; set; }
        [Required]
        [MaxLength(15, ErrorMessage = " There are too many characters in this field.")]
        [MinLength(2, ErrorMessage = "Please add at least 2 characters")]
        public string Name { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        [Display(Name ="Created on")]
        public DateTimeOffset DateAdded { get; set; }
        [Display(Name = "Modified On")]
        public DateTimeOffset? DateModified { get; set; }
        [ForeignKey(nameof(IngredientType))]
        public int? IngredientTypeId { get; set; }
        public virtual IngredientType IngredientType { get; set; }
        public virtual ICollection<Recipe> RecipesList { get; set; }

        public IngredientTag()  
        {
            RecipesList = new HashSet<Recipe>();
        }


    }
}
