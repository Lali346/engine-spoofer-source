// Decompiled with JetBrains decompiler
// Type: HWID_Spoofer.OpenVPN
// Assembly: Engine HWID PRO CHANGER 2.0.5, Version=52333.4351.421.534, Culture=neutral, PublicKeyToken=null
// MVID: F1720227-1647-4F5D-AAC2-6AE171A8A256
// Assembly location: C:\Users\Pier\Downloads\GreenCode - Exposed\GreenCode - Exposed\Engine Spoofer 2.0.5\Engine - Cracked by jwanah.exe

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

namespace HWID_Spoofer
{
  internal class OpenVPN
  {
    private string OpenVpnPath = "C:\\Program Files\\OpenVPN\\bin\\openvpn.exe";
    public BackgroundWorker logChecker;
    public BackgroundWorker processChecker;

    public event ConnectionChangedEvent onConnectionChanged;

    public event ConnectionStatusChanged onStatusChanged;

    public bool Connected { get; set; }

    private string logPath { get; set; }

    public OpenVPN()
    {
      this.logChecker = new BackgroundWorker();
      this.logChecker.WorkerSupportsCancellation = true;
      this.logChecker.DoWork += new DoWorkEventHandler(this.LogChecker_DoWork);
      this.processChecker = new BackgroundWorker();
      this.processChecker.WorkerSupportsCancellation = true;
      this.processChecker.DoWork += new DoWorkEventHandler(this.ProcessChecker_DoWork);
      this.processChecker.RunWorkerAsync();
    }

    private void ProcessChecker_DoWork(object sender, DoWorkEventArgs e)
    {
      while (this.processChecker.IsBusy)
      {
        if (this.processChecker.CancellationPending)
        {
          e.Cancel = true;
          break;
        }
        if (this.Connected && Process.GetProcessesByName("openvpn").Length == 0)
        {
          this.Connected = false;
          this.onConnectionChanged(false);
          this.onStatusChanged("OpenVPN process killed");
        }
        Thread.Sleep(1000);
      }
    }

    private void LogChecker_DoWork(object sender, DoWorkEventArgs e)
    {
      this.onStatusChanged("Checking Logs");
      while (!this.Connected)
      {
        if (this.logChecker.CancellationPending)
        {
          e.Cancel = true;
          return;
        }
        if (this.GetLogs().Contains("Initialization Sequence Completed"))
        {
          this.onConnectionChanged(true);
          this.onStatusChanged("Connected");
          this.Connected = true;
        }
        else if (Process.GetProcessesByName("openvpn").Length == 0)
        {
          this.Connected = false;
          this.onConnectionChanged(false);
          this.onStatusChanged("Failed to connect");
          this.logChecker.CancelAsync();
        }
      }
      this.logChecker.CancelAsync();
    }

    public void Connect(
      string username,
      string password,
      string ovpnFilePath,
      string logPath,
      string authFile = "auth.txt")
    {
      if (this.Connected)
        this.Disconnect();
      this.logPath = logPath;
      File.WriteAllText(authFile, username + Environment.NewLine + password);
      Process.Start(new ProcessStartInfo()
      {
        FileName = this.OpenVpnPath,
        Arguments = "--config " + ovpnFilePath + " --auth-user-pass " + authFile + " --log " + logPath,
        CreateNoWindow = true,
        WindowStyle = ProcessWindowStyle.Hidden
      });
      this.onStatusChanged("Connecting");
      if (this.logChecker.IsBusy)
        this.logChecker.CancelAsync();
      this.logChecker.RunWorkerAsync();
    }

    public void Disconnect()
    {
      if (!this.Connected)
        throw new Exception("You are not connected to a server.");
      if (this.logChecker.IsBusy)
        this.logChecker.CancelAsync();
      foreach (Process process in Process.GetProcesses())
      {
        if (process.ProcessName.StartsWith("openvpn"))
          process.Kill();
      }
      this.onStatusChanged("Disconnected");
      this.onConnectionChanged(false);
      this.Connected = false;
    }

    public string GetLogs()
    {
      try
      {
        if (!File.Exists(this.logPath))
          return string.Empty;
        using (FileStream fileStream = new FileStream(this.logPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
          using (StreamReader streamReader = new StreamReader((Stream) fileStream, Encoding.Default))
            return streamReader.ReadToEnd();
        }
      }
      catch
      {
        return string.Empty;
      }
    }
  }
}
