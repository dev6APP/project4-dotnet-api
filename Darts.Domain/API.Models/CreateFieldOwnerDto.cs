using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Domain.API.Models
{
    public class CreateFieldOwnerDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime Started { get; set; }
        public long LanguageID { get; set; }
    }
}
