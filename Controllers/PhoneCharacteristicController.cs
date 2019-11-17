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
    public class PhoneCharacteristicController : Controller
    {
        private readonly DataContext _context;

        public PhoneCharacteristicController(DataContext context)
        {
            _context = context;
        }

        // GET: PhoneCharacteristic
        public async Task<IActionResult> Index()
        {
            return View(await _context.PhoneCharacteristics.ToListAsync());
        }

        // GET: PhoneCharacteristic/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneCharacteristic = await _context.PhoneCharacteristics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phoneCharacteristic == null)
            {
                return NotFound();
            }

            return View(phoneCharacteristic);
        }

        // GET: PhoneCharacteristic/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhoneCharacteristic/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,type,opSystem,ScreenType,PhoneWidth,PhoneHeight,PhoneDepth,CpuModel")] PhoneCharacteristic phoneCharacteristic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phoneCharacteristic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phoneCharacteristic);
        }

        // GET: PhoneCharacteristic/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneCharacteristic = await _context.PhoneCharacteristics.FindAsync(id);
            if (phoneCharacteristic == null)
            {
                return NotFound();
            }
            return View(phoneCharacteristic);
        }

        // POST: PhoneCharacteristic/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,type,opSystem,ScreenType,PhoneWidth,PhoneHeight,PhoneDepth,CpuModel")] PhoneCharacteristic phoneCharacteristic)
        {
            if (id != phoneCharacteristic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phoneCharacteristic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhoneCharacteristicExists(phoneCharacteristic.Id))
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
            return View(phoneCharacteristic);
        }

        // GET: PhoneCharacteristic/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneCharacteristic = await _context.PhoneCharacteristics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phoneCharacteristic == null)
            {
                return NotFound();
            }

            return View(phoneCharacteristic);
        }

        // POST: PhoneCharacteristic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phoneCharacteristic = await _context.PhoneCharacteristics.FindAsync(id);
            _context.PhoneCharacteristics.Remove(phoneCharacteristic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhoneCharacteristicExists(int id)
        {
            return _context.PhoneCharacteristics.Any(e => e.Id == id);
        }
    }
}
