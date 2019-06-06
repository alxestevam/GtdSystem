using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GtdSystem.BackService.Data;
using GtdSystem.BackService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GtdSystem.BackService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserTasksController : ControllerBase
    {
        private UserTaskContext _context;
        private UserManager<AplicationUser> userManager;

        public UserTasksController(UserTaskContext context, UserManager<AplicationUser> userManager)
        {
            this.userManager = userManager;
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior=QueryTrackingBehavior.NoTracking;
        }
        

        // GET: api/Tasks
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var userId = userManager.GetUserId(HttpContext.User);

            return Ok(await _context.UserTasks
                .AsNoTracking()
                .Where(x => x.AplicationUser.Id == userId)
                .ToListAsync());
        }

        // GET: api/Tasks/5
        [HttpGet("{id}", Name = "Get")]
        public UserTask Get(int id)
        {
            Console.WriteLine("GET BY ID=" +id);
            var userId = userManager.GetUserId(HttpContext.User);

            var task = _context.UserTasks.Find(id);

            return task;

            /*if (task.AplicationUser.Id == userId)
                return task;
            else
                return null;*/
        }

        // POST: api/Tasks
        [HttpPost]
        public IActionResult Post([FromBody] TaskFront value)
        {
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = userManager.GetUserId(HttpContext.User);
            

            Console.WriteLine("UserID: " + userId);

            UserTask newTask = new UserTask();
            AplicationUser appUser = _context.Users.Find(userId);

            Console.WriteLine("User found email: " + appUser.Email);
            newTask.AplicationUser = appUser;
            newTask.Deadline = value.Deadline;
            newTask.Title = value.Title;
            newTask.Type = Models.Type.next;

            _context.UserTasks.Update(newTask);
            _context.SaveChanges();

            return Ok();
        }

        // POST: api/Tasks
        [HttpPost("/adiar", Name = "Adiar")]
        public void PostAdiar()
        {
            var userId = userManager.GetUserId(HttpContext.User);

            using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=GtdSystem;Integrated Security=True")) {
                SqlCommand cmd = new SqlCommand("adiarAllTask", conn);
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            
        }

        // PUT: api/Tasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] UserTask value)
        {
            if (_context.UserTasks.Find(id) == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await userManager.GetUserAsync(HttpContext.User);
            var userId = await userManager.GetUserIdAsync(user);
            /*
            if(value.AplicationUser.Id == userId)
            {

            }
            */

            _context.UserTasks.Update(value);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // PUT: api/Tasks/5/toggle
        [HttpPut("{id}/toggle")]
        public async Task<IActionResult> PutAsync(int id)
        {
            UserTask task = _context.UserTasks.Find(id);
            if (task == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await userManager.GetUserAsync(HttpContext.User);
            var userId = await userManager.GetUserIdAsync(user);
            /*
            if(value.AplicationUser.Id == userId)
            {

            }
            */

            task.Done = !task.Done;
            _context.UserTasks.Update(task);
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
