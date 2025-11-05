using System.ComponentModel.DataAnnotations;

namespace BuildTrackMVC.Models
{
    public class Material
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres.")]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [StringLength(500, ErrorMessage = "A descrição não pode ter mais de 500 caracteres.")]
        public string Descricao { get; set; } = null!;

        [Required(ErrorMessage = "O stock disponível é obrigatório.")]
        [Range(0, int.MaxValue, ErrorMessage = "O stock não pode ser negativo.")]
        public int StockDisponivel { get; set; }
    }
}
