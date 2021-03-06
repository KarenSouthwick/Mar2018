﻿using System;
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
    public class ProdData
    {
        IWebDriver driver = new ChromeDriver();

        [OneTimeSetUp]
        public void Initialize()
        {
            driver.Navigate().GoToUrl("https://qa-platform.authenticateis.com/Account/Logon");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 974);
            driver.FindElement(By.Id("UserName")).SendKeys("bobridsdale");
            driver.FindElement(By.Id("Password")).SendKeys("Aramark22");
            driver.FindElement(By.Id("do-submit")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.LinkText("My Products")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//div[@id='do-categoryRootNav']/div/div/ul/li/div/div[2]/p/b")).Click();
            driver.FindElement(By.XPath("//ul[@id='do-productLines']/li/div/div/p/b")).Click();
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

        [Test, Order(2)]
        public void UnitDataTest()
        {
            driver.FindElement(By.XPath("//table[@id='do-tableSideNav']/tbody/tr[6]/td")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//div[@id='do-accordion']/div[11]/div/div[2]/p/a")).Click();

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
            Thread.Sleep(5000);

        }

        [Test, Order(3)]
        public void ClaimsonPackTest()
        {
            driver.FindElement(By.XPath("//table[@id='do-tableSideNav']/tbody/tr[8]/td")).Click();
            driver.FindElement(By.XPath("//div[@id='do-accordion']/div[15]/div/div[2]/p/a")).Click();
            Thread.Sleep(3000);

            IWebElement elem1 = driver.FindElement(By.XPath("(//input[@type='text'])[3]"));
            elem1.Clear();
            elem1.SendKeys("Cod, Atlantic Cod");
            elem1.SendKeys(Keys.Enter);

            IWebElement elem2 = driver.FindElement(By.XPath("(//input[@type='text'])[4]"));
            elem2.Clear();
            elem2.SendKeys("Beam Trawl");
            elem2.SendKeys(Keys.Enter);

            IWebElement elem3 = driver.FindElement(By.XPath("(//input[@type='text'])[5]"));
            elem3.Clear();
            elem3.SendKeys("White round fish");
            elem3.SendKeys(Keys.Enter);
            Thread.Sleep(5000);

            driver.FindElement(By.Id("do-SpeciesMaximumLife")).SendKeys("50");
            driver.FindElement(By.XPath("//input[@value='add & save']")).Click();

            IWebElement elem = driver.FindElement(By.XPath("(//input[@type='text'])[12]"));
            elem.Clear();
            elem.SendKeys("Kosher");
            elem.SendKeys(Keys.Enter);
            Thread.Sleep(5000);

            driver.FindElement(By.XPath("//input[@value='save']")).Click();
            Thread.Sleep(5000);

        }

        [Test, Order(1)]
        public void NutritionalTest()
        {
            driver.FindElement(By.XPath("//div[@id='do-accordion']/div[7]/div/div[2]/p/a/i")).Click();
            driver.FindElement(By.ClassName("do-ValuesPer100G")).SendKeys("55");
            driver.FindElement(By.ClassName("do-ValuesPerPortion")).SendKeys("5");
            driver.FindElement(By.ClassName("do-TestingFrequency")).SendKeys("daily");
            driver.FindElement(By.ClassName("do-Method")).SendKeys("pipette");
            driver.FindElement(By.Id("do-SaltMethod")).SendKeys("flavour");
            driver.FindElement(By.Id("do-Comments")).SendKeys("no comment");
            
            driver.FindElement(By.XPath("//input[@value='save']")).Click();
            Thread.Sleep(5000);
        }

        [Test, Order(4)]
        public void AllergensTest()
        {
            driver.FindElement(By.XPath("//table[@id='do-tableSideNav']/tbody/tr[5]/td")).Click();
            driver.FindElement(By.XPath("//div[@id='do-accordion']/div[9]/div/div[2]/p/a/i")).Click();

            driver.FindElement(By.Id("do-LupinContains")).Click();
            driver.FindElement(By.Id("do-SesameHandledOnSameLine")).Click();
            driver.FindElement(By.Id("do-BarleyHandledOnSite")).Click();
            IWebElement elem = driver.FindElement(By.Id("do-RyeRiskOfCrossContamination"));
            int elemPos = elem.Location.Y;
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scroll(0, " + elemPos + ");");
            elem.Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("do-CashewsDeclaredOnLabel")).Click();
            driver.FindElement(By.Id("do-Comments")).SendKeys("nothing to see here");          
            
            driver.FindElement(By.XPath("//input[@value='save']")).Click();
            Thread.Sleep(5000);
        }

        [Test, Order(5)]
        public void PackagingTest()
        {
            driver.FindElement(By.XPath("//table[@id='do-tableSideNav']/tbody/tr[7]/td")).Click();
            driver.FindElement(By.XPath("//div[@id='do-accordion']/div[13]/div/div[2]/p/a/i")).Click();

            driver.FindElement(By.Id("do-TypePrimaryPackaging")).SendKeys("wood");
            driver.FindElement(By.Id("do-LengthSecondaryPackaging")).SendKeys("103");

            IWebElement elem4 = driver.FindElement(By.XPath("(//input[@type='text'])[42]"));
            elem4.Clear();
            elem4.SendKeys("Low Carbon");
            elem4.SendKeys(Keys.Enter);
            Thread.Sleep(5000);

            IWebElement elem5 = driver.FindElement(By.Id("do-PackagingFormatBbeFormat"));
            int elemPos = elem5.Location.Y;
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scroll(0, " + elemPos + ");");
            elem5.Click();
            Thread.Sleep(3000);

            driver.FindElement(By.Id("do-RegulationsEMark")).Click();
            driver.FindElement(By.Id("do-PackagingFormatBbeFormat")).SendKeys("Borat");
            driver.FindElement(By.Id("do-Comments")).SendKeys("Duck Song");

            driver.FindElement(By.XPath("//input[@value='save']")).Click();
            Thread.Sleep(5000);
        }

        [Test, Order(6)]
        public void GmoTest()
        {
            driver.FindElement(By.XPath("//table[@id='do-tableSideNav']/tbody/tr[9]/td")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//div[@id='do-accordion']/div[17]/div/div[2]/p/a/i")).Click();

            driver.FindElement(By.Id("do-ProducedFromGmo")).Click();

            driver.FindElement(By.XPath("//input[@value='save']")).Click();
            Thread.Sleep(5000);
        }

        [Test, Order(7)]
        public void StorageTest()
        {
            driver.FindElement(By.XPath("//table[@id='do-tableSideNav']/tbody/tr[10]/td")).Click();
            driver.FindElement(By.XPath("//div[@id='do-accordion']/div[19]/div/div[2]/p/a/i")).Click();

            driver.FindElement(By.Id("do-TemperatureGroupStorageTemperatureRange")).SendKeys("20");
            driver.FindElement(By.Id("do-ShelfLifeGroupTotalShelfLifeFromDateOfManufacture")).SendKeys("300");
            driver.FindElement(By.Id("do-MethodsGroupPrintMethod")).SendKeys("ink");
            driver.FindElement(By.Id("do-Comments")).SendKeys("Straight as Quo");

            driver.FindElement(By.XPath("//input[@value='save']")).Click();
            Thread.Sleep(5000);
        }

        [Test, Order(8)]
        public void StandardsTest()
        {
            driver.FindElement(By.XPath("//table[@id='do-tableSideNav']/tbody/tr[11]/td")).Click();
            driver.FindElement(By.XPath("//div[@id='do-accordion']/div[21]/div/div[2]/p/a/i")).Click();
            Thread.Sleep(3000);

            driver.FindElement(By.XPath("(//input[@type='text'])[3]")).Click();
            driver.FindElement(By.XPath("(//input[@type='text'])[3]")).Clear();
            driver.FindElement(By.XPath("(//input[@type='text'])[3]")).SendKeys("raspberrywwee parssfasigto");
            driver.FindElement(By.XPath("(//input[@type='text'])[3]")).SendKeys(Keys.Enter);
            driver.FindElement(By.Id("do-StandardTarget")).Click();
            driver.FindElement(By.Id("do-StandardTarget")).SendKeys("trevor");
            driver.FindElement(By.XPath("//input[@value='add & save']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("do-LaboratoryGroupContactName")).SendKeys("bob");
            driver.FindElement(By.Id("do-IncubationAndThermalProcessing")).SendKeys("rocking all over the world");

            IWebElement elem6 = driver.FindElement(By.Id("do-saveData"));
            int elemPos = elem6.Location.Y;
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scroll(0, " + elemPos + ");");
            elem6.Click();
            Thread.Sleep(5000);


        }

        [Test, Order(9)]
        public void IngredientsTest()
        {
            driver.FindElement(By.XPath("//table[@id='do-tableSideNav']/tbody/tr[3]/td")).Click();
            driver.FindElement(By.XPath("//div[@id='do-accordion']/div[5]/div/div[2]/p/a/i")).Click();
            Thread.Sleep(3000);

            driver.FindElement(By.XPath("(//input[@type='text'])[3]")).Click();
            driver.FindElement(By.XPath("(//input[@type='text'])[3]")).Clear();
            driver.FindElement(By.XPath("(//input[@type='text'])[3]")).SendKeys("dissaageavgv");
            driver.FindElement(By.XPath("(//input[@type='text'])[3]")).SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            driver.FindElement(By.Id("do-ComponentFunction")).Click();
            driver.FindElement(By.Id("do-ComponentFunction")).SendKeys("weekend");
            driver.FindElement(By.XPath("//input[@value='add & save']")).Click();
            Thread.Sleep(3000);

            driver.FindElement(By.XPath("(//input[@type='text'])[7]")).Click();
            driver.FindElement(By.XPath("(//input[@type='text'])[7]")).Clear();
            driver.FindElement(By.XPath("(//input[@type='text'])[7]")).SendKeys("dissssrgosgs");
            driver.FindElement(By.XPath("(//input[@type='text'])[7]")).SendKeys(Keys.Enter);
            driver.FindElement(By.XPath("(//input[@id='do-ComponentFunction'])[2]")).Click();
            driver.FindElement(By.XPath("(//input[@id='do-ComponentFunction'])[2]")).SendKeys("weekend");
            driver.FindElement(By.XPath("(//input[@value='add & save'])[2]")).Click();
            Thread.Sleep(3000);

            driver.FindElement(By.XPath("(//input[@type='text'])[11]")).Click();
            driver.FindElement(By.XPath("(//input[@type='text'])[11]")).Clear();
            driver.FindElement(By.XPath("(//input[@type='text'])[11]")).SendKeys("dissgfassuaa");
            driver.FindElement(By.XPath("(//input[@type='text'])[11]")).SendKeys(Keys.Enter);
            driver.FindElement(By.XPath("(//input[@id='do-ComponentFunction'])[3]")).Click();
            driver.FindElement(By.XPath("(//input[@id='do-ComponentFunction'])[3]")).SendKeys("weekend");
            driver.FindElement(By.XPath("(//input[@value='add & save'])[3]")).Click();
            Thread.Sleep(3000);

            IWebElement elem7 = driver.FindElement(By.Id("do-PalmOilGroupContainsPalmOil"));
            int elemPos = elem7.Location.Y;
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scroll(0, " + elemPos + ");");
            elem7.Click();
            Thread.Sleep(3000);

            driver.FindElement(By.Id("do-IngredientDeclarations")).SendKeys("All");
            driver.FindElement(By.Id("do-AllergenDeclarations")).SendKeys("The");
            driver.FindElement(By.Id("do-CookingInstructions")).SendKeys("Stars");
            driver.FindElement(By.Id("do-Comments")).SendKeys("Above Me");

            driver.FindElement(By.Id("do-saveData")).Click();
            Thread.Sleep(5000);

        }

        [Test, Order(10)]
        public void QASTest()
        {
            driver.FindElement(By.XPath("//table[@id='do-tableSideNav']/tbody/tr[12]/td")).Click();
            driver.FindElement(By.XPath("//div[@id='do-accordion']/div[23]/div/div[2]/p/a/i")).Click();
            Thread.Sleep(3000);

            driver.FindElement(By.XPath("(//input[@type='text'])[3]")).Click();
            driver.FindElement(By.XPath("(//input[@type='text'])[3]")).Clear();
            driver.FindElement(By.XPath("(//input[@type='text'])[3]")).SendKeys("asgbcfraaaa");
            driver.FindElement(By.XPath("(//input[@type='text'])[3]")).SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            driver.FindElement(By.Id("do-StandardTarget")).Click();
            driver.FindElement(By.Id("do-StandardTarget")).SendKeys("ratrace");
            driver.FindElement(By.XPath("//input[@value='add & save']")).Click();
            Thread.Sleep(3000);

            driver.FindElement(By.XPath("(//input[@type='text'])[9]")).Click();
            driver.FindElement(By.XPath("(//input[@type='text'])[9]")).Clear();
            driver.FindElement(By.XPath("(//input[@type='text'])[9]")).SendKeys("ssfgfgraahaa");
            driver.FindElement(By.XPath("(//input[@type='text'])[9]")).SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("(//input[@id='do-StandardTarget'])[2]")).Click();
            driver.FindElement(By.XPath("(//input[@id='do-StandardTarget'])[2]")).SendKeys("ratrace");
            driver.FindElement(By.XPath("(//input[@value='add & save'])[2]")).Click();
            Thread.Sleep(3000);

            driver.FindElement(By.Id("do-Comments")).SendKeys("beautiful");

            driver.FindElement(By.Id("do-saveData")).Click();
            Thread.Sleep(5000);


        }

        [Test, Order(11)]
        public void SpecNotesTest()
        {
            driver.FindElement(By.XPath("//table[@id='do-tableSideNav']/tbody/tr[13]/td")).Click();
            driver.FindElement(By.XPath("//div[@id='do-accordion']/div[25]/div/div[2]/p/a/i")).Click();

            driver.FindElement(By.Id("Title")).SendKeys("Note");
            driver.FindElement(By.Id("Details")).SendKeys("Charlie and the Queens");
            driver.FindElement(By.Id("do-submit")).Click();
            Thread.Sleep(5000);
        }

        [Test, Order(12)]
        public void ContactsTest()
        {
            driver.FindElement(By.XPath("//table[@id='do-tableSideNav']/tbody/tr[2]/td")).Click();
            driver.FindElement(By.XPath("//div[@id='do-accordion']/div[3]/div/div[2]/p/a/i")).Click();
            Thread.Sleep(3000);

            driver.FindElement(By.XPath("(//input[@type='text'])[3]")).Click();
            driver.FindElement(By.XPath("(//input[@type='text'])[3]")).Clear();
            driver.FindElement(By.XPath("(//input[@type='text'])[3]")).SendKeys("Technical");
            driver.FindElement(By.XPath("(//input[@type='text'])[3]")).SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            driver.FindElement(By.Id("do-ContactTypeFirstName")).SendKeys("Sara");
            driver.FindElement(By.Id("do-ContactTypeLastName")).SendKeys("Jones");
            driver.FindElement(By.Id("do-ContactTypeEmail")).SendKeys("sj@test.com");
            driver.FindElement(By.Id("do-ContactTypeTelephone")).SendKeys("07777777777");
            driver.FindElement(By.CssSelector(".buttonSml")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("do-saveData")).Click();
            Thread.Sleep(5000);

        }

        //[Test, Order(13)]
        public void ProdDetailsTest()
        {
            //Contacts
            driver.FindElement(By.XPath("//table[@id='do-tableSideNav']/tbody/tr[2]/td")).Click();
            Assert.AreEqual("Contact Details", driver.FindElement(By.XPath("//table[@id='do-tableSideNav']/tbody/tr[2]/td")).Text);

            //Ingredients
            driver.FindElement(By.XPath("//table[@id='do-tableSideNav']/tbody/tr[3]/td")).Click();
            Assert.AreEqual("Ingredients", driver.FindElement(By.XPath("//table[@id='do-tableSideNav']/tbody/tr[3]/td")).Text);

            //Nutritional
            //driver.FindElement(By.XPath("//table[@id='do-tableSideNav']/tbody/tr[4]/td")).Click();
            Assert.AreEqual("55", driver.FindElement(By.XPath("//div[@id='do-accordion']/div[9]/div/div/table/tbody/tr/td[2]")).Text);
            Assert.AreEqual("no comment", driver.FindElement(By.XPath("//div[@id='do-accordion']/div[9]/div[2]/div/table/tbody/tr/td/p")).Text);

            //Allergens
            driver.FindElement(By.XPath("//table[@id='do-tableSideNav']/tbody/tr[5]/td")).Click();
            Assert.AreEqual("yes", driver.FindElement(By.XPath("//div[@id='do-accordion']/div[8]/div/div/table/tbody/tr[5]/td[2]/b")).Text);

            //Unit 
            driver.FindElement(By.XPath("//table[@id='do-tableSideNav']/tbody/tr[6]/td")).Click();
            Assert.AreEqual("123", driver.FindElement(By.XPath("//div[@id='do-accordion']/div[9]/div/div/div/div/table/tbody/tr[4]/td[2]")).Text);

            //Packaging 
            //driver.FindElement(By.XPath("//table[@id='do-tableSideNav']/tbody/tr[7]/td")).Click();
            //Assert.AreEqual("Borat", driver.FindElement(By.XPath("//div[@id='do-accordion']/div[10]/div[2]/div[2]/div/div/table/tbody/tr/td[2]")).Text);

            //Claims
            driver.FindElement(By.XPath("//table[@id='do-tableSideNav']/tbody/tr[8]/td")).Click();
            Assert.AreEqual("White round fish", driver.FindElement(By.XPath("//div[@id='do-accordion']/div[11]/div/div/div/div/table/tbody/tr[3]/td[2]")).Text);

            //GMO
            driver.FindElement(By.XPath("//table[@id='do-tableSideNav']/tbody/tr[9]/td")).Click();
            Assert.AreEqual("yes", driver.FindElement(By.XPath("//div[@id='do-accordion']/div[12]/div/div/table/tbody/tr[2]/td[2]/b")).Text);

            //Storage 
            driver.FindElement(By.XPath("//table[@id='do-tableSideNav']/tbody/tr[10]/td")).Click();
            Assert.AreEqual("ink", driver.FindElement(By.XPath("//div[@id='do-accordion']/div[13]/div/div[3]/div/div/table/tbody/tr/td[2]")).Text);

            //Standards
            driver.FindElement(By.XPath("//table[@id='do-tableSideNav']/tbody/tr[11]/td")).Click();
            Assert.AreEqual("trevor", driver.FindElement(By.XPath("//div[@id='do-accordion']/div[14]/div/div/table/tbody/tr/td[2]")).Text);

            //QAS
            driver.FindElement(By.XPath("//table[@id='do-tableSideNav']/tbody/tr[12]/td")).Click();
            Assert.AreEqual("ratrace", driver.FindElement(By.XPath("//div[@id='do-accordion']/div[15]/div/div/table/tbody/tr/td[2]")).Text);          

            //Spec Notes
            //driver.FindElement(By.XPath("//table[@id='do-tableSideNav']/tbody/tr[16]/td")).Click();



            //Assert.IsTrue(driver.FindElement(By.XPath("//div[@id='do-accordion']/div[6]/div/div/table/tbody/tr/td[2]/i")).Displayed);
            //Assert.IsTrue(driver.FindElement(By.XPath("//div[@id='do-accordion']/div[6]/div/div/table/tbody/tr[2]/td[3]/i")).Displayed);

        }

        [Test, Order(14)]
        public void CreateFirstSpec()
        {
            driver.FindElement(By.LinkText("create")).Click();
            driver.FindElement(By.Id("VersionReference")).Click();
            driver.FindElement(By.Id("do-dateSixMonths")).Click();
            driver.FindElement(By.Id("VersionReference")).SendKeys("oh yes");
            driver.FindElement(By.Id("TermsConditions")).SendKeys("chelsea clinton");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.LinkText("return to product")).Click();
            Thread.Sleep(3000);

            driver.FindElement(By.XPath("//div[@id='do-dataContainer']/div/div/div/div/table/thead/tr/th")).Click();
            Assert.AreEqual("Version reference", driver.FindElement(By.XPath("//div[@id='do-dataContainer']/div/div/div/div/table/thead/tr/th")).Text);
            
        }

    }

}
