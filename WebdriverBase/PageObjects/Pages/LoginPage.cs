using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace PageObjects.Pages
{
    public class LoginPage : BasePage
    {
        private By txtUserName = By.Id("user");
        private By txtPasword = By.Id("password");
        private By btnLogin = By.Id("login");

        public LoginPage(IWebDriver driver) : base(driver)
        {

        }


        /// <summary>
        /// Login to trello
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public BoardsLandingPage LoginToTrello(string userName,string password)
        {
            EnterText(txtUserName, userName);
            EnterText(txtPasword, password);
            ClickElement(btnLogin);
            return new BoardsLandingPage(Driver);
        }


    }
}
