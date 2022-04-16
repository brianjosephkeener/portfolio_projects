namespace DemoApp.UI.DTOs
{
    public class CustomerDTO
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int? session_total { get; set; }
        public string? order_content { get; set; }
        public int location_id { get; set; }

        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
