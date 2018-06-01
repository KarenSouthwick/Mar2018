using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;


namespace March2018.Tests.Links
{
    class Spec
    {
        IWebDriver driver = new ChromeDriver();

        [SetUp]
        public void Initialize()
        {
            driver.Navigate().GoToUrl("https://uat-platform.authenticateis.com/Account/Logon");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void BuildSpecTest()
        {
            driver.FindElement(By.Id("UserName")).SendKeys("karensouthwick");
            driver.FindElement(By.Id("Password")).SendKeys("Exchange!6");
            driver.FindElement(By.Id("do-submit")).Click();



        }

        [TearDown]
        public void EndTest()
        {
            driver.Quit();

        }
    }
}
    
