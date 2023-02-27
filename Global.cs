// Decompiled with JetBrains decompiler
// Type: HWID_Spoofer.Global
// Assembly: Engine HWID PRO CHANGER 2.0.5, Version=52333.4351.421.534, Culture=neutral, PublicKeyToken=null
// MVID: F1720227-1647-4F5D-AAC2-6AE171A8A256
// Assembly location: C:\Users\Pier\Downloads\GreenCode - Exposed\GreenCode - Exposed\Engine Spoofer 2.0.5\Engine - Cracked by jwanah.exe

using System.Diagnostics;

namespace HWID_Spoofer
{
  internal class Global
  {
    public static bool PCName;
    public static bool GUID;
    public static bool HWIDserial;
    public static bool ProductID;
    public static bool MacAddress;
    public static bool InstallTime;
    public static bool InstallDate;
    public static bool HwProfileGUID;

    public static void Restart() => Global.StartShutDown("-f -r -t 5");

    private static void StartShutDown(string param) => Process.Start(new ProcessStartInfo()
    {
      FileName = "cmd",
      WindowStyle = ProcessWindowStyle.Hidden,
      Arguments = "/C shutdown " + param
    });
  }
}
