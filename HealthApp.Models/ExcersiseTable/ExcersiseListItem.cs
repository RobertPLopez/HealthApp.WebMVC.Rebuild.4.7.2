using HealthApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Models.ExcersiseTable
{
    public class ExcersiseListItem
    {
        public int ExcersiseId { get; set; }
        public int WorkoutId { get; set; }
        public int ExcersiseTypeId { get; set; }

    }
}
