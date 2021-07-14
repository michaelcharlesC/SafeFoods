using SafeFoods.Data;
using SafeFoods.Models.NutritionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeFoods.Services
{
    public class NutritionService
    {
        private readonly Guid _userId;

        public NutritionService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateNutrition(NutritionCreate model)
        {
            var entity = new Nutrition()
            {
                OwnerId = _userId,
                RecipeID = model.RecipeID,
                Carbohydrates = model.Carbohydrates,
                Calories = model.Calories,
                FatGram = model.FatGram,
                Protein = model.Protein,
                Fiber = model.Fiber
            };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Nutritions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<NutritionListItem> GetNutritions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Nutritions
                    .Where(e => e.OwnerId == _userId)
                    .Select(e => new NutritionListItem
                    {
                        Carbohydrates =e.Carbohydrates,
                        Calories = e.Calories,
                        FatGram = e.FatGram,
                        Protein = e.Protein,
                        Fiber =e.Fiber

                    });
                return query.ToArray();
            }
        }

        public NutritionDetail GetNutritionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Nutritions.Single(e => e.RecipeID == id && e.OwnerId == _userId);
                return new NutritionDetail
                {
                    RecipeID = entity.RecipeID,
                    Carbohydrates = entity.Carbohydrates,
                    Calories = entity.Calories,
                    FatGram = entity.FatGram,
                    Protein = entity.Protein,
                };
            }
        }

        public bool UpdateNutrition(NutritionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Nutritions.Single(e => e.RecipeID == model.RecipeID && e.OwnerId == _userId);

                entity.Carbohydrates = model.Carbohydrates;
                entity.Calories = model.Calories;
                entity.FatGram = model.FatGram;
                entity.Protein = model.Protein;

                return ctx.SaveChanges() == 1;

            }


        }
    }
}
