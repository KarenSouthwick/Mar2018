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
using System.Threading;

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
            driver.Navigate().GoToUrl("https://qa-platform.authenticateis.com/Account/Logon");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 974);
        }

        [Test]
        public void CreateProdTest()
        {
            driver.FindElement(By.Id("UserName")).SendKeys("User309");
            driver.FindElement(By.Id("Password")).SendKeys("Aramark22");
            driver.FindElement(By.Id("do-submit")).Click();
            driver.FindElement(By.Id("do-closePopup")).Click();
            Thread.Sleep(3000);

            IWebElement elem = driver.FindElement(By.LinkText("My Products"));
            Actions builder = new Actions(driver);
            builder.MoveToElement(elem).Perform();
            driver.FindElement(By.LinkText("My Products")).Click();
            driver.FindElement(By.Id("do-closePopup")).Click();
            Thread.Sleep(3000);

            driver.FindElement(By.XPath("//div[@id='do-categoryRootNav']/div/div/ul/li/div/div[2]/p/b")).Click();

            driver.FindElement(By.LinkText("add product")).Click();
            driver.FindElement(By.Id("ProductLine_Name")).SendKeys("" + GetRandomNumber(100, 10000));
            driver.FindElement(By.Id("ProductLine_ReferenceCode")).SendKeys("" + GetRandomNumber(10, 9999));

            driver.FindElement(By.XPath("(//input[@type='text'])[5]")).SendKeys("A G Barr (Walthamstow)" + Keys.Enter);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("(//button[@type='submit'])[2]")).Click();

            Assert.AreEqual("map supply chain", driver.FindElement(By.LinkText("map supply chain")).Text);

            //click prod tour
            driver.FindElement(By.CssSelector(".lock")).Click();
        }

        [TearDown]
        public void EndTest()
        {
            driver.Quit();
        
        }
    }
}
