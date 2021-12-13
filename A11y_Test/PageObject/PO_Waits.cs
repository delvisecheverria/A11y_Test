using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumWaitHelper = SeleniumExtras.WaitHelpers;
using System.Threading;

namespace A11y_Test.PageObject

{
    public class PO_Waits

    {
        protected IWebDriver Driver;


        public PO_Waits(IWebDriver driver)
        {
            Driver = driver;

        }

        public static bool ElementIsPresent(IWebDriver Driver, IWebElement locator)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
                //wait.Until(drv => drv.FindElement(locator));
                wait.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#search")));
                return true;
            }
            catch
            {

            }
            return false;

        }

        public void WaitExplicit(IWebDriver Driver)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            }
            catch
            {

            }
        }
        
        public void StaticWait(int Seconds)
        {
            try
            {
                Thread.Sleep(Seconds * 1000);
            }
            catch
            {

            }
        }
    }
}




