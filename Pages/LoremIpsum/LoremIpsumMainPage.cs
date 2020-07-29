using BBC.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

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
        public string GeneratesNumberOfCharactersOfLoremIpsum(int numberOfCharacters)
        {
            InputBox.Clear();
            InputBox.SendKeys(numberOfCharacters.ToString());
            RadioButtonBytes.Click();
            ButtonGenerateLoremIpsum.Click();
            return new GeneratedLoremIpsumPage().GetLoremIpsumGeneratedText();
        }
    }
}