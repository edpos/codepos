using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTanec.eCom.BusinessObjects.Model.Admin
{
    public class UserListModel
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

        public int UserGeneralId { get; set; }
        public int? PrefixId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? GenderId { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int? CountryId { get; set; }
        public int? StateProvinceId { get; set; }
        public string ZippostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string EmergencyContactPerson { get; set; }
        public string EmergencyContactNumber { get; set; }
        public string UserPhoto { get; set; }
    }
}
