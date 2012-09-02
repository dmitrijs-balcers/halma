using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halma_v0._3
{
    class Position
    {
        private int x;
        private int y;
        public bool isEmpty = true;
        public bool isSelected;
        private Pawn pawn;

        public void setPawn(Pawn pawn)
        {
            this.pawn = pawn;

            if (pawn == null && this.pawn != null)
            {
                this.pawn = null;
                this.isEmpty = true;
            }
            else if (this.pawn != null && pawn != null)
            {
                isEmpty = false;
            }
        }

        public Pawn getPawn()
        {
            return this.pawn;
        }

        public int getX()
        {
            return this.x;
        }

        public void setX(int x)
        {
            this.x = x;
        }

        public int getY()
        {
            return this.y;
        }

        public void setY(int y)
        {
            this.y = y;
        }

        public void setPosition(int x, int y) {
            this.x = x;
            this.y = y;
        }
    }
}
