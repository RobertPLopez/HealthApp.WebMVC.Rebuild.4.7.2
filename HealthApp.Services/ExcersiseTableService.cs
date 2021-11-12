using HealthApp.Data;
using HealthApp.Models.ExcersiseTable;
using HealthApp.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HealthApp.WebMVC.Data.ApplicationUser;

namespace HealthApp.Services
{
    public class ExcersiseTableService
    {
        private readonly Guid _userId;
        public ExcersiseTableService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateExcersiseTable(ExcersiseCreate model)
        {
            var entity =
                new Excersise()
                {
                    ExcersiseId = model.ExcersiseId,
                    WorkoutId = model.WorkoutId,
                    ExcersiseTypeId = model.ExcersiseTypeId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Excersises.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ExcersiseListItem> GetExcersiseTable()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Excersises
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new ExcersiseListItem
                        {
                            ExcersiseId = e.ExcersiseId,
                            WorkoutId = e.WorkoutId,
                            ExcersiseTypeId = e.ExcersiseTypeId,
                        }
                    );
                return query.ToArray();
            }
        }

        public ExcersiseDetail GetExcersiseTableById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Excersises
                    .Single(e => e.ExcersiseId == id && e.OwnerId == _userId);

                return
                    new ExcersiseDetail
                    {
                        OwnerId = entity.OwnerId,
                        ExcersiseId = entity.ExcersiseId,
                        WorkoutId = entity.WorkoutId,
                        ExcersiseTypeId = entity.ExcersiseTypeId,
                    };
            }
        }

        public bool UpdateExcersiseTable(ExcersiseEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Excersises
                        .Single(e => e.ExcersiseId == model.ExcersiseId && e.OwnerId == _userId);

                entity.ExcersiseId = model.ExcersiseId;
                entity.WorkoutId = model.WorkoutId;
                entity.ExcersiseTypeId = model.ExcersiseTypeId;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool ExcersiseTableDelete(int MyFitnessPlan)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Excersises
                    .Single(e => e.ExcersiseId == MyFitnessPlan && e.OwnerId == _userId);
                ctx.Excersises.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
