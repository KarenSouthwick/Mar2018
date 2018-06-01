using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace March2018.Tests.SmokeTests
{
    class VerifyMapProd
    {
        IWebDriver driver = new ChromeDriver();

        [SetUp]
        public void Initialize()
        {
            driver.Navigate().GoToUrl("https://uat-platform.authenticateis.com/Account/Logon");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [Test]
        public void MapProdTest()
        {
            driver.FindElement(By.Id("UserName")).SendKeys("helenmaxwell");
            driver.FindElement(By.Id("Password")).SendKeys("Aramark22");
            driver.FindElement(By.Id("do-submit")).Click();

            driver.FindElement(By.XPath("//li[@id='do-mapProductsCount']/a")).Click();
            driver.FindElement(By.LinkText("map product")).Click();

            //to be completed as cannot select frame
            driver.SwitchTo().Frame("mfp-iframe");
            driver.FindElement(By.Name("ProductLinkSearchRequests[0].Company.Name")).Clear();
            driver.FindElement(By.Name("ProductLinkSearchRequests[0].Company.Name")).SendKeys("Aviagen");
            driver.FindElement(By.Id("Aviagen")).Click();



            driver.FindElement(By.Name("ProductLinkSearchRequests[0].ProductName")).SendKeys("trev");

            driver.FindElement(By.Name("ProductLinkSearchRequests[0].ProductReference")).SendKeys("123");




            driver.FindElement(By.CssSelector("[class='button action']")).Click();

        }

        [TearDown]
        public void EndTest()
        {
            driver.Quit();

        }
    }
}
