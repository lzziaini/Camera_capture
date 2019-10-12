using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using AForge.Video;
using AForge.Video.DirectShow;

namespace myVideoCap
{
    public partial class Form1 : Form
    {
        FilterInfoCollection videoDevices;
        private Bitmap curBitmap;
        public Form1()
        {
            InitializeComponent();

            try
            {
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (videoDevices.Count == 0)
                {
                    throw new Exception();
                }
                //设备枚举，选择使用
                for (int i = 1, n = videoDevices.Count; i <= n; i++)
                {
                    string cameraName = i + " : " + videoDevices[i - 1].Name;
                    //自检设备端口数从“0”开始计数
                    cameraComboBox1.Items.Add(cameraName);
                    cameraComboBox2.Items.Add(cameraName);
                }

                // check cameras count
                if (videoDevices.Count == 1)
                {
                    cameraComboBox2.Items.Clear();
                    //检测到仅有一个视频设备时，无效化下拉列表2
                    cameraComboBox2.Items.Add("Only one camera found");
                    cameraComboBox2.SelectedIndex = 0;
                    cameraComboBox2.Enabled = false;//获取false值，使之无法对用户做出反应
                }
                else
                {
                    cameraComboBox2.SelectedIndex = 1;
                }
                cameraComboBox1.SelectedIndex = 0;//对第一个视频设备进行处理

                //for (int i = 1, n = videoDevices.Count; i <= n; i++)
                //{
                //    string cameraName = i + ":" + videoDevices[n - 1].Name;
                //    cameraComboBox1.Items.Add(cameraName);
                //    cameraComboBox2.Items.Add(cameraName);
                //}
                //cameraComboBox1.SelectedIndex = 0;
                //cameraComboBox2.SelectedIndex = 0;
            }
            catch
            {
                start1.Enabled = false;
                start2.Enabled = false;

                cameraComboBox1.Items.Add("cameras not founded");
                cameraComboBox2.Items.Add("cameras not founded");

                cameraComboBox1.SelectedIndex = 0;
                cameraComboBox2.SelectedIndex = 1;

                cameraComboBox1.Enabled = false;
                cameraComboBox2.Enabled = false;
            }
        }

        private void start1_Click(object sender, EventArgs e)
        {
            startCameras1();
            start1.Enabled = false;
            stop1.Enabled = true;
            //button3.Enabled = true;
        }
        private void start2_Click(object sender, EventArgs e)
        {
            startCameras2();
            start2.Enabled = false;
            stop2.Enabled = true;
            //button3.Enabled = true;
        }

        private void startCameras1()
        {
            VideoCaptureDevice videoSource1 = new VideoCaptureDevice(videoDevices[cameraComboBox1.SelectedIndex].MonikerString);
            videoSourcePlayer1.VideoSource = videoSource1;
            videoSourcePlayer1.Start();
        }
        private void startCameras2()
        {
            VideoCaptureDevice videoSource2 = new VideoCaptureDevice(videoDevices[cameraComboBox2.SelectedIndex].MonikerString);
            videoSourcePlayer2.VideoSource = videoSource2;
            videoSourcePlayer2.Start();
        }
        private void stop1_Click(object sender, EventArgs e)
        {
            stopCamera1();
            start1.Enabled = true;
            stop1.Enabled = false;         
        }
        private void stop2_Click(object sender, EventArgs e)
        {
            stopCamera2();
            start2.Enabled = true;
            stop2.Enabled = false; 
        }

        private void stopCamera1()
        {
            videoSourcePlayer1.SignalToStop();
            videoSourcePlayer1.WaitForStop();
        }
        private void stopCamera2()
        {
            videoSourcePlayer2.SignalToStop();
            videoSourcePlayer2.WaitForStop();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopCamera1();
            stopCamera2();
        }
        /*
        private void button3_Click(object sender, EventArgs e)
        {
            curBitmap = (Bitmap)videoSourcePlayer2.BackgroundImage;
            if (curBitmap != null)
            { 
                
            }
        }
        */
        
      
        
    }
}
