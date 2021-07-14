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
        public IEnumerable<RecipeListItem> GetRecipes()
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

        public RecipeDetail GetRecipeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Recipes.Single(e => e.RecipeId == id && e.OwnerId == _userId);
                return new RecipeDetail
                {
                    RecipeId = entity.RecipeId,
                    Name = entity.Name,
                    Description = entity.Description,
                    Instructions = entity.Instructions,
                    PrepTime = entity.PrepTime,
                    CookTime = entity.CookTime,
                    DateAdded = entity.DateAdded,
                    DateModified = entity.DateModified
                };
            }
        }

        public bool UpdateRecipe(RecipeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Recipes.Single(e => e.RecipeId == model.RecipeId && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.Instructions = model.Instructions;
                entity.PrepTime = model.PrepTime;
                entity.CookTime = model.CookTime;

                return ctx.SaveChanges() == 1;

            }


        }


    }
}
