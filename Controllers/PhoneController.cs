using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DanilaWebApp.Data;
using DanilaWebApp.Models;

namespace DanilaWebApp.Controllers
{
    public class PhoneController : Controller
    {
        private readonly DataContext _context;

        public PhoneController(DataContext context)
        {
            _context = context;
        }

        // GET: Phone
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Phones.Include(p => p.Characteristic).Include(p => p.Order);
            return View(await dataContext.ToListAsync());
        }

        // GET: Phone/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _context.Phones
                .Include(p => p.Characteristic)
                .Include(p => p.Order)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phone == null)
            {
                return NotFound();
            }

            return View(phone);
        }

        // GET: Phone/Create
        public IActionResult Create()
        {
            ViewData["CharacteristicId"] = new SelectList(_context.PhoneCharacteristics, "Id", "Id");
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id");
            return View();
        }

        // POST: Phone/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Company,Price,CharacteristicId,OrderId")] Phone phone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CharacteristicId"] = new SelectList(_context.PhoneCharacteristics, "Id", "Id", phone.CharacteristicId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", phone.OrderId);
            return View(phone);
        }

        // GET: Phone/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _context.Phones.FindAsync(id);
            if (phone == null)
            {
                return NotFound();
            }
            ViewData["CharacteristicId"] = new SelectList(_context.PhoneCharacteristics, "Id", "Id", phone.CharacteristicId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", phone.OrderId);
            return View(phone);
        }

        // POST: Phone/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Company,Price,CharacteristicId,OrderId")] Phone phone)
        {
            if (id != phone.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhoneExists(phone.Id))
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
            ViewData["CharacteristicId"] = new SelectList(_context.PhoneCharacteristics, "Id", "Id", phone.CharacteristicId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", phone.OrderId);
            return View(phone);
        }

        // GET: Phone/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _context.Phones
                .Include(p => p.Characteristic)
                .Include(p => p.Order)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phone == null)
            {
                return NotFound();
            }

            return View(phone);
        }

        // POST: Phone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phone = await _context.Phones.FindAsync(id);
            _context.Phones.Remove(phone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhoneExists(int id)
        {
            return _context.Phones.Any(e => e.Id == id);
        }
    }
}
