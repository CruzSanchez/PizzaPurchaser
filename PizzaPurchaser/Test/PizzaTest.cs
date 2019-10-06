using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaPurchaser
{
    class PizzaTest
    {
        [Test]
        public void PizzaGetter()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("http://papajohns.com");

            Thread.Sleep(5000);

            IWebElement menuButton = driver.FindElement(By.CssSelector("body > div.page-wrapper > header > section.nav-main > nav > ul > li:nth-child(1) > a"));
            menuButton.Click();
            Thread.Sleep(5000);

            IWebElement orderNowButton = driver.FindElement(By.CssSelector("body > div.page-wrapper > header > section.nav-utility > nav > ul > li:nth-child(1) > a"));
            orderNowButton.Click();
            Thread.Sleep(5000);

            IWebElement locations = driver.FindElement(By.Id("carryoutFormAccordion"));
            locations.Click();
            Thread.Sleep(5000);

            IWebElement zipCode = driver.FindElement(By.Id("locations-zipPostalcode"));
            zipCode.SendKeys("35079");
            zipCode.SendKeys(Keys.Enter);
            Thread.Sleep(5000);

            IWebElement orderCarryOut = driver.FindElement(By.CssSelector("#store-details-section-0 > div > div:nth-child(3) > div.set-store-action > form > button"));
            orderCarryOut.Click();
            Thread.Sleep(5000);

            IWebElement addToCartButton = driver.FindElement(By.CssSelector("body > div.page-wrapper > main > div.container.spacing-top-sm.spacing-bottom-med > section:nth-child(2) > div > div > ul > li:nth-child(2) > div > form > div.card-actions > button.button-alt.button-small.button"));
            addToCartButton.Click();
            Thread.Sleep(5000);

            IWebElement cart = driver.FindElement(By.Id("cart"));
            cart.Click();
            Thread.Sleep(5000);

            IWebElement yourCartHeader = driver.FindElement(By.XPath("/html/body/div[2]/main/div/div[1]/h2"));
            Assert.AreEqual("YOUR CART", yourCartHeader.Text);
        }
    }
}
