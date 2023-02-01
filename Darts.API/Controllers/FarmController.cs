using BackEnd.DAL.Repositories;
using BackEnd.Domain.API.Models;
using BackEnd.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public FarmController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpPost]
        public Farm Create(CreateFarmDto farmdto)
        {
            Farm f = new Farm();
            f.FieldOwnerID = farmdto.FieldOwnerID;
            f.Name = farmdto.Name;
            f.Address = farmdto.Address;
            f.Started = farmdto.Started;

            _uow.FarmRepository.Add(f);
            _uow.SaveChangesAsync();

            return f;
        }
        
        [HttpDelete("{id}")]
        public Farm Delete(long id)
        {
            Farm f = _uow.FarmRepository.Get(id);
            _uow.FarmRepository.Delete(f);
            _uow.SaveChangesAsync();

            return f;
        }

        [HttpGet("fieldOwner/{fieldOwnerID}")]
        public IEnumerable<Farm> GetFarmByFieldOwnerId(long fieldOwnerID)
        {
            return _uow.FarmRepository.AllQuery().Where(f => f.FieldOwnerID == fieldOwnerID).Include(m => m.Fields)
                .Include(f => f.FarmStaffs).Include(f => f.FieldOwner);
        }

        /*[HttpGet("myPronostics/{userId}")]
        public async Task<IEnumerable<Pronostic>> GetMyPredictions(long userId)
        {
            return _uow.PronosticRepository.AllQuery().Where(p => p.UserID == userId);
        }*/

        [HttpGet("{id}")]
        public IEnumerable<Farm> Get(long id)
        {
            return _uow.FarmRepository.AllQuery().Where(f => f.FarmID == id).Include(m => m.Fields)
                .Include(f => f.FarmStaffs).Include(f => f.FieldOwner);
        }

        [HttpGet]
        public IEnumerable<Farm> GetAll()
        {
            return _uow.FarmRepository.AllQuery().Include(f => f.Fields);
        }


        // edit a farm (fieldowner)
        [HttpPut("{id}")]
        public Farm Put(long id, [FromBody]UpdateFarmDto farmDto)
        {
            Farm t = _uow.FarmRepository.Get(id);
            t.Name = farmDto.Name;
            t.Address = farmDto.Address;

            _uow.FarmRepository.Update(t);
            _uow.SaveChangesAsync();

            return t;
        }
    }
}

