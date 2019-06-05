using System;
using OpenQA.Selenium;

namespace MicrosoftRewardsAutomatorTests
{
    public class BingPageObjectModel : PageObjectModel
    {
        private IWebElement _searchTextBox;
        private string[] _textListToSearch;
        
        private int _searchCount;
        public override void SetDriver(IWebDriver driver)
        {
            Driver = driver;
        }

        public void NavigateToUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
            
        }

        public void Search(string textToSearch)
        {
            _searchTextBox = ElementAwaiter.WaitUntilElementExists(Driver, By.Id("sb_form_q"));
            _searchTextBox.Clear();
            _searchTextBox.SendKeys(textToSearch);
            var searchButton = ElementAwaiter.WaitUntilElementExists(Driver, By.Id("sb_form_go"));
            searchButton.Click();
        }

        public void SetTextsToSearch(string[] result)
        {
            _textListToSearch = result;
        }

        public void LoopSearch()
        {
            Random random = new Random();

            for (var i = 0; i < _textListToSearch.Length - 1; i += 2)
            {
                System.Threading.Thread.Sleep(random.Next(1000, 3000));
                Search(_textListToSearch[i] + " " + _textListToSearch[i+1]);
                _searchCount++;
            }
        }

        public int GetNumSearchesDone()
        {
            return _searchCount;
        }
    }
}