using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildTrackMVC.Models
{
    public class Movimento
    {
        public int Id { get; set; }

        [ForeignKey("Obra")]
        public int ObraId { get; set; }

        public Obra Obra { get; set; } = null!;

        [ForeignKey("Material")]
        public int MaterialId { get; set; }

        public Material Material { get; set; } = null!;

        public string Operacao { get; set; } = null!; // ADD / REMOVE

        public int Quantidade { get; set; }

        public DateTime DataHora { get; set; } = DateTime.UtcNow;
    }
}
