/*******************************************************************
 * 
 * 作者：Neil
 * 
 * 开发时间：2006-06-20
 * 
 * 功能： 系统启动模块
 *  
 * 
 * *****************************************************************/

using System;
using System.Windows.Forms;

namespace CameraDemo
{
	/// <summary>
	/// StartUp 的摘要说明。
	/// </summary>
	public class StartUp
	{
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.DoEvents();
			Application.EnableVisualStyles();
			Application.DoEvents();

			Application.Run(new MainForm());
		}
	}
}
