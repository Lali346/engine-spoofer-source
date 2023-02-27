// Decompiled with JetBrains decompiler
// Type: HWID_Spoofer.Form2
// Assembly: Engine HWID PRO CHANGER 2.0.5, Version=52333.4351.421.534, Culture=neutral, PublicKeyToken=null
// MVID: F1720227-1647-4F5D-AAC2-6AE171A8A256
// Assembly location: C:\Users\Pier\Downloads\GreenCode - Exposed\GreenCode - Exposed\Engine Spoofer 2.0.5\Engine - Cracked by jwanah.exe

using MetroFramework;
using MetroFramework.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace HWID_Spoofer
{
  public class Form2 : Form
  {
    private IContainer components;
    private MetroLabel metroLabel1;
    private MetroButton metroButton1;
    private MetroTextBox metroTextBox1;

    public Form2() => this.InitializeComponent();

    private void metroButton1_Click(object sender, EventArgs e)
    {
      string str = new WebClient().DownloadString("https://pastebin.com/raw/HuySVNyE");
      if (this.metroTextBox1.Text == "")
      {
        int num1 = (int) MessageBox.Show("key : jwanah ");
      }
      else if (str.Contains(this.metroTextBox1.Text))
      {
        this.Hide();
        Form1 form1 = new Form1();
        this.Hide();
        int num2 = (int) form1.ShowDialog();
        this.Close();
      }
      else
      {
        int num3 = (int) MessageBox.Show("USE KEY jwanah DUMB");
      }
    }

    private void Form2_Load(object sender, EventArgs e)
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form2));
      this.metroLabel1 = new MetroLabel();
      this.metroButton1 = new MetroButton();
      this.metroTextBox1 = new MetroTextBox();
      this.SuspendLayout();
      this.metroLabel1.AutoSize = true;
      this.metroLabel1.Location = new Point(133, 65);
      this.metroLabel1.Margin = new Padding(4, 0, 4, 0);
      this.metroLabel1.Name = "metroLabel1";
      this.metroLabel1.Size = new Size(69, 20);
      this.metroLabel1.TabIndex = 0;
      this.metroLabel1.Text = "key = jwanah";
      this.metroLabel1.Theme = MetroThemeStyle.Dark;
      this.metroButton1.Location = new Point(59, 190);
      this.metroButton1.Margin = new Padding(4);
      this.metroButton1.Name = "metroButton1";
      this.metroButton1.Size = new Size(243, 28);
      this.metroButton1.TabIndex = 1;
      this.metroButton1.Text = "Login";
      this.metroButton1.Click += new EventHandler(this.metroButton1_Click);
      this.metroTextBox1.Location = new Point(59, 119);
      this.metroTextBox1.Margin = new Padding(4);
      this.metroTextBox1.Name = "metroTextBox1";
      this.metroTextBox1.Size = new Size(243, 28);
      this.metroTextBox1.TabIndex = 2;
      this.AutoScaleDimensions = new SizeF(8f, 16f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.Black;
      this.ClientSize = new Size(353, 293);
      this.Controls.Add((Control) this.metroTextBox1);
      this.Controls.Add((Control) this.metroButton1);
      this.Controls.Add((Control) this.metroLabel1);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Margin = new Padding(4);
      this.Name = nameof (Form2);
      this.Text = "Login";
      this.Load += new EventHandler(this.Form2_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
