using Allure.Commons.Model;
using Allure.NUnit.Attributes;
using NUnit.Framework;
using Task150.Model;
using Task150.Pages;

namespace Task150.Tests
{
    public class LoginAccountTest : TestBase
    {
        [AllureSubSuite("CanLoginAccountSuccessTest")]
        [AllureSeverity(SeverityLevel.Critical)]
        [AllureLink("https://github.com/VityaErmolin/QA_Training")]
        [AllureTest("This test login account successfully")]
        [AllureOwner("Viktor Ermolin")]

        [Test]
        [TestCaseSource(typeof(DataProviders), "ValidUsersWithCustomEmail")]
        public void CanLoginAccountSuccessTest(User user)
        {
            var authenticationPage = new AuthenticationPage(_driver).Open();
            Assert.True(authenticationPage.IsThisPage(), "This is not authentication page!");

            var myAccountPage = authenticationPage.FillEmailAndPassword(user.Email, user.Password)
                .LoginButtonClick();
            Assert.True(myAccountPage.IsThisPage(), "This is not authentication page!");
        }

        [AllureSubSuite("CanLoginAccountFailTest")]
        [AllureSeverity(SeverityLevel.Critical)]
        [AllureLink("https://github.com/VityaErmolin/QA_Training")]
        [AllureTest("This test login account failed")]
        [AllureOwner("Viktor Ermolin")]

        [Test]
        [TestCaseSource(typeof(DataProviders), "ValidUsersWithCustomEmail")]
        public void CanLoginAccountFailTest(User user)
        {
            var authenticationPage = new AuthenticationPage(_driver).Open();
            Assert.True(authenticationPage.IsThisPage(), "This is not authentication page!");

            var expected = _driver.Title;

            authenticationPage.FillEmailAndPassword(user.Email, user.Password+"123")
                .LoginButtonClick();

            Assert.AreEqual(expected, _driver.Title);
           //Assert.False(myAccountPage.IsThisPage(), "This is not authentication page!");
        }
    }
}