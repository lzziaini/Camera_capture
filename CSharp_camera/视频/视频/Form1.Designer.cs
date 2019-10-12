namespace 视频
{
    partial class Camera
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.videoWindow = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(372, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "抓图";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_GetCapture_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(372, 52);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 37);
            this.button2.TabIndex = 0;
            this.button2.Text = "打开";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btn_OpenCapture_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(372, 93);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 37);
            this.button3.TabIndex = 0;
            this.button3.Text = "关闭";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btn_CloseCapture_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(372, 135);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 37);
            this.button4.TabIndex = 1;
            this.button4.Text = "设置";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btn_set_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(372, 181);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 37);
            this.button5.TabIndex = 2;
            this.button5.Text = "录像";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.btn_kinescope_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(372, 223);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 37);
            this.button6.TabIndex = 3;
            this.button6.Text = "停止";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.btn_stopKinescope_Click);
            // 
            // videoWindow
            // 
            this.videoWindow.Location = new System.Drawing.Point(11, 11);
            this.videoWindow.Name = "videoWindow";
            this.videoWindow.Size = new System.Drawing.Size(331, 290);
            this.videoWindow.TabIndex = 4;
            // 
            // Camera
            // 
            this.ClientSize = new System.Drawing.Size(473, 309);
            this.Controls.Add(this.videoWindow);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Camera";
            this.Load += new System.EventHandler(this.Camera_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

