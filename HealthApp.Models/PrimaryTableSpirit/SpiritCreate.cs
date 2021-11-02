using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Models.PrimaryTableSpirit
{
    public class SpiritCreate
    {
        [Required]
        [Display(Name = "On a scale of 1-10 please rate how you view yourself.")]
        public int HowIViewMe { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        [Display(Name = "On a scale of 1-10 please rate how you view others.")]
        public int HowIViewOthers { get; set; }
        [Required]
        [Display(Name = "On a scale of 1-10 please rate how you view you think other perceive you.")]
        public int HowOtherPerceiveMe { get; set; }
        [Required]
        [Display(Name = "Please the members of your social circle.")]
        public string MySocialCircle { get; set; }
        [Required]
        [Display(Name = "Please list the amout of rest you got last night.")]
        public int MyRestHours { get; set; }
        [Required]
        [Display(Name = "If you have any outside motivation make sure to mark it!")]
        public string OutsideMotivation { get; set; }
        [Required]
        [Display(Name = "If you have any internal motivation make sure to mark it!")]
        public string InternalMotivaiton { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
