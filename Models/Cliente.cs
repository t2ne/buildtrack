using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BuildTrackMVC.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres.")]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "O NIF é obrigatório.")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "O NIF deve ter exatamente 9 dígitos.")]
        public string NIF { get; set; } = null!;

        [Required(ErrorMessage = "A morada é obrigatória.")]
        public string Morada { get; set; } = null!;

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Introduza um email válido.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "O telefone deve ter exatamente 9 dígitos.")]
        public string Telefone { get; set; } = null!;

    }
}
