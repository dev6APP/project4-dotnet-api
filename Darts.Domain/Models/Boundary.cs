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
        public long FieldID { get; set; }
        [Required]
        public long CoordinateID { get; set; }

        public Coordinate Coordinate { get; set; }
        public Field Field { get; set; }
    }
}
