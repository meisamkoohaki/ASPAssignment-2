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
    public class TeamInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeamInfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TeamInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TeamInfo.ToListAsync());
        }

        // GET: TeamInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamInfo = await _context.TeamInfo
                .FirstOrDefaultAsync(m => m.TeamInfoId == id);
            if (teamInfo == null)
            {
                return NotFound();
            }

            return View(teamInfo);
        }

        // GET: TeamInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeamInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeamInfoId,TeamName,TeamLogoURL,TeamDivision,HomeField,TeamManager")] TeamInfo teamInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teamInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teamInfo);
        }

        // GET: TeamInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamInfo = await _context.TeamInfo.FindAsync(id);
            if (teamInfo == null)
            {
                return NotFound();
            }
            return View(teamInfo);
        }

        // POST: TeamInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeamInfoId,TeamName,TeamLogoURL,TeamDivision,HomeField,TeamManager")] TeamInfo teamInfo)
        {
            if (id != teamInfo.TeamInfoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teamInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamInfoExists(teamInfo.TeamInfoId))
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
            return View(teamInfo);
        }

        // GET: TeamInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamInfo = await _context.TeamInfo
                .FirstOrDefaultAsync(m => m.TeamInfoId == id);
            if (teamInfo == null)
            {
                return NotFound();
            }

            return View(teamInfo);
        }

        // POST: TeamInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teamInfo = await _context.TeamInfo.FindAsync(id);
            _context.TeamInfo.Remove(teamInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamInfoExists(int id)
        {
            return _context.TeamInfo.Any(e => e.TeamInfoId == id);
        }
    }
}
