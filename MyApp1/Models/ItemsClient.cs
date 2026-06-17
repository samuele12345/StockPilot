using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp1.Models
{

    // sviluppa una connessione tra Items e Client
    public class ItemsClient
    {
        // vengono definite le foreign keys 
        public int ItemId { get; set; }

        [ForeignKey("ItemId")]
        public Items? Item { get; set; }

        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public Client? Client { get; set; }

    }
}
