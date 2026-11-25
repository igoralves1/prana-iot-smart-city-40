using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace _645ClearE;

public class Form4 : Form
{
	private IContainer components = null;

	public RichTextBox TXRX;

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		((Form)this).Dispose(disposing);
	}

	private void InitializeComponent()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected Obj, but got Unknown
		TXRX = new RichTextBox();
		((Control)this).SuspendLayout();
		((Control)TXRX).Location = new Point(12, 12);
		((Control)TXRX).Name = "TXRX";
		((Control)TXRX).Size = new Size(493, 302);
		((Control)TXRX).TabIndex = 0;
		((Control)TXRX).Text = "";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 12f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(517, 326);
		((Control)this).Controls.Add((Control)(object)TXRX);
		((Control)this).Name = "Form4";
		((Control)this).Text = "Form4";
		((Form)this).Load += Form4_Load;
		((Control)this).ResumeLayout(false);
	}

	public Form4()
	{
		InitializeComponent();
	}

	private void Form4_Load(object sender, EventArgs e)
	{
	}
}
