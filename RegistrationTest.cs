using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace RegistrationTest
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
        public void RegistrationCheck()
        {
            string loginURL = "http://localhost/WebTechProject/View/Registration.php";
            mydrive.Navigate().GoToUrl(loginURL);

            IWebElement FnameInput = mydrive.FindElement(By.Name("fname"));
            IWebElement LnameInput = mydrive.FindElement(By.Name("lname"));
            IWebElement InputGender = mydrive.FindElement(By.Id("html1"));
            IWebElement InputEmail = mydrive.FindElement(By.Name("email"));
            IWebElement Inputpass = mydrive.FindElement(By.Name("pass"));
            IWebElement InputNID = mydrive.FindElement(By.Name("nid"));
            IWebElement Inputuser = mydrive.FindElement(By.Id("html5"));
            IWebElement InputAddress = mydrive.FindElement(By.Name("address"));
            IWebElement submit = mydrive.FindElement(By.Name("submit"));


            Thread.Sleep(1000);

            string fname = "Shafwan Ahmed";
            FnameInput.SendKeys(fname);
            Thread.Sleep(1000);
            string lname = "Dehan";
            Thread.Sleep(1000);
            LnameInput.SendKeys(lname);
            Thread.Sleep(1000);
            InputGender.Click();
            Thread.Sleep(1000);
            string email = "01518918373";
            InputEmail.SendKeys(email);
            Thread.Sleep(1000);
            string pass = "dehan22";
            Inputpass.SendKeys(pass);
            Thread.Sleep(1000);
            string nid = "84569366225";
            InputNID.SendKeys(nid);
            Thread.Sleep(1000);
            string address = "10/F-4, Green Heaven";
            InputAddress.SendKeys(address);
            Thread.Sleep(1000);
            Inputuser.Click();
            submit.Click();
            Thread.Sleep(1000);
            string outComePage = "VMS Log In";
            string actualPage = mydrive.Title;
            Assert.AreEqual(outComePage, actualPage, "Wrong Page...Log In Failed");
        }
    }
}
