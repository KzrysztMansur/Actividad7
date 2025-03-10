using actividad7.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace actividad7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseGroupsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CourseGroupsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/coursegroups
        [HttpGet]
        public async Task<IActionResult> GetCourseGroups()
        {
            var courseGroups = await _context.CourseGroups
                                              .Include(cg => cg.Course)
                                              .Include(cg => cg.Group)
                                              .Include(cg => cg.Teacher)
                                              .ToListAsync();

            if (courseGroups == null || !courseGroups.Any())
            {
                return NotFound("No course groups found.");
            }

            return Ok(courseGroups);  // HTTP 200 OK with the list of course groups
        }

        // GET: api/coursegroups/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseGroup(int id)
        {
            var courseGroup = await _context.CourseGroups
                                             .Include(cg => cg.Course)
                                             .Include(cg => cg.Group)
                                             .Include(cg => cg.Teacher)
                                             .FirstOrDefaultAsync(cg => cg.CourseGroupId == id);

            if (courseGroup == null)
            {
                return NotFound($"CourseGroup with ID {id} not found.");
            }

            return Ok(courseGroup);  // HTTP 200 OK with the course group
        }

        // POST: api/coursegroups
        [HttpPost]
        public async Task<IActionResult> CreateCourseGroup(CourseGroup courseGroup)
        {
            if (courseGroup == null)
            {
                return BadRequest("CourseGroup data is invalid.");
            }

            _context.CourseGroups.Add(courseGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCourseGroup), new { id = courseGroup.CourseGroupId }, courseGroup);  // HTTP 201 Created with the URI of the newly created course group
        }

        // PUT: api/coursegroups/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourseGroup(int id, CourseGroup courseGroup)
        {
            if (id != courseGroup.CourseGroupId)
            {
                return BadRequest("CourseGroup ID mismatch.");
            }

            var existingCourseGroup = await _context.CourseGroups.FindAsync(id);
            if (existingCourseGroup == null)
            {
                return NotFound($"CourseGroup with ID {id} not found.");
            }

            _context.Entry(courseGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();  // HTTP 204 No Content after successful update
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating the course group.");
            }
        }

        // DELETE: api/coursegroups/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseGroup(int id)
        {
            var courseGroup = await _context.CourseGroups.FindAsync(id);
            if (courseGroup == null)
            {
                return NotFound($"CourseGroup with ID {id} not found.");
            }

            _context.CourseGroups.Remove(courseGroup);
            await _context.SaveChangesAsync();

            return NoContent();  // HTTP 204 No Content after successful delete
        }
    }
}
