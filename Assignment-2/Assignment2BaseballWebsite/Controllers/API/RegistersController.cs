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
    public class RegistersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RegistersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Registers
        [HttpGet]
        public IEnumerable<Register> GetRegister()
        {
            return _context.Register;
        }

        // GET: api/Registers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegister([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var register = await _context.Register.FindAsync(id);

            if (register == null)
            {
                return NotFound();
            }

            return Ok(register);
        }

        // PUT: api/Registers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegister([FromRoute] int id, [FromBody] Register register)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != register.RegisterId)
            {
                return BadRequest();
            }

            _context.Entry(register).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisterExists(id))
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

        // POST: api/Registers
        [HttpPost]
        public async Task<IActionResult> PostRegister([FromBody] Register register)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Register.Add(register);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegister", new { id = register.RegisterId }, register);
        }

        
        private bool RegisterExists(int id)
        {
            return _context.Register.Any(e => e.RegisterId == id);
        }
    }
}