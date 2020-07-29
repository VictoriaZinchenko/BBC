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
        [When(@"I look for articles by headline article category using Search bar")]
        public void WhenILookForArticlesByHeadlineArticleCategoryUsingSearchBar()
        {
            new NewsPage().FindArticlesByCategoryUsingSearchBar();
        }

        [When(@"I go to Do you have a question for BBC news\?")]
        public void WhenIGoToDoYouHaveAQuestionForBBCNews()
        {
            string doYouHaveQuestionTitle = "Do you have a question for BBC News?";
            new BbcMainPage().FindArticleUsingSearchBar(doYouHaveQuestionTitle);
            new FoundArticlesBySearchBarPage().OpenArticleByTitle(doYouHaveQuestionTitle);
        }

        [When(@"I fill the question field with (.*) characters of Lorem ipsum")]
        public void WhenIFillTheQuestionFieldWithCharactersOfLoremIpsum(int numberOfCharacters)
        {
            new BasePage().OpenNewTab();
            new BasePage().GoToUrl(ConfigurationManager.AppSettings["LoremIpsumUrl"]);
            string generetedText = new LoremIpsumMainPage().GeneratesNumberOfCharactersOfLoremIpsum(numberOfCharacters);
            new BasePage().CloseLastTab();
            new DoYouHaveQuestionPage().FillQuestionField(generetedText);
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
            new WorkWithFiles().CreateFolder(WorkWithFiles.BbcScreenShots);
            new WorkWithFiles().ClearFolder(WorkWithFiles.BbcScreenShots);
            new WorkWithFiles().GetScreenshot();
        }

        [When(@"I click on Submit button")]
        public void WhenIPressSubmitButton()
        {
            new DoYouHaveQuestionPage().ClickOnSubmitButton();
        }
    }
}