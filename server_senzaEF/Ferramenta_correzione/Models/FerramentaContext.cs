using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Ferramenta_correzione.Models
{
    [Table("Prodotto")]
    public class FerramentaContext : DbContext
    {
        public FerramentaContext(DbContextOptions <FerramentaContext> options) :base(options) 
        { 

        }

        public DbSet<Prodotto> Prodotti { get; set; }
    }
}
