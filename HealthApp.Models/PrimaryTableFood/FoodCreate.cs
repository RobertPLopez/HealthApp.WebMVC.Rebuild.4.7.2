using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Models.PrimaryTableFood
{
    public class FoodCreate
    {
        [Key]
        [Display(Name = "This is your food meal id.")]
        public int FoodId { get; set; }
        [Required]
        [Display(Name = "Write the name of the food you ate.")]
        public string FoodName { get; set; }
        [Required]
        [Display(Name = "Write down the total number of calories consumed.")]
        public decimal TotalCaloriesConsumed { get; set; }
        [Display(Name = "If you want list out what the food was made of.")]
        public string FoodContent { get; set; }
        [Required]
        [Display(Name = "Record your daily weight.")]
        public decimal DailyWeight { get; set; }
        [Required]
        [Display(Name = "Record how much water you have drank today.")]
        public int CupsWaterDrank { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
