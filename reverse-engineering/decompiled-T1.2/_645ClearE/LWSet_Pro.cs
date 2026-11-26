using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace _645ClearE;

public class LWSet_Pro : Form
{
	private Modbus m = new Modbus();

	private IContainer components = null;

	private TabControl tabControl1;

	private TabPage LW_Updata;

	private Label label_packettype;

	private Button button_selectpacket_set;

	private Button button_selcetpacket_read;

	private ComboBox comboBox_selectpacket;

	private GroupBox groupBox_updataset;

	private Label label1258;

	private Label label1259;

	private Label label1256;

	private Label label1257;

	private CheckBox checkBox_updata_sec;

	private CheckBox checkBox_endian;

	private CheckBox checkBox_CS;

	private Label label1215;

	private Label label1216;

	private TextBox len20;

	private TextBox len15;

	private TextBox Initialaddr20;

	private TextBox Initialaddr15;

	private Label label1217;

	private Label label1218;

	private TextBox len10;

	private TextBox len5;

	private TextBox Initialaddr10;

	private TextBox Initialaddr5;

	private Label label1219;

	private Label label1220;

	private Label label1221;

	private Label label1222;

	private Label label1223;

	private Label label1224;

	private Label label1225;

	private Label label1226;

	private Label label1227;

	private Label label1228;

	private TextBox len19;

	private TextBox len14;

	private TextBox len18;

	private TextBox len13;

	private TextBox len17;

	private TextBox len12;

	private TextBox len16;

	private TextBox len11;

	private TextBox Initialaddr19;

	private TextBox Initialaddr18;

	private TextBox Initialaddr14;

	private TextBox Initialaddr17;

	private TextBox Initialaddr13;

	private TextBox Initialaddr16;

	private TextBox Initialaddr12;

	private TextBox Initialaddr11;

	private Button SetUPdata;

	private Button ReadUPdata;

	private Label label1229;

	private TextBox UPdatanum;

	private Label label1230;

	private Label label1231;

	private Label label1232;

	private Label label1233;

	private Label label1234;

	private Label label1235;

	private Label label1236;

	private Label label1237;

	private Label label1238;

	private Label label1239;

	private TextBox len9;

	private TextBox len4;

	private TextBox len8;

	private TextBox len3;

	private TextBox len7;

	private TextBox len2;

	private TextBox len6;

	private TextBox len1;

	private TextBox Initialaddr9;

	private TextBox Initialaddr8;

	private TextBox Initialaddr4;

	private TextBox Initialaddr7;

	private TextBox Initialaddr3;

	private TextBox Initialaddr6;

	private TextBox Initialaddr2;

	private TextBox Initialaddr1;

	private TabPage Channel_Setting;

	private GroupBox groupBox1;

	private TextBox channel3;

	private TextBox channel8;

	private Label label1248;

	private TextBox channel4;

	private Label label1247;

	private Label label1240;

	private TextBox channel1;

	private Label label1241;

	private TextBox channel5;

	private TextBox channel7;

	private Label label1245;

	private Label label1244;

	private Label label1242;

	private TextBox channel2;

	private Label label1243;

	private TextBox channel6;

	private TextBox channelnum;

	private Label label1246;

	private Button ChannelSET;

	private Button ChannelREAD;

	private TabPage Rejoin_Setting;

	private Button SetNoAckLimit;

	private Button ReadNoAckLimit;

	private Label label5;

	private TextBox NoAckLimit;

	private Label label4;

	private GroupBox groupBox2;

	private Label label6;

	private Button set_clear_flag;

	private Button Read_clear_flag;

	private CheckBox check_clear_flag;

	private Button Rejoin;

	public LWSet_Pro()
	{
		InitializeComponent();
	}

	private bool CheckAddr()
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
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
		MessageBox.Show("Please open the serial port first！");
		return false;
	}

	private void button_selcetpacket_read_Click(object sender, EventArgs e)
	{
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		byte[] CRC = new byte[2];
		if (!CheckAddr())
		{
			return;
		}
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[7];
		array[0] = Convert.ToByte(Parameters.Address);
		array[1] = 3;
		array[2] = 100;
		array[3] = 86;
		array[4] = 0;
		array[5] = 1;
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
			MessageBox.Show(" Please confirm the serial port and address settings");
			return;
		}
		if (m.CheckResponse(response))
		{
			if (response[4] < 2)
			{
				((ListControl)comboBox_selectpacket).SelectedIndex = response[4];
				MessageBox.Show("Read successfully");
			}
			else
			{
				MessageBox.Show("wrong parameters");
			}
		}
		else
		{
			MessageBox.Show("No reply");
		}
	}

	private void button_selectpacket_set_Click(object sender, EventArgs e)
	{
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		byte[] CRC = new byte[2];
		if (CheckAddr())
		{
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array = new byte[11];
			byte[] response = new byte[8];
			array[0] = Convert.ToByte(Parameters.Address);
			array[1] = 16;
			array[2] = 100;
			array[3] = 86;
			array[4] = 0;
			array[5] = 1;
			array[6] = 2;
			array[7] = 0;
			array[8] = (byte)((ListControl)comboBox_selectpacket).SelectedIndex;
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

	private void ReadUPdata_Click(object sender, EventArgs e)
	{
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a3: Unknown result type (might be due to invalid IL or missing references)
		if (!CheckAddr())
		{
			return;
		}
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[93];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Parameters.Address);
		array[1] = 3;
		array[2] = 100;
		array[3] = 41;
		array[4] = 0;
		array[5] = 44;
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
			MessageBox.Show(" Please confirm the serial port and address settings");
			return;
		}
		if (m.CheckResponse(response))
		{
			if (Parameters.IsUse485)
			{
			}
			((Control)UPdatanum).Text = response[4].ToString();
			((Control)Initialaddr1).Text = (response[6] | (response[5] << 8)).ToString();
			((Control)len1).Text = (response[8] | (response[7] << 8)).ToString();
			((Control)Initialaddr2).Text = (response[10] | (response[9] << 8)).ToString();
			((Control)len2).Text = (response[12] | (response[11] << 8)).ToString();
			((Control)Initialaddr3).Text = (response[14] | (response[13] << 8)).ToString();
			((Control)len3).Text = (response[16] | (response[15] << 8)).ToString();
			((Control)Initialaddr4).Text = (response[18] | (response[17] << 8)).ToString();
			((Control)len4).Text = (response[20] | (response[19] << 8)).ToString();
			((Control)Initialaddr5).Text = (response[22] | (response[21] << 8)).ToString();
			((Control)len5).Text = (response[24] | (response[23] << 8)).ToString();
			((Control)Initialaddr6).Text = (response[26] | (response[25] << 8)).ToString();
			((Control)len6).Text = (response[28] | (response[27] << 8)).ToString();
			((Control)Initialaddr7).Text = (response[30] | (response[29] << 8)).ToString();
			((Control)len7).Text = (response[32] | (response[31] << 8)).ToString();
			((Control)Initialaddr8).Text = (response[34] | (response[33] << 8)).ToString();
			((Control)len8).Text = (response[36] | (response[35] << 8)).ToString();
			((Control)Initialaddr9).Text = (response[38] | (response[37] << 8)).ToString();
			((Control)len9).Text = (response[40] | (response[39] << 8)).ToString();
			((Control)Initialaddr10).Text = (response[42] | (response[41] << 8)).ToString();
			((Control)len10).Text = (response[44] | (response[43] << 8)).ToString();
			((Control)Initialaddr11).Text = (response[46] | (response[45] << 8)).ToString();
			((Control)len11).Text = (response[48] | (response[47] << 8)).ToString();
			((Control)Initialaddr12).Text = (response[50] | (response[49] << 8)).ToString();
			((Control)len12).Text = (response[52] | (response[51] << 8)).ToString();
			((Control)Initialaddr13).Text = (response[54] | (response[53] << 8)).ToString();
			((Control)len13).Text = (response[56] | (response[55] << 8)).ToString();
			((Control)Initialaddr14).Text = (response[58] | (response[57] << 8)).ToString();
			((Control)len14).Text = (response[60] | (response[59] << 8)).ToString();
			((Control)Initialaddr15).Text = (response[62] | (response[61] << 8)).ToString();
			((Control)len15).Text = (response[64] | (response[63] << 8)).ToString();
			((Control)Initialaddr16).Text = (response[66] | (response[65] << 8)).ToString();
			((Control)len16).Text = (response[68] | (response[67] << 8)).ToString();
			((Control)Initialaddr17).Text = (response[70] | (response[69] << 8)).ToString();
			((Control)len17).Text = (response[72] | (response[71] << 8)).ToString();
			((Control)Initialaddr18).Text = (response[74] | (response[73] << 8)).ToString();
			((Control)len18).Text = (response[76] | (response[75] << 8)).ToString();
			((Control)Initialaddr19).Text = (response[78] | (response[77] << 8)).ToString();
			((Control)len19).Text = (response[80] | (response[79] << 8)).ToString();
			((Control)Initialaddr20).Text = (response[82] | (response[81] << 8)).ToString();
			((Control)len20).Text = (response[84] | (response[83] << 8)).ToString();
			if (response[86] > 0)
			{
				checkBox_CS.Checked = true;
			}
			else
			{
				checkBox_CS.Checked = false;
			}
			if (response[88] > 0)
			{
				checkBox_endian.Checked = true;
			}
			else
			{
				checkBox_endian.Checked = false;
			}
			if (response[90] > 0)
			{
				checkBox_updata_sec.Checked = true;
			}
			else
			{
				checkBox_updata_sec.Checked = false;
			}
			MessageBox.Show("Read successfully");
		}
		else
		{
			MessageBox.Show("No reply");
		}
	}

	private void SetUPdata_Click(object sender, EventArgs e)
	{
		//IL_093c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0947: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0976: Unknown result type (might be due to invalid IL or missing references)
		//IL_0967: Unknown result type (might be due to invalid IL or missing references)
		Parameters.MessageType = 31;
		byte[] CRC = new byte[2];
		if (!CheckAddr())
		{
			return;
		}
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[97];
		byte[] response = new byte[8];
		if (((Control)len1).Text == "" && ((Control)len2).Text == "" && ((Control)len3).Text == "" && ((Control)len4).Text == "" && ((Control)len5).Text == "" && ((Control)len6).Text == "" && ((Control)len7).Text == "" && ((Control)len8).Text == "" && ((Control)len9).Text == "" && ((Control)len10).Text == "")
		{
			MessageBox.Show("Can't be empty!");
			return;
		}
		array[0] = Convert.ToByte(Parameters.Address);
		array[1] = 16;
		array[2] = 100;
		array[3] = 41;
		array[4] = 0;
		array[5] = 44;
		array[6] = 68;
		array[7] = 0;
		array[8] = (byte)Convert.ToInt16(((Control)UPdatanum).Text);
		array[9] = (byte)(Convert.ToInt32(((Control)Initialaddr1).Text) >> 8);
		array[10] = (byte)Convert.ToInt32(((Control)Initialaddr1).Text);
		array[11] = (byte)(Convert.ToInt32(((Control)len1).Text) >> 8);
		array[12] = (byte)Convert.ToInt32(((Control)len1).Text);
		array[13] = (byte)(Convert.ToInt32(((Control)Initialaddr2).Text) >> 8);
		array[14] = (byte)Convert.ToInt32(((Control)Initialaddr2).Text);
		array[15] = (byte)(Convert.ToInt32(((Control)len2).Text) >> 8);
		array[16] = (byte)Convert.ToInt32(((Control)len2).Text);
		array[17] = (byte)(Convert.ToInt32(((Control)Initialaddr3).Text) >> 8);
		array[18] = (byte)Convert.ToInt32(((Control)Initialaddr3).Text);
		array[19] = (byte)(Convert.ToInt32(((Control)len3).Text) >> 8);
		array[20] = (byte)Convert.ToInt32(((Control)len3).Text);
		array[21] = (byte)(Convert.ToInt32(((Control)Initialaddr4).Text) >> 8);
		array[22] = (byte)Convert.ToInt32(((Control)Initialaddr4).Text);
		array[23] = (byte)(Convert.ToInt32(((Control)len4).Text) >> 8);
		array[24] = (byte)Convert.ToInt32(((Control)len4).Text);
		array[25] = (byte)(Convert.ToInt32(((Control)Initialaddr5).Text) >> 8);
		array[26] = (byte)Convert.ToInt32(((Control)Initialaddr5).Text);
		array[27] = (byte)(Convert.ToInt32(((Control)len5).Text) >> 8);
		array[28] = (byte)Convert.ToInt32(((Control)len5).Text);
		array[29] = (byte)(Convert.ToInt32(((Control)Initialaddr6).Text) >> 8);
		array[30] = (byte)Convert.ToInt32(((Control)Initialaddr6).Text);
		array[31] = (byte)(Convert.ToInt32(((Control)len6).Text) >> 8);
		array[32] = (byte)Convert.ToInt32(((Control)len6).Text);
		array[33] = (byte)(Convert.ToInt32(((Control)Initialaddr7).Text) >> 8);
		array[34] = (byte)Convert.ToInt32(((Control)Initialaddr7).Text);
		array[35] = (byte)(Convert.ToInt32(((Control)len7).Text) >> 8);
		array[36] = (byte)Convert.ToInt32(((Control)len7).Text);
		array[37] = (byte)(Convert.ToInt32(((Control)Initialaddr8).Text) >> 8);
		array[38] = (byte)Convert.ToInt32(((Control)Initialaddr8).Text);
		array[39] = (byte)(Convert.ToInt32(((Control)len8).Text) >> 8);
		array[40] = (byte)Convert.ToInt32(((Control)len8).Text);
		array[41] = (byte)(Convert.ToInt32(((Control)Initialaddr9).Text) >> 8);
		array[42] = (byte)Convert.ToInt32(((Control)Initialaddr9).Text);
		array[43] = (byte)(Convert.ToInt32(((Control)len9).Text) >> 8);
		array[44] = (byte)Convert.ToInt32(((Control)len9).Text);
		array[45] = (byte)(Convert.ToInt32(((Control)Initialaddr10).Text) >> 8);
		array[46] = (byte)Convert.ToInt32(((Control)Initialaddr10).Text);
		array[47] = (byte)(Convert.ToInt32(((Control)len10).Text) >> 8);
		array[48] = (byte)Convert.ToInt32(((Control)len10).Text);
		array[49] = (byte)(Convert.ToInt32(((Control)Initialaddr11).Text) >> 8);
		array[50] = (byte)Convert.ToInt32(((Control)Initialaddr11).Text);
		array[51] = (byte)(Convert.ToInt32(((Control)len11).Text) >> 8);
		array[52] = (byte)Convert.ToInt32(((Control)len11).Text);
		array[53] = (byte)(Convert.ToInt32(((Control)Initialaddr12).Text) >> 8);
		array[54] = (byte)Convert.ToInt32(((Control)Initialaddr12).Text);
		array[55] = (byte)(Convert.ToInt32(((Control)len12).Text) >> 8);
		array[56] = (byte)Convert.ToInt32(((Control)len12).Text);
		array[57] = (byte)(Convert.ToInt32(((Control)Initialaddr13).Text) >> 8);
		array[58] = (byte)Convert.ToInt32(((Control)Initialaddr13).Text);
		array[59] = (byte)(Convert.ToInt32(((Control)len13).Text) >> 8);
		array[60] = (byte)Convert.ToInt32(((Control)len13).Text);
		array[61] = (byte)(Convert.ToInt32(((Control)Initialaddr14).Text) >> 8);
		array[62] = (byte)Convert.ToInt32(((Control)Initialaddr14).Text);
		array[63] = (byte)(Convert.ToInt32(((Control)len14).Text) >> 8);
		array[64] = (byte)Convert.ToInt32(((Control)len14).Text);
		array[65] = (byte)(Convert.ToInt32(((Control)Initialaddr15).Text) >> 8);
		array[66] = (byte)Convert.ToInt32(((Control)Initialaddr15).Text);
		array[67] = (byte)(Convert.ToInt32(((Control)len15).Text) >> 8);
		array[68] = (byte)Convert.ToInt32(((Control)len15).Text);
		array[69] = (byte)(Convert.ToInt32(((Control)Initialaddr16).Text) >> 8);
		array[70] = (byte)Convert.ToInt32(((Control)Initialaddr16).Text);
		array[71] = (byte)(Convert.ToInt32(((Control)len16).Text) >> 8);
		array[72] = (byte)Convert.ToInt32(((Control)len16).Text);
		array[73] = (byte)(Convert.ToInt32(((Control)Initialaddr17).Text) >> 8);
		array[74] = (byte)Convert.ToInt32(((Control)Initialaddr17).Text);
		array[75] = (byte)(Convert.ToInt32(((Control)len17).Text) >> 8);
		array[76] = (byte)Convert.ToInt32(((Control)len17).Text);
		array[77] = (byte)(Convert.ToInt32(((Control)Initialaddr18).Text) >> 8);
		array[78] = (byte)Convert.ToInt32(((Control)Initialaddr18).Text);
		array[79] = (byte)(Convert.ToInt32(((Control)len18).Text) >> 8);
		array[80] = (byte)Convert.ToInt32(((Control)len18).Text);
		array[81] = (byte)(Convert.ToInt32(((Control)Initialaddr19).Text) >> 8);
		array[82] = (byte)Convert.ToInt32(((Control)Initialaddr19).Text);
		array[83] = (byte)(Convert.ToInt32(((Control)len19).Text) >> 8);
		array[84] = (byte)Convert.ToInt32(((Control)len19).Text);
		array[85] = (byte)(Convert.ToInt32(((Control)Initialaddr20).Text) >> 8);
		array[86] = (byte)Convert.ToInt32(((Control)Initialaddr20).Text);
		array[87] = (byte)(Convert.ToInt32(((Control)len20).Text) >> 8);
		array[88] = (byte)Convert.ToInt32(((Control)len20).Text);
		array[89] = 0;
		if (checkBox_CS.Checked)
		{
			array[90] = 1;
		}
		else
		{
			array[90] = 0;
		}
		array[91] = 0;
		if (checkBox_endian.Checked)
		{
			array[92] = 1;
		}
		else
		{
			array[92] = 0;
		}
		array[93] = 0;
		if (checkBox_updata_sec.Checked)
		{
			array[94] = 1;
		}
		else
		{
			array[94] = 0;
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
			MessageBox.Show(" Please confirm the serial port and address settings");
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

	private void ChannelREAD_Click(object sender, EventArgs e)
	{
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		if (!CheckAddr())
		{
			return;
		}
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[87];
		byte[] CRC = new byte[2];
		array[0] = Convert.ToByte(Parameters.Address);
		array[1] = 3;
		array[2] = 99;
		array[3] = 133;
		array[4] = 0;
		array[5] = 41;
		m.GetCRC(array, ref CRC);
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
			MessageBox.Show(ex.Message);
			return;
		}
		if (m.CheckResponse(response))
		{
			if (Parameters.IsUse485)
			{
			}
			byte[] array2 = new byte[80];
			for (int i = 0; i < 80; i++)
			{
				array2[i] = response[5 + i];
			}
			((Control)channel1).Text = Encoding.ASCII.GetString(array2, 0, 9);
			((Control)channel2).Text = Encoding.ASCII.GetString(array2, 10, 9);
			((Control)channel3).Text = Encoding.ASCII.GetString(array2, 20, 9);
			((Control)channel4).Text = Encoding.ASCII.GetString(array2, 30, 9);
			((Control)channel5).Text = Encoding.ASCII.GetString(array2, 40, 9);
			((Control)channel6).Text = Encoding.ASCII.GetString(array2, 50, 9);
			((Control)channel7).Text = Encoding.ASCII.GetString(array2, 60, 9);
			((Control)channel8).Text = Encoding.ASCII.GetString(array2, 70, 9);
			((Control)channelnum).Text = response[4].ToString();
			MessageBox.Show("Read successfully");
		}
		else
		{
			MessageBox.Show("No reply");
		}
	}

	private void ChannelSET_Click(object sender, EventArgs e)
	{
		//IL_036a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0399: Unknown result type (might be due to invalid IL or missing references)
		//IL_038a: Unknown result type (might be due to invalid IL or missing references)
		byte[] CRC = new byte[2];
		if (CheckAddr())
		{
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array = new byte[91];
			byte[] response = new byte[8];
			array[0] = Convert.ToByte(Parameters.Address);
			array[1] = 16;
			array[2] = 99;
			array[3] = 133;
			array[4] = 0;
			array[5] = 41;
			array[6] = 80;
			array[7] = 0;
			array[8] = Convert.ToByte(((Control)channelnum).Text);
			string s = Convert.ToString(((Control)channel1).Text);
			byte[] bytes = Encoding.ASCII.GetBytes(s);
			int num = 10 - bytes.Length;
			for (int i = 0; i < bytes.Length; i++)
			{
				array[9 + i] = bytes[i];
			}
			string s2 = Convert.ToString(((Control)channel2).Text);
			byte[] bytes2 = Encoding.ASCII.GetBytes(s2);
			int num2 = 10 - bytes2.Length;
			for (int j = 0; j < bytes2.Length; j++)
			{
				array[19 + j] = bytes2[j];
			}
			s = Convert.ToString(((Control)channel3).Text);
			bytes = Encoding.ASCII.GetBytes(s);
			for (int k = 0; k < bytes.Length; k++)
			{
				array[29 + k] = bytes[k];
			}
			s2 = Convert.ToString(((Control)channel4).Text);
			bytes2 = Encoding.ASCII.GetBytes(s2);
			num2 = 10 - bytes2.Length;
			for (int l = 0; l < bytes2.Length; l++)
			{
				array[39 + l] = bytes2[l];
			}
			s = Convert.ToString(((Control)channel5).Text);
			bytes = Encoding.ASCII.GetBytes(s);
			for (int m = 0; m < bytes.Length; m++)
			{
				array[49 + m] = bytes[m];
			}
			s2 = Convert.ToString(((Control)channel6).Text);
			bytes2 = Encoding.ASCII.GetBytes(s2);
			num2 = 10 - bytes2.Length;
			for (int n = 0; n < bytes2.Length; n++)
			{
				array[59 + n] = bytes2[n];
			}
			s = Convert.ToString(((Control)channel7).Text);
			bytes = Encoding.ASCII.GetBytes(s);
			for (int num3 = 0; num3 < bytes.Length; num3++)
			{
				array[69 + num3] = bytes[num3];
			}
			s2 = Convert.ToString(((Control)channel8).Text);
			bytes2 = Encoding.ASCII.GetBytes(s2);
			num2 = 10 - bytes2.Length;
			for (int num4 = 0; num4 < bytes2.Length; num4++)
			{
				array[79 + num4] = bytes2[num4];
			}
			for (int num5 = 0; num5 < array[8] - 1; num5++)
			{
				array[18 + 10 * num5] = 44;
			}
			array[^3] = 0;
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
				MessageBox.Show(ex.Message);
				return;
			}
			if (this.m.CheckResponse(response))
			{
				MessageBox.Show("Set successfully");
			}
			else
			{
				MessageBox.Show("Set failed");
			}
		}
	}

	private void ReadNoAckLimit_Click(object sender, EventArgs e)
	{
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		byte[] CRC = new byte[2];
		if (CheckAddr())
		{
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array = new byte[8];
			byte[] response = new byte[7];
			array[0] = Convert.ToByte(Parameters.Address);
			array[1] = 3;
			array[2] = 100;
			array[3] = 87;
			array[4] = 0;
			array[5] = 1;
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
				MessageBox.Show(" Please confirm the serial port and address settings");
				return;
			}
			if (m.CheckResponse(response))
			{
				((Control)NoAckLimit).Text = (response[4] | (response[3] << 8)).ToString();
				MessageBox.Show("Read successfully");
			}
			else
			{
				MessageBox.Show("No reply");
			}
		}
	}

	private void SetNoAckLimit_Click(object sender, EventArgs e)
	{
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		byte[] CRC = new byte[2];
		if (CheckAddr())
		{
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array = new byte[11];
			byte[] response = new byte[8];
			array[0] = Convert.ToByte(Parameters.Address);
			array[1] = 16;
			array[2] = 100;
			array[3] = 87;
			array[4] = 0;
			array[5] = 1;
			array[6] = 2;
			array[7] = (byte)(Convert.ToInt32(((Control)NoAckLimit).Text) >> 8);
			array[8] = (byte)Convert.ToInt32(((Control)NoAckLimit).Text);
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

	private void Read_clear_flag_Click(object sender, EventArgs e)
	{
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		byte[] CRC = new byte[2];
		if (!CheckAddr())
		{
			return;
		}
		Modbus.sp.DiscardOutBuffer();
		Modbus.sp.DiscardInBuffer();
		byte[] array = new byte[8];
		byte[] response = new byte[7];
		array[0] = Convert.ToByte(Parameters.Address);
		array[1] = 3;
		array[2] = 100;
		array[3] = 88;
		array[4] = 0;
		array[5] = 1;
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
			MessageBox.Show(" Please confirm the serial port and address settings");
			return;
		}
		if (m.CheckResponse(response))
		{
			if (response[4] == 1)
			{
				check_clear_flag.Checked = true;
			}
			else
			{
				check_clear_flag.Checked = false;
			}
			MessageBox.Show("Read successfully");
		}
		else
		{
			MessageBox.Show("No reply");
		}
	}

	private void set_clear_flag_Click(object sender, EventArgs e)
	{
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		byte[] CRC = new byte[2];
		if (CheckAddr())
		{
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array = new byte[11];
			byte[] response = new byte[8];
			array[0] = Convert.ToByte(Parameters.Address);
			array[1] = 16;
			array[2] = 100;
			array[3] = 88;
			array[4] = 0;
			array[5] = 1;
			array[6] = 2;
			array[7] = 0;
			if (check_clear_flag.Checked)
			{
				array[8] = 1;
			}
			else
			{
				array[8] = 0;
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

	private void Rejoin_Click(object sender, EventArgs e)
	{
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		byte[] CRC = new byte[2];
		if (CheckAddr())
		{
			Modbus.sp.DiscardOutBuffer();
			Modbus.sp.DiscardInBuffer();
			byte[] array = new byte[11];
			byte[] response = new byte[8];
			array[0] = Convert.ToByte(Parameters.Address);
			array[1] = 16;
			array[2] = 99;
			array[3] = 100;
			array[4] = 0;
			array[5] = 1;
			array[6] = 2;
			array[7] = 0;
			array[8] = 1;
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
		//IL_04d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04dc: Expected Obj, but got Unknown
		//IL_04dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e7: Expected Obj, but got Unknown
		//IL_04e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f2: Expected Obj, but got Unknown
		//IL_04f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fd: Expected Obj, but got Unknown
		//IL_0695: Unknown result type (might be due to invalid IL or missing references)
		//IL_340f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3419: Expected Obj, but got Unknown
		//IL_34bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_34c6: Expected Obj, but got Unknown
		tabControl1 = new TabControl();
		LW_Updata = new TabPage();
		label_packettype = new Label();
		button_selectpacket_set = new Button();
		button_selcetpacket_read = new Button();
		comboBox_selectpacket = new ComboBox();
		groupBox_updataset = new GroupBox();
		label1258 = new Label();
		label1259 = new Label();
		label1256 = new Label();
		label1257 = new Label();
		checkBox_updata_sec = new CheckBox();
		checkBox_endian = new CheckBox();
		checkBox_CS = new CheckBox();
		label1215 = new Label();
		label1216 = new Label();
		len20 = new TextBox();
		len15 = new TextBox();
		Initialaddr20 = new TextBox();
		Initialaddr15 = new TextBox();
		label1217 = new Label();
		label1218 = new Label();
		len10 = new TextBox();
		len5 = new TextBox();
		Initialaddr10 = new TextBox();
		Initialaddr5 = new TextBox();
		label1219 = new Label();
		label1220 = new Label();
		label1221 = new Label();
		label1222 = new Label();
		label1223 = new Label();
		label1224 = new Label();
		label1225 = new Label();
		label1226 = new Label();
		label1227 = new Label();
		label1228 = new Label();
		len19 = new TextBox();
		len14 = new TextBox();
		len18 = new TextBox();
		len13 = new TextBox();
		len17 = new TextBox();
		len12 = new TextBox();
		len16 = new TextBox();
		len11 = new TextBox();
		Initialaddr19 = new TextBox();
		Initialaddr18 = new TextBox();
		Initialaddr14 = new TextBox();
		Initialaddr17 = new TextBox();
		Initialaddr13 = new TextBox();
		Initialaddr16 = new TextBox();
		Initialaddr12 = new TextBox();
		Initialaddr11 = new TextBox();
		SetUPdata = new Button();
		ReadUPdata = new Button();
		label1229 = new Label();
		UPdatanum = new TextBox();
		label1230 = new Label();
		label1231 = new Label();
		label1232 = new Label();
		label1233 = new Label();
		label1234 = new Label();
		label1235 = new Label();
		label1236 = new Label();
		label1237 = new Label();
		label1238 = new Label();
		label1239 = new Label();
		len9 = new TextBox();
		len4 = new TextBox();
		len8 = new TextBox();
		len3 = new TextBox();
		len7 = new TextBox();
		len2 = new TextBox();
		len6 = new TextBox();
		len1 = new TextBox();
		Initialaddr9 = new TextBox();
		Initialaddr8 = new TextBox();
		Initialaddr4 = new TextBox();
		Initialaddr7 = new TextBox();
		Initialaddr3 = new TextBox();
		Initialaddr6 = new TextBox();
		Initialaddr2 = new TextBox();
		Initialaddr1 = new TextBox();
		Channel_Setting = new TabPage();
		groupBox1 = new GroupBox();
		channelnum = new TextBox();
		label1246 = new Label();
		ChannelSET = new Button();
		ChannelREAD = new Button();
		channel3 = new TextBox();
		channel8 = new TextBox();
		label1248 = new Label();
		channel4 = new TextBox();
		label1247 = new Label();
		label1240 = new Label();
		channel1 = new TextBox();
		label1241 = new Label();
		channel5 = new TextBox();
		channel7 = new TextBox();
		label1245 = new Label();
		label1244 = new Label();
		label1242 = new Label();
		channel2 = new TextBox();
		label1243 = new Label();
		channel6 = new TextBox();
		Rejoin_Setting = new TabPage();
		groupBox2 = new GroupBox();
		Rejoin = new Button();
		label6 = new Label();
		set_clear_flag = new Button();
		Read_clear_flag = new Button();
		check_clear_flag = new CheckBox();
		SetNoAckLimit = new Button();
		ReadNoAckLimit = new Button();
		label5 = new Label();
		NoAckLimit = new TextBox();
		label4 = new Label();
		((Control)tabControl1).SuspendLayout();
		((Control)LW_Updata).SuspendLayout();
		((Control)groupBox_updataset).SuspendLayout();
		((Control)Channel_Setting).SuspendLayout();
		((Control)groupBox1).SuspendLayout();
		((Control)Rejoin_Setting).SuspendLayout();
		((Control)groupBox2).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)tabControl1).Controls.Add((Control)(object)LW_Updata);
		((Control)tabControl1).Controls.Add((Control)(object)Channel_Setting);
		((Control)tabControl1).Controls.Add((Control)(object)Rejoin_Setting);
		((Control)tabControl1).Location = new Point(0, 0);
		((Control)tabControl1).Name = "tabControl1";
		tabControl1.SelectedIndex = 0;
		((Control)tabControl1).Size = new Size(607, 384);
		((Control)tabControl1).TabIndex = 0;
		((Control)LW_Updata).Controls.Add((Control)(object)label_packettype);
		((Control)LW_Updata).Controls.Add((Control)(object)button_selectpacket_set);
		((Control)LW_Updata).Controls.Add((Control)(object)button_selcetpacket_read);
		((Control)LW_Updata).Controls.Add((Control)(object)comboBox_selectpacket);
		((Control)LW_Updata).Controls.Add((Control)(object)groupBox_updataset);
		LW_Updata.Location = new Point(4, 22);
		((Control)LW_Updata).Name = "LW_Updata";
		((Control)LW_Updata).Padding = new Padding(3);
		((Control)LW_Updata).Size = new Size(599, 358);
		LW_Updata.TabIndex = 0;
		((Control)LW_Updata).Text = "Updata Setting";
		LW_Updata.UseVisualStyleBackColor = true;
		((Control)label_packettype).AutoSize = true;
		label_packettype.ImeMode = (ImeMode)0;
		((Control)label_packettype).Location = new Point(17, 17);
		((Control)label_packettype).Name = "label_packettype";
		((Control)label_packettype).Size = new Size(83, 12);
		((Control)label_packettype).TabIndex = 194;
		((Control)label_packettype).Text = "Packet Type :";
		((ButtonBase)button_selectpacket_set).ImeMode = (ImeMode)0;
		((Control)button_selectpacket_set).Location = new Point(285, 41);
		((Control)button_selectpacket_set).Name = "button_selectpacket_set";
		((Control)button_selectpacket_set).Size = new Size(55, 23);
		((Control)button_selectpacket_set).TabIndex = 193;
		((Control)button_selectpacket_set).Text = "SET";
		((ButtonBase)button_selectpacket_set).UseVisualStyleBackColor = true;
		((Control)button_selectpacket_set).Click += button_selectpacket_set_Click;
		((ButtonBase)button_selcetpacket_read).ImeMode = (ImeMode)0;
		((Control)button_selcetpacket_read).Location = new Point(213, 41);
		((Control)button_selcetpacket_read).Name = "button_selcetpacket_read";
		((Control)button_selcetpacket_read).Size = new Size(55, 23);
		((Control)button_selcetpacket_read).TabIndex = 192;
		((Control)button_selcetpacket_read).Text = "READ";
		((ButtonBase)button_selcetpacket_read).UseVisualStyleBackColor = true;
		((Control)button_selcetpacket_read).Click += button_selcetpacket_read_Click;
		((ListControl)comboBox_selectpacket).FormattingEnabled = true;
		comboBox_selectpacket.Items.AddRange(new object[3] { "Selectable Data Packet", "Fixed Packet Of 2526", "Real Data for One Packet" });
		((Control)comboBox_selectpacket).Location = new Point(13, 44);
		((Control)comboBox_selectpacket).Name = "comboBox_selectpacket";
		((Control)comboBox_selectpacket).Size = new Size(148, 20);
		((Control)comboBox_selectpacket).TabIndex = 191;
		((Control)groupBox_updataset).Controls.Add((Control)(object)label1258);
		((Control)groupBox_updataset).Controls.Add((Control)(object)label1259);
		((Control)groupBox_updataset).Controls.Add((Control)(object)label1256);
		((Control)groupBox_updataset).Controls.Add((Control)(object)label1257);
		((Control)groupBox_updataset).Controls.Add((Control)(object)checkBox_updata_sec);
		((Control)groupBox_updataset).Controls.Add((Control)(object)checkBox_endian);
		((Control)groupBox_updataset).Controls.Add((Control)(object)checkBox_CS);
		((Control)groupBox_updataset).Controls.Add((Control)(object)label1215);
		((Control)groupBox_updataset).Controls.Add((Control)(object)label1216);
		((Control)groupBox_updataset).Controls.Add((Control)(object)len20);
		((Control)groupBox_updataset).Controls.Add((Control)(object)len15);
		((Control)groupBox_updataset).Controls.Add((Control)(object)Initialaddr20);
		((Control)groupBox_updataset).Controls.Add((Control)(object)Initialaddr15);
		((Control)groupBox_updataset).Controls.Add((Control)(object)label1217);
		((Control)groupBox_updataset).Controls.Add((Control)(object)label1218);
		((Control)groupBox_updataset).Controls.Add((Control)(object)len10);
		((Control)groupBox_updataset).Controls.Add((Control)(object)len5);
		((Control)groupBox_updataset).Controls.Add((Control)(object)Initialaddr10);
		((Control)groupBox_updataset).Controls.Add((Control)(object)Initialaddr5);
		((Control)groupBox_updataset).Controls.Add((Control)(object)label1219);
		((Control)groupBox_updataset).Controls.Add((Control)(object)label1220);
		((Control)groupBox_updataset).Controls.Add((Control)(object)label1221);
		((Control)groupBox_updataset).Controls.Add((Control)(object)label1222);
		((Control)groupBox_updataset).Controls.Add((Control)(object)label1223);
		((Control)groupBox_updataset).Controls.Add((Control)(object)label1224);
		((Control)groupBox_updataset).Controls.Add((Control)(object)label1225);
		((Control)groupBox_updataset).Controls.Add((Control)(object)label1226);
		((Control)groupBox_updataset).Controls.Add((Control)(object)label1227);
		((Control)groupBox_updataset).Controls.Add((Control)(object)label1228);
		((Control)groupBox_updataset).Controls.Add((Control)(object)len19);
		((Control)groupBox_updataset).Controls.Add((Control)(object)len14);
		((Control)groupBox_updataset).Controls.Add((Control)(object)len18);
		((Control)groupBox_updataset).Controls.Add((Control)(object)len13);
		((Control)groupBox_updataset).Controls.Add((Control)(object)len17);
		((Control)groupBox_updataset).Controls.Add((Control)(object)len12);
		((Control)groupBox_updataset).Controls.Add((Control)(object)len16);
		((Control)groupBox_updataset).Controls.Add((Control)(object)len11);
		((Control)groupBox_updataset).Controls.Add((Control)(object)Initialaddr19);
		((Control)groupBox_updataset).Controls.Add((Control)(object)Initialaddr18);
		((Control)groupBox_updataset).Controls.Add((Control)(object)Initialaddr14);
		((Control)groupBox_updataset).Controls.Add((Control)(object)Initialaddr17);
		((Control)groupBox_updataset).Controls.Add((Control)(object)Initialaddr13);
		((Control)groupBox_updataset).Controls.Add((Control)(object)Initialaddr16);
		((Control)groupBox_updataset).Controls.Add((Control)(object)Initialaddr12);
		((Control)groupBox_updataset).Controls.Add((Control)(object)Initialaddr11);
		((Control)groupBox_updataset).Controls.Add((Control)(object)SetUPdata);
		((Control)groupBox_updataset).Controls.Add((Control)(object)ReadUPdata);
		((Control)groupBox_updataset).Controls.Add((Control)(object)label1229);
		((Control)groupBox_updataset).Controls.Add((Control)(object)UPdatanum);
		((Control)groupBox_updataset).Controls.Add((Control)(object)label1230);
		((Control)groupBox_updataset).Controls.Add((Control)(object)label1231);
		((Control)groupBox_updataset).Controls.Add((Control)(object)label1232);
		((Control)groupBox_updataset).Controls.Add((Control)(object)label1233);
		((Control)groupBox_updataset).Controls.Add((Control)(object)label1234);
		((Control)groupBox_updataset).Controls.Add((Control)(object)label1235);
		((Control)groupBox_updataset).Controls.Add((Control)(object)label1236);
		((Control)groupBox_updataset).Controls.Add((Control)(object)label1237);
		((Control)groupBox_updataset).Controls.Add((Control)(object)label1238);
		((Control)groupBox_updataset).Controls.Add((Control)(object)label1239);
		((Control)groupBox_updataset).Controls.Add((Control)(object)len9);
		((Control)groupBox_updataset).Controls.Add((Control)(object)len4);
		((Control)groupBox_updataset).Controls.Add((Control)(object)len8);
		((Control)groupBox_updataset).Controls.Add((Control)(object)len3);
		((Control)groupBox_updataset).Controls.Add((Control)(object)len7);
		((Control)groupBox_updataset).Controls.Add((Control)(object)len2);
		((Control)groupBox_updataset).Controls.Add((Control)(object)len6);
		((Control)groupBox_updataset).Controls.Add((Control)(object)len1);
		((Control)groupBox_updataset).Controls.Add((Control)(object)Initialaddr9);
		((Control)groupBox_updataset).Controls.Add((Control)(object)Initialaddr8);
		((Control)groupBox_updataset).Controls.Add((Control)(object)Initialaddr4);
		((Control)groupBox_updataset).Controls.Add((Control)(object)Initialaddr7);
		((Control)groupBox_updataset).Controls.Add((Control)(object)Initialaddr3);
		((Control)groupBox_updataset).Controls.Add((Control)(object)Initialaddr6);
		((Control)groupBox_updataset).Controls.Add((Control)(object)Initialaddr2);
		((Control)groupBox_updataset).Controls.Add((Control)(object)Initialaddr1);
		((Control)groupBox_updataset).Location = new Point(6, 81);
		((Control)groupBox_updataset).Name = "groupBox_updataset";
		((Control)groupBox_updataset).Size = new Size(586, 271);
		((Control)groupBox_updataset).TabIndex = 190;
		groupBox_updataset.TabStop = false;
		((Control)groupBox_updataset).Text = "Updata Setting";
		((Control)label1258).AutoSize = true;
		label1258.ImeMode = (ImeMode)0;
		((Control)label1258).Location = new Point(526, 27);
		((Control)label1258).Name = "label1258";
		((Control)label1258).Size = new Size(23, 12);
		((Control)label1258).TabIndex = 210;
		((Control)label1258).Text = "len";
		((Control)label1259).AutoSize = true;
		label1259.ImeMode = (ImeMode)0;
		((Control)label1259).Location = new Point(462, 27);
		((Control)label1259).Name = "label1259";
		((Control)label1259).Size = new Size(29, 12);
		((Control)label1259).TabIndex = 209;
		((Control)label1259).Text = "addr";
		((Control)label1259).UseWaitCursor = true;
		((Control)label1256).AutoSize = true;
		label1256.ImeMode = (ImeMode)0;
		((Control)label1256).Location = new Point(235, 26);
		((Control)label1256).Name = "label1256";
		((Control)label1256).Size = new Size(23, 12);
		((Control)label1256).TabIndex = 208;
		((Control)label1256).Text = "len";
		((Control)label1257).AutoSize = true;
		label1257.ImeMode = (ImeMode)0;
		((Control)label1257).Location = new Point(171, 26);
		((Control)label1257).Name = "label1257";
		((Control)label1257).Size = new Size(29, 12);
		((Control)label1257).TabIndex = 207;
		((Control)label1257).Text = "addr";
		((Control)label1257).UseWaitCursor = true;
		((Control)checkBox_updata_sec).AutoSize = true;
		((ButtonBase)checkBox_updata_sec).ImeMode = (ImeMode)0;
		((Control)checkBox_updata_sec).Location = new Point(310, 222);
		((Control)checkBox_updata_sec).Name = "checkBox_updata_sec";
		((Control)checkBox_updata_sec).Size = new Size(102, 16);
		((Control)checkBox_updata_sec).TabIndex = 206;
		((Control)checkBox_updata_sec).Text = "Updata in sec";
		((ButtonBase)checkBox_updata_sec).UseVisualStyleBackColor = true;
		((Control)checkBox_endian).AutoSize = true;
		((ButtonBase)checkBox_endian).ImeMode = (ImeMode)0;
		((Control)checkBox_endian).Location = new Point(196, 221);
		((Control)checkBox_endian).Name = "checkBox_endian";
		((Control)checkBox_endian).Size = new Size(84, 16);
		((Control)checkBox_endian).TabIndex = 205;
		((Control)checkBox_endian).Text = "Big endian";
		((ButtonBase)checkBox_endian).UseVisualStyleBackColor = true;
		((Control)checkBox_CS).AutoSize = true;
		((ButtonBase)checkBox_CS).ImeMode = (ImeMode)0;
		((Control)checkBox_CS).Location = new Point(103, 221);
		((Control)checkBox_CS).Name = "checkBox_CS";
		((Control)checkBox_CS).Size = new Size(66, 16);
		((Control)checkBox_CS).TabIndex = 204;
		((Control)checkBox_CS).Text = "Need CS";
		((ButtonBase)checkBox_CS).UseVisualStyleBackColor = true;
		((Control)label1215).AutoSize = true;
		label1215.ImeMode = (ImeMode)0;
		((Control)label1215).Location = new Point(434, 170);
		((Control)label1215).Name = "label1215";
		((Control)label1215).Size = new Size(23, 12);
		((Control)label1215).TabIndex = 203;
		((Control)label1215).Text = "20.";
		((Control)label1216).AutoSize = true;
		label1216.ImeMode = (ImeMode)0;
		((Control)label1216).Location = new Point(292, 170);
		((Control)label1216).Name = "label1216";
		((Control)label1216).Size = new Size(23, 12);
		((Control)label1216).TabIndex = 202;
		((Control)label1216).Text = "15.";
		((Control)len20).Location = new Point(521, 166);
		((Control)len20).Name = "len20";
		((Control)len20).Size = new Size(43, 21);
		((Control)len20).TabIndex = 200;
		((Control)len20).Text = "0";
		((Control)len15).Location = new Point(380, 166);
		((Control)len15).Name = "len15";
		((Control)len15).Size = new Size(43, 21);
		((Control)len15).TabIndex = 201;
		((Control)len15).Text = "0";
		((Control)Initialaddr20).Location = new Point(465, 166);
		((Control)Initialaddr20).Name = "Initialaddr20";
		((Control)Initialaddr20).Size = new Size(43, 21);
		((Control)Initialaddr20).TabIndex = 198;
		((Control)Initialaddr20).Text = "0";
		((Control)Initialaddr15).Location = new Point(323, 166);
		((Control)Initialaddr15).Name = "Initialaddr15";
		((Control)Initialaddr15).Size = new Size(43, 21);
		((Control)Initialaddr15).TabIndex = 199;
		((Control)Initialaddr15).Text = "0";
		((Control)label1217).AutoSize = true;
		label1217.ImeMode = (ImeMode)0;
		((Control)label1217).Location = new Point(146, 170);
		((Control)label1217).Name = "label1217";
		((Control)label1217).Size = new Size(23, 12);
		((Control)label1217).TabIndex = 197;
		((Control)label1217).Text = "10.";
		((Control)label1218).AutoSize = true;
		label1218.ImeMode = (ImeMode)0;
		((Control)label1218).Location = new Point(14, 170);
		((Control)label1218).Name = "label1218";
		((Control)label1218).Size = new Size(17, 12);
		((Control)label1218).TabIndex = 196;
		((Control)label1218).Text = "5.";
		((Control)len10).Location = new Point(230, 166);
		((Control)len10).Name = "len10";
		((Control)len10).Size = new Size(43, 21);
		((Control)len10).TabIndex = 194;
		((Control)len10).Text = "0";
		((Control)len5).Location = new Point(89, 166);
		((Control)len5).Name = "len5";
		((Control)len5).Size = new Size(43, 21);
		((Control)len5).TabIndex = 195;
		((Control)len5).Text = "0";
		((Control)Initialaddr10).Location = new Point(174, 166);
		((Control)Initialaddr10).Name = "Initialaddr10";
		((Control)Initialaddr10).Size = new Size(43, 21);
		((Control)Initialaddr10).TabIndex = 192;
		((Control)Initialaddr10).Text = "0";
		((Control)Initialaddr5).Location = new Point(32, 166);
		((Control)Initialaddr5).Name = "Initialaddr5";
		((Control)Initialaddr5).Size = new Size(43, 21);
		((Control)Initialaddr5).TabIndex = 193;
		((Control)Initialaddr5).Text = "0";
		((Control)label1219).AutoSize = true;
		label1219.ImeMode = (ImeMode)0;
		((Control)label1219).Location = new Point(381, 26);
		((Control)label1219).Name = "label1219";
		((Control)label1219).Size = new Size(23, 12);
		((Control)label1219).TabIndex = 191;
		((Control)label1219).Text = "len";
		((Control)label1220).AutoSize = true;
		label1220.ImeMode = (ImeMode)0;
		((Control)label1220).Location = new Point(317, 26);
		((Control)label1220).Name = "label1220";
		((Control)label1220).Size = new Size(29, 12);
		((Control)label1220).TabIndex = 190;
		((Control)label1220).Text = "addr";
		((Control)label1220).UseWaitCursor = true;
		((Control)label1221).AutoSize = true;
		label1221.ImeMode = (ImeMode)0;
		((Control)label1221).Location = new Point(434, 138);
		((Control)label1221).Name = "label1221";
		((Control)label1221).Size = new Size(23, 12);
		((Control)label1221).TabIndex = 184;
		((Control)label1221).Text = "19.";
		((Control)label1222).AutoSize = true;
		label1222.ImeMode = (ImeMode)0;
		((Control)label1222).Location = new Point(292, 138);
		((Control)label1222).Name = "label1222";
		((Control)label1222).Size = new Size(23, 12);
		((Control)label1222).TabIndex = 183;
		((Control)label1222).Text = "14.";
		((Control)label1223).AutoSize = true;
		label1223.ImeMode = (ImeMode)0;
		((Control)label1223).Location = new Point(434, 109);
		((Control)label1223).Name = "label1223";
		((Control)label1223).Size = new Size(23, 12);
		((Control)label1223).TabIndex = 182;
		((Control)label1223).Text = "18.";
		((Control)label1224).AutoSize = true;
		label1224.ImeMode = (ImeMode)0;
		((Control)label1224).Location = new Point(292, 109);
		((Control)label1224).Name = "label1224";
		((Control)label1224).Size = new Size(23, 12);
		((Control)label1224).TabIndex = 185;
		((Control)label1224).Text = "13.";
		((Control)label1225).AutoSize = true;
		label1225.ImeMode = (ImeMode)0;
		((Control)label1225).Location = new Point(434, 81);
		((Control)label1225).Name = "label1225";
		((Control)label1225).Size = new Size(23, 12);
		((Control)label1225).TabIndex = 188;
		((Control)label1225).Text = "17.";
		((Control)label1226).AutoSize = true;
		label1226.ImeMode = (ImeMode)0;
		((Control)label1226).Location = new Point(292, 81);
		((Control)label1226).Name = "label1226";
		((Control)label1226).Size = new Size(23, 12);
		((Control)label1226).TabIndex = 189;
		((Control)label1226).Text = "12.";
		((Control)label1227).AutoSize = true;
		label1227.ImeMode = (ImeMode)0;
		((Control)label1227).Location = new Point(434, 54);
		((Control)label1227).Name = "label1227";
		((Control)label1227).Size = new Size(23, 12);
		((Control)label1227).TabIndex = 186;
		((Control)label1227).Text = "16.";
		((Control)label1228).AutoSize = true;
		label1228.ImeMode = (ImeMode)0;
		((Control)label1228).Location = new Point(292, 54);
		((Control)label1228).Name = "label1228";
		((Control)label1228).Size = new Size(23, 12);
		((Control)label1228).TabIndex = 187;
		((Control)label1228).Text = "11.";
		((Control)len19).Location = new Point(521, 134);
		((Control)len19).Name = "len19";
		((Control)len19).Size = new Size(43, 21);
		((Control)len19).TabIndex = 178;
		((Control)len19).Text = "0";
		((Control)len14).Location = new Point(380, 134);
		((Control)len14).Name = "len14";
		((Control)len14).Size = new Size(43, 21);
		((Control)len14).TabIndex = 181;
		((Control)len14).Text = "0";
		((Control)len18).Location = new Point(521, 105);
		((Control)len18).Name = "len18";
		((Control)len18).Size = new Size(43, 21);
		((Control)len18).TabIndex = 180;
		((Control)len18).Text = "0";
		((Control)len13).Location = new Point(380, 105);
		((Control)len13).Name = "len13";
		((Control)len13).Size = new Size(43, 21);
		((Control)len13).TabIndex = 179;
		((Control)len13).Text = "0";
		((Control)len17).Location = new Point(521, 77);
		((Control)len17).Name = "len17";
		((Control)len17).Size = new Size(43, 21);
		((Control)len17).TabIndex = 169;
		((Control)len17).Text = "0";
		((Control)len12).Location = new Point(380, 77);
		((Control)len12).Name = "len12";
		((Control)len12).Size = new Size(43, 21);
		((Control)len12).TabIndex = 170;
		((Control)len12).Text = "0";
		((Control)len16).Location = new Point(521, 50);
		((Control)len16).Name = "len16";
		((Control)len16).Size = new Size(43, 21);
		((Control)len16).TabIndex = 168;
		((Control)len16).Text = "0";
		((Control)len11).Location = new Point(380, 50);
		((Control)len11).Name = "len11";
		((Control)len11).Size = new Size(43, 21);
		((Control)len11).TabIndex = 166;
		((Control)len11).Text = "0";
		((Control)Initialaddr19).Location = new Point(465, 134);
		((Control)Initialaddr19).Name = "Initialaddr19";
		((Control)Initialaddr19).Size = new Size(43, 21);
		((Control)Initialaddr19).TabIndex = 167;
		((Control)Initialaddr19).Text = "0";
		((Control)Initialaddr18).Location = new Point(465, 105);
		((Control)Initialaddr18).Name = "Initialaddr18";
		((Control)Initialaddr18).Size = new Size(43, 21);
		((Control)Initialaddr18).TabIndex = 171;
		((Control)Initialaddr18).Text = "0";
		((Control)Initialaddr14).Location = new Point(323, 134);
		((Control)Initialaddr14).Name = "Initialaddr14";
		((Control)Initialaddr14).Size = new Size(43, 21);
		((Control)Initialaddr14).TabIndex = 175;
		((Control)Initialaddr14).Text = "0";
		((Control)Initialaddr17).Location = new Point(465, 77);
		((Control)Initialaddr17).Name = "Initialaddr17";
		((Control)Initialaddr17).Size = new Size(43, 21);
		((Control)Initialaddr17).TabIndex = 176;
		((Control)Initialaddr17).Text = "0";
		((Control)Initialaddr13).Location = new Point(323, 105);
		((Control)Initialaddr13).Name = "Initialaddr13";
		((Control)Initialaddr13).Size = new Size(43, 21);
		((Control)Initialaddr13).TabIndex = 174;
		((Control)Initialaddr13).Text = "0";
		((Control)Initialaddr16).Location = new Point(465, 50);
		((Control)Initialaddr16).Name = "Initialaddr16";
		((Control)Initialaddr16).Size = new Size(43, 21);
		((Control)Initialaddr16).TabIndex = 172;
		((Control)Initialaddr16).Text = "0";
		((Control)Initialaddr12).Location = new Point(323, 77);
		((Control)Initialaddr12).Name = "Initialaddr12";
		((Control)Initialaddr12).Size = new Size(43, 21);
		((Control)Initialaddr12).TabIndex = 173;
		((Control)Initialaddr12).Text = "0";
		((Control)Initialaddr11).Location = new Point(323, 50);
		((Control)Initialaddr11).Name = "Initialaddr11";
		((Control)Initialaddr11).Size = new Size(43, 21);
		((Control)Initialaddr11).TabIndex = 177;
		((Control)Initialaddr11).Text = "0";
		((ButtonBase)SetUPdata).ImeMode = (ImeMode)0;
		((Control)SetUPdata).Location = new Point(509, 221);
		((Control)SetUPdata).Name = "SetUPdata";
		((Control)SetUPdata).Size = new Size(55, 23);
		((Control)SetUPdata).TabIndex = 165;
		((Control)SetUPdata).Text = "SET";
		((ButtonBase)SetUPdata).UseVisualStyleBackColor = true;
		((Control)SetUPdata).Click += SetUPdata_Click;
		((ButtonBase)ReadUPdata).ImeMode = (ImeMode)0;
		((Control)ReadUPdata).Location = new Point(437, 221);
		((Control)ReadUPdata).Name = "ReadUPdata";
		((Control)ReadUPdata).Size = new Size(55, 23);
		((Control)ReadUPdata).TabIndex = 164;
		((Control)ReadUPdata).Text = "READ";
		((ButtonBase)ReadUPdata).UseVisualStyleBackColor = true;
		((Control)ReadUPdata).Click += ReadUPdata_Click;
		((Control)label1229).AutoSize = true;
		label1229.ImeMode = (ImeMode)0;
		((Control)label1229).Location = new Point(35, 203);
		((Control)label1229).Name = "label1229";
		((Control)label1229).Size = new Size(23, 12);
		((Control)label1229).TabIndex = 161;
		((Control)label1229).Text = "num";
		((Control)UPdatanum).Location = new Point(32, 221);
		((Control)UPdatanum).Name = "UPdatanum";
		((Control)UPdatanum).Size = new Size(43, 21);
		((Control)UPdatanum).TabIndex = 160;
		((Control)UPdatanum).Text = "0";
		((Control)label1230).AutoSize = true;
		label1230.ImeMode = (ImeMode)0;
		((Control)label1230).Location = new Point(90, 26);
		((Control)label1230).Name = "label1230";
		((Control)label1230).Size = new Size(23, 12);
		((Control)label1230).TabIndex = 157;
		((Control)label1230).Text = "len";
		((Control)label1231).AutoSize = true;
		label1231.ImeMode = (ImeMode)0;
		((Control)label1231).Location = new Point(26, 26);
		((Control)label1231).Name = "label1231";
		((Control)label1231).Size = new Size(29, 12);
		((Control)label1231).TabIndex = 156;
		((Control)label1231).Text = "addr";
		((Control)label1231).UseWaitCursor = true;
		((Control)label1232).AutoSize = true;
		label1232.ImeMode = (ImeMode)0;
		((Control)label1232).Location = new Point(155, 138);
		((Control)label1232).Name = "label1232";
		((Control)label1232).Size = new Size(17, 12);
		((Control)label1232).TabIndex = 150;
		((Control)label1232).Text = "9.";
		((Control)label1233).AutoSize = true;
		label1233.ImeMode = (ImeMode)0;
		((Control)label1233).Location = new Point(14, 138);
		((Control)label1233).Name = "label1233";
		((Control)label1233).Size = new Size(17, 12);
		((Control)label1233).TabIndex = 149;
		((Control)label1233).Text = "4.";
		((Control)label1234).AutoSize = true;
		label1234.ImeMode = (ImeMode)0;
		((Control)label1234).Location = new Point(155, 109);
		((Control)label1234).Name = "label1234";
		((Control)label1234).Size = new Size(17, 12);
		((Control)label1234).TabIndex = 148;
		((Control)label1234).Text = "8.";
		((Control)label1235).AutoSize = true;
		label1235.ImeMode = (ImeMode)0;
		((Control)label1235).Location = new Point(14, 109);
		((Control)label1235).Name = "label1235";
		((Control)label1235).Size = new Size(17, 12);
		((Control)label1235).TabIndex = 151;
		((Control)label1235).Text = "3.";
		((Control)label1236).AutoSize = true;
		label1236.ImeMode = (ImeMode)0;
		((Control)label1236).Location = new Point(155, 81);
		((Control)label1236).Name = "label1236";
		((Control)label1236).Size = new Size(17, 12);
		((Control)label1236).TabIndex = 154;
		((Control)label1236).Text = "7.";
		((Control)label1237).AutoSize = true;
		label1237.ImeMode = (ImeMode)0;
		((Control)label1237).Location = new Point(14, 81);
		((Control)label1237).Name = "label1237";
		((Control)label1237).Size = new Size(17, 12);
		((Control)label1237).TabIndex = 155;
		((Control)label1237).Text = "2.";
		((Control)label1238).AutoSize = true;
		label1238.ImeMode = (ImeMode)0;
		((Control)label1238).Location = new Point(155, 54);
		((Control)label1238).Name = "label1238";
		((Control)label1238).Size = new Size(17, 12);
		((Control)label1238).TabIndex = 152;
		((Control)label1238).Text = "6.";
		((Control)label1239).AutoSize = true;
		label1239.ImeMode = (ImeMode)0;
		((Control)label1239).Location = new Point(14, 54);
		((Control)label1239).Name = "label1239";
		((Control)label1239).Size = new Size(17, 12);
		((Control)label1239).TabIndex = 153;
		((Control)label1239).Text = "1.";
		((Control)len9).Location = new Point(230, 134);
		((Control)len9).Name = "len9";
		((Control)len9).Size = new Size(43, 21);
		((Control)len9).TabIndex = 144;
		((Control)len9).Text = "0";
		((Control)len4).Location = new Point(89, 134);
		((Control)len4).Name = "len4";
		((Control)len4).Size = new Size(43, 21);
		((Control)len4).TabIndex = 147;
		((Control)len4).Text = "0";
		((Control)len8).Location = new Point(230, 105);
		((Control)len8).Name = "len8";
		((Control)len8).Size = new Size(43, 21);
		((Control)len8).TabIndex = 146;
		((Control)len8).Text = "0";
		((Control)len3).Location = new Point(89, 105);
		((Control)len3).Name = "len3";
		((Control)len3).Size = new Size(43, 21);
		((Control)len3).TabIndex = 145;
		((Control)len3).Text = "0";
		((Control)len7).Location = new Point(230, 77);
		((Control)len7).Name = "len7";
		((Control)len7).Size = new Size(43, 21);
		((Control)len7).TabIndex = 135;
		((Control)len7).Text = "0";
		((Control)len2).Location = new Point(89, 77);
		((Control)len2).Name = "len2";
		((Control)len2).Size = new Size(43, 21);
		((Control)len2).TabIndex = 136;
		((Control)len2).Text = "0";
		((Control)len6).Location = new Point(230, 50);
		((Control)len6).Name = "len6";
		((Control)len6).Size = new Size(43, 21);
		((Control)len6).TabIndex = 134;
		((Control)len6).Text = "0";
		((Control)len1).Location = new Point(89, 50);
		((Control)len1).Name = "len1";
		((Control)len1).Size = new Size(43, 21);
		((Control)len1).TabIndex = 132;
		((Control)len1).Text = "0";
		((Control)Initialaddr9).Location = new Point(174, 134);
		((Control)Initialaddr9).Name = "Initialaddr9";
		((Control)Initialaddr9).Size = new Size(43, 21);
		((Control)Initialaddr9).TabIndex = 133;
		((Control)Initialaddr9).Text = "0";
		((Control)Initialaddr8).Location = new Point(174, 105);
		((Control)Initialaddr8).Name = "Initialaddr8";
		((Control)Initialaddr8).Size = new Size(43, 21);
		((Control)Initialaddr8).TabIndex = 137;
		((Control)Initialaddr8).Text = "0";
		((Control)Initialaddr4).Location = new Point(32, 134);
		((Control)Initialaddr4).Name = "Initialaddr4";
		((Control)Initialaddr4).Size = new Size(43, 21);
		((Control)Initialaddr4).TabIndex = 141;
		((Control)Initialaddr4).Text = "0";
		((Control)Initialaddr7).Location = new Point(174, 77);
		((Control)Initialaddr7).Name = "Initialaddr7";
		((Control)Initialaddr7).Size = new Size(43, 21);
		((Control)Initialaddr7).TabIndex = 142;
		((Control)Initialaddr7).Text = "0";
		((Control)Initialaddr3).Location = new Point(32, 105);
		((Control)Initialaddr3).Name = "Initialaddr3";
		((Control)Initialaddr3).Size = new Size(43, 21);
		((Control)Initialaddr3).TabIndex = 140;
		((Control)Initialaddr3).Text = "0";
		((Control)Initialaddr6).Location = new Point(174, 50);
		((Control)Initialaddr6).Name = "Initialaddr6";
		((Control)Initialaddr6).Size = new Size(43, 21);
		((Control)Initialaddr6).TabIndex = 138;
		((Control)Initialaddr6).Text = "0";
		((Control)Initialaddr2).Location = new Point(32, 77);
		((Control)Initialaddr2).Name = "Initialaddr2";
		((Control)Initialaddr2).Size = new Size(43, 21);
		((Control)Initialaddr2).TabIndex = 139;
		((Control)Initialaddr2).Text = "0";
		((Control)Initialaddr1).Location = new Point(32, 50);
		((Control)Initialaddr1).Name = "Initialaddr1";
		((Control)Initialaddr1).Size = new Size(43, 21);
		((Control)Initialaddr1).TabIndex = 143;
		((Control)Initialaddr1).Text = "0";
		((Control)Channel_Setting).Controls.Add((Control)(object)groupBox1);
		Channel_Setting.Location = new Point(4, 22);
		((Control)Channel_Setting).Name = "Channel_Setting";
		((Control)Channel_Setting).Size = new Size(599, 358);
		Channel_Setting.TabIndex = 1;
		((Control)Channel_Setting).Text = "Channel Setting";
		Channel_Setting.UseVisualStyleBackColor = true;
		((Control)groupBox1).Controls.Add((Control)(object)channelnum);
		((Control)groupBox1).Controls.Add((Control)(object)label1246);
		((Control)groupBox1).Controls.Add((Control)(object)ChannelSET);
		((Control)groupBox1).Controls.Add((Control)(object)ChannelREAD);
		((Control)groupBox1).Controls.Add((Control)(object)channel3);
		((Control)groupBox1).Controls.Add((Control)(object)channel8);
		((Control)groupBox1).Controls.Add((Control)(object)label1248);
		((Control)groupBox1).Controls.Add((Control)(object)channel4);
		((Control)groupBox1).Controls.Add((Control)(object)label1247);
		((Control)groupBox1).Controls.Add((Control)(object)label1240);
		((Control)groupBox1).Controls.Add((Control)(object)channel1);
		((Control)groupBox1).Controls.Add((Control)(object)label1241);
		((Control)groupBox1).Controls.Add((Control)(object)channel5);
		((Control)groupBox1).Controls.Add((Control)(object)channel7);
		((Control)groupBox1).Controls.Add((Control)(object)label1245);
		((Control)groupBox1).Controls.Add((Control)(object)label1244);
		((Control)groupBox1).Controls.Add((Control)(object)label1242);
		((Control)groupBox1).Controls.Add((Control)(object)channel2);
		((Control)groupBox1).Controls.Add((Control)(object)label1243);
		((Control)groupBox1).Controls.Add((Control)(object)channel6);
		((Control)groupBox1).Location = new Point(8, 12);
		((Control)groupBox1).Name = "groupBox1";
		((Control)groupBox1).Size = new Size(577, 198);
		((Control)groupBox1).TabIndex = 76;
		groupBox1.TabStop = false;
		((Control)groupBox1).Text = "Channel Seting";
		((Control)channelnum).Location = new Point(167, 107);
		((TextBoxBase)channelnum).MaxLength = 2;
		((Control)channelnum).Name = "channelnum";
		((Control)channelnum).Size = new Size(48, 21);
		((Control)channelnum).TabIndex = 79;
		((Control)label1246).AutoSize = true;
		label1246.ImeMode = (ImeMode)0;
		((Control)label1246).Location = new Point(47, 110);
		((Control)label1246).Name = "label1246";
		((Control)label1246).Size = new Size(95, 12);
		((Control)label1246).TabIndex = 78;
		((Control)label1246).Text = "channel count：";
		((Control)ChannelSET).Font = new Font("宋体", 9f);
		((ButtonBase)ChannelSET).ImeMode = (ImeMode)0;
		((Control)ChannelSET).Location = new Point(306, 154);
		((Control)ChannelSET).Name = "ChannelSET";
		((Control)ChannelSET).Size = new Size(55, 23);
		((Control)ChannelSET).TabIndex = 77;
		((Control)ChannelSET).Text = "SET";
		((ButtonBase)ChannelSET).UseVisualStyleBackColor = true;
		((Control)ChannelSET).Click += ChannelSET_Click;
		((Control)ChannelREAD).Font = new Font("宋体", 9f);
		((ButtonBase)ChannelREAD).ImeMode = (ImeMode)0;
		((Control)ChannelREAD).Location = new Point(204, 154);
		((Control)ChannelREAD).Name = "ChannelREAD";
		((Control)ChannelREAD).Size = new Size(55, 23);
		((Control)ChannelREAD).TabIndex = 76;
		((Control)ChannelREAD).Text = "READ";
		((ButtonBase)ChannelREAD).UseVisualStyleBackColor = true;
		((Control)ChannelREAD).Click += ChannelREAD_Click;
		((Control)channel3).Location = new Point(306, 27);
		((TextBoxBase)channel3).MaxLength = 9;
		((Control)channel3).Name = "channel3";
		((Control)channel3).Size = new Size(80, 21);
		((Control)channel3).TabIndex = 70;
		((Control)channel8).Location = new Point(430, 65);
		((TextBoxBase)channel8).MaxLength = 9;
		((Control)channel8).Name = "channel8";
		((Control)channel8).Size = new Size(80, 21);
		((Control)channel8).TabIndex = 75;
		((Control)label1248).AutoSize = true;
		label1248.ImeMode = (ImeMode)0;
		((Control)label1248).Location = new Point(43, 30);
		((Control)label1248).Name = "label1248";
		((Control)label1248).Size = new Size(11, 12);
		((Control)label1248).TabIndex = 60;
		((Control)label1248).Text = "1";
		((Control)channel4).Location = new Point(430, 27);
		((TextBoxBase)channel4).MaxLength = 9;
		((Control)channel4).Name = "channel4";
		((Control)channel4).Size = new Size(80, 21);
		((Control)channel4).TabIndex = 74;
		((Control)label1247).AutoSize = true;
		label1247.ImeMode = (ImeMode)0;
		((Control)label1247).Location = new Point(43, 68);
		((Control)label1247).Name = "label1247";
		((Control)label1247).Size = new Size(11, 12);
		((Control)label1247).TabIndex = 61;
		((Control)label1247).Text = "5";
		((Control)label1240).AutoSize = true;
		label1240.ImeMode = (ImeMode)0;
		((Control)label1240).Location = new Point(409, 68);
		((Control)label1240).Name = "label1240";
		((Control)label1240).Size = new Size(11, 12);
		((Control)label1240).TabIndex = 73;
		((Control)label1240).Text = "8";
		((Control)channel1).Location = new Point(64, 27);
		((TextBoxBase)channel1).MaxLength = 9;
		((Control)channel1).Name = "channel1";
		((Control)channel1).Size = new Size(80, 21);
		((Control)channel1).TabIndex = 62;
		((Control)label1241).AutoSize = true;
		label1241.ImeMode = (ImeMode)0;
		((Control)label1241).Location = new Point(409, 30);
		((Control)label1241).Name = "label1241";
		((Control)label1241).Size = new Size(11, 12);
		((Control)label1241).TabIndex = 72;
		((Control)label1241).Text = "4";
		((Control)channel5).Location = new Point(64, 65);
		((TextBoxBase)channel5).MaxLength = 9;
		((Control)channel5).Name = "channel5";
		((Control)channel5).Size = new Size(80, 21);
		((Control)channel5).TabIndex = 63;
		((Control)channel7).Location = new Point(306, 65);
		((TextBoxBase)channel7).MaxLength = 9;
		((Control)channel7).Name = "channel7";
		((Control)channel7).Size = new Size(80, 21);
		((Control)channel7).TabIndex = 71;
		((Control)label1245).AutoSize = true;
		label1245.ImeMode = (ImeMode)0;
		((Control)label1245).Location = new Point(165, 30);
		((Control)label1245).Name = "label1245";
		((Control)label1245).Size = new Size(11, 12);
		((Control)label1245).TabIndex = 64;
		((Control)label1245).Text = "2";
		((Control)label1244).AutoSize = true;
		label1244.ImeMode = (ImeMode)0;
		((Control)label1244).Location = new Point(165, 68);
		((Control)label1244).Name = "label1244";
		((Control)label1244).Size = new Size(11, 12);
		((Control)label1244).TabIndex = 65;
		((Control)label1244).Text = "6";
		((Control)label1242).AutoSize = true;
		label1242.ImeMode = (ImeMode)0;
		((Control)label1242).Location = new Point(285, 68);
		((Control)label1242).Name = "label1242";
		((Control)label1242).Size = new Size(11, 12);
		((Control)label1242).TabIndex = 69;
		((Control)label1242).Text = "7";
		((Control)channel2).Location = new Point(186, 27);
		((TextBoxBase)channel2).MaxLength = 9;
		((Control)channel2).Name = "channel2";
		((Control)channel2).Size = new Size(80, 21);
		((Control)channel2).TabIndex = 66;
		((Control)label1243).AutoSize = true;
		label1243.ImeMode = (ImeMode)0;
		((Control)label1243).Location = new Point(285, 30);
		((Control)label1243).Name = "label1243";
		((Control)label1243).Size = new Size(11, 12);
		((Control)label1243).TabIndex = 68;
		((Control)label1243).Text = "3";
		((Control)channel6).Location = new Point(186, 65);
		((TextBoxBase)channel6).MaxLength = 9;
		((Control)channel6).Name = "channel6";
		((Control)channel6).Size = new Size(80, 21);
		((Control)channel6).TabIndex = 67;
		((Control)Rejoin_Setting).Controls.Add((Control)(object)groupBox2);
		((Control)Rejoin_Setting).Controls.Add((Control)(object)SetNoAckLimit);
		((Control)Rejoin_Setting).Controls.Add((Control)(object)ReadNoAckLimit);
		((Control)Rejoin_Setting).Controls.Add((Control)(object)label5);
		((Control)Rejoin_Setting).Controls.Add((Control)(object)NoAckLimit);
		((Control)Rejoin_Setting).Controls.Add((Control)(object)label4);
		Rejoin_Setting.Location = new Point(4, 22);
		((Control)Rejoin_Setting).Name = "Rejoin_Setting";
		((Control)Rejoin_Setting).Size = new Size(599, 358);
		Rejoin_Setting.TabIndex = 2;
		((Control)Rejoin_Setting).Text = "Rejoin Setting";
		Rejoin_Setting.UseVisualStyleBackColor = true;
		((Control)groupBox2).Controls.Add((Control)(object)Rejoin);
		((Control)groupBox2).Controls.Add((Control)(object)label6);
		((Control)groupBox2).Controls.Add((Control)(object)set_clear_flag);
		((Control)groupBox2).Controls.Add((Control)(object)Read_clear_flag);
		((Control)groupBox2).Controls.Add((Control)(object)check_clear_flag);
		((Control)groupBox2).Location = new Point(23, 115);
		((Control)groupBox2).Name = "groupBox2";
		((Control)groupBox2).Size = new Size(325, 100);
		((Control)groupBox2).TabIndex = 6;
		groupBox2.TabStop = false;
		((Control)groupBox2).Text = "Join info";
		((ButtonBase)Rejoin).ImeMode = (ImeMode)0;
		((Control)Rejoin).Location = new Point(221, 20);
		((Control)Rejoin).Name = "Rejoin";
		((Control)Rejoin).Size = new Size(85, 41);
		((Control)Rejoin).TabIndex = 62;
		((Control)Rejoin).Text = "Rejoin Now";
		((ButtonBase)Rejoin).UseVisualStyleBackColor = true;
		((Control)Rejoin).Click += Rejoin_Click;
		((Control)label6).AutoSize = true;
		((Control)label6).Location = new Point(41, 39);
		((Control)label6).Name = "label6";
		((Control)label6).Size = new Size(143, 12);
		((Control)label6).TabIndex = 7;
		((Control)label6).Text = "(Reset after execution)";
		((Control)set_clear_flag).Location = new Point(124, 71);
		((Control)set_clear_flag).Name = "set_clear_flag";
		((Control)set_clear_flag).Size = new Size(45, 23);
		((Control)set_clear_flag).TabIndex = 8;
		((Control)set_clear_flag).Text = "SET";
		((ButtonBase)set_clear_flag).UseVisualStyleBackColor = true;
		((Control)set_clear_flag).Click += set_clear_flag_Click;
		((Control)Read_clear_flag).Location = new Point(29, 71);
		((Control)Read_clear_flag).Name = "Read_clear_flag";
		((Control)Read_clear_flag).Size = new Size(45, 23);
		((Control)Read_clear_flag).TabIndex = 7;
		((Control)Read_clear_flag).Text = "READ";
		((ButtonBase)Read_clear_flag).UseVisualStyleBackColor = true;
		((Control)Read_clear_flag).Click += Read_clear_flag_Click;
		((Control)check_clear_flag).AutoSize = true;
		((Control)check_clear_flag).Location = new Point(29, 20);
		((Control)check_clear_flag).Name = "check_clear_flag";
		((Control)check_clear_flag).Size = new Size(114, 16);
		((Control)check_clear_flag).TabIndex = 5;
		((Control)check_clear_flag).Text = "Clear dev nonce";
		((ButtonBase)check_clear_flag).UseVisualStyleBackColor = true;
		((Control)SetNoAckLimit).Location = new Point(210, 50);
		((Control)SetNoAckLimit).Name = "SetNoAckLimit";
		((Control)SetNoAckLimit).Size = new Size(46, 23);
		((Control)SetNoAckLimit).TabIndex = 4;
		((Control)SetNoAckLimit).Text = "SET";
		((ButtonBase)SetNoAckLimit).UseVisualStyleBackColor = true;
		((Control)SetNoAckLimit).Click += SetNoAckLimit_Click;
		((Control)ReadNoAckLimit).Location = new Point(84, 50);
		((Control)ReadNoAckLimit).Name = "ReadNoAckLimit";
		((Control)ReadNoAckLimit).Size = new Size(46, 23);
		((Control)ReadNoAckLimit).TabIndex = 3;
		((Control)ReadNoAckLimit).Text = "READ";
		((ButtonBase)ReadNoAckLimit).UseVisualStyleBackColor = true;
		((Control)ReadNoAckLimit).Click += ReadNoAckLimit_Click;
		((Control)label5).AutoSize = true;
		((Control)label5).Location = new Point(194, 23);
		((Control)label5).Name = "label5";
		((Control)label5).Size = new Size(275, 12);
		((Control)label5).TabIndex = 2;
		((Control)label5).Text = "data upload cycles without receiving a reply.";
		((Control)NoAckLimit).Location = new Point(147, 20);
		((Control)NoAckLimit).Name = "NoAckLimit";
		((Control)NoAckLimit).Size = new Size(47, 21);
		((Control)NoAckLimit).TabIndex = 1;
		((Control)label4).AutoSize = true;
		((Control)label4).Location = new Point(21, 23);
		((Control)label4).Name = "label4";
		((Control)label4).Size = new Size(125, 12);
		((Control)label4).TabIndex = 0;
		((Control)label4).Text = "Try to rejoin after:";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 12f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(610, 389);
		((Control)this).Controls.Add((Control)(object)tabControl1);
		((Control)this).Name = "LWSet_Pro";
		((Control)this).Text = "LoRaWAN More Settings";
		((Control)tabControl1).ResumeLayout(false);
		((Control)LW_Updata).ResumeLayout(false);
		((Control)LW_Updata).PerformLayout();
		((Control)groupBox_updataset).ResumeLayout(false);
		((Control)groupBox_updataset).PerformLayout();
		((Control)Channel_Setting).ResumeLayout(false);
		((Control)groupBox1).ResumeLayout(false);
		((Control)groupBox1).PerformLayout();
		((Control)Rejoin_Setting).ResumeLayout(false);
		((Control)Rejoin_Setting).PerformLayout();
		((Control)groupBox2).ResumeLayout(false);
		((Control)groupBox2).PerformLayout();
		((Control)this).ResumeLayout(false);
	}
}
