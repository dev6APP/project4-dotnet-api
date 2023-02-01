using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Domain.Models
{
    public class Worker
    {
        public long WorkerID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public long PermissionID { get; set; }
        public long LanguageID { get; set; }
        

        public Permission Permission { get; set; }
        public Language Language { get; set; }
        
        public ICollection<FarmStaff>? FarmStaffs { get; set; }
        public ICollection<PhotoData>? Photos { get; set; }
        
    }
}
