using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace March2018.Tests.SmokeTests
{
    class VerifyAcceptProd
    {
        IWebDriver driver = new ChromeDriver();

        [SetUp]
        public void Initialize()
        {
            driver.Navigate().GoToUrl("https://uat-platform.authenticateis.com/Account/Logon");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
        }

        [Test]
        public void AcceptProdTest()
        {
            driver.FindElement(By.Id("UserName")).SendKeys("jamesdan");
            driver.FindElement(By.Id("Password")).SendKeys("Aramark22");
            driver.FindElement(By.Id("do-submit")).Click();

            driver.FindElement(By.XPath("//li[@id='do-productRequest']/a")).Click();
            driver.FindElement(By.LinkText("accept")).Click();
            driver.FindElement(By.PartialLinkText("create requested")).Click();

            driver.FindElement(By.XPath("(//input[@type='text'])[6]")).SendKeys("AK Stoddart - Ayr" + Keys.Enter);
            driver.FindElement(By.LinkText("create product")).Click();

            driver.FindElement(By.CssSelector(".lock")).Click();
        }

        [TearDown]
        public void EndTest()
        {
            driver.Quit();
        }

        }
    }

