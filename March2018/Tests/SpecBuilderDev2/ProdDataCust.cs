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
            driver.FindElement(By.Id("UserName")).SendKeys("darioeurocash");
            driver.FindElement(By.Id("Password")).SendKeys("Aramark22");
            driver.FindElement(By.Id("do-submit")).Click();

        }

        [OneTimeTearDown]
        public void EndTest()
        {
            driver.FindElement(By.CssSelector(".lock")).Click();
            driver.Quit();
        }

        [Test, Order(1)]
        public void CustSpec()
        {
            driver.FindElement(By.XPath("(//button[@id='do-submitLinked'])[7]")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.LinkText("My Products")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//div[@id='do-categoryRootNav']/div/div/ul/li/div/div[2]/p/b")).Click();
            driver.FindElement(By.XPath("//ul[@id='do-productLines']/li[3]/div/div/p/b")).Click();
            driver.FindElement(By.LinkText("Product Data")).Click();
            Thread.Sleep(3000);
            driver.Manage().Cookies.DeleteCookieNamed("catalogueHistory");
            driver.FindElement(By.LinkText("create")).Click();
            driver.FindElement(By.Id("VersionReference")).SendKeys("version uno");
            driver.FindElement(By.Id("do-dateSixMonths")).Click();
            driver.FindElement(By.CssSelector("button.button.action")).Click();
            driver.FindElement(By.LinkText("return to product")).Click();

        }

        [Test, Order(2)]
        public void VerifySpec()
        {
            driver.FindElement(By.XPath("//nav[@id='do-navigation']/ul/li[7]/a")).Click();
            driver.FindElement(By.Id("do-submitPrimary")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.LinkText("My Products")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//div[@id='do-categoryRootNav']/div/div/ul/li/div/div[2]/p/b")).Click();
            driver.FindElement(By.XPath("//ul[@id='do-productLines']/li[3]/div/div/p/b")).Click();
            driver.FindElement(By.LinkText("Product Data")).Click();
            Thread.Sleep(3000);
             driver.FindElement(By.LinkText("Supplier Data")).Click();
            //Assert.Contains("Yes - version uno", driver.FindElement(By.XPath("//div[@id='do-step-supplierData']/div/div[3]/div/table/tbody/tr/td[7]")).Text);

        }
    }
}
