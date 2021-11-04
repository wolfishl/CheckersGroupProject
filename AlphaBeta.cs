using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersGame
{
    class AlphaBeta
    {

        public static int NrEntries = 0;
        public static double Value(Board board, int depth, double alfa, double beta, Player player)
        {
            Trace.println("Enter alphabeta d = " + depth + " a = " + alfa + " b = " + beta + " P = " + player, 5);
            ++NrEntries;
            double value = 0.0;
            if (depth == 0)
            {
                value = board.heuristicValue();
            }
            else
            {
                Player opponent = player == Player.MAX ? Player.MIN : Player.MAX;

                if (player == Player.MAX)
                {
                    for (int col = 0; col < Board.SIZE; ++col)
                    {
                        for (int row = 0; row < Board.SIZE; ++row)
                        {
                            if (board.canMove(Player.MAX, col, row))
                            {
                                foreach (Board nextPos in board.MakeMove(Player.MAX, col, row))
                                { 
                                    double thisVal = Value(nextPos, depth - 1, alfa, beta, opponent);
                                    if (thisVal > alfa)
                                    {
                                        alfa = thisVal;
                                    }
                                    if (beta <= alfa)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    value = alfa;
                }
                else  // player == Player.MIN
                {
                    for (int col = 0; col < Board.SIZE; ++col)
                    {
                        for (int row = 0; row < Board.SIZE; ++row)
                        {
                            if (board.canMove(Player.MIN, col, row))
                            {
                                foreach (Board nextPos in board.MakeMove(Player.MIN, col, row))
                                {
                                    double thisVal = Value(nextPos, depth - 1, alfa, beta, opponent);
                                    if (thisVal < beta)
                                    {
                                        beta = thisVal;
                                    }
                                    if (beta <= alfa)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    value = beta;
                }
            }
            Trace.println("Exit alfabeta value = " + value + " depth " + depth, 5);
            return value;
        }

    }
}
