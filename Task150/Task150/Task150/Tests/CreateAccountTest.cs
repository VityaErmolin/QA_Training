using Allure.Commons.Model;
using Allure.NUnit.Attributes;
using NUnit.Framework;
using OpenQA.Selenium;
using Task150.HelperPage;
using Task150.Model;
using Task150.Pages;

namespace Task150.Tests
{
    public class CreateAccountTest : TestBase
    {
        [AllureSubSuite("CanCreateUserAccountTest")]
        [AllureSeverity(SeverityLevel.Critical)]
        [AllureLink("https://github.com/VityaErmolin/QA_Training")]
        [AllureTest("This test create account")]
        [AllureOwner("Viktor Ermolin")]

        [Test]
        [TestCaseSource(typeof(DataProviders), "ValidUsers")]
        public void CanCreateUserAccountTest(User user)
        {
            var authenticationPage = new AuthenticationPage(_driver).Open();

            Assert.True(authenticationPage.IsThisPage(), "This is not authentication page!");

            var accountCreationPage = authenticationPage.FillEmailFieldForRegister(user.Email)
                .CreateAccountButtonClick();

            Assert.True(accountCreationPage.IsThisPage(), "This is not account creation page!");

            Assert.False(accountCreationPage.DayOfBirthSelectIsMultiple()
                         && accountCreationPage.MonthOfBirthSelectIsMultiple()
                         && accountCreationPage.YearOfBirthSelectIsMultiple()
                         && accountCreationPage.StateSelectIsMultiple()
                         && accountCreationPage.CountrySelectIsMultiple(), "Selects shouldn't be multiple!");

            var myAccountPage = accountCreationPage.FillFields(user)
                .RegisterButtonClick();

            Assert.True(myAccountPage.IsThisPage() &&
                        IsRegisterAccount(user.FirstName, user.LastName), "Account wasn't created!");
        }

        private bool IsRegisterAccount(string firstName, string lastName)
        {
            var byCssSelector = By.CssSelector(".account > span");
            var fullNameText = _driver.FindElement(byCssSelector).Text;
            return _driver.WaiterByElementIsDisplay(byCssSelector) &&
                   string.Equals(fullNameText, firstName + " " + lastName);
        }
    }
}