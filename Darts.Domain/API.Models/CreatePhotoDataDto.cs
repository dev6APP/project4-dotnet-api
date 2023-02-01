using BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Domain.API.Models
{
    public class CreatePhotoDataDto
    {
        public long AmountFlowers { get; set; }
        public DateTime Date { get; set; }
        public long FieldID { get; set; }
        public long WorkerID { get; set; }
        public string X { get; set; }
        public string Y { get; set; }

        public long FieldOwnerID { get; set; }
    }
}
