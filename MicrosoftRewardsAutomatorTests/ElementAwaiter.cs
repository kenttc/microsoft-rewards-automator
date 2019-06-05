using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MicrosoftRewardsAutomatorTests
{
    public class ElementAwaiter
    {
        public static IWebElement WaitUntilElementExists(IWebDriver driver , By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(d => d.FindElement(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }
    }
}