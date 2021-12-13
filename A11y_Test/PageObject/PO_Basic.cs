using System;
using NUnit.Framework;
using OpenQA.Selenium;




namespace A11y_Test.PageObject
{
    public class PO_Basic
    {

        protected IWebDriver Driver;

        //Locators
        private IWebElement LoginLink => Driver.FindElement(By.XPath("//a[contains(text(),'Log In')]"));
        protected IWebElement Email => Driver.FindElement(By.XPath("//input[@id='login-email-address']"));
        protected IWebElement Password => Driver.FindElement(By.Id("login-password"));
        protected IWebElement SigIn_btn => Driver.FindElement(By.XPath("//input[@class='cssButton submit_button button  button_login']"));
        protected IWebElement Welcome_text => Driver.FindElement(By.XPath("//span[@class='greetUser']"));
        protected IWebElement SigOut_btn => Driver.FindElement(By.XPath("//a[text()='Log Out']"));
        protected IWebElement SigOut_text => Driver.FindElement(By.XPath("//h1[@id='logoffDefaultHeading']"));

        protected IWebElement Clothing_cat => Driver.FindElement(By.XPath("//a[@class='category-top'][1]"));
        protected IWebElement Field_dresses => Driver.FindElement(By.XPath("//input[@name='products_id[2]']"));
        protected IWebElement AddToCart_btn => Driver.FindElement(By.XPath("//input[@id='submit1']"));
        protected IWebElement Quantity => Driver.FindElement(By.XPath("//input[@name='cart_quantity[]']"));
        protected IWebElement Cart_element => Driver.FindElement(By.XPath("//span[@class='cartProdTitle']"));
        protected IWebElement Delete_element => Driver.FindElement(By.XPath("//*[@id='cartContentsDisplay']/tbody/tr[2]/td[6]/a/img"));

        protected IWebElement Field_search => Driver.FindElement(By.XPath("(//input[@name='keyword'])[last()]"));
        protected IWebElement Search_btn => Driver.FindElement(By.XPath("(//input[@class='cssButton submit_button button  button_search'])[last()]"));
        protected By Search_result1 = By.XPath("(//a[contains(text(),'Short')])[last()-1]");
        protected IWebElement Search_result => Driver.FindElement(By.XPath("(//a[contains(text(),'Short')])[last()-1]"));


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




    }
}


