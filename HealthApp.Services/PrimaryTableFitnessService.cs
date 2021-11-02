using HealthApp.Data;
using HealthApp.Models.PrimaryTableFitness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HealthApp.WebMVC.Models.ApplicationUser;

namespace HealthApp.Services
{
    public class PrimaryTableFitnessService
    {
        private readonly Guid _userId;
        public PrimaryTableFitnessService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePrimaryFitnessTable(PrimaryTableFitnessCreate model)
        {
            var entity =
                new PrimaryTableFitness()
                {
                    WorkoutId = model.WorkoutId,
                    OwnerId = model.OwnerId,
                    TotalCaloriesBurned = model.TotalCaloriesBurned,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.FitnessTables.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PrimaryTableFitnessListItem> GetPrimaryTableFitness()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .FitnessTables
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new PrimaryTableFitnessListItem
                        {
                            WorkoutId = e.WorkoutId,
                            TotalCaloriesBurned = e.TotalCaloriesBurned,
                            CreatedUtc = e.CreatedUtc
                        }
                    );
                return query.ToArray();
            }
        }

        //Not quite sure what the error here relates to 
        public PrimaryTableFitnessDetail GetPrimaryTableFitnessById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .FitnessTables
                    .Single(e => e.WorkoutId == id && e.OwnerId == _userId);

                return
                    new PrimaryTableFitnessDetail
                    {
                        OwnerId = entity.OwnerId,
                        WorkoutId = entity.WorkoutId,
                        TotalCaloriesBurned = entity.TotalCaloriesBurned,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc,
                    };
            }
        }

        public bool UpdatePrimaryTableFitness(PrimaryTableFitnessEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .FitnessTables
                        .Single(e => e.WorkoutId == model.WorkoutId && e.OwnerId == _userId);

                entity.WorkoutId = model.WorkoutId;
                entity.TotalCaloriesBurned = model.TotalCaloriesBurned;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool PrimaryTableFitnessDelete(int MyFitnessPlan)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .FitnessTables
                    .Single(e => e.WorkoutId == MyFitnessPlan && e.OwnerId == _userId);
                ctx.FitnessTables.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}