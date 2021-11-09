using HealthApp.Data;
using HealthApp.Models.ExcersiseTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HealthApp.WebMVC.Data.ApplicationUser;

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
    }
}
