using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace _645ClearE;

public class zhongtai_addr_set : Form
{
	private Modbus m = new Modbus();

	private IContainer components = null;

	private GroupBox groupBox3;

	private Button Set_register;

	private Button Read_register;

	private Label label2;

	private Label label3;

	private TextBox 域名设置3;

	private TextBox 端口号3;

	private GroupBox groupBox2;

	private TextBox 域名1;

	private Label label371;

	private Label label185;

	private TextBox IP4text;

	private Label label1;

	private TextBox IP3text;

	private Label label365;

	private ComboBox 地域;

	private Button Set_IP;

	private Label label184;

	private Label label360;

	private TextBox 端口数;

	private TextBox IP2text;

	private Button Read_IP;

	private TextBox 端口号;

	private TextBox IP1text;

	private Label label183;

	private TextBox 上传间隔;

	private Label label182;

	public zhongtai_addr_set()
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

	private void Read_IP_Click(object sender, EventArgs e)
	{
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_042e: Unknown result type (might be due to invalid IL or missing references)
		//IL_041f: Unknown result type (might be due to invalid IL or missing references)
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
			catch (Exception ex2)
			{
				MessageBox.Show(ex2.Message);
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
					catch (Exception ex3)
					{
						MessageBox.Show(ex3.Message);
						return;
					}
					if (m.CheckResponse(response3))
					{
						((Control)端口数).Text = response3[3].ToString();
						((ListControl)地域).SelectedIndex = response3[7];
						MessageBox.Show("read success!");
					}
					else
					{
						MessageBox.Show("no recieve or check error");
					}
				}
			}
			else
			{
				MessageBox.Show("No reply or check error");
			}
		}
		else
		{
			MessageBox.Show("No reply or check error");
		}
	}

	private void Set_IP_Click(object sender, EventArgs e)
	{
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0374: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0624: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_039c: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0654: Unknown result type (might be due to invalid IL or missing references)
		//IL_0645: Unknown result type (might be due to invalid IL or missing references)
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
			MessageBox.Show("set failed");
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
		catch (Exception ex2)
		{
			MessageBox.Show(ex2.Message);
			return;
		}
		if (!m.CheckResponse(response2))
		{
			MessageBox.Show("set failed");
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
		catch (Exception ex3)
		{
			MessageBox.Show(ex3.Message);
			return;
		}
		if (!m.CheckResponse(response3))
		{
			MessageBox.Show("set failed");
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
			catch (Exception ex4)
			{
				MessageBox.Show(ex4.Message);
				return;
			}
			if (!m.CheckResponse(response4))
			{
				MessageBox.Show("set failed");
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
				for (int j = 0; j < num; j++)
				{
					array5[7 + bytes.Length + j] = 0;
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
				catch (Exception ex5)
				{
					MessageBox.Show(ex5.Message);
					return;
				}
				if (m.CheckResponse(response5))
				{
					MessageBox.Show("set success");
				}
				else
				{
					MessageBox.Show("set failed");
				}
			}
		}
	}

	private void Read_register_Click(object sender, EventArgs e)
	{
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		if (!CheckAddr())
		{
			return;
		}
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[155];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Parameters.Address);
		array[1] = 3;
		array[2] = 96;
		array[3] = 72;
		array[4] = 0;
		array[5] = 75;
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
			byte[] array2 = new byte[50];
			for (int i = 0; i < 50; i++)
			{
				array2[i] = response[3 + i];
			}
			text = Encoding.ASCII.GetString(array2);
			((Control)域名设置3).Text = text;
			if (CheckAddr())
			{
				Modbus.sp.DiscardOutBuffer();
				Modbus.sp.DiscardInBuffer();
				byte[] array3 = new byte[8];
				byte[] response2 = new byte[7];
				byte[] CRC2 = new byte[2];
				array3[0] = Convert.ToByte(Parameters.Address);
				array3[1] = 3;
				array3[2] = 96;
				array3[3] = 18;
				array3[4] = 0;
				array3[5] = 1;
				m.GetCRC(array3, ref CRC2);
				m.GetCRC(array3, ref CRC2);
				array3[^2] = CRC2[0];
				array3[^1] = CRC2[1];
				try
				{
					Modbus.sp.Write(array3, 0, array3.Length);
					Thread.Sleep(20);
					m.GetResponse(ref response2);
				}
				catch (Exception ex2)
				{
					MessageBox.Show(ex2.Message);
					return;
				}
				if (m.CheckResponse(response2))
				{
					((Control)端口号3).Text = ((response2[4] << 8) | response2[3]).ToString();
					MessageBox.Show("read success");
				}
				else
				{
					MessageBox.Show("No reply or check error");
				}
			}
		}
		else
		{
			MessageBox.Show("No reply or check error");
		}
	}

	private void Set_register_Click(object sender, EventArgs e)
	{
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
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
		array[3] = 18;
		array[4] = 0;
		array[5] = 1;
		array[6] = 2;
		array[8] = (byte)(Convert.ToInt32(((Control)端口号3).Text) >> 8);
		array[7] = (byte)Convert.ToInt32(((Control)端口号3).Text);
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
			MessageBox.Show("set failed");
		}
		else if (CheckAddr())
		{
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array2 = new byte[89];
			byte[] response2 = new byte[8];
			byte[] CRC2 = new byte[2];
			array2[0] = Convert.ToByte(Parameters.Address);
			array2[1] = 16;
			array2[2] = 96;
			array2[3] = 72;
			array2[4] = 0;
			array2[5] = 40;
			array2[6] = 80;
			string s = Convert.ToString(((Control)域名设置3).Text);
			byte[] bytes = Encoding.ASCII.GetBytes(s);
			int num = 50 - bytes.Length;
			for (int i = 0; i < bytes.Length; i++)
			{
				array2[7 + i] = bytes[i];
			}
			for (int j = 0; j < num; j++)
			{
				array2[7 + bytes.Length + j] = 0;
			}
			m.GetCRC(array2, ref CRC2);
			array2[^2] = CRC2[0];
			array2[^1] = CRC2[1];
			try
			{
				Modbus.sp.Write(array2, 0, array2.Length);
				Thread.Sleep(20);
				m.GetResponse(ref response2);
			}
			catch (Exception ex2)
			{
				MessageBox.Show(ex2.Message);
				return;
			}
			if (m.CheckResponse(response2))
			{
				MessageBox.Show("set success");
			}
			else
			{
				MessageBox.Show("set failed");
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
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected Obj, but got Unknown
		//IL_06ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f4: Expected Obj, but got Unknown
		//IL_091f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0929: Expected Obj, but got Unknown
		groupBox3 = new GroupBox();
		Set_register = new Button();
		Read_register = new Button();
		label2 = new Label();
		label3 = new Label();
		域名设置3 = new TextBox();
		端口号3 = new TextBox();
		groupBox2 = new GroupBox();
		域名1 = new TextBox();
		label371 = new Label();
		label185 = new Label();
		IP4text = new TextBox();
		label1 = new Label();
		IP3text = new TextBox();
		label365 = new Label();
		地域 = new ComboBox();
		Set_IP = new Button();
		label184 = new Label();
		label360 = new Label();
		端口数 = new TextBox();
		IP2text = new TextBox();
		Read_IP = new Button();
		端口号 = new TextBox();
		IP1text = new TextBox();
		label183 = new Label();
		上传间隔 = new TextBox();
		label182 = new Label();
		((Control)groupBox3).SuspendLayout();
		((Control)groupBox2).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)groupBox3).Controls.Add((Control)(object)Set_register);
		((Control)groupBox3).Controls.Add((Control)(object)Read_register);
		((Control)groupBox3).Controls.Add((Control)(object)label2);
		((Control)groupBox3).Controls.Add((Control)(object)label3);
		((Control)groupBox3).Controls.Add((Control)(object)域名设置3);
		((Control)groupBox3).Controls.Add((Control)(object)端口号3);
		((Control)groupBox3).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)groupBox3).Location = new Point(12, 205);
		((Control)groupBox3).Name = "groupBox3";
		((Control)groupBox3).Size = new Size(355, 178);
		((Control)groupBox3).TabIndex = 87;
		groupBox3.TabStop = false;
		((Control)groupBox3).Text = "register";
		((ButtonBase)Set_register).ImeMode = (ImeMode)0;
		((Control)Set_register).Location = new Point(282, 148);
		((Control)Set_register).Name = "Set_register";
		((Control)Set_register).Size = new Size(55, 23);
		((Control)Set_register).TabIndex = 84;
		((Control)Set_register).Text = "Set";
		((ButtonBase)Set_register).UseVisualStyleBackColor = true;
		((Control)Set_register).Click += Set_register_Click;
		((ButtonBase)Read_register).ImeMode = (ImeMode)0;
		((Control)Read_register).Location = new Point(40, 148);
		((Control)Read_register).Name = "Read_register";
		((Control)Read_register).Size = new Size(55, 23);
		((Control)Read_register).TabIndex = 83;
		((Control)Read_register).Text = "Read";
		((ButtonBase)Read_register).UseVisualStyleBackColor = true;
		((Control)Read_register).Click += Read_register_Click;
		((Control)label2).AutoSize = true;
		label2.ImeMode = (ImeMode)0;
		((Control)label2).Location = new Point(13, 35);
		((Control)label2).Name = "label2";
		((Control)label2).Size = new Size(98, 17);
		((Control)label2).TabIndex = 79;
		((Control)label2).Text = "register_addr：";
		((Control)label3).AutoSize = true;
		label3.ImeMode = (ImeMode)0;
		((Control)label3).Location = new Point(13, 98);
		((Control)label3).Name = "label3";
		((Control)label3).Size = new Size(95, 17);
		((Control)label3).TabIndex = 81;
		((Control)label3).Text = "register_port：";
		((Control)域名设置3).Location = new Point(111, 32);
		((TextBoxBase)域名设置3).MaxLength = 50;
		((Control)域名设置3).Name = "域名设置3";
		((Control)域名设置3).Size = new Size(229, 23);
		((Control)域名设置3).TabIndex = 80;
		((Control)端口号3).Location = new Point(111, 92);
		((TextBoxBase)端口号3).MaxLength = 6;
		((Control)端口号3).Name = "端口号3";
		((Control)端口号3).Size = new Size(73, 23);
		((Control)端口号3).TabIndex = 82;
		((Control)groupBox2).Controls.Add((Control)(object)域名1);
		((Control)groupBox2).Controls.Add((Control)(object)label371);
		((Control)groupBox2).Controls.Add((Control)(object)label185);
		((Control)groupBox2).Controls.Add((Control)(object)IP4text);
		((Control)groupBox2).Controls.Add((Control)(object)label1);
		((Control)groupBox2).Controls.Add((Control)(object)IP3text);
		((Control)groupBox2).Controls.Add((Control)(object)label365);
		((Control)groupBox2).Controls.Add((Control)(object)地域);
		((Control)groupBox2).Controls.Add((Control)(object)Set_IP);
		((Control)groupBox2).Controls.Add((Control)(object)label184);
		((Control)groupBox2).Controls.Add((Control)(object)label360);
		((Control)groupBox2).Controls.Add((Control)(object)端口数);
		((Control)groupBox2).Controls.Add((Control)(object)IP2text);
		((Control)groupBox2).Controls.Add((Control)(object)Read_IP);
		((Control)groupBox2).Controls.Add((Control)(object)端口号);
		((Control)groupBox2).Controls.Add((Control)(object)IP1text);
		((Control)groupBox2).Controls.Add((Control)(object)label183);
		((Control)groupBox2).Controls.Add((Control)(object)上传间隔);
		((Control)groupBox2).Controls.Add((Control)(object)label182);
		((Control)groupBox2).Font = new Font("微软雅黑", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)134);
		((Control)groupBox2).Location = new Point(12, 12);
		((Control)groupBox2).Name = "groupBox2";
		((Control)groupBox2).Size = new Size(355, 177);
		((Control)groupBox2).TabIndex = 86;
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
		((Control)label185).AutoSize = true;
		label185.ImeMode = (ImeMode)0;
		((Control)label185).Location = new Point(10, 52);
		((Control)label185).Name = "label185";
		((Control)label185).Size = new Size(31, 17);
		((Control)label185).TabIndex = 4;
		((Control)label185).Text = "IP：";
		((Control)IP4text).Location = new Point(185, 49);
		((TextBoxBase)IP4text).MaxLength = 3;
		((Control)IP4text).Name = "IP4text";
		((Control)IP4text).Size = new Size(37, 23);
		((Control)IP4text).TabIndex = 8;
		((Control)label1).AutoSize = true;
		((Control)label1).Font = new Font("微软雅黑", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)134);
		label1.ImeMode = (ImeMode)0;
		((Control)label1).Location = new Point(263, 112);
		((Control)label1).Name = "label1";
		((Control)label1).Size = new Size(89, 17);
		((Control)label1).TabIndex = 77;
		((Control)label1).Text = "（Default 1）";
		((Control)label1).Visible = false;
		((Control)IP3text).Location = new Point(147, 49);
		((TextBoxBase)IP3text).MaxLength = 3;
		((Control)IP3text).Name = "IP3text";
		((Control)IP3text).Size = new Size(37, 23);
		((Control)IP3text).TabIndex = 7;
		((Control)label365).AutoSize = true;
		label365.ImeMode = (ImeMode)0;
		((Control)label365).Location = new Point(10, 19);
		((Control)label365).Name = "label365";
		((Control)label365).Size = new Size(120, 17);
		((Control)label365).TabIndex = 68;
		((Control)label365).Text = "IP/Domain Name：";
		地域.DropDownStyle = (ComboBoxStyle)2;
		((ListControl)地域).FormattingEnabled = true;
		地域.Items.AddRange(new object[2] { "IP-Connect", "Domain" });
		((Control)地域).Location = new Point(132, 16);
		((Control)地域).Name = "地域";
		((Control)地域).Size = new Size(90, 25);
		((Control)地域).TabIndex = 67;
		((ButtonBase)Set_IP).ImeMode = (ImeMode)0;
		((Control)Set_IP).Location = new Point(282, 148);
		((Control)Set_IP).Name = "Set_IP";
		((Control)Set_IP).Size = new Size(55, 23);
		((Control)Set_IP).TabIndex = 76;
		((Control)Set_IP).Text = "Set";
		((ButtonBase)Set_IP).UseVisualStyleBackColor = true;
		((Control)Set_IP).Click += Set_IP_Click;
		((Control)label184).AutoSize = true;
		label184.ImeMode = (ImeMode)0;
		((Control)label184).Location = new Point(10, 112);
		((Control)label184).Name = "label184";
		((Control)label184).Size = new Size(44, 17);
		((Control)label184).TabIndex = 9;
		((Control)label184).Text = "Port：";
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
		((Control)IP2text).Location = new Point(108, 49);
		((TextBoxBase)IP2text).MaxLength = 3;
		((Control)IP2text).Name = "IP2text";
		((Control)IP2text).Size = new Size(37, 23);
		((Control)IP2text).TabIndex = 5;
		((ButtonBase)Read_IP).ImeMode = (ImeMode)0;
		((Control)Read_IP).Location = new Point(221, 148);
		((Control)Read_IP).Name = "Read_IP";
		((Control)Read_IP).Size = new Size(55, 23);
		((Control)Read_IP).TabIndex = 75;
		((Control)Read_IP).Text = "Read";
		((ButtonBase)Read_IP).UseVisualStyleBackColor = true;
		((Control)Read_IP).Click += Read_IP_Click;
		((Control)端口号).Location = new Point(54, 109);
		((TextBoxBase)端口号).MaxLength = 6;
		((Control)端口号).Name = "端口号";
		((Control)端口号).Size = new Size(62, 23);
		((Control)端口号).TabIndex = 10;
		((Control)IP1text).Location = new Point(69, 49);
		((TextBoxBase)IP1text).MaxLength = 3;
		((Control)IP1text).Name = "IP1text";
		((Control)IP1text).Size = new Size(37, 23);
		((Control)IP1text).TabIndex = 6;
		((Control)label183).AutoSize = true;
		label183.ImeMode = (ImeMode)0;
		((Control)label183).Location = new Point(8, 143);
		((Control)label183).Name = "label183";
		((Control)label183).Size = new Size(109, 17);
		((Control)label183).TabIndex = 11;
		((Control)label183).Text = "Upload interval：";
		((Control)上传间隔).Location = new Point(123, 140);
		((TextBoxBase)上传间隔).MaxLength = 3;
		((Control)上传间隔).Name = "上传间隔";
		((Control)上传间隔).Size = new Size(37, 23);
		((Control)上传间隔).TabIndex = 12;
		((Control)label182).AutoSize = true;
		label182.ImeMode = (ImeMode)0;
		((Control)label182).Location = new Point(166, 143);
		((Control)label182).Name = "label182";
		((Control)label182).Size = new Size(30, 17);
		((Control)label182).TabIndex = 13;
		((Control)label182).Text = "Min";
		((Control)label182).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 12f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(380, 392);
		((Control)this).Controls.Add((Control)(object)groupBox3);
		((Control)this).Controls.Add((Control)(object)groupBox2);
		((Control)this).Name = "zhongtai_addr_set";
		((Control)this).Text = "Form6";
		((Control)groupBox3).ResumeLayout(false);
		((Control)groupBox3).PerformLayout();
		((Control)groupBox2).ResumeLayout(false);
		((Control)groupBox2).PerformLayout();
		((Control)this).ResumeLayout(false);
	}
}
