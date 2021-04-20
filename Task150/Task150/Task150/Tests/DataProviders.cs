using System.Collections;
using Task150.HelperPage;
using Task150.Model;

namespace Task150.Tests
{
    internal class DataProviders
    {
        //Создать GUID который генерирует  почту
        public static IEnumerable ValidUsers
        {
            get
            {
                yield return new User().GenerateUser();
            }
        }

        public static IEnumerable ValidUsersWithCustomEmail
        {
            get
            {
                yield return new User().GenerateUser("test2_mail@gmail.com");
            }
        }
    }
}


//{
//    Email = "test11_mail@gmail.com",
//    Password = "123456789",
//    IsMan = true,
//    FirstName = "Test",
//    LastName = "Testing",
//    BirthDate = new BirthDate()
//    {
//        DayOfBirth = "25",
//        MonthOfBirth = Month.July, 
//        YearOfBirth = "1998"
//    },
//    Company = "Issoft",
//    StreetAddress = "Street ",
//    ApartmentAddress = "1",
//    City = "Minsk",
//    State = "California",
//    PostalCode = "12345",
//    Country = "United States",
//    AdditionalInformation = "Some information",
//    HomePhone = "1234567",
//    MobilePhone = "1234567",
//    Alias = "Work",
//    IsSignUpForNewsletter = true,
//    IsReceiveSpecialOffers = false
//};