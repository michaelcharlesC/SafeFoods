using SafeFoods.Data;
using SafeFoods.Models;
using SafeFoods.Models.IngredientTagModels;
using SafeFoods.Models.RecipeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeFoods.Services
{
    public class IngredientTagService
    {
        private readonly Guid _userId;

        public IngredientTagService(Guid userId)
        {
            _userId = userId;
        }

        public IngredientTagService() { }


        public bool CreateIngredientTag(IngredientTagCreate model)
        {
            var entity = new IngredientTag()
            {
                OwnerId = _userId,
                Name = model.Name,
                DateAdded = DateTimeOffset.Now

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.IngredientTags.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool AddIngredientTagToRecipe(int recipeId, IngTagModel model)
        {

            var tagOne = new IngredientTag();
            var tagTwo = new IngredientTag();
            var tagThree = new IngredientTag();
            var tagFour = new IngredientTag();


            tagOne.DateAdded = DateTime.Now;
            tagOne.OwnerId = _userId;
            tagOne.Name = GetIngredientTagById(model.ingredientTagOneId).Name;
            tagOne.IngredientTagId = model.ingredientTagOneId;

            tagTwo.DateAdded = DateTime.Now;
            tagTwo.OwnerId = _userId;
            tagTwo.Name = GetIngredientTagById(model.ingredientTagTwoId).Name;
            tagTwo.IngredientTagId = model.ingredientTagTwoId;

            tagThree.DateAdded = DateTime.Now;
            tagThree.OwnerId = _userId;
            tagThree.Name = GetIngredientTagById(model.ingredientTagThreeId).Name;
            tagThree.IngredientTagId = model.ingredientTagThreeId;


            tagFour.DateAdded = DateTime.Now;
            tagFour.OwnerId = _userId;
            tagFour.Name = GetIngredientTagById(model.ingredientTagFourId).Name;
            tagFour.IngredientTagId = model.ingredientTagFourId;

            using (var ctx = new ApplicationDbContext())
            {
               
                var entity = ctx.Recipes.Find(recipeId);
                entity.ListOfIngredients.Add(tagOne);
                entity.ListOfIngredients.Add(tagTwo);
                entity.ListOfIngredients.Add(tagThree);
                entity.ListOfIngredients.Add(tagFour);

                return ctx.SaveChanges() >= 1;

            }
        }

        //public IEnumerable<RecipeFridgeSearch> FridgeSearchTags()
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query =
        //            ctx
        //            .IngredientTags
        //            //.Where(e => e.OwnerId == _userId)
        //            .Select(e => new RecipeFridgeSearch
        //            {
        //                ingredientTagOneId = e.ingredientTagOneId,
        //                Name = e.Name
        //            });

        //        return query.ToArray();
        //    }
        //}

        public IEnumerable<IngredientTagListItem> GetIngredientTags()
        {
            using( var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .IngredientTags
                    //.Where(e => e.OwnerId == _userId)
                    .Select(e => new IngredientTagListItem
                    {
                        IngredientTagId = e.IngredientTagId,
                        Name = e.Name
                    });

                return query.ToArray();
            }
        }

        public IngredientTagDetail GetIngredientTagById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.IngredientTags.Single(e => e.IngredientTagId == id);
                return new IngredientTagDetail
                {
                    IngredientTagId = entity.IngredientTagId,
                    Name = entity.Name,
                    DateAdded = entity.DateAdded,
                    DateModified = entity.DateModified,
                    RecipeList = entity.RecipesList.ToList()
                    
                };
            }
        }

        public bool UpdateIngredientTag(IngredientTagEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.IngredientTags.Single(e => e.IngredientTagId == model.IngredientTagId);

                entity.Name = model.Name;
                entity.DateModified = DateTimeOffset.Now;


                return ctx.SaveChanges() == 1;

            }


        }

        public bool DeleteIngredientTag(int IngredientTagId)
        {
            using(var ctx =new ApplicationDbContext())
            {
                var entity = ctx.IngredientTags.Single(e => e.IngredientTagId == IngredientTagId);

                ctx.IngredientTags.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        
    }
}
