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
            Boundary b = new();
            b.FieldID = boundary.FieldID;
            var max_id = _uow.CoordinateRepository.AllQuery().Select(c => c.CoordinateID).Max();
            b.CoordinateID = max_id;

            _uow.BoundaryRepository.Add(b);
            _uow.SaveChangesAsync();

            return b;
        }
        [HttpGet]
        public IEnumerable<Boundary> Get()
        {
            return _uow.BoundaryRepository.AllQuery().Include(b => b.Coordinate).Include(b => b.Field);
        }

        [HttpGet("field/{id}")]
        public IEnumerable<Boundary> GetFieldBoundaries(long id)
        {
            return _uow.BoundaryRepository.AllQuery().Where(f => f.FieldID == id).Include(b => b.Coordinate);
        }
        /*[HttpGet("{id}")]
        public async Task<Boundary> Get(long id)
        {
            return await _uow.BoundaryRepository.GetAsync(id);
        }*/

        /*[HttpPut]
        public User Put(editUserDto user, long id)
        {
            User e = _uow.UserRepository.Get(id);
            e.Name = user.Name;
            e.Email = user.Email;
            e.Address = user.Address;
            e.City = user.City;
            e.ZipCode = user.ZipCode;



            _uow.UserRepository.Update(e);
            _uow.SaveChangesAsync();

            return e;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> PostLogin([FromBody] LoginUser model)
        {
            var result = await _userService.Login(model);

            if (result == null)
                return BadRequest("Username or password is incorrect");
            return Ok(result);
        }*/
    }
}
