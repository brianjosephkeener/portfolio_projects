using System;

namespace Proj_1.Models
{
    public class Customer
    {
        private int id {get; set;}
        private string first_name {get; set;}
        private string last_name {get;set;}
        private int session_total {get;set;}
        private string order_content {get; set;}
        private int location_id {get; set;}

        private DateTime CreatedAt {get;set;}
        private DateTime UpdatedAt {get; set;}
        public Customer(int id, string first_name, string last_name, string room, int location_id, DateTime CreatedAt, DateTime UpdatedAt, string order_content, int session_total)
        {
            this.id = id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.session_total = session_total;
            this.order_content = order_content;
            this.location_id = location_id;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
        }

        public string getFirstName()
        {
            return this.first_name;
        }

        public string setFirstName(string first_name)
        {
            return this.first_name = first_name;
        }

        public string getLastName()
        {
            return this.last_name;
        }

        public string setLastName(string last_name)
        {
            return this.last_name = last_name;
        }

        public int getId()
        {
            return this.id;
        }

        public int getSessionTotal()
        {
            return this.session_total;
        }

        public int setSessionTotal(int session_total)
        {
            return this.session_total = session_total;
        }

        public string getOrderContent()
        {
            return this.order_content;
        }

        public string setOrderContent(string order_content)
        {
            return this.order_content;
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