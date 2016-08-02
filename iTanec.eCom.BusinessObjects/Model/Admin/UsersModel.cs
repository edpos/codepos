using System;

namespace iTanec.eCom.BusinessObjects.Model.Admin
{
    public class UsersModel
    {
        public int UserId { get; set; }
        public string UserCode { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string BranchId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? IsLoggedIn { get; set; }
        public bool? IsLocked { get; set; }
        public Int16? LoginAttempts { get; set; }
        public DateTime? LockedTime { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
    }
}