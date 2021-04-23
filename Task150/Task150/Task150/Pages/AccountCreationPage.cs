using System;
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

        //Selects
        [FindsBy(How = How.Id, Using = "id_country")]
        public IWebElement CountrySelect;

        [FindsBy(How = How.Id, Using = "days")]
        public IWebElement DayOfBirthSelect;

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

        [FindsBy(How = How.Id, Using = "id_gender1")]
        private IWebElement ManRadioButton;

        [FindsBy(How = How.Id, Using = "phone_mobile")]
        private IWebElement MobilePhoneField;

        [FindsBy(How = How.Id, Using = "months")]
        public IWebElement MonthOfBirthSelect;

        [FindsBy(How = How.Id, Using = "passwd")]
        private IWebElement PasswordField;

        [FindsBy(How = How.Id, Using = "postcode")]
        private IWebElement PostalCodeField;

        [FindsBy(How = How.Id, Using = "submitAccount")]
        private IWebElement RegistweButton;

        [FindsBy(How = How.Id, Using = "id_state")]
        public IWebElement StateSelect;

        [FindsBy(How = How.Id, Using = "address1")]
        private IWebElement StreetAddressField;

        [FindsBy(How = How.Id, Using = "id_gender2")]
        private IWebElement WomanRadioButton;

        [FindsBy(How = How.Id, Using = "years")]
        public IWebElement YearOfBirthSelect;


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

        public bool IsMultiple(IWebElement element)
        {
            return new SelectElement(element).IsMultiple;
        }

        public AccountCreationPage FillFields(User user)
        {
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
            string lastName, string password, DateTime birthDate,
            bool isSignUpForNewsletter, bool isReceiveSpecialOffers)
        {
            //Title
            //Radio Button Gender
            var genderRadioElement = isMan
                ? ManRadioButton
                : WomanRadioButton;
            genderRadioElement.Click();

            //First Name
            FirstNameField.SendKeys(firstName);
            //Last Name
            LastNameField.SendKeys(lastName);

            //Password
            PasswordField.SendKeys(password);

            //Date of Birth
            var dayOfBirthSelect = new SelectElement(DayOfBirthSelect);
            dayOfBirthSelect.SelectByValue(birthDate.Day.ToString());

            //Month of Birth
            var monthOfBirthSelect = new SelectElement(MonthOfBirthSelect);
            monthOfBirthSelect.SelectByValue(birthDate.Month.ToString());

            //Year of Birth
            var yearOfBirthSelect = new SelectElement(YearOfBirthSelect);
            yearOfBirthSelect.SelectByValue(birthDate.Year.ToString());

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