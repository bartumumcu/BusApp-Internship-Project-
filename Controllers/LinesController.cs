using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusApp.Data;
using BusApp.Models;
using BusApp.Models.ViewModels;
using System.Xml;

namespace BusApp.Controllers
{
    public class LinesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lines
        public async Task<IActionResult> Index()
        {
            return _context.Line != null ?
                        View(await _context.Line.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Line'  is null.");

        }

        // GET: Lines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Line == null)
            {
                return NotFound();
            }

            var line = await _context.Line
                .FirstOrDefaultAsync(m => m.Id == id);
            if (line == null)
            {
                return NotFound();
            }

            return View(line);
        }

        // GET: Lines/Create
         
        public IActionResult Create()
        {
            var viewmodel = new LineCreateViewModel()
            {
                Line = new Line(),
                Buses = _context.Bus.ToList()
                };
            return View(viewmodel);
        }

        // POST: Lines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Line line)
        {
            if (ModelState.IsValid)
            {
                _context.Add(line);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //var viewModel = new LineCreateViewModel()
            //{
            //    Line = new Line(),
            //    Buses = _context.Bus.ToList()
            //};

            return View();
        }


        // GET: Lines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Line == null)
            {
                return NotFound();
            }

            var line = await _context.Line.FindAsync(id);
            if (line == null)
            {
                return NotFound();
            }
            return View(line);
        }

        // POST: Lines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,length")] Line line)
        {
            if (id != line.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(line);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LineExists(line.Id))
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
            return View(line);
        }

        // GET: Lines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Line == null)
            {
                return NotFound();
            }

            var line = await _context.Line
                .FirstOrDefaultAsync(m => m.Id == id);
            if (line == null)
            {
                return NotFound();
            }

            return View(line);
        }

        // POST: Lines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Line == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Line'  is null.");
            }
            var line = await _context.Line.FindAsync(id);
            if (line != null)
            {
                _context.Line.Remove(line);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        //AddBusToLine
        public IActionResult AddBusToLine()
        {
            var viewModel = new AddBusToLineViewModel
            {
                Lines = _context.Line.ToList(),
                Buses = _context.Bus.ToList()
            };
            return View(viewModel);
        }

        //AddbusToLine Post
        [HttpPost]
        public IActionResult AddBusToLine(AddBusToLineViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var line = _context.Line.Include(l => l.busses).FirstOrDefault(l => l.Id == viewModel.LineId);
                var bus = _context.Bus.Find(viewModel.BusId);
                if ((line != null && bus != null))
                {
                    line.busses.Add(bus);
                    _context.SaveChanges();

                    return RedirectToAction("Index", "Line");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid line or bus selection.");
                }
            }
            viewModel.Lines = _context.Line.ToList();
            viewModel.Buses = _context.Bus.ToList();
            return View(viewModel);
        }




        private bool LineExists(int id)
        {
            return (_context.Line?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
