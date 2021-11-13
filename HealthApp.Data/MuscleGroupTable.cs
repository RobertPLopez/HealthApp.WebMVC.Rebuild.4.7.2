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
        [Key]
        public int MuscleGroupTableId { get; set; }
        [Required]
        public string MuscleGroupWorkedName { get; set; }
        [Required]
        public int MuscleGroupWorkedNameId { get; set; }
        public Guid OwnerId { get; set; }
    }
}
