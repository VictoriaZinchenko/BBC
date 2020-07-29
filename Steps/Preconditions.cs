using BBC.Base;
using BBC.Pages.BBC;
using TechTalk.SpecFlow;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace BBC.Steps
{
    [Binding]
    public sealed class Preconditions
    {

        [Given(@"I have gone to BBC main page")]
        public void GivenIGoToBBCMainPage()
        {
            new BasePage().GoToUrl(ConfigurationManager.AppSettings["BbcUrl"]);
        }

        [Given(@"I have opened News page")]
        public void GivenIHaveOpenedNewsPage()
        {
            new BbcMainPage().OpenNewsPage();
        }
    }
}