namespace DemoApp.UI.DTOs
{
    public class ProductDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public int amount { get; set; }
        public string price { get; set; }
        public string description { get; set; }
        public int location_id { get; set; }

        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }

        public ProductDTO(int id, string name, int amount, string price, string description, int location_id, DateTime createdAt, DateTime updatedAt)
        {
            this.id = id;
            this.name = name;
            this.amount = amount;
            this.price = price;
            this.description = description;
            this.location_id = location_id;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
        }
    }
}
