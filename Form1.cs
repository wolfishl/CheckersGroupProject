using System;
using System.Windows.Forms;
using System.Drawing; 

namespace CheckersGame
{
    public partial class Form1 : Form
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        Button[,] board;
        int boardSize = 8;

        public Form1()
        {
            InitializeComponent();
            board = new Button [8, 8] { 
                { square1 , square2, square3, square4, square5, square6, square7, square8       },
                { square9, square10, square11, square12, square13, square14, square15, square16 },
                { square17, square18, square19, square20, square21, square22, square23, square24},
                { square25, square26, square27, square28, square29, square30, square31, square32},
                { square33, square34, square35, square36, square37, square38, square39, square40},
                { square41, square42, square43, square44, square45, square46, square47, square48},
                { square49, square50, square51, square52, square53, square54, square55, square56},
                { square57, square58, square59, square60, square61, square62, square63, square64} 
            };
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            InitializeNoneCheckers();
            InitializeBoard(); 
            playerGroupBox.Visible = false;
            levelGroupBox.Visible = false; 
            var startBtn = (Button)sender;
            startBtn.Visible = false;
        }

        private void InitializeNoneCheckers()
        {
            foreach (var btn in board)
            {
                btn.BackgroundImage = Properties.Resources.checkerNone;
                btn.Tag = "none"; 
            }
        }

        private void InitializeBoard()
        {
            if (radioYou.Checked)
            {
                InitializeTop(Properties.Resources.checkerGray, "white");
                InitializeBottom(Properties.Resources.checkerWhite, "gray"); 
            } else
            {
                InitializeTop(Properties.Resources.checkerWhite, "gray");
                InitializeBottom(Properties.Resources.checkerGray, "white"); 
            }
        }

        private void InitializeTop(Bitmap checker, string color)
        {
            int lastColumn = 2;
            int boardSize = 8;
            for (int col = 0; col <= lastColumn; col++)
            {
                for (int row = 0; row < boardSize; row++)
                {
                    if ((col + row) % 2 == 0)
                    {
                        board[col, row].BackgroundImage = checker;
                        board[col, row].Tag = color;
                    }
                }
            }
        }

        private void InitializeBottom(Bitmap checker, string color)
        {

            int startingColumn = 5;
            int boardSize = 8;
            for (int col = startingColumn; col < boardSize; col++)
            {
                for (int row = 0; row < boardSize; row++)
                {
                    if ((col + row) % 2 == 0)
                    {
                        board[col, row].BackgroundImage = checker;
                        board[col, row].Tag = color;
                    }
                }
            }
        }    

        /* OnClickMethod for each square calls InputCheckerMove */
        private void SquareOnClick(object sender, EventArgs e)
        {
            InputCheckerMove(sender);
        }


        /* InputCheckerMove allows user to enter a move. Highlights the selected square Cyan so user
         knows which square they are at. */
        public void InputCheckerMove(object sender)
        {
            Button btn = (Button)sender;
            if (!btn.Tag.Equals("none"))
            {
                var grayTeam = btn.Tag.Equals("gray"); 
                for (var r = 0; r < boardSize; r++)
                {
                    for (var c = 0; c < boardSize; c++)
                    {
                        if (board[r, c].Name == btn.Name)
                        {
                            moveGroupBox.Visible = true;
                            btn.BackColor = Color.Cyan;
                            break;
                        }
                    }
                }
            }
            else
            {
                // Choose a square that contains a piece
            }
        }

        /* BtnCancel_Click reverts color of the square and the number selectors if user wants to select different square */
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            RevertColor();
            selectRow.Value = 1;
            selectColumn.Value = 1;
            moveGroupBox.Visible = false;
        }

        /* BtnMoveChecker_Click is what happens after user selects destination row and column and clicks go
            We will need to put move validation in this method
         */
        private void BtnMoveChecker_Click(object sender, EventArgs e)
        {
            var destRow = int.Parse(selectRow.Text);
            var destCol = int.Parse(selectColumn.Text);
            //if (destRow == 0 || destCol == 8)
            //{
            //    btn.Text = "king"; // Why? 
            //}
            
            for (var row = 0; row < boardSize; row++)
            {
                for (var col = 0; col < boardSize; col++)
                {
                    if (board[row, col].BackColor.Equals(Color.Cyan))
                    {
                        var originBtn = board[row, col];
                        var destBtn = board[destRow - 1, destCol - 1]; 
                        bool grayTeam = board[row, col].Tag.Equals("gray") ? true : false;
                        if (ValidateMove(originBtn, destBtn))
                        {
                            MovePiece(board[destRow - 1, destCol - 1], grayTeam, board[row, col]);
                            selectRow.Value = 1;
                            selectColumn.Value = 1;
                            break;
                        }
                        else
                        {
                            txtInvalidMove.Text = "Invalid Move"; 
                        }

                    }
                }
            }
        }

        /* MovePiece is called by BtnMoveChecker_Click. This actually moves the pieces by changing images */
        public void MovePiece(Button destination, bool grayTeam, Button origin)
        {
            destination.Tag = origin.Tag;
            destination.BackgroundImage = origin.Tag.Equals("gray") ? Properties.Resources.checkerGray : Properties.Resources.checkerWhite;
            destination.BackgroundImageLayout = ImageLayout.Stretch;
            origin.BackgroundImage = Properties.Resources.checkerNone;
            origin.Tag = "none"; 
            moveGroupBox.Visible = false;
            RevertColor(); 
        }

        private bool ValidateMove(Button origin, Button destination)
        {
            return true; 
        }
        
        /* Revert color is a method that changes the color back to what it previously was (after a cancel or move)
         There is a bug here that needs to be fixed. */
        private void RevertColor()
        {
            for (var r = 0; r < boardSize; r++)
            {
                for (var c = 0; c < boardSize; c++)
                {
                    if (board[r, c].BackColor.Equals(Color.Cyan))
                    {
                        if (c == 0)
                        {
                            board[r, c].BackColor = Color.Black;
                        }
                        else
                        {
                            board[r, c].BackColor = board[r, c - 1].BackColor.Equals(Color.Black) ? Color.Red : Color.Black;
                        }
                        break;
                    }
                }
            }
        }


    }
}
