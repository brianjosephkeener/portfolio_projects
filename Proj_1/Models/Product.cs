using System;

namespace Proj_1.Models
{
    public class Product
    {
        private int id {get; set;}
        private string name {get; set;}
        private int amount {get;set;}
        private decimal price {get;set;}
        private string description {get;set;}
        private int location_id {get; set;}

        private DateTime CreatedAt {get;set;}
        private DateTime UpdatedAt {get; set;}
        public Product(int id, string name, int amount, decimal price, string description, int location_id, DateTime CreatedAt, DateTime UpdatedAt)
        {
            this.id = id;
            this.name = name;
            this.amount = amount;
            this.price = price;
            this.description = description;
            this.location_id = location_id;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
        }

        public int getId()
        {
            return this.id;
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

        public decimal getPrice()
        {
            return this.price;
        }
        public decimal setPrice(decimal price)
        {
            return this.price = price;
        }
        public string? getDescription()
        {
            if(this.description == null)
            {
                return "No description available";
            }
            return this.description;
        }
        public string setDescription(string description)
        {
            return this.description = description;
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