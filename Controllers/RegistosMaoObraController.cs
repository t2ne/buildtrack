using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BuildTrackMVC.Data;
using BuildTrackMVC.Models;
using System.Threading.Tasks;

namespace BuildTrackMVC.Controllers
{
    public class RegistosMaoObraController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistosMaoObraController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RegistoMaoObra
        public async Task<IActionResult> Index()
        {
            var registos = await _context.RegistosMaoObra
                .Include(r => r.Obra)
                .ToListAsync();
            return View(registos);
        }

        // GET: RegistoMaoObra/Create
        public IActionResult Create()
        {
            ViewData["Obras"] = _context.Obras.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ObraId,NomeTrabalhador,HorasTrabalhadas,ValorHora,DescricaoTrabalho,DataRegisto")] RegistoMaoObra registo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Obras"] = _context.Obras.ToList();
            return View(registo);
        }
    }
}
