using System;

namespace Proj_0.Models
{
    public class Guest 
    {
        private int id {get; set;}
        private string first_name {get; set;}
        private string last_name {get;set;}
        private string room {get;set;}
        private decimal credit {get; set;}
        private string confirmation_number {get; set;}

        private int durationofstay {get; set;}

        private byte checked_in {get; set;}
        private int room_id {get; set;}
        private int location_id {get; set;}

        private DateTime CreatedAt {get;set;}
        private DateTime UpdatedAt {get; set;}
        public Guest(int id, string first_name, string last_name, string room, int location_id, int room_id, DateTime CreatedAt, DateTime UpdatedAt)
        {
            this.id = id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.room = room;
            this.location_id = location_id;
            this.room_id = room_id;
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

        public string getRoom()
        {
            return this.room;
        }

        public string setRoom(string room)
        {
            return this.room = room;
        }

        public decimal getCredit()
        {
            return this.credit;
        }

        public decimal setCredit(decimal credit)
        {
            return this.credit = credit;
        }

        public string getConfirmNum()
        {
            return this.confirmation_number;
        }

        public string setConfirmNum(string confirmation_number)
        {
            return this.confirmation_number = confirmation_number;
        }

        public int getDurationOfStay()
        {
            return this.durationofstay;
        }

        public int setDurationOfStay(int durationofstay)
        {
            return this.durationofstay = durationofstay;
        }

        public bool getCheckedIn()
        {
            return (this.checked_in == 0) ? false : true;
        }

        public byte SetCheckedIn(byte checked_in)
        {
            return (checked_in == 0) ? this.checked_in = 0: this.checked_in = 1;
        }

        public int getRoom_Id()
        {
            return this.room_id;
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