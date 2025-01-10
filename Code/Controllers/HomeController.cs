using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Code.Models;
using Microsoft.EntityFrameworkCore;

namespace Code.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context, ILogger<HomeController> logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task<IActionResult> Index()
    {
        var pdfs = await _context.Pdfs
        .Include(p => p.User)
        .Include(p => p.PdfAcademicPrograms)
            .ThenInclude(pap => pap.AcademicProgram)
        .ToListAsync(); // Get a list of PDFs

        ViewBag.Username = HttpContext.Session.GetString("Username") ?? "Guest";
        return View(pdfs);
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
