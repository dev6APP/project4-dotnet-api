using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Domain.API.Models.Auth
{
    public class RegisterFieldOwnerModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public DateTime Started { get; set; }
        [Required(ErrorMessage = "Language is required")]
        public long LanguageID { get; set; }


    }
}
