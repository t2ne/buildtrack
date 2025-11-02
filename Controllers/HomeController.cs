using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BuildTrackMVC.Models;

namespace BuildTrackMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // Home agora é dashboard
    public IActionResult Index()
    {
        return View();
    }

    // Privacy renomeado para Manual
    public IActionResult Manual()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
