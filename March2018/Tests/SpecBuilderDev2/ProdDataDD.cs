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
            driver.FindElement(By.Id("UserName")).SendKeys("darioeurocash");
            driver.FindElement(By.Id("Password")).SendKeys("Aramark22");
            driver.FindElement(By.Id("do-submit")).Click();
            driver.FindElement(By.Id("do-submitPrimary")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.LinkText("My Products")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//div[@id='do-categoryRootNav']/div/div/ul/li/div/div[2]/p/b")).Click();
            driver.FindElement(By.XPath("//ul[@id='do-productLines']/li[6]/div/div/p/b")).Click();
            driver.FindElement(By.LinkText("Product Data")).Click();
            Thread.Sleep(3000);
        }

        [OneTimeTearDown]
        public void EndTest()
        {
            driver.Manage().Cookies.DeleteCookieNamed("catalogueHistory");
            driver.FindElement(By.CssSelector(".lock")).Click();
            driver.Quit();
        }

        [Test, Order(1)]
        public void DirectDataTest()
        {
            IWebElement elem = driver.FindElement(By.XPath("//div[@id='do-accordion']/div[10]/div/div/div/table/tbody/tr/td"));
            int elemPos = elem.Location.Y;
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scroll(0, " + elemPos + ");");
            elem.Click();
            Thread.Sleep(3000);

            Assert.AreEqual("remove data link", driver.FindElement(By.XPath("(//a[contains(text(),'remove data link')])[2]")).Text);
            Assert.AreEqual("Eggs", driver.FindElement(By.XPath("//div[@id='do-accordion']/div[10]/div/div/div/table/tbody/tr/td")).Text);

        }

        [Test, Order(2)]
        public void UnitDataTest()
        {
            driver.FindElement(By.XPath("(//a[contains(text(),'add')])[2]")).Click();
            driver.FindElement(By.ClassName("do-Code")).SendKeys("123");
            driver.FindElement(By.ClassName("do-PackSize")).SendKeys("123");
            driver.FindElement(By.ClassName("do-NetWeight")).SendKeys("123");
            driver.FindElement(By.ClassName("do-DrainedWeight")).SendKeys("123");
            driver.FindElement(By.ClassName("do-NumberPerCase")).SendKeys("123");
            driver.FindElement(By.ClassName("do-Barcode")).SendKeys("123");
            driver.FindElement(By.ClassName("do-OnPallet")).Click();
            driver.FindElement(By.ClassName("do-NumberOfCasesPerLayer")).SendKeys("123");
            driver.FindElement(By.ClassName("do-NumberOfCasesPerPallet")).SendKeys("123");
            driver.FindElement(By.ClassName("do-NumberOfLayersPerPallet")).SendKeys("123");
            driver.FindElement(By.CssSelector(".buttonSml")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector(".button.view")).Click();
            Thread.Sleep(3000);
        }

        [Test, Order(3)]
        public void Confirmation()
        {
            Assert.AreEqual("123", driver.FindElement(By.XPath("//div[@id='do-accordion']/div[12]/div/div/div/div/div/table/tbody/tr[8]/td[2]")).Text);
            Assert.AreEqual("remove data link", driver.FindElement(By.XPath("(//a[contains(text(),'remove data link')])[2]")).Text);
        }
    
    }
}
