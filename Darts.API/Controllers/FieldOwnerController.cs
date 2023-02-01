using BackEnd.Domain.API.Models;
using BackEnd.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldOwnerController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public FieldOwnerController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpPost]
        public FieldOwner Create(CreateFieldOwnerDto dto)
        {
            FieldOwner f = new()
            {
                Name= dto.Name,
                Started= dto.Started,
                Country= dto.Country,
                City= dto.City,
                LanguageID= dto.LanguageID,
                Password= dto.Password,
            };
            
            _uow.FieldOwnerRepository.Add(f);
            _uow.SaveChangesAsync();

            return f;
        }
        
        [HttpDelete("{id}")]
        public FieldOwner Delete(long id)
        {
            FieldOwner f = _uow.FieldOwnerRepository.Get(id);
            _uow.FieldOwnerRepository.Delete(f);
            _uow.SaveChangesAsync();

            return f;
        }

        [HttpGet]
        public IEnumerable<FieldOwner> Get()
        {
            return _uow.FieldOwnerRepository.AllQuery().Include(f => f.Farms);
        }

        [HttpGet("{id}")]
        public IEnumerable<FieldOwner> Get(long id)
        {
            return _uow.FieldOwnerRepository.AllQuery().Where(f => f.FieldOwnerID == id).Include(f => f.Farms).Include(f => f.Language);
        }

        // ADMIN
        [HttpGet("admin/overview")]
        public IEnumerable<FieldOwner> GetFieldOwnerAndFarms()
        {
            return _uow.FieldOwnerRepository.AllQuery().Include(f => f.Farms);
        }


        [HttpPut("{id}")]
        public FieldOwner Put(long id, [FromBody]CreateFieldOwnerDto dto)
        {
            FieldOwner m = _uow.FieldOwnerRepository.Get(id);
            m.Name=dto.Name;
            m.Started=dto.Started;
            m.LanguageID=dto.LanguageID;
            m.City=dto.City;
            m.Country=dto.Country;
            m.Password=dto.Password;

            _uow.FieldOwnerRepository.Update(m);
            _uow.SaveChangesAsync();

            return m;
        }
    }
}
