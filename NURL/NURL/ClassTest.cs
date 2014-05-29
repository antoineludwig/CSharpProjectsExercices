/*
 * Created by SharpDevelop.
 * User: Ludwig
 * Date: 28/05/2014
 * Time: 14:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;

namespace NURL
{
	/// <summary>
	/// Classe de test
	/// </summary>
	[TestFixture]
	public class Test
	{
		//TESTS SUR GETSOURCE
//		[Test]
//		[TestCase(@"C:/Temp/fake.html", "<h1>hello</h1>")]
//		public void TestGetSource(string url, string source){
//			var nurl = new ClassNURL();
//			string s = nurl.GetSource(url);
//			Assert.AreEqual(s,source,"Test renvoie bien la bonne source");
//		}

		[Test]
		[TestCase("WrongURL", "Erreur dans le téléchargement de la source")]
		public void TestGetWrongURLSource(string url, string source){
			var nurl = new ClassNURL();
			string s = nurl.GetSource(url);
			Assert.AreEqual(s,source,"Test renvoie bien une erreur");
		}

		//TEST SUR ISURL
		[Test]
		[TestCase("http://www.perdu.com/")]
		public void TestISURL(string url){
			var nurl = new ClassNURL();
			bool b = nurl.IsURL(url);
			Assert.IsTrue(b,"Test renvoie true pour une bonne url");
		}

		[Test]
		[TestCase("WrongURL")]
		public void TestISNOTURL(string url){
			var nurl = new ClassNURL();
			bool b = nurl.IsURL(url);
			Assert.IsFalse(b,"Test renvoie false pour une mauvaise url");
		}

		//TEST SUR CALCULAVG
		[Test]
		public void TestAVG(){
			double[] results = new double[3];
			results[0]=6.3;
			results[1]=2.0;
			results[2]=3.6;
			var nurl = new ClassNURL();
			Assert.AreEqual(3.9666666666666668,nurl.calculAVG(results),"Test renvoie bonne moyenne");
		}

		//TEST SUR ECRITUREFICHIER      
		//TEST ISFICHIER
		[Test]
		[TestCase(@"C:\Temp\test.txt")]
		public void TestIsFichier(string chemfic){
			var nurl = new ClassNURL();
			bool b = nurl.IsFichier(chemfic);
			Assert.IsTrue(b,"Test renvoie true, fichier existant");
		}
		
		[Test]
		[TestCase("wrong")]
		public void TestIsNotFichier(string chemfic){
			var nurl = new ClassNURL();
			bool b = nurl.IsFichier(chemfic);
			Assert.IsFalse(b,"Test renvoie false pour un mauvais chemein de fichier");
		}
		
		[Test]
		[TestCase(@"C:\Temp\test.pdf")]
		public void TestFichierNonSaisissable(string chemfic){
			var nurl = new ClassNURL();
			bool b = nurl.IsFichier(chemfic);
			Assert.IsFalse(b,"Test renvoie false car fichier non saisissable");
		}
		
		//TEST GESTIONARGUMENTS
		[Test]
		//test get
		[TestCase(new string[] {"get", "-url", "http://www.perdu.com/"},true)]
//		[TestCase(new string[] {"get", "-url", "http://www.perdu.com/", "-save", @"C:\Temp\test.txt"},true)]
//		[TestCase(new string[] {"test", "-url", "http://www.perdu.com/", "-times", "5"},true)]
//		[TestCase(new string[] {"test", "-url", "http://www.perdu.com/", "-times", "5", "-avg"},true)]
//		[TestCase(new string[] {"get", "-url", "wrong"},false)]
//		[TestCase(new string[] {"get","-durl", "http://www.perdu.com/"},false)]
//		[TestCase(new string[] {"getd", "-url", "http://www.perdu.com/", "-save", @"C:\Temp\test.txt"},false)]
//		[TestCase(new string[] {"get", "-url","http://www.perdu.com/", "-save", "rrr"},false)]
//		[TestCase(new string[] {"get", "-url", "http://www.perdu.com/", "-savedzz", @"C:\Temp\test.txt"},false)]
//		[TestCase(new string[] {"test", "-urdl", "http://www.perdu.com/", "-times", "5"},false)]
//		[TestCase(new string[] {"testd", "-url", "http://www.perdu.com/", "-times", "5"},false)]
//		[TestCase(new string[] {"test", "-url", "http://www.perdu.com/", "-timesd", "5"},false)]
//		[TestCase(new string[] {"test", "-url", "wrong", "-timesd", "5"},false)]
//		[TestCase(new string[] {" testz", "-url", "http://www.perdu.com/", "-times", "5", "-avg"},false)]
//		[TestCase(new string[] {" test", "-urls", "http://www.perdu.com/", "-timesd", "5", "-avg"},false)]
//		[TestCase(new string[] {" test", "-url", "http://www.perdu.com/", "-times","5", "-avgd"},false)]
//		[TestCase(new string[] {" test", "-url", "wrong", "-times", "5", "-avgd "},false)]
		public void TestArguments(string[] args, bool err){
			var nurl = new ClassNURL();
			var ga = new GestionArguments(args);
			Assert.AreEqual(ga.VerifieArguments(),err,"Gestion des arguments");
		}
	}
}

