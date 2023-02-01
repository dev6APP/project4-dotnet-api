using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Domain.API.Models
{
    public class SetBoundaryDto
    {
        public long FieldID { get; set; }
        public int BoundaryOrder { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
    }
}
