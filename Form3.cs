// Decompiled with JetBrains decompiler
// Type: HWID_Spoofer.Form3
// Assembly: Engine HWID PRO CHANGER 2.0.5, Version=52333.4351.421.534, Culture=neutral, PublicKeyToken=null
// MVID: F1720227-1647-4F5D-AAC2-6AE171A8A256
// Assembly location: C:\Users\Pier\Downloads\GreenCode - Exposed\GreenCode - Exposed\Engine Spoofer 2.0.5\Engine - Cracked by jwanah.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HWID_Spoofer
{
  public class Form3 : Form
  {
    private IContainer components;
    private Timer timer1;
    private ProgressBar progressBar1;

    public Form3() => this.InitializeComponent();

    private void Form3_Load(object sender, EventArgs e)
    {
    }

    private void timer1_Tick(object sender, EventArgs e)
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form3));
      this.timer1 = new Timer(this.components);
      this.progressBar1 = new ProgressBar();
      this.SuspendLayout();
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.progressBar1.Location = new Point(121, 377);
      this.progressBar1.Margin = new Padding(4);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new Size(387, 12);
      this.progressBar1.TabIndex = 0;
      this.AutoScaleDimensions = new SizeF(8f, 16f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImage = (Image) componentResourceManager.GetObject("$this.BackgroundImage");
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.ClientSize = new Size(612, 393);
      this.Controls.Add((Control) this.progressBar1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Margin = new Padding(4);
      this.Name = nameof (Form3);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (Form3);
      this.Load += new EventHandler(this.Form3_Load);
      this.ResumeLayout(false);
    }
  }
}
