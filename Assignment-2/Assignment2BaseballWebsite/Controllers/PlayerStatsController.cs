using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment2BaseballWebsite.Data;
using Assignment2BaseballWebsite.Models;

namespace Assignment2BaseballWebsite.Controllers
{
    public class PlayerStatsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlayerStatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PlayerStats
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PlayerStats.Include(p => p.playerInfo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PlayerStats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerStats = await _context.PlayerStats
                .Include(p => p.playerInfo)
                .FirstOrDefaultAsync(m => m.StatId == id);
            if (playerStats == null)
            {
                return NotFound();
            }

            return View(playerStats);
        }

        // GET: PlayerStats/Create
        public IActionResult Create()
        {
            ViewData["RegisterId"] = new SelectList(_context.Register, "RegisterId", "City");
            return View();
        }

        // POST: PlayerStats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StatId,Hits,Doubles,Triples,HomeRuns,RunsBattedIn,RegisterId")] PlayerStats playerStats)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playerStats);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RegisterId"] = new SelectList(_context.Register, "RegisterId", "City", playerStats.playerInfo);
            return View(playerStats);
        }

        // GET: PlayerStats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerStats = await _context.PlayerStats.FindAsync(id);
            if (playerStats == null)
            {
                return NotFound();
            }
            ViewData["RegisterId"] = new SelectList(_context.Register, "RegisterId", "City", playerStats.playerInfo);
            return View(playerStats);
        }

        // POST: PlayerStats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StatId,Hits,Doubles,Triples,HomeRuns,RunsBattedIn,RegisterId")] PlayerStats playerStats)
        {
            if (id != playerStats.StatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playerStats);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerStatsExists(playerStats.StatId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["RegisterId"] = new SelectList(_context.Register, "RegisterId", "City", playerStats.RegisterId);
            return View(playerStats);
        }

        // GET: PlayerStats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerStats = await _context.PlayerStats
                .Include(p => p.playerInfo)
                .FirstOrDefaultAsync(m => m.StatId == id);
            if (playerStats == null)
            {
                return NotFound();
            }

            return View(playerStats);
        }

        // POST: PlayerStats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playerStats = await _context.PlayerStats.FindAsync(id);
            _context.PlayerStats.Remove(playerStats);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerStatsExists(int id)
        {
            return _context.PlayerStats.Any(e => e.StatId == id);
        }
    }
}
