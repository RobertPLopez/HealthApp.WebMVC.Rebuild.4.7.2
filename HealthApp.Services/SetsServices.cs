using HealthApp.Data;
using HealthApp.Models.SetsDataTable;
using HealthApp.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HealthApp.WebMVC.Data.ApplicationUser;

namespace HealthApp.Services
{
    public class SetsServices
    {
        private readonly Guid _userId;
        public SetsServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSetsTable(SetsCreate model)
        {
            var entity =
                new SetsDataTable()
                {
                    SetId = model.SetId,
                    OwnerId = model.OwnerId,
                    RepsPerSet = model.RepsPerSet,
                    Weight = model.Weight,
                    DistanceRan = model.DistanceRan,
                    TimeRan = model.TimeRan,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.SetsDataTables.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SetsListItem> GetSetsTable()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .SetsDataTables
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new SetsListItem
                        {
                            SetId = e.SetId,
                            OwnerId = e.OwnerId,
                            RepsPerSet = e.RepsPerSet,
                            Weight = e.Weight,
                            DistanceRan = e.DistanceRan,
                            TimeRan = e.TimeRan,
                        }
                    );
                return query.ToArray();
            }
        }

        public SetsDetail GetSetTableById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .SetsDataTables
                    .Single(e => e.SetId == id && e.OwnerId == _userId);

                return
                    new SetsDetail
                    {
                        OwnerId = entity.OwnerId,
                        SetId = entity.SetId,
                        RepsPerSet = entity.RepsPerSet,
                        Weight = entity.Weight,
                        DistanceRan = entity.DistanceRan,
                        TimeRan = entity.TimeRan,
                    };
            }
        }

        public bool UpdateSetsTable(SetsEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .SetsDataTables
                        .Single(e => e.SetId == model.SetId && e.OwnerId == _userId);

                entity.SetId = model.SetId;
                entity.RepsPerSet = model.RepsPerSet;
                entity.Weight = model.Weight;
                entity.DistanceRan = model.DistanceRan;
                entity.TimeRan = model.TimeRan;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool SetsTableDelete(int MyFitnessPlan)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .SetsDataTables
                    .Single(e => e.SetId == MyFitnessPlan && e.OwnerId == _userId);
                ctx.SetsDataTables.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
