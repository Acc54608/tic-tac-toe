using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public partial class Form1 : Form
    {
        int[,] ticTacToe = new int[3, 3];
        Random rnd1 = new Random();
        Boolean xWin;
        Boolean oWin;
        String arrStr = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void newGame_Click(object sender, EventArgs e)
        {
            arrStr = "";
            xWin = false;
            oWin = false;
            lblWinner.Text = "";
            List<Label> tiles = new List<Label>{ tile1, tile2, tile3, tile4, tile5, tile6, tile7, tile8, tile9 };
            int tile = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    ticTacToe[i, j] = rnd1.Next(2);
                    if (ticTacToe[i, j] == 0)
                        tiles[tile].Text = "O";
                    else
                        tiles[tile].Text = "X";
                    tile++;
                }
            WhoWon(ticTacToe);
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    arrStr += ticTacToe[i, j].ToString();
            label1.Text = arrStr;
        }

        private void WhoWon(int[,] ticTacToe)
        {
            xWin = false;
            oWin = false;

            for (int i = 0; i < 3; i++)
            {
                if (ticTacToe[i, 0] == 0 && ticTacToe[i, 1] == 0 && ticTacToe[i, 2] == 0)
                    oWin = true;
                if (ticTacToe[i, 0] == 1 && ticTacToe[i, 1] == 1 && ticTacToe[i, 2] == 1)
                    xWin = true;

            }

            for (int j = 0; j < 3; j++)
            {
                if (ticTacToe[0, j] == 0 && ticTacToe[1, j] == 0 && ticTacToe[2, j] == 0)
                    oWin = true;
                if (ticTacToe[0, j] == 1 && ticTacToe[1, j] == 1 && ticTacToe[2, j] == 1)
                    xWin = true;
            }

            if (ticTacToe[0, 0] == 0 && ticTacToe[1, 1] == 0 && ticTacToe[2, 2] == 0)
                oWin = true;
            if (ticTacToe[0, 0] == 1 && ticTacToe[1, 1] == 1 && ticTacToe[2, 2] == 1)
                xWin = true;

            if (ticTacToe[0, 2] == 0 && ticTacToe[1, 1] == 0 && ticTacToe[2, 0] == 0)
                oWin = true;
            if (ticTacToe[0, 2] == 1 && ticTacToe[1, 1] == 1 && ticTacToe[2, 0] == 1)
                xWin = true;

            if (xWin && oWin)
                lblWinner.Text = "It's a Tie";
            if (!xWin && !oWin)
                lblWinner.Text = "Both lost :(";
            if (xWin && !oWin)
                lblWinner.Text = "X Wins!";
            if (oWin && !xWin)
                lblWinner.Text = "O Wins!";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
