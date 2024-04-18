using System.ComponentModel.DataAnnotations.Schema;

namespace Ferramenta_correzione.Models
{

    [Table("Prodotto")]
    public class Prodotto
    {
        public int ProdottoId { get; set; }

        public string? Codice { get; set; }

        public string Nome { get; set; } = null!;

        public string Categoria { get; set; } = null!;

        public string? Descrizione { get; set; }

        public decimal Prezzo { get; set; }

        public int? Quantita { get; set; }

        public DateTime? DataCreazione { get; set; }
    }
}
