//using BackEnd.API.Services;
using BackEnd.Domain.API.Models;
using BackEnd.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        //private readonly IUserService _userService;
        // testtjeeeee
        public AdminController(IUnitOfWork uow/*, IUserService userService*/)
        {
            _uow = uow;
            //_userService = userService;
        }

        /*
         // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterUser model)
        {
            //Register a new user
            User user = new User();
            user.Name = model.Name;
            user.Password = Encryption.Hash(model.Password);
            user.Email = model.Email;
            user.Points = 0;
            user.Email = model.Email.ToString();
            user.Address = model.Address;
            user.City = model.City;
            user.ZipCode= model.ZipCode;

            var newUser = _uow.UserRepository.Add(user);
            await _uow.SaveChangesAsync();

            return Ok(Mapper.Map(newUser));
        }
         */
        /*[HttpPost]
        public Admin Create(AdminDto dto)
        {
            Admin a = new Admin();
            a.Name = dto.Name;

            _uow.AdminRepository.Add(a);
            _uow.SaveChangesAsync();

            return a;
        }
        [HttpDelete("{id}")]
        public Admin Delete(int id)
        {
            Admin a = _uow.AdminRepository.Get(id);
            _uow.AdminRepository.Delete(a);
            return a;
        }*/
        [HttpGet]
        public async Task<IEnumerable<Admin>> Get()
        {
            return await _uow.AdminRepository.AllAsync();
        }
        [HttpGet("{id}")]
        public async Task<Admin> Get(long id)
        {
            return await _uow.AdminRepository.GetAsync(id);
        }
        /*[HttpPut]
        public Admin Put(int id, AdminDto dto)
        {
            Admin a = _uow.AdminRepository.Get(id);
            a.Name = dto.Name;
            
            _uow.AdminRepository.Update(a);
            _uow.SaveChangesAsync();

            return a;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> PostLogin([FromBody] LoginAdmin model)
        {
            var result = await _userService.LoginAdmin(model);

            if (result == null)
                return BadRequest("Username or password is incorrect");
            return Ok(result);
        }*/
    }
}
