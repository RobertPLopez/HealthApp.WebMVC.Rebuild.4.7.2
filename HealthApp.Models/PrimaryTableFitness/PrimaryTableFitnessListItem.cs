using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Models.PrimaryTableFitness
{
    public class PrimaryTableFitnessListItem
    {
        public int WorkoutId { get; set; }

        //public ICollection <Excersises> : ExcersiseTabele I need to be able to connect this to the sub fitness tables 

        public int TotalCaloriesBurned { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
