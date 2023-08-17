using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace VehicleSearchCheck
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver mydrive;
        [TestInitialize]
        public void Config()
        {
            mydrive = new ChromeDriver();
            mydrive.Manage().Window.Maximize();
        }
        [TestCleanup]
        public void Stop()
        {
            mydrive.Quit();
        }
        [TestMethod]
        public void VehicleSearch()
        {
            string loginURL = "http://localhost/WebTechProject/View/Login.php";
            mydrive.Navigate().GoToUrl(loginURL);

            IWebElement usernameInput = mydrive.FindElement(By.Name("email"));
            IWebElement passwordInput = mydrive.FindElement(By.Name("pass"));
            IWebElement loginButton = mydrive.FindElement(By.Name("login"));
            Thread.Sleep(1000);

            string email = "01317810827";
            Thread.Sleep(1000);
            string pass = "dehan22";
            Thread.Sleep(1000);
            usernameInput.SendKeys(email);
            Thread.Sleep(1000);
            passwordInput.SendKeys(pass);
            Thread.Sleep(1000);
            loginButton.Click();
            Thread.Sleep(5000);
            string outComePage = "Home Page";
            string actualPage = mydrive.Title;
            Assert.AreEqual(outComePage, actualPage, "Wrong Page...Log In Failed");

            IWebElement searchValue = mydrive.FindElement(By.Name("search"));
            IWebElement submitSearch = mydrive.FindElement(By.Name("searchSubmit"));

            string value01 = "19393021";
            searchValue.SendKeys(value01);
            Thread.Sleep(1500);
            submitSearch.Click();
            Thread.Sleep(5000);

            string outcomepage = "Profile";
            string actualOutcome = mydrive.Title;
            Assert.AreEqual(outcomepage, actualOutcome, "Wrong Page");
            Thread.Sleep(2000);

        }
    }
}
