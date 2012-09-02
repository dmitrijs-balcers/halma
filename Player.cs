using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halma_v0._3
{
    class Player
    {
        private int m_quantityOfPawns;
        public int quantityOfPawns
        {
            get
            {
                return this.m_quantityOfPawns;
            }

            set 
            {
                m_quantityOfPawns = value;
                if (m_quantityOfPawns == 0)
                    m_isPawnsSetted = true;
            }
        }
        public int firstPawnXposition;

        private bool m_isPawnsSetted;
        public bool isPawnsSetted
        {
            get { return m_isPawnsSetted; }
            set { m_isPawnsSetted = value; }
        }

        public Player(int quantityOfPawns, int firstPawnXposition, bool isPawnsSetted) {
            this.quantityOfPawns = quantityOfPawns;
            this.firstPawnXposition = firstPawnXposition;
            this.isPawnsSetted = isPawnsSetted;
        }
    }
}
