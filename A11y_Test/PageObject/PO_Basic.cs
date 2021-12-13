using System;
using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Axe;
using System.IO;

namespace A11y_Test.PageObject
{
    public class PO_Basic
    {

        protected IWebDriver Driver;
        //locators
        #region Page Locators
        private IWebElement LoginLink => Driver.FindElement(By.XPath("//a[contains(text(),'Log In')]"));
        protected IWebElement Email => Driver.FindElement(By.XPath("//input[@id='login-email-address']"));
        protected IWebElement Password => Driver.FindElement(By.Id("login-password"));
        protected IWebElement SigIn_btn => Driver.FindElement(By.XPath("//input[@class='cssButton submit_button button  button_login']"));
        protected IWebElement Welcome_text => Driver.FindElement(By.XPath("//span[@class='greetUser']"));
        protected IWebElement SigOut_btn => Driver.FindElement(By.XPath("//a[text()='Log Out']"));
        protected IWebElement SigOut_text => Driver.FindElement(By.XPath("//h1[@id='logoffDefaultHeading']"));

        #endregion

        public PO_Basic(IWebDriver driver)
        {
            Driver = driver;

        }

        //verify if we are in the main page   
        public void GoToHomePage()
        {
            PO_Waits po_wait = new PO_Waits(Driver);

            Driver.Navigate().GoToUrl("http://www.testingyes.com/demo/");
            po_wait.StaticWait(5);
            bool text = Driver.FindElement(By.XPath("//h1[contains(text(),'Wellcome')]")).Displayed;
            if (text == true)

            {
                Assert.AreEqual(true, text);
                Console.WriteLine("The text: Wellcome was found");

            }
            else
            {
                Assert.Fail("Text not found");
            }
        }

        public void Login(string email, string password)
        {
            PO_Waits po_wait = new PO_Waits(Driver);
            //I need to create the time
            LoginLink.Click();

            po_wait.WaitExplicit(Driver);
            Email.SendKeys(email);
            po_wait.StaticWait(3);
            Password.SendKeys(password);
            SigIn_btn.Click();
            string text = Welcome_text.Text;
            if (text == "Test1")
            {
                Assert.AreEqual("Test1", text);
                Console.WriteLine("The text Test1 was found");
                po_wait.StaticWait(5);

            }
            else
            {
                Assert.Fail("Text not found");
            }

        }

        public void LogOut()
        {
            PO_Waits po_wait = new PO_Waits(Driver);
            //I need to create the time
            SigOut_btn.Click();
            po_wait.WaitExplicit(Driver);
            string text = SigOut_text.Text;
            if (text == "Log Off")
            {
                Assert.AreEqual("Log Off", text);
                Console.WriteLine("Log Out successfully");
                po_wait.StaticWait(3);

            }
            else
            {
                Assert.Fail("Unable to Log Out");
            }

        }

        public void AccessibilityTest(string GetDestFolder, string name)
        {
            AxeResult results = new AxeBuilder(Driver).Analyze();
            string path = Path.Combine(GetDestFolder, name + ".html");
            Driver.CreateAxeHtmlReport(results, path);
        }





    }
}


