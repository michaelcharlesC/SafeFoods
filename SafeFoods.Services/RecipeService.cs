using SafeFoods.Data;
using SafeFoods.Models;
using SafeFoods.Models.RecipeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeFoods.Services
{
    public class RecipeService
    {
        private readonly Guid _userId;

        public RecipeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRecipe(RecipeCreate model)
        {
            var entity = new Recipe()
            {
                OwnerId = _userId,
                Name = model.Name,
                Description = model.Description,
                Instructions = model.Instructions,
                PrepTime = model.PrepTime,
                CookTime = model.CookTime,
                DateAdded = DateTimeOffset.Now

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Recipes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<RecipeListItem> GetIngredientTypes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Recipes
                    .Where(e => e.OwnerId == _userId)
                    .Select(e => new RecipeListItem
                    {
                        Name = e.Name,
                        Description =e.Description,
                        DateAdded = e.DateAdded
                    });
                return query.ToArray();
            }
        }
    }
}
