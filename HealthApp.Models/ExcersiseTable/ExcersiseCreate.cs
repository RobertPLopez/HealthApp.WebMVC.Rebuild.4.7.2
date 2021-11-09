using HealthApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Models.ExcersiseTable
{
    class ExcersiseCreate
    {
        [Key]
        public int ExcersiseId { get; set; }
        [ForeignKey("Workout Number")]
        public int WorkoutId { get; set; }
        [ForeignKey("Workout Type Id")]
        public int ExcersiseTypeId { get; set; }
        [Required]
        public ICollection<SetsDataTable> Sets { get; set; }
    }
}
