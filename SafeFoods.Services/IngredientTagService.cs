using SafeFoods.Data;
using SafeFoods.Models;
using SafeFoods.Models.IngredientTagModels;
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

        public IEnumerable<IngredientTagListItem> GetIngredientTags()
        {
            using( var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .IngredientTags
                    .Where(e => e.OwnerId == _userId)
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
                var entity = ctx.IngredientTags.Single(e => e.IngredientTagId == id && e.OwnerId == _userId);
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
                var entity = ctx.IngredientTags.Single(e => e.IngredientTagId == model.IngredientTagId && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.DateModified = DateTimeOffset.Now;


                return ctx.SaveChanges() == 1;

            }


        }
    }
}
