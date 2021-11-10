using HealthApp.Data;
using HealthApp.Models.ExcersiseTypeTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HealthApp.WebMVC.Data.ApplicationUser;

namespace HealthApp.Services
{
    public class ExcersiseTypeServices
    {
        private readonly Guid _userId;
        public ExcersiseTypeServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateExcersiseTypeTable(ExcersiseTypeCreate model)
        {
            var entity =
                new ExcersiseTypeTable()
                {
                    ExcersiseTypeId = model.ExcersiseTypeId,
                    OwnerId = model.OwnerId,
                    PreformedMovement = model.PreformedMovement,
                    ExcersiseName = model.ExcersiseName,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.ExcersiseTypes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ExcersiseTypeListItem> GetExcersiseTypeTable()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .ExcersiseTypes
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new ExcersiseTypeListItem
                        {
                            ExcersiseTypeId = e.ExcersiseTypeId,
                            PreformedMovement = e.PreformedMovement,
                            ExcersiseName = e.ExcersiseName
                        }
                    );
                return query.ToArray();
            }
        }

        public ExcersiseTypeDetail GetExcersiseTypeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .ExcersiseTypes
                    .Single(e => e.ExcersiseTypeId == id && e.OwnerId == _userId);

                return
                    new ExcersiseTypeDetail
                    {
                        ExcersiseTypeId = entity.ExcersiseTypeId,
                        OwnerId = entity.OwnerId,
                        PreformedMovement = entity.PreformedMovement,
                        ExcersiseName = entity.ExcersiseName,
                    };
            }
        }

        public bool UpdateExcersiseTypeTable(ExcersiseTypeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ExcersiseTypes
                        .Single(e => e.ExcersiseTypeId == model.ExcersiseTypeId && e.OwnerId == _userId);

                entity.ExcersiseTypeId = model.ExcersiseTypeId;
                entity.PreformedMovement = model.PreformedMovement;
                entity.ExcersiseName = model.ExcersiseName;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool ExcersiseTypeTableDelete(int MyFitnessPlan)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .ExcersiseTypes
                    .Single(e => e.ExcersiseTypeId == MyFitnessPlan && e.OwnerId == _userId);
                ctx.ExcersiseTypes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
