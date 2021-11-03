using System;
using System.Windows.Forms;

namespace CheckersGame
{
    public class Board
    {
        Button [,] board;

        public Board(Button [,] board)
        {
            this.board = board;
        }
        internal double heuristicValue()
        {
            throw new NotImplementedException();
        }
    }
}