using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace March2018.Tests.TestDataAccess
{
    class RandomProd
    {
        public static int GetRandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        [Test]
        public void Test()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://uat-platform.authenticateis.com/Account/Logon");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.FindElement(By.Id("UserName")).SendKeys("angelgaltrey");
            driver.FindElement(By.Id("Password")).SendKeys("Aramark22");
            driver.FindElement(By.Id("do-submit")).Click();

            driver.FindElement(By.LinkText("Products")).Click();
            driver.FindElement(By.LinkText("Product Catalogue")).Click();
            driver.FindElement(By.PartialLinkText("Benson")).Click();

            driver.FindElement(By.LinkText("create new")).Click();
            driver.FindElement(By.Id("ProductLine_Name")).SendKeys("" + GetRandomNumber(100, 1000));
            driver.FindElement(By.Id("ProductLine_ReferenceCode")).SendKeys("" + GetRandomNumber(16, 99));

            driver.FindElement(By.XPath("(//input[@type='text'])[5]")).SendKeys("Cranswick Delico" + Keys.Enter);
            driver.FindElement(By.CssSelector("[class='button action']")).Click();

            driver.Quit();

        }

    }
}