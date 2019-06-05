using OpenQA.Selenium;

namespace MicrosoftRewardsAutomatorTests
{
    public abstract class PageObjectModel
    {
        protected IWebDriver Driver { get; set; }
        public abstract void SetDriver(IWebDriver driver);
    }
}