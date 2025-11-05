using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildTrackMVC.Models
{
    public class Obra
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da obra é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres.")]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [StringLength(500, ErrorMessage = "A descrição não pode ter mais de 500 caracteres.")]
        public string Descricao { get; set; } = null!;

        [Required(ErrorMessage = "Deve selecionar um cliente.")]
        [Range(1, int.MaxValue, ErrorMessage = "Deve selecionar um cliente.")]
        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; } = null!;

        [Required(ErrorMessage = "A morada é obrigatória.")]
        [StringLength(200, ErrorMessage = "A morada não pode ter mais de 200 caracteres.")]
        public string Morada { get; set; } = null!;

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public bool Ativa { get; set; }
    }
}
