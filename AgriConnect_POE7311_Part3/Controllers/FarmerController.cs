using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgriConnect_POE7311_Part3.Data;
using AgriConnect_POE7311_Part3.Models;

namespace AgriConnect_POE7311_Part3.Controllers
{
    public class FarmerController : Controller
    {
        private readonly MyDbContext _context;

        public FarmerController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Farmer
        public async Task<IActionResult> Index()
        {
            return View(await _context.Farmers.ToListAsync());
        }

        // GET: Farmer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmer = await _context.Farmers
                .FirstOrDefaultAsync(m => m.FarmerId == id);
            if (farmer == null)
            {
                return NotFound();
            }

            return View(farmer);
        }

        // GET: Farmer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Farmer/Create (Register logic)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FarmerId,FullName,Email,Username,PasswordHash,Address,ContactNumber,ProfileImagePath,CreatedAt")] Farmer farmer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    farmer.CreatedAt = DateTime.Now;
                    _context.Add(farmer);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while registering the farmer: " + ex.Message);
                }
            }
            return View(farmer);
        }

        // GET: Farmer/FarmerDashboard
        public async Task<IActionResult> FarmerDashboard(int id)
        {//dotnet-bot (2025). DbContext.FindAsync Method (Microsoft.EntityFrameworkCore). [online] Microsoft.com. Available at: https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext.findasync?view=efcore-9.0 [Accessed 20 Jun. 2025].‌
            var farmer = await _context.Farmers.FirstOrDefaultAsync(f => f.FarmerId == id);
            if (farmer == null)
            {
                return NotFound();
            }

            return View(farmer);
        }


        // GET: Farmer/Login
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password)
        {/*How (2018). Stack Overflow. [online] Stack Overflow. Available at:  https://stackoverflow.com/questions/50048487/how-to-understand-string-isnullorwhitespaces-syntax [Accessed 20 Jun. 2025].*/‌
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {// // Validate input: both username and password must be provided
                ModelState.AddModelError("", "Username and password are required.");
                return View();
            }

            var farmer = await _context.Farmers
                .FirstOrDefaultAsync(f => f.Username == username && f.PasswordHash == password);

            if (farmer != null)
            {
                TempData["WelcomeMessage"] = $"Welcome back, {farmer.FullName}!";
                return RedirectToAction("EmployeeDashboard", new { id = farmer.FarmerId });
            }

            ModelState.AddModelError("", "Invalid username or password.");
            return View();
        }


        // GET: Farmer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmer = await _context.Farmers.FindAsync(id);
            if (farmer == null)
            {
                return NotFound();
            }
            return View(farmer);
        }

        // POST: Farmer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FarmerId,FullName,Email,Username,PasswordHash,Address,ContactNumber,ProfileImagePath,CreatedAt")] Farmer farmer)
        {
            if (id != farmer.FarmerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(farmer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FarmerExists(farmer.FarmerId))
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
            return View(farmer);
        }

        // GET: Farmer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmer = await _context.Farmers
                .FirstOrDefaultAsync(m => m.FarmerId == id);
            if (farmer == null)
            {
                return NotFound();
            }

            return View(farmer);
        }

        // POST: Farmer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var farmer = await _context.Farmers.FindAsync(id);
            if (farmer != null)
            {
                _context.Farmers.Remove(farmer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FarmerExists(int id)
        {
            return _context.Farmers.Any(e => e.FarmerId == id);
        }
    }
}
