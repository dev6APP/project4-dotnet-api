using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Domain.Models
{
    public class Coordinate
    {
        public long CoordinateID { get; set; }
        [Required]
        public string X { get; set; }
        [Required]
        public string Y { get; set; }

        public ICollection<Boundary>? Boundaries { get; set; }
        public ICollection<PhotoData>? Photos { get; set; }

    }
}
