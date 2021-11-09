using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Data
{
    public class MuscleGroupTable
    {
        public string MuscleGroupWorkedName { get; set; }
        [ForeignKey("Profile Number")]
        public Guid OwnerId { get; set; }
    }
}
