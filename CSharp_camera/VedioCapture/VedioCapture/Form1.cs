using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace VedioCapture
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnShow;
		private System.Windows.Forms.PictureBox pictureBoxShow;
		private System.Windows.Forms.Button btnForm2;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button btnShnapShot;
		private System.Windows.Forms.PictureBox pictureBox1;


		private ClassVedioCapture VC = new ClassVedioCapture();


		public Form1()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
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
			this.pictureBoxShow = new System.Windows.Forms.PictureBox();
			this.btnShow = new System.Windows.Forms.Button();
			this.btnForm2 = new System.Windows.Forms.Button();
			this.btnShnapShot = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// pictureBoxShow
			// 
			this.pictureBoxShow.Location = new System.Drawing.Point(6, 5);
			this.pictureBoxShow.Name = "pictureBoxShow";
			this.pictureBoxShow.Size = new System.Drawing.Size(314, 278);
			this.pictureBoxShow.TabIndex = 0;
			this.pictureBoxShow.TabStop = false;
			// 
			// btnShow
			// 
			this.btnShow.Location = new System.Drawing.Point(200, 295);
			this.btnShow.Name = "btnShow";
			this.btnShow.Size = new System.Drawing.Size(97, 44);
			this.btnShow.TabIndex = 1;
			this.btnShow.Text = "Show";
			this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
			// 
			// btnForm2
			// 
			this.btnForm2.Location = new System.Drawing.Point(416, 375);
			this.btnForm2.Name = "btnForm2";
			this.btnForm2.Size = new System.Drawing.Size(92, 49);
			this.btnForm2.TabIndex = 3;
			this.btnForm2.Text = "Form2";
			this.btnForm2.Click += new System.EventHandler(this.btnForm2_Click);
			// 
			// btnShnapShot
			// 
			this.btnShnapShot.Location = new System.Drawing.Point(421, 299);
			this.btnShnapShot.Name = "btnShnapShot";
			this.btnShnapShot.Size = new System.Drawing.Size(97, 44);
			this.btnShnapShot.TabIndex = 4;
			this.btnShnapShot.Text = "ShnapShot";
			this.btnShnapShot.Click += new System.EventHandler(this.btnShnapShot_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(350, 10);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(314, 278);
			this.pictureBox1.TabIndex = 5;
			this.pictureBox1.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(716, 459);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.btnShnapShot);
			this.Controls.Add(this.btnForm2);
			this.Controls.Add(this.btnShow);
			this.Controls.Add(this.pictureBoxShow);
			this.Name = "Form1";
			this.Text = "摄像头显示程序";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void btnShow_Click(object sender, System.EventArgs e)
		{
			try
			{
				VC.Initialize(this.pictureBoxShow,this.pictureBoxShow.Width,this.pictureBoxShow.Height);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void btnForm2_Click(object sender, System.EventArgs e)
		{
			try
			{
				Form2 frmTemp = new Form2();

				frmTemp.Show();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}			
		}

		private void btnShnapShot_Click(object sender, System.EventArgs e)
		{
			VC.CopyToClipBorad();
			this.pictureBox1.Image = VC.getCaptureImage();

		}


	}
}
