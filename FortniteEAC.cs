// Decompiled with JetBrains decompiler
// Type: HWID_Spoofer.FortniteEAC
// Assembly: Engine HWID PRO CHANGER 2.0.5, Version=52333.4351.421.534, Culture=neutral, PublicKeyToken=null
// MVID: F1720227-1647-4F5D-AAC2-6AE171A8A256
// Assembly location: C:\Users\Pier\Downloads\GreenCode - Exposed\GreenCode - Exposed\Engine Spoofer 2.0.5\Engine - Cracked by jwanah.exe

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace HWID_Spoofer
{
  internal class FortniteEAC
  {
    private const string EAC_EXECUTABLE = "FortniteClient-Win64-Shipping_EAC.exe";
    private const string EAC_TOKEN = "91e19a79b3c4c7c591d47bd6";
    private const string BE_EXECUTABLE = "FortniteClient-Win64-Shipping_BE.exe";
    private const string BE_TOKEN = "f7b9gah4h5380d10f721dd6a";
    private static Process _antiCheat;

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool AllocConsole();

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool FreeConsole();

    private static void MainFEAC(string[] args)
    {
      FortniteEAC.FreeConsole();
      FortniteEAC.AllocConsole();
      string str1 = string.Join(" ", args);
      if (!File.Exists("Original.exe") || !File.Exists("FortniteClient-Win64-Shipping_EAC.exe") || !File.Exists("FortniteClient-Win64-Shipping_BE.exe"))
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Please ensure the working path is the Fortnite Win64 folder!");
        Console.ReadKey();
      }
      else
      {
        AppDomain.CurrentDomain.ProcessExit += new EventHandler(FortniteEAC.OnProcessExit);
        Console.WriteLine("[1]. EasyAntiCheat");
        Console.WriteLine("[2]. BattlEye");
        Console.Write("Option: ");
        string str2 = Console.ReadLine();
        if (!(str2 == "1"))
        {
          if (str2 == "2")
          {
            FortniteEAC._antiCheat = new Process()
            {
              StartInfo = {
                FileName = "FortniteClient-Win64-Shipping_BE.exe",
                Arguments = str1 + " -noeac -fromfl=be -fltoken=f7b9gah4h5380d10f721dd6a",
                CreateNoWindow = false
              }
            };
          }
          else
          {
            Console.WriteLine("Invalid option!");
            Console.ReadKey();
            return;
          }
        }
        else
          FortniteEAC._antiCheat = new Process()
          {
            StartInfo = {
              FileName = "FortniteClient-Win64-Shipping_EAC.exe",
              Arguments = str1 + " -nobe -fromfl=eac -fltoken=91e19a79b3c4c7c591d47bd6",
              CreateNoWindow = false
            }
          };
        File.Move(Assembly.GetExecutingAssembly().Location, "Backup.exe");
        File.Move("Original.exe", "FortniteLauncher.exe");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Launching...");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        FortniteEAC._antiCheat.Start();
        FortniteEAC._antiCheat.WaitForExit();
        File.Move("FortniteLauncher.exe", "Original.exe");
        File.Move("Backup.exe", "FortniteLauncher.exe");
      }
    }

    private static void OnProcessExit(object sender, EventArgs e)
    {
      if (FortniteEAC._antiCheat.HasExited)
        return;
      FortniteEAC._antiCheat.Kill();
    }
  }
}
