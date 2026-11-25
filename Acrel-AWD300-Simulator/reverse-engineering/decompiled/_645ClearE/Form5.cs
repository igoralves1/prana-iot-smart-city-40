using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace _645ClearE;

public class Form5 : Form
{
	private Modbus m = new Modbus();

	private IContainer components = null;

	private TextBox textBox1;

	private TextBox textBox2;

	private TextBox textBox3;

	private TextBox textBox4;

	private TextBox textBox5;

	private TextBox textBox6;

	private TextBox textBox7;

	private TextBox textBox8;

	private Button AD1_LOW;

	private Button AD1_HIGH;

	private Button AD2_LOW;

	private Button AD2_HIGH;

	private Button AD3_LOW;

	private Button AD3_HIGH;

	private Button AD4_LOW;

	private Button AD4_HIGH;

	private Label label1;

	private Label label2;

	private TextBox textBox9;

	private Button button9;

	private Button button10;

	private TextBox textBox10;

	private TextBox textBox11;

	private Button button11;

	private Button button12;

	private TextBox textBox12;

	private Label label3;

	private Label label4;

	private TextBox textBox13;

	private Button button13;

	private Button button14;

	private TextBox textBox14;

	private Label label5;

	private Label label6;

	private TextBox textBox15;

	private Button button15;

	private Button button16;

	private TextBox textBox16;

	private Label label7;

	private Label label8;

	private GroupBox groupBox1;

	private GroupBox groupBox2;

	private GroupBox groupBox3;

	private GroupBox AD3设定值;

	private GroupBox AD4设定值;

	private GroupBox groupBox6;

	private Label label13;

	private Label label14;

	private Label label15;

	private Label label16;

	private Label label12;

	private Label label11;

	private Label label10;

	private Label label9;

	private Button button1;

	public Form5()
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

	private void button9_Click(object sender, EventArgs e)
	{
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		if (CheckAddr())
		{
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array = new byte[8];
			byte[] response = new byte[9];
			byte[] CRC = new byte[2];
			short num = 0;
			array[0] = Convert.ToByte(Parameters.Address);
			array[1] = 3;
			array[2] = 2;
			array[3] = 29;
			array[4] = 0;
			array[5] = 2;
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
				num = (short)((response[3] << 8) | response[4]);
				((Control)textBox9).Text = num.ToString();
				num = (short)((response[5] << 8) | response[6]);
				((Control)textBox10).Text = num.ToString();
				MessageBox.Show("读取成功");
			}
			else
			{
				MessageBox.Show("没有回复或校验错误");
			}
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0430: Unknown result type (might be due to invalid IL or missing references)
		//IL_0421: Unknown result type (might be due to invalid IL or missing references)
		if (CheckAddr())
		{
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array = new byte[8];
			byte[] response = new byte[13];
			byte[] CRC = new byte[2];
			short num = 0;
			array[0] = Convert.ToByte(Parameters.Address);
			array[1] = 3;
			array[2] = 2;
			array[3] = 17;
			array[4] = 0;
			array[5] = 4;
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
				num = (short)((response[3] << 8) | response[4]);
				((Control)textBox1).Text = num.ToString();
				num = (short)((response[5] << 8) | response[6]);
				((Control)textBox2).Text = num.ToString();
				num = (short)((response[7] << 8) | response[8]);
				((Control)textBox3).Text = num.ToString();
				num = (short)((response[9] << 8) | response[10]);
				((Control)textBox4).Text = num.ToString();
			}
			else
			{
				MessageBox.Show("没有回复或校验错误");
			}
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array2 = new byte[8];
			byte[] response2 = new byte[11];
			byte[] CRC2 = new byte[2];
			array2[0] = Convert.ToByte(Parameters.Address);
			array2[1] = 3;
			array2[2] = 1;
			array2[3] = 100;
			array2[4] = 0;
			array2[5] = 3;
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
				double num2 = (double)(short)((response2[3] << 8) | response2[4]) / 10.0;
				((Control)textBox8).Text = num2.ToString("f1");
				double num3 = (double)(short)((response2[5] << 8) | response2[6]) / 10.0;
				((Control)textBox7).Text = num3.ToString("f1");
				double num4 = (double)(short)((response2[7] << 8) | response2[8]) / 10.0;
				((Control)textBox6).Text = num4.ToString("f1");
			}
			else
			{
				MessageBox.Show("没有回复或校验错误");
			}
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array3 = new byte[8];
			byte[] response3 = new byte[7];
			byte[] CRC3 = new byte[2];
			array3[0] = Convert.ToByte(Parameters.Address);
			array3[1] = 3;
			array3[2] = 0;
			array3[3] = 16;
			array3[4] = 0;
			array3[5] = 1;
			m.GetCRC(array3, ref CRC3);
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
			if (m.CheckResponse(response3))
			{
				double num2 = (double)(short)((response3[3] << 8) | response3[4]) / 10.0;
				((Control)textBox5).Text = num2.ToString("f1");
				MessageBox.Show("读取成功");
			}
			else
			{
				MessageBox.Show("没有回复或校验错误");
			}
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		if (CheckAddr())
		{
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array = new byte[8];
			byte[] response = new byte[11];
			byte[] CRC = new byte[2];
			array[0] = Convert.ToByte(Parameters.Address);
			array[1] = 3;
			array[2] = 1;
			array[3] = 100;
			array[4] = 0;
			array[5] = 3;
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
				double num = (double)(short)((response[3] << 8) | response[4]) / 10.0;
				((Control)textBox8).Text = num.ToString("f1");
				double num2 = (double)(short)((response[5] << 8) | response[6]) / 10.0;
				((Control)textBox7).Text = num2.ToString("f1");
				double num3 = (double)(short)((response[7] << 8) | response[8]) / 10.0;
				((Control)textBox6).Text = num3.ToString("f1");
				MessageBox.Show("读取成功");
			}
			else
			{
				MessageBox.Show("没有回复或校验错误");
			}
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array2 = new byte[8];
			byte[] response2 = new byte[7];
			byte[] CRC2 = new byte[2];
			array2[0] = Convert.ToByte(Parameters.Address);
			array2[1] = 3;
			array2[2] = 0;
			array2[3] = 16;
			array2[4] = 0;
			array2[5] = 1;
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
				double num = (double)(short)((response2[3] << 8) | response2[4]) / 10.0;
				((Control)textBox5).Text = num.ToString("f1");
				MessageBox.Show("读取成功");
			}
			else
			{
				MessageBox.Show("没有回复或校验错误");
			}
		}
	}

	private void AD1_LOW_Click(object sender, EventArgs e)
	{
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		byte[] CRC = new byte[2];
		if (CheckAddr())
		{
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array = new byte[11];
			byte[] response = new byte[8];
			array[0] = Convert.ToByte(Parameters.Address);
			array[1] = 16;
			array[2] = 2;
			array[3] = 21;
			array[4] = 0;
			array[5] = 1;
			array[6] = 2;
			array[7] = 0;
			array[8] = 0;
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

	private void AD1_HIGH_Click(object sender, EventArgs e)
	{
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		byte[] CRC = new byte[2];
		if (CheckAddr())
		{
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array = new byte[11];
			byte[] response = new byte[8];
			array[0] = Convert.ToByte(Parameters.Address);
			array[1] = 16;
			array[2] = 2;
			array[3] = 22;
			array[4] = 0;
			array[5] = 1;
			array[6] = 2;
			array[7] = 0;
			array[8] = 0;
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

	private void AD2_LOW_Click(object sender, EventArgs e)
	{
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		byte[] CRC = new byte[2];
		if (CheckAddr())
		{
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array = new byte[11];
			byte[] response = new byte[8];
			array[0] = Convert.ToByte(Parameters.Address);
			array[1] = 16;
			array[2] = 2;
			array[3] = 23;
			array[4] = 0;
			array[5] = 1;
			array[6] = 2;
			array[7] = 0;
			array[8] = 0;
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

	private void AD2_HIGH_Click(object sender, EventArgs e)
	{
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		byte[] CRC = new byte[2];
		if (CheckAddr())
		{
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array = new byte[11];
			byte[] response = new byte[8];
			array[0] = Convert.ToByte(Parameters.Address);
			array[1] = 16;
			array[2] = 2;
			array[3] = 24;
			array[4] = 0;
			array[5] = 1;
			array[6] = 2;
			array[7] = 0;
			array[8] = 0;
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

	private void AD3_LOW_Click(object sender, EventArgs e)
	{
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		byte[] CRC = new byte[2];
		if (CheckAddr())
		{
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array = new byte[11];
			byte[] response = new byte[8];
			array[0] = Convert.ToByte(Parameters.Address);
			array[1] = 16;
			array[2] = 2;
			array[3] = 25;
			array[4] = 0;
			array[5] = 1;
			array[6] = 2;
			array[7] = 0;
			array[8] = 0;
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

	private void AD3_HIGH_Click(object sender, EventArgs e)
	{
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		byte[] CRC = new byte[2];
		if (CheckAddr())
		{
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array = new byte[11];
			byte[] response = new byte[8];
			array[0] = Convert.ToByte(Parameters.Address);
			array[1] = 16;
			array[2] = 2;
			array[3] = 26;
			array[4] = 0;
			array[5] = 1;
			array[6] = 2;
			array[7] = 0;
			array[8] = 0;
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

	private void AD4_LOW_Click(object sender, EventArgs e)
	{
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		byte[] CRC = new byte[2];
		if (CheckAddr())
		{
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array = new byte[11];
			byte[] response = new byte[8];
			array[0] = Convert.ToByte(Parameters.Address);
			array[1] = 16;
			array[2] = 2;
			array[3] = 27;
			array[4] = 0;
			array[5] = 1;
			array[6] = 2;
			array[7] = 0;
			array[8] = 0;
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

	private void AD4_HIGH_Click(object sender, EventArgs e)
	{
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		byte[] CRC = new byte[2];
		if (CheckAddr())
		{
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array = new byte[11];
			byte[] response = new byte[8];
			array[0] = Convert.ToByte(Parameters.Address);
			array[1] = 16;
			array[2] = 2;
			array[3] = 28;
			array[4] = 0;
			array[5] = 1;
			array[6] = 2;
			array[7] = 0;
			array[8] = 0;
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

	private void button10_Click(object sender, EventArgs e)
	{
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		byte[] CRC = new byte[2];
		if (CheckAddr())
		{
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array = new byte[13];
			byte[] response = new byte[8];
			array[0] = Convert.ToByte(Parameters.Address);
			array[1] = 16;
			array[2] = 2;
			array[3] = 29;
			array[4] = 0;
			array[5] = 2;
			array[6] = 4;
			array[7] = (byte)(Convert.ToInt32(((Control)textBox9).Text) >> 8);
			array[8] = (byte)Convert.ToInt32(((Control)textBox9).Text);
			array[9] = (byte)(Convert.ToInt32(((Control)textBox10).Text) >> 8);
			array[10] = (byte)Convert.ToInt32(((Control)textBox10).Text);
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

	private void button11_Click(object sender, EventArgs e)
	{
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		byte[] CRC = new byte[2];
		if (CheckAddr())
		{
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array = new byte[13];
			byte[] response = new byte[8];
			array[0] = Convert.ToByte(Parameters.Address);
			array[1] = 16;
			array[2] = 2;
			array[3] = 31;
			array[4] = 0;
			array[5] = 2;
			array[6] = 4;
			array[7] = (byte)(Convert.ToInt32(((Control)textBox12).Text) >> 8);
			array[8] = (byte)Convert.ToInt32(((Control)textBox12).Text);
			array[9] = (byte)(Convert.ToInt32(((Control)textBox11).Text) >> 8);
			array[10] = (byte)Convert.ToInt32(((Control)textBox11).Text);
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

	private void button15_Click(object sender, EventArgs e)
	{
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		byte[] CRC = new byte[2];
		if (CheckAddr())
		{
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array = new byte[13];
			byte[] response = new byte[8];
			array[0] = Convert.ToByte(Parameters.Address);
			array[1] = 16;
			array[2] = 2;
			array[3] = 33;
			array[4] = 0;
			array[5] = 2;
			array[6] = 4;
			array[7] = (byte)(Convert.ToInt32(((Control)textBox16).Text) >> 8);
			array[8] = (byte)Convert.ToInt32(((Control)textBox16).Text);
			array[9] = (byte)(Convert.ToInt32(((Control)textBox15).Text) >> 8);
			array[10] = (byte)Convert.ToInt32(((Control)textBox15).Text);
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

	private void button13_Click(object sender, EventArgs e)
	{
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		byte[] CRC = new byte[2];
		if (CheckAddr())
		{
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array = new byte[13];
			byte[] response = new byte[8];
			array[0] = Convert.ToByte(Parameters.Address);
			array[1] = 16;
			array[2] = 2;
			array[3] = 35;
			array[4] = 0;
			array[5] = 2;
			array[6] = 4;
			array[7] = (byte)(Convert.ToInt32(((Control)textBox14).Text) >> 8);
			array[8] = (byte)Convert.ToInt32(((Control)textBox14).Text);
			array[9] = (byte)(Convert.ToInt32(((Control)textBox13).Text) >> 8);
			array[10] = (byte)Convert.ToInt32(((Control)textBox13).Text);
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

	private void button12_Click(object sender, EventArgs e)
	{
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		if (CheckAddr())
		{
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array = new byte[8];
			byte[] response = new byte[9];
			byte[] CRC = new byte[2];
			short num = 0;
			array[0] = Convert.ToByte(Parameters.Address);
			array[1] = 3;
			array[2] = 2;
			array[3] = 31;
			array[4] = 0;
			array[5] = 2;
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
				num = (short)((response[3] << 8) | response[4]);
				((Control)textBox12).Text = num.ToString();
				num = (short)((response[5] << 8) | response[6]);
				((Control)textBox11).Text = num.ToString();
				MessageBox.Show("读取成功");
			}
			else
			{
				MessageBox.Show("没有回复或校验错误");
			}
		}
	}

	private void button16_Click(object sender, EventArgs e)
	{
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		if (CheckAddr())
		{
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array = new byte[8];
			byte[] response = new byte[9];
			byte[] CRC = new byte[2];
			short num = 0;
			array[0] = Convert.ToByte(Parameters.Address);
			array[1] = 3;
			array[2] = 2;
			array[3] = 33;
			array[4] = 0;
			array[5] = 2;
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
				num = (short)((response[3] << 8) | response[4]);
				((Control)textBox16).Text = num.ToString();
				num = (short)((response[5] << 8) | response[6]);
				((Control)textBox15).Text = num.ToString();
				MessageBox.Show("读取成功");
			}
			else
			{
				MessageBox.Show("没有回复或校验错误");
			}
		}
	}

	private void button14_Click(object sender, EventArgs e)
	{
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		if (CheckAddr())
		{
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array = new byte[8];
			byte[] response = new byte[9];
			byte[] CRC = new byte[2];
			short num = 0;
			array[0] = Convert.ToByte(Parameters.Address);
			array[1] = 3;
			array[2] = 2;
			array[3] = 35;
			array[4] = 0;
			array[5] = 2;
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
				num = (short)((response[3] << 8) | response[4]);
				((Control)textBox14).Text = num.ToString();
				num = (short)((response[5] << 8) | response[6]);
				((Control)textBox13).Text = num.ToString();
				MessageBox.Show("读取成功");
			}
			else
			{
				MessageBox.Show("没有回复或校验错误");
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
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0413: Unknown result type (might be due to invalid IL or missing references)
		//IL_0480: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_055a: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_062e: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0758: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0886: Unknown result type (might be due to invalid IL or missing references)
		//IL_091d: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d39: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d97: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f23: Unknown result type (might be due to invalid IL or missing references)
		//IL_104d: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_1145: Unknown result type (might be due to invalid IL or missing references)
		//IL_11d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1305: Unknown result type (might be due to invalid IL or missing references)
		//IL_1366: Unknown result type (might be due to invalid IL or missing references)
		//IL_13fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1491: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ff9: Unknown result type (might be due to invalid IL or missing references)
		//IL_2003: Expected Obj, but got Unknown
		//IL_2026: Unknown result type (might be due to invalid IL or missing references)
		//IL_214d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2157: Expected Obj, but got Unknown
		//IL_215d: Unknown result type (might be due to invalid IL or missing references)
		textBox1 = new TextBox();
		textBox2 = new TextBox();
		textBox3 = new TextBox();
		textBox4 = new TextBox();
		textBox5 = new TextBox();
		textBox6 = new TextBox();
		textBox7 = new TextBox();
		textBox8 = new TextBox();
		AD1_LOW = new Button();
		AD1_HIGH = new Button();
		AD2_LOW = new Button();
		AD2_HIGH = new Button();
		AD3_LOW = new Button();
		AD3_HIGH = new Button();
		AD4_LOW = new Button();
		AD4_HIGH = new Button();
		label1 = new Label();
		label2 = new Label();
		textBox9 = new TextBox();
		button9 = new Button();
		button10 = new Button();
		textBox10 = new TextBox();
		textBox11 = new TextBox();
		button11 = new Button();
		button12 = new Button();
		textBox12 = new TextBox();
		label3 = new Label();
		label4 = new Label();
		textBox13 = new TextBox();
		button13 = new Button();
		button14 = new Button();
		textBox14 = new TextBox();
		label5 = new Label();
		label6 = new Label();
		textBox15 = new TextBox();
		button15 = new Button();
		button16 = new Button();
		textBox16 = new TextBox();
		label7 = new Label();
		label8 = new Label();
		groupBox1 = new GroupBox();
		groupBox2 = new GroupBox();
		groupBox3 = new GroupBox();
		AD3设定值 = new GroupBox();
		AD4设定值 = new GroupBox();
		groupBox6 = new GroupBox();
		label9 = new Label();
		label10 = new Label();
		label11 = new Label();
		label12 = new Label();
		label13 = new Label();
		label14 = new Label();
		label15 = new Label();
		label16 = new Label();
		button1 = new Button();
		((Control)groupBox1).SuspendLayout();
		((Control)groupBox2).SuspendLayout();
		((Control)groupBox3).SuspendLayout();
		((Control)AD3设定值).SuspendLayout();
		((Control)AD4设定值).SuspendLayout();
		((Control)groupBox6).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)textBox1).Location = new Point(32, 43);
		((Control)textBox1).Margin = new Padding(3, 4, 3, 4);
		((Control)textBox1).Name = "textBox1";
		((TextBoxBase)textBox1).ReadOnly = true;
		((Control)textBox1).Size = new Size(93, 23);
		((Control)textBox1).TabIndex = 0;
		((Control)textBox2).Location = new Point(139, 43);
		((Control)textBox2).Margin = new Padding(3, 4, 3, 4);
		((Control)textBox2).Name = "textBox2";
		((TextBoxBase)textBox2).ReadOnly = true;
		((Control)textBox2).Size = new Size(93, 23);
		((Control)textBox2).TabIndex = 1;
		((Control)textBox3).Location = new Point(247, 43);
		((Control)textBox3).Margin = new Padding(3, 4, 3, 4);
		((Control)textBox3).Name = "textBox3";
		((TextBoxBase)textBox3).ReadOnly = true;
		((Control)textBox3).Size = new Size(93, 23);
		((Control)textBox3).TabIndex = 2;
		((Control)textBox4).Location = new Point(358, 43);
		((Control)textBox4).Margin = new Padding(3, 4, 3, 4);
		((Control)textBox4).Name = "textBox4";
		((TextBoxBase)textBox4).ReadOnly = true;
		((Control)textBox4).Size = new Size(93, 23);
		((Control)textBox4).TabIndex = 3;
		((Control)textBox5).Location = new Point(358, 95);
		((Control)textBox5).Margin = new Padding(3, 4, 3, 4);
		((Control)textBox5).Name = "textBox5";
		((TextBoxBase)textBox5).ReadOnly = true;
		((Control)textBox5).Size = new Size(93, 23);
		((Control)textBox5).TabIndex = 7;
		((Control)textBox6).Location = new Point(247, 95);
		((Control)textBox6).Margin = new Padding(3, 4, 3, 4);
		((Control)textBox6).Name = "textBox6";
		((TextBoxBase)textBox6).ReadOnly = true;
		((Control)textBox6).Size = new Size(93, 23);
		((Control)textBox6).TabIndex = 6;
		((Control)textBox7).Location = new Point(139, 95);
		((Control)textBox7).Margin = new Padding(3, 4, 3, 4);
		((Control)textBox7).Name = "textBox7";
		((TextBoxBase)textBox7).ReadOnly = true;
		((Control)textBox7).Size = new Size(93, 23);
		((Control)textBox7).TabIndex = 5;
		((Control)textBox8).Location = new Point(32, 95);
		((Control)textBox8).Margin = new Padding(3, 4, 3, 4);
		((Control)textBox8).Name = "textBox8";
		((TextBoxBase)textBox8).ReadOnly = true;
		((Control)textBox8).Size = new Size(93, 23);
		((Control)textBox8).TabIndex = 4;
		((Control)AD1_LOW).Location = new Point(47, 23);
		((Control)AD1_LOW).Margin = new Padding(3, 4, 3, 4);
		((Control)AD1_LOW).Name = "AD1_LOW";
		((Control)AD1_LOW).Size = new Size(87, 33);
		((Control)AD1_LOW).TabIndex = 8;
		((Control)AD1_LOW).Text = "AD1_LOW";
		((ButtonBase)AD1_LOW).UseVisualStyleBackColor = true;
		((Control)AD1_LOW).Click += AD1_LOW_Click;
		((Control)AD1_HIGH).Location = new Point(47, 64);
		((Control)AD1_HIGH).Margin = new Padding(3, 4, 3, 4);
		((Control)AD1_HIGH).Name = "AD1_HIGH";
		((Control)AD1_HIGH).Size = new Size(87, 33);
		((Control)AD1_HIGH).TabIndex = 9;
		((Control)AD1_HIGH).Text = "AD1_HIGH";
		((ButtonBase)AD1_HIGH).UseVisualStyleBackColor = true;
		((Control)AD1_HIGH).Click += AD1_HIGH_Click;
		((Control)AD2_LOW).Location = new Point(169, 23);
		((Control)AD2_LOW).Margin = new Padding(3, 4, 3, 4);
		((Control)AD2_LOW).Name = "AD2_LOW";
		((Control)AD2_LOW).Size = new Size(87, 33);
		((Control)AD2_LOW).TabIndex = 10;
		((Control)AD2_LOW).Text = "AD2_LOW";
		((ButtonBase)AD2_LOW).UseVisualStyleBackColor = true;
		((Control)AD2_LOW).Click += AD2_LOW_Click;
		((Control)AD2_HIGH).Location = new Point(169, 64);
		((Control)AD2_HIGH).Margin = new Padding(3, 4, 3, 4);
		((Control)AD2_HIGH).Name = "AD2_HIGH";
		((Control)AD2_HIGH).Size = new Size(87, 33);
		((Control)AD2_HIGH).TabIndex = 11;
		((Control)AD2_HIGH).Text = "AD2_HIGH";
		((ButtonBase)AD2_HIGH).UseVisualStyleBackColor = true;
		((Control)AD2_HIGH).Click += AD2_HIGH_Click;
		((Control)AD3_LOW).Location = new Point(293, 23);
		((Control)AD3_LOW).Margin = new Padding(3, 4, 3, 4);
		((Control)AD3_LOW).Name = "AD3_LOW";
		((Control)AD3_LOW).Size = new Size(87, 33);
		((Control)AD3_LOW).TabIndex = 12;
		((Control)AD3_LOW).Text = "AD3_LOW";
		((ButtonBase)AD3_LOW).UseVisualStyleBackColor = true;
		((Control)AD3_LOW).Click += AD3_LOW_Click;
		((Control)AD3_HIGH).Location = new Point(293, 64);
		((Control)AD3_HIGH).Margin = new Padding(3, 4, 3, 4);
		((Control)AD3_HIGH).Name = "AD3_HIGH";
		((Control)AD3_HIGH).Size = new Size(87, 33);
		((Control)AD3_HIGH).TabIndex = 13;
		((Control)AD3_HIGH).Text = "AD3_HIGH";
		((ButtonBase)AD3_HIGH).UseVisualStyleBackColor = true;
		((Control)AD3_HIGH).Click += AD3_HIGH_Click;
		((Control)AD4_LOW).Location = new Point(417, 23);
		((Control)AD4_LOW).Margin = new Padding(3, 4, 3, 4);
		((Control)AD4_LOW).Name = "AD4_LOW";
		((Control)AD4_LOW).Size = new Size(87, 33);
		((Control)AD4_LOW).TabIndex = 14;
		((Control)AD4_LOW).Text = "AD4_LOW";
		((ButtonBase)AD4_LOW).UseVisualStyleBackColor = true;
		((Control)AD4_LOW).Click += AD4_LOW_Click;
		((Control)AD4_HIGH).Location = new Point(417, 64);
		((Control)AD4_HIGH).Margin = new Padding(3, 4, 3, 4);
		((Control)AD4_HIGH).Name = "AD4_HIGH";
		((Control)AD4_HIGH).Size = new Size(87, 33);
		((Control)AD4_HIGH).TabIndex = 15;
		((Control)AD4_HIGH).Text = "AD4_HIGH";
		((ButtonBase)AD4_HIGH).UseVisualStyleBackColor = true;
		((Control)AD4_HIGH).Click += AD4_HIGH_Click;
		((Control)label1).AutoSize = true;
		((Control)label1).Location = new Point(9, 29);
		((Control)label1).Name = "label1";
		((Control)label1).Size = new Size(44, 17);
		((Control)label1).TabIndex = 16;
		((Control)label1).Text = "下限值";
		((Control)label2).AutoSize = true;
		((Control)label2).Location = new Point(9, 70);
		((Control)label2).Name = "label2";
		((Control)label2).Size = new Size(44, 17);
		((Control)label2).TabIndex = 17;
		((Control)label2).Text = "上限值";
		((Control)textBox9).Location = new Point(64, 27);
		((Control)textBox9).Margin = new Padding(3, 4, 3, 4);
		((Control)textBox9).Name = "textBox9";
		((Control)textBox9).Size = new Size(60, 23);
		((Control)textBox9).TabIndex = 18;
		((Control)button9).Location = new Point(135, 21);
		((Control)button9).Margin = new Padding(3, 4, 3, 4);
		((Control)button9).Name = "button9";
		((Control)button9).Size = new Size(87, 33);
		((Control)button9).TabIndex = 19;
		((Control)button9).Text = "读取";
		((ButtonBase)button9).UseVisualStyleBackColor = true;
		((Control)button9).Click += button9_Click;
		((Control)button10).Location = new Point(135, 63);
		((Control)button10).Margin = new Padding(3, 4, 3, 4);
		((Control)button10).Name = "button10";
		((Control)button10).Size = new Size(87, 33);
		((Control)button10).TabIndex = 20;
		((Control)button10).Text = "设置";
		((ButtonBase)button10).UseVisualStyleBackColor = true;
		((Control)button10).Click += button10_Click;
		((Control)textBox10).Location = new Point(64, 67);
		((Control)textBox10).Margin = new Padding(3, 4, 3, 4);
		((Control)textBox10).Name = "textBox10";
		((Control)textBox10).Size = new Size(60, 23);
		((Control)textBox10).TabIndex = 21;
		((Control)textBox11).Location = new Point(63, 65);
		((Control)textBox11).Margin = new Padding(3, 4, 3, 4);
		((Control)textBox11).Name = "textBox11";
		((Control)textBox11).Size = new Size(60, 23);
		((Control)textBox11).TabIndex = 27;
		((Control)button11).Location = new Point(134, 61);
		((Control)button11).Margin = new Padding(3, 4, 3, 4);
		((Control)button11).Name = "button11";
		((Control)button11).Size = new Size(87, 33);
		((Control)button11).TabIndex = 26;
		((Control)button11).Text = "设置";
		((ButtonBase)button11).UseVisualStyleBackColor = true;
		((Control)button11).Click += button11_Click;
		((Control)button12).Location = new Point(134, 19);
		((Control)button12).Margin = new Padding(3, 4, 3, 4);
		((Control)button12).Name = "button12";
		((Control)button12).Size = new Size(87, 33);
		((Control)button12).TabIndex = 25;
		((Control)button12).Text = "读取";
		((ButtonBase)button12).UseVisualStyleBackColor = true;
		((Control)button12).Click += button12_Click;
		((Control)textBox12).Location = new Point(63, 24);
		((Control)textBox12).Margin = new Padding(3, 4, 3, 4);
		((Control)textBox12).Name = "textBox12";
		((Control)textBox12).Size = new Size(60, 23);
		((Control)textBox12).TabIndex = 24;
		((Control)label3).AutoSize = true;
		((Control)label3).Location = new Point(8, 68);
		((Control)label3).Name = "label3";
		((Control)label3).Size = new Size(44, 17);
		((Control)label3).TabIndex = 23;
		((Control)label3).Text = "上限值";
		((Control)label4).AutoSize = true;
		((Control)label4).Location = new Point(8, 27);
		((Control)label4).Name = "label4";
		((Control)label4).Size = new Size(44, 17);
		((Control)label4).TabIndex = 22;
		((Control)label4).Text = "下限值";
		((Control)textBox13).Location = new Point(66, 67);
		((Control)textBox13).Margin = new Padding(3, 4, 3, 4);
		((Control)textBox13).Name = "textBox13";
		((Control)textBox13).Size = new Size(60, 23);
		((Control)textBox13).TabIndex = 39;
		((Control)button13).Location = new Point(137, 62);
		((Control)button13).Margin = new Padding(3, 4, 3, 4);
		((Control)button13).Name = "button13";
		((Control)button13).Size = new Size(87, 33);
		((Control)button13).TabIndex = 38;
		((Control)button13).Text = "设置";
		((ButtonBase)button13).UseVisualStyleBackColor = true;
		((Control)button13).Click += button13_Click;
		((Control)button14).Location = new Point(137, 21);
		((Control)button14).Margin = new Padding(3, 4, 3, 4);
		((Control)button14).Name = "button14";
		((Control)button14).Size = new Size(87, 33);
		((Control)button14).TabIndex = 37;
		((Control)button14).Text = "读取";
		((ButtonBase)button14).UseVisualStyleBackColor = true;
		((Control)button14).Click += button14_Click;
		((Control)textBox14).Location = new Point(66, 26);
		((Control)textBox14).Margin = new Padding(3, 4, 3, 4);
		((Control)textBox14).Name = "textBox14";
		((Control)textBox14).Size = new Size(60, 23);
		((Control)textBox14).TabIndex = 36;
		((Control)label5).AutoSize = true;
		((Control)label5).Location = new Point(11, 69);
		((Control)label5).Name = "label5";
		((Control)label5).Size = new Size(44, 17);
		((Control)label5).TabIndex = 35;
		((Control)label5).Text = "上限值";
		((Control)label6).AutoSize = true;
		((Control)label6).Location = new Point(11, 28);
		((Control)label6).Name = "label6";
		((Control)label6).Size = new Size(44, 17);
		((Control)label6).TabIndex = 34;
		((Control)label6).Text = "下限值";
		((Control)textBox15).Location = new Point(65, 68);
		((Control)textBox15).Margin = new Padding(3, 4, 3, 4);
		((Control)textBox15).Name = "textBox15";
		((Control)textBox15).Size = new Size(60, 23);
		((Control)textBox15).TabIndex = 33;
		((Control)button15).Location = new Point(136, 63);
		((Control)button15).Margin = new Padding(3, 4, 3, 4);
		((Control)button15).Name = "button15";
		((Control)button15).Size = new Size(87, 33);
		((Control)button15).TabIndex = 32;
		((Control)button15).Text = "设置";
		((ButtonBase)button15).UseVisualStyleBackColor = true;
		((Control)button15).Click += button15_Click;
		((Control)button16).Location = new Point(136, 22);
		((Control)button16).Margin = new Padding(3, 4, 3, 4);
		((Control)button16).Name = "button16";
		((Control)button16).Size = new Size(87, 33);
		((Control)button16).TabIndex = 31;
		((Control)button16).Text = "读取";
		((ButtonBase)button16).UseVisualStyleBackColor = true;
		((Control)button16).Click += button16_Click;
		((Control)textBox16).Location = new Point(65, 27);
		((Control)textBox16).Margin = new Padding(3, 4, 3, 4);
		((Control)textBox16).Name = "textBox16";
		((Control)textBox16).Size = new Size(60, 23);
		((Control)textBox16).TabIndex = 30;
		((Control)label7).AutoSize = true;
		((Control)label7).Location = new Point(10, 69);
		((Control)label7).Name = "label7";
		((Control)label7).Size = new Size(44, 17);
		((Control)label7).TabIndex = 29;
		((Control)label7).Text = "上限值";
		((Control)label8).AutoSize = true;
		((Control)label8).Location = new Point(10, 28);
		((Control)label8).Name = "label8";
		((Control)label8).Size = new Size(44, 17);
		((Control)label8).TabIndex = 28;
		((Control)label8).Text = "下限值";
		((Control)groupBox1).Controls.Add((Control)(object)AD4_HIGH);
		((Control)groupBox1).Controls.Add((Control)(object)AD4_LOW);
		((Control)groupBox1).Controls.Add((Control)(object)AD3_HIGH);
		((Control)groupBox1).Controls.Add((Control)(object)AD3_LOW);
		((Control)groupBox1).Controls.Add((Control)(object)AD2_HIGH);
		((Control)groupBox1).Controls.Add((Control)(object)AD2_LOW);
		((Control)groupBox1).Controls.Add((Control)(object)AD1_HIGH);
		((Control)groupBox1).Controls.Add((Control)(object)AD1_LOW);
		((Control)groupBox1).Location = new Point(33, 160);
		((Control)groupBox1).Name = "groupBox1";
		((Control)groupBox1).Size = new Size(539, 111);
		((Control)groupBox1).TabIndex = 40;
		groupBox1.TabStop = false;
		((Control)groupBox1).Text = "校准";
		((Control)groupBox2).Controls.Add((Control)(object)textBox10);
		((Control)groupBox2).Controls.Add((Control)(object)button10);
		((Control)groupBox2).Controls.Add((Control)(object)button9);
		((Control)groupBox2).Controls.Add((Control)(object)textBox9);
		((Control)groupBox2).Controls.Add((Control)(object)label2);
		((Control)groupBox2).Controls.Add((Control)(object)label1);
		((Control)groupBox2).Location = new Point(33, 290);
		((Control)groupBox2).Name = "groupBox2";
		((Control)groupBox2).Size = new Size(239, 109);
		((Control)groupBox2).TabIndex = 41;
		groupBox2.TabStop = false;
		((Control)groupBox2).Text = "AD1设定值";
		((Control)groupBox3).Controls.Add((Control)(object)textBox11);
		((Control)groupBox3).Controls.Add((Control)(object)button11);
		((Control)groupBox3).Controls.Add((Control)(object)button12);
		((Control)groupBox3).Controls.Add((Control)(object)textBox12);
		((Control)groupBox3).Controls.Add((Control)(object)label3);
		((Control)groupBox3).Controls.Add((Control)(object)label4);
		((Control)groupBox3).Location = new Point(331, 290);
		((Control)groupBox3).Name = "groupBox3";
		((Control)groupBox3).Size = new Size(241, 106);
		((Control)groupBox3).TabIndex = 42;
		groupBox3.TabStop = false;
		((Control)groupBox3).Text = "AD2设定值";
		((Control)AD3设定值).Controls.Add((Control)(object)textBox15);
		((Control)AD3设定值).Controls.Add((Control)(object)button15);
		((Control)AD3设定值).Controls.Add((Control)(object)button16);
		((Control)AD3设定值).Controls.Add((Control)(object)textBox16);
		((Control)AD3设定值).Controls.Add((Control)(object)label7);
		((Control)AD3设定值).Controls.Add((Control)(object)label8);
		((Control)AD3设定值).Location = new Point(33, 416);
		((Control)AD3设定值).Name = "AD3设定值";
		((Control)AD3设定值).Size = new Size(232, 109);
		((Control)AD3设定值).TabIndex = 43;
		AD3设定值.TabStop = false;
		((Control)AD3设定值).Text = "AD3设定值";
		((Control)AD4设定值).Controls.Add((Control)(object)textBox13);
		((Control)AD4设定值).Controls.Add((Control)(object)button13);
		((Control)AD4设定值).Controls.Add((Control)(object)button14);
		((Control)AD4设定值).Controls.Add((Control)(object)textBox14);
		((Control)AD4设定值).Controls.Add((Control)(object)label5);
		((Control)AD4设定值).Controls.Add((Control)(object)label6);
		((Control)AD4设定值).Location = new Point(331, 416);
		((Control)AD4设定值).Name = "AD4设定值";
		((Control)AD4设定值).Size = new Size(240, 109);
		((Control)AD4设定值).TabIndex = 44;
		AD4设定值.TabStop = false;
		((Control)AD4设定值).Text = "AD4设定值";
		((Control)groupBox6).Controls.Add((Control)(object)button1);
		((Control)groupBox6).Controls.Add((Control)(object)label13);
		((Control)groupBox6).Controls.Add((Control)(object)label14);
		((Control)groupBox6).Controls.Add((Control)(object)label15);
		((Control)groupBox6).Controls.Add((Control)(object)label16);
		((Control)groupBox6).Controls.Add((Control)(object)label12);
		((Control)groupBox6).Controls.Add((Control)(object)label11);
		((Control)groupBox6).Controls.Add((Control)(object)label10);
		((Control)groupBox6).Controls.Add((Control)(object)label9);
		((Control)groupBox6).Controls.Add((Control)(object)textBox5);
		((Control)groupBox6).Controls.Add((Control)(object)textBox6);
		((Control)groupBox6).Controls.Add((Control)(object)textBox7);
		((Control)groupBox6).Controls.Add((Control)(object)textBox8);
		((Control)groupBox6).Controls.Add((Control)(object)textBox4);
		((Control)groupBox6).Controls.Add((Control)(object)textBox3);
		((Control)groupBox6).Controls.Add((Control)(object)textBox2);
		((Control)groupBox6).Controls.Add((Control)(object)textBox1);
		((Control)groupBox6).Location = new Point(33, 15);
		((Control)groupBox6).Name = "groupBox6";
		((Control)groupBox6).Size = new Size(539, 139);
		((Control)groupBox6).TabIndex = 45;
		groupBox6.TabStop = false;
		((Control)groupBox6).Text = "读取";
		((Control)label9).AutoSize = true;
		((Control)label9).Location = new Point(65, 22);
		((Control)label9).Name = "label9";
		((Control)label9).Size = new Size(32, 17);
		((Control)label9).TabIndex = 8;
		((Control)label9).Text = "AD1";
		((Control)label10).AutoSize = true;
		((Control)label10).Location = new Point(171, 22);
		((Control)label10).Name = "label10";
		((Control)label10).Size = new Size(32, 17);
		((Control)label10).TabIndex = 9;
		((Control)label10).Text = "AD2";
		((Control)label11).AutoSize = true;
		((Control)label11).Location = new Point(279, 21);
		((Control)label11).Name = "label11";
		((Control)label11).Size = new Size(32, 17);
		((Control)label11).TabIndex = 10;
		((Control)label11).Text = "AD3";
		((Control)label12).AutoSize = true;
		((Control)label12).Location = new Point(387, 21);
		((Control)label12).Name = "label12";
		((Control)label12).Size = new Size(32, 17);
		((Control)label12).TabIndex = 11;
		((Control)label12).Text = "AD4";
		((Control)label13).AutoSize = true;
		((Control)label13).Location = new Point(381, 74);
		((Control)label13).Name = "label13";
		((Control)label13).Size = new Size(48, 17);
		((Control)label13).TabIndex = 15;
		((Control)label13).Text = "TEMP4";
		((Control)label14).AutoSize = true;
		((Control)label14).Location = new Point(268, 74);
		((Control)label14).Name = "label14";
		((Control)label14).Size = new Size(49, 17);
		((Control)label14).TabIndex = 14;
		((Control)label14).Text = "TEMPC";
		((Control)label15).AutoSize = true;
		((Control)label15).Location = new Point(164, 74);
		((Control)label15).Name = "label15";
		((Control)label15).Size = new Size(49, 17);
		((Control)label15).TabIndex = 13;
		((Control)label15).Text = "TEMPB";
		((Control)label16).AutoSize = true;
		((Control)label16).Location = new Point(58, 74);
		((Control)label16).Name = "label16";
		((Control)label16).Size = new Size(49, 17);
		((Control)label16).TabIndex = 12;
		((Control)label16).Text = "TEMPA";
		((Control)button1).Font = new Font("微软雅黑", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)134);
		((Control)button1).Location = new Point(467, 58);
		((Control)button1).Margin = new Padding(3, 4, 3, 4);
		((Control)button1).Name = "button1";
		((Control)button1).Size = new Size(64, 44);
		((Control)button1).TabIndex = 22;
		((Control)button1).Text = "读取";
		((ButtonBase)button1).UseVisualStyleBackColor = true;
		((Control)button1).Click += button1_Click;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(7f, 17f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(629, 553);
		((Control)this).Controls.Add((Control)(object)groupBox6);
		((Control)this).Controls.Add((Control)(object)AD4设定值);
		((Control)this).Controls.Add((Control)(object)AD3设定值);
		((Control)this).Controls.Add((Control)(object)groupBox3);
		((Control)this).Controls.Add((Control)(object)groupBox2);
		((Control)this).Controls.Add((Control)(object)groupBox1);
		((Control)this).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Form)this).Margin = new Padding(3, 4, 3, 4);
		((Control)this).Name = "Form5";
		((Control)this).Text = "Form5";
		((Control)groupBox1).ResumeLayout(false);
		((Control)groupBox2).ResumeLayout(false);
		((Control)groupBox2).PerformLayout();
		((Control)groupBox3).ResumeLayout(false);
		((Control)groupBox3).PerformLayout();
		((Control)AD3设定值).ResumeLayout(false);
		((Control)AD3设定值).PerformLayout();
		((Control)AD4设定值).ResumeLayout(false);
		((Control)AD4设定值).PerformLayout();
		((Control)groupBox6).ResumeLayout(false);
		((Control)groupBox6).PerformLayout();
		((Control)this).ResumeLayout(false);
	}
}
