using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Domain.Models
{
    public class PhotoData
    {
        public long PhotoDataID { get; set; }
        [Required]
        public long AmountFlowers { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public long CoordinateID { get; set; }
        public long FieldID { get; set; }
        public long WorkerID { get; set; }

        public long FieldOwnerID { get; set; }

        public Coordinate Coordinate { get; set; }
        public Field Field { get; set; }
        public Worker Worker { get; set; }
        public FieldOwner FieldOwner { get; set; }


    }
}
