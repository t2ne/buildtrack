using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BuildTrackMVC.Data;
using BuildTrackMVC.Models;
using System.Threading.Tasks;

namespace BuildTrackMVC.Controllers
{
    public class MovimentosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovimentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Movimentos
        public async Task<IActionResult> Index()
        {
            var movimentos = await _context.Movimentos
                .Include(m => m.Obra)
                .Include(m => m.Material)
                .ToListAsync();
            return View(movimentos);
        }

        // GET: Movimentos/Create
        public IActionResult Create()
        {
            ViewData["Obras"] = _context.Obras.ToList();
            ViewData["Materiais"] = _context.Materiais.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ObraId,MaterialId,Operacao,Quantidade")] Movimento movimento)
        {
            if (ModelState.IsValid)
            {
                // DataHora já definido por default no model
                _context.Add(movimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Obras"] = _context.Obras.ToList();
            ViewData["Materiais"] = _context.Materiais.ToList();
            return View(movimento);
        }

        // API endpoint to add movimento via AJAX
        [HttpPost]
        public async Task<IActionResult> AddMovimento([FromBody] Movimento movimento)
        {
            try
            {
                // Remove navigation properties from validation
                ModelState.Remove("Obra");
                ModelState.Remove("Material");

                if (ModelState.IsValid)
                {
                    movimento.DataHora = DateTime.UtcNow;
                    _context.Add(movimento);
                    await _context.SaveChangesAsync();

                    return Json(new { success = true });
                }

                return Json(new { success = false });
            }
            catch (Exception ex)
            {
                return Json(new { success = false });
            }
        }

        // API endpoint to get movimentos by obra
        [HttpGet]
        public async Task<IActionResult> GetMovimentosByObra(int obraId)
        {
            var movimentos = await _context.Movimentos
                .Include(m => m.Material)
                .Where(m => m.ObraId == obraId)
                .OrderByDescending(m => m.DataHora)
                .Select(m => new
                {
                    m.Id,
                    m.MaterialId,
                    MaterialNome = m.Material.Nome,
                    m.Quantidade,
                    m.Operacao,
                    DataHora = m.DataHora.ToString("dd/MM/yyyy HH:mm")
                })
                .ToListAsync();

            return Json(movimentos);
        }
    }
}
