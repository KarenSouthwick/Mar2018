using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace March2018.Tests.Links
{
    class Tables
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

            driver.FindElement(By.XPath("//li[@id='do-productRequest']/a")).Click();
            driver.FindElement(By.XPath("//li[@id='do-mapProductsCount']/a")).Click();

            driver.FindElement(By.Id("do-filterCompanyRequests")).Click();

            driver.Quit();

        }
    }
}
