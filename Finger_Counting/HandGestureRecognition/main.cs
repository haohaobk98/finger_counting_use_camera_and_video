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

        // click button 1 để chạy chương trình sử dụng video
        private void button1_Click(object sender, EventArgs e)
        {
            video a = new video();
            a.Show();
            
        }

        // click button 2 để chạy chương trình sử dụng camera
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 ab = new Form1();
            ab.Show();
            
        }

        // chức năng Exit

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to quit!", "Note", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            == DialogResult.Yes)
                Application.Exit();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to quit!", "Note", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
           == DialogResult.Yes)
                Application.Exit();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to quit!", "Note", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
           == DialogResult.Yes)
                Application.Exit();
           
        }

        private void cameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 a1 = new Form1();
            a1.Show();
        }

        private void videoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            video a2 = new video();
            a2.Show();
        }

        
    }
}
