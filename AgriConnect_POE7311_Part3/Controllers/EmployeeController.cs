using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgriConnect_POE7311_Part3.Data;
using AgriConnect_POE7311_Part3.Models;

namespace AgriConnect_POE7311_Part3.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly MyDbContext _context;

        public EmployeeController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
            if (employee == null) return NotFound();

            return View(employee);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,FullName,Email,Username,PasswordHash,Department,CreatedAt")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.CreatedAt = DateTime.Now;
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return NotFound();

            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,FullName,Email,Username,PasswordHash,Department,CreatedAt")] Employee employee)
        {
            if (id != employee.EmployeeId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
            if (employee == null) return NotFound();

            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }

        // GET: Employee/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Employee/Login
        //How (2018). Stack Overflow. [online] Stack Overflow. Available at: https://stackoverflow.com/questions/50048487/how-to-understand-string-isnullorwhitespaces-syntax [Accessed 20 Jun. 2025].


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {// // Validate input: both username and password must be provided
                ModelState.AddModelError("", "Username and password are required.");
                return View();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.Username == username && e.PasswordHash == password);

            if (employee != null)
            {
                TempData["WelcomeMessage"] = $"Welcome, {employee.FullName}!";
                return RedirectToAction("EmployeeDashboard", new { id = employee.EmployeeId });
            }

            ModelState.AddModelError("", "Invalid username or password.");
            return View();
        }

        // GET: Employee/EmployeeDashboard/5
        public async Task<IActionResult> EmployeeDashboard(int id)
        {//dotnet-bot (2025). DbContext.FindAsync Method (Microsoft.EntityFrameworkCore). [online] Microsoft.com. Available at: https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext.findasync?view=efcore-9.0 [Accessed 20 Jun. 2025].‌
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return NotFound();

            return View(employee);
        }
    }
}
