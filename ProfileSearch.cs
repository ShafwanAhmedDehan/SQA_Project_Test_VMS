using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace ProfileSearch
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
        public void ProfileSearch()
        {
            string loginURL = "http://localhost/WebTechProject/View/Profilesearch.php";
            mydrive.Navigate().GoToUrl(loginURL);

            IWebElement prfSearch = mydrive.FindElement(By.Name("search"));
            IWebElement SearchButton = mydrive.FindElement(By.Name("prfSearch01"));
            Thread.Sleep(1000);

            string email = "01317810827";
            prfSearch.SendKeys(email);
            Thread.Sleep(2000);
            SearchButton.Click();
            string outComePage = "OTP verify";
            string actualPage = mydrive.Title;
            Assert.AreEqual(outComePage, actualPage, "Wrong Page...Log In Failed");
        }
    }
}
