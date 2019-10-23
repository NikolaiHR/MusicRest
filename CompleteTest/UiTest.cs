using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace CompleteTest
{
    [TestClass]
    public class UiTest
    {

        #region InstanceFields

        private static IWebDriver _driver;
        private static readonly string _driverDirectory = @"C:\Selenium_Drivers";

        #endregion

        [ClassInitialize]
        public static void Setup(TestContext context)
        
        {
            _driver = new ChromeDriver(_driverDirectory);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

        #region TestMethods

        [TestMethod]
        public void TestGetAll()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/");
            string title = _driver.Title;
            Assert.AreEqual("Record Manager", title);

            IWebElement getAllButton = _driver.FindElement(By.Id("getAllButton"));
            getAllButton.Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement recordList = wait.Until<IWebElement>(d => d.FindElement(By.Id("recordList")));
            Assert.IsTrue(recordList.Text.Contains("Kono Andu da!"));


        }

        #endregion




    }
}
