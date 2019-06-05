using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using TechTalk.SpecFlow;

namespace MicrosoftRewardsAutomatorTests
{
    [Binding]
    public class AutomatedRewardPointsCollectionSteps : IDisposable
    {
        private readonly BingPageObjectModel _bingPageObjectModel;
        private readonly RandomListRandomWordsPageObjectModel _randomListRandomWordsPageObjectModel;
        private readonly EdgeOptions _edgeOptions = new EdgeOptions(){PageLoadStrategy = PageLoadStrategy.Normal};
        private readonly IWebDriver  _driver;

        public AutomatedRewardPointsCollectionSteps(BingPageObjectModel bingPageObjectModel, RandomListRandomWordsPageObjectModel randomListRandomWordsPageObjectModel)
        {
            _bingPageObjectModel = bingPageObjectModel;
            _randomListRandomWordsPageObjectModel = randomListRandomWordsPageObjectModel;
            if(_driver != null) 
                _driver.Dispose();

            _driver = new EdgeDriver(_edgeOptions);
        }
        [Given(@"I have a edge browser")]
        public void GivenIHaveAEdgeBrowser()
        {
            _bingPageObjectModel.SetDriver(_driver);
            _randomListRandomWordsPageObjectModel.SetDriver(_driver);
        }
        
        [Given(@"I have (.*) random words from a random word generator website")]
        public void GivenIHaveRandomWordsFromARandomWordGeneratorWebsite(int p0)
        {
            _bingPageObjectModel.SetTextsToSearch(_randomListRandomWordsPageObjectModel.GetRandomWords(p0));
        }

        [Given(@"I have navigated to (.*)")]
        public void GivenIHaveNavigatedToHttpBing_Com(string url)
        {
            _bingPageObjectModel.NavigateToUrl(url);
        }

        [When(@"I loop through the search text")]
        public void WhenILoopThroughTheSearchText()
        {
            _bingPageObjectModel.LoopSearch();
        }

        [Then(@"I should have searched (.*) times")]
        public void ThenMyPointsShouldHaveBeenIncreasedBy(int p0)
        {
            Assert.IsTrue(_bingPageObjectModel.GetNumSearchesDone() == p0 , $"It does not look like I've searched {p0} times");
        }
      
        
        public void Dispose()
        {
            _driver?.Dispose();
        }
    }
}
