using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace _645ClearE;

public class Form2 : Form
{
	private IContainer components = null;

	private Label label1;

	private Button button1;

	private Button button2;

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
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected Obj, but got Unknown
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected Obj, but got Unknown
		label1 = new Label();
		button1 = new Button();
		button2 = new Button();
		((Control)this).SuspendLayout();
		((Control)label1).AutoSize = true;
		((Control)label1).Location = new Point(13, 22);
		((Control)label1).Name = "label1";
		((Control)label1).Size = new Size(245, 24);
		((Control)label1).TabIndex = 0;
		((Control)label1).Text = "校准已完成，请观察监视框中数据是否正常，\r\n点击确定关闭该对话框";
		((Control)button1).Location = new Point(48, 71);
		((Control)button1).Name = "button1";
		((Control)button1).Size = new Size(75, 23);
		((Control)button1).TabIndex = 1;
		((Control)button1).Text = "确定";
		((ButtonBase)button1).UseVisualStyleBackColor = true;
		((Control)button1).Click += button1_Click;
		((Control)button2).Location = new Point(154, 71);
		((Control)button2).Name = "button2";
		((Control)button2).Size = new Size(75, 23);
		((Control)button2).TabIndex = 2;
		((Control)button2).Text = "取消";
		((ButtonBase)button2).UseVisualStyleBackColor = true;
		((Control)button2).Click += button2_Click;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 12f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(320, 114);
		((Control)this).Controls.Add((Control)(object)button2);
		((Control)this).Controls.Add((Control)(object)button1);
		((Control)this).Controls.Add((Control)(object)label1);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "Form2";
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = "确认框";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	public Form2()
	{
		InitializeComponent();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Parameters.CorrectIsOver = true;
		((Form)this).Close();
	}

	private void button2_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}
}
