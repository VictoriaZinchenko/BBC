using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using SeleniumExtras.PageObjects;
using System.Linq;
using TechTalk.SpecFlow;
using BBC.UtilityClasses;
using ConfigurationManager = System.Configuration.ConfigurationManager;
using System;

namespace BBC.Base
{
    [Binding]
    public class BasePage
    {
        private readonly By CloseBtnOfSignInWindowBy = By.XPath("//button[@aria-label='close']");

        private IWebElement CloseBtnOfSignInWindow => Driver.FindElement(CloseBtnOfSignInWindowBy);

        public BasePage()
        {
            PageFactory.InitElements(Driver, this);
        }

        public static IWebDriver Driver { get; set; }

        [BeforeScenario]
        public static void SetUpDriver()
        {
            var ieOptions = new InternetExplorerOptions
            {
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
            };

            Driver = ConfigurationManager.AppSettings["Browser"] switch
            {
                "Chrome" => new ChromeDriver(),
                "FireFox" => new FirefoxDriver(),
                "IE" => new InternetExplorerDriver(ieOptions),
                _ => throw new System.NotImplementedException(),
            };
            Driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public static void TearDownDriverAndGetScreenShoot()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                string folderPath = ConfigurationManager.AppSettings["ScreenShotsOfFailedTestsFolderPath"];
                WorkWithFiles WorkWithFiles = new WorkWithFiles();
                WorkWithFiles.CreateFolderIfNotCreated(folderPath);
                WorkWithFiles.GetScreenshot(folderPath, $"{ScenarioContext.Current.ScenarioInfo.Title} {DateTime.Now.ToString("yyyy_MM_dd")}");
            }

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

        public void CloseSignInWindowIfItIsPresent()
        {
            try
            {
                if (Driver.FindElements(CloseBtnOfSignInWindowBy).Count != 0)
                {
                    Waits.ElementIsVisible(CloseBtnOfSignInWindowBy);
                    CloseBtnOfSignInWindow.Click();
                }
            }
            catch (NoSuchElementException)
            {

            }
        }

        public void JsClick(IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("arguments[0].click();", element);
        }
    }
}