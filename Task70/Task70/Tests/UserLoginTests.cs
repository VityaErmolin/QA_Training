using NUnit.Framework;
using Task70.Model;

namespace Task70.Tests
{
    [TestFixture]
    public class UserLoginTests : TestBase
    {
        [Test]
        [TestCaseSource(typeof(DataProviders), "ValidUsers")]
        public void CanUserLogin(User user)
        {
            app.LoginUser(user);
            Assert.True(app.LoggedIn());
        }

        [Test]
        [TestCaseSource(typeof(DataProviders), "ValidUsers")]
        public void CanUserLogout(User user)
        {
            app.LoginUser(user);
            app.LogoutUser();
            Assert.True(app.LoggedOut());
        }
    }
}