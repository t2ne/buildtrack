using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BuildTrackMVC.Data;
using BuildTrackMVC.Models;

namespace BuildTrackMVC.Controllers
{
    public class ObrasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ObrasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var obras = await _context.Obras.Include(o => o.Cliente).ToListAsync();
            return View(obras);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var obra = await _context.Obras.Include(o => o.Cliente).FirstOrDefaultAsync(o => o.Id == id);
            if (obra == null) return NotFound();

            // Pass materials to the view for the partials
            ViewData["Materiais"] = await _context.Materiais.ToListAsync();

            return View(obra);
        }

        public IActionResult Create()
        {
            ViewData["Clientes"] = _context.Clientes.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Descricao,ClienteId,Morada,Latitude,Longitude,Ativa")] Obra obra)
        {
            // Remove validation errors for navigation property
            ModelState.Remove("Cliente");

            if (ModelState.IsValid)
            {
                _context.Add(obra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Clientes"] = _context.Clientes.ToList();
            return View(obra);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var obra = await _context.Obras.FindAsync(id);
            if (obra == null) return NotFound();
            ViewData["Clientes"] = _context.Clientes.ToList();
            return View(obra);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,ClienteId,Morada,Latitude,Longitude,Ativa")] Obra obra)
        {
            if (id != obra.Id) return NotFound();

            // Remove validation errors for navigation property
            ModelState.Remove("Cliente");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObraExists(obra.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Clientes"] = _context.Clientes.ToList();
            return View(obra);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var obra = await _context.Obras.Include(o => o.Cliente).FirstOrDefaultAsync(o => o.Id == id);
            if (obra == null) return NotFound();
            return View(obra);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obra = await _context.Obras.FindAsync(id);
            if (obra != null)
            {
                _context.Obras.Remove(obra);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ObraExists(int id) => _context.Obras.Any(o => o.Id == id);
    }
}
