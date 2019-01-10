using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace PageObjects.Pages
{
    public class HomePage : BasePage
    {
        private string testUrl;
        private By btnLogin = By.CssSelector("[href='/login?returnUrl=%2F']");

        public HomePage(IWebDriver driver) : base(driver)
        {

        }

        public HomePage NavigateToHomePage()
        {
            Driver.Url = environment;
            return this;
        }


        /// <summary>
        /// Select Login
        /// </summary>
        /// <returns></returns>
        public LoginPage SelectLogin()
        {
            ClickElement(btnLogin);
            return new LoginPage(Driver);
        }


    }
}
