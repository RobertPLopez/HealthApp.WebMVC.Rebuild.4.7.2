using HealthApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public ICollection<Excersise> Excersises { get; set; }
        [Required]
        public int TotalCaloriesBurned { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}