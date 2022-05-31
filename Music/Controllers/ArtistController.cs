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
    public class ArtistController : Controller
    {
        private readonly DataContext _context;

        public ArtistController(DataContext context)
        {
            _context = context;
        }

        // GET: Artist
        public async Task<IActionResult> Index()
        {
            return View(await _context.Artists.ToListAsync());
        }

        // GET: Artist/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artistModel = await _context.Artists
                .FirstOrDefaultAsync(m => m.ArtistId == id);
            if (artistModel == null)
            {
                return NotFound();
            }

            return View(artistModel);
        }

        // GET: Artist/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artist/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArtistId,Name,DOB,Bio")] ArtistModel artistModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artistModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artistModel);
        }

        // GET: Artist/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artistModel = await _context.Artists.FindAsync(id);
            if (artistModel == null)
            {
                return NotFound();
            }
            return View(artistModel);
        }

        // POST: Artist/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArtistId,Name,DOB,Bio")] ArtistModel artistModel)
        {
            if (id != artistModel.ArtistId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artistModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtistModelExists(artistModel.ArtistId))
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
            return View(artistModel);
        }

        // GET: Artist/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artistModel = await _context.Artists
                .FirstOrDefaultAsync(m => m.ArtistId == id);
            if (artistModel == null)
            {
                return NotFound();
            }

            return View(artistModel);
        }

        // POST: Artist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artistModel = await _context.Artists.FindAsync(id);
            _context.Artists.Remove(artistModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtistModelExists(int id)
        {
            return _context.Artists.Any(e => e.ArtistId == id);
        }
    }
}
