using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Models.PrimaryTableFood
{
    public class FoodEdit
    {
        [Key]
        public int FoodId { get; set; }
        [Required]
        public string FoodName { get; set; }
        [Required]
        public decimal TotalCaloriesConsumed { get; set; }
        [Required]
        public string FoodContent { get; set; }
        [Required]
        public decimal DailyWeight { get; set; }
        [Required]
        public int CupsWaterDrank { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
