using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Halma_v0._3
{
    class Pawn
    {
        private Color color;
        public void setColor(Color color)
        {
            this.color = color;
        }
        public Color getColor()
        {
            return this.color;    //1
        }
    }
}
