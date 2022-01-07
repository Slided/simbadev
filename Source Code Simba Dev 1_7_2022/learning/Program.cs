using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace learning
{
	internal class Program
	{
		public Program()
		{
		}

		[DebuggerStepThrough]
		private static void <Main>(string[] args)
		{
			Program.Main(args).GetAwaiter().GetResult();
		}

		private static void exit()
		{
			Environment.Exit(0);
		}

		private static async Task launchAsync()
		{
			string tempPath = Path.GetTempPath();
			string str = "";
			string str1 = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Epic\\UnrealEngineLauncher\\LauncherInstalled.dat"));
			dynamic obj = JsonConvert.DeserializeObject(str1);
			foreach (dynamic obj1 in (IEnumerable)obj.InstallationList)
			{
				if (obj1.AppName == "Fortnite")
				{
					str = (string)(obj1.InstallLocation.ToString() + "\\FortniteGame\\Binaries\\Win64");
				}
			}
			WebClient webClient = new WebClient();
			await webClient.DownloadFileTaskAsync("https://anticheatnoningame.simbadev.repl.co/download.exe", string.Concat(tempPath, "\\FortniteClient-Win64-Shipping_EAC.exe"));
			await webClient.DownloadFileTaskAsync("https://anticheatnoningame.simbadev.repl.co/download.exe", string.Concat(tempPath, "\\FortniteClient-Win64-Shipping_BE.exe"));
			if (File.Exists(string.Concat(str, "\\FortniteClient-Win64-Shipping_EAC.exe")))
			{
				File.Delete(string.Concat(str, "\\FortniteClient-Win64-Shipping_EAC.exe"));
				File.Move(string.Concat(tempPath, "\\FortniteClient-Win64-Shipping_EAC.exe"), string.Concat(str, "\\FortniteClient-Win64-Shipping_EAC.exe"));
			}
			else
			{
				File.Move(string.Concat(tempPath, "\\FortniteClient-Win64-Shipping_EAC.exe"), string.Concat(str, "\\FortniteClient-Win64-Shipping_EAC.exe"));
			}
			if (File.Exists(string.Concat(str, "\\FortniteClient-Win64-Shipping_BE.exe")))
			{
				File.Delete(string.Concat(str, "\\FortniteClient-Win64-Shipping_BE.exe"));
				File.Move(string.Concat(tempPath, "\\FortniteClient-Win64-Shipping_BE.exe"), string.Concat(str, "\\FortniteClient-Win64-Shipping_BE.exe"));
			}
			else
			{
				File.Move(string.Concat(tempPath, "\\FortniteClient-Win64-Shipping_BE.exe"), string.Concat(str, "\\FortniteClient-Win64-Shipping_BE.exe"));
			}
			ProcessStartInfo processStartInfo = new ProcessStartInfo()
			{
				CreateNoWindow = true,
				FileName = "cmd.exe",
				Arguments = "/C start com.epicgames.launcher://apps/Fortnite?action=launch&silent=true"
			};
			Process.Start(processStartInfo);
			tempPath = null;
			str = null;
			str1 = null;
			obj = null;
			webClient = null;
			processStartInfo = null;
		}

		private static async Task Main(string[] args)
		{
			Console.Title = "SimbaDev";
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WindowHeight = 20;
			Console.WindowWidth = 80;
			Console.WriteLine("1: Launch");
			Console.WriteLine("2: Play Normal Fortnite");
			Console.WriteLine("3: exit");
			Console.WriteLine(" ");
			Console.Write("Choose a option: ");
			int num = Convert.ToInt32(Console.ReadLine());
			string[] strArrays = new string[] { "FortniteClient-Win64-Shipping_EAC.exe", "FortniteClient-Win64-Shipping_BE.exe", "FortniteLauncher.exe" };
			string[] strArrays1 = strArrays;
			for (int i = 0; i < (int)strArrays1.Length; i++)
			{
				string str = strArrays1[i];
				Process[] processesByName = Process.GetProcessesByName(str);
				Process[] processArray = processesByName;
				for (int j = 0; j < (int)processArray.Length; j++)
				{
					Process process = processArray[j];
					process.Kill();
					process = null;
				}
				processArray = null;
				processesByName = null;
				str = null;
			}
			strArrays1 = null;
			if (num < 1)
			{
				Console.WriteLine("that's not a option!");
				Thread.Sleep(2000);
			}
			else if (num == 1)
			{
				Console.Clear();
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("launching!");
				Thread.Sleep(3000);
				Console.Clear();
				Console.WindowWidth = 106;
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("If fortnite doesn't launch, try turning off your virus protection and make sure your fortnite isn't open!");
				Thread.Sleep(3000);
				Program.launchAsync();
				Thread.Sleep(3000);
				Program.exit();
			}
			if (num < 2)
			{
				Console.WriteLine("that's not a option!");
				Thread.Sleep(2000);
			}
			else if (num == 2)
			{
				Console.Clear();
				Console.WriteLine("Restoring fortnite! Please check your epic games launcher!");
				Program.verify();
				Thread.Sleep(5000);
				Console.Clear();
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("exiting...");
				Thread.Sleep(1500);
				Program.exit();
			}
			if (num < 3)
			{
				Console.WriteLine("that's not a option!");
				Thread.Sleep(2000);
			}
			else if (num != 3)
			{
				Console.WriteLine("that's not a option");
				strArrays = null;
				return;
			}
			else
			{
				Console.Clear();
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("exiting...");
				Thread.Sleep(2000);
				Program.exit();
			}
			strArrays = null;
		}

		private static void verify()
		{
			ProcessStartInfo processStartInfo = new ProcessStartInfo()
			{
				CreateNoWindow = true,
				FileName = "cmd.exe",
				Arguments = "/C start com.epicgames.launcher://apps/Fortnite?action=verify&silent=true"
			};
			Process.Start(processStartInfo);
		}
	}
}