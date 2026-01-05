using BookIt.Data;
using BookIt.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookIt.Controllers;

[Authorize(Roles = "Admin")] //Sadece admin olanlar girebilir
public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;
    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Bookings()
    {
        var allBookings = await _context.Bookings
            .Include(b => b.Service)
            .Include(b => b.User)
            .OrderByDescending(b => b.StartTime)
            .ToListAsync();
        return View(allBookings);
    }

    public async Task<IActionResult> Services()
    {
        var services = await _context.Services.ToListAsync();
        return View(services);
    }

    [HttpGet]
    public IActionResult CreateService() => View();

    [HttpPost]
    public async Task<IActionResult> CreateService(Service service)
    {
        if (ModelState.IsValid)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
            return RedirectToAction("Services");
        }

        return View(service);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteService(int id)
    {
        var service = await _context.Services.FindAsync(id);
        if (service != null)
        {
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Services");
    }


    [HttpGet]
    public async Task<IActionResult> EditService(int id)
    {
        var service = await _context.Services.FindAsync(id);
        if (service == null) return NotFound();
        return View(service);
    }

    // Hizmet Düzenleme - Güncelle
    [HttpPost]
    public async Task<IActionResult> EditService(Service service)
    {
        if (ModelState.IsValid)
        {
            _context.Services.Update(service);
            await _context.SaveChangesAsync();
            return RedirectToAction("Services");
        }
        return View(service);
    }
}