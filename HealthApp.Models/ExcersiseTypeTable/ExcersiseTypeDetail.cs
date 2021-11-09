using HealthApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Models.ExcersiseTypeTable
{
    class ExcersiseTypeDetail
    {
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
