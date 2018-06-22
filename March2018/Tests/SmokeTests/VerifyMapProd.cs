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
using System.Threading;

namespace March2018.Tests.SmokeTests
{
    class VerifyMapProd
    {
        IWebDriver driver = new ChromeDriver();

        [SetUp]
        public void Initialize()
        {
            driver.Navigate().GoToUrl("https://qa-platform.authenticateis.com/Account/Logon");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 974);
        }

        [Test]
        public void MapProdTest()
        {
            driver.FindElement(By.Id("UserName")).SendKeys("User2867");
            driver.FindElement(By.Id("Password")).SendKeys("Aramark22");
            driver.FindElement(By.Id("do-submit")).Click();
            driver.FindElement(By.Id("do-closePopup")).Click();
            Thread.Sleep(3000);

            driver.FindElement(By.XPath("//li[@id='do-mapProductsCount']/a")).Click();
            driver.FindElement(By.LinkText("map supply chain")).Click();
            Thread.Sleep(3000);

            driver.SwitchTo().Frame("mfp-iframe");
            IWebElement elem = driver.FindElement(By.XPath("//input[@name='ProductLinkSearchRequests[0].Company.Name']"));
            elem.Clear();
            elem.SendKeys("Bidfood");
            elem.SendKeys(Keys.ArrowDown);
            elem.SendKeys(Keys.Enter);


            driver.FindElement(By.Name("ProductLinkSearchRequests[0].ProductName")).SendKeys("treva");
            driver.FindElement(By.Name("ProductLinkSearchRequests[0].ProductReference")).SendKeys("1234");

            driver.FindElement(By.CssSelector("[class='button action']")).Click();

        }

        [TearDown]
        public void EndTest()
        {
            driver.Quit();

        }
    }
}
