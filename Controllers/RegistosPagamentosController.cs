using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BuildTrackMVC.Data;
using BuildTrackMVC.Models;

namespace BuildTrackMVC.Controllers
{
    public class RegistosPagamentosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistosPagamentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // API endpoint to add pagamento via AJAX
        [HttpPost]
        public async Task<IActionResult> AddPagamento([FromBody] RegistoPagamento pagamento)
        {
            try
            {
                ModelState.Remove("Obra");

                if (ModelState.IsValid)
                {
                    _context.Add(pagamento);
                    await _context.SaveChangesAsync();

                    return Json(new { success = true });
                }

                return Json(new { success = false });
            }
            catch
            {
                return Json(new { success = false });
            }
        }

        // API endpoint to get pagamentos by obra
        [HttpGet]
        public async Task<IActionResult> GetPagamentosByObra(int obraId)
        {
            var pagamentos = await _context.RegistosPagamentos
                .Where(p => p.ObraId == obraId)
                .OrderByDescending(p => p.DataPagamento)
                .Select(p => new
                {
                    p.Id,
                    p.TipoPagamento,
                    p.Valor,
                    p.MetodoPagamento,
                    p.Descricao,
                    DataPagamento = p.DataPagamento.ToString("dd/MM/yyyy")
                })
                .ToListAsync();

            return Json(new
            {
                pagamentos = pagamentos,
                total = pagamentos.Sum(p => p.Valor)
            });
        }
    }
}
