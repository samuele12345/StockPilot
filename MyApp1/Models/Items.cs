using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp1.Models
{
    // Forza EF Core a usare il nome tabella "Item" nel database.
    [Table("Item")]
    public class Items
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        
        public double Price { get; set; }

        public int? IdSerial { get; set; }

        [ForeignKey("IdSerial")]
        public SerialNumber? SerNumber { get; set; }


        public int? CategoryId { get; set; }

        // non diventa una colonna, serve solo a entity framework per navigare verso l'entità collegata

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }
}
