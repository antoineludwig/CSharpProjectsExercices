/*
 * Created by SharpDevelop.
 * User: Ludwig
 * Date: 29/05/2014
 * Time: 15:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NURL;

namespace NURL
{
	/// <summary>
	/// Description of GestionArguments.
	/// </summary>
	public class GestionArguments
	{
		private string[] args;
		private bool get=false;
		private bool url=false;
		private bool fic=false;
		private bool test=false;
		private bool times=false;
		private bool save=false;
		private bool avg=false;
		
		public GestionArguments(string[] _args)
		{
			args=_args;
		}
		
		public bool VerifieArguments(){
			ClassNURL n = new ClassNURL();
			
			if (args.Length<3 || args.Length>6 || args.Length==4)
				return false;
			
			//3 premiers arguments
			if(args[0].Equals("get",StringComparison.OrdinalIgnoreCase)){
				get=true;
				if(args[1].Equals("-url",StringComparison.OrdinalIgnoreCase)){
					if(n.IsURL(args[2])){
						url=true;
					}else{
						return false;
					}
				}else{
					return false;
				}
			}
			else if(args[0].Equals("test",StringComparison.OrdinalIgnoreCase)){
				test=true;
				if(args[1].Equals("-url",StringComparison.OrdinalIgnoreCase)){
					if(n.IsURL(args[2])){
						url=true;
					}else{
						return false;
					}
				}else{
					return false;
				}
			}else{
				return false;
			}
			
			//autres arguments
			if(args.Length>3){
				if(get){
					if(args[3].Equals("-save",StringComparison.OrdinalIgnoreCase)){
						save=true;
						if(n.IsFichier(args[4])){
							fic=true;
							return true;
						}else{
							return false;
						}
					}else{
						return false;
					}
				}
				if(test){
					if(args[3].Equals("-times",StringComparison.OrdinalIgnoreCase)){
						times=true;
						int i;
						if(Int32.TryParse(args[4], out i)){
							if(args.Length==6){
								if(args[5].Equals("-avg",StringComparison.OrdinalIgnoreCase)){
									avg=true;
									return true;
								}else{
									return false;
								}
							}else{
								return true;
							}
						}else{
							return false;
						}
					}else{
						return false;
					}
				}
			}else{
				if(get) return true;	
				if(test) return false;		
			}
						
			return true;
		}
		
		public void Gestion(){
			if(VerifieArguments()){
				ClassNURL n = new ClassNURL();
				if(get && url){
					n.AfficheSource(args[2]);
				}
				if(get && save && url){
					string s = n.GetSource(args[2]);
					n.EcritureFichier(args[4],s);
				}
				if(test && times){
					double[] lestemps=n.getTime(args[2],int.Parse(args[4]));
					n.AfficheTemps(lestemps);
				}
				if(test && times && avg){
					double[] lestemps=n.getTime(args[2],int.Parse(args[4]));
					n.calculAVG(lestemps);
				}
			}else{
				Console.WriteLine("Erreur dans les arguments");
			}
		}
		
	}
}
