using BBC.Base;
using BBC.UtilityClasses;
using OpenQA.Selenium;

namespace BBC.Pages.LoremIpsum
{
    class GeneratedLoremIpsumPage : BasePage
    {
        private readonly By GeneratedTextOfLoremIpsumBy = By.XPath("//div[@id='lipsum']");

        private IWebElement GeneratedTextOfLoremIpsum => Driver.FindElement(GeneratedTextOfLoremIpsumBy);

        public string GetLoremIpsumGeneratedText()
        {
            new Waits().UrlContains("/feed/");
            new Waits().ElementIsVisible(GeneratedTextOfLoremIpsumBy);
            return GeneratedTextOfLoremIpsum.Text;
        }
    }
}