using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace VedioCapture
{
	/// 
	/// Form2 的摘要说明。
	/// 
	public class Form2 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panelPreview;
		private System.Windows.Forms.Button b_play;
		private System.Windows.Forms.Button b_stop;
		/// 
		/// 必需的设计器变量。
		/// 
		private System.ComponentModel.Container components = null;
		WebCamera wc;

		public Form2()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// 
		/// 清理所有正在使用的资源。
		/// 
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
		/// 
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// 
		private void InitializeComponent()
		{
			this.b_play = new System.Windows.Forms.Button();
			this.panelPreview = new System.Windows.Forms.Panel();
			this.b_stop = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// b_play
			// 
			this.b_play.Location = new System.Drawing.Point(280, 368);
			this.b_play.Name = "b_play";
			this.b_play.TabIndex = 0;
			this.b_play.Text = "&Play";
			this.b_play.Click += new System.EventHandler(this.button1_Click);
			// 
			// panelPreview
			// 
			this.panelPreview.Location = new System.Drawing.Point(8, 8);
			this.panelPreview.Name = "panelPreview";
			this.panelPreview.Size = new System.Drawing.Size(344, 272);
			this.panelPreview.TabIndex = 1;
			// 
			// b_stop
			// 
			this.b_stop.Enabled = false;
			this.b_stop.Location = new System.Drawing.Point(360, 368);
			this.b_stop.Name = "b_stop";
			this.b_stop.TabIndex = 2;
			this.b_stop.Text = "&Stop";
			this.b_stop.Click += new System.EventHandler(this.b_stop_Click);
			// 
			// Form2
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(464, 413);
			this.Controls.Add(this.b_stop);
			this.Controls.Add(this.panelPreview);
			this.Controls.Add(this.b_play);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form2";
			this.Text = "GoodView test Web Camera";
			this.Load += new System.EventHandler(this.Form2_Load);
			this.ResumeLayout(false);

		}
		#endregion


		private void Form2_Load(object sender, System.EventArgs e)
		{
			b_play.Enabled = false;
			b_stop.Enabled = true;
			panelPreview.Size = new Size(330,330);
			wc = new WebCamera( panelPreview.Handle,panelPreview.Width,panelPreview.Height);
			wc.StartWebCam();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			b_play.Enabled = false;
			b_stop.Enabled = true;
			panelPreview.Size = new Size(330,330);
			wc = new WebCamera( panelPreview.Handle,panelPreview.Width,panelPreview.Height);
			wc.StartWebCam();
		}

		private void b_stop_Click(object sender, System.EventArgs e)
		{
			b_play.Enabled = true;
			b_stop.Enabled = false;
			wc.CloseWebcam();
		}
	}
}

