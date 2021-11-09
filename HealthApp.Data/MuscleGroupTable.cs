using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Data
{
    public class MuscleGroupTable
    {
        [Required]
        public string MuscleGroupWorkedName { get; set; }
        [Required]
        public int MuscleGroupWorkedNameId { get; set; }
        [ForeignKey("Profile Number")]
        public Guid OwnerId { get; set; }
    }
}
