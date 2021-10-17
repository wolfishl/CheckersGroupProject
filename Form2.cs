using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckersGame
{
    public partial class Form2 : Form
    {
        int rowClicked;
        int columnClicked;
        bool validEntry = false;
        Button[,] board;
        public Form2(int row, int column, Button[,] board)
        {
            InitializeComponent();
            rowClicked = row;
            columnClicked = column;
            currentRow.Text = "Current Row: " + row;
            currentColumn.Text = "Current Column: " + column;
            this.board = board;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //TODO: 
        //add conditions for jumping over
        //add code to determine the color of a piece
        //add code to support double jumps
        private void ok_Click(object sender, EventArgs e)
        {
            int.TryParse(rowComboBox.Text, out int comboBoxRow);
            int.TryParse(columnComboBox.Text, out int comboBoxColumn);
            bool grayPiece = true; //figure this out
            Button button = (Button) sender;
            bool kingPiece = button.Text == "king";
            //regular jump
            if ((grayPiece && comboBoxRow == rowClicked + 1) || //gray piece
            (!grayPiece && comboBoxRow == rowClicked - 1) || //white piece
            (kingPiece && comboBoxRow == rowClicked + 1 || //white king
            kingPiece && comboBoxRow == rowClicked - 1)) //gray king
            {
                if (comboBoxColumn == columnClicked + 1 || comboBoxColumn == columnClicked - 1)
                {
                    if (board[--comboBoxRow, --comboBoxColumn].BackgroundImage == null)
                    {
                        errorMessage.Text = "";
                        validEntry = true;
                        if(comboBoxRow == 0 || comboBoxRow == 8)
                        {
                            button.Text = "king";
                        }
                        this.Close();
                    }
                    else
                    {
                        errorMessage.Text = "Invalid move";
                    }
                }
                else
                {
                    errorMessage.Text = "Invalid move";
                }
            }
            //capturing a piece moving forward
            else if ((grayPiece && comboBoxRow == rowClicked + 2) || //gray piece
                 (kingPiece && comboBoxRow == rowClicked + 2)) //white king
            {
                Button middleSquare = (comboBoxColumn == columnClicked + 2) ? board[comboBoxRow, comboBoxColumn] :
                    (comboBoxColumn == columnClicked - 2) ? board[comboBoxRow, comboBoxColumn - 2] : null;

                if (middleSquare.BackgroundImage == null)
                {
                    errorMessage.Text = "Invalid move";
                }
                //else if ()//check if piece is from the same team
                //{
                //    errorMessage.Text = "Invalid move";
                //}
                else
                {
                    //add support to remove the piece that is being captured
                    validEntry = true;
                    this.Close();
                }
            }
            //capturing a piece moving backwards
            else if ((!grayPiece && comboBoxRow == rowClicked - 2) || //white piece
            (kingPiece && comboBoxRow == rowClicked - 2)) //gray king
            {
                Button middleSquare = (comboBoxColumn == columnClicked + 2) ? board[comboBoxRow -2, comboBoxColumn] :
                    (comboBoxColumn == columnClicked - 2) ? board[comboBoxRow -2, comboBoxColumn - 2] : null;

                if (middleSquare.BackgroundImage == null)
                {
                    errorMessage.Text = "Invalid move";
                }
                //else if ()//check if piece is from the same team
                //{
                //    errorMessage.Text = "Invalid move";
                //}
                else
                {
                    //add support to remove the piece that is being captured
                    validEntry = true;
                    this.Close();
                }
            }

            else
                {
                    errorMessage.Text = "Invalid move";
                }

            }          
  
        public int getComboBoxRow()
        {
            return int.Parse(rowComboBox.Text);
        }

        public int getComboBoxColumn()
        {
            return int.Parse(columnComboBox.Text);
        }

        public bool getValidEntry()
        {
            return validEntry;
        }

        //there's something wrong with this function
        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
