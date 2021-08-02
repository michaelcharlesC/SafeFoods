using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeFoods.Models.RecipeModels
{
    public class RecipeDetail
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }

        //public int? Rating { get; set; }
        public TimeSpan PrepTime { get; set; }
        public int CookTime { get; set; }
        public DateTimeOffset DateAdded { get; set; }
        public DateTimeOffset? DateModified { get; set; }
    }
}
