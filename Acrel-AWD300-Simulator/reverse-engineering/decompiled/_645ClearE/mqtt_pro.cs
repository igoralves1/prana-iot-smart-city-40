using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace _645ClearE;

public class mqtt_pro : Form
{
	private IContainer components = null;

	private Timer timer1;

	private TabControl tabControl1;

	private TabPage tabPage1;

	private TextBox textBox1;

	private Label label1;

	private TextBox textBox41;

	private Label label514;

	private Button button56;

	private Button button60;

	private ComboBox comboBox16;

	private TextBox textBox42;

	private TextBox textBox43;

	private TextBox textBox44;

	private TextBox textBox45;

	private Label label515;

	private Label label516;

	private Label label517;

	private Label label518;

	private Label label519;

	private TabPage tabPage2;

	private Button button2;

	private Button button1;

	private CheckBox checkBox61;

	private CheckBox checkBox62;

	private CheckBox checkBox63;

	private CheckBox checkBox64;

	private CheckBox checkBox65;

	private CheckBox checkBox66;

	private CheckBox checkBox67;

	private CheckBox checkBox68;

	private CheckBox checkBox69;

	private CheckBox checkBox70;

	private CheckBox checkBox71;

	private CheckBox checkBox72;

	private CheckBox checkBox51;

	private CheckBox checkBox52;

	private CheckBox checkBox53;

	private CheckBox checkBox54;

	private CheckBox checkBox55;

	private CheckBox checkBox56;

	private CheckBox checkBox57;

	private CheckBox checkBox58;

	private CheckBox checkBox59;

	private CheckBox checkBox60;

	private CheckBox checkBox41;

	private CheckBox checkBox42;

	private CheckBox checkBox43;

	private CheckBox checkBox44;

	private CheckBox checkBox45;

	private CheckBox checkBox46;

	private CheckBox checkBox47;

	private CheckBox checkBox48;

	private CheckBox checkBox49;

	private CheckBox checkBox50;

	private CheckBox checkBox31;

	private CheckBox checkBox32;

	private CheckBox checkBox33;

	private CheckBox checkBox34;

	private CheckBox checkBox35;

	private CheckBox checkBox36;

	private CheckBox checkBox37;

	private CheckBox checkBox38;

	private CheckBox checkBox39;

	private CheckBox checkBox40;

	private CheckBox checkBox21;

	private CheckBox checkBox22;

	private CheckBox checkBox23;

	private CheckBox checkBox24;

	private CheckBox checkBox25;

	private CheckBox checkBox26;

	private CheckBox checkBox27;

	private CheckBox checkBox28;

	private CheckBox checkBox29;

	private CheckBox checkBox30;

	private CheckBox checkBox11;

	private CheckBox checkBox12;

	private CheckBox checkBox13;

	private CheckBox checkBox14;

	private CheckBox checkBox15;

	private CheckBox checkBox16;

	private CheckBox checkBox17;

	private CheckBox checkBox18;

	private CheckBox checkBox19;

	private CheckBox checkBox20;

	private CheckBox checkBox6;

	private CheckBox checkBox7;

	private CheckBox checkBox8;

	private CheckBox checkBox9;

	private CheckBox checkBox10;

	private CheckBox checkBox5;

	private CheckBox checkBox3;

	private CheckBox checkBox4;

	private CheckBox checkBox2;

	private CheckBox checkBox1;

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
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected Obj, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected Obj, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected Obj, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected Obj, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected Obj, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected Obj, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected Obj, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected Obj, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Obj, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected Obj, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected Obj, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected Obj, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected Obj, but got Unknown
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected Obj, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected Obj, but got Unknown
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected Obj, but got Unknown
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected Obj, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected Obj, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected Obj, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected Obj, but got Unknown
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected Obj, but got Unknown
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Expected Obj, but got Unknown
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected Obj, but got Unknown
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected Obj, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected Obj, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected Obj, but got Unknown
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected Obj, but got Unknown
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Expected Obj, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected Obj, but got Unknown
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected Obj, but got Unknown
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected Obj, but got Unknown
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Expected Obj, but got Unknown
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected Obj, but got Unknown
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Expected Obj, but got Unknown
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Expected Obj, but got Unknown
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Expected Obj, but got Unknown
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected Obj, but got Unknown
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Expected Obj, but got Unknown
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Expected Obj, but got Unknown
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Expected Obj, but got Unknown
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected Obj, but got Unknown
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Expected Obj, but got Unknown
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Expected Obj, but got Unknown
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Expected Obj, but got Unknown
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected Obj, but got Unknown
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Expected Obj, but got Unknown
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected Obj, but got Unknown
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Expected Obj, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected Obj, but got Unknown
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Expected Obj, but got Unknown
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Expected Obj, but got Unknown
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Expected Obj, but got Unknown
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected Obj, but got Unknown
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Expected Obj, but got Unknown
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Expected Obj, but got Unknown
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Expected Obj, but got Unknown
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Expected Obj, but got Unknown
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_029b: Expected Obj, but got Unknown
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Expected Obj, but got Unknown
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Expected Obj, but got Unknown
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Expected Obj, but got Unknown
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c7: Expected Obj, but got Unknown
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Expected Obj, but got Unknown
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Expected Obj, but got Unknown
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Expected Obj, but got Unknown
		//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Expected Obj, but got Unknown
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Expected Obj, but got Unknown
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0309: Expected Obj, but got Unknown
		//IL_030a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Expected Obj, but got Unknown
		//IL_0315: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Expected Obj, but got Unknown
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Expected Obj, but got Unknown
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0335: Expected Obj, but got Unknown
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Expected Obj, but got Unknown
		//IL_0341: Unknown result type (might be due to invalid IL or missing references)
		//IL_034b: Expected Obj, but got Unknown
		//IL_034c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Expected Obj, but got Unknown
		//IL_0357: Unknown result type (might be due to invalid IL or missing references)
		//IL_0361: Expected Obj, but got Unknown
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_036c: Expected Obj, but got Unknown
		//IL_036d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0377: Expected Obj, but got Unknown
		//IL_0378: Unknown result type (might be due to invalid IL or missing references)
		//IL_0382: Expected Obj, but got Unknown
		//IL_0383: Unknown result type (might be due to invalid IL or missing references)
		//IL_038d: Expected Obj, but got Unknown
		//IL_038e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0398: Expected Obj, but got Unknown
		//IL_0399: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a3: Expected Obj, but got Unknown
		//IL_03a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ae: Expected Obj, but got Unknown
		//IL_03af: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b9: Expected Obj, but got Unknown
		//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c4: Expected Obj, but got Unknown
		//IL_03c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cf: Expected Obj, but got Unknown
		//IL_03d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03da: Expected Obj, but got Unknown
		//IL_03db: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e5: Expected Obj, but got Unknown
		//IL_03e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f0: Expected Obj, but got Unknown
		//IL_03f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fb: Expected Obj, but got Unknown
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0406: Expected Obj, but got Unknown
		//IL_0407: Unknown result type (might be due to invalid IL or missing references)
		//IL_0411: Expected Obj, but got Unknown
		//IL_0412: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Expected Obj, but got Unknown
		//IL_0694: Unknown result type (might be due to invalid IL or missing references)
		//IL_08aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b4: Expected Obj, but got Unknown
		//IL_095e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0968: Expected Obj, but got Unknown
		//IL_1528: Unknown result type (might be due to invalid IL or missing references)
		//IL_159d: Unknown result type (might be due to invalid IL or missing references)
		//IL_15a7: Expected Obj, but got Unknown
		//IL_1651: Unknown result type (might be due to invalid IL or missing references)
		//IL_165b: Expected Obj, but got Unknown
		components = new Container();
		timer1 = new Timer(components);
		tabControl1 = new TabControl();
		tabPage1 = new TabPage();
		textBox1 = new TextBox();
		label1 = new Label();
		textBox41 = new TextBox();
		label514 = new Label();
		button56 = new Button();
		button60 = new Button();
		comboBox16 = new ComboBox();
		textBox42 = new TextBox();
		textBox43 = new TextBox();
		textBox44 = new TextBox();
		textBox45 = new TextBox();
		label515 = new Label();
		label516 = new Label();
		label517 = new Label();
		label518 = new Label();
		label519 = new Label();
		tabPage2 = new TabPage();
		button2 = new Button();
		button1 = new Button();
		checkBox61 = new CheckBox();
		checkBox62 = new CheckBox();
		checkBox63 = new CheckBox();
		checkBox64 = new CheckBox();
		checkBox65 = new CheckBox();
		checkBox66 = new CheckBox();
		checkBox67 = new CheckBox();
		checkBox68 = new CheckBox();
		checkBox69 = new CheckBox();
		checkBox70 = new CheckBox();
		checkBox71 = new CheckBox();
		checkBox72 = new CheckBox();
		checkBox51 = new CheckBox();
		checkBox52 = new CheckBox();
		checkBox53 = new CheckBox();
		checkBox54 = new CheckBox();
		checkBox55 = new CheckBox();
		checkBox56 = new CheckBox();
		checkBox57 = new CheckBox();
		checkBox58 = new CheckBox();
		checkBox59 = new CheckBox();
		checkBox60 = new CheckBox();
		checkBox41 = new CheckBox();
		checkBox42 = new CheckBox();
		checkBox43 = new CheckBox();
		checkBox44 = new CheckBox();
		checkBox45 = new CheckBox();
		checkBox46 = new CheckBox();
		checkBox47 = new CheckBox();
		checkBox48 = new CheckBox();
		checkBox49 = new CheckBox();
		checkBox50 = new CheckBox();
		checkBox31 = new CheckBox();
		checkBox32 = new CheckBox();
		checkBox33 = new CheckBox();
		checkBox34 = new CheckBox();
		checkBox35 = new CheckBox();
		checkBox36 = new CheckBox();
		checkBox37 = new CheckBox();
		checkBox38 = new CheckBox();
		checkBox39 = new CheckBox();
		checkBox40 = new CheckBox();
		checkBox21 = new CheckBox();
		checkBox22 = new CheckBox();
		checkBox23 = new CheckBox();
		checkBox24 = new CheckBox();
		checkBox25 = new CheckBox();
		checkBox26 = new CheckBox();
		checkBox27 = new CheckBox();
		checkBox28 = new CheckBox();
		checkBox29 = new CheckBox();
		checkBox30 = new CheckBox();
		checkBox11 = new CheckBox();
		checkBox12 = new CheckBox();
		checkBox13 = new CheckBox();
		checkBox14 = new CheckBox();
		checkBox15 = new CheckBox();
		checkBox16 = new CheckBox();
		checkBox17 = new CheckBox();
		checkBox18 = new CheckBox();
		checkBox19 = new CheckBox();
		checkBox20 = new CheckBox();
		checkBox6 = new CheckBox();
		checkBox7 = new CheckBox();
		checkBox8 = new CheckBox();
		checkBox9 = new CheckBox();
		checkBox10 = new CheckBox();
		checkBox5 = new CheckBox();
		checkBox3 = new CheckBox();
		checkBox4 = new CheckBox();
		checkBox2 = new CheckBox();
		checkBox1 = new CheckBox();
		((Control)tabControl1).SuspendLayout();
		((Control)tabPage1).SuspendLayout();
		((Control)tabPage2).SuspendLayout();
		((Control)this).SuspendLayout();
		timer1.Interval = 1000;
		timer1.Tick += timer1_Tick;
		((Control)tabControl1).Controls.Add((Control)(object)tabPage1);
		((Control)tabControl1).Controls.Add((Control)(object)tabPage2);
		((Control)tabControl1).Location = new Point(0, 3);
		((Control)tabControl1).Name = "tabControl1";
		tabControl1.SelectedIndex = 0;
		((Control)tabControl1).Size = new Size(650, 415);
		((Control)tabControl1).TabIndex = 64;
		((Control)tabPage1).Controls.Add((Control)(object)textBox1);
		((Control)tabPage1).Controls.Add((Control)(object)label1);
		((Control)tabPage1).Controls.Add((Control)(object)textBox41);
		((Control)tabPage1).Controls.Add((Control)(object)label514);
		((Control)tabPage1).Controls.Add((Control)(object)button56);
		((Control)tabPage1).Controls.Add((Control)(object)button60);
		((Control)tabPage1).Controls.Add((Control)(object)comboBox16);
		((Control)tabPage1).Controls.Add((Control)(object)textBox42);
		((Control)tabPage1).Controls.Add((Control)(object)textBox43);
		((Control)tabPage1).Controls.Add((Control)(object)textBox44);
		((Control)tabPage1).Controls.Add((Control)(object)textBox45);
		((Control)tabPage1).Controls.Add((Control)(object)label515);
		((Control)tabPage1).Controls.Add((Control)(object)label516);
		((Control)tabPage1).Controls.Add((Control)(object)label517);
		((Control)tabPage1).Controls.Add((Control)(object)label518);
		((Control)tabPage1).Controls.Add((Control)(object)label519);
		tabPage1.Location = new Point(4, 22);
		((Control)tabPage1).Name = "tabPage1";
		((Control)tabPage1).Padding = new Padding(3);
		((Control)tabPage1).Size = new Size(642, 389);
		tabPage1.TabIndex = 0;
		((Control)tabPage1).Text = "mqtt-set";
		tabPage1.UseVisualStyleBackColor = true;
		((Control)textBox1).Location = new Point(162, 173);
		((TextBoxBase)textBox1).MaxLength = 60;
		((Control)textBox1).Name = "textBox1";
		((Control)textBox1).Size = new Size(444, 21);
		((Control)textBox1).TabIndex = 79;
		((Control)label1).AutoSize = true;
		label1.ImeMode = (ImeMode)0;
		((Control)label1).Location = new Point(37, 176);
		((Control)label1).Name = "label1";
		((Control)label1).Size = new Size(47, 12);
		((Control)label1).TabIndex = 78;
		((Control)label1).Text = "Command";
		((Control)textBox41).Location = new Point(162, 211);
		((TextBoxBase)textBox41).MaxLength = 60;
		((Control)textBox41).Name = "textBox41";
		((Control)textBox41).Size = new Size(444, 21);
		((Control)textBox41).TabIndex = 77;
		((Control)label514).AutoSize = true;
		label514.ImeMode = (ImeMode)0;
		((Control)label514).Location = new Point(37, 215);
		((Control)label514).Name = "label514";
		((Control)label514).Size = new Size(53, 12);
		((Control)label514).TabIndex = 76;
		((Control)label514).Text = "ClientID";
		((Control)button56).Font = new Font("华文中宋", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((ButtonBase)button56).ImeMode = (ImeMode)0;
		((Control)button56).Location = new Point(322, 310);
		((Control)button56).Name = "button56";
		((Control)button56).Size = new Size(96, 45);
		((Control)button56).TabIndex = 75;
		((Control)button56).Text = "设置";
		((ButtonBase)button56).UseVisualStyleBackColor = true;
		((Control)button56).Click += button56_Click;
		((Control)button60).Font = new Font("华文中宋", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((ButtonBase)button60).ImeMode = (ImeMode)0;
		((Control)button60).Location = new Point(199, 310);
		((Control)button60).Name = "button60";
		((Control)button60).Size = new Size(96, 45);
		((Control)button60).TabIndex = 74;
		((Control)button60).Text = "读取";
		((ButtonBase)button60).UseVisualStyleBackColor = true;
		((Control)button60).Click += button60_Click_1;
		comboBox16.DropDownStyle = (ComboBoxStyle)2;
		((ListControl)comboBox16).FormattingEnabled = true;
		comboBox16.Items.AddRange(new object[3] { "0", "1", "2" });
		((Control)comboBox16).Location = new Point(162, 248);
		((Control)comboBox16).Name = "comboBox16";
		((Control)comboBox16).Size = new Size(77, 20);
		((Control)comboBox16).TabIndex = 73;
		((Control)textBox42).Location = new Point(162, 137);
		((TextBoxBase)textBox42).MaxLength = 60;
		((Control)textBox42).Name = "textBox42";
		((Control)textBox42).Size = new Size(444, 21);
		((Control)textBox42).TabIndex = 72;
		((Control)textBox43).Location = new Point(162, 95);
		((TextBoxBase)textBox43).MaxLength = 60;
		((Control)textBox43).Name = "textBox43";
		((Control)textBox43).Size = new Size(444, 21);
		((Control)textBox43).TabIndex = 71;
		((Control)textBox44).Location = new Point(162, 53);
		((TextBoxBase)textBox44).MaxLength = 60;
		((Control)textBox44).Name = "textBox44";
		((Control)textBox44).Size = new Size(444, 21);
		((Control)textBox44).TabIndex = 70;
		((Control)textBox45).Location = new Point(162, 11);
		((TextBoxBase)textBox45).MaxLength = 60;
		((Control)textBox45).Name = "textBox45";
		((Control)textBox45).Size = new Size(444, 21);
		((Control)textBox45).TabIndex = 69;
		((Control)label515).AutoSize = true;
		label515.ImeMode = (ImeMode)0;
		((Control)label515).Location = new Point(37, 253);
		((Control)label515).Name = "label515";
		((Control)label515).Size = new Size(53, 12);
		((Control)label515).TabIndex = 68;
		((Control)label515).Text = "MQTT Q0S";
		((Control)label516).AutoSize = true;
		label516.ImeMode = (ImeMode)0;
		((Control)label516).Location = new Point(37, 140);
		((Control)label516).Name = "label516";
		((Control)label516).Size = new Size(29, 12);
		((Control)label516).TabIndex = 67;
		((Control)label516).Text = "Data";
		((Control)label517).AutoSize = true;
		label517.ImeMode = (ImeMode)0;
		((Control)label517).Location = new Point(37, 99);
		((Control)label517).Name = "label517";
		((Control)label517).Size = new Size(35, 12);
		((Control)label517).TabIndex = 66;
		((Control)label517).Text = "Alarm";
		((Control)label518).AutoSize = true;
		label518.ImeMode = (ImeMode)0;
		((Control)label518).Location = new Point(37, 56);
		((Control)label518).Name = "label518";
		((Control)label518).Size = new Size(83, 12);
		((Control)label518).TabIndex = 65;
		((Control)label518).Text = "MQTT password";
		((Control)label519).AutoSize = true;
		label519.ImeMode = (ImeMode)0;
		((Control)label519).Location = new Point(37, 14);
		((Control)label519).Name = "label519";
		((Control)label519).Size = new Size(83, 12);
		((Control)label519).TabIndex = 64;
		((Control)label519).Text = "MQTT username";
		((Control)tabPage2).Controls.Add((Control)(object)button2);
		((Control)tabPage2).Controls.Add((Control)(object)button1);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox61);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox62);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox63);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox64);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox65);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox66);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox67);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox68);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox69);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox70);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox71);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox72);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox51);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox52);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox53);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox54);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox55);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox56);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox57);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox58);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox59);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox60);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox41);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox42);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox43);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox44);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox45);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox46);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox47);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox48);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox49);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox50);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox31);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox32);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox33);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox34);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox35);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox36);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox37);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox38);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox39);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox40);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox21);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox22);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox23);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox24);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox25);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox26);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox27);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox28);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox29);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox30);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox11);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox12);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox13);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox14);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox15);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox16);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox17);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox18);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox19);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox20);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox6);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox7);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox8);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox9);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox10);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox5);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox3);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox4);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox2);
		((Control)tabPage2).Controls.Add((Control)(object)checkBox1);
		tabPage2.Location = new Point(4, 22);
		((Control)tabPage2).Name = "tabPage2";
		((Control)tabPage2).Padding = new Padding(3);
		((Control)tabPage2).Size = new Size(642, 389);
		tabPage2.TabIndex = 1;
		((Control)tabPage2).Text = "mqtt-en";
		tabPage2.UseVisualStyleBackColor = true;
		((ButtonBase)button2).FlatStyle = (FlatStyle)3;
		((Control)button2).Font = new Font("华文中宋", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)button2).Location = new Point(323, 308);
		((Control)button2).Name = "button2";
		((Control)button2).Size = new Size(97, 39);
		((Control)button2).TabIndex = 73;
		((Control)button2).Text = "设置";
		((ButtonBase)button2).UseVisualStyleBackColor = true;
		((Control)button2).Click += button2_Click;
		((ButtonBase)button1).FlatStyle = (FlatStyle)3;
		((Control)button1).Font = new Font("华文中宋", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)button1).Location = new Point(210, 308);
		((Control)button1).Name = "button1";
		((Control)button1).Size = new Size(97, 39);
		((Control)button1).TabIndex = 72;
		((Control)button1).Text = "读取";
		((ButtonBase)button1).UseVisualStyleBackColor = true;
		((Control)button1).Click += button1_Click;
		((Control)checkBox61).AutoSize = true;
		((Control)checkBox61).Location = new Point(523, 20);
		((Control)checkBox61).Name = "checkBox61";
		((Control)checkBox61).Size = new Size(66, 16);
		((Control)checkBox61).TabIndex = 71;
		((Control)checkBox61).Text = "MD_QNEG";
		((ButtonBase)checkBox61).UseVisualStyleBackColor = true;
		((Control)checkBox62).AutoSize = true;
		((Control)checkBox62).Location = new Point(523, 42);
		((Control)checkBox62).Name = "checkBox62";
		((Control)checkBox62).Size = new Size(90, 16);
		((Control)checkBox62).TabIndex = 70;
		((Control)checkBox62).Text = "UnBalance_U";
		((ButtonBase)checkBox62).UseVisualStyleBackColor = true;
		((Control)checkBox63).AutoSize = true;
		((Control)checkBox63).Location = new Point(523, 64);
		((Control)checkBox63).Name = "checkBox63";
		((Control)checkBox63).Size = new Size(90, 16);
		((Control)checkBox63).TabIndex = 69;
		((Control)checkBox63).Text = "UnBalance_I";
		((ButtonBase)checkBox63).UseVisualStyleBackColor = true;
		((Control)checkBox64).AutoSize = true;
		((Control)checkBox64).Location = new Point(523, 86);
		((Control)checkBox64).Name = "checkBox64";
		((Control)checkBox64).Size = new Size(54, 16);
		((Control)checkBox64).TabIndex = 68;
		((Control)checkBox64).Text = "EP_F1";
		((ButtonBase)checkBox64).UseVisualStyleBackColor = true;
		((Control)checkBox65).AutoSize = true;
		((Control)checkBox65).Location = new Point(523, 108);
		((Control)checkBox65).Name = "checkBox65";
		((Control)checkBox65).Size = new Size(54, 16);
		((Control)checkBox65).TabIndex = 67;
		((Control)checkBox65).Text = "EP_F2";
		((ButtonBase)checkBox65).UseVisualStyleBackColor = true;
		((Control)checkBox66).AutoSize = true;
		((Control)checkBox66).Location = new Point(523, 130);
		((Control)checkBox66).Name = "checkBox66";
		((Control)checkBox66).Size = new Size(54, 16);
		((Control)checkBox66).TabIndex = 66;
		((Control)checkBox66).Text = "EP_F3";
		((ButtonBase)checkBox66).UseVisualStyleBackColor = true;
		((Control)checkBox67).AutoSize = true;
		((Control)checkBox67).Location = new Point(523, 152);
		((Control)checkBox67).Name = "checkBox67";
		((Control)checkBox67).Size = new Size(54, 16);
		((Control)checkBox67).TabIndex = 65;
		((Control)checkBox67).Text = "EP_F4";
		((ButtonBase)checkBox67).UseVisualStyleBackColor = true;
		((Control)checkBox68).AutoSize = true;
		((Control)checkBox68).Location = new Point(523, 174);
		((Control)checkBox68).Name = "checkBox68";
		((Control)checkBox68).Size = new Size(42, 16);
		((Control)checkBox68).TabIndex = 64;
		((Control)checkBox68).Text = "EQ1";
		((ButtonBase)checkBox68).UseVisualStyleBackColor = true;
		((Control)checkBox69).AutoSize = true;
		((Control)checkBox69).Location = new Point(523, 196);
		((Control)checkBox69).Name = "checkBox69";
		((Control)checkBox69).Size = new Size(42, 16);
		((Control)checkBox69).TabIndex = 63;
		((Control)checkBox69).Text = "EQ2";
		((ButtonBase)checkBox69).UseVisualStyleBackColor = true;
		((Control)checkBox70).AutoSize = true;
		((Control)checkBox70).Location = new Point(523, 218);
		((Control)checkBox70).Name = "checkBox70";
		((Control)checkBox70).Size = new Size(42, 16);
		((Control)checkBox70).TabIndex = 62;
		((Control)checkBox70).Text = "EQ3";
		((ButtonBase)checkBox70).UseVisualStyleBackColor = true;
		((Control)checkBox71).AutoSize = true;
		((Control)checkBox71).Location = new Point(523, 240);
		((Control)checkBox71).Name = "checkBox71";
		((Control)checkBox71).Size = new Size(42, 16);
		((Control)checkBox71).TabIndex = 61;
		((Control)checkBox71).Text = "EQ4";
		((ButtonBase)checkBox71).UseVisualStyleBackColor = true;
		((Control)checkBox72).AutoSize = true;
		((Control)checkBox72).Location = new Point(523, 262);
		((Control)checkBox72).Name = "checkBox72";
		((Control)checkBox72).Size = new Size(66, 16);
		((Control)checkBox72).TabIndex = 60;
		((Control)checkBox72).Text = "VERSION";
		((ButtonBase)checkBox72).UseVisualStyleBackColor = true;
		((Control)checkBox51).AutoSize = true;
		((Control)checkBox51).Location = new Point(422, 64);
		((Control)checkBox51).Name = "checkBox51";
		((Control)checkBox51).Size = new Size(66, 16);
		((Control)checkBox51).TabIndex = 59;
		((Control)checkBox51).Text = "EQPOS_C";
		((ButtonBase)checkBox51).UseVisualStyleBackColor = true;
		((Control)checkBox52).AutoSize = true;
		((Control)checkBox52).Location = new Point(422, 86);
		((Control)checkBox52).Name = "checkBox52";
		((Control)checkBox52).Size = new Size(66, 16);
		((Control)checkBox52).TabIndex = 58;
		((Control)checkBox52).Text = "EQNEG_C";
		((ButtonBase)checkBox52).UseVisualStyleBackColor = true;
		((Control)checkBox53).AutoSize = true;
		((Control)checkBox53).Location = new Point(422, 108);
		((Control)checkBox53).Name = "checkBox53";
		((Control)checkBox53).Size = new Size(90, 16);
		((Control)checkBox53).TabIndex = 57;
		((Control)checkBox53).Text = "Ua_Harmonic";
		((ButtonBase)checkBox53).UseVisualStyleBackColor = true;
		((Control)checkBox54).AutoSize = true;
		((Control)checkBox54).Location = new Point(422, 130);
		((Control)checkBox54).Name = "checkBox54";
		((Control)checkBox54).Size = new Size(90, 16);
		((Control)checkBox54).TabIndex = 56;
		((Control)checkBox54).Text = "Ub_Harmonic";
		((ButtonBase)checkBox54).UseVisualStyleBackColor = true;
		((Control)checkBox55).AutoSize = true;
		((Control)checkBox55).Location = new Point(422, 152);
		((Control)checkBox55).Name = "checkBox55";
		((Control)checkBox55).Size = new Size(90, 16);
		((Control)checkBox55).TabIndex = 55;
		((Control)checkBox55).Text = "Uc_Harmonic";
		((ButtonBase)checkBox55).UseVisualStyleBackColor = true;
		((Control)checkBox56).AutoSize = true;
		((Control)checkBox56).Location = new Point(422, 174);
		((Control)checkBox56).Name = "checkBox56";
		((Control)checkBox56).Size = new Size(90, 16);
		((Control)checkBox56).TabIndex = 54;
		((Control)checkBox56).Text = "Ia_Harmonic";
		((ButtonBase)checkBox56).UseVisualStyleBackColor = true;
		((Control)checkBox57).AutoSize = true;
		((Control)checkBox57).Location = new Point(422, 196);
		((Control)checkBox57).Name = "checkBox57";
		((Control)checkBox57).Size = new Size(90, 16);
		((Control)checkBox57).TabIndex = 53;
		((Control)checkBox57).Text = "Ib_Harmonic";
		((ButtonBase)checkBox57).UseVisualStyleBackColor = true;
		((Control)checkBox58).AutoSize = true;
		((Control)checkBox58).Location = new Point(422, 218);
		((Control)checkBox58).Name = "checkBox58";
		((Control)checkBox58).Size = new Size(90, 16);
		((Control)checkBox58).TabIndex = 52;
		((Control)checkBox58).Text = "Ic_Harmonic";
		((ButtonBase)checkBox58).UseVisualStyleBackColor = true;
		((Control)checkBox59).AutoSize = true;
		((Control)checkBox59).Location = new Point(422, 240);
		((Control)checkBox59).Name = "checkBox59";
		((Control)checkBox59).Size = new Size(66, 16);
		((Control)checkBox59).TabIndex = 51;
		((Control)checkBox59).Text = "MD_PNEG";
		((ButtonBase)checkBox59).UseVisualStyleBackColor = true;
		((Control)checkBox60).AutoSize = true;
		((Control)checkBox60).Location = new Point(422, 262);
		((Control)checkBox60).Name = "checkBox60";
		((Control)checkBox60).Size = new Size(66, 16);
		((Control)checkBox60).TabIndex = 50;
		((Control)checkBox60).Text = "MD_QPOS";
		((ButtonBase)checkBox60).UseVisualStyleBackColor = true;
		((Control)checkBox41).AutoSize = true;
		((Control)checkBox41).Location = new Point(323, 108);
		((Control)checkBox41).Name = "checkBox41";
		((Control)checkBox41).Size = new Size(66, 16);
		((Control)checkBox41).TabIndex = 49;
		((Control)checkBox41).Text = "EPPOS_A";
		((ButtonBase)checkBox41).UseVisualStyleBackColor = true;
		((Control)checkBox42).AutoSize = true;
		((Control)checkBox42).Location = new Point(323, 130);
		((Control)checkBox42).Name = "checkBox42";
		((Control)checkBox42).Size = new Size(66, 16);
		((Control)checkBox42).TabIndex = 48;
		((Control)checkBox42).Text = "EPNEG_A";
		((ButtonBase)checkBox42).UseVisualStyleBackColor = true;
		((Control)checkBox43).AutoSize = true;
		((Control)checkBox43).Location = new Point(323, 152);
		((Control)checkBox43).Name = "checkBox43";
		((Control)checkBox43).Size = new Size(66, 16);
		((Control)checkBox43).TabIndex = 47;
		((Control)checkBox43).Text = "EQPOS_A";
		((ButtonBase)checkBox43).UseVisualStyleBackColor = true;
		((Control)checkBox44).AutoSize = true;
		((Control)checkBox44).Location = new Point(323, 174);
		((Control)checkBox44).Name = "checkBox44";
		((Control)checkBox44).Size = new Size(66, 16);
		((Control)checkBox44).TabIndex = 46;
		((Control)checkBox44).Text = "EQNEG_A";
		((ButtonBase)checkBox44).UseVisualStyleBackColor = true;
		((Control)checkBox45).AutoSize = true;
		((Control)checkBox45).Location = new Point(323, 196);
		((Control)checkBox45).Name = "checkBox45";
		((Control)checkBox45).Size = new Size(66, 16);
		((Control)checkBox45).TabIndex = 45;
		((Control)checkBox45).Text = "EPPOS_B";
		((ButtonBase)checkBox45).UseVisualStyleBackColor = true;
		((Control)checkBox46).AutoSize = true;
		((Control)checkBox46).Location = new Point(323, 218);
		((Control)checkBox46).Name = "checkBox46";
		((Control)checkBox46).Size = new Size(66, 16);
		((Control)checkBox46).TabIndex = 44;
		((Control)checkBox46).Text = "EPNEG_B";
		((ButtonBase)checkBox46).UseVisualStyleBackColor = true;
		((Control)checkBox47).AutoSize = true;
		((Control)checkBox47).Location = new Point(323, 240);
		((Control)checkBox47).Name = "checkBox47";
		((Control)checkBox47).Size = new Size(66, 16);
		((Control)checkBox47).TabIndex = 43;
		((Control)checkBox47).Text = "EQPOS_B";
		((ButtonBase)checkBox47).UseVisualStyleBackColor = true;
		((Control)checkBox48).AutoSize = true;
		((Control)checkBox48).Location = new Point(323, 262);
		((Control)checkBox48).Name = "checkBox48";
		((Control)checkBox48).Size = new Size(66, 16);
		((Control)checkBox48).TabIndex = 42;
		((Control)checkBox48).Text = "EQNEG_B";
		((ButtonBase)checkBox48).UseVisualStyleBackColor = true;
		((Control)checkBox49).AutoSize = true;
		((Control)checkBox49).Location = new Point(422, 20);
		((Control)checkBox49).Name = "checkBox49";
		((Control)checkBox49).Size = new Size(66, 16);
		((Control)checkBox49).TabIndex = 41;
		((Control)checkBox49).Text = "EPPOS_C";
		((ButtonBase)checkBox49).UseVisualStyleBackColor = true;
		((Control)checkBox50).AutoSize = true;
		((Control)checkBox50).Location = new Point(422, 42);
		((Control)checkBox50).Name = "checkBox50";
		((Control)checkBox50).Size = new Size(66, 16);
		((Control)checkBox50).TabIndex = 40;
		((Control)checkBox50).Text = "EPNEG_C";
		((ButtonBase)checkBox50).UseVisualStyleBackColor = true;
		((Control)checkBox31).AutoSize = true;
		((Control)checkBox31).Location = new Point(223, 152);
		((Control)checkBox31).Name = "checkBox31";
		((Control)checkBox31).Size = new Size(54, 16);
		((Control)checkBox31).TabIndex = 39;
		((Control)checkBox31).Text = "EQNEG";
		((ButtonBase)checkBox31).UseVisualStyleBackColor = true;
		((Control)checkBox32).AutoSize = true;
		((Control)checkBox32).Location = new Point(223, 174);
		((Control)checkBox32).Name = "checkBox32";
		((Control)checkBox32).Size = new Size(66, 16);
		((Control)checkBox32).TabIndex = 38;
		((Control)checkBox32).Text = "MD_PPOS";
		((ButtonBase)checkBox32).UseVisualStyleBackColor = true;
		((Control)checkBox33).AutoSize = true;
		((Control)checkBox33).Location = new Point(223, 196);
		((Control)checkBox33).Name = "checkBox33";
		((Control)checkBox33).Size = new Size(36, 16);
		((Control)checkBox33).TabIndex = 37;
		((Control)checkBox33).Text = "PT";
		((ButtonBase)checkBox33).UseVisualStyleBackColor = true;
		((Control)checkBox34).AutoSize = true;
		((Control)checkBox34).Location = new Point(223, 218);
		((Control)checkBox34).Name = "checkBox34";
		((Control)checkBox34).Size = new Size(36, 16);
		((Control)checkBox34).TabIndex = 36;
		((Control)checkBox34).Text = "CT";
		((ButtonBase)checkBox34).UseVisualStyleBackColor = true;
		((Control)checkBox35).AutoSize = true;
		((Control)checkBox35).Location = new Point(223, 240);
		((Control)checkBox35).Name = "checkBox35";
		((Control)checkBox35).Size = new Size(60, 16);
		((Control)checkBox35).TabIndex = 35;
		((Control)checkBox35).Text = "TEMP_A";
		((ButtonBase)checkBox35).UseVisualStyleBackColor = true;
		((Control)checkBox36).AutoSize = true;
		((Control)checkBox36).Location = new Point(223, 262);
		((Control)checkBox36).Name = "checkBox36";
		((Control)checkBox36).Size = new Size(60, 16);
		((Control)checkBox36).TabIndex = 34;
		((Control)checkBox36).Text = "TEMP_B";
		((ButtonBase)checkBox36).UseVisualStyleBackColor = true;
		((Control)checkBox37).AutoSize = true;
		((Control)checkBox37).Location = new Point(323, 20);
		((Control)checkBox37).Name = "checkBox37";
		((Control)checkBox37).Size = new Size(60, 16);
		((Control)checkBox37).TabIndex = 33;
		((Control)checkBox37).Text = "TEMP_C";
		((ButtonBase)checkBox37).UseVisualStyleBackColor = true;
		((Control)checkBox38).AutoSize = true;
		((Control)checkBox38).Location = new Point(323, 42);
		((Control)checkBox38).Name = "checkBox38";
		((Control)checkBox38).Size = new Size(60, 16);
		((Control)checkBox38).TabIndex = 32;
		((Control)checkBox38).Text = "TEMP_N";
		((ButtonBase)checkBox38).UseVisualStyleBackColor = true;
		((Control)checkBox39).AutoSize = true;
		((Control)checkBox39).Location = new Point(323, 64);
		((Control)checkBox39).Name = "checkBox39";
		((Control)checkBox39).Size = new Size(96, 16);
		((Control)checkBox39).TabIndex = 31;
		((Control)checkBox39).Text = "AfterCurrent";
		((ButtonBase)checkBox39).UseVisualStyleBackColor = true;
		((Control)checkBox40).AutoSize = true;
		((Control)checkBox40).Location = new Point(323, 86);
		((Control)checkBox40).Name = "checkBox40";
		((Control)checkBox40).Size = new Size(72, 16);
		((Control)checkBox40).TabIndex = 30;
		((Control)checkBox40).Text = "DI_STATE";
		((ButtonBase)checkBox40).UseVisualStyleBackColor = true;
		((Control)checkBox21).AutoSize = true;
		((Control)checkBox21).Location = new Point(123, 196);
		((Control)checkBox21).Name = "checkBox21";
		((Control)checkBox21).Size = new Size(30, 16);
		((Control)checkBox21).TabIndex = 29;
		((Control)checkBox21).Text = "S";
		((ButtonBase)checkBox21).UseVisualStyleBackColor = true;
		((Control)checkBox22).AutoSize = true;
		((Control)checkBox22).Location = new Point(123, 218);
		((Control)checkBox22).Name = "checkBox22";
		((Control)checkBox22).Size = new Size(42, 16);
		((Control)checkBox22).TabIndex = 28;
		((Control)checkBox22).Text = "PFA";
		((ButtonBase)checkBox22).UseVisualStyleBackColor = true;
		((Control)checkBox23).AutoSize = true;
		((Control)checkBox23).Location = new Point(123, 240);
		((Control)checkBox23).Name = "checkBox23";
		((Control)checkBox23).Size = new Size(42, 16);
		((Control)checkBox23).TabIndex = 27;
		((Control)checkBox23).Text = "PFB";
		((ButtonBase)checkBox23).UseVisualStyleBackColor = true;
		((Control)checkBox24).AutoSize = true;
		((Control)checkBox24).Location = new Point(123, 262);
		((Control)checkBox24).Name = "checkBox24";
		((Control)checkBox24).Size = new Size(42, 16);
		((Control)checkBox24).TabIndex = 26;
		((Control)checkBox24).Text = "PFC";
		((ButtonBase)checkBox24).UseVisualStyleBackColor = true;
		((Control)checkBox25).AutoSize = true;
		((Control)checkBox25).Location = new Point(223, 20);
		((Control)checkBox25).Name = "checkBox25";
		((Control)checkBox25).Size = new Size(36, 16);
		((Control)checkBox25).TabIndex = 25;
		((Control)checkBox25).Text = "PF";
		((ButtonBase)checkBox25).UseVisualStyleBackColor = true;
		((Control)checkBox26).AutoSize = true;
		((Control)checkBox26).Location = new Point(223, 42);
		((Control)checkBox26).Name = "checkBox26";
		((Control)checkBox26).Size = new Size(36, 16);
		((Control)checkBox26).TabIndex = 24;
		((Control)checkBox26).Text = "HZ";
		((ButtonBase)checkBox26).UseVisualStyleBackColor = true;
		((Control)checkBox27).AutoSize = true;
		((Control)checkBox27).Location = new Point(223, 64);
		((Control)checkBox27).Name = "checkBox27";
		((Control)checkBox27).Size = new Size(48, 16);
		((Control)checkBox27).TabIndex = 23;
		((Control)checkBox27).Text = "Rssi";
		((ButtonBase)checkBox27).UseVisualStyleBackColor = true;
		((Control)checkBox28).AutoSize = true;
		((Control)checkBox28).Location = new Point(223, 86);
		((Control)checkBox28).Name = "checkBox28";
		((Control)checkBox28).Size = new Size(54, 16);
		((Control)checkBox28).TabIndex = 22;
		((Control)checkBox28).Text = "EPPOS";
		((ButtonBase)checkBox28).UseVisualStyleBackColor = true;
		((Control)checkBox29).AutoSize = true;
		((Control)checkBox29).Location = new Point(223, 108);
		((Control)checkBox29).Name = "checkBox29";
		((Control)checkBox29).Size = new Size(54, 16);
		((Control)checkBox29).TabIndex = 21;
		((Control)checkBox29).Text = "EPNEG";
		((ButtonBase)checkBox29).UseVisualStyleBackColor = true;
		((Control)checkBox30).AutoSize = true;
		((Control)checkBox30).Location = new Point(223, 130);
		((Control)checkBox30).Name = "checkBox30";
		((Control)checkBox30).Size = new Size(54, 16);
		((Control)checkBox30).TabIndex = 20;
		((Control)checkBox30).Text = "EQPOS";
		((ButtonBase)checkBox30).UseVisualStyleBackColor = true;
		((Control)checkBox11).AutoSize = true;
		((Control)checkBox11).Location = new Point(28, 240);
		((Control)checkBox11).Name = "checkBox11";
		((Control)checkBox11).Size = new Size(36, 16);
		((Control)checkBox11).TabIndex = 19;
		((Control)checkBox11).Text = "PB";
		((ButtonBase)checkBox11).UseVisualStyleBackColor = true;
		((Control)checkBox12).AutoSize = true;
		((Control)checkBox12).Location = new Point(28, 262);
		((Control)checkBox12).Name = "checkBox12";
		((Control)checkBox12).Size = new Size(36, 16);
		((Control)checkBox12).TabIndex = 18;
		((Control)checkBox12).Text = "PC";
		((ButtonBase)checkBox12).UseVisualStyleBackColor = true;
		((Control)checkBox13).AutoSize = true;
		((Control)checkBox13).Location = new Point(123, 20);
		((Control)checkBox13).Name = "checkBox13";
		((Control)checkBox13).Size = new Size(30, 16);
		((Control)checkBox13).TabIndex = 17;
		((Control)checkBox13).Text = "P";
		((ButtonBase)checkBox13).UseVisualStyleBackColor = true;
		((Control)checkBox14).AutoSize = true;
		((Control)checkBox14).Location = new Point(123, 42);
		((Control)checkBox14).Name = "checkBox14";
		((Control)checkBox14).Size = new Size(36, 16);
		((Control)checkBox14).TabIndex = 16;
		((Control)checkBox14).Text = "QA";
		((ButtonBase)checkBox14).UseVisualStyleBackColor = true;
		((Control)checkBox15).AutoSize = true;
		((Control)checkBox15).Location = new Point(123, 64);
		((Control)checkBox15).Name = "checkBox15";
		((Control)checkBox15).Size = new Size(36, 16);
		((Control)checkBox15).TabIndex = 15;
		((Control)checkBox15).Text = "QB";
		((ButtonBase)checkBox15).UseVisualStyleBackColor = true;
		((Control)checkBox16).AutoSize = true;
		((Control)checkBox16).Location = new Point(123, 86);
		((Control)checkBox16).Name = "checkBox16";
		((Control)checkBox16).Size = new Size(36, 16);
		((Control)checkBox16).TabIndex = 14;
		((Control)checkBox16).Text = "QC";
		((ButtonBase)checkBox16).UseVisualStyleBackColor = true;
		((Control)checkBox17).AutoSize = true;
		((Control)checkBox17).Location = new Point(123, 108);
		((Control)checkBox17).Name = "checkBox17";
		((Control)checkBox17).Size = new Size(30, 16);
		((Control)checkBox17).TabIndex = 13;
		((Control)checkBox17).Text = "Q";
		((ButtonBase)checkBox17).UseVisualStyleBackColor = true;
		((Control)checkBox18).AutoSize = true;
		((Control)checkBox18).Location = new Point(123, 130);
		((Control)checkBox18).Name = "checkBox18";
		((Control)checkBox18).Size = new Size(36, 16);
		((Control)checkBox18).TabIndex = 12;
		((Control)checkBox18).Text = "SA";
		((ButtonBase)checkBox18).UseVisualStyleBackColor = true;
		((Control)checkBox19).AutoSize = true;
		((Control)checkBox19).Location = new Point(123, 152);
		((Control)checkBox19).Name = "checkBox19";
		((Control)checkBox19).Size = new Size(36, 16);
		((Control)checkBox19).TabIndex = 11;
		((Control)checkBox19).Text = "SB";
		((ButtonBase)checkBox19).UseVisualStyleBackColor = true;
		((Control)checkBox20).AutoSize = true;
		((Control)checkBox20).Location = new Point(123, 174);
		((Control)checkBox20).Name = "checkBox20";
		((Control)checkBox20).Size = new Size(36, 16);
		((Control)checkBox20).TabIndex = 10;
		((Control)checkBox20).Text = "SC";
		((ButtonBase)checkBox20).UseVisualStyleBackColor = true;
		((Control)checkBox6).AutoSize = true;
		((Control)checkBox6).Location = new Point(28, 130);
		((Control)checkBox6).Name = "checkBox6";
		((Control)checkBox6).Size = new Size(42, 16);
		((Control)checkBox6).TabIndex = 9;
		((Control)checkBox6).Text = "UCA";
		((ButtonBase)checkBox6).UseVisualStyleBackColor = true;
		((Control)checkBox7).AutoSize = true;
		((Control)checkBox7).Location = new Point(28, 152);
		((Control)checkBox7).Name = "checkBox7";
		((Control)checkBox7).Size = new Size(36, 16);
		((Control)checkBox7).TabIndex = 8;
		((Control)checkBox7).Text = "IA";
		((ButtonBase)checkBox7).UseVisualStyleBackColor = true;
		((Control)checkBox8).AutoSize = true;
		((Control)checkBox8).Location = new Point(28, 174);
		((Control)checkBox8).Name = "checkBox8";
		((Control)checkBox8).Size = new Size(36, 16);
		((Control)checkBox8).TabIndex = 7;
		((Control)checkBox8).Text = "IB";
		((ButtonBase)checkBox8).UseVisualStyleBackColor = true;
		((Control)checkBox9).AutoSize = true;
		((Control)checkBox9).Location = new Point(28, 196);
		((Control)checkBox9).Name = "checkBox9";
		((Control)checkBox9).Size = new Size(36, 16);
		((Control)checkBox9).TabIndex = 6;
		((Control)checkBox9).Text = "IC";
		((ButtonBase)checkBox9).UseVisualStyleBackColor = true;
		((Control)checkBox10).AutoSize = true;
		((Control)checkBox10).Location = new Point(28, 218);
		((Control)checkBox10).Name = "checkBox10";
		((Control)checkBox10).Size = new Size(36, 16);
		((Control)checkBox10).TabIndex = 5;
		((Control)checkBox10).Text = "PA";
		((ButtonBase)checkBox10).UseVisualStyleBackColor = true;
		((Control)checkBox5).AutoSize = true;
		((Control)checkBox5).Location = new Point(28, 108);
		((Control)checkBox5).Name = "checkBox5";
		((Control)checkBox5).Size = new Size(42, 16);
		((Control)checkBox5).TabIndex = 4;
		((Control)checkBox5).Text = "UBC";
		((ButtonBase)checkBox5).UseVisualStyleBackColor = true;
		((Control)checkBox3).AutoSize = true;
		((Control)checkBox3).Location = new Point(28, 64);
		((Control)checkBox3).Name = "checkBox3";
		((Control)checkBox3).Size = new Size(36, 16);
		((Control)checkBox3).TabIndex = 3;
		((Control)checkBox3).Text = "UC";
		((ButtonBase)checkBox3).UseVisualStyleBackColor = true;
		((Control)checkBox4).AutoSize = true;
		((Control)checkBox4).Location = new Point(28, 86);
		((Control)checkBox4).Name = "checkBox4";
		((Control)checkBox4).Size = new Size(42, 16);
		((Control)checkBox4).TabIndex = 2;
		((Control)checkBox4).Text = "UAB";
		((ButtonBase)checkBox4).UseVisualStyleBackColor = true;
		((Control)checkBox2).AutoSize = true;
		((Control)checkBox2).Location = new Point(28, 42);
		((Control)checkBox2).Name = "checkBox2";
		((Control)checkBox2).Size = new Size(36, 16);
		((Control)checkBox2).TabIndex = 1;
		((Control)checkBox2).Text = "UB";
		((ButtonBase)checkBox2).UseVisualStyleBackColor = true;
		((Control)checkBox1).AutoSize = true;
		((Control)checkBox1).Location = new Point(28, 20);
		((Control)checkBox1).Name = "checkBox1";
		((Control)checkBox1).Size = new Size(36, 16);
		((Control)checkBox1).TabIndex = 0;
		((Control)checkBox1).Text = "UA";
		((ButtonBase)checkBox1).UseVisualStyleBackColor = true;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 12f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Control)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(650, 416);
		((Control)this).Controls.Add((Control)(object)tabControl1);
		((Control)this).ForeColor = SystemColors.ControlText;
		((Control)this).Name = "mqtt_pro";
		((Control)this).Text = "mqtt_pro";
		((Control)tabControl1).ResumeLayout(false);
		((Control)tabPage1).ResumeLayout(false);
		((Control)tabPage1).PerformLayout();
		((Control)tabPage2).ResumeLayout(false);
		((Control)tabPage2).PerformLayout();
		((Control)this).ResumeLayout(false);
	}

	public mqtt_pro()
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

	private void timer1_Tick(object sender, EventArgs e)
	{
	}

	private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void button60_Click_1(object sender, EventArgs e)
	{
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_0516: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0421: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ac: Unknown result type (might be due to invalid IL or missing references)
		if (!CheckAddr())
		{
			return;
		}
		timer1.Enabled = false;
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
			timer1.Enabled = false;
			MessageBox.Show(ex.Message);
			return;
		}
		if (m.CheckResponse(response))
		{
			if (Parameters.IsUse485)
			{
				timer1.Enabled = true;
			}
			string text = "";
			byte[] array2 = new byte[60];
			for (int i = 0; i < 60; i++)
			{
				array2[i] = response[3 + i];
			}
			text = Encoding.ASCII.GetString(array2);
			((Control)textBox45).Text = text;
			string text2 = "";
			byte[] array3 = new byte[60];
			for (int i = 0; i < 60; i++)
			{
				array3[i] = response[63 + i];
			}
			text2 = Encoding.ASCII.GetString(array3);
			((Control)textBox44).Text = text2;
			string text3 = "";
			byte[] array4 = new byte[60];
			for (int i = 0; i < 60; i++)
			{
				array4[i] = response[123 + i];
			}
			text3 = Encoding.ASCII.GetString(array4);
			((Control)textBox43).Text = text3;
			Thread.Sleep(20);
			if (!CheckAddr())
			{
				return;
			}
			timer1.Enabled = false;
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] CRC2 = new byte[2];
			byte[] array5 = new byte[8];
			byte[] response2 = new byte[127];
			array5[0] = Convert.ToByte(Parameters.Address);
			array5[1] = 3;
			array5[2] = 112;
			array5[3] = 90;
			array5[4] = 0;
			array5[5] = 61;
			m.GetCRC(array5, ref CRC2);
			array5[^2] = CRC2[0];
			array5[^1] = CRC2[1];
			try
			{
				Modbus.sp.Write(array5, 0, array5.Length);
				Thread.Sleep(20);
				m.GetResponse(ref response2);
			}
			catch (Exception ex)
			{
				timer1.Enabled = false;
				MessageBox.Show(ex.Message);
				return;
			}
			if (m.CheckResponse(response2))
			{
				if (Parameters.IsUse485)
				{
					timer1.Enabled = true;
				}
				string text4 = "";
				byte[] array6 = new byte[60];
				for (int i = 0; i < 60; i++)
				{
					array6[i] = response2[3 + i];
				}
				text4 = Encoding.ASCII.GetString(array6);
				((Control)textBox42).Text = text4;
				string text5 = "";
				byte[] array7 = new byte[60];
				for (int i = 0; i < 60; i++)
				{
					array7[i] = response2[63 + i];
				}
				text5 = Encoding.ASCII.GetString(array7);
				((Control)textBox41).Text = text5;
				((ListControl)comboBox16).SelectedIndex = response2[123];
			}
			else
			{
				timer1.Enabled = true;
				MessageBox.Show("没有回复或校验错误");
			}
			Thread.Sleep(20);
			if (!CheckAddr())
			{
				return;
			}
			timer1.Enabled = false;
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] CRC3 = new byte[2];
			byte[] array8 = new byte[8];
			byte[] response3 = new byte[65];
			array8[0] = Convert.ToByte(Parameters.Address);
			array8[1] = 3;
			array8[2] = 112;
			array8[3] = 151;
			array8[4] = 0;
			array8[5] = 30;
			m.GetCRC(array8, ref CRC3);
			array8[^2] = CRC3[0];
			array8[^1] = CRC3[1];
			try
			{
				Modbus.sp.Write(array8, 0, array8.Length);
				Thread.Sleep(20);
				m.GetResponse(ref response3);
			}
			catch (Exception ex)
			{
				timer1.Enabled = false;
				MessageBox.Show(ex.Message);
				return;
			}
			if (m.CheckResponse(response3))
			{
				if (Parameters.IsUse485)
				{
					timer1.Enabled = true;
				}
				string text6 = "";
				byte[] array6 = new byte[60];
				for (int i = 0; i < 60; i++)
				{
					array6[i] = response3[3 + i];
				}
				text6 = Encoding.ASCII.GetString(array6);
				((Control)textBox1).Text = text6;
				MessageBox.Show("读取成功");
			}
			else
			{
				timer1.Enabled = true;
				MessageBox.Show("没有回复或校验错误");
			}
		}
		else
		{
			timer1.Enabled = true;
			MessageBox.Show("没有回复或校验错误");
		}
	}

	private void button56_Click(object sender, EventArgs e)
	{
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_045e: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0604: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f5: Unknown result type (might be due to invalid IL or missing references)
		byte[] CRC = new byte[2];
		if (CheckAddr())
		{
			timer1.Enabled = false;
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array = new byte[189];
			byte[] response = new byte[8];
			array[0] = Convert.ToByte(Parameters.Address);
			array[1] = 16;
			array[2] = 112;
			array[3] = 0;
			array[4] = 0;
			array[5] = 90;
			array[6] = 180;
			string text = Convert.ToString(((Control)textBox45).Text);
			text = text.Replace("  ", "\0");
			byte[] bytes = Encoding.ASCII.GetBytes(text);
			int num = 60 - bytes.Length;
			for (int i = 0; i < bytes.Length; i++)
			{
				array[7 + i] = bytes[i];
			}
			for (int i = 0; i < num; i++)
			{
				array[7 + bytes.Length + i] = 0;
			}
			string text2 = Convert.ToString(((Control)textBox44).Text);
			text2 = text2.Replace("  ", "\0");
			byte[] bytes2 = Encoding.ASCII.GetBytes(text2);
			int num2 = 60 - bytes2.Length;
			for (int i = 0; i < bytes2.Length; i++)
			{
				array[67 + i] = bytes2[i];
			}
			for (int i = 0; i < num2; i++)
			{
				array[67 + bytes2.Length + i] = 0;
			}
			string text3 = Convert.ToString(((Control)textBox43).Text);
			text3 = text3.Replace("  ", "\0");
			byte[] bytes3 = Encoding.ASCII.GetBytes(text3);
			int num3 = 60 - bytes3.Length;
			for (int i = 0; i < bytes3.Length; i++)
			{
				array[127 + i] = bytes3[i];
			}
			for (int i = 0; i < num3; i++)
			{
				array[127 + bytes3.Length + i] = 0;
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
				timer1.Enabled = false;
				MessageBox.Show(ex.Message);
				return;
			}
			byte[] array2 = new byte[131];
			byte[] response2 = new byte[8];
			array2[0] = Convert.ToByte(Parameters.Address);
			array2[1] = 16;
			array2[2] = 112;
			array2[3] = 90;
			array2[4] = 0;
			array2[5] = 61;
			array2[6] = 121;
			string text4 = Convert.ToString(((Control)textBox42).Text);
			text4 = text4.Replace("  ", "\0");
			byte[] bytes4 = Encoding.ASCII.GetBytes(text4);
			int num4 = 60 - bytes4.Length;
			for (int i = 0; i < bytes4.Length; i++)
			{
				array2[7 + i] = bytes4[i];
			}
			for (int i = 0; i < num4; i++)
			{
				array2[7 + bytes4.Length + i] = 0;
			}
			string text5 = Convert.ToString(((Control)textBox41).Text);
			text5 = text5.Replace("  ", "\0");
			byte[] bytes5 = Encoding.ASCII.GetBytes(text5);
			int num5 = 60 - bytes5.Length;
			for (int i = 0; i < bytes5.Length; i++)
			{
				array2[67 + i] = bytes5[i];
			}
			for (int i = 0; i < num5; i++)
			{
				array2[67 + bytes5.Length + i] = 0;
			}
			array2[127] = (byte)((ListControl)comboBox16).SelectedIndex;
			array2[128] = 0;
			m.GetCRC(array2, ref CRC);
			array2[^2] = CRC[0];
			array2[^1] = CRC[1];
			try
			{
				Modbus.sp.Write(array2, 0, array2.Length);
				Thread.Sleep(50);
				m.GetResponse(ref response2);
			}
			catch (Exception ex)
			{
				timer1.Enabled = false;
				MessageBox.Show(ex.Message);
				return;
			}
			byte[] array3 = new byte[69];
			byte[] response3 = new byte[8];
			array3[0] = Convert.ToByte(Parameters.Address);
			array3[1] = 16;
			array3[2] = 112;
			array3[3] = 151;
			array3[4] = 0;
			array3[5] = 30;
			array3[6] = 60;
			string text6 = Convert.ToString(((Control)textBox1).Text);
			text6 = text6.Replace("  ", "\0");
			byte[] bytes6 = Encoding.ASCII.GetBytes(text6);
			int num6 = 60 - bytes6.Length;
			for (int i = 0; i < bytes6.Length; i++)
			{
				array3[7 + i] = bytes6[i];
			}
			for (int i = 0; i < num6; i++)
			{
				array3[7 + bytes6.Length + i] = 0;
			}
			m.GetCRC(array3, ref CRC);
			array3[^2] = CRC[0];
			array3[^1] = CRC[1];
			try
			{
				Modbus.sp.Write(array3, 0, array3.Length);
				Thread.Sleep(50);
				m.GetResponse(ref response3);
			}
			catch (Exception ex)
			{
				timer1.Enabled = false;
				MessageBox.Show(ex.Message);
				return;
			}
			if (m.CheckResponse(response) && m.CheckResponse(response2) && m.CheckResponse(response3))
			{
				timer1.Enabled = true;
				MessageBox.Show("设置成功");
			}
			else
			{
				MessageBox.Show("未能成功设置");
			}
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e75: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e59: Unknown result type (might be due to invalid IL or missing references)
		if (!CheckAddr())
		{
			return;
		}
		timer1.Enabled = false;
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] CRC = new byte[2];
		byte[] array = new byte[8];
		byte[] response = new byte[15];
		array[0] = Convert.ToByte(Parameters.Address);
		array[1] = 3;
		array[2] = 112;
		array[3] = 181;
		array[4] = 0;
		array[5] = 5;
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
			timer1.Enabled = false;
			MessageBox.Show(ex.Message);
			return;
		}
		if (m.CheckResponse(response))
		{
			if (Parameters.IsUse485)
			{
				timer1.Enabled = true;
			}
			if ((response[3] & 1) == 1)
			{
				checkBox1.Checked = true;
			}
			else
			{
				checkBox1.Checked = false;
			}
			if ((response[3] & 2) == 2)
			{
				checkBox2.Checked = true;
			}
			else
			{
				checkBox2.Checked = false;
			}
			if ((response[3] & 4) == 4)
			{
				checkBox3.Checked = true;
			}
			else
			{
				checkBox3.Checked = false;
			}
			if ((response[3] & 8) == 8)
			{
				checkBox4.Checked = true;
			}
			else
			{
				checkBox4.Checked = false;
			}
			if ((response[3] & 0x10) == 16)
			{
				checkBox5.Checked = true;
			}
			else
			{
				checkBox5.Checked = false;
			}
			if ((response[3] & 0x20) == 32)
			{
				checkBox6.Checked = true;
			}
			else
			{
				checkBox6.Checked = false;
			}
			if ((response[3] & 0x40) == 64)
			{
				checkBox7.Checked = true;
			}
			else
			{
				checkBox7.Checked = false;
			}
			if ((response[3] & 0x80) == 128)
			{
				checkBox8.Checked = true;
			}
			else
			{
				checkBox8.Checked = false;
			}
			if ((response[4] & 1) == 1)
			{
				checkBox9.Checked = true;
			}
			else
			{
				checkBox9.Checked = false;
			}
			if ((response[4] & 2) == 2)
			{
				checkBox10.Checked = true;
			}
			else
			{
				checkBox10.Checked = false;
			}
			if ((response[4] & 4) == 4)
			{
				checkBox11.Checked = true;
			}
			else
			{
				checkBox11.Checked = false;
			}
			if ((response[4] & 8) == 8)
			{
				checkBox12.Checked = true;
			}
			else
			{
				checkBox12.Checked = false;
			}
			if ((response[4] & 0x10) == 16)
			{
				checkBox13.Checked = true;
			}
			else
			{
				checkBox13.Checked = false;
			}
			if ((response[4] & 0x20) == 32)
			{
				checkBox14.Checked = true;
			}
			else
			{
				checkBox14.Checked = false;
			}
			if ((response[4] & 0x40) == 64)
			{
				checkBox15.Checked = true;
			}
			else
			{
				checkBox15.Checked = false;
			}
			if ((response[4] & 0x80) == 128)
			{
				checkBox16.Checked = true;
			}
			else
			{
				checkBox16.Checked = false;
			}
			if ((response[5] & 1) == 1)
			{
				checkBox17.Checked = true;
			}
			else
			{
				checkBox17.Checked = false;
			}
			if ((response[5] & 2) == 2)
			{
				checkBox18.Checked = true;
			}
			else
			{
				checkBox18.Checked = false;
			}
			if ((response[5] & 4) == 4)
			{
				checkBox19.Checked = true;
			}
			else
			{
				checkBox19.Checked = false;
			}
			if ((response[5] & 8) == 8)
			{
				checkBox20.Checked = true;
			}
			else
			{
				checkBox20.Checked = false;
			}
			if ((response[5] & 0x10) == 16)
			{
				checkBox21.Checked = true;
			}
			else
			{
				checkBox21.Checked = false;
			}
			if ((response[5] & 0x20) == 32)
			{
				checkBox22.Checked = true;
			}
			else
			{
				checkBox22.Checked = false;
			}
			if ((response[5] & 0x40) == 64)
			{
				checkBox23.Checked = true;
			}
			else
			{
				checkBox23.Checked = false;
			}
			if ((response[5] & 0x80) == 128)
			{
				checkBox24.Checked = true;
			}
			else
			{
				checkBox24.Checked = false;
			}
			if ((response[6] & 1) == 1)
			{
				checkBox25.Checked = true;
			}
			else
			{
				checkBox25.Checked = false;
			}
			if ((response[6] & 2) == 2)
			{
				checkBox26.Checked = true;
			}
			else
			{
				checkBox26.Checked = false;
			}
			if ((response[6] & 4) == 4)
			{
				checkBox27.Checked = true;
			}
			else
			{
				checkBox27.Checked = false;
			}
			if ((response[6] & 8) == 8)
			{
				checkBox28.Checked = true;
			}
			else
			{
				checkBox28.Checked = false;
			}
			if ((response[6] & 0x10) == 16)
			{
				checkBox29.Checked = true;
			}
			else
			{
				checkBox29.Checked = false;
			}
			if ((response[6] & 0x20) == 32)
			{
				checkBox30.Checked = true;
			}
			else
			{
				checkBox30.Checked = false;
			}
			if ((response[6] & 0x40) == 64)
			{
				checkBox31.Checked = true;
			}
			else
			{
				checkBox31.Checked = false;
			}
			if ((response[6] & 0x80) == 128)
			{
				checkBox32.Checked = true;
			}
			else
			{
				checkBox32.Checked = false;
			}
			if ((response[7] & 1) == 1)
			{
				checkBox33.Checked = true;
			}
			else
			{
				checkBox33.Checked = false;
			}
			if ((response[7] & 2) == 2)
			{
				checkBox34.Checked = true;
			}
			else
			{
				checkBox34.Checked = false;
			}
			if ((response[7] & 4) == 4)
			{
				checkBox35.Checked = true;
			}
			else
			{
				checkBox35.Checked = false;
			}
			if ((response[7] & 8) == 8)
			{
				checkBox36.Checked = true;
			}
			else
			{
				checkBox36.Checked = false;
			}
			if ((response[7] & 0x10) == 16)
			{
				checkBox37.Checked = true;
			}
			else
			{
				checkBox37.Checked = false;
			}
			if ((response[7] & 0x20) == 32)
			{
				checkBox38.Checked = true;
			}
			else
			{
				checkBox38.Checked = false;
			}
			if ((response[7] & 0x40) == 64)
			{
				checkBox39.Checked = true;
			}
			else
			{
				checkBox39.Checked = false;
			}
			if ((response[7] & 0x80) == 128)
			{
				checkBox40.Checked = true;
			}
			else
			{
				checkBox40.Checked = false;
			}
			if ((response[8] & 1) == 1)
			{
				checkBox41.Checked = true;
			}
			else
			{
				checkBox41.Checked = false;
			}
			if ((response[8] & 2) == 2)
			{
				checkBox42.Checked = true;
			}
			else
			{
				checkBox42.Checked = false;
			}
			if ((response[8] & 4) == 4)
			{
				checkBox43.Checked = true;
			}
			else
			{
				checkBox43.Checked = false;
			}
			if ((response[8] & 8) == 8)
			{
				checkBox44.Checked = true;
			}
			else
			{
				checkBox44.Checked = false;
			}
			if ((response[8] & 0x10) == 16)
			{
				checkBox45.Checked = true;
			}
			else
			{
				checkBox45.Checked = false;
			}
			if ((response[8] & 0x20) == 32)
			{
				checkBox46.Checked = true;
			}
			else
			{
				checkBox46.Checked = false;
			}
			if ((response[8] & 0x40) == 64)
			{
				checkBox47.Checked = true;
			}
			else
			{
				checkBox47.Checked = false;
			}
			if ((response[8] & 0x80) == 128)
			{
				checkBox48.Checked = true;
			}
			else
			{
				checkBox48.Checked = false;
			}
			if ((response[9] & 1) == 1)
			{
				checkBox49.Checked = true;
			}
			else
			{
				checkBox49.Checked = false;
			}
			if ((response[9] & 2) == 2)
			{
				checkBox50.Checked = true;
			}
			else
			{
				checkBox50.Checked = false;
			}
			if ((response[9] & 4) == 4)
			{
				checkBox51.Checked = true;
			}
			else
			{
				checkBox51.Checked = false;
			}
			if ((response[9] & 8) == 8)
			{
				checkBox52.Checked = true;
			}
			else
			{
				checkBox52.Checked = false;
			}
			if ((response[9] & 0x10) == 16)
			{
				checkBox53.Checked = true;
			}
			else
			{
				checkBox53.Checked = false;
			}
			if ((response[9] & 0x20) == 32)
			{
				checkBox54.Checked = true;
			}
			else
			{
				checkBox54.Checked = false;
			}
			if ((response[9] & 0x40) == 64)
			{
				checkBox55.Checked = true;
			}
			else
			{
				checkBox55.Checked = false;
			}
			if ((response[9] & 0x80) == 128)
			{
				checkBox56.Checked = true;
			}
			else
			{
				checkBox56.Checked = false;
			}
			if ((response[10] & 1) == 1)
			{
				checkBox57.Checked = true;
			}
			else
			{
				checkBox57.Checked = false;
			}
			if ((response[10] & 2) == 2)
			{
				checkBox58.Checked = true;
			}
			else
			{
				checkBox58.Checked = false;
			}
			if ((response[10] & 4) == 4)
			{
				checkBox59.Checked = true;
			}
			else
			{
				checkBox59.Checked = false;
			}
			if ((response[10] & 8) == 8)
			{
				checkBox60.Checked = true;
			}
			else
			{
				checkBox60.Checked = false;
			}
			if ((response[10] & 0x10) == 16)
			{
				checkBox61.Checked = true;
			}
			else
			{
				checkBox61.Checked = false;
			}
			if ((response[10] & 0x20) == 32)
			{
				checkBox62.Checked = true;
			}
			else
			{
				checkBox62.Checked = false;
			}
			if ((response[10] & 0x40) == 64)
			{
				checkBox63.Checked = true;
			}
			else
			{
				checkBox63.Checked = false;
			}
			if ((response[10] & 0x80) == 128)
			{
				checkBox64.Checked = true;
			}
			else
			{
				checkBox64.Checked = false;
			}
			if ((response[11] & 1) == 1)
			{
				checkBox65.Checked = true;
			}
			else
			{
				checkBox65.Checked = false;
			}
			if ((response[11] & 2) == 2)
			{
				checkBox66.Checked = true;
			}
			else
			{
				checkBox66.Checked = false;
			}
			if ((response[11] & 4) == 4)
			{
				checkBox67.Checked = true;
			}
			else
			{
				checkBox67.Checked = false;
			}
			if ((response[11] & 8) == 8)
			{
				checkBox68.Checked = true;
			}
			else
			{
				checkBox68.Checked = false;
			}
			if ((response[11] & 0x10) == 16)
			{
				checkBox69.Checked = true;
			}
			else
			{
				checkBox69.Checked = false;
			}
			if ((response[11] & 0x20) == 32)
			{
				checkBox70.Checked = true;
			}
			else
			{
				checkBox70.Checked = false;
			}
			if ((response[11] & 0x40) == 64)
			{
				checkBox71.Checked = true;
			}
			else
			{
				checkBox71.Checked = false;
			}
			if ((response[11] & 0x80) == 128)
			{
				checkBox72.Checked = true;
			}
			else
			{
				checkBox72.Checked = false;
			}
			MessageBox.Show("读取成功");
		}
		else
		{
			timer1.Enabled = true;
			MessageBox.Show("没有回复或校验错误");
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		//IL_09b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e7: Unknown result type (might be due to invalid IL or missing references)
		byte[] CRC = new byte[2];
		if (CheckAddr())
		{
			timer1.Enabled = false;
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array = new byte[19];
			byte[] response = new byte[8];
			array[0] = Convert.ToByte(Parameters.Address);
			array[1] = 16;
			array[2] = 112;
			array[3] = 181;
			array[4] = 0;
			array[5] = 5;
			array[6] = 16;
			if (checkBox1.Checked)
			{
				array[7] = (byte)(array[7] | 1);
			}
			if (checkBox2.Checked)
			{
				array[7] = (byte)(array[7] | 2);
			}
			if (checkBox3.Checked)
			{
				array[7] = (byte)(array[7] | 4);
			}
			if (checkBox4.Checked)
			{
				array[7] = (byte)(array[7] | 8);
			}
			if (checkBox5.Checked)
			{
				array[7] = (byte)(array[7] | 0x10);
			}
			if (checkBox6.Checked)
			{
				array[7] = (byte)(array[7] | 0x20);
			}
			if (checkBox7.Checked)
			{
				array[7] = (byte)(array[7] | 0x40);
			}
			if (checkBox8.Checked)
			{
				array[7] = (byte)(array[7] | 0x80);
			}
			if (checkBox9.Checked)
			{
				array[8] = (byte)(array[8] | 1);
			}
			if (checkBox10.Checked)
			{
				array[8] = (byte)(array[8] | 2);
			}
			if (checkBox11.Checked)
			{
				array[8] = (byte)(array[8] | 4);
			}
			if (checkBox12.Checked)
			{
				array[8] = (byte)(array[8] | 8);
			}
			if (checkBox13.Checked)
			{
				array[8] = (byte)(array[8] | 0x10);
			}
			if (checkBox14.Checked)
			{
				array[8] = (byte)(array[8] | 0x20);
			}
			if (checkBox15.Checked)
			{
				array[8] = (byte)(array[8] | 0x40);
			}
			if (checkBox16.Checked)
			{
				array[8] = (byte)(array[8] | 0x80);
			}
			if (checkBox17.Checked)
			{
				array[9] = (byte)(array[9] | 1);
			}
			if (checkBox18.Checked)
			{
				array[9] = (byte)(array[9] | 2);
			}
			if (checkBox19.Checked)
			{
				array[9] = (byte)(array[9] | 4);
			}
			if (checkBox20.Checked)
			{
				array[9] = (byte)(array[9] | 8);
			}
			if (checkBox21.Checked)
			{
				array[9] = (byte)(array[9] | 0x10);
			}
			if (checkBox22.Checked)
			{
				array[9] = (byte)(array[9] | 0x20);
			}
			if (checkBox23.Checked)
			{
				array[9] = (byte)(array[9] | 0x40);
			}
			if (checkBox24.Checked)
			{
				array[9] = (byte)(array[9] | 0x80);
			}
			if (checkBox25.Checked)
			{
				array[10] = (byte)(array[10] | 1);
			}
			if (checkBox26.Checked)
			{
				array[10] = (byte)(array[10] | 2);
			}
			if (checkBox27.Checked)
			{
				array[10] = (byte)(array[10] | 4);
			}
			if (checkBox28.Checked)
			{
				array[10] = (byte)(array[10] | 8);
			}
			if (checkBox29.Checked)
			{
				array[10] = (byte)(array[10] | 0x10);
			}
			if (checkBox30.Checked)
			{
				array[10] = (byte)(array[10] | 0x20);
			}
			if (checkBox31.Checked)
			{
				array[10] = (byte)(array[10] | 0x40);
			}
			if (checkBox32.Checked)
			{
				array[10] = (byte)(array[10] | 0x80);
			}
			if (checkBox33.Checked)
			{
				array[11] = (byte)(array[11] | 1);
			}
			if (checkBox34.Checked)
			{
				array[11] = (byte)(array[11] | 2);
			}
			if (checkBox35.Checked)
			{
				array[11] = (byte)(array[11] | 4);
			}
			if (checkBox36.Checked)
			{
				array[11] = (byte)(array[11] | 8);
			}
			if (checkBox37.Checked)
			{
				array[11] = (byte)(array[11] | 0x10);
			}
			if (checkBox38.Checked)
			{
				array[11] = (byte)(array[11] | 0x20);
			}
			if (checkBox39.Checked)
			{
				array[11] = (byte)(array[11] | 0x40);
			}
			if (checkBox40.Checked)
			{
				array[11] = (byte)(array[11] | 0x80);
			}
			if (checkBox41.Checked)
			{
				array[12] = (byte)(array[12] | 1);
			}
			if (checkBox42.Checked)
			{
				array[12] = (byte)(array[12] | 2);
			}
			if (checkBox43.Checked)
			{
				array[12] = (byte)(array[12] | 4);
			}
			if (checkBox44.Checked)
			{
				array[12] = (byte)(array[12] | 8);
			}
			if (checkBox45.Checked)
			{
				array[12] = (byte)(array[12] | 0x10);
			}
			if (checkBox46.Checked)
			{
				array[12] = (byte)(array[12] | 0x20);
			}
			if (checkBox47.Checked)
			{
				array[12] = (byte)(array[12] | 0x40);
			}
			if (checkBox48.Checked)
			{
				array[12] = (byte)(array[12] | 0x80);
			}
			if (checkBox49.Checked)
			{
				array[13] = (byte)(array[13] | 1);
			}
			if (checkBox50.Checked)
			{
				array[13] = (byte)(array[13] | 2);
			}
			if (checkBox51.Checked)
			{
				array[13] = (byte)(array[13] | 4);
			}
			if (checkBox52.Checked)
			{
				array[13] = (byte)(array[13] | 8);
			}
			if (checkBox53.Checked)
			{
				array[13] = (byte)(array[13] | 0x10);
			}
			if (checkBox54.Checked)
			{
				array[13] = (byte)(array[13] | 0x20);
			}
			if (checkBox55.Checked)
			{
				array[13] = (byte)(array[13] | 0x40);
			}
			if (checkBox56.Checked)
			{
				array[13] = (byte)(array[13] | 0x80);
			}
			if (checkBox57.Checked)
			{
				array[14] = (byte)(array[14] | 1);
			}
			if (checkBox58.Checked)
			{
				array[14] = (byte)(array[14] | 2);
			}
			if (checkBox59.Checked)
			{
				array[14] = (byte)(array[14] | 4);
			}
			if (checkBox60.Checked)
			{
				array[14] = (byte)(array[14] | 8);
			}
			if (checkBox61.Checked)
			{
				array[14] = (byte)(array[14] | 0x10);
			}
			if (checkBox62.Checked)
			{
				array[14] = (byte)(array[14] | 0x20);
			}
			if (checkBox63.Checked)
			{
				array[14] = (byte)(array[14] | 0x40);
			}
			if (checkBox64.Checked)
			{
				array[14] = (byte)(array[14] | 0x80);
			}
			array[15] = 0;
			if (checkBox65.Checked)
			{
				array[15] = (byte)(array[15] | 1);
			}
			if (checkBox66.Checked)
			{
				array[15] = (byte)(array[15] | 2);
			}
			if (checkBox67.Checked)
			{
				array[15] = (byte)(array[15] | 4);
			}
			if (checkBox68.Checked)
			{
				array[15] = (byte)(array[15] | 8);
			}
			if (checkBox69.Checked)
			{
				array[15] = (byte)(array[15] | 0x10);
			}
			if (checkBox70.Checked)
			{
				array[15] = (byte)(array[15] | 0x20);
			}
			if (checkBox71.Checked)
			{
				array[15] = (byte)(array[15] | 0x40);
			}
			if (checkBox72.Checked)
			{
				array[15] = (byte)(array[15] | 0x80);
			}
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
				timer1.Enabled = false;
				MessageBox.Show(ex.Message);
				return;
			}
			if (m.CheckResponse(response))
			{
				timer1.Enabled = true;
				MessageBox.Show("设置成功");
			}
			else
			{
				MessageBox.Show("未能设置成功");
			}
		}
	}
}
