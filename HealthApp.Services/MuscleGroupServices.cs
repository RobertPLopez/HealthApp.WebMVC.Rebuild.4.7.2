using HealthApp.Data;
using HealthApp.Models.MuscleGroupTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HealthApp.WebMVC.Data.ApplicationUser;

namespace HealthApp.Services
{
    public class MuscleGroupServices
    {
        private readonly Guid _userId;
        public MuscleGroupServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMuscleGroupTable
            (MuscleGroupCreate model)
        {
            var entity =
                new MuscleGroupTable()
                {
                    MuscleGroupWorkedName = model.MuscleGroupWorkedName,
                    OwnerId = model.OwnerId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.MuscleGroups.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MuscleGroupListItem> GetMuscleGroupTable()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .MuscleGroups
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new MuscleGroupListItem
                        {
                            MuscleGroupWorkedName = e.MuscleGroupWorkedName,
                        }
                    );
                return query.ToArray();
            }
        }

        public MuscleGroupDetail GetMuscleGroupTableyId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .MuscleGroups
                    .Single(e => e.OwnerId == _userId);

                return
                    new MuscleGroupDetail
                    {
                        OwnerId = entity.OwnerId,
                        MuscleGroupWorkedName = entity.MuscleGroupWorkedName,
                    };
            }
        }

        public bool UpdateMucsleGroupTable
            (MuscleGroupEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MuscleGroups
                        .Single(e => e.OwnerId == _userId);

                entity.MuscleGroupWorkedName = model.MuscleGroupWorkedName;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool MuscleGroupTableDelete(int MyFitnessPlan)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .MuscleGroups
                    .Single(e => e.OwnerId == _userId);
                ctx.MuscleGroups.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
