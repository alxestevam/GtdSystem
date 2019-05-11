using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GtdSystem.BackService.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtdSystem.BackService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserTaskContext _context;

        public UsersController(UserTaskContext context)
        {
            _context = context;
        }
        

        // GET: api/Users
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _context.Users.Select(x => x.UserName).ToArray() ;
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "GetUsers")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Users
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
