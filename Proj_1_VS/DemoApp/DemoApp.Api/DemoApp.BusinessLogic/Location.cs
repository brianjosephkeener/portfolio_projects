namespace DemoApp.BusinessLogic
{
    public class Location
    {

        public int id { get; set; }
        public string name { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Location(int id, string name, DateTime created_at, DateTime updated_at)
        {
            this.id = id;
            this.name = name;
            this.CreatedAt = created_at;
            this.UpdatedAt = updated_at;
        }

        public string getName()
        {
            return this.name;
        }

        public string setName(string name)
        {
            return this.name = name;
        }

        public int getId()
        {
            return this.id;
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