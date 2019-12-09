using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment2BaseballWebsite.Data;
using Assignment2BaseballWebsite.Models;

namespace Assignment2BaseballWebsite.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TeamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Teams
        [HttpGet]
        public IEnumerable<TeamInfo> GetTeamInfo()
        {
            return _context.TeamInfo;
        }

        // GET: api/Teams/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teamInfo = await _context.TeamInfo.FindAsync(id);

            if (teamInfo == null)
            {
                return NotFound();
            }

            return Ok(teamInfo);
        }

        // PUT: api/Teams/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeamInfo([FromRoute] int id, [FromBody] TeamInfo teamInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teamInfo.TeamInfoId)
            {
                return BadRequest();
            }

            _context.Entry(teamInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Teams
        [HttpPost]
        public async Task<IActionResult> PostTeamInfo([FromBody] TeamInfo teamInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TeamInfo.Add(teamInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeamInfo", new { id = teamInfo.TeamInfoId }, teamInfo);
        }

        // DELETE: api/Teams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teamInfo = await _context.TeamInfo.FindAsync(id);
            if (teamInfo == null)
            {
                return NotFound();
            }

            _context.TeamInfo.Remove(teamInfo);
            await _context.SaveChangesAsync();

            return Ok(teamInfo);
        }

        private bool TeamInfoExists(int id)
        {
            return _context.TeamInfo.Any(e => e.TeamInfoId == id);
        }
    }
}