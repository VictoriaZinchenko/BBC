using BBC.Base;
using BBC.UtilityClasses;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BBC.Pages.BBC
{
    public class BbcMainPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//div[@id='orb-nav-links']//a[(text()='News')]")]
        private IWebElement NewsButtonOfMenuLine;
        [FindsBy(How = How.XPath, Using = "//input[@id='orb-search-q']")]
        private IWebElement SearchBar;
        [FindsBy(How = How.XPath, Using = "//button[@id='orb-search-button']")]
        private IWebElement ButtonSearchBar;

        public void OpenNewsPage()
        {
            new Waits().ElementToBeClickable(NewsButtonOfMenuLine);
            NewsButtonOfMenuLine.Click();
            new Waits().UrlContains("/news");
        }

        public void FindArticleUsingSearchBar(string navigationText)
        {
            SearchBar.SendKeys(navigationText);
            ButtonSearchBar.Click();
            new Waits().UrlContains("/search");
        }
    }
}