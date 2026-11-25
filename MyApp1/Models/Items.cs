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

        [ForeignKey("SerialId")]
        public int? SerialId { get; set; }
        
        public SerialNumber? SerNumber { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }

        public Category? Category { get; set; }

        [ForeignKey("UserId")]
        public string? UserId { get; set;}

        public UserM? User { get; set; }
    }
}
