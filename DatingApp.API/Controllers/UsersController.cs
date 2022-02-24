using System.Collections.Generic;
using System.Linq;
using DatingApp.API.DataBase;
using DatingApp.API.DataBase.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(_context.Users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

    }
}