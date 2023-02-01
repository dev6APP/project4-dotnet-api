using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Domain.Models
{
    public class FarmStaff
    {
        public long FarmID { get; set; }
        public long WorkerID { get; set; }

        public Farm Farm { get; set; }
        public Worker Worker { get; set; }
    }
}
