using SafeFoods.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeFoods.Models.RecipeModels
{
    public class RecipeFridgeSearch
    {
        public int ingredientTagOneId { get; set; }
        public string ingredientTagOneName { get; set; }
        public int ingredientTagTwoId { get; set; }
        public string ingredientTagTwoName { get; set; }
        public int ingredientTagThreeId { get; set; }
        public string ingredientTagThreeName { get; set; }
        public int ingredientTagFourId { get; set; }
        public string ingredientTagFourName { get; set; }
    }
}
