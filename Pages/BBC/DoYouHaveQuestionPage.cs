using BBC.Base;
using BBC.UtilityClasses;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace BBC.Pages.BBC
{
    class DoYouHaveQuestionPage : BasePage
    {
        private const string UserContactField = "//div[@class='embed-content-container']//input[@placeholder='{0}']";
        private readonly By ErrorMessageBy = By.XPath("//*[@class='text-input--error']//div[text()]");

        [FindsBy(How = How.XPath, Using = "//textarea[@placeholder='What questions would you like us to investigate?']")]
        private IWebElement QuestionField;
        [FindsBy(How = How.XPath, Using = "//button[@class='button' and text()='Submit']")]
        private IWebElement SubmitButton;

        private IWebElement ErrorMessage => Driver.FindElement(ErrorMessageBy);

        public void FillQuestionField(string text)
        {
            Waits.ElementToBeClickable(SubmitButton);
            QuestionField.SendKeys(text);
        }

        public void FillFormWithUserInformation(List<string> userInfoList, List<string> fieldsList) =>
            fieldsList.Select((field, index) => new { userInfo = userInfoList[index], field })
                .ToList().ForEach(list => Driver.FindElement(By.XPath(string.Format(UserContactField, list.field)))
                    .SendKeys(list.userInfo));

        public void ClickOnSubmitButton() => SubmitButton.Click();

        public bool IsErrorPresentForEmptyField(string nameOfEmptyField)
        {
            Waits.ElementIsVisible(ErrorMessageBy);
            return Driver.FindElement(By.XPath(string.Format(UserContactField, nameOfEmptyField))).
               GetAttribute("class").Equals("text-input--error__input")
               && ErrorMessage.Text.Equals($"{nameOfEmptyField} can't be blank");
        }
    }
}