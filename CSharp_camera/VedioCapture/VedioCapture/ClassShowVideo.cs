using System;
using System.Runtime.InteropServices;

namespace VedioCapture
{
	/// 
	/// avicap ��ժҪ˵����
	/// 
	public class ClassShowVideo
	{
		// ClassShowVideo calls
		[DllImport("avicap32.dll")] public static extern IntPtr capCreateCaptureWindowA(byte[] lpszWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, int nID);
		[DllImport("avicap32.dll")] public static extern bool capGetDriverDescriptionA(short wDriver, byte[] lpszName, int cbName, byte[] lpszVer, int cbVer);
		[DllImport("User32.dll")] public static extern bool SendMessage(IntPtr hWnd, int wMsg, bool wParam, int lParam); 
		[DllImport("User32.dll")] public static extern bool SendMessage(IntPtr hWnd, int wMsg, short wParam, int lParam); 
		[DllImport("User32.dll")] public static extern bool SendMessage(IntPtr hWnd, int wMsg, short wParam, FrameEventHandler lParam); 
		[DllImport("User32.dll")] public static extern bool SendMessage(IntPtr hWnd, int wMsg, int wParam, ref BITMAPINFO lParam);
		[DllImport("User32.dll")] public static extern int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);
		[DllImport("avicap32.dll")]public static extern int capGetVideoFormat(IntPtr hWnd, IntPtr psVideoFormat, int wSize );

		// Constants
		public const int WM_USER = 0x400;
		public const int WS_CHILD = 0x40000000;
		public const int WS_VISIBLE = 0x10000000;
		public const int SWP_NOMOVE = 0x2;
		public const int SWP_NOZORDER = 0x4;
		public const int WM_CAP_DRIVER_CONNECT = WM_USER + 10;
		public const int WM_CAP_DRIVER_DISCONNECT = WM_USER + 11;
		public const int WM_CAP_SET_CALLBACK_FRAME = WM_USER + 5;
		public const int WM_CAP_SET_PREVIEW = WM_USER + 50;
		public const int WM_CAP_SET_PREVIEWRATE = WM_USER + 52;
		public const int WM_CAP_SET_VIDEOFORMAT = WM_USER + 45;
 
		// Structures
		[StructLayout(LayoutKind.Sequential)] public struct VIDEOHDR
		{
			[MarshalAs(UnmanagedType.I4)] public int lpData;
			[MarshalAs(UnmanagedType.I4)] public int dwBufferLength;
			[MarshalAs(UnmanagedType.I4)] public int dwBytesUsed;
			[MarshalAs(UnmanagedType.I4)] public int dwTimeCaptured;
			[MarshalAs(UnmanagedType.I4)] public int dwUser;
			[MarshalAs(UnmanagedType.I4)] public int dwFlags;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst=4)] public int[] dwReserved;
		}

		[StructLayout(LayoutKind.Sequential)] public struct BITMAPINFOHEADER
		{
			[MarshalAs(UnmanagedType.I4)] public Int32 biSize ;
			[MarshalAs(UnmanagedType.I4)] public Int32 biWidth ;
			[MarshalAs(UnmanagedType.I4)] public Int32 biHeight ;
			[MarshalAs(UnmanagedType.I2)] public short biPlanes;
			[MarshalAs(UnmanagedType.I2)] public short biBitCount ;
			[MarshalAs(UnmanagedType.I4)] public Int32 biCompression;
			[MarshalAs(UnmanagedType.I4)] public Int32 biSizeImage;
			[MarshalAs(UnmanagedType.I4)] public Int32 biXPelsPerMeter;
			[MarshalAs(UnmanagedType.I4)] public Int32 biYPelsPerMeter;
			[MarshalAs(UnmanagedType.I4)] public Int32 biClrUsed;
			[MarshalAs(UnmanagedType.I4)] public Int32 biClrImportant;
		} 

		[StructLayout(LayoutKind.Sequential)] public struct BITMAPINFO
		{
			[MarshalAs(UnmanagedType.Struct, SizeConst=40)] public BITMAPINFOHEADER bmiHeader;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst=1024)] public Int32[] bmiColors;
		}
 
		public delegate void FrameEventHandler(IntPtr lwnd, IntPtr lpVHdr);
 
		// Public methods
		public static object GetStructure(IntPtr ptr,ValueType structure)
		{
			return Marshal.PtrToStructure(ptr,structure.GetType());
		}
 
		public static object GetStructure(int ptr,ValueType structure)
		{
			return GetStructure(new IntPtr(ptr),structure);
		}
 
		public static void Copy(IntPtr ptr,byte[] data)
		{
			Marshal.Copy(ptr,data,0,data.Length);
		}
 
		public static void Copy(int ptr,byte[] data)
		{
			Copy(new IntPtr(ptr),data);
		}
 
		public static int SizeOf(object structure)
		{
			return Marshal.SizeOf(structure); 
		}
	}

	//Web Camera Class
	public class WebCamera
	{
		// Constructur
		public WebCamera(IntPtr handle, int width,int height)
		{
			mControlPtr = handle;
			mWidth = width;
			mHeight = height;
		}
 
		// delegate for frame callback
		public delegate void RecievedFrameEventHandler(byte[] data);
		public event RecievedFrameEventHandler RecievedFrame;
 
		private IntPtr lwndC; // Holds the unmanaged handle of the control
		private IntPtr mControlPtr; // Holds the managed pointer of the control
		private int mWidth;
		private int mHeight;
 
		private ClassShowVideo.FrameEventHandler mFrameEventHandler; // Delegate instance for the frame callback - must keep alive! gc should NOT collect it
 
		// Close the web camera
		public void CloseWebcam()
		{
			this.capDriverDisconnect(this.lwndC);
		}
 
		// start the web camera
		public void StartWebCam()
		{
			byte[] lpszName = new byte[100];
			byte[] lpszVer = new byte[100];
 
			ClassShowVideo.capGetDriverDescriptionA(0, lpszName, 100,lpszVer, 100);
			this.lwndC = ClassShowVideo.capCreateCaptureWindowA(lpszName, ClassShowVideo.WS_VISIBLE + ClassShowVideo.WS_CHILD, 0, 0, mWidth, mHeight, mControlPtr, 0);
 
			if (this.capDriverConnect(this.lwndC, 0))
			{
				this.capPreviewRate(this.lwndC, 66);
				this.capPreview(this.lwndC, true);
				ClassShowVideo.BITMAPINFO bitmapinfo = new ClassShowVideo.BITMAPINFO(); 
				bitmapinfo.bmiHeader.biSize = ClassShowVideo.SizeOf(bitmapinfo.bmiHeader);
				bitmapinfo.bmiHeader.biWidth = 352;
				bitmapinfo.bmiHeader.biHeight = 288;
				bitmapinfo.bmiHeader.biPlanes = 1;
				bitmapinfo.bmiHeader.biBitCount = 24;
				this.capSetVideoFormat(this.lwndC, ref bitmapinfo, ClassShowVideo.SizeOf(bitmapinfo));
				this.mFrameEventHandler = new ClassShowVideo.FrameEventHandler(FrameCallBack);
				this.capSetCallbackOnFrame(this.lwndC, this.mFrameEventHandler);
				ClassShowVideo.SetWindowPos(this.lwndC, 0, 0, 0, mWidth , mHeight , 6);
			} 
		}

		// private functions
		private bool capDriverConnect(IntPtr lwnd, short i)
		{
			return ClassShowVideo.SendMessage(lwnd, ClassShowVideo.WM_CAP_DRIVER_CONNECT, i, 0);
		}

		private bool capDriverDisconnect(IntPtr lwnd)
		{
			return ClassShowVideo.SendMessage(lwnd, ClassShowVideo.WM_CAP_DRIVER_DISCONNECT, 0, 0);
		}
 
		private bool capPreview(IntPtr lwnd, bool f)
		{
			return ClassShowVideo.SendMessage(lwnd, ClassShowVideo.WM_CAP_SET_PREVIEW , f, 0);
		}

		private bool capPreviewRate(IntPtr lwnd, short wMS)
		{
			return ClassShowVideo.SendMessage(lwnd, ClassShowVideo.WM_CAP_SET_PREVIEWRATE, wMS, 0);
		}
 
		private bool capSetCallbackOnFrame(IntPtr lwnd, ClassShowVideo.FrameEventHandler lpProc)
		{ 
			return ClassShowVideo.SendMessage(lwnd, ClassShowVideo.WM_CAP_SET_CALLBACK_FRAME, 0, lpProc);
		}

		private bool capSetVideoFormat(IntPtr hCapWnd, ref ClassShowVideo.BITMAPINFO BmpFormat, int CapFormatSize)
		{
			return ClassShowVideo.SendMessage(hCapWnd, ClassShowVideo.WM_CAP_SET_VIDEOFORMAT, CapFormatSize, ref BmpFormat);
		}

		private void FrameCallBack(IntPtr lwnd, IntPtr lpVHdr)
		{
			ClassShowVideo.VIDEOHDR videoHeader = new ClassShowVideo.VIDEOHDR();
			byte[] VideoData;
			videoHeader = (ClassShowVideo.VIDEOHDR)ClassShowVideo.GetStructure(lpVHdr,videoHeader);
			VideoData = new byte[videoHeader.dwBytesUsed];
			ClassShowVideo.Copy(videoHeader.lpData ,VideoData);
			if (this.RecievedFrame != null)
				this.RecievedFrame (VideoData);
		}
	}

}

