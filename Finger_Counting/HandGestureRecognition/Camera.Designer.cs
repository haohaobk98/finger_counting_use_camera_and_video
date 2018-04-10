namespace HandGestureRecognition
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
            this.components = new System.ComponentModel.Container();
            this.imageBoxFrameGrabber = new Emgu.CV.UI.ImageBox();
            this.imageBoxSkin = new Emgu.CV.UI.ImageBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxSkin)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageBoxFrameGrabber
            // 
            this.imageBoxFrameGrabber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imageBoxFrameGrabber.Location = new System.Drawing.Point(48, 12);
            this.imageBoxFrameGrabber.Name = "imageBoxFrameGrabber";
            this.imageBoxFrameGrabber.Size = new System.Drawing.Size(466, 341);
            this.imageBoxFrameGrabber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBoxFrameGrabber.TabIndex = 2;
            this.imageBoxFrameGrabber.TabStop = false;
            this.toolTip1.SetToolTip(this.imageBoxFrameGrabber, "Click right mouse to use some functions");
            // 
            // imageBoxSkin
            // 
            this.imageBoxSkin.Location = new System.Drawing.Point(520, 12);
            this.imageBoxSkin.Name = "imageBoxSkin";
            this.imageBoxSkin.Size = new System.Drawing.Size(471, 341);
            this.imageBoxSkin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBoxSkin.TabIndex = 3;
            this.imageBoxSkin.TabStop = false;
            this.toolTip1.SetToolTip(this.imageBoxSkin, "Click right mouse to use some functions");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1003, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click_1);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(791, 359);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 380);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.imageBoxSkin);
            this.Controls.Add(this.imageBoxFrameGrabber);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "filevideo";
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxSkin)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBoxFrameGrabber;
        private Emgu.CV.UI.ImageBox imageBoxSkin;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}