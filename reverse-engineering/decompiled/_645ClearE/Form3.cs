using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace _645ClearE;

public class Form3 : Form
{
	private IContainer components = null;

	private TextBox 端口号;

	private Label label184;

	private TextBox IP4text;

	private TextBox IP3text;

	private TextBox IP2text;

	private TextBox IP1text;

	private Label label185;

	private Label label182;

	private TextBox 上传间隔;

	private Label label183;

	private Label label360;

	private TextBox 端口数;

	private Label label365;

	private ComboBox 地域;

	private GroupBox groupBox71;

	private TextBox WIFI名称textBox;

	private TextBox WIFI密码textBox;

	private Button WIFI设置button;

	private Button WIFI读取button;

	private Label label744;

	private Label label748;

	private Label label1;

	private Button button1;

	private Button button2;

	private GroupBox groupBox1;

	private GroupBox groupBox3;

	private Button button3;

	private Button button4;

	private Label label2;

	private Label label3;

	private TextBox textBox1;

	private TextBox textBox2;

	private GroupBox groupBox2;

	private TextBox 域名1;

	private Label label371;

	private Label label848;

	private TextBox HW_NUM;

	private Label label849;

	private Label set_SerialNum;

	private TextBox Serial;

	private ComboBox HW_Qos;

	private GroupBox groupBox4;

	private Label label4;

	private Label label5;

	private Button button5;

	private Button button6;

	private TextBox password;

	private TextBox usename;

	private Modbus m = new Modbus();

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
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected Obj, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected Obj, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected Obj, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected Obj, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected Obj, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected Obj, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected Obj, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected Obj, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected Obj, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected Obj, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected Obj, but got Unknown
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected Obj, but got Unknown
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected Obj, but got Unknown
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected Obj, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected Obj, but got Unknown
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected Obj, but got Unknown
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected Obj, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected Obj, but got Unknown
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected Obj, but got Unknown
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected Obj, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected Obj, but got Unknown
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected Obj, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected Obj, but got Unknown
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Expected Obj, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected Obj, but got Unknown
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected Obj, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected Obj, but got Unknown
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Expected Obj, but got Unknown
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected Obj, but got Unknown
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Expected Obj, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected Obj, but got Unknown
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Expected Obj, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected Obj, but got Unknown
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Expected Obj, but got Unknown
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected Obj, but got Unknown
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Expected Obj, but got Unknown
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected Obj, but got Unknown
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Expected Obj, but got Unknown
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected Obj, but got Unknown
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Expected Obj, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected Obj, but got Unknown
		//IL_0a27: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a31: Expected Obj, but got Unknown
		//IL_0ac2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0acc: Expected Obj, but got Unknown
		//IL_0bad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb7: Expected Obj, but got Unknown
		//IL_0c4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c59: Expected Obj, but got Unknown
		//IL_122f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1239: Expected Obj, but got Unknown
		//IL_1399: Unknown result type (might be due to invalid IL or missing references)
		//IL_13a3: Expected Obj, but got Unknown
		//IL_15e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ea: Expected Obj, but got Unknown
		//IL_19ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_19b8: Expected Obj, but got Unknown
		端口号 = new TextBox();
		label184 = new Label();
		IP4text = new TextBox();
		IP3text = new TextBox();
		IP2text = new TextBox();
		IP1text = new TextBox();
		label185 = new Label();
		label182 = new Label();
		上传间隔 = new TextBox();
		label183 = new Label();
		label360 = new Label();
		端口数 = new TextBox();
		label365 = new Label();
		地域 = new ComboBox();
		groupBox71 = new GroupBox();
		groupBox3 = new GroupBox();
		label848 = new Label();
		HW_NUM = new TextBox();
		label849 = new Label();
		set_SerialNum = new Label();
		Serial = new TextBox();
		HW_Qos = new ComboBox();
		button3 = new Button();
		button4 = new Button();
		label2 = new Label();
		label3 = new Label();
		textBox1 = new TextBox();
		textBox2 = new TextBox();
		groupBox2 = new GroupBox();
		域名1 = new TextBox();
		label371 = new Label();
		label1 = new Label();
		button1 = new Button();
		button2 = new Button();
		groupBox1 = new GroupBox();
		label748 = new Label();
		label744 = new Label();
		WIFI读取button = new Button();
		WIFI设置button = new Button();
		WIFI密码textBox = new TextBox();
		WIFI名称textBox = new TextBox();
		groupBox4 = new GroupBox();
		label4 = new Label();
		label5 = new Label();
		button5 = new Button();
		button6 = new Button();
		password = new TextBox();
		usename = new TextBox();
		((Control)groupBox71).SuspendLayout();
		((Control)groupBox3).SuspendLayout();
		((Control)groupBox2).SuspendLayout();
		((Control)groupBox1).SuspendLayout();
		((Control)groupBox4).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)端口号).Location = new Point(52, 109);
		((TextBoxBase)端口号).MaxLength = 6;
		((Control)端口号).Name = "端口号";
		((Control)端口号).Size = new Size(62, 23);
		((Control)端口号).TabIndex = 10;
		((Control)label184).AutoSize = true;
		label184.ImeMode = (ImeMode)0;
		((Control)label184).Location = new Point(10, 112);
		((Control)label184).Name = "label184";
		((Control)label184).Size = new Size(44, 17);
		((Control)label184).TabIndex = 9;
		((Control)label184).Text = "Port：";
		((Control)IP4text).Location = new Point(185, 49);
		((TextBoxBase)IP4text).MaxLength = 3;
		((Control)IP4text).Name = "IP4text";
		((Control)IP4text).Size = new Size(37, 23);
		((Control)IP4text).TabIndex = 8;
		((Control)IP3text).Location = new Point(147, 49);
		((TextBoxBase)IP3text).MaxLength = 3;
		((Control)IP3text).Name = "IP3text";
		((Control)IP3text).Size = new Size(37, 23);
		((Control)IP3text).TabIndex = 7;
		((Control)IP2text).Location = new Point(108, 49);
		((TextBoxBase)IP2text).MaxLength = 3;
		((Control)IP2text).Name = "IP2text";
		((Control)IP2text).Size = new Size(37, 23);
		((Control)IP2text).TabIndex = 5;
		((Control)IP1text).Location = new Point(69, 49);
		((TextBoxBase)IP1text).MaxLength = 3;
		((Control)IP1text).Name = "IP1text";
		((Control)IP1text).Size = new Size(37, 23);
		((Control)IP1text).TabIndex = 6;
		((Control)label185).AutoSize = true;
		label185.ImeMode = (ImeMode)0;
		((Control)label185).Location = new Point(10, 52);
		((Control)label185).Name = "label185";
		((Control)label185).Size = new Size(31, 17);
		((Control)label185).TabIndex = 4;
		((Control)label185).Text = "IP：";
		((Control)label182).AutoSize = true;
		label182.ImeMode = (ImeMode)0;
		((Control)label182).Location = new Point(166, 143);
		((Control)label182).Name = "label182";
		((Control)label182).Size = new Size(30, 17);
		((Control)label182).TabIndex = 13;
		((Control)label182).Text = "Min";
		((Control)label182).Visible = false;
		((Control)上传间隔).Location = new Point(123, 140);
		((TextBoxBase)上传间隔).MaxLength = 3;
		((Control)上传间隔).Name = "上传间隔";
		((Control)上传间隔).Size = new Size(37, 23);
		((Control)上传间隔).TabIndex = 12;
		((Control)label183).AutoSize = true;
		label183.ImeMode = (ImeMode)0;
		((Control)label183).Location = new Point(8, 143);
		((Control)label183).Name = "label183";
		((Control)label183).Size = new Size(109, 17);
		((Control)label183).TabIndex = 11;
		((Control)label183).Text = "Upload interval：";
		((Control)label360).AutoSize = true;
		label360.ImeMode = (ImeMode)0;
		((Control)label360).Location = new Point(129, 112);
		((Control)label360).Name = "label360";
		((Control)label360).Size = new Size(96, 17);
		((Control)label360).TabIndex = 56;
		((Control)label360).Text = "Port Number：";
		((Control)端口数).Location = new Point(225, 109);
		((TextBoxBase)端口数).MaxLength = 3;
		((Control)端口数).Name = "端口数";
		((Control)端口数).Size = new Size(37, 23);
		((Control)端口数).TabIndex = 57;
		((Control)label365).AutoSize = true;
		label365.ImeMode = (ImeMode)0;
		((Control)label365).Location = new Point(10, 19);
		((Control)label365).Name = "label365";
		((Control)label365).Size = new Size(120, 17);
		((Control)label365).TabIndex = 68;
		((Control)label365).Text = "IP/Domain Name：";
		地域.DropDownStyle = (ComboBoxStyle)2;
		((ListControl)地域).FormattingEnabled = true;
		地域.Items.AddRange(new object[2] { "IP地址", "域名" });
		((Control)地域).Location = new Point(132, 16);
		((Control)地域).Name = "地域";
		((Control)地域).Size = new Size(60, 25);
		((Control)地域).TabIndex = 67;
		地域.SelectedIndexChanged += 地域_SelectedIndexChanged;
		((Control)groupBox71).Controls.Add((Control)(object)groupBox4);
		((Control)groupBox71).Controls.Add((Control)(object)groupBox3);
		((Control)groupBox71).Controls.Add((Control)(object)groupBox2);
		((Control)groupBox71).Controls.Add((Control)(object)groupBox1);
		((Control)groupBox71).Location = new Point(12, 12);
		((Control)groupBox71).Name = "groupBox71";
		((Control)groupBox71).Size = new Size(380, 616);
		((Control)groupBox71).TabIndex = 69;
		groupBox71.TabStop = false;
		((Control)groupBox71).Enter += groupBox71_Enter;
		((Control)groupBox3).Controls.Add((Control)(object)label848);
		((Control)groupBox3).Controls.Add((Control)(object)HW_NUM);
		((Control)groupBox3).Controls.Add((Control)(object)label849);
		((Control)groupBox3).Controls.Add((Control)(object)set_SerialNum);
		((Control)groupBox3).Controls.Add((Control)(object)Serial);
		((Control)groupBox3).Controls.Add((Control)(object)HW_Qos);
		((Control)groupBox3).Controls.Add((Control)(object)button3);
		((Control)groupBox3).Controls.Add((Control)(object)button4);
		((Control)groupBox3).Controls.Add((Control)(object)label2);
		((Control)groupBox3).Controls.Add((Control)(object)label3);
		((Control)groupBox3).Controls.Add((Control)(object)textBox1);
		((Control)groupBox3).Controls.Add((Control)(object)textBox2);
		((Control)groupBox3).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)groupBox3).Location = new Point(15, 309);
		((Control)groupBox3).Name = "groupBox3";
		((Control)groupBox3).Size = new Size(355, 178);
		((Control)groupBox3).TabIndex = 83;
		groupBox3.TabStop = false;
		((Control)groupBox3).Text = "utc";
		((Control)label848).AutoSize = true;
		((Control)label848).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		label848.ImeMode = (ImeMode)0;
		((Control)label848).Location = new Point(10, 152);
		((Control)label848).Name = "label848";
		((Control)label848).Size = new Size(60, 17);
		((Control)label848).TabIndex = 384;
		((Control)label848).Text = "Datanum";
		((Control)HW_NUM).Location = new Point(80, 148);
		((Control)HW_NUM).Name = "HW_NUM";
		((Control)HW_NUM).Size = new Size(70, 23);
		((Control)HW_NUM).TabIndex = 383;
		((Control)label849).AutoSize = true;
		((Control)label849).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		label849.ImeMode = (ImeMode)0;
		((Control)label849).Location = new Point(10, 121);
		((Control)label849).Name = "label849";
		((Control)label849).Size = new Size(35, 17);
		((Control)label849).TabIndex = 382;
		((Control)label849).Text = "QOS";
		((Control)set_SerialNum).AutoSize = true;
		set_SerialNum.FlatStyle = (FlatStyle)3;
		((Control)set_SerialNum).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		set_SerialNum.ImeMode = (ImeMode)0;
		((Control)set_SerialNum).Location = new Point(10, 89);
		((Control)set_SerialNum).Name = "set_SerialNum";
		((Control)set_SerialNum).Size = new Size(68, 17);
		((Control)set_SerialNum).TabIndex = 381;
		((Control)set_SerialNum).Text = "SerialNum";
		((Control)Serial).Location = new Point(80, 85);
		((TextBoxBase)Serial).MaxLength = 30;
		((Control)Serial).Name = "Serial";
		((Control)Serial).Size = new Size(169, 23);
		((Control)Serial).TabIndex = 380;
		((ListControl)HW_Qos).FormattingEnabled = true;
		HW_Qos.Items.AddRange(new object[3] { "0", "1", "2" });
		((Control)HW_Qos).Location = new Point(80, 117);
		((Control)HW_Qos).Name = "HW_Qos";
		((Control)HW_Qos).Size = new Size(44, 25);
		((Control)HW_Qos).TabIndex = 379;
		((ButtonBase)button3).ImeMode = (ImeMode)0;
		((Control)button3).Location = new Point(282, 148);
		((Control)button3).Name = "button3";
		((Control)button3).Size = new Size(55, 23);
		((Control)button3).TabIndex = 84;
		((Control)button3).Text = "Set";
		((ButtonBase)button3).UseVisualStyleBackColor = true;
		((Control)button3).Click += button3_Click;
		((ButtonBase)button4).ImeMode = (ImeMode)0;
		((Control)button4).Location = new Point(221, 148);
		((Control)button4).Name = "button4";
		((Control)button4).Size = new Size(55, 23);
		((Control)button4).TabIndex = 83;
		((Control)button4).Text = "Read";
		((ButtonBase)button4).UseVisualStyleBackColor = true;
		((Control)button4).Click += button4_Click;
		((Control)label2).AutoSize = true;
		label2.ImeMode = (ImeMode)0;
		((Control)label2).Location = new Point(10, 26);
		((Control)label2).Name = "label2";
		((Control)label2).Size = new Size(63, 17);
		((Control)label2).TabIndex = 79;
		((Control)label2).Text = "country：";
		((Control)label3).AutoSize = true;
		label3.ImeMode = (ImeMode)0;
		((Control)label3).Location = new Point(10, 56);
		((Control)label3).Name = "label3";
		((Control)label3).Size = new Size(44, 17);
		((Control)label3).TabIndex = 81;
		((Control)label3).Text = "UTC：";
		((Control)textBox1).Location = new Point(80, 20);
		((TextBoxBase)textBox1).MaxLength = 6;
		((Control)textBox1).Name = "textBox1";
		((Control)textBox1).Size = new Size(88, 23);
		((Control)textBox1).TabIndex = 80;
		((Control)textBox2).Location = new Point(80, 56);
		((TextBoxBase)textBox2).MaxLength = 6;
		((Control)textBox2).Name = "textBox2";
		((Control)textBox2).Size = new Size(88, 23);
		((Control)textBox2).TabIndex = 82;
		((Control)groupBox2).Controls.Add((Control)(object)域名1);
		((Control)groupBox2).Controls.Add((Control)(object)label371);
		((Control)groupBox2).Controls.Add((Control)(object)label185);
		((Control)groupBox2).Controls.Add((Control)(object)IP4text);
		((Control)groupBox2).Controls.Add((Control)(object)label1);
		((Control)groupBox2).Controls.Add((Control)(object)IP3text);
		((Control)groupBox2).Controls.Add((Control)(object)label365);
		((Control)groupBox2).Controls.Add((Control)(object)地域);
		((Control)groupBox2).Controls.Add((Control)(object)button1);
		((Control)groupBox2).Controls.Add((Control)(object)label184);
		((Control)groupBox2).Controls.Add((Control)(object)label360);
		((Control)groupBox2).Controls.Add((Control)(object)端口数);
		((Control)groupBox2).Controls.Add((Control)(object)IP2text);
		((Control)groupBox2).Controls.Add((Control)(object)button2);
		((Control)groupBox2).Controls.Add((Control)(object)端口号);
		((Control)groupBox2).Controls.Add((Control)(object)IP1text);
		((Control)groupBox2).Controls.Add((Control)(object)label183);
		((Control)groupBox2).Controls.Add((Control)(object)上传间隔);
		((Control)groupBox2).Controls.Add((Control)(object)label182);
		((Control)groupBox2).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)groupBox2).Location = new Point(15, 126);
		((Control)groupBox2).Name = "groupBox2";
		((Control)groupBox2).Size = new Size(355, 177);
		((Control)groupBox2).TabIndex = 78;
		groupBox2.TabStop = false;
		((Control)groupBox2).Text = "Ip";
		((Control)域名1).Location = new Point(110, 78);
		((TextBoxBase)域名1).MaxLength = 50;
		((Control)域名1).Name = "域名1";
		((Control)域名1).Size = new Size(236, 23);
		((Control)域名1).TabIndex = 79;
		((Control)label371).AutoSize = true;
		label371.ImeMode = (ImeMode)0;
		((Control)label371).Location = new Point(10, 80);
		((Control)label371).Name = "label371";
		((Control)label371).Size = new Size(104, 17);
		((Control)label371).TabIndex = 78;
		((Control)label371).Text = "Domain Name：";
		((Control)label1).AutoSize = true;
		((Control)label1).Font = new Font("微软雅黑", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)134);
		label1.ImeMode = (ImeMode)0;
		((Control)label1).Location = new Point(263, 112);
		((Control)label1).Name = "label1";
		((Control)label1).Size = new Size(89, 17);
		((Control)label1).TabIndex = 77;
		((Control)label1).Text = "（Default 1）";
		((Control)label1).Visible = false;
		((ButtonBase)button1).ImeMode = (ImeMode)0;
		((Control)button1).Location = new Point(282, 148);
		((Control)button1).Name = "button1";
		((Control)button1).Size = new Size(55, 23);
		((Control)button1).TabIndex = 76;
		((Control)button1).Text = "Set";
		((ButtonBase)button1).UseVisualStyleBackColor = true;
		((Control)button1).Click += button1_Click;
		((ButtonBase)button2).ImeMode = (ImeMode)0;
		((Control)button2).Location = new Point(221, 148);
		((Control)button2).Name = "button2";
		((Control)button2).Size = new Size(55, 23);
		((Control)button2).TabIndex = 75;
		((Control)button2).Text = "Read";
		((ButtonBase)button2).UseVisualStyleBackColor = true;
		((Control)button2).Click += button2_Click;
		((Control)groupBox1).Controls.Add((Control)(object)label748);
		((Control)groupBox1).Controls.Add((Control)(object)label744);
		((Control)groupBox1).Controls.Add((Control)(object)WIFI读取button);
		((Control)groupBox1).Controls.Add((Control)(object)WIFI设置button);
		((Control)groupBox1).Controls.Add((Control)(object)WIFI密码textBox);
		((Control)groupBox1).Controls.Add((Control)(object)WIFI名称textBox);
		((Control)groupBox1).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)groupBox1).Location = new Point(15, 20);
		((Control)groupBox1).Name = "groupBox1";
		((Control)groupBox1).Size = new Size(355, 100);
		((Control)groupBox1).TabIndex = 70;
		groupBox1.TabStop = false;
		((Control)groupBox1).Text = "wifi";
		((Control)label748).AutoSize = true;
		label748.ImeMode = (ImeMode)0;
		((Control)label748).Location = new Point(6, 17);
		((Control)label748).Name = "label748";
		((Control)label748).Size = new Size(82, 17);
		((Control)label748).TabIndex = 13;
		((Control)label748).Text = "WIFI name：";
		((Control)label744).AutoSize = true;
		label744.ImeMode = (ImeMode)0;
		((Control)label744).Location = new Point(4, 44);
		((Control)label744).Name = "label744";
		((Control)label744).Size = new Size(103, 17);
		((Control)label744).TabIndex = 14;
		((Control)label744).Text = "WIFIpassword：";
		((ButtonBase)WIFI读取button).ImeMode = (ImeMode)0;
		((Control)WIFI读取button).Location = new Point(218, 71);
		((Control)WIFI读取button).Name = "WIFI读取button";
		((Control)WIFI读取button).Size = new Size(55, 23);
		((Control)WIFI读取button).TabIndex = 69;
		((Control)WIFI读取button).Text = "Read";
		((ButtonBase)WIFI读取button).UseVisualStyleBackColor = true;
		((Control)WIFI读取button).Click += WIFI读取button_Click;
		((ButtonBase)WIFI设置button).ImeMode = (ImeMode)0;
		((Control)WIFI设置button).Location = new Point(279, 71);
		((Control)WIFI设置button).Name = "WIFI设置button";
		((Control)WIFI设置button).Size = new Size(55, 23);
		((Control)WIFI设置button).TabIndex = 70;
		((Control)WIFI设置button).Text = "Set";
		((ButtonBase)WIFI设置button).UseVisualStyleBackColor = true;
		((Control)WIFI设置button).Click += WIFI设置button_Click;
		((Control)WIFI密码textBox).Location = new Point(107, 41);
		((TextBoxBase)WIFI密码textBox).MaxLength = 50;
		((Control)WIFI密码textBox).Name = "WIFI密码textBox";
		((Control)WIFI密码textBox).Size = new Size(239, 23);
		((Control)WIFI密码textBox).TabIndex = 73;
		((Control)WIFI名称textBox).Location = new Point(107, 16);
		((TextBoxBase)WIFI名称textBox).MaxLength = 50;
		((Control)WIFI名称textBox).Name = "WIFI名称textBox";
		((Control)WIFI名称textBox).Size = new Size(239, 23);
		((Control)WIFI名称textBox).TabIndex = 74;
		((Control)groupBox4).Controls.Add((Control)(object)label4);
		((Control)groupBox4).Controls.Add((Control)(object)label5);
		((Control)groupBox4).Controls.Add((Control)(object)button5);
		((Control)groupBox4).Controls.Add((Control)(object)button6);
		((Control)groupBox4).Controls.Add((Control)(object)password);
		((Control)groupBox4).Controls.Add((Control)(object)usename);
		((Control)groupBox4).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)groupBox4).Location = new Point(15, 502);
		((Control)groupBox4).Name = "groupBox4";
		((Control)groupBox4).Size = new Size(355, 100);
		((Control)groupBox4).TabIndex = 71;
		groupBox4.TabStop = false;
		((Control)groupBox4).Text = "mqtt";
		((Control)label4).AutoSize = true;
		label4.ImeMode = (ImeMode)0;
		((Control)label4).Location = new Point(6, 17);
		((Control)label4).Name = "label4";
		((Control)label4).Size = new Size(63, 17);
		((Control)label4).TabIndex = 13;
		((Control)label4).Text = "usename:";
		((Control)label5).AutoSize = true;
		label5.ImeMode = (ImeMode)0;
		((Control)label5).Location = new Point(4, 44);
		((Control)label5).Name = "label5";
		((Control)label5).Size = new Size(68, 17);
		((Control)label5).TabIndex = 14;
		((Control)label5).Text = "password:";
		((ButtonBase)button5).ImeMode = (ImeMode)0;
		((Control)button5).Location = new Point(218, 71);
		((Control)button5).Name = "button5";
		((Control)button5).Size = new Size(55, 23);
		((Control)button5).TabIndex = 69;
		((Control)button5).Text = "Read";
		((ButtonBase)button5).UseVisualStyleBackColor = true;
		((Control)button5).Click += button5_Click;
		((ButtonBase)button6).ImeMode = (ImeMode)0;
		((Control)button6).Location = new Point(279, 71);
		((Control)button6).Name = "button6";
		((Control)button6).Size = new Size(55, 23);
		((Control)button6).TabIndex = 70;
		((Control)button6).Text = "Set";
		((ButtonBase)button6).UseVisualStyleBackColor = true;
		((Control)password).Location = new Point(80, 41);
		((TextBoxBase)password).MaxLength = 50;
		((Control)password).Name = "password";
		((Control)password).Size = new Size(266, 23);
		((Control)password).TabIndex = 73;
		((Control)usename).Location = new Point(80, 16);
		((TextBoxBase)usename).MaxLength = 50;
		((Control)usename).Name = "usename";
		((Control)usename).Size = new Size(266, 23);
		((Control)usename).TabIndex = 74;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 12f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(401, 637);
		((Control)this).Controls.Add((Control)(object)groupBox71);
		((Form)this).MaximizeBox = false;
		((Control)this).Name = "Form3";
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = "IOT";
		((Form)this).Load += Form3_Load;
		((Control)groupBox71).ResumeLayout(false);
		((Control)groupBox3).ResumeLayout(false);
		((Control)groupBox3).PerformLayout();
		((Control)groupBox2).ResumeLayout(false);
		((Control)groupBox2).PerformLayout();
		((Control)groupBox1).ResumeLayout(false);
		((Control)groupBox1).PerformLayout();
		((Control)groupBox4).ResumeLayout(false);
		((Control)groupBox4).PerformLayout();
		((Control)this).ResumeLayout(false);
	}

	public Form3()
	{
		InitializeComponent();
	}

	private bool CheckAddr()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		if (Parameters.IsRightAddr != 1)
		{
			MessageBox.Show("请确认已输入正确的地址！");
			return false;
		}
		if (Parameters.IsPortOpen > 0)
		{
			return true;
		}
		MessageBox.Show("请先打开串口！");
		return false;
	}

	private void groupBox71_Enter(object sender, EventArgs e)
	{
	}

	private void WIFI读取button_Click(object sender, EventArgs e)
	{
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		if (!CheckAddr())
		{
			return;
		}
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[45];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Parameters.Address);
		array[1] = 3;
		array[2] = 96;
		array[3] = 187;
		array[4] = 0;
		array[5] = 20;
		m.GetCRC(array, ref CRC);
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			Thread.Sleep(20);
			m.GetResponse(ref response);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
			return;
		}
		if (m.CheckResponse(response))
		{
			string text = "";
			byte[] array2 = new byte[20];
			for (int i = 0; i < 20; i++)
			{
				array2[i] = response[3 + i];
			}
			text = Encoding.ASCII.GetString(array2);
			((Control)WIFI名称textBox).Text = text;
			for (int i = 0; i < 20; i++)
			{
				array2[i] = response[23 + i];
			}
			text = Encoding.ASCII.GetString(array2);
			((Control)WIFI密码textBox).Text = text;
			MessageBox.Show("读取成功");
		}
		else
		{
			MessageBox.Show("没有回复或校验错误");
		}
	}

	private void WIFI设置button_Click(object sender, EventArgs e)
	{
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		byte[] CRC = new byte[2];
		if (CheckAddr())
		{
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array = new byte[49];
			byte[] response = new byte[8];
			array[0] = Convert.ToByte(Parameters.Address);
			array[1] = 16;
			array[2] = 96;
			array[3] = 187;
			array[4] = 0;
			array[5] = 20;
			array[6] = 40;
			string s = Convert.ToString(((Control)WIFI名称textBox).Text);
			byte[] bytes = Encoding.ASCII.GetBytes(s);
			int num = 20 - bytes.Length;
			for (int i = 0; i < bytes.Length; i++)
			{
				array[7 + i] = bytes[i];
			}
			for (int i = 0; i < num; i++)
			{
				array[7 + bytes.Length + i] = 0;
			}
			string s2 = Convert.ToString(((Control)WIFI密码textBox).Text);
			byte[] bytes2 = Encoding.ASCII.GetBytes(s2);
			int num2 = 20 - bytes2.Length;
			for (int i = 0; i < bytes2.Length; i++)
			{
				array[27 + i] = bytes2[i];
			}
			for (int i = 0; i < num2; i++)
			{
				array[27 + bytes2.Length + i] = 0;
			}
			m.GetCRC(array, ref CRC);
			m.GetCRC(array, ref CRC);
			array[^2] = CRC[0];
			array[^1] = CRC[1];
			try
			{
				Modbus.sp.Write(array, 0, array.Length);
				Thread.Sleep(20);
				m.GetResponse(ref response);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}
			if (m.CheckResponse(response))
			{
				MessageBox.Show("设置成功");
			}
			else
			{
				MessageBox.Show("未能成功设置");
			}
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_043a: Unknown result type (might be due to invalid IL or missing references)
		//IL_042b: Unknown result type (might be due to invalid IL or missing references)
		if (!CheckAddr())
		{
			return;
		}
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[43];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Parameters.Address);
		array[1] = 3;
		array[2] = 96;
		array[3] = 0;
		array[4] = 0;
		array[5] = 19;
		m.GetCRC(array, ref CRC);
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			Thread.Sleep(20);
			m.GetResponse(ref response);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
			return;
		}
		if (m.CheckResponse(response))
		{
			((Control)上传间隔).Text = ((response[6] << 8) | response[5]).ToString();
			((Control)IP1text).Text = response[23].ToString();
			((Control)IP2text).Text = response[24].ToString();
			((Control)IP3text).Text = response[25].ToString();
			((Control)IP4text).Text = response[26].ToString();
			((Control)端口号).Text = ((response[36] << 8) | response[35]).ToString();
			if (!CheckAddr())
			{
				return;
			}
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array2 = new byte[8];
			byte[] response2 = new byte[155];
			byte[] CRC2 = new byte[2];
			array2[0] = Convert.ToByte(Parameters.Address);
			array2[1] = 3;
			array2[2] = 96;
			array2[3] = 22;
			array2[4] = 0;
			array2[5] = 75;
			m.GetCRC(array2, ref CRC2);
			m.GetCRC(array2, ref CRC2);
			array2[^2] = CRC2[0];
			array2[^1] = CRC2[1];
			try
			{
				Modbus.sp.Write(array2, 0, array2.Length);
				Thread.Sleep(20);
				m.GetResponse(ref response2);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}
			if (m.CheckResponse(response2))
			{
				string text = "";
				byte[] array3 = new byte[50];
				for (int i = 0; i < 50; i++)
				{
					array3[i] = response2[3 + i];
				}
				text = Encoding.ASCII.GetString(array3);
				((Control)域名1).Text = text;
				if (CheckAddr())
				{
					Modbus.sp.DiscardOutBuffer();
					Modbus.sp.DiscardInBuffer();
					byte[] array4 = new byte[8];
					byte[] response3 = new byte[11];
					byte[] CRC3 = new byte[2];
					array4[0] = Convert.ToByte(Parameters.Address);
					array4[1] = 3;
					array4[2] = 96;
					array4[3] = 19;
					array4[4] = 0;
					array4[5] = 3;
					m.GetCRC(array4, ref CRC3);
					m.GetCRC(array4, ref CRC3);
					array4[^2] = CRC3[0];
					array4[^1] = CRC3[1];
					try
					{
						Modbus.sp.Write(array4, 0, array4.Length);
						Thread.Sleep(20);
						m.GetResponse(ref response3);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
						return;
					}
					if (m.CheckResponse(response3))
					{
						((Control)端口数).Text = response3[3].ToString();
						((ListControl)地域).SelectedIndex = response3[7];
						MessageBox.Show("读取成功");
					}
					else
					{
						MessageBox.Show("没有回复或校验错误");
					}
				}
			}
			else
			{
				MessageBox.Show("没有回复或校验错误");
			}
		}
		else
		{
			MessageBox.Show("没有回复或校验错误");
		}
	}

	private void Form3_Load(object sender, EventArgs e)
	{
		((Control)域名1).Enabled = false;
		((Control)IP1text).Enabled = false;
		((Control)IP2text).Enabled = false;
		((Control)IP3text).Enabled = false;
		((Control)IP4text).Enabled = false;
		if (((ListControl)地域).SelectedIndex == 0)
		{
			((Control)域名1).Enabled = false;
			((Control)IP1text).Enabled = true;
			((Control)IP2text).Enabled = true;
			((Control)IP3text).Enabled = true;
			((Control)IP4text).Enabled = true;
		}
		else if (((ListControl)地域).SelectedIndex == 1)
		{
			((Control)域名1).Enabled = true;
			((Control)IP1text).Enabled = false;
			((Control)IP2text).Enabled = false;
			((Control)IP3text).Enabled = false;
			((Control)IP4text).Enabled = false;
		}
		else
		{
			((Control)域名1).Enabled = false;
			((Control)IP1text).Enabled = false;
			((Control)IP2text).Enabled = false;
			((Control)IP3text).Enabled = false;
			((Control)IP4text).Enabled = false;
		}
	}

	private void 地域_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (((ListControl)地域).SelectedIndex == 0)
		{
			((Control)域名1).Enabled = false;
			((Control)IP1text).Enabled = true;
			((Control)IP2text).Enabled = true;
			((Control)IP3text).Enabled = true;
			((Control)IP4text).Enabled = true;
		}
		else if (((ListControl)地域).SelectedIndex == 1)
		{
			((Control)域名1).Enabled = true;
			((Control)IP1text).Enabled = false;
			((Control)IP2text).Enabled = false;
			((Control)IP3text).Enabled = false;
			((Control)IP4text).Enabled = false;
		}
		else
		{
			((Control)域名1).Enabled = false;
			((Control)IP1text).Enabled = false;
			((Control)IP2text).Enabled = false;
			((Control)IP3text).Enabled = false;
			((Control)IP4text).Enabled = false;
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0370: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_061e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_039c: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0652: Unknown result type (might be due to invalid IL or missing references)
		//IL_0643: Unknown result type (might be due to invalid IL or missing references)
		byte[] CRC = new byte[2];
		if (!CheckAddr())
		{
			return;
		}
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[11];
		byte[] response = new byte[8];
		array[0] = Convert.ToByte(Parameters.Address);
		array[1] = 16;
		array[2] = 96;
		array[3] = 1;
		array[4] = 0;
		array[5] = 1;
		array[6] = 2;
		array[8] = (byte)(Convert.ToInt32(((Control)上传间隔).Text) >> 8);
		array[7] = (byte)Convert.ToInt32(((Control)上传间隔).Text);
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			Thread.Sleep(20);
			m.GetResponse(ref response);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
			return;
		}
		if (!m.CheckResponse(response))
		{
			MessageBox.Show("未能成功设置");
			return;
		}
		byte[] CRC2 = new byte[2];
		if (!CheckAddr())
		{
			return;
		}
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array2 = new byte[13];
		byte[] response2 = new byte[8];
		array2[0] = Convert.ToByte(Parameters.Address);
		array2[1] = 16;
		array2[2] = 96;
		array2[3] = 10;
		array2[4] = 0;
		array2[5] = 2;
		array2[6] = 4;
		array2[7] = (byte)Convert.ToInt32(((Control)IP1text).Text);
		array2[8] = (byte)Convert.ToInt32(((Control)IP2text).Text);
		array2[9] = (byte)Convert.ToInt32(((Control)IP3text).Text);
		array2[10] = (byte)Convert.ToInt32(((Control)IP4text).Text);
		m.GetCRC(array2, ref CRC2);
		array2[^2] = CRC2[0];
		array2[^1] = CRC2[1];
		try
		{
			Modbus.sp.Write(array2, 0, array2.Length);
			Thread.Sleep(20);
			m.GetResponse(ref response2);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
			return;
		}
		if (!m.CheckResponse(response2))
		{
			MessageBox.Show("未能成功设置");
			return;
		}
		byte[] CRC3 = new byte[2];
		if (!CheckAddr())
		{
			return;
		}
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array3 = new byte[11];
		byte[] response3 = new byte[8];
		array3[0] = Convert.ToByte(Parameters.Address);
		array3[1] = 16;
		array3[2] = 96;
		array3[3] = 16;
		array3[4] = 0;
		array3[5] = 1;
		array3[6] = 2;
		array3[8] = (byte)(Convert.ToInt32(((Control)端口号).Text) >> 8);
		array3[7] = (byte)Convert.ToInt32(((Control)端口号).Text);
		m.GetCRC(array3, ref CRC3);
		array3[^2] = CRC3[0];
		array3[^1] = CRC3[1];
		try
		{
			Modbus.sp.Write(array3, 0, array3.Length);
			Thread.Sleep(20);
			m.GetResponse(ref response3);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
			return;
		}
		if (!m.CheckResponse(response3))
		{
			MessageBox.Show("未能成功设置");
		}
		else
		{
			if (!CheckAddr())
			{
				return;
			}
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array4 = new byte[15];
			byte[] response4 = new byte[8];
			byte[] CRC4 = new byte[2];
			array4[0] = Convert.ToByte(Parameters.Address);
			array4[1] = 16;
			array4[2] = 96;
			array4[3] = 19;
			array4[4] = 0;
			array4[5] = 3;
			array4[6] = 6;
			array4[7] = (byte)Convert.ToInt32(((Control)端口数).Text);
			array4[11] = (byte)((ListControl)地域).SelectedIndex;
			array4[12] = 0;
			m.GetCRC(array4, ref CRC4);
			array4[^2] = CRC4[0];
			array4[^1] = CRC4[1];
			try
			{
				Modbus.sp.Write(array4, 0, array4.Length);
				Thread.Sleep(20);
				m.GetResponse(ref response4);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}
			if (!m.CheckResponse(response4))
			{
				MessageBox.Show("未能成功设置");
			}
			else if (CheckAddr())
			{
				Modbus.sp.DiscardOutBuffer();
				Modbus.sp.DiscardInBuffer();
				byte[] array5 = new byte[89];
				byte[] response5 = new byte[8];
				byte[] CRC5 = new byte[2];
				array5[0] = Convert.ToByte(Parameters.Address);
				array5[1] = 16;
				array5[2] = 96;
				array5[3] = 22;
				array5[4] = 0;
				array5[5] = 40;
				array5[6] = 80;
				string s = Convert.ToString(((Control)域名1).Text);
				byte[] bytes = Encoding.ASCII.GetBytes(s);
				int num = 50 - bytes.Length;
				for (int i = 0; i < bytes.Length; i++)
				{
					array5[7 + i] = bytes[i];
				}
				for (int i = 0; i < num; i++)
				{
					array5[7 + bytes.Length + i] = 0;
				}
				m.GetCRC(array5, ref CRC5);
				array5[^2] = CRC5[0];
				array5[^1] = CRC5[1];
				try
				{
					Modbus.sp.Write(array5, 0, array5.Length);
					Thread.Sleep(20);
					m.GetResponse(ref response5);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					return;
				}
				if (m.CheckResponse(response5))
				{
					MessageBox.Show("成功设置");
				}
				else
				{
					MessageBox.Show("未能成功设置");
				}
			}
		}
	}

	private void button4_Click(object sender, EventArgs e)
	{
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		if (!CheckAddr())
		{
			return;
		}
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] CRC = new byte[2];
		byte[] array = new byte[8];
		byte[] response = new byte[69];
		array[0] = Convert.ToByte(Parameters.Address);
		array[1] = 3;
		array[2] = 112;
		array[3] = 0;
		array[4] = 0;
		array[5] = 32;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			Thread.Sleep(20);
			m.GetResponse(ref response);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message + " 请确定串口及地址设置！");
			return;
		}
		if (m.CheckResponse(response))
		{
			if (Parameters.IsUse485)
			{
			}
			string text = "";
			byte[] array2 = response;
			foreach (byte b in array2)
			{
			}
			byte[] array3 = new byte[16];
			for (int j = 0; j < 16; j++)
			{
				array3[j] = response[3 + j];
			}
			text = Encoding.ASCII.GetString(array3);
			((Control)Serial).Text = text;
			((ListControl)HW_Qos).SelectedIndex = response[19];
			((Control)HW_NUM).Text = response[20].ToString();
			string text2 = " ";
			byte[] array4 = new byte[41];
			for (int j = 0; j < 41; j++)
			{
				array4[j] = response[21 + j];
			}
			text2 = Encoding.ASCII.GetString(array4);
			((Control)textBox1).Text = text2;
			string text3 = " ";
			byte[] array5 = new byte[5];
			for (int j = 0; j < 5; j++)
			{
				array5[j] = response[62 + j];
			}
			text3 = Encoding.ASCII.GetString(array5);
			((Control)textBox2).Text = text3;
			MessageBox.Show("读取成功！");
		}
		else
		{
			MessageBox.Show("没有回复或校验错误！");
		}
	}

	private void button3_Click(object sender, EventArgs e)
	{
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		byte[] CRC = new byte[2];
		if (CheckAddr())
		{
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array = new byte[73];
			byte[] response = new byte[8];
			array[0] = Convert.ToByte(Parameters.Address);
			array[1] = 16;
			array[2] = 112;
			array[3] = 0;
			array[4] = 0;
			array[5] = 32;
			array[6] = 64;
			string text = Convert.ToString(((Control)Serial).Text);
			text = text.Replace("  ", "\0");
			byte[] bytes = Encoding.ASCII.GetBytes(text);
			int num = 16 - bytes.Length;
			for (int i = 0; i < bytes.Length; i++)
			{
				array[7 + i] = bytes[i];
			}
			for (int i = 0; i < num; i++)
			{
				array[7 + bytes.Length + i] = 0;
			}
			array[23] = (byte)((ListControl)HW_Qos).SelectedIndex;
			array[24] = Convert.ToByte(((Control)HW_NUM).Text);
			text = Convert.ToString(((Control)textBox1).Text);
			byte[] bytes2 = Encoding.ASCII.GetBytes(text);
			num = 41 - bytes2.Length;
			for (int i = 0; i < bytes2.Length; i++)
			{
				array[25 + i] = bytes2[i];
			}
			for (int i = 0; i < num; i++)
			{
				array[25 + bytes2.Length + i] = 0;
			}
			text = Convert.ToString(((Control)textBox2).Text);
			bytes2 = Encoding.ASCII.GetBytes(text);
			num = 5 - bytes2.Length;
			for (int i = 0; i < bytes2.Length; i++)
			{
				array[66 + i] = bytes2[i];
			}
			for (int i = 0; i < num; i++)
			{
				array[66 + bytes2.Length + i] = 0;
			}
			m.GetCRC(array, ref CRC);
			array[^2] = CRC[0];
			array[^1] = CRC[1];
			try
			{
				Modbus.sp.Write(array, 0, array.Length);
				Thread.Sleep(50);
				m.GetResponse(ref response);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + " 请确定串口及地址设置！");
				return;
			}
			if (m.CheckResponse(response))
			{
				MessageBox.Show("设置成功！");
			}
			else
			{
				MessageBox.Show("未能成功设置！");
			}
		}
	}

	private void button5_Click(object sender, EventArgs e)
	{
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		if (!CheckAddr())
		{
			return;
		}
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] CRC = new byte[2];
		byte[] array = new byte[8];
		byte[] response = new byte[185];
		array[0] = Convert.ToByte(Parameters.Address);
		array[1] = 3;
		array[2] = 112;
		array[3] = 0;
		array[4] = 0;
		array[5] = 90;
		m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			Thread.Sleep(20);
			m.GetResponse(ref response);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
			return;
		}
		if (m.CheckResponse(response))
		{
			if (Parameters.IsUse485)
			{
			}
			string text = "";
			byte[] array2 = new byte[60];
			for (int i = 0; i < 60; i++)
			{
				array2[i] = response[3 + i];
			}
			text = Encoding.ASCII.GetString(array2);
			((Control)usename).Text = text;
			string text2 = "";
			byte[] array3 = new byte[60];
			for (int i = 0; i < 60; i++)
			{
				array3[i] = response[63 + i];
			}
			text2 = Encoding.ASCII.GetString(array3);
			((Control)password).Text = text2;
			MessageBox.Show("read success");
			Thread.Sleep(20);
			if (CheckAddr())
			{
				MessageBox.Show("没有回复或校验错误");
			}
		}
		else
		{
			MessageBox.Show("没有回复或校验错误");
		}
	}
}
