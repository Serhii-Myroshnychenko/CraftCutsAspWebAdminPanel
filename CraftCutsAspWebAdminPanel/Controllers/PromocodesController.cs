using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CraftCutsAspWebAdminPanel.Data;
using CraftCutsAspWebAdminPanel.Models;
using System.Text;

namespace CraftCutsAspWebAdminPanel.Controllers
{
    public class PromocodesController : Controller
    {
        private readonly CraftCutsNewDB2Context _context;

        public PromocodesController(CraftCutsNewDB2Context context)
        {
            _context = context;
        }

        // GET: Promocodes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Promocodes.ToListAsync());
        }

        // GET: Promocodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocode = await _context.Promocodes
                .FirstOrDefaultAsync(m => m.PromocodeId == id);
            if (promocode == null)
            {
                return NotFound();
            }

            return View(promocode);
        }

        // GET: Promocodes/Create
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> CreateAuto()
        {
            var promocode = new Promocode();
            promocode.Name = RandomString(10);
            promocode.SalePercent = 15;
            promocode.Time = DateTime.Now;
            _context.Add(promocode);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Promocodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PromocodeId,Name,SalePercent,Time")] Promocode promocode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(promocode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(promocode);
        }

        // GET: Promocodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocode = await _context.Promocodes.FindAsync(id);
            if (promocode == null)
            {
                return NotFound();
            }
            return View(promocode);
        }

        // POST: Promocodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PromocodeId,Name,SalePercent,Time")] Promocode promocode)
        {
            if (id != promocode.PromocodeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promocode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromocodeExists(promocode.PromocodeId))
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
            return View(promocode);
        }

        // GET: Promocodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocode = await _context.Promocodes
                .FirstOrDefaultAsync(m => m.PromocodeId == id);
            if (promocode == null)
            {
                return NotFound();
            }

            return View(promocode);
        }

        // POST: Promocodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promocode = await _context.Promocodes.FindAsync(id);
            _context.Promocodes.Remove(promocode);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromocodeExists(int id)
        {
            return _context.Promocodes.Any(e => e.PromocodeId == id);
        }
        private static string RandomString(int length)
        {
            Random rand = new Random();
            const string pool = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var builder = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                var c = pool[rand.Next(0, pool.Length)];
                builder.Append(c);
            }

            return builder.ToString();
        }
    }
}
