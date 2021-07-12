using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeFoods.Models.IngredientTagModels
{
    public class IngredientTypeListItem
    {
        public int IngredientTypeId { get; set; }
        public string Name { get; set; }
        public ICollection<IngredientTag> IngredientTagList { get; set; }
    }
}
