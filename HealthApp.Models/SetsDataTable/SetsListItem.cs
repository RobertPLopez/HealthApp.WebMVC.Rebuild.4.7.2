using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Models.SetsDataTable
{
    public class SetsListItem
    {
        public int SetId { get; set; }
        public Guid OwnerId { get; set; }
        public int RepsPerSet { get; set; }
        public int? Weight { get; set; }
        public int? DistanceRan { get; set; }
        public int? TimeRan { get; set; }
    }
}
