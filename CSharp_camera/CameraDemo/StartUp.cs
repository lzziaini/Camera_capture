/*******************************************************************
 * 
 * ���ߣ�Neil
 * 
 * ����ʱ�䣺2006-06-20
 * 
 * ���ܣ� ϵͳ����ģ��
 *  
 * 
 * *****************************************************************/

using System;
using System.Windows.Forms;

namespace CameraDemo
{
	/// <summary>
	/// StartUp ��ժҪ˵����
	/// </summary>
	public class StartUp
	{
		/// <summary>
		/// Ӧ�ó��������ڵ㡣
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
