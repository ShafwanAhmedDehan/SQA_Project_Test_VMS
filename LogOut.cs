using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace LogOutTest
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
        public void TestMethod1()
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

            IWebElement logoutButton = mydrive.FindElement(By.Name("logout"));
            logoutButton.Click();
            Thread.Sleep(5000);
            string outputpage = "VMS Log In";
            string actualOutput = mydrive.Title;
            Assert.AreEqual(outputpage, actualOutput, "Wrong Page...");
        }
    }
}
