using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Domain.API.Models
{
    public class UpdateFarmDto
    {
        public string Name { get; set; }
        public DateTime Started { get; set; }
        public string Address {get; set; }

    }
}
