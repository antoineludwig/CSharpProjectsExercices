/*
 * Created by SharpDevelop.
 * User: Ludwig
 * Date: 29/05/2014
 * Time: 11:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace NURL
{
	/// <summary>
	/// Description of Program.
	/// </summary>
	public class Program
	{
		public static void Main(string[] args)
		{
				ClassNURL nurl = new ClassNURL();
				Uri myuri;
			Console.WriteLine(Uri.TryCreate("",UriKind.RelativeOrAbsolute,out myuri));
			Console.ReadLine();
			
		}
	}
}