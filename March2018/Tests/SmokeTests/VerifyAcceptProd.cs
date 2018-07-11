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
using System.Threading; 

namespace March2018.Tests.SmokeTests
{
    class VerifyAcceptProd
    {
        IWebDriver driver = new ChromeDriver();

        [SetUp]
        public void Initialize()
        {
            driver.Navigate().GoToUrl("https://qa-platform.authenticateis.com/Account/Logon");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 974);
        }

        [Test]
        public void AcceptProdTest()
        {
            driver.FindElement(By.Id("UserName")).SendKeys("konstantinoskurtulus");
            driver.FindElement(By.Id("Password")).SendKeys("Aramark22");
            driver.FindElement(By.Id("do-submit")).Click();
            driver.FindElement(By.Id("do-closePopup")).Click();
            Thread.Sleep(3000);

            driver.FindElement(By.XPath("//div[@id='do-boxLinks']/div[2]/div[2]/div/div/div[2]/ul/li[2]/div/a")).Click();            
            driver.FindElement(By.XPath("//table[@id='do-requestOptions-0']/tbody/tr/td[2]/a")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//div[@id='do-acceptResponse-0']/div/table/tbody/tr/td[4]/a")).Click();

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

