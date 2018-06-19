using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;

namespace March2018.Tests.SpecBuilderDev2
{
    [TestFixture]
    public class ProdCatDelete
    {
        IWebDriver driver = new ChromeDriver();

        [OneTimeSetUp]
        public void Initialize()
        {
            driver.Navigate().GoToUrl("https://qa-platform.authenticateis.com/Account/Logon");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 974);
            driver.FindElement(By.Id("UserName")).SendKeys("User1508");
            driver.FindElement(By.Id("Password")).SendKeys("Aramark22");
            driver.FindElement(By.Id("do-submit")).Click();
            driver.FindElement(By.Id("do-closePopup")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.LinkText("My Products")).Click();
            driver.FindElement(By.Id("do-closePopup")).Click();
        }

        [OneTimeTearDown]
        public void EndTest()
        {
            driver.Manage().Cookies.DeleteCookieNamed("AuthenticateProductFeatureShown");
            driver.Manage().Cookies.DeleteCookieNamed("AuthenticateCatalogueFeatureShown");
            driver.Manage().Cookies.DeleteCookieNamed("catalogueHistory");
            driver.Manage().Cookies.DeleteCookieNamed("AuthenticateProductTourRun");
            driver.FindElement(By.CssSelector(".lock")).Click();
            driver.Quit();
        }

        [Test, Order(1)]
        public void DeleteCategory()
        {
            Thread.Sleep(3000);
            driver.FindElement(By.LinkText("add category")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("Category_Name")).SendKeys("Hungary");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            driver.FindElement(By.LinkText("add product")).Click();
            driver.FindElement(By.Id("ProductLine_Name")).SendKeys("product7");
            driver.FindElement(By.Id("ProductLine_ReferenceCode")).SendKeys("pp7");
            driver.FindElement(By.XPath("(//button[@type='submit'])[2]")).Click();
            driver.FindElement(By.XPath("//div[@id='step-0']/div[3]/button")).Click();
            driver.FindElement(By.LinkText("Hungary")).Click();
            driver.FindElement(By.XPath("//ul[@id='do-productLines']/li/div/div[2]/a[4]/span")).Click();
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            driver.FindElement(By.XPath("//a[@id='do-productLinesBack']/i")).Click();
            driver.FindElement(By.LinkText("Delete")).Click();
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }
    }
}
