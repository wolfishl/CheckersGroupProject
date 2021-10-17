using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;

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

        public void MovingOnClick(object sender)
        {
            Button btn = (Button)sender;
            //this line doesn't work
            bool blackTeam = btn.BackgroundImage == (System.Drawing.Image)(resources.GetObject("square2.BackgroundImage"))? true : false;
            var name = btn.Name;
            if (btn.BackgroundImage != null)
            {
                int x = 0;
                int y = 0;
                bool found = false;
                for (x = 0; x < boardSize; x++)
                {
                    for (y = 0; y < boardSize; y++)
                    {
                        if (board[x, y].Name == name)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (found) break;
                }

                Form2 testDialog = new Form2(x + 1, y + 1, board);
                testDialog.ShowDialog();
                bool valid = false;
                while(!valid)
                {
                    valid = testDialog.getValidEntry();
                    if(valid)
                    {
                        int row = testDialog.getComboBoxRow() - 1;
                        int column = testDialog.getComboBoxColumn() - 1;
                        MovePiece(board[row, column], blackTeam, btn);
                    }
                }
                 
            }
    
        }

        public void MovePiece(Button button, bool blackTeam, Button fromPiece)
        {            
                if (blackTeam)
                {
                    button.BackgroundImage = (System.Drawing.Image)(resources.GetObject("square2.BackgroundImage"));
                }
                else
                {
                    button.BackgroundImage = (System.Drawing.Image)(resources.GetObject("square1.BackgroundImage"));
                }
                button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            fromPiece.BackgroundImage = null;
            
        }

        private void square1_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender); 
        }

        private void square2_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square3_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square4_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square5_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square6_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square7_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square8_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square9_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square10_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square11_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square12_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square13_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square14_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square15_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square16_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square17_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square18_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square19_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square20_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square21_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square22_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square23_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square24_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square25_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square26_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square27_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square28_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square29_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square30_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square31_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square32_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square33_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square34_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square35_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square36_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square37_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square38_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square39_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square40_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square41_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square42_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square43_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square44_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square45_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square46_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square47_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square48_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square49_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square50_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square51_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square52_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square53_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square54_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square55_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square56_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square57_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square58_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square59_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square60_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square61_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square62_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square63_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }

        private void square64_Click(object sender, EventArgs e)
        {
            MovingOnClick(sender);
        }
    }
}
