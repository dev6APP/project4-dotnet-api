﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Domain.API.Models
{
    public class CreateFieldDto
    {
        public string Name { get; set; }
        public long FarmID { get; set; }
    }
}
