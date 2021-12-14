using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CheckersGame
{
    /* 
     * TODO: 
     *  1. combine checkabove() and checkBelow() 
     *  2. implement copy()
     */
    public class Board 
    {
        Button[,] board;
        public static readonly int SIZE = 8;
        public static readonly String topColor;

        public Board(Button[,] board, String topColor)
        {
            this.board = board;
            this.topColor = topColor;
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
         * returns a list of boards for every possible next move
         */
        internal List<Board> getAllMoves(Player player)
        {
            List<Board> allMoves = new List<Board>();
            String playerColor = (player == player.MIN) ? "gray" : "white";
            String otherColor = (playerColor == "gray") ? "white" : "gray";
            for (int col = 0; col < SIZE; col++)
            {
                for (int row = 0; row < SIZE; row++)
                {
                    String piece = getPiece(board[col, row]);
                    if (!piece || piece == otherColor) //check that there is a piece there that is this color
                    {
                        continue;
                    }
                    else
                    {
                        Location square = new Location(col, row);
                        List<Board> theseMoves = movesforThisPiece(square, otherColor);
                        allMoves.Add(theseMoves); //might need to make sure not null

                    }
                }
            }
            return allMoves;
        }

        /*
         * generate a list of all possible moves for this piece
         */
        internal List<Board> movesforThisPiece(Location square, String otherColor)
        {
            List<Board> theseMoves = new List<Board>();
            //check if king, when uncomment, make the next if an else if
            //String piece = board[square.col, square.row];
            //if (piece == "king")
            //{
            //    theseMoves.Add(checkAbove);
            //    theseMoves.Add(checkBelow);
            //}
            if (playerColor == topColor) //moving down
            {
                theseMoves.Add(checkBelow(square, otherColor));
            }
            else //moving up
            {
                theseMoves.Add(checkAbove(square, otherColor));
            }
        }

        /*
         * check if moves are possible above and returns the boards of possible moves 
         */
        internal List<Board> checkAbove(Location square, playerColor, otherColor)
        {
            List<Board> moves = new List<Board>();
            int col = square.col;
            int row = square.row;
            if (!(col == 0)) //not first row
            {
                bool firstRow = false;
                bool lastRow = false;
                if (row == 0)
                {
                    firstRow = true;
                }
                if (row = SIZE-1)
                {
                    lastRow = true;
                }
                String left = firstRow ? null : getPiece(board[col - 1, row - 1]);
                String right = lastRow ? null : getPiece(board[col - 1, row + 1]);
                if (!firstRow) //check left side
                {
                    if (!left)
                    {
                        Location moveTo = new Location(col - 1, row - 1);
                        moves.Add(MakeMove(square, moveTo, playerColor));
                    }
                    else
                    {
                        if (col - 2 > 0 && row - 2 > 0)
                        {
                            Location middle = new Location(col - 1, row - 1);
                            Location end = new Location(col - 2, row - 2);
                            Board jumpedBoard = makeJump(square, middle, end, playerColor);
                            if (jumpedBoard)
                            {
                                moves.Add(jumpedBoard);
                            }
                        }
                    }
                }
                if (!lastRow) //check right side
                {
                    if (!right)
                    {
                        Location moveTo = new Location(col - 1, row + 1);
                        moves.Add(MakeMove(square, moveTo, playerColor))
                    }
                    else
                    {
                        if (col - 2 > 0 && row + 2 < SIZE)
                        {
                            Location middle = new Location(col - 1, row + 1);
                            Location end = new Location(col - 2, row + 2);
                            Board jumpedBoard = makeJump(square, middle, end, playerColor);
                            if (jumpedBoard)
                            {
                                moves.Add(jumpedBoard)
                            }
                        }
                    }
                }
            }
            return moves;
        }

        /*
         * check if moves are possible below and returns the boards of possible moves 
         */
        internal List<Board> checkBelow(col, row, otherColor)
        {
            List<Board> moves = new List<Board>();
            int col = square.col;
            int row = square.row;
            if (!(col == SIZE)) //not last row
            {
                bool firstRow = false;
                bool lastRow = false;
                if (row == 0)
                {
                    firstRow = true;
                }
                if (row = SIZE - 1)
                {
                    lastRow = true;
                }
                String left = firstRow ? null : getPiece(board[col + 1, row - 1]);
                String right = lastRow ? null : getPiece(board[col + 1, row + 1]);
                if (!firstRow) //check left side
                {
                    if (!left)
                    {
                        Location moveTo = new Location(col + 1, row - 1);
                        moves.Add(MakeMove(square, moveTo, playerColor));
                    }
                    else
                    {
                        if (col + 2 > 0 && row - 2 > 0)
                        {
                            Location middle = new Location(col + 1, row - 1);
                            Location end = new Location(col + 2, row - 2);
                            Board jumpedBoard = makeJump(square, middle, end, playerColor);
                            if (jumpedBoard)
                            {
                                moves.Add(jumpedBoard);
                            }
                        }
                    }
                }
                if (!lastRow) //check right side
                {
                    if (!right)
                    {
                        Location moveTo = new Location(col + 1, row + 1);
                        moves.Add(MakeMove(square, moveTo, playerColor))
                    }
                    else
                    {
                        if (col - 2 > 0 && row + 2 < SIZE)
                        {
                            Location middle = new Location(col + 1, row + 1);
                            Location end = new Location(col + 2, row + 2);
                            Board jumpedBoard = makeJump(square, middle, end, playerColor);
                            if (jumpedBoard)
                            {
                                moves.Add(jumpedBoard);
                            }
                        }
                    }
                }
            }
            return moves;
        }
        
        /* 
         * returns a copy of the board with the new move
         */
        internal Board MakeMove(Location starting, Location ending, String color)
        {
            Board movedBoard = this.copy();
            movedBoard[col, row].Tag = "none";
            movedBoard[destCol, destRow].Tag = color;
            return movedBoard;
        }

        /*
        * Checks if a jump is possible and returns a copy of the board with the new move if it is
        */
        internal Board makeJump(Location starting, Location middle, Location end, String color)
        {
            Board jumpedBoard = null;
            String middleColor = getPiece(board[middle.col, middle.ro]));
            String endPiece = getPiece(board[end.col, end.row]);
            if ((middle != color) && (!endPiece)) //checks that a jump is possible
            {
                jumpedBoard = this.copy;
                jumpedBoard[starting.col, starting.row].Tag = "none";
                jumpedBoard[middle.col, middle.row].Tag = "none";
                jumpedBoard[end.col, end.row].Tag = color;
            }
            return jumpedBoard;
        }


        /*
         * TODO
         * Makes a deep copy of the board
         */
        public Board copy()
        {
           //TODO
        }

        /*
         * returns the color of the square and null if empty
         */
        internal String getPiece(Button square)
        {
            String piece = square.Tag;
            if (piece == "none")
            {
                piece = null;
            }
            return piece;
        }
    }
}