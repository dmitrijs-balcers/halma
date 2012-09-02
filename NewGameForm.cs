using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Halma_v0._3
{
    public partial class NewGameForm : Form
    {
        public NewGameForm()
        {
            InitializeComponent();
        }

        private void bt_startServer_Click(object sender, EventArgs e)
        {
            bt_twoPlayer.Enabled = true;
            bt_4player.Enabled = true;
            Form1 main = this.Owner as Form1;
            if (main != null)
            {
                bool Flag = true;
                main.startServerFlag = Flag;
            }
        }

        private void bt_twoPlayer_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            if (main != null)
            {
                Board bw = new Board();
                bw.newGame(2);
                this.Close();
            }
        }

        private void bt_4player_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            if (main != null)
            {
                if (main != null)
                {
                    Board bw = new Board();
                    bw.newGame(4);
                    this.Close();
                }
            }
        }

        private void bt_login_Click(object sender, EventArgs e)
        {

        }
    }
}
