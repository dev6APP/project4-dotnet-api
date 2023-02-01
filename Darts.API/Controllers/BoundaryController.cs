//using BackEnd.API.Services;
//using BackEnd.Domain.API.Mappers;
using BackEnd.Domain.API.Models;
using BackEnd.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using BackEnd.DAL;
using BackEnd.Domain.Security;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoundaryController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public BoundaryController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // POST api/<UsersController>
        [HttpPost]
        public Boundary SetBoundary([FromBody] SetBoundaryDto boundary)
        {
            Boundary b = new()
            {
                FieldID = boundary.FieldID,
                BoundaryOrder= boundary.BoundaryOrder,
                X = boundary.X,
                Y = boundary.Y
            };

            _uow.BoundaryRepository.Add(b);
            _uow.SaveChangesAsync();

            return b;
        }
        [HttpGet]
        public IEnumerable<Boundary> Get()
        {
            return _uow.BoundaryRepository.AllQuery().Include(b => b.Field);
        }

        [HttpGet("field/{id}")]
        public IEnumerable<Boundary> GetFieldBoundaries(long id)
        {
            return _uow.BoundaryRepository.AllQuery().Where(f => f.FieldID == id);
        }
        
    }
}
