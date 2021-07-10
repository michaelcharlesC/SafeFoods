using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeFoods.Data
{
    public class IngredientType
    {
        [Key]
        public int IngredientTypeId { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<IngredientTag> IngredientTagList { get; set; }

        public IngredientType()
        {
            IngredientTagList = new HashSet<IngredientTag>();
        }
    }
}
