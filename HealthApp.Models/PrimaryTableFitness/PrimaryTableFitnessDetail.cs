using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Models.PrimaryTableFitness
{
    public class PrimaryTableFitnessDetail
    {
        [Key]
        [Display(Name = "Your Fitness Plan!")]
        public int WorkoutId { get; set; }
        public Guid OwnerId { get; set; }
        //[Required]
        //public ICollection <Excersises> : ExcersiseTabele I need to be able to connect this to the sub fitness tables 
        [Required]
        [Display(Name = "This is the total number of calories burned!")]
        public int TotalCaloriesBurned { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
