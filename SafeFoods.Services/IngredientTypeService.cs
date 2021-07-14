using SafeFoods.Data;
using SafeFoods.Models.IngredientTagModels;
using SafeFoods.Models.IngredientTypeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeFoods.Services
{
    public class IngredientTypeService
    {
        private readonly Guid _userId;

        public IngredientTypeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateIngredientType(IngredientTypeCreate model)
        {
            var entity = new IngredientType()
            {
                OwnerId = _userId,
                Name = model.Name,

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.IngredientTypes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<IngredientTypeListItem> GetIngredientTypes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .IngredientTypes
                    .Where(e => e.OwnerId == _userId)
                    .Select(e => new IngredientTypeListItem
                    {
                        IngredientTypeId = e.IngredientTypeId,
                        Name = e.Name
                    });
                return query.ToArray();
            }
        }

        public IngredientTypeDetail GetIngredientTypeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.IngredientTypes.Single(e => e.IngredientTypeId == id && e.OwnerId == _userId);
                return new IngredientTypeDetail
                {
                    IngredientTypeId = entity.IngredientTypeId,
                    Name = entity.Name,
                    IngredientTagList = entity.IngredientTagList.ToList()
                };
            }
        }

        public bool UpdateIngredientType(IngredientTypeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.IngredientTypes.Single(e => e.IngredientTypeId == model.IngredientTypeId && e.OwnerId == _userId);

                entity.Name = model.Name;


                return ctx.SaveChanges() == 1;

            }


        }
    }
}
