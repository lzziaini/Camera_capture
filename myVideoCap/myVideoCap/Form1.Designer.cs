namespace myVideoCap
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.videoSourcePlayer1 = new AForge.Controls.VideoSourcePlayer();
            this.cameraComboBox1 = new System.Windows.Forms.ComboBox();
            this.start1 = new System.Windows.Forms.Button();
            this.stop1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cameraComboBox2 = new System.Windows.Forms.ComboBox();
            this.videoSourcePlayer2 = new AForge.Controls.VideoSourcePlayer();
            this.start2 = new System.Windows.Forms.Button();
            this.stop2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.videoSourcePlayer1);
            this.groupBox1.Controls.Add(this.cameraComboBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 306);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "camera1";
            // 
            // videoSourcePlayer1
            // 
            this.videoSourcePlayer1.Location = new System.Drawing.Point(6, 50);
            this.videoSourcePlayer1.Name = "videoSourcePlayer1";
            this.videoSourcePlayer1.Size = new System.Drawing.Size(352, 228);
            this.videoSourcePlayer1.TabIndex = 0;
            this.videoSourcePlayer1.Text = "videoSourcePlayer1";
            this.videoSourcePlayer1.VideoSource = null;
            // 
            // cameraComboBox1
            // 
            this.cameraComboBox1.FormattingEnabled = true;
            this.cameraComboBox1.Location = new System.Drawing.Point(34, 20);
            this.cameraComboBox1.Name = "cameraComboBox1";
            this.cameraComboBox1.Size = new System.Drawing.Size(315, 20);
            this.cameraComboBox1.TabIndex = 0;
            // 
            // start1
            // 
            this.start1.Location = new System.Drawing.Point(67, 324);
            this.start1.Name = "start1";
            this.start1.Size = new System.Drawing.Size(75, 23);
            this.start1.TabIndex = 1;
            this.start1.Text = "开始1";
            this.start1.UseVisualStyleBackColor = true;
            this.start1.Click += new System.EventHandler(this.start1_Click);
            // 
            // stop1
            // 
            this.stop1.Location = new System.Drawing.Point(252, 324);
            this.stop1.Name = "stop1";
            this.stop1.Size = new System.Drawing.Size(75, 23);
            this.stop1.TabIndex = 2;
            this.stop1.Text = "停止1";
            this.stop1.UseVisualStyleBackColor = true;
            this.stop1.Click += new System.EventHandler(this.stop1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(739, 324);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "边缘检测";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cameraComboBox2);
            this.groupBox2.Controls.Add(this.videoSourcePlayer2);
            this.groupBox2.Location = new System.Drawing.Point(415, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(380, 306);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "camera2";
            // 
            // cameraComboBox2
            // 
            this.cameraComboBox2.FormattingEnabled = true;
            this.cameraComboBox2.Location = new System.Drawing.Point(29, 20);
            this.cameraComboBox2.Name = "cameraComboBox2";
            this.cameraComboBox2.Size = new System.Drawing.Size(315, 20);
            this.cameraComboBox2.TabIndex = 2;
            // 
            // videoSourcePlayer2
            // 
            this.videoSourcePlayer2.Location = new System.Drawing.Point(14, 50);
            this.videoSourcePlayer2.Name = "videoSourcePlayer2";
            this.videoSourcePlayer2.Size = new System.Drawing.Size(352, 228);
            this.videoSourcePlayer2.TabIndex = 1;
            this.videoSourcePlayer2.Text = "videoSourcePlayer2";
            this.videoSourcePlayer2.VideoSource = null;
            // 
            // start2
            // 
            this.start2.Location = new System.Drawing.Point(159, 324);
            this.start2.Name = "start2";
            this.start2.Size = new System.Drawing.Size(75, 23);
            this.start2.TabIndex = 5;
            this.start2.Text = "开始2";
            this.start2.UseVisualStyleBackColor = true;
            this.start2.Click += new System.EventHandler(this.start2_Click);
            // 
            // stop2
            // 
            this.stop2.Location = new System.Drawing.Point(346, 324);
            this.stop2.Name = "stop2";
            this.stop2.Size = new System.Drawing.Size(75, 23);
            this.stop2.TabIndex = 6;
            this.stop2.Text = "停止2";
            this.stop2.UseVisualStyleBackColor = true;
            this.stop2.Click += new System.EventHandler(this.stop2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 355);
            this.Controls.Add(this.stop2);
            this.Controls.Add(this.start2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.stop1);
            this.Controls.Add(this.start1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "myVideoCap";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cameraComboBox1;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer1;
        private System.Windows.Forms.Button start1;
        private System.Windows.Forms.Button stop1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox2;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer2;
        private System.Windows.Forms.ComboBox cameraComboBox2;
        private System.Windows.Forms.Button start2;
        private System.Windows.Forms.Button stop2;
    }
}

