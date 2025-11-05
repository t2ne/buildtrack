using System;
using System.ComponentModel.DataAnnotations;

namespace BuildTrackMVC.Models
{
    public class RegistoMaoObra
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A obra é obrigatória.")]
        public int ObraId { get; set; }
        public Obra Obra { get; set; } = null!;

        [Required(ErrorMessage = "O nome do trabalhador é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres.")]
        public string NomeTrabalhador { get; set; } = null!;

        [Required(ErrorMessage = "As horas trabalhadas são obrigatórias.")]
        [Range(0.5, 24, ErrorMessage = "As horas devem estar entre 0.5 e 24.")]
        public double HorasTrabalhadas { get; set; }

        [Required(ErrorMessage = "O valor por hora é obrigatório.")]
        [Range(0.01, 1000, ErrorMessage = "O valor por hora deve ser positivo.")]
        public decimal ValorHora { get; set; }

        [StringLength(500, ErrorMessage = "A descrição não pode ter mais de 500 caracteres.")]
        public string? DescricaoTrabalho { get; set; }

        [Required(ErrorMessage = "A data de registo é obrigatória.")]
        public DateTime DataRegisto { get; set; } = DateTime.Now;
    }
}
