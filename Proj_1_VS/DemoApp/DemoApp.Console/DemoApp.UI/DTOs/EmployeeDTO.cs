namespace DemoApp.UI.DTOs
{
    public class EmployeeDTO
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int location_id { get; set; }

        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
