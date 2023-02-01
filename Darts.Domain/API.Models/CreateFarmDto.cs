using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Domain.API.Models
{
    public class CreateFarmDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public long FieldOwnerID { get; set; }
        public DateTime Started { get; set; }
    }
}
