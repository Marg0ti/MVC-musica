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
    public class ReviewsController : Controller
    {
        private readonly Margot_ChinookContext _context;

        public ReviewsController(Margot_ChinookContext context)
        {
            _context = context;
        }

        // GET: Reviews
        //public async Task<IActionResult> Index()
        //{
        //    var chinookContext = _context.Reviews.Include(r => r.Artist);
        //    return View(await chinookContext.ToListAsync());
        //}

        // GET: Reviews/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var review = await _context.Reviews
        //        .Include(r => r.Artist)
        //        .FirstOrDefaultAsync(m => m.ReviewId == id);
        //    if (review == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(review);
        //}

        // GET: Reviews/Create
        [Authorize(Roles = "Platinum")]
        public IActionResult Create(int? id)
        {
			if (id == null)
			{
				return NotFound();
			}
            ViewData["ArtistId"] = id;

            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Platinum")]
        public async Task<IActionResult> Create([Bind("ArtistId,Title,ReviewContent,Rating")] Review review)
        {
            Console.WriteLine($"ArtistId: {review.ArtistId}, Title: {review.Title}, Content: {review.ReviewContent}, Rating: {review.Rating}");
            if (ModelState.IsValid)
            {
                _context.Add(review);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Artists", new {Id = review.ArtistId });
            }
            
            return View(review);
        }

        // GET: Reviews/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var review = await _context.Reviews.FindAsync(id);
        //    if (review == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistId", "ArtistId", review.ArtistId);
        //    return View(review);
        //}

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ReviewId,Title,ReviewContent,Rating,ArtistId")] Review review)
        //{
        //    if (id != review.ReviewId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(review);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ReviewExists(review.ReviewId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistId", "ArtistId", review.ArtistId);
        //    return View(review);
        //}

        // GET: Reviews/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var review = await _context.Reviews
        //        .Include(r => r.Artist)
        //        .FirstOrDefaultAsync(m => m.ReviewId == id);
        //    if (review == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(review);
        //}

        // POST: Reviews/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var review = await _context.Reviews.FindAsync(id);
        //    if (review != null)
        //    {
        //        _context.Reviews.Remove(review);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ReviewExists(int id)
        //{
        //    return _context.Reviews.Any(e => e.ReviewId == id);
        //}
    }
}
