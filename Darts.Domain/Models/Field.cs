using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Domain.Models
{
    public class Field
    {
        public long FieldID { get; set; }
        [Required]
        public string Name { get; set; }
        
        public long FarmID { get; set; }

        public Farm Farm { get; set; }
        public ICollection<Boundary>? Boundaries { get; set; }
        public ICollection<PhotoData>? Photos { get; set; }

    }
}
