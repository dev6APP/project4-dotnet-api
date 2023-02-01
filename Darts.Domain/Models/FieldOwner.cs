using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Domain.Models
{
    public class FieldOwner
    {
        public long FieldOwnerID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime Started { get; set; }
        public long LanguageID { get; set; }

        public Language Language { get; set; }
        public ICollection<Farm>? Farms { get; set; }
        public ICollection<PhotoData>? Photos { get; set; }

    }
}
