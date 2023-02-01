using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Domain.Models
{
    public class Language
    {
        public long LanguageID { get; set; }
        [Required]
        public string Name { get; set; }
        
        public ICollection<Worker> Workers { get; set; }
        public ICollection<FieldOwner> FieldOwners { get; set; }
    }
}
