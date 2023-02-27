// Decompiled with JetBrains decompiler
// Type: HWID_Spoofer.Form1
// Assembly: Engine HWID PRO CHANGER 2.0.5, Version=52333.4351.421.534, Culture=neutral, PublicKeyToken=null
// MVID: F1720227-1647-4F5D-AAC2-6AE171A8A256
// Assembly location: C:\Users\Pier\Downloads\GreenCode - Exposed\GreenCode - Exposed\Engine Spoofer 2.0.5\Engine - Cracked by jwanah.exe

using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;

namespace HWID_Spoofer
{
  public class Form1 : MetroForm
  {
    private OpenVPN vpn;
    private Random rand = new Random();
    public const string Alphabet = "ABCDEF0123456789";
    private Random random = new Random();
    public const string Alphabet1 = "abcdef0123456789";
    private IContainer components;
    private MetroLabel metroLabel1;
    private Timer timer1;
    private MetroLabel metroLabel10;
    private MetroLabel labelStatus;
    private MetroLabel metroLabel11;
    private MetroTabPage metroTabPage2;
    private MetroButton metroButton1;
    public ListBox listBox1;
    private MetroTabPage metroTabPage1;
    private MetroCheckBox metroCheckBox9;
    private MetroCheckBox metroCheckBox8;
    private MetroCheckBox metroCheckBox7;
    private MetroCheckBox metroCheckBox5;
    private MetroCheckBox metroCheckBox1;
    private MetroCheckBox metroCheckBox4;
    private MetroCheckBox metroCheckBox3;
    private MetroTabControl metroTabControl1;
    private MetroTabPage metroTabPage3;
    private MetroLabel metroLabel9;
    private MetroTextBox txtPass;
    private MetroTextBox txtUser;
    private MetroButton btnDisconnect;
    private MetroButton btnConnect;
    private MetroButton btnImport;
    private MetroLabel metroLabel8;
    private MetroLabel metroLabel7;
    private MetroLabel metroLabel6;
    private MetroTabPage metroTabPage5;
    private MetroLabel metroLabel13;
    private MetroButton metroButton3;
    private MetroLabel metroLabel12;
    private MetroButton metroButton2;
    private MetroButton metroButton4;
    private MetroLabel metroLabel14;
    private MetroTabPage metroTabPage6;
    private MetroLabel metroLabel5;
    private MetroLabel metroLabel4;
    private MetroLink metroLink2;
    private MetroLink metroLink1;
    private MetroLabel metroLabel3;
    private PictureBox pictureBox1;
    private MetroProgressBar metroProgressBar3;
    private MetroProgressBar metroProgressBar2;
    private MetroProgressBar metroProgressBar1;
    private Timer timer2;
    private Timer timer3;
    private MetroLabel metroLabel2;

    private string OVPNFile { get; set; }

    public Form1()
    {
      this.InitializeComponent();
      this.vpn = new OpenVPN();
      this.vpn.onConnectionChanged += new ConnectionChangedEvent(this.Vpn_onConnectionChanged);
      this.vpn.onStatusChanged += new ConnectionStatusChanged(this.Vpn_onStatusChanged);
    }

    private void Vpn_onStatusChanged(string status) => this.labelStatus.Invoke((Delegate) (() => this.labelStatus.Text = status));

    private void Vpn_onConnectionChanged(bool connected)
    {
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      this.listBox1.BackColor = System.Drawing.Color.FromArgb(29, 29, 29);
      this.listBox1.ForeColor = System.Drawing.Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    }

    private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
    {
      if (this.metroCheckBox1.Checked)
      {
        this.metroCheckBox3.Checked = true;
        this.metroCheckBox4.Checked = true;
        this.metroCheckBox5.Checked = true;
        this.metroCheckBox7.Checked = true;
        this.metroCheckBox8.Checked = true;
        this.metroCheckBox9.Checked = true;
      }
      else
      {
        this.metroCheckBox3.Checked = false;
        this.metroCheckBox4.Checked = false;
        this.metroCheckBox5.Checked = false;
        this.metroCheckBox7.Checked = false;
        this.metroCheckBox8.Checked = false;
        this.metroCheckBox9.Checked = false;
      }
    }

    public void Log(string log) => this.listBox1.Items.Add((object) log);

    private void metroCheckBox3_CheckedChanged(object sender, EventArgs e)
    {
      if (this.metroCheckBox3.Checked)
        Global.GUID = true;
      else
        Global.GUID = false;
    }

    private void metroCheckBox4_CheckedChanged(object sender, EventArgs e)
    {
      if (this.metroCheckBox4.Checked)
        Global.HWIDserial = true;
      else
        Global.HWIDserial = false;
    }

    private void metroCheckBox5_CheckedChanged(object sender, EventArgs e)
    {
      if (this.metroCheckBox5.Checked)
        Global.ProductID = true;
      else
        Global.ProductID = false;
    }

    private void metroCheckBox7_CheckedChanged(object sender, EventArgs e)
    {
      if (this.metroCheckBox7.Checked)
        Global.InstallTime = true;
      else
        Global.InstallTime = false;
    }

    private void metroCheckBox8_CheckedChanged(object sender, EventArgs e)
    {
      if (this.metroCheckBox8.Checked)
        Global.InstallDate = true;
      else
        Global.InstallDate = false;
    }

    private void metroCheckBox9_CheckedChanged(object sender, EventArgs e)
    {
      if (this.metroCheckBox9.Checked)
        Global.HwProfileGUID = true;
      else
        Global.HwProfileGUID = false;
    }

    public void Spoof()
    {
      this.listBox1.Items.Clear();
      if (Global.PCName)
        this.SpoofPCName();
      if (Global.GUID)
        this.SpoofGUID();
      if (Global.HWIDserial)
        this.SpoofHWIDserial();
      if (Global.MacAddress)
        this.SpoofMacAddress();
      if (Global.ProductID)
        this.SpoofProductID();
      if (Global.InstallTime)
        this.SpoofInstallTime();
      if (Global.InstallDate)
        this.SpoofInstallDate();
      if (!Global.HwProfileGUID)
        return;
      this.SpoofHwProfileGUID();
    }

    private void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
    {
      int num = (int) MessageBox.Show("Spoofer Sync");
    }

    public string GenerateString(int size)
    {
      char[] chArray = new char[size];
      for (int index = 0; index < size; ++index)
        chArray[index] = "ABCDEF0123456789"[this.rand.Next("ABCDEF0123456789".Length)];
      return new string(chArray);
    }

    private void SpoofMacAddress()
    {
      this.Log("Current MAC Address: " + this.CurrentMAC());
      string str = "00" + this.GenerateString(10);
      RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E972-E325-11CE-BFC1-08002BE10318}\\0012", true);
      registryKey.SetValue("NetworkAddress", (object) str);
      registryKey.Close();
      this.Log("MAC address changed to: " + this.CurrentMAC());
      this.Log("");
    }

    private string CurrentMAC()
    {
      RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E972-E325-11CE-BFC1-08002BE10318}\\0012", true);
      string str = (string) registryKey.GetValue("NetworkAddress");
      registryKey.Close();
      return str;
    }

    private void SpoofGUID()
    {
      this.Log("Current GUID: " + Form1.CurrentGUID());
      string str = Guid.NewGuid().ToString();
      RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE\\Microsoft\\Cryptography", true).SetValue("MachineGuid", (object) str);
      this.Log("GUID changed to: " + Form1.CurrentGUID());
      this.Log("");
    }

    public static string CurrentGUID()
    {
      string name1 = "SOFTWARE\\Microsoft\\Cryptography";
      string name2 = "MachineGuid";
      using (RegistryKey registryKey1 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
      {
        using (RegistryKey registryKey2 = registryKey1.OpenSubKey(name1))
          return ((registryKey2 != null ? registryKey2.GetValue(name2) : throw new KeyNotFoundException(string.Format("Key Not Found: {0}", (object) name1))) ?? throw new IndexOutOfRangeException(string.Format("Index Not Found: {0}", (object) name2))).ToString();
      }
    }

    private void SpoofProductID()
    {
      this.Log("Current ProductID: " + Form1.CurrentProductID());
      string str = this.GenerateString(5) + "-" + this.GenerateString(5) + "-" + this.GenerateString(5) + "-" + this.GenerateString(5);
      RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", true);
      registryKey.SetValue("ProductID", (object) str);
      registryKey.Close();
      this.Log("ProductID changed to: " + Form1.CurrentProductID());
      this.Log("");
    }

    public static string CurrentProductID()
    {
      string name1 = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion";
      string name2 = "ProductID";
      using (RegistryKey registryKey1 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
      {
        using (RegistryKey registryKey2 = registryKey1.OpenSubKey(name1))
          return ((registryKey2 != null ? registryKey2.GetValue(name2) : throw new KeyNotFoundException(string.Format("Key Not Found: {0}", (object) name1))) ?? throw new IndexOutOfRangeException(string.Format("Index Not Found: {0}", (object) name2))).ToString();
      }
    }

    public string GenerateDate(int size)
    {
      char[] chArray = new char[size];
      for (int index = 0; index < size; ++index)
        chArray[index] = "abcdef0123456789"[this.random.Next("abcdef0123456789".Length)];
      return new string(chArray);
    }

    private void SpoofInstallTime()
    {
      this.Log("Current install time: " + Form1.CurrentInstallTime());
      string date = this.GenerateDate(15);
      RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", true);
      registryKey.SetValue("InstallTime", (object) date);
      registryKey.Close();
      this.Log("Install time changed to: " + Form1.CurrentInstallTime());
      this.Log("");
    }

    public static string CurrentInstallTime()
    {
      string name1 = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion";
      string name2 = "InstallTime";
      using (RegistryKey registryKey1 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
      {
        using (RegistryKey registryKey2 = registryKey1.OpenSubKey(name1))
          return ((registryKey2 != null ? registryKey2.GetValue(name2) : throw new KeyNotFoundException(string.Format("Key Not Found: {0}", (object) name1))) ?? throw new IndexOutOfRangeException(string.Format("Index Not Found: {0}", (object) name2))).ToString();
      }
    }

    private void SpoofInstallDate()
    {
      this.Log("Current install date: " + Form1.CurrentInstallDate());
      string date = this.GenerateDate(8);
      RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", true);
      registryKey.SetValue("InstallDate", (object) date);
      registryKey.Close();
      this.Log("New Install Date: " + Form1.CurrentInstallDate());
      this.Log("");
    }

    public static string CurrentInstallDate()
    {
      string name1 = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion";
      string name2 = "InstallDate";
      using (RegistryKey registryKey1 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
      {
        using (RegistryKey registryKey2 = registryKey1.OpenSubKey(name1))
          return ((registryKey2 != null ? registryKey2.GetValue(name2) : throw new KeyNotFoundException(string.Format("Key Not Found: {0}", (object) name1))) ?? throw new IndexOutOfRangeException(string.Format("Index Not Found: {0}", (object) name2))).ToString();
      }
    }

    private void SpoofHwProfileGUID()
    {
      this.Log("Current HwProfileGUID: " + Form1.CurrentHwProfileGUID());
      string str = "{" + Guid.NewGuid().ToString() + "}";
      RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\IDConfigDB\\Hardware Profiles\\0001", true);
      registryKey.SetValue("HwProfileGUID", (object) str);
      registryKey.Close();
      this.Log("New HwProfileGUID: " + Form1.CurrentHwProfileGUID());
      this.Log("");
    }

    public static string CurrentHwProfileGUID()
    {
      string name1 = "SYSTEM\\CurrentControlSet\\Control\\IDConfigDB\\Hardware Profiles\\0001";
      string name2 = "HwProfileGUID";
      using (RegistryKey registryKey1 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
      {
        using (RegistryKey registryKey2 = registryKey1.OpenSubKey(name1))
          return ((registryKey2 != null ? registryKey2.GetValue(name2) : throw new KeyNotFoundException(string.Format("Key Not Found: {0}", (object) name1))) ?? throw new IndexOutOfRangeException(string.Format("Index Not Found: {0}", (object) name2))).ToString();
      }
    }

    private void ChangeSerialNumber(char volume, uint newSerial)
    {
      \u003C\u003Ef__AnonymousType0<string, int, int>[] source = new \u003C\u003Ef__AnonymousType0<string, int, int>[3]
      {
        new{ Name = "FAT32", NameOffs = 82, SerialOffs = 67 },
        new{ Name = "FAT", NameOffs = 54, SerialOffs = 39 },
        new{ Name = "NTFS", NameOffs = 3, SerialOffs = 72 }
      };
      using (Form1.Disk disk = new Form1.Disk(volume))
      {
        byte[] sector = new byte[512];
        disk.ReadSector(0U, sector);
        var data = source.FirstOrDefault(f => this.Strncmp(f.Name, sector, f.NameOffs));
        if (data == null)
          throw new NotSupportedException("This file system is not supported");
        uint num1 = newSerial;
        int num2 = 0;
        while (num2 < 4)
        {
          sector[data.SerialOffs + num2] = (byte) (num1 & (uint) byte.MaxValue);
          ++num2;
          num1 >>= 8;
        }
        disk.WriteSector(0U, sector);
      }
    }

    private bool Strncmp(string str, byte[] data, int offset)
    {
      for (int index = 0; index < str.Length; ++index)
      {
        if ((int) data[index + offset] != (int) (byte) str[index])
          return false;
      }
      return true;
    }

    private void SpoofHWIDserial()
    {
      string s = this.GenerateString(8);
      uint newSerial = uint.Parse(s, NumberStyles.HexNumber);
      this.Log("HDD serial changing to: " + s + " - " + newSerial.ToString());
      this.ChangeSerialNumber('C', newSerial);
      this.Log("");
    }

    private void SpoofPCName()
    {
      this.Log("Current PC name: " + Form1.CurrentPCName());
      RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ActiveComputerName", true);
      registryKey.SetValue("ComputerName", (object) ("DESKTOP-" + this.GenerateString(15)));
      registryKey.Close();
      this.Log("PC name spoofed to: " + Form1.CurrentPCName());
      this.Log("");
    }

    public static string CurrentPCName()
    {
      string name1 = "SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ActiveComputerName";
      string name2 = "ComputerName";
      using (RegistryKey registryKey1 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
      {
        using (RegistryKey registryKey2 = registryKey1.OpenSubKey(name1))
          return ((registryKey2 != null ? registryKey2.GetValue(name2) : throw new KeyNotFoundException(string.Format("Key Not Found: {0}", (object) name1))) ?? throw new IndexOutOfRangeException(string.Format("Index Not Found: {0}", (object) name2))).ToString();
      }
    }

    private void metroButton1_Click_1(object sender, EventArgs e)
    {
      if (MessageBox.Show("Are you sure you would like to continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
        return;
      this.Spoof();
    }

    private void btnImport_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog1 = new OpenFileDialog();
      openFileDialog1.Filter = "OVPN File (*.ovpn) | *.ovpn";
      OpenFileDialog openFileDialog2 = openFileDialog1;
      if (openFileDialog2.ShowDialog() != DialogResult.OK)
        return;
      this.OVPNFile = openFileDialog2.FileName;
    }

    private void btnConnect_Click(object sender, EventArgs e) => this.vpn.Connect(this.txtUser.Text, this.txtPass.Text, this.OVPNFile, "log.txt");

    private void btnDisconnect_Click(object sender, EventArgs e)
    {
      if (!this.vpn.Connected)
        return;
      this.vpn.Disconnect();
    }

    private void metroButton2_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Are you sure you would like to continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
        return;
      Process process = new Process();
      process.StartInfo.FileName = "cmd.exe";
      process.StartInfo.RedirectStandardInput = true;
      process.StartInfo.RedirectStandardError = true;
      process.StartInfo.RedirectStandardOutput = true;
      process.StartInfo.UseShellExecute = false;
      process.StartInfo.CreateNoWindow = true;
      process.Start();
      process.StandardInput.WriteLine("taskkill /f /im UnrealCEFSubProcess.exe");
      process.StandardInput.WriteLine("taskkill /f /im CEFProcess.exe");
      process.StandardInput.WriteLine("taskkill /f /im EasyAntiCheat.exe");
      process.StandardInput.WriteLine("taskkill /f /im BEService.exe");
      process.StandardInput.WriteLine("taskkill /f /im BEServices.exe");
      process.StandardInput.WriteLine("taskkill /f /im BattleEye.exe");
      process.StandardInput.WriteLine("taskkill /f /im epicgameslauncher.exe");
      process.StandardInput.WriteLine("taskkill /f /im FortniteClient-Win64-Shipping_EAC.exe");
      process.StandardInput.WriteLine("taskkill /f /im FortniteClient-Win64-Shipping.exe");
      process.StandardInput.WriteLine("taskkill /f /im FortniteClient-Win64-Shipping_BE.exe");
      process.StandardInput.WriteLine("taskkill /f /im FortniteLauncher.exe");
      process.StandardInput.WriteLine("reg delete \"HKEY_LOCAL_MACHINE\\Software\\Epic Games\" /f");
      process.StandardInput.WriteLine("reg delete \"HKEY_CURRENT_USER\\Software\\Epic Games\" /f");
      process.StandardInput.WriteLine("reg delete \"HKEY_LOCAL_MACHINE\\Software\\Epic Games\" /f");
      process.StandardInput.WriteLine("reg delete \"HKEY_LOCAL_MACHINE\\SOFTWARE\\Classes\\com.epicgames.launcher\" /f");
      process.StandardInput.WriteLine("reg delete \"HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\EpicGames\" /f");
      process.StandardInput.WriteLine("reg delete \"HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Epic Games\" /f");
      process.StandardInput.WriteLine("reg delete \"HKEY_CLASSES_ROOT\\com.epicgames.launcher\" /f");
      process.StandardInput.WriteLine("reg delete \"HKEY_LOCAL_MACHINE\\Software\\Epic Games\" /f");
      process.StandardInput.WriteLine("reg delete \"HKEY_CURRENT_USER\\Software\\Classes\\com.epicgames.launcher\" /f");
      process.StandardInput.WriteLine("reg delete \"HKEY_CURRENT_USER\\Software\\Epic Games\\Unreal Engine\\Hardware Survey\" /f");
      process.StandardInput.WriteLine("reg delete \"HKEY_CURRENT_USER\\Software\\Epic Games\\Unreal Engine\\Identifiers\" /f");
      process.StandardInput.WriteLine("reg delete \"HKEY_LOCAL_MACHINE\\SOFTWARE\\Classes\\com.epicgames.launcher\" /f");
      process.StandardInput.WriteLine("reg delete \"HKEY_LOCAL_MACHINE\\SOFTWARE\\EpicGames\" /f");
      process.StandardInput.WriteLine("reg delete \"HKEY_CURRENT_USER\\SOFTWARE\\EpicGames\" /f");
      process.StandardInput.WriteLine("reg delete \"HKLM\\SYSTEM\\CurrentControlSet\\Control\\IDConfigDB\\Hardware\\Profiles\\0001 \\v HwProfileGuid \\t REG_SZ \\d {%08x-%04x-%04x-%04x-%04x%08x} /f");
      process.StandardInput.WriteLine("exit");
      this.timer1.Start();
    }

    private void metroButton3_Click(object sender, EventArgs e)
    {
      string str = WindowsIdentity.GetCurrent().User.Value;
      Registry.Users.DeleteSubKeyTree(str + "\\SOFTWARE\\Chromium", false);
      Registry.Users.DeleteSubKeyTree(str + "\\SOFTWARE\\CitizenFX", false);
      Registry.Users.DeleteSubKeyTree(str + "\\SOFTWARE\\FiveM", false);
      Registry.Users.DeleteSubKeyTree(str + "\\SOFTWARE\\discord-", false);
      Registry.Users.DeleteSubKeyTree(str + "_Classes\\FiveM.ProtocolHandler", false);
      Registry.Users.DeleteSubKeyTree(str + "_Classes\\fivem", false);
      Registry.Users.DeleteSubKeyTree(str + "_Classes\\discord-", false);
      Registry.CurrentUser.DeleteSubKeyTree("\\SOFTWARE\\CitizenFX", false);
      Registry.CurrentUser.DeleteSubKeyTree("\\SOFTWARE\\FiveM", false);
      Registry.CurrentUser.DeleteSubKeyTree("\\SOFTWARE\\Chromium", false);
      Registry.ClassesRoot.DeleteSubKeyTree("fivem", false);
      Registry.ClassesRoot.DeleteSubKeyTree("FiveM.ProtocolHandler", false);
      Registry.ClassesRoot.DeleteSubKeyTree("discord-", false);
      string path1 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\DigitalEntitlements";
      if (Directory.Exists(path1))
        Directory.Delete(path1, true);
      string path2 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\FiveM\\FiveM.app\\cache";
      if (Directory.Exists(path2))
        Directory.Delete(path2, true);
      string path3 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\CitizenFX";
      if (Directory.Exists(path3))
        Directory.Delete(path3, true);
      string path4 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\FiveM\\FiveM.app\\mods";
      if (Directory.Exists(path4))
        Directory.Delete(path4, true);
      string path5 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\FiveM\\FiveM.app\\imgui.inie";
      if (File.Exists(path5))
        File.Delete(path5);
      string path6 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\FiveM\\FiveM.app\\CitizenFX.ini";
      if (File.Exists(path6))
        File.Delete(path6);
      string path7 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\FiveM\\FiveM.app\\asi-five.dll";
      if (File.Exists(path7))
        File.Delete(path7);
      string path8 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\FiveM\\FiveM.app\\adhesive.dll";
      if (File.Exists(path8))
        File.Delete(path8);
      string path9 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\FiveM\\FiveM.app\\crashes";
      if (Directory.Exists(path9))
        Directory.Delete(path9, true);
      string path10 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\FiveM\\FiveM.app\\logs";
      if (Directory.Exists(path10))
        Directory.Delete(path10, true);
      string path11 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\FiveM\\FiveM.app\\caches.xml";
      if (File.Exists(path11))
        File.Delete(path11);
      this.timer2.Start();
    }

    private void metroButton4_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Are you sure you would like to continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
        return;
      this.timer3.Start();
      Form form = new Form();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      this.metroProgressBar1.Increment(1);
      if (this.metroProgressBar1.Value != 100)
        return;
      this.timer1.Stop();
    }

    private void timer2_Tick(object sender, EventArgs e)
    {
      this.metroProgressBar2.Increment(1);
      if (this.metroProgressBar2.Value != 100)
        return;
      this.timer2.Stop();
    }

    private void timer3_Tick(object sender, EventArgs e)
    {
      this.metroProgressBar3.Increment(1);
      if (this.metroProgressBar3.Value != 100)
        return;
      this.timer3.Stop();
    }

    private void metroLabel11_Click(object sender, EventArgs e)
    {
    }

    private void label1_Click(object sender, EventArgs e)
    {
    }

    private void label3_Click(object sender, EventArgs e)
    {
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form1));
      this.metroLabel1 = new MetroLabel();
      this.timer1 = new Timer(this.components);
      this.metroLabel10 = new MetroLabel();
      this.labelStatus = new MetroLabel();
      this.metroLabel11 = new MetroLabel();
      this.metroTabPage2 = new MetroTabPage();
      this.metroLabel6 = new MetroLabel();
      this.metroButton1 = new MetroButton();
      this.listBox1 = new ListBox();
      this.metroTabPage1 = new MetroTabPage();
      this.metroLabel2 = new MetroLabel();
      this.metroCheckBox9 = new MetroCheckBox();
      this.metroCheckBox8 = new MetroCheckBox();
      this.metroCheckBox7 = new MetroCheckBox();
      this.metroCheckBox5 = new MetroCheckBox();
      this.metroCheckBox1 = new MetroCheckBox();
      this.metroCheckBox4 = new MetroCheckBox();
      this.metroCheckBox3 = new MetroCheckBox();
      this.metroTabControl1 = new MetroTabControl();
      this.metroTabPage3 = new MetroTabPage();
      this.metroLabel9 = new MetroLabel();
      this.txtPass = new MetroTextBox();
      this.txtUser = new MetroTextBox();
      this.btnDisconnect = new MetroButton();
      this.btnConnect = new MetroButton();
      this.btnImport = new MetroButton();
      this.metroLabel8 = new MetroLabel();
      this.metroLabel7 = new MetroLabel();
      this.metroTabPage5 = new MetroTabPage();
      this.metroProgressBar3 = new MetroProgressBar();
      this.metroProgressBar2 = new MetroProgressBar();
      this.metroProgressBar1 = new MetroProgressBar();
      this.metroButton4 = new MetroButton();
      this.metroLabel14 = new MetroLabel();
      this.metroLabel13 = new MetroLabel();
      this.metroButton3 = new MetroButton();
      this.metroLabel12 = new MetroLabel();
      this.metroButton2 = new MetroButton();
      this.metroTabPage6 = new MetroTabPage();
      this.metroLabel5 = new MetroLabel();
      this.metroLabel4 = new MetroLabel();
      this.metroLink2 = new MetroLink();
      this.metroLink1 = new MetroLink();
      this.metroLabel3 = new MetroLabel();
      this.pictureBox1 = new PictureBox();
      this.timer2 = new Timer(this.components);
      this.timer3 = new Timer(this.components);
      this.metroTabPage2.SuspendLayout();
      this.metroTabPage1.SuspendLayout();
      this.metroTabControl1.SuspendLayout();
      this.metroTabPage3.SuspendLayout();
      this.metroTabPage5.SuspendLayout();
      this.metroTabPage6.SuspendLayout();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.SuspendLayout();
      this.metroLabel1.AutoSize = true;
      this.metroLabel1.Location = new Point(9, 14);
      this.metroLabel1.Margin = new Padding(4, 0, 4, 0);
      this.metroLabel1.Name = "metroLabel1";
      this.metroLabel1.Size = new Size(183, 20);
      this.metroLabel1.TabIndex = 7;
      this.metroLabel1.Text = "Engine Spoofer | Cracked by jwanah";
      this.metroLabel1.Theme = MetroThemeStyle.Dark;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.metroLabel10.AutoSize = true;
      this.metroLabel10.Location = new Point(8, 370);
      this.metroLabel10.Margin = new Padding(4, 0, 4, 0);
      this.metroLabel10.Name = "metroLabel10";
      this.metroLabel10.Size = new Size(80, 20);
      this.metroLabel10.TabIndex = 15;
      this.metroLabel10.Text = "VPN Status:";
      this.metroLabel10.Theme = MetroThemeStyle.Dark;
      this.labelStatus.AutoSize = true;
      this.labelStatus.Location = new Point(111, 370);
      this.labelStatus.Margin = new Padding(4, 0, 4, 0);
      this.labelStatus.Name = "labelStatus";
      this.labelStatus.Size = new Size(104, 20);
      this.labelStatus.TabIndex = 14;
      this.labelStatus.Text = "Not Connected";
      this.labelStatus.Theme = MetroThemeStyle.Dark;
      this.metroLabel11.AutoSize = true;
      this.metroLabel11.Location = new Point(355, 16);
      this.metroLabel11.Margin = new Padding(4, 0, 4, 0);
      this.metroLabel11.Name = "metroLabel11";
      this.metroLabel11.Size = new Size(202, 40);
      this.metroLabel11.TabIndex = 24;
      this.metroLabel11.Text = "Trusted Spoofer (Free Spoofer )\r\n";
      this.metroLabel11.Theme = MetroThemeStyle.Dark;
      this.metroLabel11.Click += new EventHandler(this.metroLabel11_Click);
      this.metroTabPage2.Controls.Add((Control) this.metroLabel6);
      this.metroTabPage2.Controls.Add((Control) this.metroButton1);
      this.metroTabPage2.Controls.Add((Control) this.listBox1);
      this.metroTabPage2.HorizontalScrollbarBarColor = true;
      this.metroTabPage2.HorizontalScrollbarSize = 12;
      this.metroTabPage2.Location = new Point(4, 40);
      this.metroTabPage2.Margin = new Padding(4);
      this.metroTabPage2.Name = "metroTabPage2";
      this.metroTabPage2.Size = new Size(580, 287);
      this.metroTabPage2.TabIndex = 1;
      this.metroTabPage2.Text = "Spoof";
      this.metroTabPage2.Theme = MetroThemeStyle.Dark;
      this.metroTabPage2.VerticalScrollbarBarColor = true;
      this.metroTabPage2.VerticalScrollbarSize = 13;
      this.metroLabel6.AutoSize = true;
      this.metroLabel6.Location = new Point(4, 185);
      this.metroLabel6.Margin = new Padding(4, 0, 4, 0);
      this.metroLabel6.Name = "metroLabel6";
      this.metroLabel6.Size = new Size(232, 40);
      this.metroLabel6.TabIndex = 20;
      this.metroLabel6.Text = "Befor you press on the spoof button\r\nDont forget to choice some settings";
      this.metroLabel6.Theme = MetroThemeStyle.Dark;
      this.metroButton1.Location = new Point(4, 251);
      this.metroButton1.Margin = new Padding(4);
      this.metroButton1.Name = "metroButton1";
      this.metroButton1.Size = new Size(569, 28);
      this.metroButton1.TabIndex = 19;
      this.metroButton1.Text = "Spoof";
      this.metroButton1.Theme = MetroThemeStyle.Dark;
      this.metroButton1.Click += new EventHandler(this.metroButton1_Click_1);
      this.listBox1.FormattingEnabled = true;
      this.listBox1.ItemHeight = 16;
      this.listBox1.Location = new Point(4, 16);
      this.listBox1.Margin = new Padding(4);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new Size(568, 164);
      this.listBox1.TabIndex = 18;
      this.metroTabPage1.Controls.Add((Control) this.metroLabel11);
      this.metroTabPage1.Controls.Add((Control) this.metroLabel2);
      this.metroTabPage1.Controls.Add((Control) this.metroCheckBox9);
      this.metroTabPage1.Controls.Add((Control) this.metroCheckBox8);
      this.metroTabPage1.Controls.Add((Control) this.metroCheckBox7);
      this.metroTabPage1.Controls.Add((Control) this.metroCheckBox5);
      this.metroTabPage1.Controls.Add((Control) this.metroCheckBox1);
      this.metroTabPage1.Controls.Add((Control) this.metroCheckBox4);
      this.metroTabPage1.Controls.Add((Control) this.metroCheckBox3);
      this.metroTabPage1.HorizontalScrollbarBarColor = true;
      this.metroTabPage1.HorizontalScrollbarSize = 12;
      this.metroTabPage1.Location = new Point(4, 40);
      this.metroTabPage1.Margin = new Padding(4);
      this.metroTabPage1.Name = "metroTabPage1";
      this.metroTabPage1.Size = new Size(580, 287);
      this.metroTabPage1.Style = MetroColorStyle.Red;
      this.metroTabPage1.TabIndex = 0;
      this.metroTabPage1.Text = "Settings";
      this.metroTabPage1.Theme = MetroThemeStyle.Dark;
      this.metroTabPage1.VerticalScrollbarBarColor = true;
      this.metroTabPage1.VerticalScrollbarSize = 13;
      this.metroLabel2.AutoSize = true;
      this.metroLabel2.Location = new Point(0, 16);
      this.metroLabel2.Margin = new Padding(4, 0, 4, 0);
      this.metroLabel2.Name = "metroLabel2";
      this.metroLabel2.Size = new Size(294, 140);
      this.metroLabel2.TabIndex = 24;
      this.metroLabel2.Text = componentResourceManager.GetString("metroLabel2.Text");
      this.metroLabel2.Theme = MetroThemeStyle.Dark;
      this.metroCheckBox9.AutoSize = true;
      this.metroCheckBox9.Location = new Point(333, 235);
      this.metroCheckBox9.Margin = new Padding(4);
      this.metroCheckBox9.Name = "metroCheckBox9";
      this.metroCheckBox9.Size = new Size(109, 17);
      this.metroCheckBox9.Style = MetroColorStyle.White;
      this.metroCheckBox9.TabIndex = 11;
      this.metroCheckBox9.Text = "HwProfileGUID";
      this.metroCheckBox9.Theme = MetroThemeStyle.Dark;
      this.metroCheckBox9.CheckedChanged += new EventHandler(this.metroCheckBox9_CheckedChanged);
      this.metroCheckBox8.AutoSize = true;
      this.metroCheckBox8.Location = new Point(333, 209);
      this.metroCheckBox8.Margin = new Padding(4);
      this.metroCheckBox8.Name = "metroCheckBox8";
      this.metroCheckBox8.Size = new Size(87, 17);
      this.metroCheckBox8.Style = MetroColorStyle.White;
      this.metroCheckBox8.TabIndex = 10;
      this.metroCheckBox8.Text = "Install date";
      this.metroCheckBox8.Theme = MetroThemeStyle.Dark;
      this.metroCheckBox8.CheckedChanged += new EventHandler(this.metroCheckBox8_CheckedChanged);
      this.metroCheckBox7.AutoSize = true;
      this.metroCheckBox7.Location = new Point(333, 183);
      this.metroCheckBox7.Margin = new Padding(4);
      this.metroCheckBox7.Name = "metroCheckBox7";
      this.metroCheckBox7.Size = new Size(86, 17);
      this.metroCheckBox7.Style = MetroColorStyle.White;
      this.metroCheckBox7.TabIndex = 9;
      this.metroCheckBox7.Text = "Install time";
      this.metroCheckBox7.Theme = MetroThemeStyle.Dark;
      this.metroCheckBox7.CheckedChanged += new EventHandler(this.metroCheckBox7_CheckedChanged);
      this.metroCheckBox5.AutoSize = true;
      this.metroCheckBox5.Location = new Point(103, 261);
      this.metroCheckBox5.Margin = new Padding(4);
      this.metroCheckBox5.Name = "metroCheckBox5";
      this.metroCheckBox5.Size = new Size(85, 17);
      this.metroCheckBox5.Style = MetroColorStyle.White;
      this.metroCheckBox5.TabIndex = 6;
      this.metroCheckBox5.Text = "Product ID";
      this.metroCheckBox5.Theme = MetroThemeStyle.Dark;
      this.metroCheckBox5.CheckedChanged += new EventHandler(this.metroCheckBox5_CheckedChanged);
      this.metroCheckBox1.AutoSize = true;
      this.metroCheckBox1.Location = new Point(103, 183);
      this.metroCheckBox1.Margin = new Padding(4);
      this.metroCheckBox1.Name = "metroCheckBox1";
      this.metroCheckBox1.Size = new Size(84, 17);
      this.metroCheckBox1.Style = MetroColorStyle.White;
      this.metroCheckBox1.TabIndex = 2;
      this.metroCheckBox1.Text = "All HWID's";
      this.metroCheckBox1.Theme = MetroThemeStyle.Dark;
      this.metroCheckBox1.CheckedChanged += new EventHandler(this.metroCheckBox1_CheckedChanged);
      this.metroCheckBox4.AutoSize = true;
      this.metroCheckBox4.Location = new Point(103, 235);
      this.metroCheckBox4.Margin = new Padding(4);
      this.metroCheckBox4.Name = "metroCheckBox4";
      this.metroCheckBox4.Size = new Size(87, 17);
      this.metroCheckBox4.Style = MetroColorStyle.White;
      this.metroCheckBox4.TabIndex = 5;
      this.metroCheckBox4.Text = "HDD Serial";
      this.metroCheckBox4.Theme = MetroThemeStyle.Dark;
      this.metroCheckBox4.CheckedChanged += new EventHandler(this.metroCheckBox4_CheckedChanged);
      this.metroCheckBox3.AutoSize = true;
      this.metroCheckBox3.Location = new Point(103, 209);
      this.metroCheckBox3.Margin = new Padding(4);
      this.metroCheckBox3.Name = "metroCheckBox3";
      this.metroCheckBox3.Size = new Size(107, 17);
      this.metroCheckBox3.Style = MetroColorStyle.White;
      this.metroCheckBox3.TabIndex = 4;
      this.metroCheckBox3.Text = "Machine GUID";
      this.metroCheckBox3.Theme = MetroThemeStyle.Dark;
      this.metroCheckBox3.CheckedChanged += new EventHandler(this.metroCheckBox3_CheckedChanged);
      this.metroTabControl1.Controls.Add((Control) this.metroTabPage1);
      this.metroTabControl1.Controls.Add((Control) this.metroTabPage3);
      this.metroTabControl1.Controls.Add((Control) this.metroTabPage5);
      this.metroTabControl1.Controls.Add((Control) this.metroTabPage2);
      this.metroTabControl1.Controls.Add((Control) this.metroTabPage6);
      this.metroTabControl1.Location = new Point(4, 41);
      this.metroTabControl1.Margin = new Padding(4);
      this.metroTabControl1.Name = "metroTabControl1";
      this.metroTabControl1.SelectedIndex = 0;
      this.metroTabControl1.Size = new Size(588, 331);
      this.metroTabControl1.Style = MetroColorStyle.Red;
      this.metroTabControl1.TabIndex = 12;
      this.metroTabControl1.Theme = MetroThemeStyle.Dark;
      this.metroTabPage3.Controls.Add((Control) this.metroLabel9);
      this.metroTabPage3.Controls.Add((Control) this.txtPass);
      this.metroTabPage3.Controls.Add((Control) this.txtUser);
      this.metroTabPage3.Controls.Add((Control) this.btnDisconnect);
      this.metroTabPage3.Controls.Add((Control) this.btnConnect);
      this.metroTabPage3.Controls.Add((Control) this.btnImport);
      this.metroTabPage3.Controls.Add((Control) this.metroLabel8);
      this.metroTabPage3.Controls.Add((Control) this.metroLabel7);
      this.metroTabPage3.HorizontalScrollbarBarColor = true;
      this.metroTabPage3.HorizontalScrollbarSize = 12;
      this.metroTabPage3.Location = new Point(4, 40);
      this.metroTabPage3.Margin = new Padding(4);
      this.metroTabPage3.Name = "metroTabPage3";
      this.metroTabPage3.Size = new Size(580, 287);
      this.metroTabPage3.Style = MetroColorStyle.Red;
      this.metroTabPage3.TabIndex = 2;
      this.metroTabPage3.Text = "VPN";
      this.metroTabPage3.Theme = MetroThemeStyle.Dark;
      this.metroTabPage3.VerticalScrollbarBarColor = true;
      this.metroTabPage3.VerticalScrollbarSize = 13;
      this.metroLabel9.AutoSize = true;
      this.metroLabel9.Location = new Point(13, 5);
      this.metroLabel9.Margin = new Padding(4, 0, 4, 0);
      this.metroLabel9.Name = "metroLabel9";
      this.metroLabel9.Size = new Size(258, 60);
      this.metroLabel9.TabIndex = 24;
      this.metroLabel9.Text = "You need to sing up https://openvpn.net\r\nAnd full you're username and pass\r\nimport .ovpn file and connect";
      this.metroLabel9.Theme = MetroThemeStyle.Dark;
      this.txtPass.Location = new Point(149, 144);
      this.txtPass.Margin = new Padding(4);
      this.txtPass.Name = "txtPass";
      this.txtPass.Size = new Size(312, 28);
      this.txtPass.TabIndex = 23;
      this.txtUser.Location = new Point(149, 91);
      this.txtUser.Margin = new Padding(4);
      this.txtUser.Name = "txtUser";
      this.txtUser.Size = new Size(312, 28);
      this.txtUser.TabIndex = 22;
      this.btnDisconnect.Location = new Point((int) sbyte.MaxValue, 209);
      this.btnDisconnect.Margin = new Padding(4);
      this.btnDisconnect.Name = "btnDisconnect";
      this.btnDisconnect.Size = new Size(172, 47);
      this.btnDisconnect.TabIndex = 21;
      this.btnDisconnect.Text = "Disconnect";
      this.btnDisconnect.Theme = MetroThemeStyle.Dark;
      this.btnDisconnect.Click += new EventHandler(this.btnDisconnect_Click);
      this.btnConnect.Location = new Point(303, 209);
      this.btnConnect.Margin = new Padding(4);
      this.btnConnect.Name = "btnConnect";
      this.btnConnect.Size = new Size(172, 47);
      this.btnConnect.TabIndex = 20;
      this.btnConnect.Text = "Connect";
      this.btnConnect.Theme = MetroThemeStyle.Dark;
      this.btnConnect.Click += new EventHandler(this.btnConnect_Click);
      this.btnImport.Location = new Point(372, 17);
      this.btnImport.Margin = new Padding(4);
      this.btnImport.Name = "btnImport";
      this.btnImport.Size = new Size(201, 46);
      this.btnImport.TabIndex = 19;
      this.btnImport.Text = "Import .ovpn File";
      this.btnImport.Theme = MetroThemeStyle.Dark;
      this.btnImport.Click += new EventHandler(this.btnImport_Click);
      this.metroLabel8.AutoSize = true;
      this.metroLabel8.Location = new Point(12, 144);
      this.metroLabel8.Margin = new Padding(4, 0, 4, 0);
      this.metroLabel8.Name = "metroLabel8";
      this.metroLabel8.Size = new Size(101, 20);
      this.metroLabel8.TabIndex = 18;
      this.metroLabel8.Text = "Password / Pin:";
      this.metroLabel8.Theme = MetroThemeStyle.Dark;
      this.metroLabel7.AutoSize = true;
      this.metroLabel7.Location = new Point(47, 91);
      this.metroLabel7.Margin = new Padding(4, 0, 4, 0);
      this.metroLabel7.Name = "metroLabel7";
      this.metroLabel7.Size = new Size(76, 20);
      this.metroLabel7.TabIndex = 17;
      this.metroLabel7.Text = "Username:";
      this.metroLabel7.Theme = MetroThemeStyle.Dark;
      this.metroTabPage5.Controls.Add((Control) this.metroProgressBar3);
      this.metroTabPage5.Controls.Add((Control) this.metroProgressBar2);
      this.metroTabPage5.Controls.Add((Control) this.metroProgressBar1);
      this.metroTabPage5.Controls.Add((Control) this.metroButton4);
      this.metroTabPage5.Controls.Add((Control) this.metroLabel14);
      this.metroTabPage5.Controls.Add((Control) this.metroLabel13);
      this.metroTabPage5.Controls.Add((Control) this.metroButton3);
      this.metroTabPage5.Controls.Add((Control) this.metroLabel12);
      this.metroTabPage5.Controls.Add((Control) this.metroButton2);
      this.metroTabPage5.HorizontalScrollbarBarColor = true;
      this.metroTabPage5.HorizontalScrollbarSize = 12;
      this.metroTabPage5.Location = new Point(4, 40);
      this.metroTabPage5.Margin = new Padding(4);
      this.metroTabPage5.Name = "metroTabPage5";
      this.metroTabPage5.Size = new Size(580, 287);
      this.metroTabPage5.TabIndex = 4;
      this.metroTabPage5.Text = "Clean";
      this.metroTabPage5.Theme = MetroThemeStyle.Dark;
      this.metroTabPage5.VerticalScrollbarBarColor = true;
      this.metroTabPage5.VerticalScrollbarSize = 13;
      this.metroProgressBar3.Location = new Point(201, (int) byte.MaxValue);
      this.metroProgressBar3.Margin = new Padding(4);
      this.metroProgressBar3.Name = "metroProgressBar3";
      this.metroProgressBar3.Size = new Size(184, 12);
      this.metroProgressBar3.TabIndex = 10;
      this.metroProgressBar2.Location = new Point(372, 139);
      this.metroProgressBar2.Margin = new Padding(4);
      this.metroProgressBar2.Name = "metroProgressBar2";
      this.metroProgressBar2.Size = new Size(184, 12);
      this.metroProgressBar2.TabIndex = 9;
      this.metroProgressBar1.Location = new Point(21, 139);
      this.metroProgressBar1.Margin = new Padding(4);
      this.metroProgressBar1.Name = "metroProgressBar1";
      this.metroProgressBar1.Size = new Size(184, 12);
      this.metroProgressBar1.TabIndex = 8;
      this.metroButton4.Location = new Point(201, 219);
      this.metroButton4.Margin = new Padding(4);
      this.metroButton4.Name = "metroButton4";
      this.metroButton4.Size = new Size(184, 28);
      this.metroButton4.TabIndex = 7;
      this.metroButton4.Text = "Clean";
      this.metroButton4.Theme = MetroThemeStyle.Dark;
      this.metroButton4.Click += new EventHandler(this.metroButton4_Click);
      this.metroLabel14.AutoSize = true;
      this.metroLabel14.Location = new Point(267, 153);
      this.metroLabel14.Margin = new Padding(4, 0, 4, 0);
      this.metroLabel14.Name = "metroLabel14";
      this.metroLabel14.Size = new Size(40, 20);
      this.metroLabel14.TabIndex = 6;
      this.metroLabel14.Text = "Apex";
      this.metroLabel14.Theme = MetroThemeStyle.Dark;
      this.metroLabel13.AutoSize = true;
      this.metroLabel13.Location = new Point(400, 41);
      this.metroLabel13.Margin = new Padding(4, 0, 4, 0);
      this.metroLabel13.Name = "metroLabel13";
      this.metroLabel13.Size = new Size(98, 20);
      this.metroLabel13.TabIndex = 5;
      this.metroLabel13.Text = "Fivem Cleaner";
      this.metroLabel13.Theme = MetroThemeStyle.Dark;
      this.metroButton3.Location = new Point(372, 103);
      this.metroButton3.Margin = new Padding(4);
      this.metroButton3.Name = "metroButton3";
      this.metroButton3.Size = new Size(184, 28);
      this.metroButton3.TabIndex = 4;
      this.metroButton3.Text = "Clean";
      this.metroButton3.Theme = MetroThemeStyle.Dark;
      this.metroButton3.Click += new EventHandler(this.metroButton3_Click);
      this.metroLabel12.AutoSize = true;
      this.metroLabel12.Location = new Point(44, 41);
      this.metroLabel12.Margin = new Padding(4, 0, 4, 0);
      this.metroLabel12.Name = "metroLabel12";
      this.metroLabel12.Size = new Size(109, 20);
      this.metroLabel12.TabIndex = 3;
      this.metroLabel12.Text = "Fortnite Cleaner";
      this.metroLabel12.Theme = MetroThemeStyle.Dark;
      this.metroButton2.Location = new Point(21, 103);
      this.metroButton2.Margin = new Padding(4);
      this.metroButton2.Name = "metroButton2";
      this.metroButton2.Size = new Size(184, 28);
      this.metroButton2.TabIndex = 2;
      this.metroButton2.Text = "Clean";
      this.metroButton2.Theme = MetroThemeStyle.Dark;
      this.metroButton2.Click += new EventHandler(this.metroButton2_Click);
      this.metroTabPage6.Controls.Add((Control) this.metroLabel5);
      this.metroTabPage6.Controls.Add((Control) this.metroLabel4);
      this.metroTabPage6.Controls.Add((Control) this.metroLink2);
      this.metroTabPage6.Controls.Add((Control) this.metroLink1);
      this.metroTabPage6.Controls.Add((Control) this.metroLabel3);
      this.metroTabPage6.Controls.Add((Control) this.pictureBox1);
      this.metroTabPage6.HorizontalScrollbarBarColor = true;
      this.metroTabPage6.HorizontalScrollbarSize = 12;
      this.metroTabPage6.Location = new Point(4, 40);
      this.metroTabPage6.Margin = new Padding(4);
      this.metroTabPage6.Name = "metroTabPage6";
      this.metroTabPage6.Size = new Size(580, 287);
      this.metroTabPage6.TabIndex = 5;
      this.metroTabPage6.Text = "About";
      this.metroTabPage6.Theme = MetroThemeStyle.Dark;
      this.metroTabPage6.VerticalScrollbarBarColor = true;
      this.metroTabPage6.VerticalScrollbarSize = 13;
      this.metroLabel5.AutoSize = true;
      this.metroLabel5.Location = new Point(4, 250);
      this.metroLabel5.Margin = new Padding(4, 0, 4, 0);
      this.metroLabel5.Name = "metroLabel5";
      this.metroLabel5.Size = new Size(88, 20);
      this.metroLabel5.TabIndex = 40;
      this.metroLabel5.Text = "juanah#0001";
      this.metroLabel5.Theme = MetroThemeStyle.Dark;
      this.metroLabel4.AutoSize = true;
      this.metroLabel4.Location = new Point(4, 223);
      this.metroLabel4.Margin = new Padding(4, 0, 4, 0);
      this.metroLabel4.Name = "metroLabel4";
      this.metroLabel4.Size = new Size(72, 20);
      this.metroLabel4.TabIndex = 39;
      this.metroLabel4.Text = "dont be dumbass, and join https://discord.gg/5Z2dx4KMu9";
      this.metroLabel4.Theme = MetroThemeStyle.Dark;
      this.metroLink2.Location = new Point(108, 250);
      this.metroLink2.Margin = new Padding(4);
      this.metroLink2.Name = "metroLink2";
      this.metroLink2.Size = new Size(227, 28);
      this.metroLink2.TabIndex = 38;
      this.metroLink2.Text = " ";
      this.metroLink2.Theme = MetroThemeStyle.Dark;
      this.metroLink1.Location = new Point(89, 223);
      this.metroLink1.Margin = new Padding(4);
      this.metroLink1.Name = "metroLink1";
      this.metroLink1.Size = new Size(296, 28);
      this.metroLink1.TabIndex = 37;
      this.metroLink1.Text = " ";
      this.metroLink1.Theme = MetroThemeStyle.Dark;
      this.metroLabel3.AutoSize = true;
      this.metroLabel3.Location = new Point(4, 124);
      this.metroLabel3.Margin = new Padding(4, 0, 4, 0);
      this.metroLabel3.Name = "metroLabel3";
      this.metroLabel3.Size = new Size(442, 80);
      this.metroLabel3.TabIndex = 36;
      this.metroLabel3.Text = componentResourceManager.GetString("metroLabel3.Text");
      this.metroLabel3.Theme = MetroThemeStyle.Dark;
      this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
      this.pictureBox1.BackgroundImage = (Image) componentResourceManager.GetObject("pictureBox1.BackgroundImage");
      this.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
      this.pictureBox1.Location = new Point(4, 5);
      this.pictureBox1.Margin = new Padding(4);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(569, 105);
      this.pictureBox1.TabIndex = 35;
      this.pictureBox1.TabStop = false;
      this.timer2.Tick += new EventHandler(this.timer2_Tick);
      this.timer3.Tick += new EventHandler(this.timer3_Tick);
      this.AutoScaleDimensions = new SizeF(8f, 16f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(596, 400);
      this.Controls.Add((Control) this.metroLabel10);
      this.Controls.Add((Control) this.labelStatus);
      this.Controls.Add((Control) this.metroTabControl1);
      this.Controls.Add((Control) this.metroLabel1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Margin = new Padding(4);
      this.Name = nameof (Form1);
      this.Padding = new Padding(27, 74, 27, 25);
      this.Style = MetroColorStyle.Red;
      this.Theme = MetroThemeStyle.Dark;
      this.Load += new EventHandler(this.Form1_Load);
      this.metroTabPage2.ResumeLayout(false);
      this.metroTabPage2.PerformLayout();
      this.metroTabPage1.ResumeLayout(false);
      this.metroTabPage1.PerformLayout();
      this.metroTabControl1.ResumeLayout(false);
      this.metroTabPage3.ResumeLayout(false);
      this.metroTabPage3.PerformLayout();
      this.metroTabPage5.ResumeLayout(false);
      this.metroTabPage5.PerformLayout();
      this.metroTabPage6.ResumeLayout(false);
      this.metroTabPage6.PerformLayout();
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private class Disk : IDisposable
    {
      private SafeFileHandle handle;
      private const uint INVALID_SET_FILE_POINTER = 4294967295;

      public Disk(char volume)
      {
        this.handle = new SafeFileHandle(Form1.Disk.CreateFile(string.Format("\\\\.\\{0}:", (object) volume), FileAccess.ReadWrite, FileShare.ReadWrite, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero), true);
        if (!this.handle.IsInvalid)
          return;
        Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
      }

      public void ReadSector(uint sector, byte[] buffer)
      {
        if (buffer == null)
          throw new ArgumentNullException(nameof (buffer));
        if (Form1.Disk.SetFilePointer(this.handle, sector, IntPtr.Zero, Form1.Disk.EMoveMethod.Begin) == uint.MaxValue)
          Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
        uint lpNumberOfBytesRead;
        if (!Form1.Disk.ReadFile(this.handle, buffer, buffer.Length, out lpNumberOfBytesRead, IntPtr.Zero))
          Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
        if ((long) lpNumberOfBytesRead != (long) buffer.Length)
          throw new IOException();
      }

      public void WriteSector(uint sector, byte[] buffer)
      {
        if (buffer == null)
          throw new ArgumentNullException(nameof (buffer));
        if (Form1.Disk.SetFilePointer(this.handle, sector, IntPtr.Zero, Form1.Disk.EMoveMethod.Begin) == uint.MaxValue)
          Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
        uint lpNumberOfBytesWritten;
        if (!Form1.Disk.WriteFile(this.handle, buffer, buffer.Length, out lpNumberOfBytesWritten, IntPtr.Zero))
          Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
        if ((long) lpNumberOfBytesWritten != (long) buffer.Length)
          throw new IOException();
      }

      public void Dispose()
      {
        this.Dispose(true);
        GC.SuppressFinalize((object) this);
      }

      protected virtual void Dispose(bool disposing)
      {
        if (!disposing || this.handle == null)
          return;
        this.handle.Dispose();
      }

      [DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
      public static extern IntPtr CreateFile(
        string fileName,
        [MarshalAs(UnmanagedType.U4)] FileAccess fileAccess,
        [MarshalAs(UnmanagedType.U4)] FileShare fileShare,
        IntPtr securityAttributes,
        [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
        int flags,
        IntPtr template);

      [DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
      private static extern uint SetFilePointer(
        [In] SafeFileHandle hFile,
        [In] uint lDistanceToMove,
        [In] IntPtr lpDistanceToMoveHigh,
        [In] Form1.Disk.EMoveMethod dwMoveMethod);

      [DllImport("kernel32.dll", SetLastError = true)]
      private static extern bool ReadFile(
        SafeFileHandle hFile,
        [Out] byte[] lpBuffer,
        int nNumberOfBytesToRead,
        out uint lpNumberOfBytesRead,
        IntPtr lpOverlapped);

      [DllImport("kernel32.dll")]
      private static extern bool WriteFile(
        SafeFileHandle hFile,
        [In] byte[] lpBuffer,
        int nNumberOfBytesToWrite,
        out uint lpNumberOfBytesWritten,
        [In] IntPtr lpOverlapped);

      private enum EMoveMethod : uint
      {
        Begin,
        Current,
        End,
      }
    }
  }
}
