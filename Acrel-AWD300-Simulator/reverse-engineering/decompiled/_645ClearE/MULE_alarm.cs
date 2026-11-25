using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace _645ClearE;

public class MULE_alarm : Form
{
	private Modbus m = new Modbus();

	private IContainer components = null;

	private CheckedListBox checkedListBox1;

	private GroupBox groupBox1;

	private GroupBox 报警设置;

	private TextBox UCOver_Time;

	private TextBox UCOver_Value;

	private TextBox UBOver_Time;

	private TextBox UBOver_Value;

	private TextBox UAOver_Time;

	private TextBox UAOver_Value;

	private Label label6;

	private Label label5;

	private Label label4;

	private Label label3;

	private Label label2;

	private Label label1;

	private Label label49;

	private Label label50;

	private Label label51;

	private Label label52;

	private Label label53;

	private Label label54;

	private TextBox TCOver_Time;

	private TextBox TCOver_Value;

	private TextBox TBOver_Time;

	private TextBox TBOver_Value;

	private TextBox TAOver_Time;

	private TextBox TAOver_Value;

	private Label label55;

	private Label label56;

	private Label label57;

	private Label label58;

	private Label label59;

	private Label label60;

	private Label label37;

	private Label label38;

	private Label label39;

	private Label label40;

	private Label label41;

	private Label label42;

	private TextBox ICLOW_Time;

	private TextBox ICLOW_Value;

	private TextBox IBLOW_Time;

	private TextBox IBLOW_Value;

	private TextBox IALOW_Time;

	private TextBox IALOW_Value;

	private Label label43;

	private Label label44;

	private Label label45;

	private Label label46;

	private Label label47;

	private Label label48;

	private Label label25;

	private Label label26;

	private Label label27;

	private Label label28;

	private Label label29;

	private Label label30;

	private TextBox ICOver_Time;

	private TextBox ICOver_Value;

	private TextBox IBOver_Time;

	private TextBox IBOver_Value;

	private TextBox IAOver_Time;

	private TextBox IAOver_Value;

	private Label label31;

	private Label label32;

	private Label label33;

	private Label label34;

	private Label label35;

	private Label label36;

	private Label label7;

	private Label label8;

	private Label label9;

	private Label label10;

	private Label label11;

	private Label label18;

	private TextBox UCLOW_Time;

	private TextBox UCLOW_Value;

	private TextBox UBLOW_Time;

	private TextBox UBLOW_Value;

	private TextBox UALOW_Time;

	private TextBox UALOW_Value;

	private Label label19;

	private Label label20;

	private Label label21;

	private Label label22;

	private Label label23;

	private Label label24;

	private Label label17;

	private Label label16;

	private Label label15;

	private Label label14;

	private Label label13;

	private Label label12;

	private GroupBox groupBox3;

	private CheckedListBox checkedListBox2;

	private Button button2;

	private Button button1;

	private CheckBox IBLOW;

	private CheckBox IALOW;

	private CheckBox UCLOW;

	private CheckBox UBLOW;

	private CheckBox UALOW;

	private CheckBox TCOver;

	private CheckBox TBOver;

	private CheckBox TAOver;

	private CheckBox ICOver;

	private CheckBox IBOver;

	private CheckBox IAOver;

	private CheckBox UCOver;

	private CheckBox UBOver;

	private CheckBox UAOver;

	private CheckBox ICLOW;

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

	public MULE_alarm()
	{
		InitializeComponent();
	}

	private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	private void groupBox3_Enter(object sender, EventArgs e)
	{
	}

	private void button1_Click(object sender, EventArgs e)
	{
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0780: Unknown result type (might be due to invalid IL or missing references)
		//IL_0771: Unknown result type (might be due to invalid IL or missing references)
		if (!CheckAddr())
		{
			return;
		}
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[67];
		byte[] CRC = new byte[2];
		ushort num = 0;
		array[0] = Convert.ToByte(Parameters.Address);
		array[1] = 3;
		array[2] = 2;
		array[3] = 18;
		array[4] = 0;
		array[5] = 31;
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
			MessageBox.Show(ex.Message + " 请确定串口及地址设置！");
			return;
		}
		if (m.CheckResponse(response))
		{
			if ((response[4] & 1) == 1)
			{
				UAOver.Checked = true;
			}
			else
			{
				UAOver.Checked = false;
			}
			if ((response[4] & 2) == 2)
			{
				UBOver.Checked = true;
			}
			else
			{
				UBOver.Checked = false;
			}
			if ((response[4] & 4) == 4)
			{
				UCOver.Checked = true;
			}
			else
			{
				UCOver.Checked = false;
			}
			if ((response[4] & 8) == 8)
			{
				IAOver.Checked = true;
			}
			else
			{
				IAOver.Checked = false;
			}
			if ((response[4] & 0x10) == 16)
			{
				IBOver.Checked = true;
			}
			else
			{
				IBOver.Checked = false;
			}
			if ((response[4] & 0x20) == 32)
			{
				ICOver.Checked = true;
			}
			else
			{
				ICOver.Checked = false;
			}
			if ((response[4] & 0x40) == 64)
			{
				TAOver.Checked = true;
			}
			else
			{
				TAOver.Checked = false;
			}
			if ((response[4] & 0x80) == 128)
			{
				TBOver.Checked = true;
			}
			else
			{
				TBOver.Checked = false;
			}
			if ((response[3] & 1) == 1)
			{
				TCOver.Checked = true;
			}
			else
			{
				TCOver.Checked = false;
			}
			if ((response[3] & 2) == 2)
			{
				UALOW.Checked = true;
			}
			else
			{
				UALOW.Checked = false;
			}
			if ((response[3] & 4) == 4)
			{
				UBLOW.Checked = true;
			}
			else
			{
				UBLOW.Checked = false;
			}
			if ((response[3] & 8) == 8)
			{
				UCLOW.Checked = true;
			}
			else
			{
				UCLOW.Checked = false;
			}
			if ((response[3] & 0x10) == 16)
			{
				IALOW.Checked = true;
			}
			else
			{
				IALOW.Checked = false;
			}
			if ((response[3] & 0x20) == 32)
			{
				IBLOW.Checked = true;
			}
			else
			{
				IBLOW.Checked = false;
			}
			if ((response[3] & 0x40) == 64)
			{
				ICLOW.Checked = true;
			}
			else
			{
				ICLOW.Checked = false;
			}
			num = (ushort)((response[5] << 8) | response[6]);
			((Control)UAOver_Value).Text = num.ToString();
			num = (ushort)((response[7] << 8) | response[8]);
			((Control)UAOver_Time).Text = num.ToString();
			num = (ushort)((response[9] << 8) | response[10]);
			((Control)UBOver_Value).Text = num.ToString();
			num = (ushort)((response[11] << 8) | response[12]);
			((Control)UBOver_Time).Text = num.ToString();
			num = (ushort)((response[13] << 8) | response[14]);
			((Control)UCOver_Value).Text = num.ToString();
			num = (ushort)((response[15] << 8) | response[16]);
			((Control)UCOver_Time).Text = num.ToString();
			num = (ushort)((response[17] << 8) | response[18]);
			((Control)IAOver_Value).Text = num.ToString();
			num = (ushort)((response[19] << 8) | response[20]);
			((Control)IAOver_Time).Text = num.ToString();
			num = (ushort)((response[21] << 8) | response[22]);
			((Control)IBOver_Value).Text = num.ToString();
			num = (ushort)((response[23] << 8) | response[24]);
			((Control)IBOver_Time).Text = num.ToString();
			num = (ushort)((response[25] << 8) | response[26]);
			((Control)ICOver_Value).Text = num.ToString();
			num = (ushort)((response[27] << 8) | response[28]);
			((Control)ICOver_Time).Text = num.ToString();
			num = (ushort)((response[29] << 8) | response[30]);
			((Control)TAOver_Value).Text = num.ToString();
			num = (ushort)((response[31] << 8) | response[32]);
			((Control)TAOver_Time).Text = num.ToString();
			num = (ushort)((response[33] << 8) | response[34]);
			((Control)TBOver_Value).Text = num.ToString();
			num = (ushort)((response[35] << 8) | response[36]);
			((Control)TBOver_Time).Text = num.ToString();
			num = (ushort)((response[37] << 8) | response[38]);
			((Control)TCOver_Value).Text = num.ToString();
			num = (ushort)((response[39] << 8) | response[40]);
			((Control)TCOver_Time).Text = num.ToString();
			num = (ushort)((response[41] << 8) | response[42]);
			((Control)UALOW_Value).Text = num.ToString();
			num = (ushort)((response[43] << 8) | response[44]);
			((Control)UALOW_Time).Text = num.ToString();
			num = (ushort)((response[45] << 8) | response[46]);
			((Control)UBLOW_Value).Text = num.ToString();
			num = (ushort)((response[47] << 8) | response[48]);
			((Control)UBLOW_Time).Text = num.ToString();
			num = (ushort)((response[49] << 8) | response[50]);
			((Control)UCLOW_Value).Text = num.ToString();
			num = (ushort)((response[51] << 8) | response[52]);
			((Control)UCLOW_Time).Text = num.ToString();
			num = (ushort)((response[53] << 8) | response[54]);
			((Control)IALOW_Value).Text = num.ToString();
			num = (ushort)((response[55] << 8) | response[56]);
			((Control)IALOW_Time).Text = num.ToString();
			num = (ushort)((response[57] << 8) | response[58]);
			((Control)IBLOW_Value).Text = num.ToString();
			num = (ushort)((response[59] << 8) | response[60]);
			((Control)IBLOW_Time).Text = num.ToString();
			num = (ushort)((response[61] << 8) | response[62]);
			((Control)ICLOW_Value).Text = num.ToString();
			num = (ushort)((response[63] << 8) | response[64]);
			((Control)ICLOW_Time).Text = num.ToString();
			MessageBox.Show("读取成功！");
		}
		else
		{
			MessageBox.Show("没有回复或校验错误！");
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		//IL_07aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_07dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ce: Unknown result type (might be due to invalid IL or missing references)
		byte[] CRC = new byte[2];
		if (CheckAddr())
		{
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array = new byte[71];
			byte[] response = new byte[8];
			array[0] = Convert.ToByte(Parameters.Address);
			array[1] = 16;
			array[2] = 2;
			array[3] = 18;
			array[4] = 0;
			array[5] = 31;
			array[6] = 62;
			if (UAOver.Checked)
			{
				array[8] = (byte)(array[8] | 1);
			}
			if (UBOver.Checked)
			{
				array[8] = (byte)(array[8] | 2);
			}
			if (UCOver.Checked)
			{
				array[8] = (byte)(array[8] | 4);
			}
			if (IAOver.Checked)
			{
				array[8] = (byte)(array[8] | 8);
			}
			if (IBOver.Checked)
			{
				array[8] = (byte)(array[8] | 0x10);
			}
			if (ICOver.Checked)
			{
				array[8] = (byte)(array[8] | 0x20);
			}
			if (TAOver.Checked)
			{
				array[8] = (byte)(array[8] | 0x40);
			}
			if (TBOver.Checked)
			{
				array[8] = (byte)(array[8] | 0x80);
			}
			if (TCOver.Checked)
			{
				array[7] = (byte)(array[7] | 1);
			}
			if (UALOW.Checked)
			{
				array[7] = (byte)(array[7] | 2);
			}
			if (UBLOW.Checked)
			{
				array[7] = (byte)(array[7] | 4);
			}
			if (UCLOW.Checked)
			{
				array[7] = (byte)(array[7] | 8);
			}
			if (IALOW.Checked)
			{
				array[7] = (byte)(array[7] | 0x10);
			}
			if (IBLOW.Checked)
			{
				array[7] = (byte)(array[7] | 0x20);
			}
			if (ICLOW.Checked)
			{
				array[7] = (byte)(array[7] | 0x40);
			}
			array[9] = (byte)(Convert.ToInt32(((Control)UAOver_Value).Text) >> 8);
			array[10] = (byte)Convert.ToInt32(((Control)UAOver_Value).Text);
			array[11] = (byte)(Convert.ToInt32(((Control)UAOver_Time).Text) >> 8);
			array[12] = (byte)Convert.ToInt32(((Control)UAOver_Time).Text);
			array[13] = (byte)(Convert.ToInt32(((Control)UBOver_Value).Text) >> 8);
			array[14] = (byte)Convert.ToInt32(((Control)UBOver_Value).Text);
			array[15] = (byte)(Convert.ToInt32(((Control)UBOver_Time).Text) >> 8);
			array[16] = (byte)Convert.ToInt32(((Control)UBOver_Time).Text);
			array[17] = (byte)(Convert.ToInt32(((Control)UCOver_Value).Text) >> 8);
			array[18] = (byte)Convert.ToInt32(((Control)UCOver_Value).Text);
			array[19] = (byte)(Convert.ToInt32(((Control)UCOver_Time).Text) >> 8);
			array[20] = (byte)Convert.ToInt32(((Control)UCOver_Time).Text);
			array[21] = (byte)(Convert.ToInt32(((Control)IAOver_Value).Text) >> 8);
			array[22] = (byte)Convert.ToInt32(((Control)IAOver_Value).Text);
			array[23] = (byte)(Convert.ToInt32(((Control)IAOver_Time).Text) >> 8);
			array[24] = (byte)Convert.ToInt32(((Control)IAOver_Time).Text);
			array[25] = (byte)(Convert.ToInt32(((Control)IBOver_Value).Text) >> 8);
			array[26] = (byte)Convert.ToInt32(((Control)IBOver_Value).Text);
			array[27] = (byte)(Convert.ToInt32(((Control)IBOver_Time).Text) >> 8);
			array[28] = (byte)Convert.ToInt32(((Control)IBOver_Time).Text);
			array[29] = (byte)(Convert.ToInt32(((Control)ICOver_Value).Text) >> 8);
			array[30] = (byte)Convert.ToInt32(((Control)ICOver_Value).Text);
			array[31] = (byte)(Convert.ToInt32(((Control)ICOver_Time).Text) >> 8);
			array[32] = (byte)Convert.ToInt32(((Control)ICOver_Time).Text);
			array[33] = (byte)(Convert.ToInt32(((Control)TAOver_Value).Text) >> 8);
			array[34] = (byte)Convert.ToInt32(((Control)TAOver_Value).Text);
			array[35] = (byte)(Convert.ToInt32(((Control)TAOver_Time).Text) >> 8);
			array[36] = (byte)Convert.ToInt32(((Control)TAOver_Time).Text);
			array[37] = (byte)(Convert.ToInt32(((Control)TBOver_Value).Text) >> 8);
			array[38] = (byte)Convert.ToInt32(((Control)TBOver_Value).Text);
			array[39] = (byte)(Convert.ToInt32(((Control)TBOver_Time).Text) >> 8);
			array[40] = (byte)Convert.ToInt32(((Control)TBOver_Time).Text);
			array[41] = (byte)(Convert.ToInt32(((Control)TCOver_Value).Text) >> 8);
			array[42] = (byte)Convert.ToInt32(((Control)TCOver_Value).Text);
			array[43] = (byte)Convert.ToInt32(((Control)TCOver_Time).Text);
			array[44] = (byte)Convert.ToInt32(((Control)TCOver_Time).Text);
			array[45] = (byte)(Convert.ToInt32(((Control)UALOW_Value).Text) >> 8);
			array[46] = (byte)Convert.ToInt32(((Control)UALOW_Value).Text);
			array[47] = (byte)(Convert.ToInt32(((Control)UALOW_Time).Text) >> 8);
			array[48] = (byte)Convert.ToInt32(((Control)UALOW_Time).Text);
			array[49] = (byte)(Convert.ToInt32(((Control)UBLOW_Value).Text) >> 8);
			array[50] = (byte)Convert.ToInt32(((Control)UBLOW_Value).Text);
			array[51] = (byte)(Convert.ToInt32(((Control)UBLOW_Time).Text) >> 8);
			array[52] = (byte)Convert.ToInt32(((Control)UBLOW_Time).Text);
			array[53] = (byte)(Convert.ToInt32(((Control)UCLOW_Value).Text) >> 8);
			array[54] = (byte)Convert.ToInt32(((Control)UCLOW_Value).Text);
			array[55] = (byte)(Convert.ToInt32(((Control)UCLOW_Time).Text) >> 8);
			array[56] = (byte)Convert.ToInt32(((Control)UCLOW_Time).Text);
			array[57] = (byte)(Convert.ToInt32(((Control)IALOW_Value).Text) >> 8);
			array[58] = (byte)Convert.ToInt32(((Control)IALOW_Value).Text);
			array[59] = (byte)(Convert.ToInt32(((Control)IALOW_Time).Text) >> 8);
			array[60] = (byte)Convert.ToInt32(((Control)IALOW_Time).Text);
			array[61] = (byte)(Convert.ToInt32(((Control)IBLOW_Value).Text) >> 8);
			array[62] = (byte)Convert.ToInt32(((Control)IBLOW_Value).Text);
			array[63] = (byte)(Convert.ToInt32(((Control)IBLOW_Time).Text) >> 8);
			array[64] = (byte)Convert.ToInt32(((Control)IBLOW_Time).Text);
			array[65] = (byte)(Convert.ToInt32(((Control)ICLOW_Value).Text) >> 8);
			array[66] = (byte)Convert.ToInt32(((Control)ICLOW_Value).Text);
			array[67] = (byte)(Convert.ToInt32(((Control)ICLOW_Time).Text) >> 8);
			array[68] = (byte)Convert.ToInt32(((Control)ICLOW_Time).Text);
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
				MessageBox.Show("设置成功！");
			}
			else
			{
				MessageBox.Show("未能成功设置！");
			}
		}
	}

	private void checkBox14_CheckedChanged(object sender, EventArgs e)
	{
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
		//IL_03a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b3: Expected Obj, but got Unknown
		//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03be: Expected Obj, but got Unknown
		//IL_03bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c9: Expected Obj, but got Unknown
		//IL_03ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d4: Expected Obj, but got Unknown
		//IL_03d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03df: Expected Obj, but got Unknown
		//IL_03e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ea: Expected Obj, but got Unknown
		//IL_03eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f5: Expected Obj, but got Unknown
		//IL_03f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0400: Expected Obj, but got Unknown
		//IL_0401: Unknown result type (might be due to invalid IL or missing references)
		//IL_040b: Expected Obj, but got Unknown
		//IL_040c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0416: Expected Obj, but got Unknown
		//IL_0417: Unknown result type (might be due to invalid IL or missing references)
		//IL_0421: Expected Obj, but got Unknown
		//IL_0422: Unknown result type (might be due to invalid IL or missing references)
		//IL_042c: Expected Obj, but got Unknown
		//IL_042d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0437: Expected Obj, but got Unknown
		//IL_0438: Unknown result type (might be due to invalid IL or missing references)
		//IL_0442: Expected Obj, but got Unknown
		//IL_0443: Unknown result type (might be due to invalid IL or missing references)
		//IL_044d: Expected Obj, but got Unknown
		//IL_044e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0458: Expected Obj, but got Unknown
		//IL_0459: Unknown result type (might be due to invalid IL or missing references)
		//IL_0463: Expected Obj, but got Unknown
		//IL_0464: Unknown result type (might be due to invalid IL or missing references)
		//IL_046e: Expected Obj, but got Unknown
		//IL_046f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0479: Expected Obj, but got Unknown
		//IL_047a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0484: Expected Obj, but got Unknown
		//IL_0485: Unknown result type (might be due to invalid IL or missing references)
		//IL_048f: Expected Obj, but got Unknown
		//IL_0490: Unknown result type (might be due to invalid IL or missing references)
		//IL_049a: Expected Obj, but got Unknown
		//IL_049b: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a5: Expected Obj, but got Unknown
		//IL_04a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b0: Expected Obj, but got Unknown
		//IL_04b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bb: Expected Obj, but got Unknown
		//IL_04bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c6: Expected Obj, but got Unknown
		//IL_04c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d1: Expected Obj, but got Unknown
		//IL_0531: Unknown result type (might be due to invalid IL or missing references)
		//IL_053b: Expected Obj, but got Unknown
		//IL_07ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c4: Expected Obj, but got Unknown
		//IL_10a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_10aa: Expected Obj, but got Unknown
		//IL_113e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1148: Expected Obj, but got Unknown
		//IL_11c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_11d0: Expected Obj, but got Unknown
		//IL_124e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1258: Expected Obj, but got Unknown
		//IL_12d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_12e0: Expected Obj, but got Unknown
		//IL_135e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1368: Expected Obj, but got Unknown
		//IL_13e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_13f3: Expected Obj, but got Unknown
		//IL_1642: Unknown result type (might be due to invalid IL or missing references)
		//IL_164c: Expected Obj, but got Unknown
		//IL_16ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_16d8: Expected Obj, but got Unknown
		//IL_175a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1764: Expected Obj, but got Unknown
		//IL_17e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_17f0: Expected Obj, but got Unknown
		//IL_1872: Unknown result type (might be due to invalid IL or missing references)
		//IL_187c: Expected Obj, but got Unknown
		//IL_1901: Unknown result type (might be due to invalid IL or missing references)
		//IL_190b: Expected Obj, but got Unknown
		//IL_1990: Unknown result type (might be due to invalid IL or missing references)
		//IL_199a: Expected Obj, but got Unknown
		//IL_1a1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a29: Expected Obj, but got Unknown
		//IL_1aae: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ab8: Expected Obj, but got Unknown
		//IL_1b3d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b47: Expected Obj, but got Unknown
		//IL_1bcc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bd6: Expected Obj, but got Unknown
		//IL_1c5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c65: Expected Obj, but got Unknown
		//IL_1ec4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ece: Expected Obj, but got Unknown
		//IL_1f50: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f5a: Expected Obj, but got Unknown
		//IL_1fdc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fe6: Expected Obj, but got Unknown
		//IL_2068: Unknown result type (might be due to invalid IL or missing references)
		//IL_2072: Expected Obj, but got Unknown
		//IL_20f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_20fe: Expected Obj, but got Unknown
		//IL_2180: Unknown result type (might be due to invalid IL or missing references)
		//IL_218a: Expected Obj, but got Unknown
		//IL_220c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2216: Expected Obj, but got Unknown
		//IL_229b: Unknown result type (might be due to invalid IL or missing references)
		//IL_22a5: Expected Obj, but got Unknown
		//IL_232a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2334: Expected Obj, but got Unknown
		//IL_23b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_23c0: Expected Obj, but got Unknown
		//IL_2442: Unknown result type (might be due to invalid IL or missing references)
		//IL_244c: Expected Obj, but got Unknown
		//IL_24ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_24d8: Expected Obj, but got Unknown
		//IL_2728: Unknown result type (might be due to invalid IL or missing references)
		//IL_2732: Expected Obj, but got Unknown
		//IL_27b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_27c1: Expected Obj, but got Unknown
		//IL_2846: Unknown result type (might be due to invalid IL or missing references)
		//IL_2850: Expected Obj, but got Unknown
		//IL_28d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_28dc: Expected Obj, but got Unknown
		//IL_295e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2968: Expected Obj, but got Unknown
		//IL_29ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_29f4: Expected Obj, but got Unknown
		//IL_2a76: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a80: Expected Obj, but got Unknown
		//IL_2b05: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b0f: Expected Obj, but got Unknown
		//IL_2b94: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b9e: Expected Obj, but got Unknown
		//IL_2c23: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c2d: Expected Obj, but got Unknown
		//IL_2cb2: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cbc: Expected Obj, but got Unknown
		//IL_2d41: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d4b: Expected Obj, but got Unknown
		//IL_2faa: Unknown result type (might be due to invalid IL or missing references)
		//IL_2fb4: Expected Obj, but got Unknown
		//IL_3039: Unknown result type (might be due to invalid IL or missing references)
		//IL_3043: Expected Obj, but got Unknown
		//IL_30c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_30d2: Expected Obj, but got Unknown
		//IL_3157: Unknown result type (might be due to invalid IL or missing references)
		//IL_3161: Expected Obj, but got Unknown
		//IL_31e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_31f0: Expected Obj, but got Unknown
		//IL_3275: Unknown result type (might be due to invalid IL or missing references)
		//IL_327f: Expected Obj, but got Unknown
		//IL_3304: Unknown result type (might be due to invalid IL or missing references)
		//IL_330e: Expected Obj, but got Unknown
		//IL_3393: Unknown result type (might be due to invalid IL or missing references)
		//IL_339d: Expected Obj, but got Unknown
		//IL_3422: Unknown result type (might be due to invalid IL or missing references)
		//IL_342c: Expected Obj, but got Unknown
		//IL_34b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_34bb: Expected Obj, but got Unknown
		//IL_3540: Unknown result type (might be due to invalid IL or missing references)
		//IL_354a: Expected Obj, but got Unknown
		//IL_35cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_35d9: Expected Obj, but got Unknown
		//IL_3838: Unknown result type (might be due to invalid IL or missing references)
		//IL_3842: Expected Obj, but got Unknown
		//IL_38c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_38ce: Expected Obj, but got Unknown
		//IL_3950: Unknown result type (might be due to invalid IL or missing references)
		//IL_395a: Expected Obj, but got Unknown
		//IL_39dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_39e6: Expected Obj, but got Unknown
		//IL_3a68: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a72: Expected Obj, but got Unknown
		//IL_3af4: Unknown result type (might be due to invalid IL or missing references)
		//IL_3afe: Expected Obj, but got Unknown
		//IL_3b8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b94: Expected Obj, but got Unknown
		//IL_3c5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c65: Expected Obj, but got Unknown
		//IL_3d7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3d88: Expected Obj, but got Unknown
		//IL_3e36: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e40: Expected Obj, but got Unknown
		//IL_3eea: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ef4: Expected Obj, but got Unknown
		//IL_3f7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f88: Expected Obj, but got Unknown
		//IL_4012: Unknown result type (might be due to invalid IL or missing references)
		//IL_401c: Expected Obj, but got Unknown
		//IL_40a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_40b0: Expected Obj, but got Unknown
		//IL_413a: Unknown result type (might be due to invalid IL or missing references)
		//IL_4144: Expected Obj, but got Unknown
		//IL_41ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_41d8: Expected Obj, but got Unknown
		//IL_4262: Unknown result type (might be due to invalid IL or missing references)
		//IL_426c: Expected Obj, but got Unknown
		//IL_42f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_4303: Expected Obj, but got Unknown
		//IL_4390: Unknown result type (might be due to invalid IL or missing references)
		//IL_439a: Expected Obj, but got Unknown
		//IL_4427: Unknown result type (might be due to invalid IL or missing references)
		//IL_4431: Expected Obj, but got Unknown
		//IL_44bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_44c9: Expected Obj, but got Unknown
		//IL_4557: Unknown result type (might be due to invalid IL or missing references)
		//IL_4561: Expected Obj, but got Unknown
		//IL_45ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_45f9: Expected Obj, but got Unknown
		//IL_4687: Unknown result type (might be due to invalid IL or missing references)
		//IL_4691: Expected Obj, but got Unknown
		//IL_4737: Unknown result type (might be due to invalid IL or missing references)
		//IL_4741: Expected Obj, but got Unknown
		checkedListBox1 = new CheckedListBox();
		groupBox1 = new GroupBox();
		报警设置 = new GroupBox();
		label1 = new Label();
		label2 = new Label();
		label3 = new Label();
		label4 = new Label();
		label5 = new Label();
		label6 = new Label();
		UAOver_Value = new TextBox();
		UAOver_Time = new TextBox();
		UBOver_Value = new TextBox();
		UBOver_Time = new TextBox();
		UCOver_Value = new TextBox();
		UCOver_Time = new TextBox();
		label12 = new Label();
		label13 = new Label();
		label14 = new Label();
		label15 = new Label();
		label16 = new Label();
		label17 = new Label();
		label7 = new Label();
		label8 = new Label();
		label9 = new Label();
		label10 = new Label();
		label11 = new Label();
		label18 = new Label();
		UCLOW_Time = new TextBox();
		UCLOW_Value = new TextBox();
		UBLOW_Time = new TextBox();
		UBLOW_Value = new TextBox();
		UALOW_Time = new TextBox();
		UALOW_Value = new TextBox();
		label19 = new Label();
		label20 = new Label();
		label21 = new Label();
		label22 = new Label();
		label23 = new Label();
		label24 = new Label();
		label25 = new Label();
		label26 = new Label();
		label27 = new Label();
		label28 = new Label();
		label29 = new Label();
		label30 = new Label();
		ICOver_Time = new TextBox();
		ICOver_Value = new TextBox();
		IBOver_Time = new TextBox();
		IBOver_Value = new TextBox();
		IAOver_Time = new TextBox();
		IAOver_Value = new TextBox();
		label31 = new Label();
		label32 = new Label();
		label33 = new Label();
		label34 = new Label();
		label35 = new Label();
		label36 = new Label();
		label37 = new Label();
		label38 = new Label();
		label39 = new Label();
		label40 = new Label();
		label41 = new Label();
		label42 = new Label();
		ICLOW_Time = new TextBox();
		ICLOW_Value = new TextBox();
		IBLOW_Time = new TextBox();
		IBLOW_Value = new TextBox();
		IALOW_Time = new TextBox();
		IALOW_Value = new TextBox();
		label43 = new Label();
		label44 = new Label();
		label45 = new Label();
		label46 = new Label();
		label47 = new Label();
		label48 = new Label();
		label49 = new Label();
		label50 = new Label();
		label51 = new Label();
		label52 = new Label();
		label53 = new Label();
		label54 = new Label();
		TCOver_Time = new TextBox();
		TCOver_Value = new TextBox();
		TBOver_Time = new TextBox();
		TBOver_Value = new TextBox();
		TAOver_Time = new TextBox();
		TAOver_Value = new TextBox();
		label55 = new Label();
		label56 = new Label();
		label57 = new Label();
		label58 = new Label();
		label59 = new Label();
		label60 = new Label();
		groupBox3 = new GroupBox();
		checkedListBox2 = new CheckedListBox();
		button1 = new Button();
		button2 = new Button();
		UAOver = new CheckBox();
		UBOver = new CheckBox();
		UCOver = new CheckBox();
		IAOver = new CheckBox();
		IBOver = new CheckBox();
		ICOver = new CheckBox();
		TAOver = new CheckBox();
		TBOver = new CheckBox();
		TCOver = new CheckBox();
		UALOW = new CheckBox();
		UBLOW = new CheckBox();
		UCLOW = new CheckBox();
		IALOW = new CheckBox();
		IBLOW = new CheckBox();
		ICLOW = new CheckBox();
		((Control)groupBox1).SuspendLayout();
		((Control)报警设置).SuspendLayout();
		((Control)groupBox3).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)checkedListBox1).BackColor = SystemColors.Control;
		((ListBox)checkedListBox1).BorderStyle = (BorderStyle)0;
		((Control)checkedListBox1).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((ObjectCollection)checkedListBox1.Items).AddRange(new object[15]
		{
			"A相电压过高", "B相电压过高", "C相电压过高", "A相电流过高", "B相电流过高", "C相电流过高", "A相温度过高", "B相温度过高", "C相温度过高", "A相电压过低",
			"B相电压过低", "C相电压过低", "A相电流过低", "B相电流过低", "C相电流过低"
		});
		((Control)checkedListBox1).Location = new Point(351, 526);
		((Control)checkedListBox1).Name = "checkedListBox1";
		((Control)checkedListBox1).Size = new Size(97, 270);
		((Control)checkedListBox1).TabIndex = 0;
		((Control)checkedListBox1).Visible = false;
		((ListBox)checkedListBox1).SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
		((Control)groupBox1).Controls.Add((Control)(object)ICLOW);
		((Control)groupBox1).Controls.Add((Control)(object)IBLOW);
		((Control)groupBox1).Controls.Add((Control)(object)IALOW);
		((Control)groupBox1).Controls.Add((Control)(object)UCLOW);
		((Control)groupBox1).Controls.Add((Control)(object)UBLOW);
		((Control)groupBox1).Controls.Add((Control)(object)UALOW);
		((Control)groupBox1).Controls.Add((Control)(object)TCOver);
		((Control)groupBox1).Controls.Add((Control)(object)TBOver);
		((Control)groupBox1).Controls.Add((Control)(object)TAOver);
		((Control)groupBox1).Controls.Add((Control)(object)ICOver);
		((Control)groupBox1).Controls.Add((Control)(object)IBOver);
		((Control)groupBox1).Controls.Add((Control)(object)IAOver);
		((Control)groupBox1).Controls.Add((Control)(object)UCOver);
		((Control)groupBox1).Controls.Add((Control)(object)UBOver);
		((Control)groupBox1).Controls.Add((Control)(object)UAOver);
		((Control)groupBox1).Font = new Font("微软雅黑", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)134);
		((Control)groupBox1).Location = new Point(22, 12);
		((Control)groupBox1).Name = "groupBox1";
		((Control)groupBox1).Size = new Size(117, 331);
		((Control)groupBox1).TabIndex = 1;
		groupBox1.TabStop = false;
		((Control)groupBox1).Text = "报警允许位";
		((Control)报警设置).Controls.Add((Control)(object)checkedListBox1);
		((Control)报警设置).Controls.Add((Control)(object)button2);
		((Control)报警设置).Controls.Add((Control)(object)button1);
		((Control)报警设置).Controls.Add((Control)(object)label49);
		((Control)报警设置).Controls.Add((Control)(object)label50);
		((Control)报警设置).Controls.Add((Control)(object)label51);
		((Control)报警设置).Controls.Add((Control)(object)label52);
		((Control)报警设置).Controls.Add((Control)(object)label53);
		((Control)报警设置).Controls.Add((Control)(object)label54);
		((Control)报警设置).Controls.Add((Control)(object)TCOver_Time);
		((Control)报警设置).Controls.Add((Control)(object)TCOver_Value);
		((Control)报警设置).Controls.Add((Control)(object)TBOver_Time);
		((Control)报警设置).Controls.Add((Control)(object)TBOver_Value);
		((Control)报警设置).Controls.Add((Control)(object)TAOver_Time);
		((Control)报警设置).Controls.Add((Control)(object)TAOver_Value);
		((Control)报警设置).Controls.Add((Control)(object)label55);
		((Control)报警设置).Controls.Add((Control)(object)label56);
		((Control)报警设置).Controls.Add((Control)(object)label57);
		((Control)报警设置).Controls.Add((Control)(object)label58);
		((Control)报警设置).Controls.Add((Control)(object)label59);
		((Control)报警设置).Controls.Add((Control)(object)label60);
		((Control)报警设置).Controls.Add((Control)(object)label37);
		((Control)报警设置).Controls.Add((Control)(object)label38);
		((Control)报警设置).Controls.Add((Control)(object)label39);
		((Control)报警设置).Controls.Add((Control)(object)label40);
		((Control)报警设置).Controls.Add((Control)(object)label41);
		((Control)报警设置).Controls.Add((Control)(object)label42);
		((Control)报警设置).Controls.Add((Control)(object)ICLOW_Time);
		((Control)报警设置).Controls.Add((Control)(object)ICLOW_Value);
		((Control)报警设置).Controls.Add((Control)(object)IBLOW_Time);
		((Control)报警设置).Controls.Add((Control)(object)IBLOW_Value);
		((Control)报警设置).Controls.Add((Control)(object)IALOW_Time);
		((Control)报警设置).Controls.Add((Control)(object)IALOW_Value);
		((Control)报警设置).Controls.Add((Control)(object)label43);
		((Control)报警设置).Controls.Add((Control)(object)label44);
		((Control)报警设置).Controls.Add((Control)(object)label45);
		((Control)报警设置).Controls.Add((Control)(object)label46);
		((Control)报警设置).Controls.Add((Control)(object)label47);
		((Control)报警设置).Controls.Add((Control)(object)label48);
		((Control)报警设置).Controls.Add((Control)(object)label25);
		((Control)报警设置).Controls.Add((Control)(object)label26);
		((Control)报警设置).Controls.Add((Control)(object)label27);
		((Control)报警设置).Controls.Add((Control)(object)label28);
		((Control)报警设置).Controls.Add((Control)(object)label29);
		((Control)报警设置).Controls.Add((Control)(object)label30);
		((Control)报警设置).Controls.Add((Control)(object)ICOver_Time);
		((Control)报警设置).Controls.Add((Control)(object)ICOver_Value);
		((Control)报警设置).Controls.Add((Control)(object)IBOver_Time);
		((Control)报警设置).Controls.Add((Control)(object)IBOver_Value);
		((Control)报警设置).Controls.Add((Control)(object)IAOver_Time);
		((Control)报警设置).Controls.Add((Control)(object)IAOver_Value);
		((Control)报警设置).Controls.Add((Control)(object)label31);
		((Control)报警设置).Controls.Add((Control)(object)label32);
		((Control)报警设置).Controls.Add((Control)(object)label33);
		((Control)报警设置).Controls.Add((Control)(object)label34);
		((Control)报警设置).Controls.Add((Control)(object)label35);
		((Control)报警设置).Controls.Add((Control)(object)label36);
		((Control)报警设置).Controls.Add((Control)(object)label7);
		((Control)报警设置).Controls.Add((Control)(object)label8);
		((Control)报警设置).Controls.Add((Control)(object)label9);
		((Control)报警设置).Controls.Add((Control)(object)label10);
		((Control)报警设置).Controls.Add((Control)(object)label11);
		((Control)报警设置).Controls.Add((Control)(object)label18);
		((Control)报警设置).Controls.Add((Control)(object)UCLOW_Time);
		((Control)报警设置).Controls.Add((Control)(object)UCLOW_Value);
		((Control)报警设置).Controls.Add((Control)(object)UBLOW_Time);
		((Control)报警设置).Controls.Add((Control)(object)UBLOW_Value);
		((Control)报警设置).Controls.Add((Control)(object)UALOW_Time);
		((Control)报警设置).Controls.Add((Control)(object)UALOW_Value);
		((Control)报警设置).Controls.Add((Control)(object)label19);
		((Control)报警设置).Controls.Add((Control)(object)label20);
		((Control)报警设置).Controls.Add((Control)(object)label21);
		((Control)报警设置).Controls.Add((Control)(object)label22);
		((Control)报警设置).Controls.Add((Control)(object)label23);
		((Control)报警设置).Controls.Add((Control)(object)label24);
		((Control)报警设置).Controls.Add((Control)(object)label17);
		((Control)报警设置).Controls.Add((Control)(object)label16);
		((Control)报警设置).Controls.Add((Control)(object)label15);
		((Control)报警设置).Controls.Add((Control)(object)label14);
		((Control)报警设置).Controls.Add((Control)(object)label13);
		((Control)报警设置).Controls.Add((Control)(object)label12);
		((Control)报警设置).Controls.Add((Control)(object)UCOver_Time);
		((Control)报警设置).Controls.Add((Control)(object)UCOver_Value);
		((Control)报警设置).Controls.Add((Control)(object)UBOver_Time);
		((Control)报警设置).Controls.Add((Control)(object)UBOver_Value);
		((Control)报警设置).Controls.Add((Control)(object)UAOver_Time);
		((Control)报警设置).Controls.Add((Control)(object)UAOver_Value);
		((Control)报警设置).Controls.Add((Control)(object)label6);
		((Control)报警设置).Controls.Add((Control)(object)label5);
		((Control)报警设置).Controls.Add((Control)(object)label4);
		((Control)报警设置).Controls.Add((Control)(object)label3);
		((Control)报警设置).Controls.Add((Control)(object)label2);
		((Control)报警设置).Controls.Add((Control)(object)label1);
		((Control)报警设置).Font = new Font("微软雅黑", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)134);
		((Control)报警设置).Location = new Point(168, 12);
		((Control)报警设置).Name = "报警设置";
		((Control)报警设置).Size = new Size(632, 604);
		((Control)报警设置).TabIndex = 2;
		报警设置.TabStop = false;
		((Control)报警设置).Text = "报警设置";
		((Control)label1).AutoSize = true;
		((Control)label1).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label1).Location = new Point(21, 33);
		((Control)label1).Name = "label1";
		((Control)label1).Size = new Size(100, 17);
		((Control)label1).TabIndex = 0;
		((Control)label1).Text = "A相电压过高阈值";
		((Control)label2).AutoSize = true;
		((Control)label2).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label2).Location = new Point(21, 60);
		((Control)label2).Name = "label2";
		((Control)label2).Size = new Size(124, 17);
		((Control)label2).TabIndex = 1;
		((Control)label2).Text = "A相电压过高报警延时";
		((Control)label3).AutoSize = true;
		((Control)label3).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label3).Location = new Point(21, 87);
		((Control)label3).Name = "label3";
		((Control)label3).Size = new Size(100, 17);
		((Control)label3).TabIndex = 2;
		((Control)label3).Text = "B相电压过高阈值";
		((Control)label4).AutoSize = true;
		((Control)label4).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label4).Location = new Point(21, 114);
		((Control)label4).Name = "label4";
		((Control)label4).Size = new Size(124, 17);
		((Control)label4).TabIndex = 3;
		((Control)label4).Text = "B相电压过高报警延时";
		((Control)label5).AutoSize = true;
		((Control)label5).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label5).Location = new Point(21, 141);
		((Control)label5).Name = "label5";
		((Control)label5).Size = new Size(100, 17);
		((Control)label5).TabIndex = 4;
		((Control)label5).Text = "C相电压过高阈值";
		((Control)label6).AutoSize = true;
		((Control)label6).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label6).Location = new Point(21, 168);
		((Control)label6).Name = "label6";
		((Control)label6).Size = new Size(124, 17);
		((Control)label6).TabIndex = 5;
		((Control)label6).Text = "C相电压过高报警延时";
		((Control)UAOver_Value).Location = new Point(145, 31);
		((Control)UAOver_Value).Name = "UAOver_Value";
		((Control)UAOver_Value).Size = new Size(100, 23);
		((Control)UAOver_Value).TabIndex = 11;
		((Control)UAOver_Time).Location = new Point(145, 58);
		((Control)UAOver_Time).Name = "UAOver_Time";
		((Control)UAOver_Time).Size = new Size(100, 23);
		((Control)UAOver_Time).TabIndex = 12;
		((Control)UBOver_Value).Location = new Point(145, 85);
		((Control)UBOver_Value).Name = "UBOver_Value";
		((Control)UBOver_Value).Size = new Size(100, 23);
		((Control)UBOver_Value).TabIndex = 13;
		((Control)UBOver_Time).Location = new Point(145, 112);
		((Control)UBOver_Time).Name = "UBOver_Time";
		((Control)UBOver_Time).Size = new Size(100, 23);
		((Control)UBOver_Time).TabIndex = 14;
		((Control)UCOver_Value).Location = new Point(145, 139);
		((Control)UCOver_Value).Name = "UCOver_Value";
		((Control)UCOver_Value).Size = new Size(100, 23);
		((Control)UCOver_Value).TabIndex = 15;
		((Control)UCOver_Time).Location = new Point(145, 166);
		((Control)UCOver_Time).Name = "UCOver_Time";
		((Control)UCOver_Time).Size = new Size(100, 23);
		((Control)UCOver_Time).TabIndex = 16;
		((Control)label12).AutoSize = true;
		((Control)label12).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label12).Location = new Point(251, 33);
		((Control)label12).Name = "label12";
		((Control)label12).Size = new Size(33, 17);
		((Control)label12).TabIndex = 17;
		((Control)label12).Text = "0.1V";
		((Control)label13).AutoSize = true;
		((Control)label13).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label13).Location = new Point(251, 60);
		((Control)label13).Name = "label13";
		((Control)label13).Size = new Size(39, 17);
		((Control)label13).TabIndex = 18;
		((Control)label13).Text = "0.01S";
		((Control)label14).AutoSize = true;
		((Control)label14).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label14).Location = new Point(251, 87);
		((Control)label14).Name = "label14";
		((Control)label14).Size = new Size(33, 17);
		((Control)label14).TabIndex = 19;
		((Control)label14).Text = "0.1V";
		((Control)label15).AutoSize = true;
		((Control)label15).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label15).Location = new Point(251, 114);
		((Control)label15).Name = "label15";
		((Control)label15).Size = new Size(39, 17);
		((Control)label15).TabIndex = 20;
		((Control)label15).Text = "0.01S";
		((Control)label16).AutoSize = true;
		((Control)label16).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label16).Location = new Point(251, 141);
		((Control)label16).Name = "label16";
		((Control)label16).Size = new Size(33, 17);
		((Control)label16).TabIndex = 21;
		((Control)label16).Text = "0.1V";
		((Control)label17).AutoSize = true;
		((Control)label17).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label17).Location = new Point(251, 168);
		((Control)label17).Name = "label17";
		((Control)label17).Size = new Size(39, 17);
		((Control)label17).TabIndex = 22;
		((Control)label17).Text = "0.01S";
		((Control)label7).AutoSize = true;
		((Control)label7).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label7).Location = new Point(251, 341);
		((Control)label7).Name = "label7";
		((Control)label7).Size = new Size(39, 17);
		((Control)label7).TabIndex = 40;
		((Control)label7).Text = "0.01S";
		((Control)label8).AutoSize = true;
		((Control)label8).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label8).Location = new Point(251, 314);
		((Control)label8).Name = "label8";
		((Control)label8).Size = new Size(33, 17);
		((Control)label8).TabIndex = 39;
		((Control)label8).Text = "0.1V";
		((Control)label9).AutoSize = true;
		((Control)label9).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label9).Location = new Point(251, 287);
		((Control)label9).Name = "label9";
		((Control)label9).Size = new Size(39, 17);
		((Control)label9).TabIndex = 38;
		((Control)label9).Text = "0.01S";
		((Control)label10).AutoSize = true;
		((Control)label10).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label10).Location = new Point(251, 260);
		((Control)label10).Name = "label10";
		((Control)label10).Size = new Size(33, 17);
		((Control)label10).TabIndex = 37;
		((Control)label10).Text = "0.1V";
		((Control)label11).AutoSize = true;
		((Control)label11).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label11).Location = new Point(251, 233);
		((Control)label11).Name = "label11";
		((Control)label11).Size = new Size(39, 17);
		((Control)label11).TabIndex = 36;
		((Control)label11).Text = "0.01S";
		((Control)label18).AutoSize = true;
		((Control)label18).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label18).Location = new Point(251, 206);
		((Control)label18).Name = "label18";
		((Control)label18).Size = new Size(33, 17);
		((Control)label18).TabIndex = 35;
		((Control)label18).Text = "0.1V";
		((Control)UCLOW_Time).Location = new Point(145, 339);
		((Control)UCLOW_Time).Name = "UCLOW_Time";
		((Control)UCLOW_Time).Size = new Size(100, 23);
		((Control)UCLOW_Time).TabIndex = 34;
		((Control)UCLOW_Value).Location = new Point(145, 312);
		((Control)UCLOW_Value).Name = "UCLOW_Value";
		((Control)UCLOW_Value).Size = new Size(100, 23);
		((Control)UCLOW_Value).TabIndex = 33;
		((Control)UBLOW_Time).Location = new Point(145, 285);
		((Control)UBLOW_Time).Name = "UBLOW_Time";
		((Control)UBLOW_Time).Size = new Size(100, 23);
		((Control)UBLOW_Time).TabIndex = 32;
		((Control)UBLOW_Value).Location = new Point(145, 258);
		((Control)UBLOW_Value).Name = "UBLOW_Value";
		((Control)UBLOW_Value).Size = new Size(100, 23);
		((Control)UBLOW_Value).TabIndex = 31;
		((Control)UALOW_Time).Location = new Point(145, 231);
		((Control)UALOW_Time).Name = "UALOW_Time";
		((Control)UALOW_Time).Size = new Size(100, 23);
		((Control)UALOW_Time).TabIndex = 30;
		((Control)UALOW_Value).Location = new Point(145, 204);
		((Control)UALOW_Value).Name = "UALOW_Value";
		((Control)UALOW_Value).Size = new Size(100, 23);
		((Control)UALOW_Value).TabIndex = 29;
		((Control)label19).AutoSize = true;
		((Control)label19).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label19).Location = new Point(21, 342);
		((Control)label19).Name = "label19";
		((Control)label19).Size = new Size(124, 17);
		((Control)label19).TabIndex = 28;
		((Control)label19).Text = "C相电压过低报警延时";
		((Control)label20).AutoSize = true;
		((Control)label20).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label20).Location = new Point(21, 315);
		((Control)label20).Name = "label20";
		((Control)label20).Size = new Size(100, 17);
		((Control)label20).TabIndex = 27;
		((Control)label20).Text = "C相电压过低阈值";
		((Control)label21).AutoSize = true;
		((Control)label21).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label21).Location = new Point(21, 288);
		((Control)label21).Name = "label21";
		((Control)label21).Size = new Size(124, 17);
		((Control)label21).TabIndex = 26;
		((Control)label21).Text = "B相电压过低报警延时";
		((Control)label22).AutoSize = true;
		((Control)label22).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label22).Location = new Point(21, 261);
		((Control)label22).Name = "label22";
		((Control)label22).Size = new Size(100, 17);
		((Control)label22).TabIndex = 25;
		((Control)label22).Text = "B相电压过低阈值";
		((Control)label23).AutoSize = true;
		((Control)label23).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label23).Location = new Point(21, 234);
		((Control)label23).Name = "label23";
		((Control)label23).Size = new Size(124, 17);
		((Control)label23).TabIndex = 24;
		((Control)label23).Text = "A相电压过低报警延时";
		((Control)label24).AutoSize = true;
		((Control)label24).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label24).Location = new Point(21, 207);
		((Control)label24).Name = "label24";
		((Control)label24).Size = new Size(100, 17);
		((Control)label24).TabIndex = 23;
		((Control)label24).Text = "A相电压过低阈值";
		((Control)label25).AutoSize = true;
		((Control)label25).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label25).Location = new Point(539, 168);
		((Control)label25).Name = "label25";
		((Control)label25).Size = new Size(39, 17);
		((Control)label25).TabIndex = 58;
		((Control)label25).Text = "0.01S";
		((Control)label26).AutoSize = true;
		((Control)label26).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label26).Location = new Point(539, 141);
		((Control)label26).Name = "label26";
		((Control)label26).Size = new Size(40, 17);
		((Control)label26).TabIndex = 57;
		((Control)label26).Text = "0.01A";
		((Control)label27).AutoSize = true;
		((Control)label27).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label27).Location = new Point(539, 114);
		((Control)label27).Name = "label27";
		((Control)label27).Size = new Size(39, 17);
		((Control)label27).TabIndex = 56;
		((Control)label27).Text = "0.01S";
		((Control)label28).AutoSize = true;
		((Control)label28).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label28).Location = new Point(539, 87);
		((Control)label28).Name = "label28";
		((Control)label28).Size = new Size(40, 17);
		((Control)label28).TabIndex = 55;
		((Control)label28).Text = "0.01A";
		((Control)label29).AutoSize = true;
		((Control)label29).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label29).Location = new Point(539, 60);
		((Control)label29).Name = "label29";
		((Control)label29).Size = new Size(39, 17);
		((Control)label29).TabIndex = 54;
		((Control)label29).Text = "0.01S";
		((Control)label30).AutoSize = true;
		((Control)label30).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label30).Location = new Point(539, 33);
		((Control)label30).Name = "label30";
		((Control)label30).Size = new Size(40, 17);
		((Control)label30).TabIndex = 53;
		((Control)label30).Text = "0.01A";
		((Control)ICOver_Time).Location = new Point(433, 166);
		((Control)ICOver_Time).Name = "ICOver_Time";
		((Control)ICOver_Time).Size = new Size(100, 23);
		((Control)ICOver_Time).TabIndex = 52;
		((Control)ICOver_Value).Location = new Point(433, 139);
		((Control)ICOver_Value).Name = "ICOver_Value";
		((Control)ICOver_Value).Size = new Size(100, 23);
		((Control)ICOver_Value).TabIndex = 51;
		((Control)IBOver_Time).Location = new Point(433, 112);
		((Control)IBOver_Time).Name = "IBOver_Time";
		((Control)IBOver_Time).Size = new Size(100, 23);
		((Control)IBOver_Time).TabIndex = 50;
		((Control)IBOver_Value).Location = new Point(433, 85);
		((Control)IBOver_Value).Name = "IBOver_Value";
		((Control)IBOver_Value).Size = new Size(100, 23);
		((Control)IBOver_Value).TabIndex = 49;
		((Control)IAOver_Time).Location = new Point(433, 58);
		((Control)IAOver_Time).Name = "IAOver_Time";
		((Control)IAOver_Time).Size = new Size(100, 23);
		((Control)IAOver_Time).TabIndex = 48;
		((Control)IAOver_Value).Location = new Point(433, 31);
		((Control)IAOver_Value).Name = "IAOver_Value";
		((Control)IAOver_Value).Size = new Size(100, 23);
		((Control)IAOver_Value).TabIndex = 47;
		((Control)label31).AutoSize = true;
		((Control)label31).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label31).Location = new Point(308, 168);
		((Control)label31).Name = "label31";
		((Control)label31).Size = new Size(124, 17);
		((Control)label31).TabIndex = 46;
		((Control)label31).Text = "C相电流过高报警延时";
		((Control)label32).AutoSize = true;
		((Control)label32).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label32).Location = new Point(308, 141);
		((Control)label32).Name = "label32";
		((Control)label32).Size = new Size(100, 17);
		((Control)label32).TabIndex = 45;
		((Control)label32).Text = "C相电流过高阈值";
		((Control)label33).AutoSize = true;
		((Control)label33).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label33).Location = new Point(308, 114);
		((Control)label33).Name = "label33";
		((Control)label33).Size = new Size(124, 17);
		((Control)label33).TabIndex = 44;
		((Control)label33).Text = "B相电流过高报警延时";
		((Control)label34).AutoSize = true;
		((Control)label34).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label34).Location = new Point(308, 87);
		((Control)label34).Name = "label34";
		((Control)label34).Size = new Size(100, 17);
		((Control)label34).TabIndex = 43;
		((Control)label34).Text = "B相电流过高阈值";
		((Control)label35).AutoSize = true;
		((Control)label35).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label35).Location = new Point(308, 60);
		((Control)label35).Name = "label35";
		((Control)label35).Size = new Size(124, 17);
		((Control)label35).TabIndex = 42;
		((Control)label35).Text = "A相电流过高报警延时";
		((Control)label36).AutoSize = true;
		((Control)label36).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label36).Location = new Point(308, 33);
		((Control)label36).Name = "label36";
		((Control)label36).Size = new Size(100, 17);
		((Control)label36).TabIndex = 41;
		((Control)label36).Text = "A相电流过高阈值";
		((Control)label37).AutoSize = true;
		((Control)label37).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label37).Location = new Point(539, 341);
		((Control)label37).Name = "label37";
		((Control)label37).Size = new Size(39, 17);
		((Control)label37).TabIndex = 76;
		((Control)label37).Text = "0.01S";
		((Control)label38).AutoSize = true;
		((Control)label38).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label38).Location = new Point(539, 314);
		((Control)label38).Name = "label38";
		((Control)label38).Size = new Size(40, 17);
		((Control)label38).TabIndex = 75;
		((Control)label38).Text = "0.01A";
		((Control)label39).AutoSize = true;
		((Control)label39).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label39).Location = new Point(539, 287);
		((Control)label39).Name = "label39";
		((Control)label39).Size = new Size(39, 17);
		((Control)label39).TabIndex = 74;
		((Control)label39).Text = "0.01S";
		((Control)label40).AutoSize = true;
		((Control)label40).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label40).Location = new Point(539, 260);
		((Control)label40).Name = "label40";
		((Control)label40).Size = new Size(40, 17);
		((Control)label40).TabIndex = 73;
		((Control)label40).Text = "0.01A";
		((Control)label41).AutoSize = true;
		((Control)label41).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label41).Location = new Point(539, 233);
		((Control)label41).Name = "label41";
		((Control)label41).Size = new Size(39, 17);
		((Control)label41).TabIndex = 72;
		((Control)label41).Text = "0.01S";
		((Control)label42).AutoSize = true;
		((Control)label42).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label42).Location = new Point(539, 206);
		((Control)label42).Name = "label42";
		((Control)label42).Size = new Size(40, 17);
		((Control)label42).TabIndex = 71;
		((Control)label42).Text = "0.01A";
		((Control)ICLOW_Time).Location = new Point(433, 339);
		((Control)ICLOW_Time).Name = "ICLOW_Time";
		((Control)ICLOW_Time).Size = new Size(100, 23);
		((Control)ICLOW_Time).TabIndex = 70;
		((Control)ICLOW_Value).Location = new Point(433, 312);
		((Control)ICLOW_Value).Name = "ICLOW_Value";
		((Control)ICLOW_Value).Size = new Size(100, 23);
		((Control)ICLOW_Value).TabIndex = 69;
		((Control)IBLOW_Time).Location = new Point(433, 285);
		((Control)IBLOW_Time).Name = "IBLOW_Time";
		((Control)IBLOW_Time).Size = new Size(100, 23);
		((Control)IBLOW_Time).TabIndex = 68;
		((Control)IBLOW_Value).Location = new Point(433, 258);
		((Control)IBLOW_Value).Name = "IBLOW_Value";
		((Control)IBLOW_Value).Size = new Size(100, 23);
		((Control)IBLOW_Value).TabIndex = 67;
		((Control)IALOW_Time).Location = new Point(433, 231);
		((Control)IALOW_Time).Name = "IALOW_Time";
		((Control)IALOW_Time).Size = new Size(100, 23);
		((Control)IALOW_Time).TabIndex = 66;
		((Control)IALOW_Value).Location = new Point(433, 204);
		((Control)IALOW_Value).Name = "IALOW_Value";
		((Control)IALOW_Value).Size = new Size(100, 23);
		((Control)IALOW_Value).TabIndex = 65;
		((Control)label43).AutoSize = true;
		((Control)label43).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label43).Location = new Point(308, 342);
		((Control)label43).Name = "label43";
		((Control)label43).Size = new Size(124, 17);
		((Control)label43).TabIndex = 64;
		((Control)label43).Text = "C相电流过低报警延时";
		((Control)label44).AutoSize = true;
		((Control)label44).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label44).Location = new Point(308, 315);
		((Control)label44).Name = "label44";
		((Control)label44).Size = new Size(100, 17);
		((Control)label44).TabIndex = 63;
		((Control)label44).Text = "C相电流过低阈值";
		((Control)label45).AutoSize = true;
		((Control)label45).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label45).Location = new Point(308, 288);
		((Control)label45).Name = "label45";
		((Control)label45).Size = new Size(124, 17);
		((Control)label45).TabIndex = 62;
		((Control)label45).Text = "B相电流过低报警延时";
		((Control)label46).AutoSize = true;
		((Control)label46).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label46).Location = new Point(308, 261);
		((Control)label46).Name = "label46";
		((Control)label46).Size = new Size(100, 17);
		((Control)label46).TabIndex = 61;
		((Control)label46).Text = "B相电流过低阈值";
		((Control)label47).AutoSize = true;
		((Control)label47).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label47).Location = new Point(308, 234);
		((Control)label47).Name = "label47";
		((Control)label47).Size = new Size(124, 17);
		((Control)label47).TabIndex = 60;
		((Control)label47).Text = "A相电流过低报警延时";
		((Control)label48).AutoSize = true;
		((Control)label48).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label48).Location = new Point(308, 207);
		((Control)label48).Name = "label48";
		((Control)label48).Size = new Size(100, 17);
		((Control)label48).TabIndex = 59;
		((Control)label48).Text = "A相电流过低阈值";
		((Control)label49).AutoSize = true;
		((Control)label49).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label49).Location = new Point(251, 528);
		((Control)label49).Name = "label49";
		((Control)label49).Size = new Size(39, 17);
		((Control)label49).TabIndex = 94;
		((Control)label49).Text = "0.01S";
		((Control)label50).AutoSize = true;
		((Control)label50).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label50).Location = new Point(251, 501);
		((Control)label50).Name = "label50";
		((Control)label50).Size = new Size(44, 17);
		((Control)label50).TabIndex = 93;
		((Control)label50).Text = "0.01℃";
		((Control)label51).AutoSize = true;
		((Control)label51).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label51).Location = new Point(251, 474);
		((Control)label51).Name = "label51";
		((Control)label51).Size = new Size(39, 17);
		((Control)label51).TabIndex = 92;
		((Control)label51).Text = "0.01S";
		((Control)label52).AutoSize = true;
		((Control)label52).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label52).Location = new Point(251, 447);
		((Control)label52).Name = "label52";
		((Control)label52).Size = new Size(44, 17);
		((Control)label52).TabIndex = 91;
		((Control)label52).Text = "0.01℃";
		((Control)label53).AutoSize = true;
		((Control)label53).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label53).Location = new Point(251, 420);
		((Control)label53).Name = "label53";
		((Control)label53).Size = new Size(39, 17);
		((Control)label53).TabIndex = 90;
		((Control)label53).Text = "0.01S";
		((Control)label54).AutoSize = true;
		((Control)label54).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label54).Location = new Point(251, 393);
		((Control)label54).Name = "label54";
		((Control)label54).Size = new Size(44, 17);
		((Control)label54).TabIndex = 89;
		((Control)label54).Text = "0.01℃";
		((Control)TCOver_Time).Location = new Point(145, 526);
		((Control)TCOver_Time).Name = "TCOver_Time";
		((Control)TCOver_Time).Size = new Size(100, 23);
		((Control)TCOver_Time).TabIndex = 88;
		((Control)TCOver_Value).Location = new Point(145, 499);
		((Control)TCOver_Value).Name = "TCOver_Value";
		((Control)TCOver_Value).Size = new Size(100, 23);
		((Control)TCOver_Value).TabIndex = 87;
		((Control)TBOver_Time).Location = new Point(145, 472);
		((Control)TBOver_Time).Name = "TBOver_Time";
		((Control)TBOver_Time).Size = new Size(100, 23);
		((Control)TBOver_Time).TabIndex = 86;
		((Control)TBOver_Value).Location = new Point(145, 445);
		((Control)TBOver_Value).Name = "TBOver_Value";
		((Control)TBOver_Value).Size = new Size(100, 23);
		((Control)TBOver_Value).TabIndex = 85;
		((Control)TAOver_Time).Location = new Point(145, 418);
		((Control)TAOver_Time).Name = "TAOver_Time";
		((Control)TAOver_Time).Size = new Size(100, 23);
		((Control)TAOver_Time).TabIndex = 84;
		((Control)TAOver_Value).Location = new Point(145, 391);
		((Control)TAOver_Value).Name = "TAOver_Value";
		((Control)TAOver_Value).Size = new Size(100, 23);
		((Control)TAOver_Value).TabIndex = 83;
		((Control)label55).AutoSize = true;
		((Control)label55).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label55).Location = new Point(21, 529);
		((Control)label55).Name = "label55";
		((Control)label55).Size = new Size(124, 17);
		((Control)label55).TabIndex = 82;
		((Control)label55).Text = "C相温度过高报警延时";
		((Control)label56).AutoSize = true;
		((Control)label56).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label56).Location = new Point(21, 502);
		((Control)label56).Name = "label56";
		((Control)label56).Size = new Size(100, 17);
		((Control)label56).TabIndex = 81;
		((Control)label56).Text = "C相温度过高阈值";
		((Control)label57).AutoSize = true;
		((Control)label57).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label57).Location = new Point(21, 475);
		((Control)label57).Name = "label57";
		((Control)label57).Size = new Size(124, 17);
		((Control)label57).TabIndex = 80;
		((Control)label57).Text = "B相温度过高报警延时";
		((Control)label58).AutoSize = true;
		((Control)label58).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label58).Location = new Point(21, 448);
		((Control)label58).Name = "label58";
		((Control)label58).Size = new Size(100, 17);
		((Control)label58).TabIndex = 79;
		((Control)label58).Text = "B相温度过高阈值";
		((Control)label59).AutoSize = true;
		((Control)label59).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label59).Location = new Point(21, 421);
		((Control)label59).Name = "label59";
		((Control)label59).Size = new Size(124, 17);
		((Control)label59).TabIndex = 78;
		((Control)label59).Text = "A相温度过高报警延时";
		((Control)label60).AutoSize = true;
		((Control)label60).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)label60).Location = new Point(21, 394);
		((Control)label60).Name = "label60";
		((Control)label60).Size = new Size(100, 17);
		((Control)label60).TabIndex = 77;
		((Control)label60).Text = "A相温度过高阈值";
		((Control)groupBox3).Controls.Add((Control)(object)checkedListBox2);
		((Control)groupBox3).Font = new Font("微软雅黑", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)134);
		((Control)groupBox3).Location = new Point(22, 351);
		((Control)groupBox3).Name = "groupBox3";
		((Control)groupBox3).Size = new Size(117, 305);
		((Control)groupBox3).TabIndex = 3;
		groupBox3.TabStop = false;
		((Control)groupBox3).Text = "报警状态位";
		((Control)groupBox3).Enter += groupBox3_Enter;
		((Control)checkedListBox2).BackColor = SystemColors.Control;
		((ListBox)checkedListBox2).BorderStyle = (BorderStyle)0;
		((Control)checkedListBox2).Enabled = false;
		((Control)checkedListBox2).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((ListControl)checkedListBox2).FormattingEnabled = true;
		((ObjectCollection)checkedListBox2.Items).AddRange(new object[15]
		{
			"A相电压过高", "B相电压过高", "C相电压过高", "A相电流过高", "B相电流过高", "C相电流过高", "A相温度过高", "B相温度过高", "C相温度过高", "A相电压过低",
			"B相电压过低", "C相电压过低", "A相电流过低", "B相电流过低", "C相电流过低"
		});
		((Control)checkedListBox2).Location = new Point(16, 20);
		((Control)checkedListBox2).Name = "checkedListBox2";
		((Control)checkedListBox2).Size = new Size(97, 270);
		((Control)checkedListBox2).TabIndex = 0;
		((Control)button1).BackColor = SystemColors.GradientActiveCaption;
		((Control)button1).Font = new Font("微软雅黑", 14.25f, (FontStyle)1, (GraphicsUnit)3, (byte)134);
		((Control)button1).Location = new Point(338, 443);
		((Control)button1).Name = "button1";
		((Control)button1).Size = new Size(110, 48);
		((Control)button1).TabIndex = 95;
		((Control)button1).Text = "读 取";
		((ButtonBase)button1).UseVisualStyleBackColor = false;
		((Control)button1).Click += button1_Click;
		((Control)button2).BackColor = SystemColors.GradientActiveCaption;
		((Control)button2).Font = new Font("微软雅黑", 14.25f, (FontStyle)1, (GraphicsUnit)3, (byte)134);
		((Control)button2).Location = new Point(474, 443);
		((Control)button2).Name = "button2";
		((Control)button2).Size = new Size(110, 48);
		((Control)button2).TabIndex = 96;
		((Control)button2).Text = "设 置";
		((ButtonBase)button2).UseVisualStyleBackColor = false;
		((Control)button2).Click += button2_Click;
		((Control)UAOver).AutoSize = true;
		((Control)UAOver).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)UAOver).Location = new Point(6, 22);
		((Control)UAOver).Name = "UAOver";
		((Control)UAOver).Size = new Size(95, 21);
		((Control)UAOver).TabIndex = 0;
		((Control)UAOver).Text = "A相电压过高";
		((ButtonBase)UAOver).UseVisualStyleBackColor = true;
		((Control)UBOver).AutoSize = true;
		((Control)UBOver).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)UBOver).Location = new Point(6, 42);
		((Control)UBOver).Name = "UBOver";
		((Control)UBOver).Size = new Size(95, 21);
		((Control)UBOver).TabIndex = 1;
		((Control)UBOver).Text = "B相电压过高";
		((ButtonBase)UBOver).UseVisualStyleBackColor = true;
		((Control)UCOver).AutoSize = true;
		((Control)UCOver).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)UCOver).Location = new Point(6, 62);
		((Control)UCOver).Name = "UCOver";
		((Control)UCOver).Size = new Size(95, 21);
		((Control)UCOver).TabIndex = 2;
		((Control)UCOver).Text = "C相电压过高";
		((ButtonBase)UCOver).UseVisualStyleBackColor = true;
		((Control)IAOver).AutoSize = true;
		((Control)IAOver).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)IAOver).Location = new Point(6, 82);
		((Control)IAOver).Name = "IAOver";
		((Control)IAOver).Size = new Size(95, 21);
		((Control)IAOver).TabIndex = 3;
		((Control)IAOver).Text = "A相电流过高";
		((ButtonBase)IAOver).UseVisualStyleBackColor = true;
		((Control)IBOver).AutoSize = true;
		((Control)IBOver).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)IBOver).Location = new Point(6, 102);
		((Control)IBOver).Name = "IBOver";
		((Control)IBOver).Size = new Size(95, 21);
		((Control)IBOver).TabIndex = 4;
		((Control)IBOver).Text = "B相电流过高";
		((ButtonBase)IBOver).UseVisualStyleBackColor = true;
		((Control)ICOver).AutoSize = true;
		((Control)ICOver).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)ICOver).Location = new Point(6, 122);
		((Control)ICOver).Name = "ICOver";
		((Control)ICOver).Size = new Size(95, 21);
		((Control)ICOver).TabIndex = 5;
		((Control)ICOver).Text = "C相电流过高";
		((ButtonBase)ICOver).UseVisualStyleBackColor = true;
		((Control)TAOver).AutoSize = true;
		((Control)TAOver).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)TAOver).Location = new Point(6, 142);
		((Control)TAOver).Name = "TAOver";
		((Control)TAOver).Size = new Size(95, 21);
		((Control)TAOver).TabIndex = 6;
		((Control)TAOver).Text = "A相温度过高";
		((ButtonBase)TAOver).UseVisualStyleBackColor = true;
		((Control)TBOver).AutoSize = true;
		((Control)TBOver).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)TBOver).Location = new Point(6, 162);
		((Control)TBOver).Name = "TBOver";
		((Control)TBOver).Size = new Size(95, 21);
		((Control)TBOver).TabIndex = 7;
		((Control)TBOver).Text = "B相温度过高\r\n";
		((ButtonBase)TBOver).UseVisualStyleBackColor = true;
		((Control)TCOver).AutoSize = true;
		((Control)TCOver).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)TCOver).Location = new Point(6, 182);
		((Control)TCOver).Name = "TCOver";
		((Control)TCOver).Size = new Size(95, 21);
		((Control)TCOver).TabIndex = 8;
		((Control)TCOver).Text = "C相温度过高";
		((ButtonBase)TCOver).UseVisualStyleBackColor = true;
		((Control)UALOW).AutoSize = true;
		((Control)UALOW).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)UALOW).Location = new Point(6, 203);
		((Control)UALOW).Name = "UALOW";
		((Control)UALOW).Size = new Size(95, 21);
		((Control)UALOW).TabIndex = 9;
		((Control)UALOW).Text = "A相电压过低";
		((ButtonBase)UALOW).UseVisualStyleBackColor = true;
		((Control)UBLOW).AutoSize = true;
		((Control)UBLOW).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)UBLOW).Location = new Point(6, 222);
		((Control)UBLOW).Name = "UBLOW";
		((Control)UBLOW).Size = new Size(95, 21);
		((Control)UBLOW).TabIndex = 10;
		((Control)UBLOW).Text = "B相电压过低";
		((ButtonBase)UBLOW).UseVisualStyleBackColor = true;
		((Control)UCLOW).AutoSize = true;
		((Control)UCLOW).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)UCLOW).Location = new Point(6, 242);
		((Control)UCLOW).Name = "UCLOW";
		((Control)UCLOW).Size = new Size(95, 21);
		((Control)UCLOW).TabIndex = 11;
		((Control)UCLOW).Text = "C相电压过低";
		((ButtonBase)UCLOW).UseVisualStyleBackColor = true;
		((Control)IALOW).AutoSize = true;
		((Control)IALOW).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)IALOW).Location = new Point(6, 262);
		((Control)IALOW).Name = "IALOW";
		((Control)IALOW).Size = new Size(95, 21);
		((Control)IALOW).TabIndex = 12;
		((Control)IALOW).Text = "A相电流过低";
		((ButtonBase)IALOW).UseVisualStyleBackColor = true;
		((Control)IBLOW).AutoSize = true;
		((Control)IBLOW).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)IBLOW).Location = new Point(6, 283);
		((Control)IBLOW).Name = "IBLOW";
		((Control)IBLOW).Size = new Size(95, 21);
		((Control)IBLOW).TabIndex = 13;
		((Control)IBLOW).Text = "B相电流过低";
		((ButtonBase)IBLOW).UseVisualStyleBackColor = true;
		IBLOW.CheckedChanged += checkBox14_CheckedChanged;
		((Control)ICLOW).AutoSize = true;
		((Control)ICLOW).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)ICLOW).Location = new Point(6, 302);
		((Control)ICLOW).Name = "ICLOW";
		((Control)ICLOW).Size = new Size(95, 21);
		((Control)ICLOW).TabIndex = 14;
		((Control)ICLOW).Text = "C相电流过低";
		((ButtonBase)ICLOW).UseVisualStyleBackColor = true;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 12f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Control)this).BackColor = SystemColors.Control;
		((Form)this).ClientSize = new Size(812, 672);
		((Control)this).Controls.Add((Control)(object)groupBox3);
		((Control)this).Controls.Add((Control)(object)报警设置);
		((Control)this).Controls.Add((Control)(object)groupBox1);
		((Control)this).Name = "MULE_alarm";
		((Control)this).Text = "MULE_alarm";
		((Control)groupBox1).ResumeLayout(false);
		((Control)groupBox1).PerformLayout();
		((Control)报警设置).ResumeLayout(false);
		((Control)报警设置).PerformLayout();
		((Control)groupBox3).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
	}
}
