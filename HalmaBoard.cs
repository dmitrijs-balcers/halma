using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;

namespace Halma_v0._3
{
    class HalmaBoard
    {
        private ArrayList chessTile = new ArrayList();
        private ArrayList chessPieces = new ArrayList();
        private int[,] board = new int[8, 8]; // board array
        private const int TILESIZE = 75;
        public void HalmaGame_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphicsObject = e.Graphics; // obtain graphics object
            graphicsObject.TranslateTransform(0, 24); // adjust origin

            for (int row = 0; row <= board.GetUpperBound(0); row++)
            {
                for (int column = 0; column < board.GetUpperBound(1); column++)
                {
                    graphicsObject.DrawImage((Image)chessTile[board[row, column]], new Point(TILESIZE * column, (TILESIZE * row)));
                } // end loop of columns
            } // end loop of rows
        }
    }
}
