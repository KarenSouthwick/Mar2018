using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace March2018.PageObjects
{
    class HomePage
    {
        private IWebDriver driver;

        [FindsBy(How = How.CssSelector, Using = ".lock")]
        private IWebElement LogOffButton;

        public HomePage (IWebDriver driver)
        {
            this.driver = driver;
        }

        public void LogOff()
        {
            LogOffButton.Submit();
        }
    }
}
