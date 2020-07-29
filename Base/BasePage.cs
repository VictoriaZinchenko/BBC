using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using System.Linq;
using TechTalk.SpecFlow;

namespace BBC.Base
{
    [Binding]
    public class BasePage
    {
        public BasePage()
        {
            PageFactory.InitElements(Driver, this);
        }

        public static IWebDriver Driver { get; set; }

        [BeforeScenario]
        public static void SetUpDriver()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public static void TearDownDriver()
        {
            Driver.Quit();
        }

        public void GoToUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void OpenNewTab()
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.open();");
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
        }

        public void CloseLastTab()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.Last()).Close();
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
        }
    }
}