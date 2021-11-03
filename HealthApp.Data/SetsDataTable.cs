﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Data
{
    public class SetsDataTable
    {
        [Key]
        public int SetId { get; set; }
        [Required]
        public int RepsPerSet { get; set; }
        //Need to figure out how to make nullable
        public int Weight { get; set; }
        //Need to figure out how to make nullable
        public int DistanceRan { get; set; }
        //Need to figure out how to make nullable
        public int TimeRan { get; set; }
    }
}
