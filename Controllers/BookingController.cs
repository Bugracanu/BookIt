using System.Security.Claims;
using BookIt.Data;
using BookIt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace BookIt.Controllers;

public class BookingController : Controller
{
    private readonly ApplicationDbContext _context;
    public BookingController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Create(int serviceId)
    {
        var service = await _context.Services.FindAsync(serviceId);
        if (service == null) return NotFound();
        ViewBag.ServiceName = service.Name;
        ViewBag.ServiceId = service.Id;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Booking booking)
    {
        //Giriş yapan kullanıcının Id'sini alıyoruz burada
        var userIdStr = User.FindFirstValue("UserId");
        if (userIdStr != null)
        {
            booking.UserId = int.Parse(userIdStr);
            booking.Status = "Pending"; //başlangıç durumu: Beklemede

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
        return View(booking);
    }


}