namespace DemoApp.BusinessLogic
{
    public class Customer
    {

        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int? session_total { get; set; }
        public string? order_content { get; set; }
        public int location_id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Customer(int id, string first_name, string last_name, int? session_total, string order_content, DateTime created_at, DateTime updated_at, int location_id)
        {
            this.id = id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.session_total = session_total;
            this.order_content = order_content;
            this.CreatedAt = created_at;
            this.UpdatedAt = updated_at;
            this.location_id = location_id;
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

        public int? getSessionTotal()
        {
            return this.session_total;
        }

        public int? setSessionTotal(int? session_total)
        {
            return this.session_total = session_total;
        }

        public string? getOrderContent()
        {
            return this.order_content;
        }

        public string? setOrderContent(string? order_content)
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