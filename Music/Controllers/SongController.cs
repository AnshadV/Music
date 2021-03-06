using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Music.Models;

namespace Music.Controllers
{
    public class SongController : Controller
    {
        private readonly DataContext _context;

        public SongController(DataContext context)
        {
            _context = context;
        }

        // GET: Song
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.SongModel.Include(s => s.ArtistModel);
            return View(await dataContext.ToListAsync());
        }

        // GET: Song/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songModel = await _context.SongModel
                .Include(s => s.ArtistModel)
                .FirstOrDefaultAsync(m => m.SongId == id);
            if (songModel == null)
            {
                return NotFound();
            }

            return View(songModel);
        }

        // GET: Song/Create
        public IActionResult Create()
        {
            ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistId", "Name");
            return View();
        }

        // POST: Song/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SongId,SongName,ReleaseDate,CoverImage,ArtistId")] SongModel songModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(songModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistId", "ArtistId", songModel.ArtistId);
            return View(songModel);
        }

        // GET: Song/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songModel = await _context.SongModel.FindAsync(id);
            if (songModel == null)
            {
                return NotFound();
            }
            ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistId", "ArtistId", songModel.ArtistId);
            return View(songModel);
        }

        // POST: Song/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SongId,SongName,ReleaseDate,CoverImage,ArtistId")] SongModel songModel)
        {
            if (id != songModel.SongId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(songModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongModelExists(songModel.SongId))
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
            ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistId", "ArtistId", songModel.ArtistId);
            return View(songModel);
        }

        // GET: Song/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songModel = await _context.SongModel
                .Include(s => s.ArtistModel)
                .FirstOrDefaultAsync(m => m.SongId == id);
            if (songModel == null)
            {
                return NotFound();
            }

            return View(songModel);
        }

        // POST: Song/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var songModel = await _context.SongModel.FindAsync(id);
            _context.SongModel.Remove(songModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongModelExists(int id)
        {
            return _context.SongModel.Any(e => e.SongId == id);
        }
    }
}
