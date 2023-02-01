using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackEnd.DAL;
using BackEnd.Domain.Models;
using BackEnd.Domain.API.Models;


namespace BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public PermissionController(IUnitOfWork uow) {
            _uow = uow;
        }

        [HttpPost]
        public Permission Create(UpdateNameDto dto)
        {
            Permission p = new()
            {
                Name= dto.Name
            };

            _uow.PermissionRepository.Add(p);
            _uow.SaveChangesAsync();

            return p;
        }

        [HttpDelete("{id}")]
        public Permission Delete(long id)
        {
            Permission c = _uow.PermissionRepository.Get(id);
            _uow.PermissionRepository.Delete(c);
            _uow.SaveChangesAsync();

            return c;
        }
        [HttpGet]
        public async Task<IEnumerable<Permission>> Get()
        {
            return await _uow.PermissionRepository.AllAsync();
        }
        [HttpGet("{id}")]
        public async Task<Permission> Get(int id)
        {
            return await _uow.PermissionRepository.GetAsync(id);
        }
        [HttpPut("{id}")]
        public Permission Put(long id, [FromBody]UpdateNameDto dto )
        {
            Permission c = _uow.PermissionRepository.Get(id);
            c.Name = dto.Name;
            
            _uow.PermissionRepository.Update(c);
            _uow.SaveChangesAsync();

            return c;
        }
    }
}
