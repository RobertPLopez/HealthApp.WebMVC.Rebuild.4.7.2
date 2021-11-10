using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Models.PrimaryTableSpirit
{
    public class SpiritEdit
    {
        public int HowIViewMe { get; set; }

        public int HowIViewOthers { get; set; }

        public int HowOtherPerceiveMe { get; set; }

        public string MySocialCircle { get; set; }

        public int MyRestHours { get; set; }

        public string OutsideMotivation { get; set; }

        public string InternalMotivaiton { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
