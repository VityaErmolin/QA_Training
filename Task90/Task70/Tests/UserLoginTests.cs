using Allure.Commons.Model;
using Allure.NUnit.Attributes;
using NUnit.Framework;
using Task70.Model;

namespace Task70.Tests
{
    
    [TestFixture]
    public class UserLoginTests : TestBase
    {
        [Test]
        [TestCaseSource(typeof(DataProviders), "ValidUsers")]
        [AllureSubSuite("Login")]
        [AllureSeverity(SeverityLevel.Normal)]
        [AllureLink("TUT.BY", "https://www.tut.by/")]
        [AllureTest("This test for login")]
        [AllureOwner("CanUserLogin")]
        public void CanUserLogin(User user)
        {
            app.LoginUser(user);
            Assert.True(app.LoggedIn(), "Login process was failed!");
        }

        [Test]
        [TestCaseSource(typeof(DataProviders), "ValidUsers")]
        [AllureSubSuite("Logout")]
        [AllureSeverity(SeverityLevel.Normal)]
        [AllureLink("TUT.BY", "https://www.tut.by/")]
        [AllureTest("This test for logout")]
        [AllureOwner("CanUserLogout")]
        public void CanUserLogout(User user)
        {
            app.LoginUser(user);
            app.LogoutUser();
            Assert.True(app.LoggedOut(), "Logout process was failed!");
        }
    }
}