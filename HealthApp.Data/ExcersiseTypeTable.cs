using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Data
{
    public class ExcersiseTypeTable
    {
        public ExcersiseTypeTable()
        {
            MuscleGroups = new HashSet<MuscleGroupTable>();
        }

        [Key]
        public int ExcersiseTypeId { get; set; }
        [ForeignKey("Profile Number")]
        public Guid OwnerId { get; set; }

        [Required]
        public string PreformedMovement { get; set; }

        [Required]
        public string ExcersiseName { get; set; }
        [Required]
        public ICollection<MuscleGroupTable> MuscleGroups { get; set; }
    }
}

//Three basic questions 
//2) do the icollection data set all require the full crud? 
//3) if not am I am on the right path for the I collection templates. 
