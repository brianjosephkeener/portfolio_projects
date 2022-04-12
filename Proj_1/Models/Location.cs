using System;

namespace Proj_0.Models
{
    public class Location
    {
        private int id {get; set;}
        private string name {get; set;}
        private DateTime CreatedAt {get;set;}
        private DateTime UpdatedAt {get; set;}
        public Location(int id, string name, DateTime CreatedAt, DateTime UpdatedAt)
        {
            this.id = id;
            this.name = name;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
        }

        public string GetName()
        {
            return this.name;
        }

        public string SetName(string name)
        {
            return this.name = name;
        }

        public int GetId()
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