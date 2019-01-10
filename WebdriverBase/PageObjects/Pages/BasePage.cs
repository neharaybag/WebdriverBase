using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace PageObjects.Pages
{

   
    public class BasePage
    {

        protected IWebDriver Driver { get; }
        protected string environment;
        protected WebDriverWait wait;
        

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            GetEnvironment();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            wait = new OpenQA.Selenium.Support.UI.WebDriverWait(Driver, TimeSpan.FromSeconds(30));
        }

        /// <summary>
        /// Get Driver page title
        /// </summary>
        protected string PageTitle => Driver.Title;

        /// <summary>
        /// Get driver url
        /// </summary>
        protected string url => Driver.Url;

        /// <summary>
        /// Get environment
        /// </summary>
        private void GetEnvironment()
        {
            var configReader = new AppSettingsReader();            
            environment = (string)configReader.GetValue("baseUrl", typeof(string));
        }


        /// <summary>
        /// Click on element
        /// </summary>
        /// <param name="locator"></param>
        protected void ClickElement(By locator)
        {
            wait.Until(ElementToBeClickable(locator));
            FindWebElement(locator).Click();
        }


        /// <summary>
        /// Find element by locator
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        protected IWebElement FindWebElement(By locator)
        {
            return Driver.FindElement(locator);
        }


        /// <summary>
        /// Find elements by locator
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        protected ReadOnlyCollection<IWebElement> FindElementsByLocator(By locator)
        {
            return Driver.FindElements(locator);
        }



        /// <summary>
        /// Enter text
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="text"></param>
        protected void EnterText(By locator,string text)
        {
            wait.Until(ElementIsVisible(locator));
            ClickElement(locator);
            FindWebElement(locator).SendKeys(text);
        }



        /// <summary>
        /// Get attribute value for element
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
        protected string GetAttributeValue(IWebElement element,string attribute)
        {
            return element.GetAttribute(attribute);
        }


        /// <summary>
        /// Get attribute value for element
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
        protected string GetAttributeValue(By locator,string attribute)
        {
            return FindWebElement(locator).GetAttribute(attribute);
        }



        /// <summary>
        /// Verify element is displayed
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        protected bool ElementDisplayed(By locator)
        {
            try
            {
                wait.Until(ElementIsVisible(locator));
                return true;
            }
            catch(WebDriverTimeoutException)
            {
                return false;
            }            

        }


        /// <summary>
        /// Get element text
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        protected string GetElementText(By locator)
        {
            return FindWebElement(locator).Text;
        }


        /// <summary>
        /// Verify element text is presnet 
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        protected bool CompareElementText(By locator,string text)
        {
            try
            {
                wait.Until(TextToBePresentInElementLocated(locator, text));
                return true;
            }
            catch(WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
