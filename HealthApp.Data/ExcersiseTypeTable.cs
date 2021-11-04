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
        public enum PreformedMovement { get; set; }

        [Required]
        public string ExcersiseName { get; set; }
        [Required]
        public ICollection<MuscleGroupTable> MuscleGroups { get; set; }

        public enum PreformedMovement
        { 
            Cardio, 
            Weights, 
            Acrobics
        }
    }
}

//Three basic questions 
//1) how are we suposed to represent enums in this template 
//2) do the icollection data set all require the full crud? 
//3) if not am I am on the right path for the I collection templates. 
