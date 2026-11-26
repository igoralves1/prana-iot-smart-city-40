using System;
using System.ComponentModel;
using System.IO.Ports;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace _645ClearE;

public class PortConfig : Form
{
	private Modbus m = new Modbus();

	private ResourceManager rm;

	private IContainer components = null;

	private Button button2;

	private Button button1;

	private Label label5;

	private Label label4;

	private Label label2;

	private Label label3;

	private ComboBox comboBoxCheck;

	private ComboBox comboBoxStop;

	private ComboBox comboBoxData;

	private ComboBox comboBoxBaud;

	private ComboBox comboBoxPort;

	private Label label1;

	public PortConfig()
	{
		InitializeComponent();
	}

	public bool check()
	{
		if (Parameters.PortSet.PortNumber != ((Control)comboBoxPort).Text || Parameters.PortSet.PortData != ((Control)comboBoxData).Text || Parameters.PortSet.PortStop != ((Control)comboBoxStop).Text || Parameters.PortSet.PortCheck != ((Control)comboBoxCheck).Text || Parameters.PortSet.PortBaud != ((Control)comboBoxBaud).Text)
		{
			return true;
		}
		return false;
	}

	private void button1_Click(object sender, EventArgs e)
	{
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		if (check())
		{
			Parameters.PortSet.PortNumber = ((Control)comboBoxPort).Text;
			Parameters.PortSet.PortData = ((Control)comboBoxData).Text;
			Parameters.PortSet.PortStop = ((Control)comboBoxStop).Text;
			Parameters.PortSet.PortCheck = ((Control)comboBoxCheck).Text;
			Parameters.PortSet.PortBaud = ((Control)comboBoxBaud).Text;
			if (Modbus.sp.IsOpen)
			{
				m.close();
				Thread.Sleep(200);
				if (m.Open())
				{
					MessageBox.Show("Open " + Parameters.PortSet.PortNumber.ToString() + " successfully");
					((Form)this).Close();
				}
				else
				{
					MessageBox.Show("Open " + Parameters.PortSet.PortNumber.ToString() + " failed");
				}
			}
			else if (m.Open())
			{
				MessageBox.Show("Open " + Parameters.PortSet.PortNumber.ToString() + " successfully");
				((Form)this).Close();
			}
			else
			{
				MessageBox.Show("Open " + Parameters.PortSet.PortNumber.ToString() + " failed");
			}
		}
		else if (Parameters.IsPortOpen == 1)
		{
			MessageBox.Show("Open " + Parameters.PortSet.PortNumber.ToString() + " successfully");
			((Form)this).Close();
		}
		else if (m.Open())
		{
			MessageBox.Show("Open " + Parameters.PortSet.PortNumber.ToString() + " successfully");
			((Form)this).Close();
		}
		else
		{
			MessageBox.Show("Open " + Parameters.PortSet.PortNumber.ToString() + " failed");
		}
	}

	private void PortConfig_Load(object sender, EventArgs e)
	{
		rm = new ResourceManager(typeof(Form1));
		comboBoxPort.Items.Clear();
		string[] portNames = SerialPort.GetPortNames();
		if (portNames.Length != 0)
		{
			((Control)button1).Enabled = true;
			ObjectCollection items = comboBoxPort.Items;
			object[] array = portNames;
			items.AddRange(array);
			((ListControl)comboBoxPort).SelectedIndex = 0;
		}
		((Control)comboBoxPort).Text = Parameters.PortSet.PortNumber;
		((Control)comboBoxData).Text = Parameters.PortSet.PortData;
		((Control)comboBoxStop).Text = Parameters.PortSet.PortStop;
		((Control)comboBoxCheck).Text = Parameters.PortSet.PortCheck;
		((Control)comboBoxBaud).Text = Parameters.PortSet.PortBaud;
	}

	private void button2_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void comboBoxPort_DropDown(object sender, EventArgs e)
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		comboBoxPort.Items.Clear();
		string[] portNames = SerialPort.GetPortNames();
		if (portNames.Length != 0)
		{
			((Control)button1).Enabled = true;
			ObjectCollection items = comboBoxPort.Items;
			object[] array = portNames;
			items.AddRange(array);
			((ListControl)comboBoxPort).SelectedIndex = 0;
		}
		else
		{
			((Control)button1).Enabled = false;
			MessageBox.Show(" No available serial ports");
		}
	}

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
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected Obj, but got Unknown
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected Obj, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected Obj, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected Obj, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected Obj, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected Obj, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected Obj, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected Obj, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected Obj, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected Obj, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected Obj, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(PortConfig));
		button2 = new Button();
		button1 = new Button();
		label5 = new Label();
		label4 = new Label();
		label2 = new Label();
		label3 = new Label();
		comboBoxCheck = new ComboBox();
		comboBoxStop = new ComboBox();
		comboBoxData = new ComboBox();
		comboBoxBaud = new ComboBox();
		comboBoxPort = new ComboBox();
		label1 = new Label();
		((Control)this).SuspendLayout();
		componentResourceManager.ApplyResources(button2, "button2");
		((Control)button2).Name = "button2";
		((ButtonBase)button2).UseVisualStyleBackColor = true;
		((Control)button2).Click += button2_Click;
		componentResourceManager.ApplyResources(button1, "button1");
		((Control)button1).Name = "button1";
		((ButtonBase)button1).UseVisualStyleBackColor = true;
		((Control)button1).Click += button1_Click;
		componentResourceManager.ApplyResources(label5, "label5");
		((Control)label5).Name = "label5";
		componentResourceManager.ApplyResources(label4, "label4");
		((Control)label4).Name = "label4";
		componentResourceManager.ApplyResources(label2, "label2");
		((Control)label2).Name = "label2";
		componentResourceManager.ApplyResources(label3, "label3");
		((Control)label3).Name = "label3";
		comboBoxCheck.DropDownStyle = (ComboBoxStyle)2;
		((ListControl)comboBoxCheck).FormattingEnabled = true;
		comboBoxCheck.Items.AddRange(new object[3]
		{
			componentResourceManager.GetString("comboBoxCheck.Items"),
			componentResourceManager.GetString("comboBoxCheck.Items1"),
			componentResourceManager.GetString("comboBoxCheck.Items2")
		});
		componentResourceManager.ApplyResources(comboBoxCheck, "comboBoxCheck");
		((Control)comboBoxCheck).Name = "comboBoxCheck";
		comboBoxStop.DropDownStyle = (ComboBoxStyle)2;
		((ListControl)comboBoxStop).FormattingEnabled = true;
		comboBoxStop.Items.AddRange(new object[3]
		{
			componentResourceManager.GetString("comboBoxStop.Items"),
			componentResourceManager.GetString("comboBoxStop.Items1"),
			componentResourceManager.GetString("comboBoxStop.Items2")
		});
		componentResourceManager.ApplyResources(comboBoxStop, "comboBoxStop");
		((Control)comboBoxStop).Name = "comboBoxStop";
		comboBoxData.DropDownStyle = (ComboBoxStyle)2;
		((ListControl)comboBoxData).FormattingEnabled = true;
		comboBoxData.Items.AddRange(new object[3]
		{
			componentResourceManager.GetString("comboBoxData.Items"),
			componentResourceManager.GetString("comboBoxData.Items1"),
			componentResourceManager.GetString("comboBoxData.Items2")
		});
		componentResourceManager.ApplyResources(comboBoxData, "comboBoxData");
		((Control)comboBoxData).Name = "comboBoxData";
		comboBoxBaud.DropDownStyle = (ComboBoxStyle)2;
		((ListControl)comboBoxBaud).FormattingEnabled = true;
		comboBoxBaud.Items.AddRange(new object[4]
		{
			componentResourceManager.GetString("comboBoxBaud.Items"),
			componentResourceManager.GetString("comboBoxBaud.Items1"),
			componentResourceManager.GetString("comboBoxBaud.Items2"),
			componentResourceManager.GetString("comboBoxBaud.Items3")
		});
		componentResourceManager.ApplyResources(comboBoxBaud, "comboBoxBaud");
		((Control)comboBoxBaud).Name = "comboBoxBaud";
		comboBoxPort.DropDownStyle = (ComboBoxStyle)2;
		((ListControl)comboBoxPort).FormattingEnabled = true;
		comboBoxPort.Items.AddRange(new object[12]
		{
			componentResourceManager.GetString("comboBoxPort.Items"),
			componentResourceManager.GetString("comboBoxPort.Items1"),
			componentResourceManager.GetString("comboBoxPort.Items2"),
			componentResourceManager.GetString("comboBoxPort.Items3"),
			componentResourceManager.GetString("comboBoxPort.Items4"),
			componentResourceManager.GetString("comboBoxPort.Items5"),
			componentResourceManager.GetString("comboBoxPort.Items6"),
			componentResourceManager.GetString("comboBoxPort.Items7"),
			componentResourceManager.GetString("comboBoxPort.Items8"),
			componentResourceManager.GetString("comboBoxPort.Items9"),
			componentResourceManager.GetString("comboBoxPort.Items10"),
			componentResourceManager.GetString("comboBoxPort.Items11")
		});
		componentResourceManager.ApplyResources(comboBoxPort, "comboBoxPort");
		((Control)comboBoxPort).Name = "comboBoxPort";
		comboBoxPort.DropDown += comboBoxPort_DropDown;
		componentResourceManager.ApplyResources(label1, "label1");
		((Control)label1).Name = "label1";
		componentResourceManager.ApplyResources(this, "$this");
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Control)this).Controls.Add((Control)(object)button2);
		((Control)this).Controls.Add((Control)(object)button1);
		((Control)this).Controls.Add((Control)(object)label5);
		((Control)this).Controls.Add((Control)(object)label4);
		((Control)this).Controls.Add((Control)(object)label2);
		((Control)this).Controls.Add((Control)(object)label3);
		((Control)this).Controls.Add((Control)(object)comboBoxCheck);
		((Control)this).Controls.Add((Control)(object)comboBoxStop);
		((Control)this).Controls.Add((Control)(object)comboBoxData);
		((Control)this).Controls.Add((Control)(object)comboBoxBaud);
		((Control)this).Controls.Add((Control)(object)comboBoxPort);
		((Control)this).Controls.Add((Control)(object)label1);
		((Control)this).Name = "PortConfig";
		((Form)this).Load += PortConfig_Load;
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
