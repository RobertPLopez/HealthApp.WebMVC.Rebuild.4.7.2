using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Data
{
    public class ExcersiseTypeTable
    {
        public MuscleGroupCollection()
        {
            MuscleGroups = new HashSet<MuscleGroupTable>();
        }

        [Key]
        public int ExcersiseTypeId { get; set; }
        //Need to set up the Enum
        public enum PreformedMovements { get; set; }

        [Required]
        public string ExcersiseName { get; set; }
        [Required]
        public ICollection<MuscleGroupTable> MuscleGroups { get; set; }

        public enum PreformedMovements
        { 
            Cardio, 
            Weights, 
            Acrobics
        }
    }
}
