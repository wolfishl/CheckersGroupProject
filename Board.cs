﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CheckersGame
{
    public class Board
    {
        Button [,] board;
        public static readonly int SIZE = 8;

        public Board(Button [,] board)
        {
            this.board = board;
        }
        internal double heuristicValue()
        {
            throw new NotImplementedException();
        }
       
        internal bool isEmpty()
        {
            throw new NotImplementedException();
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
         * returns a list of possible moves for the piece specified in that column
         */
        internal List<Board> MakeMove(Player player, int col, int row)
        {
            throw new NotImplementedException();
        }
    }
}