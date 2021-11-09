using HealthApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Models.ExcersiseTypeTable
{
    class ExcersiseTypeEdit
    {
        public string PreformedMovement { get; set; }

        public string ExcersiseName { get; set; }

        public ICollection<MuscleGroupTable> MuscleGroups { get; set; }
    }
}
