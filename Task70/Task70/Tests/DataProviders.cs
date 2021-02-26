using System;
using System.Collections;
using System.Text;
using Task70.Model;

namespace Task70.Tests
{
    internal class DataProviders
    {
        public static IEnumerable ValidUsers
        {
            get
            {
                yield return new User()
                {
                    Login = "seleniumtests@tut.by",
                    Password = "123456789zxcvbn"
                };
            }
        }
    }
}
