using HealthApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Models.ExcersiseTable
{
    class ExcersiseEdit
    {
        public int ExcersiseId { get; set; }
        public int WorkoutId { get; set; }
        public int ExcersiseTypeId { get; set; }
        public ICollection<SetsDataTable> Sets { get; set; }
    }
}
