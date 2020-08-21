using BBC.Base;
using BBC.UtilityClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
            Waits.ElementToBeClickable(NewsButtonOfMenuLine);
            JsClick(NewsButtonOfMenuLine);
            Waits.UrlContains("/news");
            CloseSignInWindowIfItIsPresent();
        }

        public void FindArticleUsingSearchBar(string navigationText)
        {
            SearchBar.SendKeys(navigationText);
            ButtonSearchBar.Click();
            Waits.UrlContains("/search");
        }
    }
}