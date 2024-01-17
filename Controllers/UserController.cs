using lab_8.DbContext;
using lab_8.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lab_8.Hasher;

namespace lab_8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private ApiDbContext _db;
        public UserController(ApiDbContext db) 
        {
            _db = db;
        }

        [HttpGet("get")]
        public IActionResult GetUser(int id)
        {
            var user = _db.Users.Where(x=>x.Id == id).FirstOrDefault();
            if (user is null)
                return BadRequest();
            return Ok(user.Name);
        }

        [HttpPost("login")]
        public IActionResult Login(string email, string password)
        {
            var user = _db.Users.Where(x=>x.Email == email).FirstOrDefault();
            if(user is not null && PasswordHasher.VerifyPassword(password, user.Password))
                return Ok(user.Id);
            return BadRequest();
        }

        [HttpPost("register")]
        public IActionResult Register(UserModel model)
        {
            if(!model.IsValid)
                return BadRequest();

            var user = _db.Users.Where(x=>x.Email==model.Email).FirstOrDefault();
            if (user is not null)
                return Conflict();

            var newUser = new User(model.Name, model.Email, model.Password, model.Address);
            _db.Users.Add(newUser);
            _db.SaveChanges();

            return Ok();
            
        }
        [HttpDelete("delete")]
        public IActionResult DeleteUser(int id)
        {
            var user = _db.Users.Where(x=>x.Id == id).FirstOrDefault();
            if(user is null)
                return BadRequest();
            _db.Users.Remove(user);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult UpdateUser(int id, UserModel model)
        {
            if (!model.IsValid)
                return BadRequest();

            var user = _db.Users.Where(x => x.Id == id).FirstOrDefault();
            if (user is null)
                return NotFound();

            user.Name = model.Name;
            user.Address = model.Address;
            user.Email = model.Email;
            user.Password = model.Password;
            _db.SaveChanges();
            return Ok();
        }
    }
}
