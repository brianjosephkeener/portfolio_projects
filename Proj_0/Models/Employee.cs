using System;

namespace Proj_0.Models
{
    public class Employee 
    {
        private int id {get; set;}
        private string username {get; set;}
        private string password {get;set;}
        private byte admin {get;set;}

        private int location_id {get; set;}

        private DateTime CreatedAt {get;set;}
        private DateTime UpdatedAt {get; set;}
        public Employee(int id, string username, string password, byte admin, int location_id, DateTime CreatedAt, DateTime UpdatedAt)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.admin = admin;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
        }

        public string GetUsername()
        {
            return this.username;
        }

        public string SetUsername(string username)
        {
            return this.username = username;
        }

        public string GetPassword()
        {
            return this.password;
        }

        public string SetPassword(string password)
        {
            return this.password = password;
        }

        public int GetId()
        {
            return this.id;
        }

        public bool GetAdmin()
        {
            return (this.admin == 0) ? false : true;
        }

        public byte SetAdmin(byte admin)
        {
            return (admin == 0) ? this.admin = 0: this.admin = 1;
        }

        public int Location_Id()
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

        public DateTime SetUpdatedAt(DateTime UpdatedAt)
        {
            return this.UpdatedAt = System.DateTime.UtcNow;
        }
        
    }
}