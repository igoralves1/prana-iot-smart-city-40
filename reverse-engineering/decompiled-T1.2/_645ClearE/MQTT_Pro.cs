using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace _645ClearE;

public class MQTT_Pro : Form
{
	private Modbus m = new Modbus();

	private IContainer components = null;

	private TabControl tabControl1;

	private TabPage set_data_items;

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

	public MQTT_Pro()
	{
		InitializeComponent();
	}

	private bool CheckAddr()
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		if (Parameters.IsRightAddr != 1)
		{
			MessageBox.Show("Please check the address！");
			return false;
		}
		if (Parameters.IsPortOpen > 0)
		{
			return true;
		}
		MessageBox.Show("Please check your serial port！");
		return false;
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
	}

	private void button1_Click(object sender, EventArgs e)
	{
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d65: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d56: Unknown result type (might be due to invalid IL or missing references)
		if (!CheckAddr())
		{
			return;
		}
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] CRC = new byte[2];
		byte[] array = new byte[8];
		byte[] response = new byte[15];
		array[0] = Convert.ToByte(Parameters.Address);
		array[1] = 3;
		array[2] = 112;
		array[3] = 153;
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
			MessageBox.Show(ex.Message);
			return;
		}
		if (m.CheckResponse(response))
		{
			if (Parameters.IsUse485)
			{
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
			MessageBox.Show("Read successfully");
		}
		else
		{
			MessageBox.Show("No reply or checksum error");
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		//IL_08c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e7: Unknown result type (might be due to invalid IL or missing references)
		byte[] CRC = new byte[2];
		if (CheckAddr())
		{
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array = new byte[19];
			byte[] response = new byte[8];
			array[0] = Convert.ToByte(Parameters.Address);
			array[1] = 16;
			array[2] = 112;
			array[3] = 153;
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
				MessageBox.Show(ex.Message);
				return;
			}
			if (m.CheckResponse(response))
			{
				MessageBox.Show("Set successfully");
			}
			else
			{
				MessageBox.Show("Set failed");
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
		//IL_0aa7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b26: Expected Obj, but got Unknown
		//IL_0bd0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bda: Expected Obj, but got Unknown
		tabControl1 = new TabControl();
		set_data_items = new TabPage();
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
		((Control)set_data_items).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)tabControl1).Controls.Add((Control)(object)set_data_items);
		((Control)tabControl1).Location = new Point(4, 4);
		((Control)tabControl1).Name = "tabControl1";
		tabControl1.SelectedIndex = 0;
		((Control)tabControl1).Size = new Size(662, 415);
		((Control)tabControl1).TabIndex = 65;
		((Control)set_data_items).Controls.Add((Control)(object)button2);
		((Control)set_data_items).Controls.Add((Control)(object)button1);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox61);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox62);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox63);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox64);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox65);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox66);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox67);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox68);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox69);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox70);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox71);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox72);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox51);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox52);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox53);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox54);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox55);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox56);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox57);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox58);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox59);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox60);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox41);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox42);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox43);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox44);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox45);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox46);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox47);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox48);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox49);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox50);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox31);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox32);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox33);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox34);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox35);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox36);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox37);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox38);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox39);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox40);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox21);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox22);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox23);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox24);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox25);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox26);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox27);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox28);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox29);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox30);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox11);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox12);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox13);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox14);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox15);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox16);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox17);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox18);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox19);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox20);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox6);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox7);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox8);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox9);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox10);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox5);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox3);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox4);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox2);
		((Control)set_data_items).Controls.Add((Control)(object)checkBox1);
		set_data_items.Location = new Point(4, 22);
		((Control)set_data_items).Name = "set_data_items";
		((Control)set_data_items).Padding = new Padding(3);
		((Control)set_data_items).Size = new Size(654, 389);
		set_data_items.TabIndex = 1;
		((Control)set_data_items).Text = "data items";
		set_data_items.UseVisualStyleBackColor = true;
		((ButtonBase)button2).FlatStyle = (FlatStyle)3;
		((Control)button2).Font = new Font("Microsoft Sans Serif", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)button2).Location = new Point(323, 308);
		((Control)button2).Name = "button2";
		((Control)button2).Size = new Size(97, 39);
		((Control)button2).TabIndex = 73;
		((Control)button2).Text = "SET";
		((ButtonBase)button2).UseVisualStyleBackColor = true;
		((Control)button2).Click += button2_Click;
		((ButtonBase)button1).FlatStyle = (FlatStyle)3;
		((Control)button1).Font = new Font("Microsoft Sans Serif", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)button1).Location = new Point(210, 308);
		((Control)button1).Name = "button1";
		((Control)button1).Size = new Size(97, 39);
		((Control)button1).TabIndex = 72;
		((Control)button1).Text = "READ";
		((ButtonBase)button1).UseVisualStyleBackColor = true;
		((Control)button1).Click += button1_Click;
		((Control)checkBox61).AutoSize = true;
		((Control)checkBox61).Location = new Point(538, 20);
		((Control)checkBox61).Name = "checkBox61";
		((Control)checkBox61).Size = new Size(66, 16);
		((Control)checkBox61).TabIndex = 71;
		((Control)checkBox61).Text = "MD_QPOS";
		((ButtonBase)checkBox61).UseVisualStyleBackColor = true;
		((Control)checkBox62).AutoSize = true;
		((Control)checkBox62).Location = new Point(538, 42);
		((Control)checkBox62).Name = "checkBox62";
		((Control)checkBox62).Size = new Size(66, 16);
		((Control)checkBox62).TabIndex = 70;
		((Control)checkBox62).Text = "MD_QNEG";
		((ButtonBase)checkBox62).UseVisualStyleBackColor = true;
		((Control)checkBox63).AutoSize = true;
		((Control)checkBox63).Location = new Point(538, 64);
		((Control)checkBox63).Name = "checkBox63";
		((Control)checkBox63).Size = new Size(90, 16);
		((Control)checkBox63).TabIndex = 69;
		((Control)checkBox63).Text = "UnBalance_U";
		((ButtonBase)checkBox63).UseVisualStyleBackColor = true;
		((Control)checkBox64).AutoSize = true;
		((Control)checkBox64).Location = new Point(538, 86);
		((Control)checkBox64).Name = "checkBox64";
		((Control)checkBox64).Size = new Size(90, 16);
		((Control)checkBox64).TabIndex = 68;
		((Control)checkBox64).Text = "UnBalance_I";
		((ButtonBase)checkBox64).UseVisualStyleBackColor = true;
		((Control)checkBox65).AutoSize = true;
		((Control)checkBox65).Location = new Point(538, 108);
		((Control)checkBox65).Name = "checkBox65";
		((Control)checkBox65).Size = new Size(54, 16);
		((Control)checkBox65).TabIndex = 67;
		((Control)checkBox65).Text = "EP_F1";
		((ButtonBase)checkBox65).UseVisualStyleBackColor = true;
		((Control)checkBox66).AutoSize = true;
		((Control)checkBox66).Location = new Point(538, 130);
		((Control)checkBox66).Name = "checkBox66";
		((Control)checkBox66).Size = new Size(54, 16);
		((Control)checkBox66).TabIndex = 66;
		((Control)checkBox66).Text = "EP_F2";
		((ButtonBase)checkBox66).UseVisualStyleBackColor = true;
		((Control)checkBox67).AutoSize = true;
		((Control)checkBox67).Location = new Point(538, 152);
		((Control)checkBox67).Name = "checkBox67";
		((Control)checkBox67).Size = new Size(54, 16);
		((Control)checkBox67).TabIndex = 65;
		((Control)checkBox67).Text = "EP_F3";
		((ButtonBase)checkBox67).UseVisualStyleBackColor = true;
		((Control)checkBox68).AutoSize = true;
		((Control)checkBox68).Location = new Point(538, 174);
		((Control)checkBox68).Name = "checkBox68";
		((Control)checkBox68).Size = new Size(54, 16);
		((Control)checkBox68).TabIndex = 64;
		((Control)checkBox68).Text = "EP_F4";
		((ButtonBase)checkBox68).UseVisualStyleBackColor = true;
		((Control)checkBox69).AutoSize = true;
		((Control)checkBox69).Location = new Point(538, 196);
		((Control)checkBox69).Name = "checkBox69";
		((Control)checkBox69).Size = new Size(42, 16);
		((Control)checkBox69).TabIndex = 63;
		((Control)checkBox69).Text = "EQ1";
		((ButtonBase)checkBox69).UseVisualStyleBackColor = true;
		((Control)checkBox70).AutoSize = true;
		((Control)checkBox70).Location = new Point(538, 218);
		((Control)checkBox70).Name = "checkBox70";
		((Control)checkBox70).Size = new Size(42, 16);
		((Control)checkBox70).TabIndex = 62;
		((Control)checkBox70).Text = "EQ2";
		((ButtonBase)checkBox70).UseVisualStyleBackColor = true;
		((Control)checkBox71).AutoSize = true;
		((Control)checkBox71).Location = new Point(538, 240);
		((Control)checkBox71).Name = "checkBox71";
		((Control)checkBox71).Size = new Size(42, 16);
		((Control)checkBox71).TabIndex = 61;
		((Control)checkBox71).Text = "EQ3";
		((ButtonBase)checkBox71).UseVisualStyleBackColor = true;
		((Control)checkBox72).AutoSize = true;
		((Control)checkBox72).Location = new Point(538, 262);
		((Control)checkBox72).Name = "checkBox72";
		((Control)checkBox72).Size = new Size(42, 16);
		((Control)checkBox72).TabIndex = 60;
		((Control)checkBox72).Text = "EQ4";
		((ButtonBase)checkBox72).UseVisualStyleBackColor = true;
		((Control)checkBox51).AutoSize = true;
		((Control)checkBox51).Location = new Point(432, 64);
		((Control)checkBox51).Name = "checkBox51";
		((Control)checkBox51).Size = new Size(66, 16);
		((Control)checkBox51).TabIndex = 59;
		((Control)checkBox51).Text = "EPNEG_C";
		((ButtonBase)checkBox51).UseVisualStyleBackColor = true;
		((Control)checkBox52).AutoSize = true;
		((Control)checkBox52).Location = new Point(432, 86);
		((Control)checkBox52).Name = "checkBox52";
		((Control)checkBox52).Size = new Size(66, 16);
		((Control)checkBox52).TabIndex = 58;
		((Control)checkBox52).Text = "EQPOS_C";
		((ButtonBase)checkBox52).UseVisualStyleBackColor = true;
		((Control)checkBox53).AutoSize = true;
		((Control)checkBox53).Location = new Point(432, 108);
		((Control)checkBox53).Name = "checkBox53";
		((Control)checkBox53).Size = new Size(66, 16);
		((Control)checkBox53).TabIndex = 57;
		((Control)checkBox53).Text = "EQNEG_C";
		((ButtonBase)checkBox53).UseVisualStyleBackColor = true;
		((Control)checkBox54).AutoSize = true;
		((Control)checkBox54).Location = new Point(432, 130);
		((Control)checkBox54).Name = "checkBox54";
		((Control)checkBox54).Size = new Size(90, 16);
		((Control)checkBox54).TabIndex = 56;
		((Control)checkBox54).Text = "Ua_Harmonic";
		((ButtonBase)checkBox54).UseVisualStyleBackColor = true;
		((Control)checkBox55).AutoSize = true;
		((Control)checkBox55).Location = new Point(432, 152);
		((Control)checkBox55).Name = "checkBox55";
		((Control)checkBox55).Size = new Size(90, 16);
		((Control)checkBox55).TabIndex = 55;
		((Control)checkBox55).Text = "Ub_Harmonic";
		((ButtonBase)checkBox55).UseVisualStyleBackColor = true;
		((Control)checkBox56).AutoSize = true;
		((Control)checkBox56).Location = new Point(432, 174);
		((Control)checkBox56).Name = "checkBox56";
		((Control)checkBox56).Size = new Size(90, 16);
		((Control)checkBox56).TabIndex = 54;
		((Control)checkBox56).Text = "Uc_Harmonic";
		((ButtonBase)checkBox56).UseVisualStyleBackColor = true;
		((Control)checkBox57).AutoSize = true;
		((Control)checkBox57).Location = new Point(432, 196);
		((Control)checkBox57).Name = "checkBox57";
		((Control)checkBox57).Size = new Size(90, 16);
		((Control)checkBox57).TabIndex = 53;
		((Control)checkBox57).Text = "Ia_Harmonic";
		((ButtonBase)checkBox57).UseVisualStyleBackColor = true;
		((Control)checkBox58).AutoSize = true;
		((Control)checkBox58).Location = new Point(432, 218);
		((Control)checkBox58).Name = "checkBox58";
		((Control)checkBox58).Size = new Size(90, 16);
		((Control)checkBox58).TabIndex = 52;
		((Control)checkBox58).Text = "Ib_Harmonic";
		((ButtonBase)checkBox58).UseVisualStyleBackColor = true;
		((Control)checkBox59).AutoSize = true;
		((Control)checkBox59).Location = new Point(432, 240);
		((Control)checkBox59).Name = "checkBox59";
		((Control)checkBox59).Size = new Size(90, 16);
		((Control)checkBox59).TabIndex = 51;
		((Control)checkBox59).Text = "Ic_Harmonic";
		((ButtonBase)checkBox59).UseVisualStyleBackColor = true;
		((Control)checkBox60).AutoSize = true;
		((Control)checkBox60).Location = new Point(432, 262);
		((Control)checkBox60).Name = "checkBox60";
		((Control)checkBox60).Size = new Size(66, 16);
		((Control)checkBox60).TabIndex = 50;
		((Control)checkBox60).Text = "MD_PNEG";
		((ButtonBase)checkBox60).UseVisualStyleBackColor = true;
		((Control)checkBox41).AutoSize = true;
		((Control)checkBox41).Location = new Point(325, 108);
		((Control)checkBox41).Name = "checkBox41";
		((Control)checkBox41).Size = new Size(72, 16);
		((Control)checkBox41).TabIndex = 49;
		((Control)checkBox41).Text = "DI_STATE";
		((ButtonBase)checkBox41).UseVisualStyleBackColor = true;
		((Control)checkBox42).AutoSize = true;
		((Control)checkBox42).Location = new Point(325, 130);
		((Control)checkBox42).Name = "checkBox42";
		((Control)checkBox42).Size = new Size(66, 16);
		((Control)checkBox42).TabIndex = 48;
		((Control)checkBox42).Text = "EPPOS_A";
		((ButtonBase)checkBox42).UseVisualStyleBackColor = true;
		((Control)checkBox43).AutoSize = true;
		((Control)checkBox43).Location = new Point(325, 152);
		((Control)checkBox43).Name = "checkBox43";
		((Control)checkBox43).Size = new Size(66, 16);
		((Control)checkBox43).TabIndex = 47;
		((Control)checkBox43).Text = "EPNEG_A";
		((ButtonBase)checkBox43).UseVisualStyleBackColor = true;
		((Control)checkBox44).AutoSize = true;
		((Control)checkBox44).Location = new Point(325, 174);
		((Control)checkBox44).Name = "checkBox44";
		((Control)checkBox44).Size = new Size(66, 16);
		((Control)checkBox44).TabIndex = 46;
		((Control)checkBox44).Text = "EQPOS_A";
		((ButtonBase)checkBox44).UseVisualStyleBackColor = true;
		((Control)checkBox45).AutoSize = true;
		((Control)checkBox45).Location = new Point(325, 196);
		((Control)checkBox45).Name = "checkBox45";
		((Control)checkBox45).Size = new Size(66, 16);
		((Control)checkBox45).TabIndex = 45;
		((Control)checkBox45).Text = "EQNEG_A";
		((ButtonBase)checkBox45).UseVisualStyleBackColor = true;
		((Control)checkBox46).AutoSize = true;
		((Control)checkBox46).Location = new Point(325, 218);
		((Control)checkBox46).Name = "checkBox46";
		((Control)checkBox46).Size = new Size(66, 16);
		((Control)checkBox46).TabIndex = 44;
		((Control)checkBox46).Text = "EPPOS_B";
		((ButtonBase)checkBox46).UseVisualStyleBackColor = true;
		((Control)checkBox47).AutoSize = true;
		((Control)checkBox47).Location = new Point(325, 240);
		((Control)checkBox47).Name = "checkBox47";
		((Control)checkBox47).Size = new Size(66, 16);
		((Control)checkBox47).TabIndex = 43;
		((Control)checkBox47).Text = "EPNEG_B";
		((ButtonBase)checkBox47).UseVisualStyleBackColor = true;
		((Control)checkBox48).AutoSize = true;
		((Control)checkBox48).Location = new Point(325, 262);
		((Control)checkBox48).Name = "checkBox48";
		((Control)checkBox48).Size = new Size(66, 16);
		((Control)checkBox48).TabIndex = 42;
		((Control)checkBox48).Text = "EQPOS_B";
		((ButtonBase)checkBox48).UseVisualStyleBackColor = true;
		((Control)checkBox49).AutoSize = true;
		((Control)checkBox49).Location = new Point(432, 20);
		((Control)checkBox49).Name = "checkBox49";
		((Control)checkBox49).Size = new Size(66, 16);
		((Control)checkBox49).TabIndex = 41;
		((Control)checkBox49).Text = "EQNEG_B";
		((ButtonBase)checkBox49).UseVisualStyleBackColor = true;
		((Control)checkBox50).AutoSize = true;
		((Control)checkBox50).Location = new Point(432, 42);
		((Control)checkBox50).Name = "checkBox50";
		((Control)checkBox50).Size = new Size(66, 16);
		((Control)checkBox50).TabIndex = 40;
		((Control)checkBox50).Text = "EPPOS_C";
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
		((Control)checkBox33).Size = new Size(72, 16);
		((Control)checkBox33).TabIndex = 37;
		((Control)checkBox33).Text = "CCID/MAC";
		((ButtonBase)checkBox33).UseVisualStyleBackColor = true;
		((Control)checkBox34).AutoSize = true;
		((Control)checkBox34).Location = new Point(223, 218);
		((Control)checkBox34).Name = "checkBox34";
		((Control)checkBox34).Size = new Size(36, 16);
		((Control)checkBox34).TabIndex = 36;
		((Control)checkBox34).Text = "PT";
		((ButtonBase)checkBox34).UseVisualStyleBackColor = true;
		((Control)checkBox35).AutoSize = true;
		((Control)checkBox35).Location = new Point(223, 240);
		((Control)checkBox35).Name = "checkBox35";
		((Control)checkBox35).Size = new Size(36, 16);
		((Control)checkBox35).TabIndex = 35;
		((Control)checkBox35).Text = "CT";
		((ButtonBase)checkBox35).UseVisualStyleBackColor = true;
		((Control)checkBox36).AutoSize = true;
		((Control)checkBox36).Location = new Point(223, 262);
		((Control)checkBox36).Name = "checkBox36";
		((Control)checkBox36).Size = new Size(60, 16);
		((Control)checkBox36).TabIndex = 34;
		((Control)checkBox36).Text = "TEMP_A";
		((ButtonBase)checkBox36).UseVisualStyleBackColor = true;
		((Control)checkBox37).AutoSize = true;
		((Control)checkBox37).Location = new Point(325, 20);
		((Control)checkBox37).Name = "checkBox37";
		((Control)checkBox37).Size = new Size(60, 16);
		((Control)checkBox37).TabIndex = 33;
		((Control)checkBox37).Text = "TEMP_B";
		((ButtonBase)checkBox37).UseVisualStyleBackColor = true;
		((Control)checkBox38).AutoSize = true;
		((Control)checkBox38).Location = new Point(325, 42);
		((Control)checkBox38).Name = "checkBox38";
		((Control)checkBox38).Size = new Size(60, 16);
		((Control)checkBox38).TabIndex = 32;
		((Control)checkBox38).Text = "TEMP_C";
		((ButtonBase)checkBox38).UseVisualStyleBackColor = true;
		((Control)checkBox39).AutoSize = true;
		((Control)checkBox39).Location = new Point(325, 64);
		((Control)checkBox39).Name = "checkBox39";
		((Control)checkBox39).Size = new Size(60, 16);
		((Control)checkBox39).TabIndex = 31;
		((Control)checkBox39).Text = "TEMP_N";
		((ButtonBase)checkBox39).UseVisualStyleBackColor = true;
		((Control)checkBox40).AutoSize = true;
		((Control)checkBox40).Location = new Point(325, 86);
		((Control)checkBox40).Name = "checkBox40";
		((Control)checkBox40).Size = new Size(96, 16);
		((Control)checkBox40).TabIndex = 30;
		((Control)checkBox40).Text = "AfterCurrent";
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
		((Form)this).ClientSize = new Size(671, 422);
		((Control)this).Controls.Add((Control)(object)tabControl1);
		((Control)this).Name = "MQTT_Pro";
		((Control)this).Text = "MQTT_Pro";
		((Control)tabControl1).ResumeLayout(false);
		((Control)set_data_items).ResumeLayout(false);
		((Control)set_data_items).PerformLayout();
		((Control)this).ResumeLayout(false);
	}
}
