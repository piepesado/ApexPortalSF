using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;
using ApexPortal.Login.Pages;
using ApexPortal.Login;
using TechTalk.SpecFlow.Assist;
using System.Configuration;

namespace ApexPortal.Steps
{
    [Binding]
    public class LoginSteps
    {

        private IWebDriver _driver;
        private LoginPage _loginPage;
        private HomePage _homePage;

        [Given(@"that I navigate to the APEX Portal Url")]
        public void GivenThatINavigateToTheAPEXPortalUrl()
        {
            _driver = WebDriverFactory.Create();
            _loginPage = LoginPage.NavigateTo(_driver);
        }
        
        [When(@"I have entered (.*) as username")]
        public void GivenIHaveEnteredAsUsername(string user)
        {
            /*
            var credentials = table.CreateInstance<Credentials>();
            _loginPage.EnterUser(credentials.Username);
            _loginPage.EnterPass(credentials.Password);
            _loginPage.EnterCid(credentials.Cid);
            
            _loginPage.EnterUser(user);
            */           
           
            user = ConfigurationManager.AppSettings["USER"];                     
            _loginPage.EnterUser(user);
        }
        
        [When(@"I have entered (.*) as password")]
        public void GivenIHaveEnteredAsPassword(string pass)
        {
            pass = ConfigurationManager.AppSettings["PASS"];
            _loginPage.EnterPass(pass);
        }
        
        [When(@"I have entered (.*) as the CID number")]
        public void GivenIHaveEnteredAsTheCIDNumber(string cid)
        {
            cid = ConfigurationManager.AppSettings["CID"];
            _loginPage.EnterCid(cid);
        }
        
        [When(@"I click on Login button")]
        public void WhenIClickOnLoginButton()
        {            
            _loginPage.ClickLogIn();
        }
        
        [Then(@"I should land on Apex hompage for Agency Agent role")]
        public void ThenIShouldLandOnApexHompageForAgencyAgentRole()
        {
            HomePage _homePage = new HomePage(_driver);
            _homePage.EnsurePageIsLoaded();

        }
    }
}
