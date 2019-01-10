using NUnit.Framework;
using PageObjects.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class BoardTests : BaseTest
    {
        [Test]
        public void CreateBoardTest()
        {

            // Set test data 
            string boardName = $"Board {GetUniqueDateTimeStamp().ToString()}";
            HomePage homepage = new HomePage(Driver);

            // Login to trello
            BoardsLandingPage boardsLandingPage = homepage.NavigateToHomePage().SelectLogin()
                .LoginToTrello(userName, password);

            // Create Board
            BoardPage boardPage = boardsLandingPage.CreateBoard(boardName);
         
            // Close Board
            boardPage.SelectShowMenu()
                .SelectCloseBoard();

            // Verify close board pop up
            Assert.That(boardPage.VerifyCloseBoardPopUP(), "Close board pop up is not displayed");

            // Close board
            boardPage.ConfirmCloseBoard();

            // Verify board closed messaged
            Assert.That(boardPage.VerifyBoardClosedMessage(boardName), "Board closed message is not displayed");

            // Select Delete Board
            boardPage.SelectDeleteBoard();

            // Verify Delete board pop up
            Assert.That(boardPage.VerifyDeleteBoardPopUp(), "Delete pop up is not displayed");

            // Delete Board
            boardPage.ConfirmDelete();

            // Verify board is deleted
            Assert.That(boardPage.VerifyBoardDeletedMessage(), "Board is not deleted");

           
                
        }
    }
}
