using BBC.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace BBC.Pages.LoremIpsum
{
    class LoremIpsumMainPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//input[@id='amount']")]
        private IWebElement InputBox;
        [FindsBy(How = How.XPath, Using = "//input[@id='generate']")]
        private IWebElement ButtonGenerateLoremIpsum;
        [FindsBy(How = How.XPath, Using = "//input[@id='bytes']")]
        private IWebElement RadioButtonBytes;

        //For A-Z characters, etc. UTF-8 uses only one byte per character.

        public string GetGeneratedLoremIpsumTextFromSeparateTab(int numberOfCharacters)
        {
            OpenNewTab();
            GoToUrl(ConfigurationManager.AppSettings["LoremIpsumUrl"]);
            string generetedText = GenerateNumberOfLoremIpsumCharacters(numberOfCharacters);
            CloseLastTab();
            return generetedText;
        }

        private string GenerateNumberOfLoremIpsumCharacters(int numberOfCharacters)
        {
            InputBox.Clear();
            InputBox.SendKeys(numberOfCharacters.ToString());
            RadioButtonBytes.Click();
            ButtonGenerateLoremIpsum.Click();
            return new GeneratedLoremIpsumPage().GetLoremIpsumGeneratedText();
        }
    }
}