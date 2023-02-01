using BackEnd.Domain.API.Models;
using BackEnd.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public WorkerController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpPost]
        public Worker CreateWorker(WorkerDto dto)
        {
            Worker w = new()
            {
                Name= dto.Name,
                Password= dto.Password,
                PhoneNumber= dto.PhoneNumber,
                Country= dto.Country,
                City= dto.City,
                EmailAddress= dto.EmailAddress,
                ContractEndDate= dto.ContractEndDate,
                ContractStartDate = dto.ContractStartDate,
                PermissionID= dto.PermissionID,
                LanguageID= dto.LanguageID
            };
            

            _uow.WorkerRepository.Add(w);
            _uow.SaveChangesAsync();

            return w;
        }
        [HttpDelete("{id}")]
        public Worker Delete(long id)
        {
            Worker w = _uow.WorkerRepository.Get(id);
            _uow.WorkerRepository.Delete(w);
            _uow.SaveChangesAsync();

            return w;
        }
        [HttpGet]
        public async Task<IEnumerable<Worker>> Get()
        {
            return await _uow.WorkerRepository.AllAsync();
        }
        [HttpGet("{id}")]
        public IEnumerable<Worker> Get(long id)
        {
            return _uow.WorkerRepository.AllQuery().Where(w => w.WorkerID == id).Include(w => w.Language).Include(w => w.Permission);
        }

        // workers of a farm 
        [HttpGet("farm/{farmID}")]
        public IEnumerable<FarmStaff> GetFarmsWorkers(long farmID)
        {
            return _uow.FarmStaffRepository.AllQuery().Where(f => f.FarmID == farmID).Include(s => s.Worker).Include(s => s.Farm);
        }


        [HttpPut("{id}")]
        public Worker Put([FromBody]WorkerDto dto, [FromRoute]long id)
        {
            Worker e = _uow.WorkerRepository.Get(id);
            e.Name = dto.Name;
            e.ContractStartDate = dto.ContractStartDate;
            e.ContractEndDate = dto.ContractEndDate;
            e.PhoneNumber = dto.PhoneNumber;
            e.EmailAddress= dto.EmailAddress;
            e.PermissionID= dto.PermissionID;
            e.LanguageID= dto.LanguageID;
            e.Country= dto.Country;
            e.City= dto.City;
            e.Password= dto.Password;

            _uow.WorkerRepository.Update(e);
            _uow.SaveChangesAsync();

            return e;
        }
    }
}
