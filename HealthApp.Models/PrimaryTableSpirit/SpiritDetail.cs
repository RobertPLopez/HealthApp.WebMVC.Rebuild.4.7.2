using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Models.PrimaryTableSpirit
{
    public class SpiritDetail
    {
        [Key]
        [Display(Name = "This is how you view yourself.")]
        public int HowIViewMe { get; set; }
        [Required]
        [Display(Name = "This is how you view others.")]
        public int HowIViewOthers { get; set; }
        [Required]
        [Display(Name = "This is how you think others view you.")]
        public int HowOtherPerceiveMe { get; set; }
        [Required]
        [Display(Name = "This is your social circle")]
        public string MySocialCircle { get; set; }
        [Required]
        [Display(Name = "This is how much rest you got last night")]
        public int MyRestHours { get; set; }
        [Required]
        [Display(Name = "This is how your external motivation.")]
        public string OutsideMotivation { get; set; }
        [Required]
        [Display(Name = "This is how your internal motivation.")]
        public string InternalMotivaiton { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
