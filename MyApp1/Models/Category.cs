namespace MyApp1.Models
{
    public class Category
    {
        public int id { get; set; }
        public string Name { get; set; } = null!;
        public List<Items>? Items { get; set; } 

    }
}
