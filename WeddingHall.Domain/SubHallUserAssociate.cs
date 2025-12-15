using System;

namespace WeddingHall.Domain
{
    public class SubHallUserAssociate : BaseDomainClass
    {
        public Guid GUID { get; set; }   // Primary Key

        public Guid UserId { get; set; }      // FK → Users.GUID
        public Guid SubHall_Id { get; set; }  // FK → SubHallDetail.GUID

        // Navigation Properties
        //They are used to move (navigate) from one table to another related table in C# code.
        public Users? UserManager { get; set; } 
        public SubHallDetail? SubHallDetail { get; set; }
    }
}
