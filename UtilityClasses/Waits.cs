using System;
using BBC.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BBC.UtilityClasses
{
    public static class Waits
    {
        static WebDriverWait Wait = new WebDriverWait(BasePage.Driver, new TimeSpan(0, 0, 30));

        internal static void UrlContains(string partOfUrl)
           => Wait.Until(ExpectedConditions.UrlContains(partOfUrl));

        internal static void ElementToBeClickable(IWebElement element) 
            => Wait.Until(ExpectedConditions.ElementToBeClickable(element)); 

        internal static void ElementExists(By locator) 
            => Wait.Until(ExpectedConditions.ElementExists(locator));

        internal static void ElementIsVisible(By locator) 
            => Wait.Until(ExpectedConditions.ElementIsVisible(locator));
    }
}