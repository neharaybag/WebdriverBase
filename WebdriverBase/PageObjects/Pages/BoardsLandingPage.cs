using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace PageObjects.Pages
{
    public class BoardsLandingPage : BasePage
    {
        private By lnkCreateNewBoard = By.CssSelector(".board-tile.mod-add");
        private By txtBoardTitle = By.CssSelector("div .subtle-input[placeholder='Add board title']");
        private By btnCreateBoard = By.CssSelector(".create-board-form button[type='submit']");
        private By listBoardTitles = By.CssSelector(".board-tile-details .board-tile-details-name");

    

        public BoardsLandingPage(IWebDriver driver) : base(driver)
        {
        }


        /// <summary>
        /// Create board
        /// </summary>
        /// <param name="boardName"></param>
        /// <returns></returns>
        public BoardPage CreateBoard(string boardName)
        {
            ClickElement(lnkCreateNewBoard);
            EnterText(txtBoardTitle, boardName);
            ClickElement(btnCreateBoard);
            return new BoardPage(Driver);
        }

        /// <summary>
        /// Verify given board name is present in list of baords
        /// </summary>
        /// <param name="boardName"></param>
        /// <returns></returns>
        public bool VerifyBoardIsPresent(string boardName)
        {
            var boards = FindElementsByLocator(listBoardTitles);
            foreach (var boardTitle in boards)
            {
                if (GetAttributeValue(boardTitle,"title").Equals(boardName))
                {
                    return true;
                   
                }
            }

            return false;
        }


        /// <summary>
        /// Select board by name
        /// </summary>
        /// <param name="boardName"></param>
        public BoardPage SelectBoard(string boardName)
        {
            var boards = FindElementsByLocator(listBoardTitles);
            foreach (var boardTitle in boards)
            {
                if (GetAttributeValue(boardTitle, "title").Equals(boardName))
                {
                    boardTitle.Click();

                }
            }
            return new BoardPage(Driver);
        }

       
    }
}
