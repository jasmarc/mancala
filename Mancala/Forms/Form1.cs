using System;
using System.Windows.Forms;
using Mancala.Entities;

namespace Mancala.Forms
{
    public partial class Form1 : Form, IView
    {
        public Form1()
        {
            InitializeComponent();
            referree.Board.PropertyChanged += updateTitleBar;
            Text = referree.Board.Turn.ToString();
        }

        private void updateTitleBar(object sender, EventArgs e)
        {
            Text = referree.Board.Turn.ToString();
        }
    }
}
