using System.Linq;
using OpenQA.Selenium;

namespace MicrosoftRewardsAutomatorTests
{
    public class RandomListRandomWordsPageObjectModel : PageObjectModel
    {
        public string[] GetRandomWords(int numberOfWords)
        {
            Driver.Navigate().GoToUrl($"https://www.randomlists.com/random-words?qty={numberOfWords}&dup=false");
            ElementAwaiter.WaitUntilElementExists(Driver, By.ClassName("rand_large"));
            return Driver.FindElements(By.ClassName("rand_large")).Select(x => x.Text).ToArray();
        }

        public override void SetDriver(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}