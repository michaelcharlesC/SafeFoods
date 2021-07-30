﻿using SafeFoods.Data;
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

        public bool CreateNutrition(int recipeId, NutritionCreate model)
        {
            var entity = new Nutrition()
            {
                OwnerId = _userId,
                RecipeID = recipeId,
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
                        RecipeID = e.RecipeID,
                        Carbohydrates =e.Carbohydrates,
                        Calories = e.Calories,
                        FatGram = e.FatGram,
                        Protein = e.Protein,
                        Fiber =e.Fiber

                    });
                return query.ToArray();
            }
        }

        public NutritionDetail GetNutritionById(int recipeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Nutritions.Single(e => e.RecipeID == recipeId /*&& e.OwnerId == _userId*/);
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
                entity.Fiber = model.Fiber;

                return ctx.SaveChanges() == 1;

            }


        }

        public bool DeleteNutrition(int NutritionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Nutritions.Single(e => e.RecipeID == NutritionId && e.OwnerId == _userId);

                ctx.Nutritions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        

        
    }
}
