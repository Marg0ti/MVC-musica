﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicAut_HernandezMargot.Data;
using MusicAut_HernandezMargot.Models;

namespace MusicAut_HernandezMargot.Controllers
{
    public class TracksController : Controller
    {
        private readonly Margot_ChinookContext _context;

        public TracksController(Margot_ChinookContext context)
        {
            _context = context;
        }

        // GET: Tracks
        public async Task<IActionResult> Index()
        {
            var chinookContext = _context.Tracks.Include(t => t.Album).Include(t => t.Genre).Include(t => t.MediaType).OrderByDescending(x => x.Name).Take(15);
            return View(await chinookContext.ToListAsync());
        }

        // GET: Tracks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = await _context.Tracks
                .Include(t => t.Album)
                .Include(t => t.Genre)
                .Include(t => t.MediaType)
                .FirstOrDefaultAsync(m => m.TrackId == id);
            if (track == null)
            {
                return NotFound();
            }

            return View(track);
        }

        // GET: Tracks/Create
        public IActionResult Create()
        {
            ViewData["AlbumId"] = new SelectList(_context.Albums, "AlbumId", "AlbumId");
            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "GenreId");
            ViewData["MediaTypeId"] = new SelectList(_context.MediaTypes, "MediaTypeId", "MediaTypeId");
            return View();
        }

        // POST: Tracks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrackId,Name,AlbumId,MediaTypeId,GenreId,Composer,Milliseconds,Bytes,UnitPrice")] Track track)
        {
            if (ModelState.IsValid)
            {
                _context.Add(track);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlbumId"] = new SelectList(_context.Albums, "AlbumId", "AlbumId", track.AlbumId);
            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "GenreId", track.GenreId);
            ViewData["MediaTypeId"] = new SelectList(_context.MediaTypes, "MediaTypeId", "MediaTypeId", track.MediaTypeId);
            return View(track);
        }

        // GET: Tracks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = await _context.Tracks.FindAsync(id);
            if (track == null)
            {
                return NotFound();
            }
            ViewData["AlbumId"] = new SelectList(_context.Albums, "AlbumId", "AlbumId", track.AlbumId);
            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "GenreId", track.GenreId);
            ViewData["MediaTypeId"] = new SelectList(_context.MediaTypes, "MediaTypeId", "MediaTypeId", track.MediaTypeId);
            return View(track);
        }

        // POST: Tracks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrackId,Name,AlbumId,MediaTypeId,GenreId,Composer,Milliseconds,Bytes,UnitPrice")] Track track)
        {
            if (id != track.TrackId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(track);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrackExists(track.TrackId))
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
            ViewData["AlbumId"] = new SelectList(_context.Albums, "AlbumId", "AlbumId", track.AlbumId);
            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "GenreId", track.GenreId);
            ViewData["MediaTypeId"] = new SelectList(_context.MediaTypes, "MediaTypeId", "MediaTypeId", track.MediaTypeId);
            return View(track);
        }

        // GET: Tracks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = await _context.Tracks
                .Include(t => t.Album)
                .Include(t => t.Genre)
                .Include(t => t.MediaType)
                .FirstOrDefaultAsync(m => m.TrackId == id);
            if (track == null)
            {
                return NotFound();
            }

            return View(track);
        }

        // POST: Tracks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var track = await _context.Tracks.FindAsync(id);
            if (track != null)
            {
                _context.Tracks.Remove(track);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrackExists(int id)
        {
            return _context.Tracks.Any(e => e.TrackId == id);
        }
    }
}
