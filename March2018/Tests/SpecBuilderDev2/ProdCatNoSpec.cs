﻿using System;
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
    public class ProdCatNoSpec
    {
        IWebDriver driver = new FirefoxDriver();

        [OneTimeSetUp]
        public void Initialize()
        {
            driver.Navigate().GoToUrl("https://dev-platform.authenticateis.com/Account/Logon");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.Id("UserName")).SendKeys("AnnaDavis");
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
        public void Message()
        {
            driver.FindElement(By.XPath("//div[@id='do-categoryRootNav']/div/div/ul/li/div/div[2]")).Click();
            driver.FindElement(By.XPath("//ul[@id='do-productLines']/li[5]/div/div/p[2]")).Click();
            driver.FindElement(By.LinkText("Product Data")).Click();
            driver.FindElement(By.XPath("//div[@id='step-0']/div[3]/button")).Click();
            driver.FindElement(By.LinkText("find out more")).Click();
            Assert.AreEqual("Specification Feature Required", driver.FindElement(By.XPath("//div[@id='unlockSpecification']/h3")).Text);
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
            
        }

    }
}