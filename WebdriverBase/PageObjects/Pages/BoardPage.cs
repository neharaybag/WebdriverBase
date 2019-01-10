using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace PageObjects.Pages
{
    public class BoardPage : BasePage
    {
        public BoardPage(IWebDriver driver) : base(driver)
        {
           if (!ElementDisplayed(lblBoardName))
            {
                throw new Exception("Board page is not loaded");
            }

        }

        private By lblBoardName = By.CssSelector("[href='#'] .board-header-btn-text");
        private By lnkShowMenu = By.CssSelector(".board-header-btns .icon-overflow-menu-horizontal.icon-sm");
        private By lblMessage = By.CssSelector(".big-message h1");
        private By lnkDeleteBaord = By.CssSelector("a.js-delete");
        private By btnDelete = By.CssSelector("[type='submit'][value='Delete']");

        #region "Menu Section"
        private By lnkMore = By.CssSelector(".board-menu-navigation-item-link.js-open-more");
        private By lnkCloseBoard = By.CssSelector("a.js-close-board");
        private By lblPopUp = By.CssSelector(".pop-over-header .pop-over-header-title");
        private By popUpContent = By.CssSelector(".pop-over-content div div p");
        private By btnClose = By.CssSelector("[type='submit'][value='Close']");
        #endregion


        /// <summary>
        /// Select Show Menu link
        /// </summary>
        /// <returns></returns>
        public BoardPage SelectShowMenu()
        {
            var element = FindWebElement(lnkShowMenu);
            Actions action = new Actions(Driver);
            action.MoveToElement(element).Click().Perform();
            return this;
        }


        public BoardPage SelectCloseBoard()
        {
            ClickElement(lnkMore);
            ClickElement(lnkCloseBoard);
            return this;
        }


        /// <summary>
        /// Verify close confimation pop up
        /// </summary>
        /// <returns></returns>
        public bool VerifyCloseBoardPopUP()
        {
            return CompareElementText(lblPopUp, "Close Board?") &&
                    CompareElementText(popUpContent, "You can re-open the board by clicking the “Boards” menu from the header, selecting “View Closed Boards,” finding the board and clicking “Re-open.”");
        }


        /// <summary>
        /// Click on close button on confirmation message
        /// </summary>
        public void ConfirmCloseBoard()
        {
            ClickElement(btnClose);
        }



        /// <summary>
        /// Verify board closed message
        /// </summary>
        /// <param name="boardName"></param>
        /// <returns></returns>
        public bool VerifyBoardClosedMessage(string boardName)
        {
            string message = $"{boardName} is closed";
            return CompareElementText(lblMessage, message);
        }


        /// <summary>
        /// Select Delete board link
        /// </summary>
        public void SelectDeleteBoard()
        {
            ClickElement(lnkDeleteBaord);
        }


        /// <summary>
        /// Verify Delete Baord confirmation pop up
        /// </summary>
        /// <returns></returns>
        public bool VerifyDeleteBoardPopUp()
        {
            return CompareElementText(lblPopUp, "Delete") &&
                   CompareElementText(popUpContent, "All lists, cards and actions will be deleted, and you won’t be able to re-open the board. There is no undo.");

        }


        /// <summary>
        /// Click confirm delete button
        /// </summary>
        /// <returns></returns>
        public BoardPage ConfirmDelete()
        {
            ClickElement(btnDelete);
            return this;
        }


        /// <summary>
        /// Verify Board not found message after board is deleted
        /// </summary>
        /// <returns></returns>
        public bool VerifyBoardDeletedMessage()
        {
            return CompareElementText(lblMessage, "Board not found.");
        }

    }
}
