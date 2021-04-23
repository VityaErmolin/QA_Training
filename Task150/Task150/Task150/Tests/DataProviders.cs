using System.Collections;
using Task150.HelperPage;
using Task150.Model;

namespace Task150.Tests
{
    internal class DataProviders
    {
        public static IEnumerable ValidUsers
        {
            get { yield return new User().GenerateUser(); }
        }

        public static IEnumerable ValidUsersWithCustomEmail
        {
            get { yield return new User().GenerateUser("test2_mail@gmail.com"); }
        }
    }
}