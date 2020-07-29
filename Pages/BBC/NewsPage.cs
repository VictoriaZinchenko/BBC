using BBC.Base;
using BBC.UtilityClasses;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace BBC.Pages.BBC
{
    public class NewsPage : BasePage
    {
        private readonly By TitleOfMainArticleBy = By.XPath("//div[@data-entityid='container-top-stories#1']//h3");
        private readonly By TitlesOfSecondaryArticlesListBy = By.XPath("//div[contains(@class, 'top-stories__secondary-item')]//h3");
        private readonly By CategoryOfHeadlineArticleBy = By.XPath("//*[contains(@class, 'inline-block@m')]//*[contains(@class, 'section-link')]");

        private IWebElement TitleOfMainArticle => Driver.FindElement(TitleOfMainArticleBy);

        private IWebElement CategoryOfHeadlineArticle => Driver.FindElement(CategoryOfHeadlineArticleBy);

        private IList<IWebElement> TitlesOfSecondaryArticlesList => Driver.FindElements(TitlesOfSecondaryArticlesListBy);

        public string GetMainArticleTitle()
        {
            new Waits().ElementExists(TitleOfMainArticleBy);
            new Waits().ElementIsVisible(TitleOfMainArticleBy);
            return TitleOfMainArticle.Text;
        }

        public List<string> GetTitlesOfSecondaryArticles()
        {
            new Waits().ElementExists(TitlesOfSecondaryArticlesListBy);
            new Waits().ElementIsVisible(TitlesOfSecondaryArticlesListBy);
            return TitlesOfSecondaryArticlesList.Select(title => title.Text).ToList();
        }

        public void FindArticlesByCategoryUsingSearchBar()
        {
            new Waits().ElementIsVisible(CategoryOfHeadlineArticleBy);
            new BbcMainPage().FindArticleUsingSearchBar(CategoryOfHeadlineArticle.Text);
        }
    }
}