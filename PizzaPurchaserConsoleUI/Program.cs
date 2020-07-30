using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Threading;

namespace PizzaPurchaserConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = Stopwatch.StartNew();
            watch.Start();

            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("http://papajohns.com");

            Thread.Sleep(2000);

            IWebElement menuButton = driver.FindElement(By.CssSelector("body > div.page-wrapper > header > section.nav-main > nav > ul > li:nth-child(1) > a"));
            menuButton.Click();
            Thread.Sleep(2000);

            IWebElement orderNowButton = driver.FindElement(By.CssSelector("body > div.page-wrapper > header > section.nav-utility > nav > ul > li:nth-child(1) > a"));
            orderNowButton.Click();
            Thread.Sleep(2000);

            IWebElement locations = driver.FindElement(By.Id("carryoutFormAccordion"));
            locations.Click();
            Thread.Sleep(2000);

            IWebElement zipCode = driver.FindElement(By.Id("locations-zipPostalcode"));
            zipCode.SendKeys("35079");
            zipCode.SendKeys(Keys.Enter);
            Thread.Sleep(2000);

            IWebElement orderCarryOut = driver.FindElement(By.CssSelector("#store-details-section-0 > div > div:nth-child(3) > div.set-store-action > form > button"));
            orderCarryOut.Click();
            Thread.Sleep(3000);

            IWebElement continueButton = driver.FindElement(By.LinkText("Continue Ordering"));
            continueButton.Click();

            IWebElement addToCartButton = driver.FindElement(By.CssSelector("body > div.page-wrapper > main > div.container.spacing-top-sm.spacing-bottom-med > section:nth-child(2) > div > div > ul > li:nth-child(2) > div > form > div.card-actions > button.button-alt.button-small.button"));
            addToCartButton.Click();
            Thread.Sleep(2000);

            IWebElement cart = driver.FindElement(By.Id("cart"));
            cart.Click();
            Thread.Sleep(2000);

            IWebElement checkoutButton = driver.FindElement(By.CssSelector("#vcFormId > button"));
            checkoutButton.Click();
            Thread.Sleep(3000); 

            IWebElement firstNameTextField = driver.FindElement(By.Id("contact-firstname"));
            firstNameTextField.SendKeys("Cruz");

            IWebElement lastNameTextField = driver.FindElement(By.Id("contact-lastname"));
            lastNameTextField.SendKeys("Sanchez");

            IWebElement emailTextField = driver.FindElement(By.Id("contact-email"));
            emailTextField.SendKeys("csanchez@truecoders.io");

            IWebElement phoneNumberTextField = driver.FindElement(By.Id("phone-number"));
            phoneNumberTextField.SendKeys("5555451234");

            IWebElement emailCheckBox = driver.FindElement(By.Id("create-account-emailoffers"));
            emailCheckBox.Click();

            IWebElement creditCardTextField = driver.FindElement(By.Id("credit-card-number"));
            creditCardTextField.SendKeys("1234567890123456");

            IWebElement nameOnCardTextField = driver.FindElement(By.Id("credit-card-name"));
            nameOnCardTextField.SendKeys("Cruz Sanchez");

            SelectElement exprirationDateDropDown = new SelectElement(driver.FindElement(By.Id("credit-card-expiration-month")));
            exprirationDateDropDown.SelectByIndex(7);

            SelectElement exprirationYearDropDown = new SelectElement(driver.FindElement(By.Id("credit-card-expiration-year")));
            exprirationYearDropDown.SelectByValue("2021");
            
            IWebElement checkoutZipTextField = driver.FindElement(By.Id("billing-zipcode"));
            checkoutZipTextField.SendKeys("35079");
            
            IWebElement cvvTextField = driver.FindElement(By.Id("credit-card-cvv"));
            cvvTextField.SendKeys("123");
            
            IWebElement termsAndConditionsCheckBox = driver.FindElement(By.Id("input"));
            termsAndConditionsCheckBox.Click();
            
            IWebElement reviewOrderButton = driver.FindElement(By.Id("validate-order"));
            reviewOrderButton.Click();
            
            IWebElement placeOrderButton = driver.FindElement(By.Id("place-your-order"));
            placeOrderButton.Click();

            watch.Stop();
            Console.WriteLine(watch.Elapsed.TotalSeconds);
        }
    }
}
