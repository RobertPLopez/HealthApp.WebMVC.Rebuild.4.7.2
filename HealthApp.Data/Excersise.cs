using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Data
{
    public class Excersise
    {
        public Excersise()
        {
            Sets = new HashSet<SetsDataTable>();
        }

        [Key]
        public int ExcersiseId {get; set;}
        [ForeignKey("Profile Number")]
        public Guid OwnerId { get; set; }
        [ForeignKey("Workout Number")]
        public int WorkoutId { get; set; }
        [ForeignKey("Workout Type Id")]
        public int ExcersiseTypeId { get; set; }
        [Required]
        public ICollection<SetsDataTable> Sets { get; set; }

    }
}
