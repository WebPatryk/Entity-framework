using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entity.Data;
using Entity.Models;

namespace Entity.Controllers
{
    public class CarMoviesController : Controller
    {
        private readonly EntityContext _context;

        public CarMoviesController(EntityContext context)
        {
            _context = context;
        }

        // GET: CarMovies
        public async Task<IActionResult> Index(string searchString)
        {

            var car = from m in _context.CarMovie
                      select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                //LINQ - method based syntax
                car = car.Where(s => s.CarTitle.Contains(searchString)); //Lambda Expression
            }


            return View(await _context.CarMovie.ToListAsync());
        }

        // GET: CarMovies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carMovie = await _context.CarMovie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carMovie == null)
            {
                return NotFound();
            }

            return View(carMovie);
        }

        // GET: CarMovies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarMovies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CarTitle,State,Country,Price")] CarMovie carMovie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carMovie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carMovie);
        }

        // GET: CarMovies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carMovie = await _context.CarMovie.FindAsync(id);
            if (carMovie == null)
            {
                return NotFound();
            }
            return View(carMovie);
        }

        // POST: CarMovies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CarTitle,State,Country,Price")] CarMovie carMovie)
        {
            if (id != carMovie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carMovie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarMovieExists(carMovie.Id))
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
            return View(carMovie);
        }

        // GET: CarMovies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carMovie = await _context.CarMovie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carMovie == null)
            {
                return NotFound();
            }

            return View(carMovie);
        }

        // POST: CarMovies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carMovie = await _context.CarMovie.FindAsync(id);
            _context.CarMovie.Remove(carMovie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarMovieExists(int id)
        {
            return _context.CarMovie.Any(e => e.Id == id);
        }
    }
}
