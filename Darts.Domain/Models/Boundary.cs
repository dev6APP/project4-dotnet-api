using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Domain.Models
{
    public class Boundary
    {
        [Required]
        public long BoundaryID { get; set; }
        public long FieldID { get; set; }
        public int BoundaryOrder { get; set; }
        public string X { get; set; }
        public string Y { get; set; }


        public Field Field { get; set; }
    }
}
