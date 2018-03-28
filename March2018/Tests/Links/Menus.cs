using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;

namespace March2018.Tests.Links
{
    class Menus
    {
        [Test]
        public void Test()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://uat-platform.authenticateis.com/Account/Logon");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.FindElement(By.Id("UserName")).SendKeys("angelgaltrey");
            driver.FindElement(By.Id("Password")).SendKeys("Aramark22");
            driver.FindElement(By.Id("do-submit")).Click();

            driver.FindElement(By.Id("productLineSearchQuery")).Clear();
            driver.FindElement(By.Id("productLineSearchQuery")).SendKeys("Guacamole");
            driver.FindElement(By.Name("action:ProductLineAdvancedSearch")).Click();
            driver.FindElement(By.LinkText("Guacamole")).Click();
                      
            IWebElement elem = driver.FindElement(By.LinkText("KPI's"));
            Actions builder = new Actions(driver);
            builder.MoveToElement(elem).Perform();

            driver.FindElement(By.LinkText("Upload KPI Scores")).Click();

            driver.Quit();
        }
    }
}
