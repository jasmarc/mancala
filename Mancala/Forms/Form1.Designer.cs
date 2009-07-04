using System.Collections.Generic;
using System.Windows.Forms;
using Mancala.Entities;

namespace Mancala.Forms
{
    partial class Form1
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
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            referree = new Referree()
            {
                Board = new Board()
            };
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            LinkedListNode<ICup> cup = referree.Board.Cups.First;
            this.button1.DataBindings.Add("Text", cup.Value, "Seeds");
            this.button1.Tag = cup.Value;
            this.button1.Location = new System.Drawing.Point(49, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(referree.ReceivedMove);
            // 
            // button2
            // 
            cup = cup.Next;
            this.button2.DataBindings.Add("Text", cup.Value, "Seeds");
            this.button2.Tag = cup.Value;
            this.button2.Location = new System.Drawing.Point(80, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 25);
            this.button2.TabIndex = 0;
            this.button2.Text = "button1";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(referree.ReceivedMove);
            // 
            // button3
            // 
            cup = cup.Next;
            this.button3.DataBindings.Add("Text", cup.Value, "Seeds");
            this.button3.Tag = cup.Value;
            this.button3.Location = new System.Drawing.Point(111, 43);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(25, 25);
            this.button3.TabIndex = 0;
            this.button3.Text = "button1";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(referree.ReceivedMove);
            // 
            // button4
            // 
            cup = cup.Next;
            this.button4.DataBindings.Add("Text", cup.Value, "Seeds");
            this.button4.Tag = cup.Value;
            this.button4.Location = new System.Drawing.Point(142, 43);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(25, 25);
            this.button4.TabIndex = 0;
            this.button4.Text = "button1";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(referree.ReceivedMove);
            // 
            // button5
            // 
            cup = cup.Next;
            this.button5.DataBindings.Add("Text", cup.Value, "Seeds");
            this.button5.Tag = cup.Value;
            this.button5.Location = new System.Drawing.Point(173, 43);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(25, 25);
            this.button5.TabIndex = 0;
            this.button5.Text = "button1";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(referree.ReceivedMove);
            // 
            // button6
            // 
            cup = cup.Next;
            this.button6.DataBindings.Add("Text", cup.Value, "Seeds");
            this.button6.Tag = cup.Value;
            this.button6.Location = new System.Drawing.Point(204, 43);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(25, 25);
            this.button6.TabIndex = 0;
            this.button6.Text = "button1";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(referree.ReceivedMove);
            // 
            // label1
            // 
            cup = cup.Next;
            this.label1.DataBindings.Add("Text", cup.Value, "Seeds");
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "A";
            // 
            // button7
            // 
            cup = cup.Next;
            this.button7.DataBindings.Add("Text", cup.Value, "Seeds");
            this.button7.Tag = cup.Value;
            this.button7.Location = new System.Drawing.Point(204, 12);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(25, 25);
            this.button7.TabIndex = 0;
            this.button7.Text = "button1";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(referree.ReceivedMove);
            // 
            // button8
            // 
            cup = cup.Next;
            this.button8.DataBindings.Add("Text", cup.Value, "Seeds");
            this.button8.Tag = cup.Value;
            this.button8.Location = new System.Drawing.Point(173, 12);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(25, 25);
            this.button8.TabIndex = 0;
            this.button8.Text = "button1";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            cup = cup.Next;
            this.button9.DataBindings.Add("Text", cup.Value, "Seeds");
            this.button9.Tag = cup.Value;
            this.button9.Location = new System.Drawing.Point(142, 12);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(25, 25);
            this.button9.TabIndex = 0;
            this.button9.Text = "button1";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            cup = cup.Next;
            this.button10.DataBindings.Add("Text", cup.Value, "Seeds");
            this.button10.Tag = cup.Value;
            this.button10.Location = new System.Drawing.Point(111, 12);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(25, 25);
            this.button10.TabIndex = 0;
            this.button10.Text = "button1";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            cup = cup.Next;
            this.button11.DataBindings.Add("Text", cup.Value, "Seeds");
            this.button11.Tag = cup.Value;
            this.button11.Location = new System.Drawing.Point(80, 12);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(25, 25);
            this.button11.TabIndex = 0;
            this.button11.Text = "button1";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            cup = cup.Next;
            this.button12.DataBindings.Add("Text", cup.Value, "Seeds");
            this.button12.Tag = cup.Value;
            this.button12.Location = new System.Drawing.Point(49, 12);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(25, 25);
            this.button12.TabIndex = 0;
            this.button12.Text = "button1";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(235, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(31, 56);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            cup = cup.Next;
            this.label2.DataBindings.Add("Text", cup.Value, "Seeds");
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "A";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(31, 56);
            this.panel2.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 84);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public IReferree referree { get; set; }
        private Button[] buttons;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
    }
}