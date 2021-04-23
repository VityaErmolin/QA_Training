using System;

namespace Task150.Model
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsMan { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Company { get; set; }
        public string StreetAddress { get; set; }
        public string ApartmentAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string AdditionalInformation { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string Alias { get; set; }
        public bool IsSignUpForNewsletter { get; set; }
        public bool IsReceiveSpecialOffers { get; set; }
    }
    
}
