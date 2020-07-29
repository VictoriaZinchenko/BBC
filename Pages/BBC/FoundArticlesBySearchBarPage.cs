using BBC.Base;
using BBC.UtilityClasses;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BBC.Pages.BBC
{
    class FoundArticlesBySearchBarPage : BasePage
    {
        private const string ArticleByTitle = "//ul[@role='list']//*[text()='{0}']/ancestor::p";

        [FindsBy(How = How.XPath, Using = "//ul[@role='list' and @class='css-1lb37cz-Stack e1y4nx260']//li[1]//a")]
        private IWebElement FirstArticleUsingSearch;

        public string GetNameOfFirstArticleByCategory()
        {
            new Waits().ElementToBeClickable(FirstArticleUsingSearch);
            return FirstArticleUsingSearch.Text;
        }

        public void OpenArticleByTitle(string title)
        {
            IWebElement article = Driver.FindElement(By.XPath(string.Format(ArticleByTitle, title)));
            new Waits().ElementToBeClickable(article);
            article.Click();
        }
    }
}