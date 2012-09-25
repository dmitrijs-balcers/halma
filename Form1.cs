using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;

namespace Halma_v0._3
{
    public partial class Form1 : Form
    {
        public bool startServerFlag = false;
        private Board m_view;
        public Form1()
        {
            Text = "Halma";
            ClientSize = new Size(600, 600);
            MainMenu menu = new MainMenu();
            MenuItem item = new MenuItem("&File");
            menu.MenuItems.Add(item);
            menu.MenuItems.Add(new MenuItem("&New game", new EventHandler(OnNewGame)));
            menu.MenuItems.Add(new MenuItem("&Quit", new EventHandler(OnExit)));
            Menu = menu;

            m_view = new Board();
            m_view.Location = new Point(0, 0);
            m_view.Size = ClientSize;
            Controls.Add(m_view);
            InitializeComponent();
        }

        private void OnNewGame(object sender, EventArgs ev)
        {
            NewGameForm ng = new NewGameForm();
            ng.Owner = this;
            ng.ShowDialog();
            m_view.Invalidate();
            if (startServerFlag == true)
            {
                startServer();
            }
        }

        public static void startServer()
        {
            // Create and register the channel
            Console.WriteLine("Starting Server...");
            TcpChannel tcpChannel = new TcpChannel(9998);
            ChannelServices.RegisterChannel(tcpChannel);
            Console.WriteLine("TCP channel registered...");
            //Register LoginServer
            //LoginServer loginServer = new LoginServer();
            //Type loginServerType = loginServer.GetType();
            //RemotingConfiguration.RegisterWellKnownServiceType(loginServerType, "LoginServer", WellKnownObjectMode.Singleton);
            Console.WriteLine("LoginServer registered...");
            //GameServer gameServer = new GameServer();
            //Type gameServerType = gameServer.GetType();
            //RemotingConfiguration.RegisterWellKnownServiceType(gameServerType, "GameServer", WellKnownObjectMode.Singleton);
            Console.WriteLine("GameServer registered... ");
            Console.WriteLine("Server started!");
        }

        private void OnExit(object sender, EventArgs ev)
        {
            Close();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            HalmaBoard hb = new HalmaBoard();
            hb.HalmaGame_Paint(sender, e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (m_view != null)
            {
                m_view.Size = ClientSize;
                m_view.Invalidate();
            }
        }
    }
}
