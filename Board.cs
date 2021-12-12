using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CheckersGame
{
    public class Board // Leah // 
    {
        Button[,] board;
        public static readonly int SIZE = 8;

        public Board(Button[,] board)
        {
            this.board = board;
        }


        /*
         * calculates and returns a heuristic value for the current board
         * POsitive value means white is winning, negative is gray is winning
         */
        internal double heuristicValue()
        {
            int whitePieces = 0;
            int grayPieces = 0;
            for (int col = 0; col < SIZE; col++)
            {
                for (int row = 0; row < SIZE; row++)
                {
                    String squareStatus = board[col, row].Tag;
                    if (squareStatus == "white")
                    {
                        whitePieces++;
                    }
                    else if(squareStatus == "gray")
                    {
                        grayPieces++;
                    }
                }
            }
            return whitePieces - grayPieces;
        }


        /*
         * returns a boolean that is true if the specified player can move on that piece
         * note: must check that there is a piece in that square
         */
        internal bool canMove(Player player, int col, int row)
        {
            throw new NotImplementedException();
        }


        /*
         * returns a list of boards for every possible next move
         * will call canMove
         */
        internal Board[] allMoves(Player player)
        {
            throw new NotImplementedException();
        }


        /*
         * returns a list of possible moves for the piece specified in that column
         */
        internal List<Board> MakeMove(Player player, int col, int row)
        {
            throw new NotImplementedException();
        }
    }
}