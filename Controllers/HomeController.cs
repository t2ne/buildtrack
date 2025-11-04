using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BuildTrackMVC.Models;
using BuildTrackMVC.Data;
using Microsoft.EntityFrameworkCore;

namespace BuildTrackMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    // Home agora é dashboard
    public async Task<IActionResult> Index()
    {
        ViewBag.ClientesCount = await _context.Clientes.CountAsync();
        ViewBag.MateriaisCount = await _context.Materiais.CountAsync();
        ViewBag.ObrasAtivasCount = await _context.Obras.CountAsync(o => o.Ativa);
        ViewBag.MovimentosCount = await _context.Movimentos.CountAsync();
        ViewBag.RegistosMaoObraCount = await _context.RegistosMaoObra.CountAsync();
        ViewBag.RegistosPagamentosCount = await _context.RegistosPagamentos.CountAsync();

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
