using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HandGestureRecognition
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            video a = new video();
            a.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 ab = new Form1();
            ab.Show();
            
        }

        // chức năng Exit

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("do you want to quit!", "Note", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            == DialogResult.Yes)
                Application.Exit();
        }
    }
}
