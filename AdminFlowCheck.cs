using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace AdminUserFlowCheck
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
        public void AdminFlowCheck()
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

            IWebElement notification = mydrive.FindElement(By.Name("notifi"));
            notification.Click();
            Thread.Sleep(5000);
            IWebElement clearButton = mydrive.FindElement(By.Name("clearButton"));
            clearButton.Click();
            Thread.Sleep(3000);

            string buttonName = "Back";
            IWebElement back = mydrive.FindElement(By.LinkText(buttonName));
            Thread.Sleep(1000);
            back.Click();
            Thread.Sleep(5000);

            IWebElement Profile = mydrive.FindElement(By.Name("profile"));
            Profile.Click();
            Thread.Sleep(5000);
            IWebElement backprf = mydrive.FindElement(By.LinkText(buttonName));
            Thread.Sleep(1000);
            backprf.Click();
            Thread.Sleep(5000);

            IWebElement vinfo = mydrive.FindElement(By.Name("vehicleinfo"));
            vinfo.Click();
            Thread.Sleep(5000);
            IWebElement backprf01 = mydrive.FindElement(By.LinkText(buttonName));
            Thread.Sleep(1000);
            backprf01.Click();
            Thread.Sleep(5000);

            IWebElement UserInfo = mydrive.FindElement(By.Name("info"));
            UserInfo.Click();
            Thread.Sleep(5000);
            IWebElement backprf02 = mydrive.FindElement(By.LinkText(buttonName));
            Thread.Sleep(1000);
            backprf02.Click();
            Thread.Sleep(3000);
        }
    }
}
