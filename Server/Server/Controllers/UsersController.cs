using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private TaskContext _Context;

        public UsersController( TaskContext _Context )
        {
            this._Context = _Context;
        }

        [HttpGet]
        public IActionResult CheckLogin (User user)
        {
            User u = _Context.User.Where(u => 
            u.Email == user.Email && u.Password == user.Password).FirstOrDefault();

            if (u == null)
            {
                return BadRequest();

            }return Ok();

        }


        [HttpPost]
        public IActionResult CheckRegister(User user)
        {
             _Context.User.Add(user);

            return Ok();
        }

    }
}
