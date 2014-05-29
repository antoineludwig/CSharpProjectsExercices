/*
 * Created by SharpDevelop.
 * User: Ludwig
 * Date: 28/05/2014
 * Time: 14:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace NURL
{
	/// <summary>
	/// Description of ClassNURL.
	/// </summary>
	public class ClassNURL
	{

		public string GetSource(string url){
			if ((url==null) && (!IsURL(url))){
				var web = new System.Net.WebClient();
				return web.DownloadString(url);
			}
				return"Erreur dans le téléchargement de la source";	
		}
		
		public bool IsURL(string url){
			try{
			var request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
			request.Method = "HEAD";
			var response = (System.Net.HttpWebResponse)request.GetResponse();
			
			return( response.StatusCode == System.Net.HttpStatusCode.OK);
			}
			catch(Exception e){
				Console.WriteLine(e.ToString());
				return false;
			}
		}
		
		public double[] getTime(string url,int nb){
			double[] lestemps = new double[nb];
			DateTime starttime;
			TimeSpan tempsecoule;
			string s;
			for(int i=0;i<nb;i++){
				starttime = DateTime.Now;
				s = GetSource(url);
				tempsecoule = DateTime.Now.Subtract(starttime);
				lestemps[i]=(double)tempsecoule.Milliseconds;
			}
			return lestemps;
		}
		
		public double calculAVG(double[] lestemps){
			double somtemp = 0.0;
			foreach (double temp in lestemps)
			{
			   somtemp += temp;
			}
			return somtemp / lestemps.Length;
		}
		
		public void EcritureFichier(string source,string text){
			System.IO.File.WriteAllText(@source, text);
		}
		
		public bool IsFichier(string nomfichier){
			System.IO.FileStream fic;
			try{
			fic = System.IO.File.Open (nomfichier,System.IO.FileMode.Open);
			}catch(Exception e){
				Console.WriteLine(e.ToString());
				return false;
			}
			return fic.CanWrite;
		}
		
		
		public void save(string chemfic,string txt){
			EcritureFichier(chemfic, txt);
		}
		
		public void AfficheSource(string source){
			string s = GetSource(source);
			Console.WriteLine(s);
		}
		
		public void AfficheTemps(double[] lestemps){
			foreach (double temp in lestemps)
			{
				Console.WriteLine(temp.ToString());
			}
		}
		
		public void AfficheMoy(double[] lestemps){
			Console.WriteLine(calculAVG(lestemps));
		}
	}
}
