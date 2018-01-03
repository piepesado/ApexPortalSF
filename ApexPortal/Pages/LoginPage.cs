using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using ApexPortal.Login.Feature;
using System.Configuration;

namespace ApexPortal.Login.Pages
{
    public class LoginPage : BasePage
    {      
        //Objects
        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement _userName;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement _passWord;

        [FindsBy(How = How.Id, Using = "orgid")]
        private IWebElement _cid;

        [FindsBy(How = How.ClassName, Using = "style-scope colt-login x-scope paper-button-1")]
        private IWebElement _loginButton;

        //Object Properties
        public string Username
        {
            get
            {
                return _userName.Text;
            }
            set
            {
                _userName.SendKeys(value);
            }
        }

        public string Password
        {
            get
            {
                return _passWord.Text;
            }
            set
            {
                _passWord.SendKeys(value);
            }
        }

        public string Cid
        {
            get
            {
                return _cid.Text;
            }
            set
            {
                _cid.SendKeys(value);
            }
        }

        //Constructor
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        //Actions
        public static LoginPage NavigateTo(IWebDriver driver)
        {
            if(driver == null)
            {
                throw new ArgumentNullException(nameof(driver));
            }

            driver.Url = ConfigurationManager.AppSettings["DEV_URL"];
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Title.Equals("APEX Portal::Login"));
            return new LoginPage(driver);
        }
        
        public void EnterUser(string value)
        {
            _userName.SendKeys(value);
            _userName.SendKeys(Keys.Tab);                    
        }

        public void EnterPass(string value)
        {
            _passWord.SendKeys(value);
            _passWord.SendKeys(Keys.Tab);
        }
        public void EnterCid(string value)
        {
            _cid.SendKeys(value);
        }
        

        public HomePage ClickLogIn()
        {
            _loginButton.Click();
            return new HomePage(_driver);
        }

        /*
        //create Home page
        public HomePage EnterCredentials(string username, string password)
        {
            this.Username = username;
            this.Password = password;
            HomePage hotelSearchPage = ClickLogIn();
            return hotelSearchPage;
        }*/
    }
}
