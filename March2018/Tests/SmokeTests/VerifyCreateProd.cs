using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace March2018.Tests.SmokeTests
{
    class VerifyCreateProd
    {
        IWebDriver driver = new ChromeDriver();

        public static int GetRandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        [SetUp]
        public void Initialize()
        {
            driver.Navigate().GoToUrl("https://uat-platform.authenticateis.com/Account/Logon");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
        }

        [Test]
        public void CreateProdTest()
        {
            driver.FindElement(By.Id("UserName")).SendKeys("mattyates");
            driver.FindElement(By.Id("Password")).SendKeys("Aramark22");
            driver.FindElement(By.Id("do-submit")).Click();

            IWebElement elem = driver.FindElement(By.LinkText("Products"));
            Actions builder = new Actions(driver);
            builder.MoveToElement(elem).Perform();

            driver.FindElement(By.LinkText("Product Catalogue")).Click();
            driver.FindElement(By.PartialLinkText("Barr")).Click();

            driver.FindElement(By.LinkText("create new")).Click();
            driver.FindElement(By.Id("ProductLine_Name")).SendKeys("" + GetRandomNumber(100, 10000));
            driver.FindElement(By.Id("ProductLine_ReferenceCode")).SendKeys("" + GetRandomNumber(10, 9999));

            driver.FindElement(By.XPath("(//input[@type='text'])[5]")).SendKeys("A G Barr (Walthamstow)" + Keys.Enter);
            driver.FindElement(By.CssSelector("[class='button action']")).Click();

            Assert.AreEqual("map product", driver.FindElement(By.LinkText("map product")).Text);

            driver.FindElement(By.CssSelector(".lock")).Click();
        }

        [TearDown]
        public void EndTest()
        {
            driver.Quit();
        
        }
    }
}
