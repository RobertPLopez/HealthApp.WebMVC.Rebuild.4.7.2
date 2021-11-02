using HealthApp.Data;
using HealthApp.Models.PrimaryTableFood;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HealthApp.WebMVC.Models.ApplicationUser;

namespace HealthApp.Services
{
    public class PrimaryTableFoodService
    {
        private readonly Guid _userId;
        public PrimaryTableFoodService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePrimaryFoodTable(FoodCreate model)
        {
            var entity =
                new PrimaryTableFood()
                {
                    FoodId = model.FoodId,
                    FoodName = model.FoodName,
                    TotalCaloriesConsumed = model.TotalCaloriesConsumed,
                    FoodContent = model.FoodContent,
                    DailyWeight = model.DailyWeight,
                    CupsWaterDrank = model.CupsWaterDrank,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.FoodTables.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FoodListItem> GetPrimaryTableFood()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .FoodTables
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new FoodListItem
                        {
                            FoodId = e.FoodId,
                            FoodName = e.FoodName,
                            TotalCaloriesConsumed = e.TotalCaloriesConsumed,
                            FoodContent = e.FoodContent,
                            DailyWeight = e.DailyWeight,
                            CupsWaterDrank = e.CupsWaterDrank,
                            CreatedUtc = e.CreatedUtc,
                            ModifiedUtc = e.ModifiedUtc
                        }
                    );
                return query.ToArray();
            }
        }

        //Not quite sure what the error here relates to 
        public FoodDetail GetPrimaryTableFoodById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .FoodTables
                    .Single(e => e.FoodId == id && e.OwnerId == _userId);

                return
                    new FoodDetail
                    {
                        OwnerId = entity.OwnerId,
                        FoodId = entity.FoodId,
                        FoodName = entity.FoodName,
                        TotalCaloriesConsumed = entity.TotalCaloriesConsumed,
                        FoodContent = entity.FoodContent,
                        DailyWeight = entity.DailyWeight,
                        CupsWaterDrank = entity.CupsWaterDrank,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc,
                    };
            }
        }

        public bool UpdatePrimaryTableFood(FoodEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .FoodTables
                        .Single(e => e.FoodId == model.FoodId && e.OwnerId == _userId);

                entity.FoodId = model.FoodId;
                entity.FoodName = model.FoodName;
                entity.TotalCaloriesConsumed = model.TotalCaloriesConsumed;
                entity.FoodContent = model.FoodContent;
                entity.DailyWeight = model.DailyWeight;
                entity.CupsWaterDrank = model.CupsWaterDrank;
                entity.CreatedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool PrimaryTableFoodDelete(int MyMealPlan)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .FoodTables
                    .Single(e => e.FoodId == MyMealPlan && e.OwnerId == _userId);
                ctx.FoodTables.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

//Need to add in the overload edit controller
