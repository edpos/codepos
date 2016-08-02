using System;

namespace iTanec.eCom.BusinessObjects.Model.Admin
{
    public class UserGeneralInfoModel
    {
        public int UserGeneralId { get; set; }
        public int UserId { get; set; }
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
