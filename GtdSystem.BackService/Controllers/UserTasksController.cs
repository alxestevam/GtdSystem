using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GtdSystem.BackService.Data;
using GtdSystem.BackService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GtdSystem.BackService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTasksController : ControllerBase
    {
        private UserTaskContext _context;

        public UserTasksController(UserTaskContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior=QueryTrackingBehavior.NoTracking;
        }
        

        // GET: api/Tasks
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.UserTasks
                .AsNoTracking()
                .ToListAsync());
        }

        // GET: api/Tasks/5
        [HttpGet("{id}", Name = "Get")]
        public UserTask Get(int id)
        {
            return _context.UserTasks.Find(id);
        }

        // POST: api/Tasks
        [HttpPost]
        public IActionResult Post([FromBody] UserTask value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.UserTasks.Add(value);
            _context.SaveChanges();

            return Ok();
        }

        // PUT: api/Tasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] UserTask value)
        {
            if (_context.UserTasks.Find(id) == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.UserTasks.Update(value);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // TODO: Fix this
            var userTask = _context.UserTasks.Find(id);

            if (userTask == null) return NotFound();

            _context.UserTasks.Remove(userTask);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
