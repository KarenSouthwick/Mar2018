using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;
using March2018.PageObjects;

namespace March2018.Tests.Tests1
{
    class Click
    {
        [Test]
        public void Test()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://uat-platform.authenticateis.com/Account/Logon");

            LogInPage logIn = new LogInPage(driver);
            PageFactory.InitElements(driver, logIn);
            logIn.LogIn("alunjones", "Aramark22");

            IWebElement element = driver.FindElement(By.XPath("//a[contains(text(),'My Network')]"));
            driver.FindElement(By.XPath("//a[contains(text(),'My Network')]")).Click();

            HomePage homePage = new HomePage(driver);
            PageFactory.InitElements(driver, homePage);
            homePage.LogOff();

            driver.Quit();
        }
    }
}
