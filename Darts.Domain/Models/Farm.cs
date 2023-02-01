using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Domain.Models
{
    public class Farm
    {
        public long FarmID { get; set; }
        [Required]  
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [DataType(DataType.Date)]
        public DateTime Started { get; set; }
       
        public long FieldOwnerID { get; set; }

        public FieldOwner FieldOwner { get; set; }
        public ICollection<FarmStaff>? FarmStaffs { get; set; }
        public ICollection<Field>? Fields { get; set; }

    }
}
