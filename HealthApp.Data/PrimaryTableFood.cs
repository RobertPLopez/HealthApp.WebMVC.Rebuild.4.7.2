using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Data
{
    public class PrimaryTableFood
    {
        [Key]
        public int FoodId { get; set; }
        public Guid OwnerId { get; set; }
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
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}