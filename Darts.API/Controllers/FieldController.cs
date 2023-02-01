using BackEnd.Domain.API.Models;
using BackEnd.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public FieldController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpPost]
        public Field Create(CreateFieldDto field)
        {
            Field f = new()
            {
                Name = field.Name,
                FarmID = field.FarmID,
            };
            
            _uow.FieldRepository.Add(f);
            _uow.SaveChangesAsync();

            return f;
        }

        
        [HttpDelete("{id}")]
        public Field Delete(long id)
        {
            Field f = _uow.FieldRepository.Get(id);
            _uow.FieldRepository.Delete(f);
            _uow.SaveChangesAsync();
            
            return f;
        }

        [HttpGet]
        public async Task<IEnumerable<Field>> Get()
        {
            return await _uow.FieldRepository.AllAsync();
        }
        [HttpGet("WithBoundaries")]
        public IEnumerable<Field> GetFieldsWithBoundaries()
        {
            return _uow.FieldRepository.AllQuery().Include(b => b.Boundaries); 
        }

        [HttpGet("{id}")]
        public async Task<Field> Get(long id)
        {
            return await _uow.FieldRepository.GetAsync(id);
        }

        // fields that are part of a certain farm
        [HttpGet("farm/{farmId}")]
        public IEnumerable<Field> GetFieldsOfFarm(long farmId)
        {
            return _uow.FieldRepository.AllQuery().Where(f => f.FarmID == farmId);
        }

        [HttpPut("{id}")]
        public Field Put([FromBody]UpdateNameDto field, long id)
        {
            Field t = _uow.FieldRepository.Get(id);
            t.Name = field.Name;

            _uow.FieldRepository.Update(t);
            _uow.SaveChangesAsync();

            return t;
        }
    }
}
