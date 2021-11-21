using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CraftCutsAspWebAdminPanel.Data;
using CraftCutsAspWebAdminPanel.Models;

namespace CraftCutsAspWebAdminPanel.Controllers
{
    public class BookingsController : Controller
    {
        private readonly CraftCutsNewDB2Context _context;

        public BookingsController(CraftCutsNewDB2Context context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var craftCutsNewDB2Context = _context.Bookings.Include(b => b.Barber).Include(b => b.Customer).Include(b => b.Promocode);
            return View(await craftCutsNewDB2Context.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Barber)
                .Include(b => b.Customer)
                .Include(b => b.Promocode)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            ViewData["BarberId"] = new SelectList(_context.Barbers, "BarberId", "Email");
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Email");
            ViewData["PromocodeId"] = new SelectList(_context.Promocodes, "PromocodeId", "Name");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,BarberId,CustomerId,Price,Date,IsPaid,PromocodeId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BarberId"] = new SelectList(_context.Barbers, "BarberId", "Email", booking.BarberId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Email", booking.CustomerId);
            ViewData["PromocodeId"] = new SelectList(_context.Promocodes, "PromocodeId", "Name", booking.PromocodeId);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["BarberId"] = new SelectList(_context.Barbers, "BarberId", "Email", booking.BarberId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Email", booking.CustomerId);
            ViewData["PromocodeId"] = new SelectList(_context.Promocodes, "PromocodeId", "Name", booking.PromocodeId);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingId,BarberId,CustomerId,Price,Date,IsPaid,PromocodeId")] Booking booking)
        {
            if (id != booking.BookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.BookingId))
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
            ViewData["BarberId"] = new SelectList(_context.Barbers, "BarberId", "Email", booking.BarberId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Email", booking.CustomerId);
            ViewData["PromocodeId"] = new SelectList(_context.Promocodes, "PromocodeId", "Name", booking.PromocodeId);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Barber)
                .Include(b => b.Customer)
                .Include(b => b.Promocode)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.BookingId == id);
        }
    }
}
