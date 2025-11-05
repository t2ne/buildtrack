using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BuildTrackMVC.Data;
using BuildTrackMVC.Models;

namespace BuildTrackMVC.Controllers
{
    public class RegistosMaoObraController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistosMaoObraController(ApplicationDbContext context)
        {
            _context = context;
        }

        // API endpoint to add registo via AJAX
        [HttpPost]
        public async Task<IActionResult> AddRegisto([FromBody] RegistoMaoObra registo)
        {
            try
            {
                ModelState.Remove("Obra");

                if (ModelState.IsValid)
                {
                    // Set DataRegisto to UTC explicitly
                    registo.DataRegisto = DateTime.UtcNow;

                    _context.Add(registo);
                    await _context.SaveChangesAsync();

                    return Json(new { success = true });
                }

                // Return validation errors
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return Json(new { success = false, message = string.Join(", ", errors) });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Erro: {ex.Message}" });
            }
        }

        // API endpoint to get registos by obra
        [HttpGet]
        public async Task<IActionResult> GetRegistosByObra(int obraId)
        {
            var registos = await _context.RegistosMaoObra
                .Where(r => r.ObraId == obraId)
                .OrderByDescending(r => r.DataRegisto)
                .Select(r => new
                {
                    r.Id,
                    r.NomeTrabalhador,
                    r.HorasTrabalhadas,
                    r.ValorHora,
                    Total = r.HorasTrabalhadas * (double)r.ValorHora,
                    r.DescricaoTrabalho,
                    DataRegisto = r.DataRegisto.ToString("dd/MM/yyyy")
                })
                .ToListAsync();

            return Json(registos);
        }
    }
}
