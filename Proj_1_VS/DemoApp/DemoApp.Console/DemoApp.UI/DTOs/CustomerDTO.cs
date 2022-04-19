namespace DemoApp.UI.DTOs
{
    public class CustomerDTO
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string? session_total { get; set; }
        public string? order_content { get; set; }
        public int location_id { get; set; }

        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }

        public CustomerDTO(string first_name, string last_name, string session_total, string order_content, int location_id)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.location_id = location_id;
            this.session_total = session_total; 
            this.order_content = order_content;
        }
    }
}
