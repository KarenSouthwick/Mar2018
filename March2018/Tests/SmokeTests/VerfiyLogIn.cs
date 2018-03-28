using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace March2018.Tests.SmokeTests
{
    class VerfiyLogIn
    {
        IWebDriver driver = new ChromeDriver();

        [SetUp]
        public void Initialize()
        {
            driver.Navigate().GoToUrl("https://uat-platform.authenticateis.com/Account/Logon");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void OpenAppTest()
        {
            driver.FindElement(By.Id("UserName")).SendKeys("alunjones");
            driver.FindElement(By.Id("Password")).SendKeys("Aramark22");
            driver.FindElement(By.Id("do-submit")).Click();

            Assert.AreEqual("AG BARR", driver.FindElement(By.ClassName("title")).Text);

            driver.FindElement(By.CssSelector(".lock")).Click();
        
        }

        [TearDown]
        public void EndTest()
        { 
            driver.Quit();

        }
    }
}

