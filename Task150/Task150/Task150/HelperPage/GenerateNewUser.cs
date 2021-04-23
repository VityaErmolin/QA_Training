using System;
using Task150.Model;

namespace Task150.HelperPage
{
    public static class GenerateNewUser
    {
        public static User GenerateUser(this User user, string email = null)
        {
            var guidString = Guid.NewGuid().ToString();

            user.IsMan = true;
            user.FirstName = "FirstName";
            user.LastName = "FirstName";
            user.Email = string.IsNullOrEmpty(email) ? guidString + "@mail.com" : email;
            user.Password = "123456789";
            user.BirthDate = new DateTime(1998,7,9);
            user.IsSignUpForNewsletter = true;
            user.IsReceiveSpecialOffers = false;
            user.Company = "Company";
            user.StreetAddress = "Address1";
            user.ApartmentAddress = "Address2";
            user.City = "City";
            user.State = "Florida";
            user.PostalCode = "00000";
            user.Country = "United States";
            user.AdditionalInformation = "AdditionalInformation";
            user.HomePhone = "123456789012";
            user.MobilePhone = "123456789013";
            user.Alias = "Alias";
            return user;
        }
    }
}