using System;
using System.Collections.Generic;

namespace ConsentFormApi.Models
{
    public partial class Customers
    {
        public Customers()
        {
            CustomersAgrees = new HashSet<CustomersAgrees>();
        }

        public int Id { get; set; }
        public string Hn { get; set; }
        public string FirstnameTh { get; set; }
        public string MiddlenameTh { get; set; }
        public string LastnameTh { get; set; }
        public string FirstnameEn { get; set; }
        public string MiddlenameEn { get; set; }
        public string LastnameEn { get; set; }
        public string TitleTh { get; set; }
        public string TitleEn { get; set; }
        public long? PapmiRowId { get; set; }
        public DateTime? Dob { get; set; }
        public string Sex { get; set; }
        public string Nationality { get; set; }
        public string LanguageCode { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string OfficePhone { get; set; }
        public string AddressNo { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Zipcode { get; set; }
        public byte? Vip { get; set; }
        public string VipDesc { get; set; }
        public byte? Membership { get; set; }
        public DateTime? MembershipAt { get; set; }
        public string Photo { get; set; }
        public int? AgeYear { get; set; }
        public int? AgeMonth { get; set; }
        public int? AgeDay { get; set; }
        public string IdCard { get; set; }
        public string PassportNumber { get; set; }
        public string SecretaryNumber { get; set; }

        public ICollection<CustomersAgrees> CustomersAgrees { get; set; }
    }
}
