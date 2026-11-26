using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace _645ClearE;

public class zhongtai_basic_set : Form
{
	private Modbus m = new Modbus();

	private IContainer components = null;

	private GroupBox basic_para;

	private Label label1055;

	private Label label1054;

	private TextBox country_set;

	private Label label1050;

	private Button button100;

	private Label label1052;

	private Label label1053;

	private Button button99;

	private Label label1051;

	private Label label1048;

	private Label label1049;

	private TextBox Serial_name;

	private ComboBox new_QOS;

	private TextBox MQTT_num;

	private TextBox Time_Hour;

	private TextBox Time_Minute;

	private TextBox Pack_Num;

	private GroupBox first_pack;

	private Button button93;

	private Button button94;

	private CheckBox checkBox19;

	private CheckBox checkBox20;

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

	private CheckBox checkBox31;

	private CheckBox checkBox32;

	private CheckBox checkBox33;

	private CheckBox checkBox34;

	private CheckBox checkBox39;

	private CheckBox checkBox40;

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

	private CheckBox checkBox73;

	private CheckBox checkBox74;

	private CheckBox checkBox75;

	private CheckBox checkBox76;

	private CheckBox checkBox77;

	private CheckBox checkBox78;

	private CheckBox checkBox79;

	private CheckBox checkBox80;

	private CheckBox checkBox81;

	private CheckBox checkBox82;

	private CheckBox checkBox83;

	private CheckBox checkBox84;

	private CheckBox checkBox85;

	private CheckBox checkBox86;

	public zhongtai_basic_set()
	{
		InitializeComponent();
	}

	private bool CheckAddr()
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		if (Parameters.IsRightAddr != 1)
		{
			MessageBox.Show("Please check the Slave ID!");
			return false;
		}
		if (Parameters.IsPortOpen > 0)
		{
			return true;
		}
		MessageBox.Show("Please open the port!");
		return false;
	}

	private void button93_Click(object sender, EventArgs e)
	{
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected Obj, but got Unknown
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected Obj, but got Unknown
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		if (!CheckAddr())
		{
			return;
		}
		byte b = 0;
		byte b2 = 0;
		byte[] array = new byte[96];
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array2 = new byte[4];
		byte[] array3 = new byte[8];
		byte[] response = new byte[101];
		byte[] CRC = new byte[2];
		array3[0] = Convert.ToByte(Parameters.Address);
		array3[1] = 3;
		array3[2] = 113;
		array3[3] = 0;
		array3[4] = 0;
		array3[5] = 48;
		m.GetCRC(array3, ref CRC);
		m.GetCRC(array3, ref CRC);
		array3[^2] = CRC[0];
		array3[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array3, 0, array3.Length);
			Thread.Sleep(20);
			m.GetResponse(ref response);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message + " No reply or check error");
			return;
		}
		if (m.CheckResponse(response))
		{
			if (Parameters.IsUse485)
			{
			}
			byte b3 = 3;
			foreach (Control item in (ArrangedElementCollection)((Control)first_pack).Controls)
			{
				Control val = item;
				if (val is CheckBox)
				{
					b++;
					CheckBox val2 = (CheckBox)val;
					if (response[b3] == b)
					{
						val2.Checked = true;
						b3++;
					}
					else
					{
						val2.Checked = false;
					}
				}
			}
			MessageBox.Show("read success");
		}
		else
		{
			MessageBox.Show("no recieve or check error");
		}
	}

	private void button94_Click(object sender, EventArgs e)
	{
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected Obj, but got Unknown
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected Obj, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		byte[] CRC = new byte[2];
		byte b = 0;
		if (!CheckAddr())
		{
			return;
		}
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[105];
		byte[] response = new byte[8];
		array[0] = Convert.ToByte(Parameters.Address);
		array[1] = 16;
		array[2] = 113;
		array[3] = 0;
		array[4] = 0;
		array[5] = 48;
		array[6] = 96;
		byte b2 = 7;
		foreach (Control item in (ArrangedElementCollection)((Control)first_pack).Controls)
		{
			Control val = item;
			if (val is CheckBox)
			{
				b++;
				CheckBox val2 = (CheckBox)val;
				if (val2.Checked)
				{
					array[b2] = b;
					b2++;
				}
			}
		}
		if (b2 - 7 != Convert.ToByte(((Control)MQTT_num).Text))
		{
			MessageBox.Show(" select num != datanum");
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
			MessageBox.Show(ex.Message + " No reply or check error");
			return;
		}
		if (m.CheckResponse(response))
		{
			MessageBox.Show("Set success!");
		}
		else
		{
			MessageBox.Show("Failed to set!");
		}
	}

	private void button100_Click(object sender, EventArgs e)
	{
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		if (!CheckAddr())
		{
			return;
		}
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] CRC = new byte[2];
		byte[] array = new byte[8];
		byte[] response = new byte[71];
		array[0] = Convert.ToByte(Parameters.Address);
		array[1] = 3;
		array[2] = 112;
		array[3] = 0;
		array[4] = 0;
		array[5] = 33;
		this.m.GetCRC(array, ref CRC);
		array[^2] = CRC[0];
		array[^1] = CRC[1];
		try
		{
			Modbus.sp.Write(array, 0, array.Length);
			Thread.Sleep(20);
			this.m.GetResponse(ref response);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message + " No reply or check error");
			return;
		}
		if (this.m.CheckResponse(response))
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
			((Control)Serial_name).Text = text;
			((ListControl)new_QOS).SelectedIndex = response[19];
			((Control)MQTT_num).Text = response[20].ToString();
			string text2 = " ";
			byte[] array4 = new byte[40];
			for (int k = 0; k < 40; k++)
			{
				array4[k] = response[21 + k];
			}
			text2 = Encoding.ASCII.GetString(array4);
			((Control)country_set).Text = text2;
			string text3 = " ";
			byte[] array5 = new byte[4];
			for (int l = 0; l < 4; l++)
			{
				array5[l] = response[61 + l];
			}
			text3 = Encoding.ASCII.GetString(array5);
			((Control)Time_Hour).Text = text3;
			string text4 = " ";
			byte[] array6 = new byte[3];
			for (int m = 0; m < 3; m++)
			{
				array6[m] = response[65 + m];
			}
			text4 = Encoding.ASCII.GetString(array6);
			((Control)Time_Minute).Text = text4;
			((Control)Pack_Num).Text = response[68].ToString();
			MessageBox.Show("Read success!");
		}
		else
		{
			MessageBox.Show("No reply or check error");
		}
	}

	private void button99_Click(object sender, EventArgs e)
	{
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		byte[] CRC = new byte[2];
		if (CheckAddr())
		{
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array = new byte[75];
			byte[] response = new byte[8];
			array[0] = Convert.ToByte(Parameters.Address);
			array[1] = 16;
			array[2] = 112;
			array[3] = 0;
			array[4] = 0;
			array[5] = 33;
			array[6] = 66;
			string text = Convert.ToString(((Control)Serial_name).Text);
			text = text.Replace("  ", "\0");
			byte[] bytes = Encoding.ASCII.GetBytes(text);
			int num = 16 - bytes.Length;
			for (int i = 0; i < bytes.Length; i++)
			{
				array[7 + i] = bytes[i];
			}
			for (int j = 0; j < num; j++)
			{
				array[7 + bytes.Length + j] = 0;
			}
			array[23] = (byte)((ListControl)new_QOS).SelectedIndex;
			array[24] = Convert.ToByte(((Control)MQTT_num).Text);
			text = Convert.ToString(((Control)country_set).Text);
			byte[] bytes2 = Encoding.ASCII.GetBytes(text);
			num = 40 - bytes2.Length;
			for (int k = 0; k < bytes2.Length; k++)
			{
				array[25 + k] = bytes2[k];
			}
			for (int l = 0; l < num; l++)
			{
				array[25 + bytes2.Length + l] = 0;
			}
			text = Convert.ToString(((Control)Time_Hour).Text);
			bytes2 = Encoding.ASCII.GetBytes(text);
			num = 4 - bytes2.Length;
			for (int m = 0; m < bytes2.Length; m++)
			{
				array[65 + m] = bytes2[m];
			}
			for (int n = 0; n < num; n++)
			{
				array[65 + bytes2.Length + n] = 0;
			}
			text = Convert.ToString(((Control)Time_Minute).Text);
			bytes2 = Encoding.ASCII.GetBytes(text);
			num = 3 - bytes2.Length;
			for (int num2 = 0; num2 < bytes2.Length; num2++)
			{
				array[69 + num2] = bytes2[num2];
			}
			for (int num3 = 0; num3 < num; num3++)
			{
				array[69 + bytes2.Length + num3] = 0;
			}
			array[72] = Convert.ToByte(((Control)Pack_Num).Text);
			this.m.GetCRC(array, ref CRC);
			array[^2] = CRC[0];
			array[^1] = CRC[1];
			try
			{
				Modbus.sp.Write(array, 0, array.Length);
				Thread.Sleep(50);
				this.m.GetResponse(ref response);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + " No reply or check error");
				return;
			}
			if (this.m.CheckResponse(response))
			{
				MessageBox.Show("Set success!");
			}
			else
			{
				MessageBox.Show("Failed to set!");
			}
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
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Expected Obj, but got Unknown
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Expected Obj, but got Unknown
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Expected Obj, but got Unknown
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected Obj, but got Unknown
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Expected Obj, but got Unknown
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected Obj, but got Unknown
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Expected Obj, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected Obj, but got Unknown
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Expected Obj, but got Unknown
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected Obj, but got Unknown
		//IL_0280: Unknown result type (might be due to invalid IL or missing references)
		//IL_028a: Expected Obj, but got Unknown
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Expected Obj, but got Unknown
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Expected Obj, but got Unknown
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Expected Obj, but got Unknown
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Expected Obj, but got Unknown
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Expected Obj, but got Unknown
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Expected Obj, but got Unknown
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d7: Expected Obj, but got Unknown
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Expected Obj, but got Unknown
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Expected Obj, but got Unknown
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Expected Obj, but got Unknown
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Expected Obj, but got Unknown
		//IL_0304: Unknown result type (might be due to invalid IL or missing references)
		//IL_030e: Expected Obj, but got Unknown
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Expected Obj, but got Unknown
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0324: Expected Obj, but got Unknown
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_032f: Expected Obj, but got Unknown
		//IL_0330: Unknown result type (might be due to invalid IL or missing references)
		//IL_033a: Expected Obj, but got Unknown
		//IL_033b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0345: Expected Obj, but got Unknown
		//IL_0346: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Expected Obj, but got Unknown
		//IL_0351: Unknown result type (might be due to invalid IL or missing references)
		//IL_035b: Expected Obj, but got Unknown
		//IL_035c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0366: Expected Obj, but got Unknown
		//IL_0367: Unknown result type (might be due to invalid IL or missing references)
		//IL_0371: Expected Obj, but got Unknown
		//IL_0372: Unknown result type (might be due to invalid IL or missing references)
		//IL_037c: Expected Obj, but got Unknown
		//IL_037d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0387: Expected Obj, but got Unknown
		//IL_0388: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Expected Obj, but got Unknown
		//IL_0393: Unknown result type (might be due to invalid IL or missing references)
		//IL_039d: Expected Obj, but got Unknown
		//IL_039e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a8: Expected Obj, but got Unknown
		//IL_05e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05eb: Expected Obj, but got Unknown
		//IL_0680: Unknown result type (might be due to invalid IL or missing references)
		//IL_068a: Expected Obj, but got Unknown
		//IL_0761: Unknown result type (might be due to invalid IL or missing references)
		//IL_076b: Expected Obj, but got Unknown
		//IL_086e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0878: Expected Obj, but got Unknown
		//IL_08f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0903: Expected Obj, but got Unknown
		//IL_0a0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a16: Expected Obj, but got Unknown
		//IL_0a97: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa1: Expected Obj, but got Unknown
		//IL_0b1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b29: Expected Obj, but got Unknown
		basic_para = new GroupBox();
		label1055 = new Label();
		label1054 = new Label();
		country_set = new TextBox();
		label1050 = new Label();
		button100 = new Button();
		label1052 = new Label();
		label1053 = new Label();
		button99 = new Button();
		label1051 = new Label();
		label1048 = new Label();
		label1049 = new Label();
		Serial_name = new TextBox();
		new_QOS = new ComboBox();
		MQTT_num = new TextBox();
		Time_Hour = new TextBox();
		Time_Minute = new TextBox();
		Pack_Num = new TextBox();
		first_pack = new GroupBox();
		button93 = new Button();
		button94 = new Button();
		checkBox19 = new CheckBox();
		checkBox20 = new CheckBox();
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
		checkBox31 = new CheckBox();
		checkBox32 = new CheckBox();
		checkBox33 = new CheckBox();
		checkBox34 = new CheckBox();
		checkBox39 = new CheckBox();
		checkBox40 = new CheckBox();
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
		checkBox73 = new CheckBox();
		checkBox74 = new CheckBox();
		checkBox75 = new CheckBox();
		checkBox76 = new CheckBox();
		checkBox77 = new CheckBox();
		checkBox78 = new CheckBox();
		checkBox79 = new CheckBox();
		checkBox80 = new CheckBox();
		checkBox81 = new CheckBox();
		checkBox82 = new CheckBox();
		checkBox83 = new CheckBox();
		checkBox84 = new CheckBox();
		checkBox85 = new CheckBox();
		checkBox86 = new CheckBox();
		((Control)basic_para).SuspendLayout();
		((Control)first_pack).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)basic_para).Controls.Add((Control)(object)label1055);
		((Control)basic_para).Controls.Add((Control)(object)label1054);
		((Control)basic_para).Controls.Add((Control)(object)country_set);
		((Control)basic_para).Controls.Add((Control)(object)label1050);
		((Control)basic_para).Controls.Add((Control)(object)button100);
		((Control)basic_para).Controls.Add((Control)(object)label1052);
		((Control)basic_para).Controls.Add((Control)(object)label1053);
		((Control)basic_para).Controls.Add((Control)(object)button99);
		((Control)basic_para).Controls.Add((Control)(object)label1051);
		((Control)basic_para).Controls.Add((Control)(object)label1048);
		((Control)basic_para).Controls.Add((Control)(object)label1049);
		((Control)basic_para).Controls.Add((Control)(object)Serial_name);
		((Control)basic_para).Controls.Add((Control)(object)new_QOS);
		((Control)basic_para).Controls.Add((Control)(object)MQTT_num);
		((Control)basic_para).Controls.Add((Control)(object)Time_Hour);
		((Control)basic_para).Controls.Add((Control)(object)Time_Minute);
		((Control)basic_para).Controls.Add((Control)(object)Pack_Num);
		((Control)basic_para).Location = new Point(522, 20);
		((Control)basic_para).Name = "basic_para";
		((Control)basic_para).Size = new Size(253, 354);
		((Control)basic_para).TabIndex = 194;
		basic_para.TabStop = false;
		((Control)basic_para).Text = "basic_para";
		((Control)label1055).AutoSize = true;
		((Control)label1055).Font = new Font("Times New Roman", 15.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)label1055).ForeColor = Color.Red;
		((Control)label1055).Location = new Point(32, 322);
		((Control)label1055).Name = "label1055";
		((Control)label1055).Size = new Size(175, 23);
		((Control)label1055).TabIndex = 195;
		((Control)label1055).Text = "please read this first";
		((Control)label1054).AutoSize = true;
		((Control)label1054).Font = new Font("Times New Roman", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)label1054).Location = new Point(22, 126);
		((Control)label1054).Name = "label1054";
		((Control)label1054).Size = new Size(51, 15);
		((Control)label1054).TabIndex = 194;
		((Control)label1054).Text = "Country";
		((Control)country_set).Location = new Point(116, 124);
		((Control)country_set).Name = "country_set";
		((Control)country_set).Size = new Size(91, 21);
		((Control)country_set).TabIndex = 193;
		((Control)label1050).AutoSize = true;
		label1050.FlatStyle = (FlatStyle)3;
		((Control)label1050).Font = new Font("Times New Roman", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)label1050).Location = new Point(21, 17);
		((Control)label1050).Name = "label1050";
		((Control)label1050).Size = new Size(61, 15);
		((Control)label1050).TabIndex = 178;
		((Control)label1050).Text = "SerialNum";
		((Control)button100).Location = new Point(25, 275);
		((Control)button100).Name = "button100";
		((Control)button100).Size = new Size(75, 23);
		((Control)button100).TabIndex = 175;
		((Control)button100).Text = "Read";
		((ButtonBase)button100).UseVisualStyleBackColor = true;
		((Control)button100).Click += button100_Click;
		((Control)label1052).AutoSize = true;
		((Control)label1052).Font = new Font("Times New Roman", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)label1052).Location = new Point(22, 161);
		((Control)label1052).Name = "label1052";
		((Control)label1052).Size = new Size(61, 15);
		((Control)label1052).TabIndex = 187;
		((Control)label1052).Text = "TimeZone";
		((Control)label1053).AutoSize = true;
		((Control)label1053).Font = new Font("Times New Roman", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)label1053).Location = new Point(22, 232);
		((Control)label1053).Name = "label1053";
		((Control)label1053).Size = new Size(62, 15);
		((Control)label1053).TabIndex = 192;
		((Control)label1053).Text = "Pack_num";
		((Control)button99).Location = new Point(157, 274);
		((Control)button99).Name = "button99";
		((Control)button99).Size = new Size(75, 23);
		((Control)button99).TabIndex = 176;
		((Control)button99).Text = "Write";
		((ButtonBase)button99).UseVisualStyleBackColor = true;
		((Control)button99).Click += button99_Click;
		((Control)label1051).AutoSize = true;
		((Control)label1051).Font = new Font("Times New Roman", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)label1051).Location = new Point(22, 197);
		((Control)label1051).Name = "label1051";
		((Control)label1051).Size = new Size(72, 15);
		((Control)label1051).TabIndex = 189;
		((Control)label1051).Text = "TimeMinute";
		((Control)label1048).AutoSize = true;
		((Control)label1048).Font = new Font("Times New Roman", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)label1048).Location = new Point(21, 91);
		((Control)label1048).Name = "label1048";
		((Control)label1048).Size = new Size(55, 15);
		((Control)label1048).TabIndex = 181;
		((Control)label1048).Text = "Datanum";
		((Control)label1049).AutoSize = true;
		((Control)label1049).Font = new Font("Times New Roman", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)label1049).Location = new Point(21, 54);
		((Control)label1049).Name = "label1049";
		((Control)label1049).Size = new Size(32, 15);
		((Control)label1049).TabIndex = 179;
		((Control)label1049).Text = "QOS";
		((Control)Serial_name).Location = new Point(116, 14);
		((TextBoxBase)Serial_name).MaxLength = 30;
		((Control)Serial_name).Name = "Serial_name";
		((Control)Serial_name).Size = new Size(130, 21);
		((Control)Serial_name).TabIndex = 177;
		((ListControl)new_QOS).FormattingEnabled = true;
		new_QOS.Items.AddRange(new object[3] { "0", "1", "2" });
		((Control)new_QOS).Location = new Point(116, 49);
		((Control)new_QOS).Name = "new_QOS";
		((Control)new_QOS).Size = new Size(44, 20);
		((Control)new_QOS).TabIndex = 174;
		((Control)MQTT_num).Location = new Point(116, 88);
		((Control)MQTT_num).Name = "MQTT_num";
		((Control)MQTT_num).Size = new Size(44, 21);
		((Control)MQTT_num).TabIndex = 180;
		((Control)Time_Hour).Location = new Point(116, 159);
		((Control)Time_Hour).Name = "Time_Hour";
		((Control)Time_Hour).Size = new Size(39, 21);
		((Control)Time_Hour).TabIndex = 186;
		((Control)Time_Minute).Location = new Point(116, 195);
		((Control)Time_Minute).Name = "Time_Minute";
		((Control)Time_Minute).Size = new Size(39, 21);
		((Control)Time_Minute).TabIndex = 188;
		((Control)Pack_Num).Location = new Point(116, 230);
		((Control)Pack_Num).Name = "Pack_Num";
		((Control)Pack_Num).Size = new Size(39, 21);
		((Control)Pack_Num).TabIndex = 191;
		((Control)first_pack).Controls.Add((Control)(object)button93);
		((Control)first_pack).Controls.Add((Control)(object)button94);
		((Control)first_pack).Controls.Add((Control)(object)checkBox19);
		((Control)first_pack).Controls.Add((Control)(object)checkBox20);
		((Control)first_pack).Controls.Add((Control)(object)checkBox21);
		((Control)first_pack).Controls.Add((Control)(object)checkBox22);
		((Control)first_pack).Controls.Add((Control)(object)checkBox23);
		((Control)first_pack).Controls.Add((Control)(object)checkBox24);
		((Control)first_pack).Controls.Add((Control)(object)checkBox25);
		((Control)first_pack).Controls.Add((Control)(object)checkBox26);
		((Control)first_pack).Controls.Add((Control)(object)checkBox27);
		((Control)first_pack).Controls.Add((Control)(object)checkBox28);
		((Control)first_pack).Controls.Add((Control)(object)checkBox29);
		((Control)first_pack).Controls.Add((Control)(object)checkBox30);
		((Control)first_pack).Controls.Add((Control)(object)checkBox31);
		((Control)first_pack).Controls.Add((Control)(object)checkBox32);
		((Control)first_pack).Controls.Add((Control)(object)checkBox33);
		((Control)first_pack).Controls.Add((Control)(object)checkBox34);
		((Control)first_pack).Controls.Add((Control)(object)checkBox39);
		((Control)first_pack).Controls.Add((Control)(object)checkBox40);
		((Control)first_pack).Controls.Add((Control)(object)checkBox41);
		((Control)first_pack).Controls.Add((Control)(object)checkBox42);
		((Control)first_pack).Controls.Add((Control)(object)checkBox43);
		((Control)first_pack).Controls.Add((Control)(object)checkBox44);
		((Control)first_pack).Controls.Add((Control)(object)checkBox45);
		((Control)first_pack).Controls.Add((Control)(object)checkBox46);
		((Control)first_pack).Controls.Add((Control)(object)checkBox47);
		((Control)first_pack).Controls.Add((Control)(object)checkBox48);
		((Control)first_pack).Controls.Add((Control)(object)checkBox49);
		((Control)first_pack).Controls.Add((Control)(object)checkBox50);
		((Control)first_pack).Controls.Add((Control)(object)checkBox51);
		((Control)first_pack).Controls.Add((Control)(object)checkBox52);
		((Control)first_pack).Controls.Add((Control)(object)checkBox53);
		((Control)first_pack).Controls.Add((Control)(object)checkBox54);
		((Control)first_pack).Controls.Add((Control)(object)checkBox55);
		((Control)first_pack).Controls.Add((Control)(object)checkBox56);
		((Control)first_pack).Controls.Add((Control)(object)checkBox57);
		((Control)first_pack).Controls.Add((Control)(object)checkBox58);
		((Control)first_pack).Controls.Add((Control)(object)checkBox59);
		((Control)first_pack).Controls.Add((Control)(object)checkBox60);
		((Control)first_pack).Controls.Add((Control)(object)checkBox61);
		((Control)first_pack).Controls.Add((Control)(object)checkBox62);
		((Control)first_pack).Controls.Add((Control)(object)checkBox63);
		((Control)first_pack).Controls.Add((Control)(object)checkBox64);
		((Control)first_pack).Controls.Add((Control)(object)checkBox65);
		((Control)first_pack).Controls.Add((Control)(object)checkBox66);
		((Control)first_pack).Controls.Add((Control)(object)checkBox67);
		((Control)first_pack).Controls.Add((Control)(object)checkBox68);
		((Control)first_pack).Controls.Add((Control)(object)checkBox69);
		((Control)first_pack).Controls.Add((Control)(object)checkBox70);
		((Control)first_pack).Controls.Add((Control)(object)checkBox71);
		((Control)first_pack).Controls.Add((Control)(object)checkBox72);
		((Control)first_pack).Controls.Add((Control)(object)checkBox73);
		((Control)first_pack).Controls.Add((Control)(object)checkBox74);
		((Control)first_pack).Controls.Add((Control)(object)checkBox75);
		((Control)first_pack).Controls.Add((Control)(object)checkBox76);
		((Control)first_pack).Controls.Add((Control)(object)checkBox77);
		((Control)first_pack).Controls.Add((Control)(object)checkBox78);
		((Control)first_pack).Controls.Add((Control)(object)checkBox79);
		((Control)first_pack).Controls.Add((Control)(object)checkBox80);
		((Control)first_pack).Controls.Add((Control)(object)checkBox81);
		((Control)first_pack).Controls.Add((Control)(object)checkBox82);
		((Control)first_pack).Controls.Add((Control)(object)checkBox83);
		((Control)first_pack).Controls.Add((Control)(object)checkBox84);
		((Control)first_pack).Controls.Add((Control)(object)checkBox85);
		((Control)first_pack).Controls.Add((Control)(object)checkBox86);
		((Control)first_pack).Location = new Point(12, 12);
		((Control)first_pack).Name = "first_pack";
		((Control)first_pack).Size = new Size(504, 362);
		((Control)first_pack).TabIndex = 193;
		first_pack.TabStop = false;
		((Control)first_pack).Text = "firsrt pack choose(48in64)";
		((Control)button93).Location = new Point(428, 101);
		((Control)button93).Name = "button93";
		((Control)button93).Size = new Size(55, 23);
		((Control)button93).TabIndex = 119;
		((Control)button93).Text = "Read";
		((ButtonBase)button93).UseVisualStyleBackColor = true;
		((Control)button93).Click += button93_Click;
		((Control)button94).Location = new Point(428, 225);
		((Control)button94).Name = "button94";
		((Control)button94).Size = new Size(55, 23);
		((Control)button94).TabIndex = 118;
		((Control)button94).Text = "Write";
		((ButtonBase)button94).UseVisualStyleBackColor = true;
		((Control)button94).Click += button94_Click;
		((Control)checkBox19).AutoSize = true;
		((Control)checkBox19).Location = new Point(21, 20);
		((Control)checkBox19).Name = "checkBox19";
		((Control)checkBox19).Size = new Size(36, 16);
		((Control)checkBox19).TabIndex = 0;
		((Control)checkBox19).Text = "Ua";
		((ButtonBase)checkBox19).UseVisualStyleBackColor = true;
		((Control)checkBox20).AutoSize = true;
		((Control)checkBox20).Location = new Point(21, 42);
		((Control)checkBox20).Name = "checkBox20";
		((Control)checkBox20).Size = new Size(36, 16);
		((Control)checkBox20).TabIndex = 1;
		((Control)checkBox20).Text = "Ub";
		((ButtonBase)checkBox20).UseVisualStyleBackColor = true;
		((Control)checkBox21).AutoSize = true;
		((Control)checkBox21).Location = new Point(21, 64);
		((Control)checkBox21).Name = "checkBox21";
		((Control)checkBox21).Size = new Size(36, 16);
		((Control)checkBox21).TabIndex = 2;
		((Control)checkBox21).Text = "Uc";
		((ButtonBase)checkBox21).UseVisualStyleBackColor = true;
		((Control)checkBox22).AutoSize = true;
		((Control)checkBox22).Location = new Point(21, 86);
		((Control)checkBox22).Name = "checkBox22";
		((Control)checkBox22).Size = new Size(36, 16);
		((Control)checkBox22).TabIndex = 3;
		((Control)checkBox22).Text = "UN";
		((ButtonBase)checkBox22).UseVisualStyleBackColor = true;
		((Control)checkBox23).AutoSize = true;
		((Control)checkBox23).Location = new Point(21, 108);
		((Control)checkBox23).Name = "checkBox23";
		((Control)checkBox23).Size = new Size(36, 16);
		((Control)checkBox23).TabIndex = 4;
		((Control)checkBox23).Text = "Ia";
		((ButtonBase)checkBox23).UseVisualStyleBackColor = true;
		((Control)checkBox24).AutoSize = true;
		((Control)checkBox24).Location = new Point(21, 130);
		((Control)checkBox24).Name = "checkBox24";
		((Control)checkBox24).Size = new Size(36, 16);
		((Control)checkBox24).TabIndex = 5;
		((Control)checkBox24).Text = "Ib";
		((ButtonBase)checkBox24).UseVisualStyleBackColor = true;
		((Control)checkBox25).AutoSize = true;
		((Control)checkBox25).Location = new Point(21, 150);
		((Control)checkBox25).Name = "checkBox25";
		((Control)checkBox25).Size = new Size(36, 16);
		((Control)checkBox25).TabIndex = 6;
		((Control)checkBox25).Text = "Ic";
		((ButtonBase)checkBox25).UseVisualStyleBackColor = true;
		((Control)checkBox26).AutoSize = true;
		((Control)checkBox26).Location = new Point(21, 172);
		((Control)checkBox26).Name = "checkBox26";
		((Control)checkBox26).Size = new Size(36, 16);
		((Control)checkBox26).TabIndex = 7;
		((Control)checkBox26).Text = "IN";
		((ButtonBase)checkBox26).UseVisualStyleBackColor = true;
		((Control)checkBox27).AutoSize = true;
		((Control)checkBox27).Location = new Point(21, 192);
		((Control)checkBox27).Name = "checkBox27";
		((Control)checkBox27).Size = new Size(36, 16);
		((Control)checkBox27).TabIndex = 8;
		((Control)checkBox27).Text = "Pa";
		((ButtonBase)checkBox27).UseVisualStyleBackColor = true;
		((Control)checkBox28).AutoSize = true;
		((Control)checkBox28).Location = new Point(21, 214);
		((Control)checkBox28).Name = "checkBox28";
		((Control)checkBox28).Size = new Size(36, 16);
		((Control)checkBox28).TabIndex = 9;
		((Control)checkBox28).Text = "Pb";
		((ButtonBase)checkBox28).UseVisualStyleBackColor = true;
		((Control)checkBox29).AutoSize = true;
		((Control)checkBox29).Location = new Point(21, 233);
		((Control)checkBox29).Name = "checkBox29";
		((Control)checkBox29).Size = new Size(36, 16);
		((Control)checkBox29).TabIndex = 10;
		((Control)checkBox29).Text = "Pc";
		((ButtonBase)checkBox29).UseVisualStyleBackColor = true;
		((Control)checkBox30).AutoSize = true;
		((Control)checkBox30).Location = new Point(21, 254);
		((Control)checkBox30).Name = "checkBox30";
		((Control)checkBox30).Size = new Size(30, 16);
		((Control)checkBox30).TabIndex = 11;
		((Control)checkBox30).Text = "P";
		((ButtonBase)checkBox30).UseVisualStyleBackColor = true;
		((Control)checkBox31).AutoSize = true;
		((Control)checkBox31).Location = new Point(21, 272);
		((Control)checkBox31).Name = "checkBox31";
		((Control)checkBox31).Size = new Size(36, 16);
		((Control)checkBox31).TabIndex = 12;
		((Control)checkBox31).Text = "Qa";
		((ButtonBase)checkBox31).UseVisualStyleBackColor = true;
		((Control)checkBox32).AutoSize = true;
		((Control)checkBox32).Location = new Point(21, 294);
		((Control)checkBox32).Name = "checkBox32";
		((Control)checkBox32).Size = new Size(36, 16);
		((Control)checkBox32).TabIndex = 13;
		((Control)checkBox32).Text = "Qb";
		((ButtonBase)checkBox32).UseVisualStyleBackColor = true;
		((Control)checkBox33).AutoSize = true;
		((Control)checkBox33).Location = new Point(21, 316);
		((Control)checkBox33).Name = "checkBox33";
		((Control)checkBox33).Size = new Size(36, 16);
		((Control)checkBox33).TabIndex = 14;
		((Control)checkBox33).Text = "Qc";
		((ButtonBase)checkBox33).UseVisualStyleBackColor = true;
		((Control)checkBox34).AutoSize = true;
		((Control)checkBox34).Location = new Point(21, 337);
		((Control)checkBox34).Name = "checkBox34";
		((Control)checkBox34).Size = new Size(30, 16);
		((Control)checkBox34).TabIndex = 15;
		((Control)checkBox34).Text = "Q";
		((ButtonBase)checkBox34).UseVisualStyleBackColor = true;
		((Control)checkBox39).AutoSize = true;
		((Control)checkBox39).Location = new Point(151, 19);
		((Control)checkBox39).Name = "checkBox39";
		((Control)checkBox39).Size = new Size(42, 16);
		((Control)checkBox39).TabIndex = 16;
		((Control)checkBox39).Text = "PFa";
		((ButtonBase)checkBox39).UseVisualStyleBackColor = true;
		((Control)checkBox40).AutoSize = true;
		((Control)checkBox40).Location = new Point(151, 42);
		((Control)checkBox40).Name = "checkBox40";
		((Control)checkBox40).Size = new Size(42, 16);
		((Control)checkBox40).TabIndex = 17;
		((Control)checkBox40).Text = "PFb";
		((ButtonBase)checkBox40).UseVisualStyleBackColor = true;
		((Control)checkBox41).AutoSize = true;
		((Control)checkBox41).Location = new Point(151, 64);
		((Control)checkBox41).Name = "checkBox41";
		((Control)checkBox41).Size = new Size(42, 16);
		((Control)checkBox41).TabIndex = 18;
		((Control)checkBox41).Text = "PFc";
		((ButtonBase)checkBox41).UseVisualStyleBackColor = true;
		((Control)checkBox42).AutoSize = true;
		((Control)checkBox42).Location = new Point(151, 85);
		((Control)checkBox42).Name = "checkBox42";
		((Control)checkBox42).Size = new Size(36, 16);
		((Control)checkBox42).TabIndex = 19;
		((Control)checkBox42).Text = "PF";
		((ButtonBase)checkBox42).UseVisualStyleBackColor = true;
		((Control)checkBox43).AutoSize = true;
		((Control)checkBox43).Location = new Point(151, 109);
		((Control)checkBox43).Name = "checkBox43";
		((Control)checkBox43).Size = new Size(42, 16);
		((Control)checkBox43).TabIndex = 20;
		((Control)checkBox43).Text = "EPI";
		((ButtonBase)checkBox43).UseVisualStyleBackColor = true;
		((Control)checkBox44).AutoSize = true;
		((Control)checkBox44).Location = new Point(151, 129);
		((Control)checkBox44).Name = "checkBox44";
		((Control)checkBox44).Size = new Size(42, 16);
		((Control)checkBox44).TabIndex = 21;
		((Control)checkBox44).Text = "EPE";
		((ButtonBase)checkBox44).UseVisualStyleBackColor = true;
		((Control)checkBox45).AutoSize = true;
		((Control)checkBox45).Location = new Point(151, 150);
		((Control)checkBox45).Name = "checkBox45";
		((Control)checkBox45).Size = new Size(42, 16);
		((Control)checkBox45).TabIndex = 22;
		((Control)checkBox45).Text = "EQL";
		((ButtonBase)checkBox45).UseVisualStyleBackColor = true;
		((Control)checkBox46).AutoSize = true;
		((Control)checkBox46).Location = new Point(151, 171);
		((Control)checkBox46).Name = "checkBox46";
		((Control)checkBox46).Size = new Size(42, 16);
		((Control)checkBox46).TabIndex = 23;
		((Control)checkBox46).Text = "EQC";
		((ButtonBase)checkBox46).UseVisualStyleBackColor = true;
		((Control)checkBox47).AutoSize = true;
		((Control)checkBox47).Location = new Point(151, 191);
		((Control)checkBox47).Name = "checkBox47";
		((Control)checkBox47).Size = new Size(54, 16);
		((Control)checkBox47).TabIndex = 24;
		((Control)checkBox47).Text = "TempA";
		((ButtonBase)checkBox47).UseVisualStyleBackColor = true;
		((Control)checkBox48).AutoSize = true;
		((Control)checkBox48).Location = new Point(151, 213);
		((Control)checkBox48).Name = "checkBox48";
		((Control)checkBox48).Size = new Size(54, 16);
		((Control)checkBox48).TabIndex = 25;
		((Control)checkBox48).Text = "TempB";
		((ButtonBase)checkBox48).UseVisualStyleBackColor = true;
		((Control)checkBox49).AutoSize = true;
		((Control)checkBox49).Location = new Point(151, 232);
		((Control)checkBox49).Name = "checkBox49";
		((Control)checkBox49).Size = new Size(54, 16);
		((Control)checkBox49).TabIndex = 26;
		((Control)checkBox49).Text = "TempC";
		((ButtonBase)checkBox49).UseVisualStyleBackColor = true;
		((Control)checkBox50).AutoSize = true;
		((Control)checkBox50).Location = new Point(151, 253);
		((Control)checkBox50).Name = "checkBox50";
		((Control)checkBox50).Size = new Size(36, 16);
		((Control)checkBox50).TabIndex = 27;
		((Control)checkBox50).Text = "Lg";
		((ButtonBase)checkBox50).UseVisualStyleBackColor = true;
		((Control)checkBox51).AutoSize = true;
		((Control)checkBox51).Location = new Point(151, 272);
		((Control)checkBox51).Name = "checkBox51";
		((Control)checkBox51).Size = new Size(54, 16);
		((Control)checkBox51).TabIndex = 28;
		((Control)checkBox51).Text = "TempN";
		((ButtonBase)checkBox51).UseVisualStyleBackColor = true;
		((Control)checkBox52).AutoSize = true;
		((Control)checkBox52).Location = new Point(151, 294);
		((Control)checkBox52).Name = "checkBox52";
		((Control)checkBox52).Size = new Size(54, 16);
		((Control)checkBox52).TabIndex = 29;
		((Control)checkBox52).Text = "UaTHD";
		((ButtonBase)checkBox52).UseVisualStyleBackColor = true;
		((Control)checkBox53).AutoSize = true;
		((Control)checkBox53).Location = new Point(151, 316);
		((Control)checkBox53).Name = "checkBox53";
		((Control)checkBox53).Size = new Size(54, 16);
		((Control)checkBox53).TabIndex = 30;
		((Control)checkBox53).Text = "UbTHD";
		((ButtonBase)checkBox53).UseVisualStyleBackColor = true;
		((Control)checkBox54).AutoSize = true;
		((Control)checkBox54).Location = new Point(151, 337);
		((Control)checkBox54).Name = "checkBox54";
		((Control)checkBox54).Size = new Size(54, 16);
		((Control)checkBox54).TabIndex = 31;
		((Control)checkBox54).Text = "UcTHD";
		((ButtonBase)checkBox54).UseVisualStyleBackColor = true;
		((Control)checkBox55).AutoSize = true;
		((Control)checkBox55).Location = new Point(265, 19);
		((Control)checkBox55).Name = "checkBox55";
		((Control)checkBox55).Size = new Size(54, 16);
		((Control)checkBox55).TabIndex = 32;
		((Control)checkBox55).Text = "IaTHD";
		((ButtonBase)checkBox55).UseVisualStyleBackColor = true;
		((Control)checkBox56).AutoSize = true;
		((Control)checkBox56).Location = new Point(265, 41);
		((Control)checkBox56).Name = "checkBox56";
		((Control)checkBox56).Size = new Size(54, 16);
		((Control)checkBox56).TabIndex = 33;
		((Control)checkBox56).Text = "IbTHD";
		((ButtonBase)checkBox56).UseVisualStyleBackColor = true;
		((Control)checkBox57).AutoSize = true;
		((Control)checkBox57).Location = new Point(265, 64);
		((Control)checkBox57).Name = "checkBox57";
		((Control)checkBox57).Size = new Size(54, 16);
		((Control)checkBox57).TabIndex = 34;
		((Control)checkBox57).Text = "IcTHD";
		((ButtonBase)checkBox57).UseVisualStyleBackColor = true;
		((Control)checkBox58).AutoSize = true;
		((Control)checkBox58).Location = new Point(265, 86);
		((Control)checkBox58).Name = "checkBox58";
		((Control)checkBox58).Size = new Size(48, 16);
		((Control)checkBox58).TabIndex = 35;
		((Control)checkBox58).Text = "EPED";
		((ButtonBase)checkBox58).UseVisualStyleBackColor = true;
		((Control)checkBox59).AutoSize = true;
		((Control)checkBox59).Location = new Point(265, 108);
		((Control)checkBox59).Name = "checkBox59";
		((Control)checkBox59).Size = new Size(48, 16);
		((Control)checkBox59).TabIndex = 36;
		((Control)checkBox59).Text = "EQLD";
		((ButtonBase)checkBox59).UseVisualStyleBackColor = true;
		((Control)checkBox60).AutoSize = true;
		((Control)checkBox60).Location = new Point(265, 128);
		((Control)checkBox60).Name = "checkBox60";
		((Control)checkBox60).Size = new Size(48, 16);
		((Control)checkBox60).TabIndex = 37;
		((Control)checkBox60).Text = "EQCD";
		((ButtonBase)checkBox60).UseVisualStyleBackColor = true;
		((Control)checkBox61).AutoSize = true;
		((Control)checkBox61).Location = new Point(265, 150);
		((Control)checkBox61).Name = "checkBox61";
		((Control)checkBox61).Size = new Size(42, 16);
		((Control)checkBox61).TabIndex = 38;
		((Control)checkBox61).Text = "Uub";
		((ButtonBase)checkBox61).UseVisualStyleBackColor = true;
		((Control)checkBox62).AutoSize = true;
		((Control)checkBox62).Location = new Point(265, 171);
		((Control)checkBox62).Name = "checkBox62";
		((Control)checkBox62).Size = new Size(42, 16);
		((Control)checkBox62).TabIndex = 39;
		((Control)checkBox62).Text = "Iub";
		((ButtonBase)checkBox62).UseVisualStyleBackColor = true;
		((Control)checkBox63).AutoSize = true;
		((Control)checkBox63).Location = new Point(265, 193);
		((Control)checkBox63).Name = "checkBox63";
		((Control)checkBox63).Size = new Size(42, 16);
		((Control)checkBox63).TabIndex = 40;
		((Control)checkBox63).Text = "EPJ";
		((ButtonBase)checkBox63).UseVisualStyleBackColor = true;
		((Control)checkBox64).AutoSize = true;
		((Control)checkBox64).Location = new Point(265, 213);
		((Control)checkBox64).Name = "checkBox64";
		((Control)checkBox64).Size = new Size(42, 16);
		((Control)checkBox64).TabIndex = 41;
		((Control)checkBox64).Text = "EPF";
		((ButtonBase)checkBox64).UseVisualStyleBackColor = true;
		((Control)checkBox65).AutoSize = true;
		((Control)checkBox65).Location = new Point(265, 232);
		((Control)checkBox65).Name = "checkBox65";
		((Control)checkBox65).Size = new Size(42, 16);
		((Control)checkBox65).TabIndex = 42;
		((Control)checkBox65).Text = "EPP";
		((ButtonBase)checkBox65).UseVisualStyleBackColor = true;
		((Control)checkBox66).AutoSize = true;
		((Control)checkBox66).Location = new Point(265, 254);
		((Control)checkBox66).Name = "checkBox66";
		((Control)checkBox66).Size = new Size(42, 16);
		((Control)checkBox66).TabIndex = 43;
		((Control)checkBox66).Text = "EPG";
		((ButtonBase)checkBox66).UseVisualStyleBackColor = true;
		((Control)checkBox67).AutoSize = true;
		((Control)checkBox67).Location = new Point(265, 272);
		((Control)checkBox67).Name = "checkBox67";
		((Control)checkBox67).Size = new Size(48, 16);
		((Control)checkBox67).TabIndex = 44;
		((Control)checkBox67).Text = "EPIJ";
		((ButtonBase)checkBox67).UseVisualStyleBackColor = true;
		((Control)checkBox68).AutoSize = true;
		((Control)checkBox68).Location = new Point(265, 294);
		((Control)checkBox68).Name = "checkBox68";
		((Control)checkBox68).Size = new Size(48, 16);
		((Control)checkBox68).TabIndex = 45;
		((Control)checkBox68).Text = "EPIF";
		((ButtonBase)checkBox68).UseVisualStyleBackColor = true;
		((Control)checkBox69).AutoSize = true;
		((Control)checkBox69).Location = new Point(265, 316);
		((Control)checkBox69).Name = "checkBox69";
		((Control)checkBox69).Size = new Size(48, 16);
		((Control)checkBox69).TabIndex = 46;
		((Control)checkBox69).Text = "EPIP";
		((ButtonBase)checkBox69).UseVisualStyleBackColor = true;
		((Control)checkBox70).AutoSize = true;
		((Control)checkBox70).Location = new Point(265, 337);
		((Control)checkBox70).Name = "checkBox70";
		((Control)checkBox70).Size = new Size(48, 16);
		((Control)checkBox70).TabIndex = 47;
		((Control)checkBox70).Text = "EPIG";
		((ButtonBase)checkBox70).UseVisualStyleBackColor = true;
		((Control)checkBox71).AutoSize = true;
		((Control)checkBox71).Location = new Point(374, 18);
		((Control)checkBox71).Name = "checkBox71";
		((Control)checkBox71).Size = new Size(48, 16);
		((Control)checkBox71).TabIndex = 48;
		((Control)checkBox71).Text = "EPEJ";
		((ButtonBase)checkBox71).UseVisualStyleBackColor = true;
		((Control)checkBox72).AutoSize = true;
		((Control)checkBox72).Location = new Point(374, 41);
		((Control)checkBox72).Name = "checkBox72";
		((Control)checkBox72).Size = new Size(48, 16);
		((Control)checkBox72).TabIndex = 49;
		((Control)checkBox72).Text = "EPEF";
		((ButtonBase)checkBox72).UseVisualStyleBackColor = true;
		((Control)checkBox73).AutoSize = true;
		((Control)checkBox73).Location = new Point(374, 64);
		((Control)checkBox73).Name = "checkBox73";
		((Control)checkBox73).Size = new Size(48, 16);
		((Control)checkBox73).TabIndex = 50;
		((Control)checkBox73).Text = "EPEP";
		((ButtonBase)checkBox73).UseVisualStyleBackColor = true;
		((Control)checkBox74).AutoSize = true;
		((Control)checkBox74).Location = new Point(374, 85);
		((Control)checkBox74).Name = "checkBox74";
		((Control)checkBox74).Size = new Size(48, 16);
		((Control)checkBox74).TabIndex = 51;
		((Control)checkBox74).Text = "EPEG";
		((ButtonBase)checkBox74).UseVisualStyleBackColor = true;
		((Control)checkBox75).AutoSize = true;
		((Control)checkBox75).Location = new Point(374, 108);
		((Control)checkBox75).Name = "checkBox75";
		((Control)checkBox75).Size = new Size(36, 16);
		((Control)checkBox75).TabIndex = 52;
		((Control)checkBox75).Text = "PT";
		((ButtonBase)checkBox75).UseVisualStyleBackColor = true;
		((Control)checkBox76).AutoSize = true;
		((Control)checkBox76).Location = new Point(374, 128);
		((Control)checkBox76).Name = "checkBox76";
		((Control)checkBox76).Size = new Size(36, 16);
		((Control)checkBox76).TabIndex = 53;
		((Control)checkBox76).Text = "CT";
		((ButtonBase)checkBox76).UseVisualStyleBackColor = true;
		((Control)checkBox77).AutoSize = true;
		((Control)checkBox77).Location = new Point(374, 150);
		((Control)checkBox77).Name = "checkBox77";
		((Control)checkBox77).Size = new Size(48, 16);
		((Control)checkBox77).TabIndex = 54;
		((Control)checkBox77).Text = "EPID";
		((ButtonBase)checkBox77).UseVisualStyleBackColor = true;
		((Control)checkBox78).AutoSize = true;
		((Control)checkBox78).Location = new Point(374, 172);
		((Control)checkBox78).Name = "checkBox78";
		((Control)checkBox78).Size = new Size(36, 16);
		((Control)checkBox78).TabIndex = 55;
		((Control)checkBox78).Text = "Fr";
		((ButtonBase)checkBox78).UseVisualStyleBackColor = true;
		((Control)checkBox79).AutoSize = true;
		((Control)checkBox79).Location = new Point(374, 193);
		((Control)checkBox79).Name = "checkBox79";
		((Control)checkBox79).Size = new Size(36, 16);
		((Control)checkBox79).TabIndex = 56;
		((Control)checkBox79).Text = "Sa";
		((ButtonBase)checkBox79).UseVisualStyleBackColor = true;
		((Control)checkBox80).AutoSize = true;
		((Control)checkBox80).Location = new Point(374, 213);
		((Control)checkBox80).Name = "checkBox80";
		((Control)checkBox80).Size = new Size(36, 16);
		((Control)checkBox80).TabIndex = 57;
		((Control)checkBox80).Text = "Sb";
		((ButtonBase)checkBox80).UseVisualStyleBackColor = true;
		((Control)checkBox81).AutoSize = true;
		((Control)checkBox81).Location = new Point(374, 232);
		((Control)checkBox81).Name = "checkBox81";
		((Control)checkBox81).Size = new Size(36, 16);
		((Control)checkBox81).TabIndex = 58;
		((Control)checkBox81).Text = "Sc";
		((ButtonBase)checkBox81).UseVisualStyleBackColor = true;
		((Control)checkBox82).AutoSize = true;
		((Control)checkBox82).Location = new Point(374, 253);
		((Control)checkBox82).Name = "checkBox82";
		((Control)checkBox82).Size = new Size(30, 16);
		((Control)checkBox82).TabIndex = 59;
		((Control)checkBox82).Text = "S";
		((ButtonBase)checkBox82).UseVisualStyleBackColor = true;
		((Control)checkBox83).AutoSize = true;
		((Control)checkBox83).Location = new Point(374, 272);
		((Control)checkBox83).Name = "checkBox83";
		((Control)checkBox83).Size = new Size(36, 16);
		((Control)checkBox83).TabIndex = 60;
		((Control)checkBox83).Text = "EP";
		((ButtonBase)checkBox83).UseVisualStyleBackColor = true;
		((Control)checkBox84).AutoSize = true;
		((Control)checkBox84).Location = new Point(374, 294);
		((Control)checkBox84).Name = "checkBox84";
		((Control)checkBox84).Size = new Size(42, 16);
		((Control)checkBox84).TabIndex = 61;
		((Control)checkBox84).Text = "Uab";
		((ButtonBase)checkBox84).UseVisualStyleBackColor = true;
		((Control)checkBox85).AutoSize = true;
		((Control)checkBox85).Location = new Point(374, 316);
		((Control)checkBox85).Name = "checkBox85";
		((Control)checkBox85).Size = new Size(42, 16);
		((Control)checkBox85).TabIndex = 62;
		((Control)checkBox85).Text = "Ubc";
		((ButtonBase)checkBox85).UseVisualStyleBackColor = true;
		((Control)checkBox86).AutoSize = true;
		((Control)checkBox86).Location = new Point(374, 337);
		((Control)checkBox86).Name = "checkBox86";
		((Control)checkBox86).Size = new Size(42, 16);
		((Control)checkBox86).TabIndex = 63;
		((Control)checkBox86).Text = "Uca";
		((ButtonBase)checkBox86).UseVisualStyleBackColor = true;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 12f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(788, 386);
		((Control)this).Controls.Add((Control)(object)basic_para);
		((Control)this).Controls.Add((Control)(object)first_pack);
		((Control)this).Name = "zhongtai_basic_set";
		((Control)this).Text = "zhongtai_basic_set";
		((Control)basic_para).ResumeLayout(false);
		((Control)basic_para).PerformLayout();
		((Control)first_pack).ResumeLayout(false);
		((Control)first_pack).PerformLayout();
		((Control)this).ResumeLayout(false);
	}
}
