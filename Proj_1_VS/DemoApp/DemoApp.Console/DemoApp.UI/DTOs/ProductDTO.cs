namespace DemoApp.UI.DTOs
{
    public class ProductDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public int amount { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public int location_id { get; set; }

        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
