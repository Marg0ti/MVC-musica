using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicAut_HernandezMargot.Data;
using MusicAut_HernandezMargot.Models;
using Microsoft.AspNetCore.Authorization;

namespace MusicAut_HernandezMargot.Controllers
{
    [Authorize]
    public class ArtistsController : Controller
    {
        private readonly Margot_ChinookContext _context;

        public ArtistsController(Margot_ChinookContext context)
        {
            _context = context;
        }

        // GET: Artists
        public async Task<IActionResult> Index()
        {
            var chinookContext = _context.Artists.OrderByDescending(x => x.Name).Take(15);
            return View(await chinookContext.ToListAsync());
        }
        public async Task<IActionResult> ShowAlbum(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
            .Where(a => a.ArtistId == id)
            .ToListAsync(); ;

            return View(album);
        }
        public async Task<IActionResult> ShowTrack(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var canciones = await _context.Albums
            .Include(a => a.Tracks)  // Incluir los álbumes del artista
            .FirstOrDefaultAsync(a => a.ArtistId == id);

            return View(canciones);
        }

        // GET: Artists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = await _context.Artists
                .Include(a => a.Reviews)
                .FirstOrDefaultAsync(m => m.ArtistId == id);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        // GET: Artists/Create
        [Authorize (Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("ArtistId,Name")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                artist.ArtistId = _context.Artists.Max(a => a.ArtistId) + 1;
                _context.Add(artist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artist);
        }

        // POST: Album/Create


        // GET: Artists/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = await _context.Artists.FindAsync(id);
            if (artist == null)
            {
                return NotFound();
            }
            return View(artist);
        }

        // POST: Artists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("ArtistId,Name")] Artist artist)
        {
            if (id != artist.ArtistId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtistExists(artist.ArtistId))
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
            return View(artist);
        }

        // GET: Artists/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = await _context.Artists
                .Include(a => a.Albums)
                .FirstOrDefaultAsync(m => m.ArtistId == id);
            if (artist == null)
            {
                return NotFound();
            }

            return RedirectToAction("Temporal", "Home");
        }

        // POST: Artists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artist = await _context.Artists
                .Include(a => a.Albums) // Incluye álbumes asociados
                .FirstOrDefaultAsync(m => m.ArtistId == id);

            if (artist != null)
            {
                // Elimina los álbumes asociados
                _context.Albums.RemoveRange(artist.Albums);

                // Elimina el artista
                _context.Artists.Remove(artist);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }

        private bool ArtistExists(int id)
        {
            return _context.Artists.Any(e => e.ArtistId == id);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult CreateAlbum(int Id)
        {
            ViewData["ArtistId"] = Id;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public IActionResult CreateAlbum(Album album)
        {
            if (ModelState.IsValid)
            {
                int newAlbumId = _context.Albums.Max(a => a.AlbumId); //buscamos el último id
                album.AlbumId = newAlbumId + 1;
                album.Artist = _context.Artists.Find(album.ArtistId); //añadir el nombre del artista
                _context.Albums.Add(album); 
                _context.SaveChanges();
                return RedirectToAction("Index"); // Redirigir a la lista de álbumes
            }

            // Si el modelo no es válido, vuelve a mostrar la vista
            return View(album);
        }

    
    }
}
