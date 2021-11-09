using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Services
{
    class ExcersiseTableService
    {
        private readonly Guid _userId;
        public ExcersiseTableService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePrimaryFitnessTable(ExcersiseCreate model)
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
    }
}
