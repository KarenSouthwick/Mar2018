using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using System.Threading;

namespace March2018.Tests.SpecBuilderDev2
{
    [TestFixture]
    public class ProdCat
    {
        IWebDriver driver = new FirefoxDriver();

        [OneTimeSetUp]
        public void Initialize()
        {
            driver.Navigate().GoToUrl("https://dev-platform.authenticateis.com/Account/Logon");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.Id("UserName")).SendKeys("helenmaxwell");
            driver.FindElement(By.Id("Password")).SendKeys("Aramark22");
            driver.FindElement(By.Id("do-submit")).Click();
            driver.FindElement(By.Id("do-closePopup")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.LinkText("My Products")).Click();
            driver.FindElement(By.Id("do-closePopup")).Click();

            Thread.Sleep(3000);

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
        public void CreateCategory()
        {
            driver.FindElement(By.LinkText("add category")).Click();
            driver.FindElement(By.Id("Category_Name")).SendKeys("Cereal Bars");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            Thread.Sleep(3000);
        }

        [Test, Order(2)]
        public void CreateSubCategory()
        {
            driver.FindElement(By.LinkText("add subcategory")).Click(); 
            driver.FindElement(By.Id("SubCategory_Name")).SendKeys("Peanut Bar");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            Thread.Sleep(3000);

        }

        [Test, Order(3)]
        public void AddProduct()
        {
            driver.FindElement(By.XPath("//div[@id='do-categorySubNav']/div/div/ul/li/div/div[2]")).Click();
            driver.FindElement(By.XPath("//div[@id='do-categoryProductLines']/div/div[2]/div/div[2]/a")).Click();
            driver.FindElement(By.Id("ProductLine_Name")).SendKeys("new jersey502");
            driver.FindElement(By.Id("ProductLine_ReferenceCode")).SendKeys("nj1205");
            IWebElement elem = driver.FindElement(By.XPath("(//input[@type='text'])[5]"));
            elem.Clear();
            elem.SendKeys("Adelie Tamworth");
            elem.SendKeys(Keys.Enter);
            driver.FindElement(By.XPath("(//button[@type='submit'])[2]")).Click();
        }

        [Test, Order(4)]
        public void ProductLineDetails()
        {
            driver.FindElement(By.XPath("//div[@id='step-0']/div[3]/button")).Click();
            driver.FindElement(By.LinkText("Cereal Bars | Peanut Bar")).Click();
            //back to product catalogue
            driver.FindElement(By.XPath("//ul[@id='do-productLines']/li/div/div")).Click();
            Assert.AreEqual("new jersey502", driver.FindElement(By.XPath("//div[@id='do-productLineDetails']/div/div/div/h4/span")).Text);
            driver.FindElement(By.LinkText("Supply Chain")).Click();
            //supply chain view
            Thread.Sleep(3000);
            Assert.AreEqual("Cereal Bars | Peanut Bar", driver.FindElement(By.XPath("//div[@id='mainBody']/div/div/div/h2/span/a")).Text);
            
        }
    }
}
