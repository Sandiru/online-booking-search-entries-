﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplication.Model
{
    public class HallCapacity
    {
        [Key] public string? HallName { get; set; }
        public int Capacity { get; set; }
    }
}
