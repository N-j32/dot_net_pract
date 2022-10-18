using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;


using Microsoft.Extensions.Logging;


namespace WebApplication2.Controllers
{
    public class TblStudentsController : Controller
    {
        //private readonly ILogger<TblStudentsController> _logger;
       // private readonly IToastNotification _toastNotification;
        private readonly db_testContext _context;
       // private object _toastNotification;

        //private readonly IToastNotification _toastNotification;

        public TblStudentsController( db_testContext context)
        {
            //_logger = logger;
          
            _context = context;
           // _toastNotification = toastNotification;

            //_toastNotification = toastNotification;
        }

        // GET: TblStudents
        public async Task<IActionResult> Index()
        {
              return View(await _context.TblStudents.ToListAsync());
        }

        // GET: TblStudents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblStudents == null)
            {
                return NotFound();
            }

            var tblStudent = await _context.TblStudents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblStudent == null)
            {
                return NotFound();
            }
            TempData["AlertMessage"] = "Product created successfully";
            return View(tblStudent);
        }

        // GET: TblStudents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblStudents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Fname,Email,Mobile,Description")] TblStudent tblStudent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblStudent);
                await _context.SaveChangesAsync();
                //toastNotification in green color - > SUCCESS
                TempData["AlertMessage"] = "Product created successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(tblStudent);
        }

        // GET: TblStudents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblStudents == null)
            {
                TempData["AlertMessage"] = "Product updated successfully";
                return NotFound();
            }

            var tblStudent = await _context.TblStudents.FindAsync(id);
            if (tblStudent == null)
            {
                return NotFound();
            }
            return View(tblStudent);
        }

        // POST: TblStudents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Fname,Email,Mobile,Description")] TblStudent tblStudent)
        {
            if (id != tblStudent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblStudent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblStudentExists(tblStudent.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["AlertMessage"] = "Product updated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(tblStudent);
        }

        // GET: TblStudents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblStudents == null)
            {
                return NotFound();
            }

            var tblStudent = await _context.TblStudents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblStudent == null)
            {
                return NotFound();
            }
            await _context.SaveChangesAsync();
            TempData["AlertMessage"] = "Product deleted successfully";
            return View(tblStudent);
        }

        // POST: TblStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblStudents == null)
            {
                return Problem("Entity set 'db_testContext.TblStudents'  is null.");
            }
            var tblStudent = await _context.TblStudents.FindAsync(id);
            if (tblStudent != null)
            {
                _context.TblStudents.Remove(tblStudent);
            }
            
            await _context.SaveChangesAsync();
           // _toastNotification.AddErrorToastMessage("Employee deleted successfully")
                TempData["AlertMessage"]="Product deleted successfully";
         
            return RedirectToAction(nameof(Index));
        }

        private bool TblStudentExists(int id)
        {
          return _context.TblStudents.Any(e => e.Id == id);
        }
    }
}
