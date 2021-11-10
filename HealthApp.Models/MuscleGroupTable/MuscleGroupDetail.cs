using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Models.MuscleGroupTable
{
    public class MuscleGroupDetail
    {
        [Required]
        public string MuscleGroupWorkedName { get; set; }
        [ForeignKey("Profile Number")]
        public Guid OwnerId { get; set; }
    }
}
