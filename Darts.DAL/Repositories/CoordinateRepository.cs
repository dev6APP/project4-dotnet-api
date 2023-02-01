using BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL.Repositories
{
    public class CoordinateRepository : GenericRepository<Coordinate>
    {
        public CoordinateRepository(BackEndContext context) : base(context) { }   
    }
}
