using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackEnd.DAL;
using BackEnd.Domain.Models;
using BackEnd.Domain.API.Models;


namespace BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public LanguageController(IUnitOfWork uow) {
            _uow = uow;
        }

        [HttpPost]
        public Language Create(UpdateNameDto dto)
        {
            Language c = new()
            {
                Name= dto.Name,
            };
            

            _uow.LanguageRepository.Add(c);
            _uow.SaveChangesAsync();

            return c;
        }
        
        [HttpDelete("{id}")]
        public Language Delete(long id)
        {
            Language c = _uow.LanguageRepository.Get(id);
            _uow.LanguageRepository.Delete(c);
            _uow.SaveChangesAsync();

            return c;
        }
        [HttpGet]
        public async Task<IEnumerable<Language>> Get()
        {
            return await _uow.LanguageRepository.AllAsync();
        }
        [HttpGet("{id}")]
        public async Task<Language> Get(int id)
        {
            return await _uow.LanguageRepository.GetAsync(id);
        }
        [HttpPut("{id}")]
        public Language Put([FromRoute]long id, [FromBody]UpdateNameDto dto)
        {
            Language c = _uow.LanguageRepository.Get(id);
            c.Name = dto.Name;

            _uow.LanguageRepository.Update(c);
            _uow.SaveChangesAsync();

            return c;
        }
    }
}
