using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApplication21_1.Data;
using WebApplication21_1.Models;

namespace WebApplication21_1.Controllers
{
    public class QuestController : Controller
    {
        private readonly QuestContext _context;

        public QuestController(QuestContext context)
        {
            _context = context;
        }

        // GET: Quest
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index(SortState sortOrder = SortState.PlayersCountAsc)
        {
            var quests = _context.Quests.Where(x => x.Id > 0);

            ViewData["CountSort"] = sortOrder == SortState.PlayersCountAsc ? SortState.PlayersCountDesc : SortState.PlayersCountAsc;
            ViewData["DifficultySort"] = sortOrder == SortState.DifficultyAsc ? SortState.DifficultyDesc : SortState.DifficultyAsc;
            ViewData["FearSort"] = sortOrder == SortState.LevelFearAsc ? SortState.LevelFearDesc : SortState.LevelFearAsc;


            quests = sortOrder switch
            {
                SortState.PlayersCountAsc => quests.OrderByDescending(s => s.PlayersCount),
                SortState.LevelFearAsc => quests.OrderBy(s => s.LevelFear),
                SortState.LevelFearDesc => quests.OrderByDescending(s => s.LevelFear),
                SortState.DifficultyAsc => quests.OrderBy(s => s.Difficulty),
                SortState.DifficultyDesc => quests.OrderByDescending(s => s.Difficulty),
                _ => quests.OrderBy(s => s.Difficulty),
            };

            return View(await quests.AsNoTracking().ToListAsync());
        }
        [Authorize]
        public async Task<IActionResult> Search(Difficulty difficulty)
        {
            var quests = _context.Quests.Where(x => x.Difficulty == difficulty);

            return View(quests);
        }
        [Authorize]

        // GET: Quest/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Quests == null)
            {
                return NotFound();
            }

            var quest = await _context.Quests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quest == null)
            {
                return NotFound();
            }

            return View(quest);
        }
        [Authorize]
        // GET: Quest/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: Quest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PlayersCount,Difficulty,LevelFear")] Quest quest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quest);
        }
        [Authorize]
        // GET: Quest/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Quests == null)
            {
                return NotFound();
            }

            var quest = await _context.Quests.FindAsync(id);
            if (quest == null)
            {
                return NotFound();
            }
            return View(quest);
        }
        [Authorize]
        // POST: Quest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PlayersCount,Difficulty,LevelFear")] Quest quest)
        {
            if (id != quest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestExists(quest.Id))
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
            return View(quest);
        }
          [Authorize]
        // GET: Quest/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Quests == null)
            {
                return NotFound();
            }

            var quest = await _context.Quests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quest == null)
            {
                return NotFound();
            }

            return View(quest);
        }
        [Authorize]
        // POST: Quest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Quests == null)
            {
                return Problem("Entity set 'QuestContext.Quests'  is null.");
            }
            var quest = await _context.Quests.FindAsync(id);
            if (quest != null)
            {
                _context.Quests.Remove(quest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestExists(int id)
        {
          return (_context.Quests?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
