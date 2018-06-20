using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium;

namespace March2018.Tests.SpecBuilderDev2
{
    [TestFixture]
    public class ProdDataDD
    {
        IWebDriver driver = new ChromeDriver();

        [OneTimeSetUp]
        public void Initialize()
        {
            driver.Navigate().GoToUrl("https://qa-platform.authenticateis.com/Account/Logon");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 974);
            driver.FindElement(By.Id("UserName")).SendKeys("User2039");
            driver.FindElement(By.Id("Password")).SendKeys("Aramark22");
            driver.FindElement(By.Id("do-submit")).Click();
            driver.FindElement(By.Id("do-submitPrimary")).Click();
            driver.FindElement(By.Id("do-closePopup")).Click();
            driver.Manage().Cookies.DeleteCookieNamed("AuthenticateProductFeatureShown");
            Thread.Sleep(3000);
            driver.FindElement(By.LinkText("My Products")).Click();
            driver.FindElement(By.Id("do-closePopup")).Click();
            driver.Manage().Cookies.DeleteCookieNamed("AuthenticateCatalogueFeatureShown");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//div[@id='do-categoryRootNav']/div/div/ul/li/div/div[2]/p/b")).Click();
            driver.FindElement(By.XPath("//ul[@id='do-productLines']/li[6]/div/div/p/b")).Click();
            driver.FindElement(By.LinkText("Product Data")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//div[@id='step-0']/div[3]/button")).Click();
            Thread.Sleep(3000);
            driver.Manage().Cookies.DeleteCookieNamed("catalogueHistory");
        }

        [OneTimeTearDown]
        public void EndTest()
        {
            driver.Manage().Cookies.DeleteCookieNamed("AuthenticateProductTourRun");
            driver.FindElement(By.CssSelector(".lock")).Click();
            driver.Quit();
        }

        [Test, Order(1)]
        public void DirectDataTest()
        {
            //driver.FindElement(By.XPath("//div[@id='do-dataContainer']/div[2]/div[2]/div/div/div/div/p/b")).Click();

        }
    
    }
}
