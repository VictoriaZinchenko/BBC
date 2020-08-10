using BBC.Base;
using BBC.Pages.BBC;
using BBC.Pages.LoremIpsum;
using BBC.UtilityClasses;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using TechTalk.SpecFlow;

namespace BBC.Steps
{
    [Binding]
    public sealed class Actions
    {
        [When(@"I open News page")]
        public void WhenIOpenNewsPage()
        {
            new BbcMainPage().OpenNewsPage();
        }

        [When(@"I look for articles by headline article category using Search bar")]
        public void WhenILookForArticlesByHeadlineArticleCategoryUsingSearchBar()
        {
            new NewsPage().FindArticlesByCategoryUsingSearchBar();
        }

        [When(@"I go to (.*) page using Search bar")]
        public void WhenIGoToPageUsingSearchBar(string pageName)
        {
            new BbcMainPage().FindArticleUsingSearchBar(pageName);
            new FoundArticlesBySearchBarPage().OpenArticleByTitle(pageName);
        }

        [When(@"I fill the question field with (.*) characters of Lorem ipsum")]
        public void WhenIFillTheQuestionFieldWithCharactersOfLoremIpsum(int numberOfCharacters)
        {
            new DoYouHaveQuestionPage().FillQuestionField(
                new LoremIpsumMainPage().GetGeneratedLoremIpsumTextFromSeparateTab(numberOfCharacters));
        }

        [When(@"I fill fields with user contact info")]
        public void WhenIFillFieldsWithUserContactInfo(Table table)
        {
            List<string> userInfoList = table.Rows[0].Values.ToList();
            List<string> fieldsList = table.Header.ToList();
            new DoYouHaveQuestionPage().FillFormWithUserInformation(userInfoList, fieldsList);
        }

        [When(@"I take a screenshot")]
        public void WhenITakeAScreenshot()
        {
            string BbcScreenShots = ConfigurationManager.AppSettings["ScreenShotsFolder"];
            WorkWithFiles WorkWithFiles = new WorkWithFiles();
            WorkWithFiles.CreateFolderIfNotCreated(BbcScreenShots);
            WorkWithFiles.ClearFolder(BbcScreenShots);
            WorkWithFiles.GetScreenshot();
        }

        [When(@"I click on Submit button")]
        public void WhenIPressSubmitButton()
        {
            new DoYouHaveQuestionPage().ClickOnSubmitButton();
        }
    }
}