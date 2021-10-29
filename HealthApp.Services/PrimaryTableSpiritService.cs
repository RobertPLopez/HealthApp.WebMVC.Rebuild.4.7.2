using HealthApp.Models.PrimaryTableFitness;
using HealthApp.Models.PrimaryTableSpirit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HealthApp.WebMVC.Models.ApplicationUser;

namespace HealthApp.Services
{
    public class PrimaryTableSpiritService
    {
        private readonly Guid _userId;

        public PrimaryTableSpiritService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSpiritTable(SpiritCreate model)
        {
            var entity =
                new SpiritCreate()
                {
                    HowIViewMe = model.HowIViewMe,
                    HowIViewOthers = model.HowIViewOthers,
                    HowOtherPerceiveMe = model.HowOtherPerceiveMe,
                    MySocialCircle = model.MySocialCircle,
                    MyRestHours = model.MyRestHours,
                    OutsideMotivation = model.OutsideMotivation,
                    InternalMotivaiton = model.InternalMotivaiton,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.SpiritTables.Add(entity); //same reason as the primary fitness table;
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SpiritListItem> GetPrimarySpiritTable()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .SpiritTables
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new SpiritListItem
                        {
                            HowIViewMe = e.HowIViewMe,
                            HowIViewOthers = e.HowIViewOthers,
                            HowOtherPerceiveMe = e.HowOtherPerceiveMe,
                            MySocialCircle = e.MySocialCircle,
                            MyRestHours = e.MyRestHours,
                            OutsideMotivation = e.OutsideMotivation,
                            InternalMotivaiton = e.InternalMotivaiton,
                            CreatedUtc = e.CreatedUtc,
                            ModifiedUtc = e.ModifiedUtc
                        }
                  );
                return query.ToArray();
            }
        }

        public GetPrimarySpiritTableById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .SpiritTables
                    .Single(e => e.HowIViewMe == id && e.OwnerId == _userId);

                return
                    new PrimaryTableSpirit
                    {
                        HowIViewMe = entity.HowIViewMe,
                        HowIViewOthers = entity.HowIViewOthers,
                        HowOtherPerceiveMe = entity.HowOtherPerceiveMe,
                        MySocialCircle = entity.MySocialCircle,
                        MyRestHours = entity.MyRestHours,
                        OutsideMotivation = entity.OutsideMotivation,
                        InternalMotivaiton = entity.InternalMotivaiton,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc,
                    };
            }
        }

        public bool UpdateSpiritTable
            (SpiritEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .SpiritTables
                    .Single(e => e.HowIViewMe == model.HowIViewMe && e.OwnerId == _userId);

                entity.HowIViewMe = model.HowIViewMe;
                entity.HowIViewOthers = model.HowIViewOthers;
                entity.HowOtherPerceiveMe = model.HowOtherPerceiveMe;
                entity.MySocialCircle = model.MySocialCircle;
                entity.MyRestHours = model.MyRestHours;
                entity.OutsideMotivation = model.OutsideMotivation;
                entity.InternalMotivaiton = model.InternalMotivaiton;
                entity.CreatedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool PrimaryTableSpiritDelete(int MySpiritPlan)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .SpiritTables
                    .Single(e => e.HowIViewMe == MySpiritPlan && e.OwnerId == _userId);
                ctx.SpiritTables.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}