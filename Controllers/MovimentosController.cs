using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BuildTrackMVC.Data;
using BuildTrackMVC.Models;

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
                    .ThenInclude(o => o.Cliente)
                .Include(m => m.Material)
                .ToListAsync();
            return View(movimentos);
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
                    // Get the material to update stock
                    var material = await _context.Materiais.FindAsync(movimento.MaterialId);
                    if (material == null)
                    {
                        return Json(new { success = false, message = "Material não encontrado." });
                    }

                    // Calculate new stock based on operation
                    int newStock = material.StockDisponivel;
                    if (movimento.Operacao == "Saída")
                    {
                        newStock -= movimento.Quantidade;

                        // Check if there's enough stock
                        if (newStock < 0)
                        {
                            return Json(new
                            {
                                success = false,
                                message = $"Stock insuficiente! Disponível: {material.StockDisponivel}, Necessário: {movimento.Quantidade}"
                            });
                        }
                    }
                    else // Entrada
                    {
                        newStock += movimento.Quantidade;
                    }

                    // Update stock and save movimento
                    material.StockDisponivel = newStock;
                    movimento.DataHora = DateTime.UtcNow;

                    _context.Add(movimento);
                    await _context.SaveChangesAsync();

                    return Json(new { success = true });
                }

                return Json(new { success = false, message = "Dados inválidos." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Erro: {ex.Message}" });
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
