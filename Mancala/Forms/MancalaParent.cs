using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Mancala.Entities.Impl;
using Mancala.Entities.Interface;

namespace Mancala.Forms
{
    public partial class MancalaParent : Form, IView
    {
        public MancalaParent()
        {
            InitializeComponent();

            referree = new Referree
                           {
                               Board = new Board(),
                               View = this
                           };

            SetPlayer(referree.Board.Turn);

            LinkedListNode<ICup> cup = referree.Board.Cups.First;
            button1.DataBindings.Add("Text", cup.Value, "Seeds");
            button1.Tag = cup.Value;
            button1.Click += button_click;

            cup = cup.Next;
            button2.DataBindings.Add("Text", cup.Value, "Seeds");
            button2.Tag = cup.Value;
            button2.Click += button_click;

            cup = cup.Next;
            button3.DataBindings.Add("Text", cup.Value, "Seeds");
            button3.Tag = cup.Value;
            button3.Click += button_click;

            cup = cup.Next;
            button4.DataBindings.Add("Text", cup.Value, "Seeds");
            button4.Tag = cup.Value;
            button4.Click += button_click;

            cup = cup.Next;
            button5.DataBindings.Add("Text", cup.Value, "Seeds");
            button5.Tag = cup.Value;
            button5.Click += button_click;

            cup = cup.Next;
            button6.DataBindings.Add("Text", cup.Value, "Seeds");
            button6.Tag = cup.Value;
            button6.Click += button_click;

            cup = cup.Next;
            label1.DataBindings.Add("Text", cup.Value, "Seeds");

            cup = cup.Next;
            button7.DataBindings.Add("Text", cup.Value, "Seeds");
            button7.Tag = cup.Value;
            button7.Click += button_click;

            cup = cup.Next;
            button8.DataBindings.Add("Text", cup.Value, "Seeds");
            button8.Tag = cup.Value;
            button8.Click += button_click;

            cup = cup.Next;
            button9.DataBindings.Add("Text", cup.Value, "Seeds");
            button9.Tag = cup.Value;
            button9.Click += button_click;

            cup = cup.Next;
            button10.DataBindings.Add("Text", cup.Value, "Seeds");
            button10.Tag = cup.Value;
            button10.Click += button_click;

            cup = cup.Next;
            button11.DataBindings.Add("Text", cup.Value, "Seeds");
            button11.Tag = cup.Value;
            button11.Click += button_click;

            cup = cup.Next;
            button12.DataBindings.Add("Text", cup.Value, "Seeds");
            button12.Tag = cup.Value;
            button12.Click += button_click;

            cup = cup.Next;
            label2.DataBindings.Add("Text", cup.Value, "Seeds");

            toolStripStatusLabelMessage.Visible = false;
        }

        public IReferree referree { get; set; }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void SetPlayer(Player player)
        {
            toolStripStatusLabelPlayer.Text = string.Format("Player: {0}", player);
        }

        public void DisplayMessage(string message)
        {
            toolStripStatusLabelMessage.Visible = true;
            toolStripStatusLabelMessage.Text = message;
            timer1.Start();
        }

        public void DisplayModalMessage(string message)
        {
            MessageBox.Show(message);
            referree.AcknowledgeMessage(message);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabelMessage.Visible = false;
            timer1.Stop();
        }

        private void button_click(object sender, EventArgs e)
        {
            referree.ReceiveMove((ICup)((Button)sender).Tag);
        }
    }
}
