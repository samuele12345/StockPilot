

namespace MyApp1.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;


        // entità di giunzione, concettualmente corrisponde al join
        public List<ItemsClient>? ItemsClient { get; set; }
    }
}
