// Decompiled with JetBrains decompiler
// Type: HWID_Spoofer.Program
// Assembly: Engine HWID PRO CHANGER 2.0.5, Version=52333.4351.421.534, Culture=neutral, PublicKeyToken=null
// MVID: F1720227-1647-4F5D-AAC2-6AE171A8A256
// Assembly location: C:\Users\Pier\Downloads\GreenCode - Exposed\GreenCode - Exposed\Engine Spoofer 2.0.5\Engine - Cracked by jwanah.exe

using System;
using System.Security.Principal;
using System.Windows.Forms;

namespace HWID_Spoofer
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      if (Program.IsAdministrator())
      {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run((Form) new Form2());
      }
      else
      {
        int num = (int) MessageBox.Show("Please run the program as administrator.", "Run as admin", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        Environment.Exit(0);
      }
    }

    public static bool IsAdministrator() => new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
  }
}
