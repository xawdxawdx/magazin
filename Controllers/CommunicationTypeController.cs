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
    public class CommunicationTypeController : Controller
    {
        private readonly DataContext _context;

        public CommunicationTypeController(DataContext context)
        {
            _context = context;
        }

        // GET: CommunicationType
        public async Task<IActionResult> Index()
        {
            return View(await _context.CommunicationTypes.ToListAsync());
        }

        // GET: CommunicationType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var communicationType = await _context.CommunicationTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (communicationType == null)
            {
                return NotFound();
            }

            return View(communicationType);
        }

        // GET: CommunicationType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CommunicationType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CommunicationName,CommunicationSubType")] CommunicationType communicationType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(communicationType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(communicationType);
        }

        // GET: CommunicationType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var communicationType = await _context.CommunicationTypes.FindAsync(id);
            if (communicationType == null)
            {
                return NotFound();
            }
            return View(communicationType);
        }

        // POST: CommunicationType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CommunicationName,CommunicationSubType")] CommunicationType communicationType)
        {
            if (id != communicationType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(communicationType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommunicationTypeExists(communicationType.Id))
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
            return View(communicationType);
        }

        // GET: CommunicationType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var communicationType = await _context.CommunicationTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (communicationType == null)
            {
                return NotFound();
            }

            return View(communicationType);
        }

        // POST: CommunicationType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var communicationType = await _context.CommunicationTypes.FindAsync(id);
            _context.CommunicationTypes.Remove(communicationType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommunicationTypeExists(int id)
        {
            return _context.CommunicationTypes.Any(e => e.Id == id);
        }
    }
}
