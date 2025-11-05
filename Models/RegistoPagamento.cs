using System;
using System.ComponentModel.DataAnnotations;

namespace BuildTrackMVC.Models
{
    public class RegistoPagamento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A obra é obrigatória.")]
        public int ObraId { get; set; }
        public Obra Obra { get; set; } = null!;

        [Required(ErrorMessage = "O tipo de pagamento é obrigatório.")]
        [StringLength(50, ErrorMessage = "O tipo não pode ter mais de 50 caracteres.")]
        public string TipoPagamento { get; set; } = null!;

        [Required(ErrorMessage = "O valor é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser positivo.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "A data de pagamento é obrigatória.")]
        public DateTime DataPagamento { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "O método de pagamento é obrigatório.")]
        [StringLength(50, ErrorMessage = "O método não pode ter mais de 50 caracteres.")]
        public string MetodoPagamento { get; set; } = null!;

        [StringLength(500, ErrorMessage = "A descrição não pode ter mais de 500 caracteres.")]
        public string? Descricao { get; set; }
    }
}
