using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Domain.Models
{
    public class Permission
    {
        public long PermissionID { get; set; }
        [Required]
        public string Name { get; set; }

        
        public ICollection<Worker>? Workers { get; set; }
    }
}
