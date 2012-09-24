namespace Halma_v0._3
{
    partial class NewGameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }    // 12123asd
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_startServer = new System.Windows.Forms.Button();
            this.bt_login = new System.Windows.Forms.Button();
            this.bt_twoPlayer = new System.Windows.Forms.Button();
            this.bt_4player = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_startServer
            // 
            this.bt_startServer.Location = new System.Drawing.Point(13, 13);
            this.bt_startServer.Name = "bt_startServer";
            this.bt_startServer.Size = new System.Drawing.Size(75, 23);
            this.bt_startServer.TabIndex = 0;
            this.bt_startServer.Text = "Start Server";
            this.bt_startServer.UseVisualStyleBackColor = true;
            this.bt_startServer.Click += new System.EventHandler(this.bt_startServer_Click);
            // 
            // bt_login
            // 
            this.bt_login.Location = new System.Drawing.Point(13, 43);
            this.bt_login.Name = "bt_login";
            this.bt_login.Size = new System.Drawing.Size(75, 23);
            this.bt_login.TabIndex = 1;
            this.bt_login.Text = "Login";
            this.bt_login.UseVisualStyleBackColor = true;
            this.bt_login.Click += new System.EventHandler(this.bt_login_Click);
            // 
            // bt_twoPlayer
            // 
            this.bt_twoPlayer.Enabled = false;
            this.bt_twoPlayer.Location = new System.Drawing.Point(13, 73);
            this.bt_twoPlayer.Name = "bt_twoPlayer";
            this.bt_twoPlayer.Size = new System.Drawing.Size(75, 23);
            this.bt_twoPlayer.TabIndex = 2;
            this.bt_twoPlayer.Text = "2 Player";
            this.bt_twoPlayer.UseVisualStyleBackColor = true;
            this.bt_twoPlayer.Click += new System.EventHandler(this.bt_twoPlayer_Click);
            // 
            // bt_4player
            // 
            this.bt_4player.Enabled = false;
            this.bt_4player.Location = new System.Drawing.Point(13, 103);
            this.bt_4player.Name = "bt_4player";
            this.bt_4player.Size = new System.Drawing.Size(75, 23);
            this.bt_4player.TabIndex = 3;
            this.bt_4player.Text = "4 player";
            this.bt_4player.UseVisualStyleBackColor = true;
            this.bt_4player.Click += new System.EventHandler(this.bt_4player_Click);
            // 
            // NewGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.bt_4player);
            this.Controls.Add(this.bt_twoPlayer);
            this.Controls.Add(this.bt_login);
            this.Controls.Add(this.bt_startServer);
            this.Name = "NewGameForm";
            this.Text = "NewGameForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_startServer;
        private System.Windows.Forms.Button bt_login;
        private System.Windows.Forms.Button bt_twoPlayer;
        private System.Windows.Forms.Button bt_4player;
    }
}