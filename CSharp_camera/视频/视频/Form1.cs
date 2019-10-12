using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.Drawing.Imaging;  

namespace 视频
{
    public partial class Camera : System.Windows.Forms.Form
    {
        private int hHwnd;
        public string fileName = "*";//照片的文件名 
        public int width = 240;//照片的尺寸为宽度：240，高度：320，即：240*320 
        public int height = 320;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Panel videoWindow;
        public bool isOpen = false;

        /// <summary>  
        /// 必需的设计器变量。  
        /// </summary>  
        [DllImport("avicap32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int capCreateCaptureWindowA([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpszWindowName, int dwStyle, int x, int y, int nWidth, short nHeight, int hWndParent, int nID);
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool DestroyWindow(int hndw);
        [DllImport("user32", EntryPoint = "SendMessageA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int SendMessage(int hwnd, int wMsg, int wParam, [MarshalAs(UnmanagedType.AsAny)] object lParam);
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int SetWindowPos(int hwnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);

        public Camera()
        {
            InitializeComponent();
        }
        private void OpenCapture()
        {
            int intWidth = this.videoWindow.Width;
            int intHeight = this.videoWindow.Height;
            int intDevice = 0;
            string refDevice = intDevice.ToString();
            hHwnd = Camera.capCreateCaptureWindowA(ref refDevice, 1342177280, 0, 0, 640, 480, this.videoWindow.Handle.ToInt32(), 0);

            if (Camera.SendMessage(hHwnd, 0x40a, intDevice, 0) > 0)
            {
                Camera.SendMessage(this.hHwnd, 0x435, -1, 0);
                Camera.SendMessage(this.hHwnd, 0x434, 0x42, 0);
                Camera.SendMessage(this.hHwnd, 0x432, -1, 0);
                Camera.SetWindowPos(this.hHwnd, 1, 0, 0, intWidth, intHeight, 6);
                isOpen = true;
            }
            else
            {
                Camera.DestroyWindow(this.hHwnd);
                MessageBox.Show("无法找到设备！！");
            }
        }

        private void btn_OpenCapture_Click(object sender, EventArgs e)//打开摄像头，显示视频 
        {
            this.OpenCapture();
        }

        private void btn_GetCapture_Click(object sender, EventArgs e)//抓取图像 
        {
            try
            {
                Camera.SendMessage(this.hHwnd, 0x41e, 0, 0);
                IDataObject obj_camera = Clipboard.GetDataObject();
                if (obj_camera.GetDataPresent(typeof(Bitmap)))
                {
                    Image image_camera = ((Image)obj_camera.GetData(typeof(Bitmap))).GetThumbnailImage(width, height, null, IntPtr.Zero);
                    //设置图片的尺寸为240*320 

                    SaveFileDialog SaveFileDialog_camera = new SaveFileDialog();
                    SaveFileDialog_camera.FileName = fileName + ".jpg";
                    SaveFileDialog_camera.Filter = "Image Files(*.JPG)|*.JPG";
                    if (SaveFileDialog_camera.ShowDialog() == DialogResult.OK)
                    {
                        image_camera.Save(SaveFileDialog_camera.FileName, ImageFormat.Jpeg);
                    }
                }
                else
                {
                    MessageBox.Show("摄像头没有开启，不能抓图，请开启摄像头！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("抓取图像时出现错误！", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_CloseCapture_Click(object sender, EventArgs e)//关闭摄像头 
        {
            Camera.SendMessage(this.hHwnd, 0x40b, 0, 0);
            Camera.DestroyWindow(this.hHwnd);

            Clipboard.Clear();//清除剪切板中的内容 
            isOpen = false;
        }
        private void btn_set_Click(object sender, EventArgs e)//对摄像头进行设置 
        {
            if (isOpen)
                Camera.SendMessage(this.hHwnd, 0x42a, 0, 0);
            else
                MessageBox.Show("摄像头没有开启，不能设置，请开启摄像头！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_kinescope_Click(object sender, EventArgs e)//开始录像，录像过程中鼠标成漏斗形，对着图像显示区域单击鼠标左键或右键就结束了录像。 
        {
            if (isOpen)
            {
                SaveFileDialog SaveFileDialog_Video = new SaveFileDialog();
                SaveFileDialog_Video.FileName = fileName + ".avi";
                SaveFileDialog_Video.Filter = "Video Files(*.avi)|*.avi";
                if (SaveFileDialog_Video.ShowDialog() == DialogResult.OK)
                {
                    SendMessage(this.hHwnd, 0x414, 0, SaveFileDialog_Video.FileName);
                    SendMessage(this.hHwnd, 0x43e, 0, 0);
                }
            }
            else
                MessageBox.Show("摄像头没有开启，不能录像，请开启摄像头！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_stopKinescope_Click(object sender, EventArgs e)//停止录像 
        {
            SendMessage(this.hHwnd, 0x444, 0, 0);
        }

 

        private void Camera_Load(object sender, EventArgs e)
        {

        }
    }
}
