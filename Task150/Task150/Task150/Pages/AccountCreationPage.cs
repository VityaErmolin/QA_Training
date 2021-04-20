using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using Task150.HelperPage;
using Task150.Model;

namespace Task150.Pages
{
    internal class AccountCreationPage : Page
    {
        [FindsBy(How = How.Id, Using = "other")]
        private IWebElement AdditionalInformationField;

        [FindsBy(How = How.Id, Using = "alias")]
        private IWebElement AliasField;

        [FindsBy(How = How.Id, Using = "address2")]
        private IWebElement ApartmentAddressField;

        [FindsBy(How = How.Id, Using = "city")]
        private IWebElement CityField;

        // Address
        [FindsBy(How = How.Id, Using = "company")]
        private IWebElement CompanyField;

        [FindsBy(How = How.Id, Using = "id_country")]
        private IWebElement CountrySelect;

        [FindsBy(How = How.Id, Using = "days")]
        private IWebElement DayOfBirthSelect;

        //Personal Information
        [FindsBy(How = How.Id, Using = "customer_firstname")]
        private IWebElement FirstNameField;

        [FindsBy(How = How.Id, Using = "phone")]
        private IWebElement HomePhoneField;

        [FindsBy(How = How.XPath, Using = "//label[@for='optin']")]
        private IWebElement IsReceiveSpecialOffersCheckBox;

        [FindsBy(How = How.XPath, Using = "//label[@for='newsletter']")]
        private IWebElement IsSignUpForNewsLetterCheckBox;

        [FindsBy(How = How.Id, Using = "customer_lastname")]
        private IWebElement LastNameField;

        [FindsBy(How = How.Id, Using = "phone_mobile")]
        private IWebElement MobilePhoneField;

        [FindsBy(How = How.Id, Using = "months")]
        private IWebElement MonthOfBirthSelect;

        [FindsBy(How = How.Id, Using = "passwd")]
        private IWebElement PasswordField;

        [FindsBy(How = How.Id, Using = "postcode")]
        private IWebElement PostalCodeField;

        [FindsBy(How = How.Id, Using = "submitAccount")]
        private IWebElement RegistweButton;

        [FindsBy(How = How.Id, Using = "id_state")]
        private IWebElement StateSelect;

        [FindsBy(How = How.Id, Using = "address1")]
        private IWebElement StreetAddressField;

        [FindsBy(How = How.Id, Using = "years")]
        private IWebElement YearOfBirthSelect;

        public AccountCreationPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public bool IsThisPage()
        {
            var byClassName = By.ClassName("page-heading");
            return _driver.WaiterByElementIsDisplay(byClassName) &&
                   _driver.FindElement(byClassName).Displayed;
        }

        public bool DayOfBirthSelectIsMultiple()
        {
            return !_driver.WaiterByElementIsDisplay(By.Id("days"))
                   && new SelectElement(DayOfBirthSelect).IsMultiple;
        }

        public bool MonthOfBirthSelectIsMultiple()
        {
            return !_driver.WaiterByElementIsDisplay(By.Id("months"))
                   && new SelectElement(MonthOfBirthSelect).IsMultiple;
        }

        public bool YearOfBirthSelectIsMultiple()
        {
            return !_driver.WaiterByElementIsDisplay(By.Id("years"))
                   && new SelectElement(YearOfBirthSelect).IsMultiple;
        }

        public bool StateSelectIsMultiple()
        {
            return !_driver.WaiterByElementIsDisplay(By.Id("id_state"))
                   && new SelectElement(StateSelect).IsMultiple;
        }

        public bool CountrySelectIsMultiple()
        {
            return !_driver.WaiterByElementIsDisplay(By.Id("id_country"))
                   && new SelectElement(CountrySelect).IsMultiple;
        }

        public AccountCreationPage FillFields(User user)
        {
            var byId = By.Id("id_gender1");
            if (!_driver.WaiterByElementIsDisplay(byId))
            {
                throw new ArgumentException("Error! You are on a different page!");
            }

            FillPersonalInformation(user.IsMan, user.FirstName,
                user.LastName, user.Password, user.BirthDate,
                user.IsSignUpForNewsletter, user.IsReceiveSpecialOffers);

            FillAddressInformation(user.Company, user.StreetAddress, user.ApartmentAddress,
                user.City, user.State, user.PostalCode, user.Country,
                user.AdditionalInformation, user.HomePhone, user.MobilePhone, user.Alias);

            return this;
        }

        public MyAccountPage RegisterButtonClick()
        {
            RegistweButton.Click();
            return new MyAccountPage(_driver);
        }

        private void FillPersonalInformation(bool isMan, string firstName,
            string lastName, string password, BirthDate birthDate,
            bool isSignUpForNewsletter, bool isReceiveSpecialOffers)
        {
            //Title
            //Radio Button Gender
            var genderRadioElement = isMan
                ? _driver.FindElement(By.Id("id_gender1"))
                : _driver.FindElement(By.Id("id_gender2"));
            genderRadioElement.Click();

            //First Name
            FirstNameField.SendKeys(firstName);
            //Last Name
            LastNameField.SendKeys(lastName);

            //Password
            PasswordField.SendKeys(password);

            //Date of Birth
            var dayOfBirthSelect = new SelectElement(DayOfBirthSelect);
            Assert.False(dayOfBirthSelect.IsMultiple);
            if (!(int.TryParse(birthDate.DayOfBirth, out var day) && day > 1 && day < 31))
            {
                throw new ArgumentException("The day of the month can not be less than 1 and more than 31");
            }

            dayOfBirthSelect.SelectByValue(birthDate.DayOfBirth);

            //Month of Birth
            var monthOfBirthSelect = new SelectElement(MonthOfBirthSelect);
            Assert.False(monthOfBirthSelect.IsMultiple);
            var monthByByte = (int) birthDate.MonthOfBirth;
            monthOfBirthSelect.SelectByValue(monthByByte.ToString());

            //Year of Birth
            var yearOfBirthSelect = new SelectElement(YearOfBirthSelect);
            Assert.False(yearOfBirthSelect.IsMultiple);
            yearOfBirthSelect.SelectByValue(birthDate.YearOfBirth);

            //Mailling
            if (isSignUpForNewsletter)
            {
                IsSignUpForNewsLetterCheckBox.Click();
            }

            if (isReceiveSpecialOffers)
            {
                IsReceiveSpecialOffersCheckBox.Click();
            }
        }

        private void FillAddressInformation(string company, string streetAddress, string apartmentAddress,
            string city, string state, string postalCode, string country, string additionalInformation,
            string homePhone, string mobilePhone, string alias)
        {
            //Company
            if (!string.IsNullOrEmpty(company))
            {
                CompanyField.SendKeys(company);
            }

            //Street Address
            StreetAddressField.SendKeys(streetAddress);

            //Apartment Address
            if (string.IsNullOrEmpty(apartmentAddress))
            {
                ApartmentAddressField.SendKeys(apartmentAddress);
            }

            //City
            CityField.SendKeys(city);

            //State
            var stateSelect = new SelectElement(StateSelect);
            stateSelect.SelectByText(state);

            //Zip/Postal Code 
            PostalCodeField.SendKeys(postalCode);

            //Country
            var countrySelect = new SelectElement(CountrySelect);
            countrySelect.SelectByText(country);

            //Additional information
            AdditionalInformationField.SendKeys(additionalInformation);

            //Home phone
            if (!string.IsNullOrEmpty(homePhone))
            {
                HomePhoneField.SendKeys(homePhone);
            }

            //Mobile Phone
            MobilePhoneField.SendKeys(mobilePhone);

            //Alias
            AliasField.SendKeys(alias);
        }
    }
}