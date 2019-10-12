using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Kinect;

namespace KinectDepthImageDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private KinectSensor kinect;
        private WriteableBitmap depthImageBitMap;
        private Int32Rect depthImageBitmapRect;
        private Int32 depthImageStride;
        private DepthImageFrame lastDepthFrame;
        private short[] depthPixelDate;

        public KinectSensor Kinnect
        {
            get { return kinect; }
            set
            {
                if (kinect != null)
                {
                    UninitializeKinectSensor(this.kinect);
                    kinect = null;
                }
                if (value != null && value.Status == KinectStatus.Connected)
                {
                    kinect = value;
                    InitializeKinectSensor(this.kinect);
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += (s, e) => DiscoverKinectSensor();
            this.Unloaded += (s, e) => this.kinect = null;
        }

        private void DiscoverKinectSensor()
        {
            KinectSensor.KinectSensors.StatusChanged += new EventHandler<StatusChangedEventArgs>(KinectSensors_StatusChanged);
            this.Kinnect = KinectSensor.KinectSensors.FirstOrDefault(sensor => sensor.Status == KinectStatus.Connected);
        }

        void KinectSensors_StatusChanged(object sender, StatusChangedEventArgs e)
        {
            switch (e.Status)
            {
                case KinectStatus.Connected:
                    if (this.kinect == null)
                        this.kinect = e.Sensor;
                    break;
                case KinectStatus.Disconnected:
                    if (this.kinect == e.Sensor)
                    {
                        this.kinect = null;
                        this.kinect = KinectSensor.KinectSensors.FirstOrDefault(x => x.Status == KinectStatus.Connected);
                        if (this.kinect == null)
                        {
                            //TODO:通知用于Kinect已拔出
                        }
                    }
                    break;
                //TODO:处理其他情况下的状态
            }
        }

        private void InitializeKinectSensor(KinectSensor kinectSensor)
        {
            if (kinectSensor != null)
            {
                DepthImageStream depthStream = kinectSensor.DepthStream;
                depthStream.Enable();

                depthImageBitMap = new WriteableBitmap(depthStream.FrameWidth, depthStream.FrameHeight, 96, 96,
                                                                            PixelFormats.Gray16, null);
                depthImageBitmapRect = new Int32Rect(0, 0, depthStream.FrameWidth, depthStream.FrameHeight);
                depthImageStride = depthStream.FrameWidth * depthStream.FrameBytesPerPixel;
                DepthImage.Source = depthImageBitMap;
                kinectSensor.DepthFrameReady += new EventHandler<DepthImageFrameReadyEventArgs>(kinectSensor_DepthFrameReady);
                kinectSensor.Start();
            }
        }

        private void UninitializeKinectSensor(KinectSensor kinect)
        {
            if (kinect != null)
            {
                kinect.Stop();
                kinect.DepthFrameReady -= new EventHandler<DepthImageFrameReadyEventArgs>(kinectSensor_DepthFrameReady);
            }
        }

        void kinectSensor_DepthFrameReady(object sender, DepthImageFrameReadyEventArgs e)
        {
            if (lastDepthFrame != null)
            {
                lastDepthFrame.Dispose();
                lastDepthFrame = null;
            }
            lastDepthFrame = e.OpenDepthImageFrame();
            if (lastDepthFrame != null)
            {
                depthPixelDate = new short[lastDepthFrame.PixelDataLength];
                lastDepthFrame.CopyPixelDataTo(depthPixelDate);
                depthImageBitMap.WritePixels(depthImageBitmapRect, depthPixelDate, depthImageStride, 0);

           
             //   CreateLighterShadesOfGray(this.lastDepthFrame, depthPixelDate);
             //    CreateBetterShadesOfGray(this.lastDepthFrame, depthPixelDate);  
               CreateColorDepthImage(this.lastDepthFrame, depthPixelDate);
            //   DepthImage.MouseLeftButtonUp += new EventHandler<MouseButtonEventArgs>(DepthImage_MouseLeftButtonUp);
            }
        }

        private void DepthImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(DepthImage);
            if (depthPixelDate != null && depthPixelDate.Length > 0)
            {
                Int32 pixelIndex = (Int32)(p.X + ((Int32)p.Y * this.lastDepthFrame.Width));
                Int32 depth = this.depthPixelDate[pixelIndex] >> DepthImageFrame.PlayerIndexBitmaskWidth;
                Int32 depthInches = (Int32)(depth * 0.0393700787);
                Int32 depthFt = depthInches / 12;
                depthInches = depthInches % 12;
                  PixelDepth.Text = String.Format("{0}mm~{1}'{2}", depth, depthFt, depthInches);
            }
        }   

        private void CreateLighterShadesOfGray(DepthImageFrame depthFrame, short[] pixelData)
        {
            Int32 depth;
            Int32 loThreashold = 0;
            Int32 hiThreshold = 3500;
            short[] enhPixelData = new short[depthFrame.Width * depthFrame.Height];
            for (int i = 0; i < pixelData.Length; i++)
            {
                depth = pixelData[i] >> DepthImageFrame.PlayerIndexBitmaskWidth;
                if (depth < loThreashold || depth > hiThreshold)
                {
                    enhPixelData[i] = 0xFF;
                }
                else
                {
                    enhPixelData[i] = (short)~pixelData[i];
                }

            }
            EnhancedDepthImage.Source = BitmapSource.Create(depthFrame.Width, depthFrame.Height, 96, 96, PixelFormats.Gray16, null, enhPixelData, depthFrame.Width * depthFrame.BytesPerPixel);
        }


        private void CreateBetterShadesOfGray(DepthImageFrame depthFrame, short[] pixelData)
        {
            Int32 depth;
            Int32 gray;
            Int32 loThreashold = 0;
            Int32 bytePerPixel = 4;
            Int32 hiThreshold = 3500;
            byte[] enhPixelData = new byte[depthFrame.Width * depthFrame.Height * bytePerPixel];
            for (int i = 0, j = 0; i < pixelData.Length; i++, j += bytePerPixel)
            {
                depth = pixelData[i] >> DepthImageFrame.PlayerIndexBitmaskWidth;
                if (depth < loThreashold || depth > hiThreshold)
                {
                    gray = 0xFF;
                }
                else
                {
                    gray = (255 * depth / 0xFFF);
                }
                enhPixelData[j] = (byte)gray;
                enhPixelData[j + 1] = (byte)gray;
                enhPixelData[j + 2] = (byte)gray;

            }
            EnhancedDepthImage.Source = BitmapSource.Create(depthFrame.Width, depthFrame.Height, 96, 96, PixelFormats.Bgr32, null, enhPixelData, depthFrame.Width * bytePerPixel);
        }


        private void CreateColorDepthImage(DepthImageFrame depthFrame, short[] pixelData)
        {
            Int32 depth;
            Double hue;
            Int32 loThreshold = 1200;
            Int32 hiThreshold = 3500;
            Int32 bytesPerPixel = 4;
            byte[] rgb = new byte[3];
            byte[] enhPixelData = new byte[depthFrame.Width * depthFrame.Height * bytesPerPixel];

            for (int i = 0, j = 0; i < pixelData.Length; i++, j += bytesPerPixel)
            {
                depth = pixelData[i] >> DepthImageFrame.PlayerIndexBitmaskWidth;

                if (depth < loThreshold || depth > hiThreshold)
                {
                    enhPixelData[j] = 0x00;
                    enhPixelData[j + 1] = 0x00;
                    enhPixelData[j + 2] = 0x00;
                }
                else
                {
                    hue = ((360 * depth / 0xFFF) + loThreshold);
                    ConvertHslToRgb(hue, 100, 100, rgb);

                    enhPixelData[j] = rgb[2];  //Blue
                    enhPixelData[j + 1] = rgb[1];  //Green
                    enhPixelData[j + 2] = rgb[0];  //Red
                }
            }

            EnhancedDepthImage.Source = BitmapSource.Create(depthFrame.Width, depthFrame.Height, 96, 96, PixelFormats.Bgr32, null, enhPixelData, depthFrame.Width * bytesPerPixel);
        }

        public void ConvertHslToRgb(double hue, double saturation, double lightness, byte[] rgb)
        {
            double red = 0.0;
            double green = 0.0;
            double blue = 0.0;
            hue = hue % 360.0;
            saturation = saturation / 100.0;
            lightness = lightness / 100.0;

            if (saturation == 0.0)
            {
                red = lightness;
                green = lightness;
                blue = lightness;
            }
            else
            {
                double huePrime = hue / 60.0;
                int x = (int)huePrime;
                double xPrime = huePrime - (double)x;
                double L0 = lightness * (1.0 - saturation);
                double L1 = lightness * (1.0 - (saturation * xPrime));
                double L2 = lightness * (1.0 - (saturation * (1.0 - xPrime)));

                switch (x)
                {
                    case 0:
                        red = lightness;
                        green = L2;
                        blue = L0;
                        break;
                    case 1:
                        red = L1;
                        green = lightness;
                        blue = L0;
                        break;
                    case 2:
                        red = L0;
                        green = lightness;
                        blue = L2;
                        break;
                    case 3:
                        red = L0;
                        green = L1;
                        blue = lightness;
                        break;
                    case 4:
                        red = L2;
                        green = L0;
                        blue = lightness;
                        break;
                    case 5:
                        red = lightness;
                        green = L0;
                        blue = L1;
                        break;
                }
            }

            rgb[0] = (byte)(255.0 * red);
            rgb[1] = (byte)(255.0 * green);
            rgb[2] = (byte)(255.0 * blue);
        }
    }
}
