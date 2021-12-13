using A11y_Test.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A11y_Test.TestCase
{
    [TestFixture]
    public class TestCase_Axe
    {
        protected IWebDriver Driver;

        [SetUp]
        public void BeforeAll()
        {
            Driver = new ChromeDriver();
        }

        [Test]
        public void LoginwithAXE()
        {
            PO_Basic po_basic = new PO_Basic(Driver);
            po_basic.GoToHomePage();
            po_basic.Login("test1@testingyes.com", "test12345");


            //C#
            po_basic.LogOut();



        }



        [TearDown]
        public void AfterAll()
        {
            Driver.Close();
        }


    }
}
