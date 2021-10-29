using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Data
{
    class PrimaryTableSpirit
    {
        [Key]
        public int HowIViewMe { get; set; }
        [ForeignKey("Profile Number")]
        public Guid OwnerId { get; set; }
        [Required]
        public int HowIViewOthers { get; set; }
        [Required]
        public int HowOtherPerceiveMe { get; set; }
        [Required]
        public string MySocialCircle { get; set; }
        [Required]
        public int MyRestHours { get; set; }
        [Required]
        public string OutsideMotivation { get; set; }
        [Required]
        public string InternalMotivaiton { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}

