/**********************************************************************************
 * 
 * 作者：Neil
 * 
 * 开发时间：2006-06-20 晚！
 * 
 * 功能：调用摄像头进行显示
 * 
 * 
 * ********************************************************************************/

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using CameraDemo.Core;

namespace CameraDemo
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnPlay;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Panel pVideo;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;


		/// <summary>
		/// 声明Camera类
		/// </summary>
		Camera ca = null;

		public MainForm()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.pVideo = new System.Windows.Forms.Panel();
			this.btnPlay = new System.Windows.Forms.Button();
			this.btnStop = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// pVideo
			// 
			this.pVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.pVideo.BackColor = System.Drawing.Color.Black;
			this.pVideo.Location = new System.Drawing.Point(8, 8);
			this.pVideo.Name = "pVideo";
			this.pVideo.Size = new System.Drawing.Size(336, 288);
			this.pVideo.TabIndex = 0;
			// 
			// btnPlay
			// 
			this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnPlay.Location = new System.Drawing.Point(368, 72);
			this.btnPlay.Name = "btnPlay";
			this.btnPlay.TabIndex = 1;
			this.btnPlay.Text = "播放";
			this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
			// 
			// btnStop
			// 
			this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnStop.Location = new System.Drawing.Point(368, 120);
			this.btnStop.Name = "btnStop";
			this.btnStop.TabIndex = 2;
			this.btnStop.Text = "停止";
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// btnClose
			// 
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnClose.Location = new System.Drawing.Point(368, 168);
			this.btnClose.Name = "btnClose";
			this.btnClose.TabIndex = 3;
			this.btnClose.Text = "关闭";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(458, 311);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnStop);
			this.Controls.Add(this.btnPlay);
			this.Controls.Add(this.pVideo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "CameraDemo";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void MainForm_Load(object sender, System.EventArgs e)
		{
			//初始化Camera
			ca = new Camera(pVideo.Handle,pVideo.Width,pVideo.Height);

			try
			{
				ca.StartWebCam();
				//如果能够初始化摄像头则设置按钮状态为已经开始播放
				btnPlay.Enabled = false;
				btnStop.Enabled = true;
			}
			catch(Exception ex)
			{
				MessageBox.Show("未能初始化摄像头！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				btnPlay.Enabled = true;
				btnStop.Enabled = false;
				ca = null;
			}
		}

		private void btnPlay_Click(object sender, System.EventArgs e)
		{
			btnPlay.Enabled = false;
			btnStop.Enabled = true;

			ca = new Camera(pVideo.Handle,pVideo.Width,pVideo.Height);
			try
			{
				ca.StartWebCam();
			}
			catch(Exception)
			{
				MessageBox.Show("未能初始化摄像头！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				btnPlay.Enabled = true;
				btnStop.Enabled = false;
				ca = null;
			}
		}

		private void btnStop_Click(object sender, System.EventArgs e)
		{
			try
			{
				ca.CloseWebcam();

				btnPlay.Enabled = true;
				btnStop.Enabled = false;
			}
			catch(Exception)
			{
				MessageBox.Show("摄像头关闭失败！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				btnPlay.Enabled = true;
				btnStop.Enabled = false;
				ca = null;
			}
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			try
			{
				ca.CloseWebcam();

				btnPlay.Enabled = true;
				btnStop.Enabled = false;
			}
			catch(Exception)
			{
				MessageBox.Show("摄像头关闭失败！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				btnPlay.Enabled = true;
				btnStop.Enabled = false;
				ca = null;
			}

			//关闭程序
			this.Close();
			Application.Exit();
		}
	}
}
