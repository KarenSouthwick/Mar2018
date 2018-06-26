using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace March2018.Tests.SpecBuilderDev2
{
    [TestFixture]
    public class ProdDataCust
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
            driver.FindElement(By.XPath("(//button[@id='do-submitLinked'])[7]")).Click();
            driver.FindElement(By.Id("do-closePopup")).Click();
            driver.Manage().Cookies.DeleteCookieNamed("AuthenticateProductFeatureShown");
            Thread.Sleep(3000);
            driver.FindElement(By.LinkText("My Products")).Click();
            driver.FindElement(By.Id("do-closePopup")).Click();
            driver.Manage().Cookies.DeleteCookieNamed("AuthenticateCatalogueFeatureShown");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//div[@id='do-categoryRootNav']/div/div/ul/li/div/div[2]/p/b")).Click();
            driver.FindElement(By.XPath("//ul[@id='do-productLines']/li[3]/div/div/p/b")).Click();
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
        public void CustSpec()
        {
            //create spec
            driver.FindElement(By.LinkText("create")).Click();
            driver.FindElement(By.Id("VersionReference")).SendKeys("version uno");

            driver.FindElement(By.XPath("//nav[@id='do-navigation']/ul/li[7]/a")).Click();
            driver.FindElement(By.Id("do-submitPrimary")).Click();
        }

        [Test, Order(2)]
        public void VerifySpec()
        {
            Thread.Sleep(3000);
            driver.FindElement(By.Id("do-closePopup")).Click();
            driver.Manage().Cookies.DeleteCookieNamed("AuthenticateProductFeatureShown");
            Thread.Sleep(3000);
            driver.FindElement(By.LinkText("My Products")).Click();
            driver.FindElement(By.Id("do-closePopup")).Click();
            driver.Manage().Cookies.DeleteCookieNamed("AuthenticateCatalogueFeatureShown");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//div[@id='do-categoryRootNav']/div/div/ul/li/div/div[2]/p/b")).Click();
            driver.FindElement(By.XPath("//ul[@id='do-productLines']/li[3]/div/div/p/b")).Click();
            driver.FindElement(By.LinkText("Product Data")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.LinkText("Supplier Data")).Click();
            Assert.AreEqual("version uno", driver.FindElement(By.XPath("//div[@id='do-step-supplierData']/div/div[3]/div/table/tbody/tr/td[7]")).Text);

        }
    }
}
