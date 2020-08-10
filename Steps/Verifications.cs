using BBC.Pages.BBC;
using BBC.UtilityClasses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace BBC.Steps
{
    [Binding]
    public sealed class Verifications
    {
        [Then(@"name of the first article is (.*)")]
        public void ThenNameOfTheFirstArticleIs(string nameOfArticle)
        {
            string actualNameOfArticle = new FoundArticlesBySearchBarPage().GetNameOfFirstArticleByCategory();
            Assert.AreEqual(nameOfArticle, actualNameOfArticle,
                $"\nThe expected first article: '{nameOfArticle}'" +
                $"\nThe actual first article: '{actualNameOfArticle}'");
        }

        [Then(@"name of the headline article is (.*)")]
        public void ThenNameOfTheHeadlineArticleIs(string nameOfArticle)
        {
            string actualNameOfArticle = new NewsPage().GetMainArticleTitle();
            Assert.AreEqual(nameOfArticle, actualNameOfArticle,
                $"\nThe expected headline article: '{nameOfArticle}'" +
                $"\nThe actual headline article: '{actualNameOfArticle}'");
        }

        [Then(@"there are correct names of secondary articles on the News page")]
        public void ThenThereAreCorrectNamesOfSecondaryArticlesOnTheNewsPage(Table table)
        {
            List<string> expectedList = table.Rows.ToList().Select(name => name["Title"]).ToList();
            Assert.IsTrue(expectedList.SequenceEqual(new NewsPage().GetTitlesOfSecondaryArticles()),
                $"\nActual list: '{string.Join(", ", new NewsPage().GetTitlesOfSecondaryArticles())}'"
                + $"\nExpected list: '{string.Join(", ", expectedList)}'");
        }

        [Then(@"I can find this screenshot on my PC")]
        public void ThenICanFindThisScreenshotOnMyPC()
        {
            Assert.IsTrue(new WorkWithFiles().GetNumberOfFolderFiles
                (ConfigurationManager.AppSettings["ScreenShotsFolder"]) != 0,
                "There is no screenshot on this PC");
        }

        [Then(@"there is error text under empty (.*) field")]
        public void ThenThereIsErrorTextUnderEmptyField(string nameOfEmptyField)
        {
            Assert.IsTrue(new DoYouHaveQuestionPage().IsErrorPresentForEmptyField(nameOfEmptyField),
            $"There is no error message under empty {nameOfEmptyField} field.");
        }
    }
}