using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace _645ClearE;

public class FormConfig : Form
{
	private IContainer components = null;

	private Label label1;

	private Label label2;

	private Label label3;

	private Label label4;

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
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected Obj, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected Obj, but got Unknown
		label1 = new Label();
		label2 = new Label();
		label3 = new Label();
		label4 = new Label();
		((Control)this).SuspendLayout();
		((Control)label1).AutoSize = true;
		((Control)label1).Font = new Font("宋体", 15.75f, (FontStyle)1, (GraphicsUnit)3, (byte)134);
		((Control)label1).Location = new Point(86, 26);
		((Control)label1).Name = "label1";
		((Control)label1).Size = new Size(230, 21);
		((Control)label1).TabIndex = 0;
		((Control)label1).Text = "AEW100调试软件_V1.0";
		((Control)label2).AutoSize = true;
		((Control)label2).Location = new Point(123, 67);
		((Control)label2).Name = "label2";
		((Control)label2).Size = new Size(107, 12);
		((Control)label2).TabIndex = 1;
		((Control)label2).Text = "Copyright：安科瑞";
		((Control)label3).AutoSize = true;
		((Control)label3).Location = new Point(134, 88);
		((Control)label3).Name = "label3";
		((Control)label3).Size = new Size(95, 12);
		((Control)label3).TabIndex = 2;
		((Control)label3).Text = "Created：余思思";
		((Control)label4).AutoSize = true;
		((Control)label4).Location = new Point(152, 110);
		((Control)label4).Name = "label4";
		((Control)label4).Size = new Size(101, 12);
		((Control)label4).TabIndex = 3;
		((Control)label4).Text = "Date：2016/09/21";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 12f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(399, 156);
		((Control)this).Controls.Add((Control)(object)label4);
		((Control)this).Controls.Add((Control)(object)label3);
		((Control)this).Controls.Add((Control)(object)label2);
		((Control)this).Controls.Add((Control)(object)label1);
		((Control)this).Name = "FormConfig";
		((Control)this).Text = "FormConfig";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	public FormConfig()
	{
		InitializeComponent();
	}
}
