using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;
using ApexPortal.Login.Pages;

namespace ApexPortal.Login.Steps
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
        
        [Given(@"I enter (.*) as the username")]
        public void GivenIEnterUsername(string user)
        {
            _loginPage.EnterUser(user);
        }
        
        [Given(@"I enter (.*) as the password")]
        public void GivenIEnterThePassword(string pass)
        {
            _loginPage.EnterPass(pass);
        }       
        
        [When(@"I click on Login button")]
        public void WhenIClickOnLoginButton()
        {
            _loginPage.ClickLogIn();
        }
        
        [Then(@"I should land on Apex hompage for Agency Agent role")]
        public void ThenIShouldLandOnApexHompageForAgencyAgentRole()
        {
            _homePage.EnsurePageIsLoaded();
            Assert.AreEqual("APEX Portal", _driver.Title);
        }

        [AfterScenario]
        public void CleanUp()
        {
            if(_driver != null)
            {
                _driver.Close();
                _driver.Dispose();
            }
        }
    }
}
