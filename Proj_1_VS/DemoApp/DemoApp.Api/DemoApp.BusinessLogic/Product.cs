using System.Text.Json.Serialization;

namespace DemoApp.BusinessLogic
{
    public class Product
    {

        public int id { get; set; }
        public string name { get; set; }
        public int amount { get; set; }
        public string price { get; set; }
        public string description { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int location_id { get; set; }
        [JsonConstructor]
        public Product(int id, string name, int amount, string price, string description, DateTime CreatedAt, DateTime UpdatedAt, int location_id)
        {
            this.id = id;
            this.name = name;
            this.amount = amount;
            this.price = price;
            this.description = description;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
            this.location_id = location_id;
        }

        public string getName()
        {
            return this.name;
        }

        public string setName(string name)
        {
            return this.name = name;
        }

        public int getAmount()
        {
            return this.amount;
        }

        public int setAmount(int amount)
        {
            return this.amount = amount;
        }

        public string getPrice()
        {
            return this.price;
        }

        public string setPrice(string price)
        {
            return this.price = price;
        }

        public string getDescription()
        {
            return this.description;
        }

        public string setDescription(string description)
        {
            return this.description = description;
        }

        public int getId()
        {
            return this.id;
        }

        public int getLocation_Id()
        {
            return this.location_id;
        }

        public DateTime GetCreationAt()
        {
            return this.CreatedAt;
        }

        public DateTime GetUpdatedAt()
        {
            return this.UpdatedAt;
        }

        public DateTime SetUpdatedAt()
        {
            return this.UpdatedAt = System.DateTime.UtcNow;
        }

    }
}