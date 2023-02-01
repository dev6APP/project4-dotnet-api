using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackEnd.DAL;
using BackEnd.Domain.Models;
using BackEnd.Domain.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoDataController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public PhotoDataController(IUnitOfWork uow) {
            _uow = uow;
        }

        [HttpPost]
        public PhotoData Create(CreatePhotoDataDto photoDataDto)
        {
            PhotoData p = new PhotoData();
            p.FieldID = photoDataDto.FieldID;
            p.AmountFlowers = photoDataDto.AmountFlowers;
            p.WorkerID = photoDataDto.WorkerID;
            p.FieldOwnerID = photoDataDto.FieldOwnerID;
            p.Date = photoDataDto.Date;
            var max_id = _uow.CoordinateRepository.AllQuery().Select(c => c.CoordinateID).Max();
            p.CoordinateID = max_id;

            _uow.PhotoDataRepository.Add(p);
            _uow.SaveChangesAsync();

            return p;
        }
        /*
        [HttpDelete("{id}")]
        public Company Delete(long id)
        {
            Company c = _uow.CompanyRepository.Get(id);
            _uow.CompanyRepository.Delete(c);
            return c;
        }*/

        // give the id of the logged in worker in the frontend
        [HttpGet("worker/{workerID}")]
        public IEnumerable<PhotoData> GetPhotoDataForWorker(long workerID)
        {
            return _uow.PhotoDataRepository.AllQuery().Where(p => p.WorkerID == workerID);
        }

        [HttpGet]
        public async Task<IEnumerable<PhotoData>> Get()
        {
            return await _uow.PhotoDataRepository.AllAsync();
        }
        [HttpGet("{id}")]
        public async Task<PhotoData> Get(int id)
        {
            return await _uow.PhotoDataRepository.GetAsync(id);
        }

        [HttpGet("fieldOwner/{fieldOwner}/year/{year}")]
        public long GetFlowersPerYear(long fieldOwner, int year)
        {
            return _uow.PhotoDataRepository.AllQuery().Where(o => o.FieldOwnerID == fieldOwner )
                .Where(f => f.Date.Year == year).Select(n => n.AmountFlowers).Sum();
        }

        // amount of flowers for the last 12 months
        [HttpGet("flowersLastYear/{id}")]
        public long GetFlowersLastYear(long id)
        {
            return _uow.PhotoDataRepository.AllQuery().Where(o => o.FieldID == id).Where(f => f.Date.Year >= DateTime.Now.Year)
                .Select(n => n.AmountFlowers).Sum(); 
        }
        /*[HttpPut]
        public Company Put(CompanyDto companyDto, long id)
        {
            Company c = _uow.CompanyRepository.Get(id);
            c.Name = companyDto.Name;
            c.Address = companyDto.Address;
            c.ZipCode = companyDto.Zipcode;

            _uow.CompanyRepository.Update(c);
            _uow.SaveChangesAsync();

            return c;
        }*/
    }
}
