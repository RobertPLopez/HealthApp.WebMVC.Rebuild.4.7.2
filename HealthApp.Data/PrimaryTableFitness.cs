using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Data
{
    public partial class PrimaryTableFitness
    {
        public PrimaryCollection()
        {
            Excersises = new HashSet<Excersise>();
        }

        [Key]
        public int WorkoutId { get; set; }
        [ForeignKey("Profile Number")]
        public Guid OwnerId { get; set; }
        //[Required]
        //public ICollection <Excersises> : ExcersiseTabele I need to be able to connect this to the sub fitness tables 
        [Required]
        public int TotalCaloriesBurned { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

        public virtual ICollection<Excersise> Excersises { get; set;} 
    }
}