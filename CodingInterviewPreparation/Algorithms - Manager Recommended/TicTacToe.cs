using System;
using NUnit.Framework;

namespace Algorithms
{
    // https://codereview.stackexchange.com/questions/176556/c-tic-tac-toe-game
    public class TicTacToe
    {
        // How would you determine if someone has won a game of tic-tac-toe on a board of any size?
        // https://www.glassdoor.com/Interview/How-would-you-determine-if-someone-has-won-a-game-of-tic-tac-toe-on-a-board-of-any-size-QTN_1104.htm
        public bool IsThereAWinner(char[,] board)
        {
            // Use Array.Rank to get number of dimensions and then
            // use Array.GetLength(int dimension) to get the length of a specific dimension.
            int lengthFirstDimension = board.GetLength(0);
            int lengthSecondDimension = board.GetLength(1);

            if (lengthFirstDimension != lengthSecondDimension)
            {
                return false; // unsupported case
            }

            // check rows for match
            for (int i = 0; i < lengthFirstDimension; i++)
            {
                char initialValue = board[i, 0];
                bool foundMismatch = false;
                for (int j = 0; j < lengthSecondDimension; j++)
                {
                    var currentValue = board[i, j];
                    if (currentValue != initialValue)
                    {
                        foundMismatch = true;
                        break;
                    }
                }

                if (foundMismatch == false) return true; // found a winning row
            }

            // check columns for match
            for (int i = 0; i < lengthSecondDimension; i++)
            {
                char initialValue = board[0, i];
                bool foundMismatch = false;
                for (int j = 0; j < lengthFirstDimension; j++)
                {
                    var currentValue = board[j, i];
                    if (currentValue != initialValue)
                    {
                        foundMismatch = true;
                        break;
                    }
                }

                if (foundMismatch == false) return true; // found a winning column
            }

            // check diagonals for match
            // first check descending diagonal
            bool foundDescDiagonalMismatch = false;
            char initialDescValue = board[0, 0];
            for (int i = 0; i < lengthSecondDimension; i++)
            {
                var currentValue = board[i, i];
                if (currentValue != initialDescValue)
                {
                    foundDescDiagonalMismatch = true;
                    break;
                }
            }

            if (foundDescDiagonalMismatch == false) return true; // found a winning descending diagonal

            // second check ascending diagonal
            bool foundAscDiagonalMismatch = false;
            char initialAscValue = board[lengthFirstDimension - 1, 0];
            for (int i = 0; i < lengthSecondDimension; i++)
            {
                var currentValue = board[lengthFirstDimension - i - 1, i];
                if (currentValue != initialAscValue)
                {
                    foundAscDiagonalMismatch = true;
                    break;
                }
            }

            if (foundAscDiagonalMismatch == false) return true; // found a winning ascending diagonal

            return false;
        }

        [Test] // static void Main(string[] args)
        public void MainTest()
        {
            // todo fix algorithm to test only for X and O
            char[,] myBoard = new char[,]
            {
                { 'X', 'O', 'X'},
                { 'O', 'X', 'O'},
                { 'X', 'O', 'O'},
            };
            
            Console.WriteLine(IsThereAWinner(myBoard));
        }
    }
}