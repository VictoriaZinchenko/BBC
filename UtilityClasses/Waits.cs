using System;
using BBC.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BBC.UtilityClasses
{
    public class Waits
    {
        WebDriverWait Wait = new WebDriverWait(BasePage.Driver, new TimeSpan(0, 0, 30));

        internal void UrlContains(string partOfUrl)
           => Wait.Until(ExpectedConditions.UrlContains(partOfUrl));

        internal void ElementToBeClickable(IWebElement element) =>
            Wait.Until(ExpectedConditions.ElementToBeClickable(element)); 

        internal void ElementExists(By locator) 
            => Wait.Until(ExpectedConditions.ElementExists(locator));

        internal void ElementIsVisible(By locator) =>
            Wait.Until(ExpectedConditions.ElementIsVisible(locator));
    }
}