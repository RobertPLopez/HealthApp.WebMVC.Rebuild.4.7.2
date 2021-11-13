using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Data
{
    public class SetsDataTable
    {
        [Key]
        public int SetId { get; set; }
        public Guid OwnerId { get; set; }
        [Required]
        public int RepsPerSet { get; set; }
        [Required]
        //Need to figure out how to make nullable
        public int? Weight { get; set; }
        [Required]
        //Need to figure out how to make nullable
        public int? DistanceRan { get; set; }
        [Required]
        //Need to figure out how to make nullable
        public int? TimeRan { get; set; }
    }
}