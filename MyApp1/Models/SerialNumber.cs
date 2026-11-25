using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp1.Models
{
    // Forza EF Core a usare il nome tabella "SerialNumber" nel database.
    [Table("SerialNumber")]
    // esempio one to one 
    public class SerialNumber
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public Items? Item { set; get; } 
    }
}
