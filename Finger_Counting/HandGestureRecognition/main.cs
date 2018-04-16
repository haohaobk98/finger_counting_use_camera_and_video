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

        /// <summary>
        /// click vào hình ảnh video trên giao diện để chạy chương trình sử dụng video
        /// hàm để khởi tạo chương trình chạy bằng video
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Video_Click(object sender, EventArgs e)
        {
            video VideoButton = new video();
            VideoButton.Show();
            
        }

        /// <summary>
        ///  click vào hình ảnh video trên giao diện để chạy chương trình sử dụng camera
        ///  hàm để khởi tạo chương trình chạy bằng camera
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Camera_Click(object sender, EventArgs e)
        {
            Form1 CameraButton = new Form1();
            CameraButton.Show();
            
        }

        /// <summary>
        /// chức năng Exit trên thanh công cụ và khi click chuột phải
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

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
        /// <summary>
        /// Hiển thị các chức năng trên thanh công cụ bao gồm camera và video
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 CameraToolStrip = new Form1();
            CameraToolStrip.Show();
        }

        private void videoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            video VideoToolStrip = new video();
            VideoToolStrip.Show();
        }

        
    }
}
