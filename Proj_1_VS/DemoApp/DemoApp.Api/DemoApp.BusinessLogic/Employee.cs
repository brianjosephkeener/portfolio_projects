namespace DemoApp.BusinessLogic
{
    public class Employee
    {

        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int location_id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Employee(int id, string username, string password, int location_id, DateTime created_at, DateTime updated_at)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.location_id = location_id;
            this.CreatedAt = created_at;
            this.UpdatedAt = updated_at;
        }

        public string getUsername()
        {
            return this.username;
        }

        public string setUsername(string username)
        {
            return this.username = username;
        }

        public string getPassword()
        {
            return this.password;
        }

        public string setPassword(string password)
        {
            return this.password = password;
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