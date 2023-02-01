using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackEnd.DAL;
using BackEnd.Domain.Models;
using BackEnd.Domain.API.Models;


namespace BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoordinateController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public CoordinateController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpPost]
        public long Create(Coordinatedto coordinate)
        {
            Coordinate c = new Coordinate();
            c.X = coordinate.X;
            c.Y = coordinate.Y;

            _uow.CoordinateRepository.Add(c);
            _uow.SaveChangesAsync();

            return c.CoordinateID;
        }

        [HttpDelete("{id}")]
        public Coordinate Delete(long id)
        {
            Coordinate c = _uow.CoordinateRepository.Get(id);
            _uow.CoordinateRepository.Delete(c);
            _uow.SaveChangesAsync();

            return c;
        }
        [HttpGet]
        public async Task<IEnumerable<Coordinate>> Get()
        {
            return await _uow.CoordinateRepository.AllAsync();
        }
        [HttpGet("{id}")]
        public async Task<Coordinate> Get(long id)
        {
            return await _uow.CoordinateRepository.GetAsync(id);
        }


    }
}
