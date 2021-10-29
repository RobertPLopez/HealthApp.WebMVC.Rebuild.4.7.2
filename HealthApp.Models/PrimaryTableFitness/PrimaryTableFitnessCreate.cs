using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Models.PrimaryTableFitness
{
    public class PrimaryTableFitnessCreate
    {
        [Required]
        [Display(Name = "Your Workout! Own it!")]
        [MaxLength(150, ErrorMessage = "There are to many characters in this field.")]
        public int WorkoutId { get; set; }
        //[Required]
        //ICollection object in the data layer
        [Required]
        public string TotalCaloriesBurned { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}