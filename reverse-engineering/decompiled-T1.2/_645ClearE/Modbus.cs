using System;
using System.IO.Ports;
using System.Threading;

namespace _645ClearE;

internal class Modbus
{
	public static SerialPort sp = new SerialPort();

	private static readonly byte[] aucCRCHi = new byte[256]
	{
		0, 193, 129, 64, 1, 192, 128, 65, 1, 192,
		128, 65, 0, 193, 129, 64, 1, 192, 128, 65,
		0, 193, 129, 64, 0, 193, 129, 64, 1, 192,
		128, 65, 1, 192, 128, 65, 0, 193, 129, 64,
		0, 193, 129, 64, 1, 192, 128, 65, 0, 193,
		129, 64, 1, 192, 128, 65, 1, 192, 128, 65,
		0, 193, 129, 64, 1, 192, 128, 65, 0, 193,
		129, 64, 0, 193, 129, 64, 1, 192, 128, 65,
		0, 193, 129, 64, 1, 192, 128, 65, 1, 192,
		128, 65, 0, 193, 129, 64, 0, 193, 129, 64,
		1, 192, 128, 65, 1, 192, 128, 65, 0, 193,
		129, 64, 1, 192, 128, 65, 0, 193, 129, 64,
		0, 193, 129, 64, 1, 192, 128, 65, 1, 192,
		128, 65, 0, 193, 129, 64, 0, 193, 129, 64,
		1, 192, 128, 65, 0, 193, 129, 64, 1, 192,
		128, 65, 1, 192, 128, 65, 0, 193, 129, 64,
		0, 193, 129, 64, 1, 192, 128, 65, 1, 192,
		128, 65, 0, 193, 129, 64, 1, 192, 128, 65,
		0, 193, 129, 64, 0, 193, 129, 64, 1, 192,
		128, 65, 0, 193, 129, 64, 1, 192, 128, 65,
		1, 192, 128, 65, 0, 193, 129, 64, 1, 192,
		128, 65, 0, 193, 129, 64, 0, 193, 129, 64,
		1, 192, 128, 65, 1, 192, 128, 65, 0, 193,
		129, 64, 0, 193, 129, 64, 1, 192, 128, 65,
		0, 193, 129, 64, 1, 192, 128, 65, 1, 192,
		128, 65, 0, 193, 129, 64
	};

	private static readonly byte[] aucCRCLo = new byte[256]
	{
		0, 192, 193, 1, 195, 3, 2, 194, 198, 6,
		7, 199, 5, 197, 196, 4, 204, 12, 13, 205,
		15, 207, 206, 14, 10, 202, 203, 11, 201, 9,
		8, 200, 216, 24, 25, 217, 27, 219, 218, 26,
		30, 222, 223, 31, 221, 29, 28, 220, 20, 212,
		213, 21, 215, 23, 22, 214, 210, 18, 19, 211,
		17, 209, 208, 16, 240, 48, 49, 241, 51, 243,
		242, 50, 54, 246, 247, 55, 245, 53, 52, 244,
		60, 252, 253, 61, 255, 63, 62, 254, 250, 58,
		59, 251, 57, 249, 248, 56, 40, 232, 233, 41,
		235, 43, 42, 234, 238, 46, 47, 239, 45, 237,
		236, 44, 228, 36, 37, 229, 39, 231, 230, 38,
		34, 226, 227, 35, 225, 33, 32, 224, 160, 96,
		97, 161, 99, 163, 162, 98, 102, 166, 167, 103,
		165, 101, 100, 164, 108, 172, 173, 109, 175, 111,
		110, 174, 170, 106, 107, 171, 105, 169, 168, 104,
		120, 184, 185, 121, 187, 123, 122, 186, 190, 126,
		127, 191, 125, 189, 188, 124, 180, 116, 117, 181,
		119, 183, 182, 118, 114, 178, 179, 115, 177, 113,
		112, 176, 80, 144, 145, 81, 147, 83, 82, 146,
		150, 86, 87, 151, 85, 149, 148, 84, 156, 92,
		93, 157, 95, 159, 158, 94, 90, 154, 155, 91,
		153, 89, 88, 152, 136, 72, 73, 137, 75, 139,
		138, 74, 78, 142, 143, 79, 141, 77, 76, 140,
		68, 132, 133, 69, 135, 71, 70, 134, 130, 66,
		67, 131, 65, 129, 128, 64
	};

	public Modbus()
	{
		sp.ReadTimeout = 3000;
	}

	public bool Open()
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		sp.PortName = Parameters.PortSet.PortNumber;
		sp.BaudRate = int.Parse(Parameters.PortSet.PortBaud);
		sp.DataBits = int.Parse(Parameters.PortSet.PortData);
		sp.StopBits = (StopBits)Enum.Parse(typeof(StopBits), Parameters.PortSet.PortStop);
		sp.ReceivedBytesThreshold = 7;
		sp.RtsEnable = true;
		sp.DtrEnable = true;
		if (Parameters.PortSet.PortCheck == "N")
		{
			sp.Parity = (Parity)0;
		}
		else if (Parameters.PortSet.PortCheck == "E")
		{
			sp.Parity = (Parity)2;
		}
		else
		{
			sp.Parity = (Parity)1;
		}
		if (!sp.IsOpen)
		{
			try
			{
				sp.Open();
				Parameters.IsPortOpen = 1;
				return true;
			}
			catch
			{
				Parameters.IsPortOpen = 0;
				return false;
			}
		}
		Parameters.IsPortOpen = 1;
		return true;
	}

	public bool close()
	{
		if (sp.IsOpen)
		{
			try
			{
				sp.Close();
				Parameters.IsPortOpen = 0;
				return true;
			}
			catch
			{
				return false;
			}
		}
		Parameters.IsPortOpen = 0;
		return true;
	}

	public void BuildMessage(ref byte[] message)
	{
		Parameters.MessageType = 0;
		byte[] CRC = new byte[2];
		int num = Convert.ToInt16(Parameters.MessageSet.Reg);
		int num2 = Convert.ToInt16(Parameters.MessageSet.RegCount);
		message[0] = Convert.ToByte(Parameters.Address);
		message[1] = Convert.ToByte(Parameters.MessageSet.func);
		message[2] = (byte)(num >> 8);
		message[3] = (byte)(num & 0xFF);
		message[4] = (byte)(num2 >> 8);
		message[5] = (byte)(num2 & 0xFF);
		GetCRC(message, ref CRC);
		message[message.Length - 2] = CRC[0];
		message[message.Length - 1] = CRC[1];
	}

	public void BuildSetMessage(byte SetType, ref byte[] smessage)
	{
		byte[] CRC = new byte[2];
		switch (SetType)
		{
		case 1:
			Parameters.MessageType = 1;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 3;
			smessage[2] = 0;
			smessage[3] = 17;
			smessage[4] = 0;
			smessage[5] = 75;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 2:
			Parameters.MessageType = 2;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 3;
			smessage[2] = 0;
			smessage[3] = 38;
			smessage[4] = 0;
			smessage[5] = 21;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 3:
			Parameters.MessageType = 3;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 3;
			smessage[2] = 0;
			smessage[3] = 73;
			smessage[4] = 0;
			smessage[5] = 21;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 4:
			Parameters.MessageType = 4;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 3;
			smessage[2] = 0;
			smessage[3] = 108;
			smessage[4] = 0;
			smessage[5] = 21;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 5:
			Parameters.MessageType = 5;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 152;
			smessage[2] = 100;
			smessage[3] = 6;
			smessage[4] = 0;
			smessage[5] = 3;
			smessage[6] = 6;
			smessage[7] = (byte)(Parameters.InitPara.Un >> 8);
			smessage[8] = (byte)Parameters.InitPara.Un;
			smessage[9] = (byte)(Parameters.InitPara.Ib >> 8);
			smessage[10] = (byte)Parameters.InitPara.Ib;
			smessage[11] = (byte)(Parameters.InitPara.Ec >> 8);
			smessage[12] = (byte)Parameters.InitPara.Ec;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 6:
			break;
		case 7:
			Parameters.MessageType = 7;
			break;
		case 8:
			Parameters.MessageType = 8;
			break;
		case 9:
			Parameters.MessageType = 9;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 153;
			smessage[2] = 100;
			smessage[3] = 5;
			smessage[4] = 0;
			smessage[5] = 1;
			smessage[6] = 2;
			smessage[7] = 0;
			smessage[8] = 0;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 10:
			Parameters.MessageType = 10;
			break;
		case 11:
			Parameters.MessageType = 11;
			break;
		case 12:
			Parameters.MessageType = 12;
			break;
		case 13:
			Parameters.MessageType = 13;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 153;
			smessage[2] = 100;
			smessage[3] = 6;
			smessage[4] = 0;
			smessage[5] = 1;
			smessage[6] = 2;
			smessage[7] = 0;
			smessage[8] = 0;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 14:
			Parameters.MessageType = 14;
			break;
		case 15:
			Parameters.MessageType = 15;
			break;
		case 16:
			Parameters.MessageType = 16;
			break;
		case 17:
			Parameters.MessageType = 17;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = Parameters.CorrectTime.func;
			smessage[2] = Parameters.CorrectTime.RegH;
			smessage[3] = Parameters.CorrectTime.RegL;
			smessage[4] = Parameters.CorrectTime.RegCountH;
			smessage[5] = Parameters.CorrectTime.RegCountL;
			smessage[6] = Parameters.CorrectTime.ByteCount;
			smessage[7] = Parameters.CorrectTime.Year;
			smessage[8] = Parameters.CorrectTime.Month;
			smessage[9] = Parameters.CorrectTime.Day;
			smessage[10] = Parameters.CorrectTime.Hour;
			smessage[11] = Parameters.CorrectTime.Minute;
			smessage[12] = Parameters.CorrectTime.Second;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 18:
			Parameters.MessageType = 18;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 3;
			smessage[2] = 0;
			smessage[3] = 167;
			smessage[4] = 0;
			smessage[5] = 12;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 19:
			Parameters.MessageType = 19;
			break;
		case 20:
			Parameters.MessageType = 18;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 3;
			smessage[2] = 0;
			smessage[3] = 181;
			smessage[4] = 0;
			smessage[5] = 3;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 21:
			Parameters.MessageType = 18;
			break;
		case 22:
			Parameters.MessageType = 22;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = Parameters.ChangePortSet.func;
			if (Parameters.IsAew100)
			{
				smessage[2] = Parameters.ChangePortSet.RegH;
			}
			else
			{
				smessage[2] = (byte)(Parameters.ChangePortSet.RegH + 144);
			}
			smessage[3] = Parameters.ChangePortSet.RegL;
			smessage[4] = Parameters.ChangePortSet.RegCountH;
			smessage[5] = Parameters.ChangePortSet.RegCountL;
			smessage[6] = Parameters.ChangePortSet.ByteCount;
			smessage[7] = 0;
			smessage[8] = Parameters.ChangePortSet.Addr;
			smessage[9] = 0;
			smessage[10] = Parameters.ChangePortSet.Baud;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 23:
			Parameters.MessageType = 23;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 3;
			if (Parameters.IsAew100)
			{
				smessage[2] = Parameters.ChangePortSet.RegH;
			}
			else
			{
				smessage[2] = (byte)(Parameters.ChangePortSet.RegH + 144);
			}
			smessage[3] = Parameters.ChangePortSet.RegL;
			smessage[4] = 0;
			smessage[5] = 2;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 24:
			Parameters.MessageType = 24;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 16;
			if (Parameters.IsAew100)
			{
				smessage[2] = Parameters.ChangePortSet.RegH;
			}
			else
			{
				smessage[2] = (byte)(Parameters.ChangePortSet.RegH + 144);
			}
			smessage[3] = 2;
			smessage[4] = 0;
			smessage[5] = 2;
			smessage[6] = 4;
			smessage[7] = 0;
			smessage[8] = Parameters.SetZM.Chips;
			smessage[9] = 0;
			smessage[10] = Parameters.SetZM.ChannelNum;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 25:
			Parameters.MessageType = 25;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 3;
			if (Parameters.IsAew100)
			{
				smessage[2] = Parameters.ChangePortSet.RegH;
			}
			else
			{
				smessage[2] = (byte)(Parameters.ChangePortSet.RegH + 144);
			}
			smessage[3] = 2;
			smessage[4] = 0;
			smessage[5] = 2;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 26:
			Parameters.MessageType = 26;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 16;
			smessage[2] = 0;
			smessage[3] = 13;
			smessage[4] = 0;
			smessage[5] = 1;
			smessage[6] = 2;
			smessage[7] = 0;
			smessage[8] = Parameters.CurrentScale;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 28:
			Parameters.MessageType = 28;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 170;
			if (Parameters.ClearType > 0)
			{
				smessage[2] = 0;
				smessage[3] = (byte)Parameters.ClearType;
			}
			else
			{
				smessage[2] = 100;
				smessage[3] = 6;
			}
			smessage[4] = 0;
			smessage[5] = 1;
			smessage[6] = 2;
			smessage[7] = 0;
			smessage[8] = 0;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 29:
			Parameters.MessageType = 29;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 16;
			smessage[2] = 0;
			smessage[3] = 17;
			smessage[4] = 0;
			smessage[5] = 3;
			smessage[6] = 6;
			smessage[7] = Parameters.CorrectTime.Second;
			smessage[8] = Parameters.CorrectTime.Minute;
			smessage[9] = Parameters.CorrectTime.Hour;
			smessage[10] = Parameters.CorrectTime.Day;
			smessage[11] = Parameters.CorrectTime.Month;
			smessage[12] = Parameters.CorrectTime.Year;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 30:
			Parameters.MessageType = 30;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 3;
			smessage[2] = 144;
			smessage[3] = 4;
			smessage[4] = 0;
			smessage[5] = 1;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 31:
			Parameters.MessageType = 31;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 16;
			smessage[2] = 144;
			smessage[3] = 4;
			smessage[4] = 0;
			smessage[5] = 1;
			smessage[6] = 2;
			smessage[7] = 0;
			smessage[8] = Parameters.WorkType;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 32:
			Parameters.MessageType = 32;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 187;
			smessage[2] = 0;
			smessage[3] = 0;
			smessage[4] = 0;
			smessage[5] = 35;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 33:
			Parameters.MessageType = 33;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 188;
			smessage[2] = 0;
			smessage[3] = 0;
			smessage[4] = 0;
			smessage[5] = 35;
			smessage[6] = 70;
			smessage[7] = (byte)(Parameters.CorrectPara.Un >> 8);
			smessage[8] = (byte)Parameters.CorrectPara.Un;
			smessage[9] = (byte)(Parameters.CorrectPara.Ib >> 8);
			smessage[10] = (byte)Parameters.CorrectPara.Ib;
			smessage[11] = (byte)(Parameters.CorrectPara.Ec >> 8);
			smessage[12] = (byte)Parameters.CorrectPara.Ec;
			smessage[13] = (byte)(Parameters.CorrectPara.UgainA >> 24);
			smessage[14] = (byte)(Parameters.CorrectPara.UgainA >> 16);
			smessage[15] = (byte)(Parameters.CorrectPara.UgainA >> 8);
			smessage[16] = (byte)Parameters.CorrectPara.UgainA;
			smessage[17] = (byte)(Parameters.CorrectPara.UgainB >> 24);
			smessage[18] = (byte)(Parameters.CorrectPara.UgainB >> 16);
			smessage[19] = (byte)(Parameters.CorrectPara.UgainB >> 8);
			smessage[20] = (byte)Parameters.CorrectPara.UgainB;
			smessage[21] = (byte)(Parameters.CorrectPara.UgainC >> 24);
			smessage[22] = (byte)(Parameters.CorrectPara.UgainC >> 16);
			smessage[23] = (byte)(Parameters.CorrectPara.UgainC >> 8);
			smessage[24] = (byte)Parameters.CorrectPara.UgainC;
			smessage[25] = (byte)(Parameters.CorrectPara.IgainA >> 24);
			smessage[26] = (byte)(Parameters.CorrectPara.IgainA >> 16);
			smessage[27] = (byte)(Parameters.CorrectPara.IgainA >> 8);
			smessage[28] = (byte)Parameters.CorrectPara.IgainA;
			smessage[29] = (byte)(Parameters.CorrectPara.IgainB >> 24);
			smessage[30] = (byte)(Parameters.CorrectPara.IgainB >> 16);
			smessage[31] = (byte)(Parameters.CorrectPara.IgainB >> 8);
			smessage[32] = (byte)Parameters.CorrectPara.IgainB;
			smessage[33] = (byte)(Parameters.CorrectPara.IgainC >> 24);
			smessage[34] = (byte)(Parameters.CorrectPara.IgainC >> 16);
			smessage[35] = (byte)(Parameters.CorrectPara.IgainC >> 8);
			smessage[36] = (byte)Parameters.CorrectPara.IgainC;
			smessage[37] = (byte)(Parameters.CorrectPara.IgainN >> 24);
			smessage[38] = (byte)(Parameters.CorrectPara.IgainN >> 16);
			smessage[39] = (byte)(Parameters.CorrectPara.IgainN >> 8);
			smessage[40] = (byte)Parameters.CorrectPara.IgainN;
			smessage[41] = (byte)(Parameters.CorrectPara.PgainA >> 24);
			smessage[42] = (byte)(Parameters.CorrectPara.PgainA >> 16);
			smessage[43] = (byte)(Parameters.CorrectPara.PgainA >> 8);
			smessage[44] = (byte)Parameters.CorrectPara.PgainA;
			smessage[45] = (byte)(Parameters.CorrectPara.PgainB >> 24);
			smessage[46] = (byte)(Parameters.CorrectPara.PgainB >> 16);
			smessage[47] = (byte)(Parameters.CorrectPara.PgainB >> 8);
			smessage[48] = (byte)Parameters.CorrectPara.PgainB;
			smessage[49] = (byte)(Parameters.CorrectPara.PgainC >> 24);
			smessage[50] = (byte)(Parameters.CorrectPara.PgainC >> 16);
			smessage[51] = (byte)(Parameters.CorrectPara.PgainC >> 8);
			smessage[52] = (byte)Parameters.CorrectPara.PgainC;
			smessage[53] = (byte)(Parameters.CorrectPara.PhA >> 24);
			smessage[54] = (byte)(Parameters.CorrectPara.PhA >> 16);
			smessage[55] = (byte)(Parameters.CorrectPara.PhA >> 8);
			smessage[56] = (byte)Parameters.CorrectPara.PhA;
			smessage[57] = (byte)(Parameters.CorrectPara.PhB >> 24);
			smessage[58] = (byte)(Parameters.CorrectPara.PhB >> 16);
			smessage[59] = (byte)(Parameters.CorrectPara.PhB >> 8);
			smessage[60] = (byte)Parameters.CorrectPara.PhB;
			smessage[61] = (byte)(Parameters.CorrectPara.PhC >> 24);
			smessage[62] = (byte)(Parameters.CorrectPara.PhC >> 16);
			smessage[63] = (byte)(Parameters.CorrectPara.PhC >> 8);
			smessage[64] = (byte)Parameters.CorrectPara.PhC;
			smessage[65] = (byte)(Parameters.CorrectPara.HFConst >> 24);
			smessage[66] = (byte)(Parameters.CorrectPara.HFConst >> 16);
			smessage[67] = (byte)(Parameters.CorrectPara.HFConst >> 8);
			smessage[68] = (byte)Parameters.CorrectPara.HFConst;
			smessage[69] = (byte)(Parameters.CorrectPara.Pstart >> 24);
			smessage[70] = (byte)(Parameters.CorrectPara.Pstart >> 16);
			smessage[71] = (byte)(Parameters.CorrectPara.Pstart >> 8);
			smessage[72] = (byte)Parameters.CorrectPara.Pstart;
			smessage[73] = (byte)(Parameters.CorrectPara.Istart >> 24);
			smessage[74] = (byte)(Parameters.CorrectPara.Istart >> 16);
			smessage[75] = (byte)(Parameters.CorrectPara.Istart >> 8);
			smessage[76] = (byte)Parameters.CorrectPara.Istart;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 34:
			Parameters.MessageType = 34;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 3;
			smessage[2] = 1;
			smessage[3] = 109;
			smessage[4] = 0;
			smessage[5] = 21;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 35:
			Parameters.MessageType = 35;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 16;
			smessage[2] = 1;
			smessage[3] = 109;
			smessage[4] = 0;
			smessage[5] = 21;
			smessage[6] = 42;
			smessage[7] = Parameters.TimeSchedule.Price1;
			smessage[8] = Parameters.TimeSchedule.Minute1;
			smessage[9] = Parameters.TimeSchedule.Hour1;
			smessage[10] = Parameters.TimeSchedule.Price2;
			smessage[11] = Parameters.TimeSchedule.Minute2;
			smessage[12] = Parameters.TimeSchedule.Hour2;
			smessage[13] = Parameters.TimeSchedule.Price3;
			smessage[14] = Parameters.TimeSchedule.Minute3;
			smessage[15] = Parameters.TimeSchedule.Hour3;
			smessage[16] = Parameters.TimeSchedule.Price4;
			smessage[17] = Parameters.TimeSchedule.Minute4;
			smessage[18] = Parameters.TimeSchedule.Hour4;
			smessage[19] = Parameters.TimeSchedule.Price5;
			smessage[20] = Parameters.TimeSchedule.Minute5;
			smessage[21] = Parameters.TimeSchedule.Hour5;
			smessage[22] = Parameters.TimeSchedule.Price6;
			smessage[23] = Parameters.TimeSchedule.Minute6;
			smessage[24] = Parameters.TimeSchedule.Hour6;
			smessage[25] = Parameters.TimeSchedule.Price7;
			smessage[26] = Parameters.TimeSchedule.Minute7;
			smessage[27] = Parameters.TimeSchedule.Hour7;
			smessage[28] = Parameters.TimeSchedule.Price8;
			smessage[29] = Parameters.TimeSchedule.Minute8;
			smessage[30] = Parameters.TimeSchedule.Hour8;
			smessage[31] = Parameters.TimeSchedule.Price9;
			smessage[32] = Parameters.TimeSchedule.Minute9;
			smessage[33] = Parameters.TimeSchedule.Hour9;
			smessage[34] = Parameters.TimeSchedule.Price10;
			smessage[35] = Parameters.TimeSchedule.Minute10;
			smessage[36] = Parameters.TimeSchedule.Hour10;
			smessage[37] = Parameters.TimeSchedule.Price11;
			smessage[38] = Parameters.TimeSchedule.Minute11;
			smessage[39] = Parameters.TimeSchedule.Hour11;
			smessage[40] = Parameters.TimeSchedule.Price12;
			smessage[41] = Parameters.TimeSchedule.Minute12;
			smessage[42] = Parameters.TimeSchedule.Hour12;
			smessage[43] = Parameters.TimeSchedule.Price13;
			smessage[44] = Parameters.TimeSchedule.Minute13;
			smessage[45] = Parameters.TimeSchedule.Hour13;
			smessage[46] = Parameters.TimeSchedule.Price14;
			smessage[47] = Parameters.TimeSchedule.Minute14;
			smessage[48] = Parameters.TimeSchedule.Hour14;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 36:
			Parameters.MessageType = 36;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 3;
			smessage[2] = 1;
			smessage[3] = 130;
			smessage[4] = 0;
			smessage[5] = 21;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 37:
			Parameters.MessageType = 37;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 16;
			smessage[2] = 1;
			smessage[3] = 130;
			smessage[4] = 0;
			smessage[5] = 21;
			smessage[6] = 42;
			smessage[7] = Parameters.TimeSchedule.Price1;
			smessage[8] = Parameters.TimeSchedule.Minute1;
			smessage[9] = Parameters.TimeSchedule.Hour1;
			smessage[10] = Parameters.TimeSchedule.Price2;
			smessage[11] = Parameters.TimeSchedule.Minute2;
			smessage[12] = Parameters.TimeSchedule.Hour2;
			smessage[13] = Parameters.TimeSchedule.Price3;
			smessage[14] = Parameters.TimeSchedule.Minute3;
			smessage[15] = Parameters.TimeSchedule.Hour3;
			smessage[16] = Parameters.TimeSchedule.Price4;
			smessage[17] = Parameters.TimeSchedule.Minute4;
			smessage[18] = Parameters.TimeSchedule.Hour4;
			smessage[19] = Parameters.TimeSchedule.Price5;
			smessage[20] = Parameters.TimeSchedule.Minute5;
			smessage[21] = Parameters.TimeSchedule.Hour5;
			smessage[22] = Parameters.TimeSchedule.Price6;
			smessage[23] = Parameters.TimeSchedule.Minute6;
			smessage[24] = Parameters.TimeSchedule.Hour6;
			smessage[25] = Parameters.TimeSchedule.Price7;
			smessage[26] = Parameters.TimeSchedule.Minute7;
			smessage[27] = Parameters.TimeSchedule.Hour7;
			smessage[28] = Parameters.TimeSchedule.Price8;
			smessage[29] = Parameters.TimeSchedule.Minute8;
			smessage[30] = Parameters.TimeSchedule.Hour8;
			smessage[31] = Parameters.TimeSchedule.Price9;
			smessage[32] = Parameters.TimeSchedule.Minute9;
			smessage[33] = Parameters.TimeSchedule.Hour9;
			smessage[34] = Parameters.TimeSchedule.Price10;
			smessage[35] = Parameters.TimeSchedule.Minute10;
			smessage[36] = Parameters.TimeSchedule.Hour10;
			smessage[37] = Parameters.TimeSchedule.Price11;
			smessage[38] = Parameters.TimeSchedule.Minute11;
			smessage[39] = Parameters.TimeSchedule.Hour11;
			smessage[40] = Parameters.TimeSchedule.Price12;
			smessage[41] = Parameters.TimeSchedule.Minute12;
			smessage[42] = Parameters.TimeSchedule.Hour12;
			smessage[43] = Parameters.TimeSchedule.Price13;
			smessage[44] = Parameters.TimeSchedule.Minute13;
			smessage[45] = Parameters.TimeSchedule.Hour13;
			smessage[46] = Parameters.TimeSchedule.Price14;
			smessage[47] = Parameters.TimeSchedule.Minute14;
			smessage[48] = Parameters.TimeSchedule.Hour14;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 38:
			Parameters.MessageType = 38;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 3;
			smessage[2] = 1;
			smessage[3] = 103;
			smessage[4] = 0;
			smessage[5] = 6;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 39:
			Parameters.MessageType = 39;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 16;
			smessage[2] = 1;
			smessage[3] = 103;
			smessage[4] = 0;
			smessage[5] = 6;
			smessage[6] = 12;
			smessage[7] = Parameters.TimeZone.Schedule1;
			smessage[8] = Parameters.TimeZone.Day1;
			smessage[9] = Parameters.TimeZone.Month1;
			smessage[10] = Parameters.TimeZone.Schedule2;
			smessage[11] = Parameters.TimeZone.Day2;
			smessage[12] = Parameters.TimeZone.Month2;
			smessage[13] = Parameters.TimeZone.Schedule3;
			smessage[14] = Parameters.TimeZone.Day3;
			smessage[15] = Parameters.TimeZone.Month3;
			smessage[16] = Parameters.TimeZone.Schedule4;
			smessage[17] = Parameters.TimeZone.Day4;
			smessage[18] = Parameters.TimeZone.Month4;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 40:
			Parameters.MessageType = 40;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 3;
			smessage[2] = 1;
			smessage[3] = 151;
			smessage[4] = 0;
			smessage[5] = 40;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 41:
			Parameters.MessageType = 41;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 3;
			smessage[2] = 0;
			smessage[3] = 10;
			smessage[4] = 0;
			smessage[5] = 3;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 42:
			Parameters.MessageType = 42;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 16;
			smessage[2] = 0;
			smessage[3] = 10;
			smessage[4] = 0;
			smessage[5] = 3;
			smessage[6] = 6;
			smessage[7] = Parameters.MeterIDToSet[0];
			smessage[8] = Parameters.MeterIDToSet[1];
			smessage[9] = Parameters.MeterIDToSet[2];
			smessage[10] = Parameters.MeterIDToSet[3];
			smessage[11] = Parameters.MeterIDToSet[4];
			smessage[12] = Parameters.MeterIDToSet[5];
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 43:
			Parameters.MessageType = 43;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 3;
			if (Parameters.IsAew100)
			{
				smessage[2] = 0;
				smessage[3] = 4;
				smessage[4] = 0;
				smessage[5] = 1;
			}
			else
			{
				smessage[2] = 144;
				smessage[3] = 5;
				smessage[4] = 0;
				smessage[5] = 2;
			}
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 44:
			Parameters.MessageType = 44;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 16;
			if (Parameters.IsAew100)
			{
				smessage[2] = 0;
				smessage[3] = 4;
				smessage[4] = 0;
				smessage[5] = 1;
				smessage[6] = 2;
				smessage[7] = Parameters.Parity;
				smessage[8] = Parameters.StopBytes;
			}
			else
			{
				smessage[2] = 144;
				smessage[3] = 5;
				smessage[4] = 0;
				smessage[5] = 2;
				smessage[6] = 4;
				smessage[7] = 0;
				smessage[8] = Parameters.Parity;
				smessage[9] = 0;
				smessage[10] = Parameters.StopBytes;
			}
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 45:
			Parameters.MessageType = 45;
			if (Parameters.IsAew100)
			{
				smessage[0] = Convert.ToByte(Parameters.Address);
			}
			else
			{
				smessage[0] = byte.MaxValue;
			}
			smessage[1] = 17;
			smessage[2] = 254;
			smessage[3] = 220;
			smessage[4] = 186;
			smessage[5] = 152;
			smessage[6] = 118;
			smessage[7] = 84;
			smessage[8] = 50;
			smessage[9] = 16;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 46:
			Parameters.MessageType = 46;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 3;
			smessage[2] = 1;
			smessage[3] = 100;
			smessage[4] = 0;
			smessage[5] = 3;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 47:
			Parameters.MessageType = 47;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 3;
			smessage[2] = 0;
			smessage[3] = 5;
			smessage[4] = 0;
			smessage[5] = 1;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 48:
			Parameters.MessageType = 48;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 16;
			smessage[2] = 0;
			smessage[3] = 5;
			smessage[4] = 0;
			smessage[5] = 1;
			smessage[6] = 2;
			smessage[7] = 0;
			smessage[8] = Parameters.TmpEN;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 49:
			Parameters.MessageType = 49;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 3;
			smessage[2] = 0;
			smessage[3] = 9;
			smessage[4] = 0;
			smessage[5] = 1;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 50:
			Parameters.MessageType = 50;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 16;
			smessage[2] = 0;
			smessage[3] = 9;
			smessage[4] = 0;
			smessage[5] = 1;
			smessage[6] = 2;
			smessage[7] = Parameters.TmpPL;
			smessage[8] = 0;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 51:
			Parameters.MessageType = 51;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 3;
			smessage[2] = 2;
			smessage[3] = 1;
			smessage[4] = 0;
			smessage[5] = 21;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 52:
			Parameters.MessageType = 52;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 16;
			smessage[2] = 2;
			smessage[3] = 1;
			smessage[4] = 0;
			smessage[5] = 21;
			smessage[6] = 42;
			smessage[7] = Parameters.TimeSchedule.Price1;
			smessage[8] = Parameters.TimeSchedule.Minute1;
			smessage[9] = Parameters.TimeSchedule.Hour1;
			smessage[10] = Parameters.TimeSchedule.Price2;
			smessage[11] = Parameters.TimeSchedule.Minute2;
			smessage[12] = Parameters.TimeSchedule.Hour2;
			smessage[13] = Parameters.TimeSchedule.Price3;
			smessage[14] = Parameters.TimeSchedule.Minute3;
			smessage[15] = Parameters.TimeSchedule.Hour3;
			smessage[16] = Parameters.TimeSchedule.Price4;
			smessage[17] = Parameters.TimeSchedule.Minute4;
			smessage[18] = Parameters.TimeSchedule.Hour4;
			smessage[19] = Parameters.TimeSchedule.Price5;
			smessage[20] = Parameters.TimeSchedule.Minute5;
			smessage[21] = Parameters.TimeSchedule.Hour5;
			smessage[22] = Parameters.TimeSchedule.Price6;
			smessage[23] = Parameters.TimeSchedule.Minute6;
			smessage[24] = Parameters.TimeSchedule.Hour6;
			smessage[25] = Parameters.TimeSchedule.Price7;
			smessage[26] = Parameters.TimeSchedule.Minute7;
			smessage[27] = Parameters.TimeSchedule.Hour7;
			smessage[28] = Parameters.TimeSchedule.Price8;
			smessage[29] = Parameters.TimeSchedule.Minute8;
			smessage[30] = Parameters.TimeSchedule.Hour8;
			smessage[31] = Parameters.TimeSchedule.Price9;
			smessage[32] = Parameters.TimeSchedule.Minute9;
			smessage[33] = Parameters.TimeSchedule.Hour9;
			smessage[34] = Parameters.TimeSchedule.Price10;
			smessage[35] = Parameters.TimeSchedule.Minute10;
			smessage[36] = Parameters.TimeSchedule.Hour10;
			smessage[37] = Parameters.TimeSchedule.Price11;
			smessage[38] = Parameters.TimeSchedule.Minute11;
			smessage[39] = Parameters.TimeSchedule.Hour11;
			smessage[40] = Parameters.TimeSchedule.Price12;
			smessage[41] = Parameters.TimeSchedule.Minute12;
			smessage[42] = Parameters.TimeSchedule.Hour12;
			smessage[43] = Parameters.TimeSchedule.Price13;
			smessage[44] = Parameters.TimeSchedule.Minute13;
			smessage[45] = Parameters.TimeSchedule.Hour13;
			smessage[46] = Parameters.TimeSchedule.Price14;
			smessage[47] = Parameters.TimeSchedule.Minute14;
			smessage[48] = Parameters.TimeSchedule.Hour14;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 67:
			Parameters.MessageType = 67;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 3;
			smessage[2] = 0;
			smessage[3] = 116;
			smessage[4] = 0;
			smessage[5] = 6;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 53:
			Parameters.MessageType = 24;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 16;
			if (Parameters.IsAew100)
			{
				smessage[2] = Parameters.ChangePortSet.RegH;
			}
			else
			{
				smessage[2] = (byte)(Parameters.ChangePortSet.RegH + 144);
			}
			smessage[3] = 2;
			smessage[4] = 0;
			smessage[5] = 2;
			smessage[6] = 4;
			smessage[7] = 0;
			smessage[8] = Parameters.SetZM.Chips;
			smessage[9] = 0;
			smessage[10] = Parameters.SetZM.ChannelNum;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 68:
			Parameters.MessageType = 68;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 3;
			smessage[2] = 1;
			smessage[3] = 46;
			smessage[4] = 0;
			smessage[5] = 28;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 69:
			Parameters.MessageType = 69;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 3;
			smessage[2] = 0;
			smessage[3] = 122;
			smessage[4] = 0;
			smessage[5] = 30;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 70:
			Parameters.MessageType = 70;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 3;
			smessage[2] = 0;
			smessage[3] = 152;
			smessage[4] = 0;
			smessage[5] = 30;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 71:
			Parameters.MessageType = 71;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 3;
			smessage[2] = 0;
			smessage[3] = 182;
			smessage[4] = 0;
			smessage[5] = 30;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 72:
			Parameters.MessageType = 72;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 3;
			smessage[2] = 0;
			smessage[3] = 212;
			smessage[4] = 0;
			smessage[5] = 30;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 73:
			Parameters.MessageType = 73;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 3;
			smessage[2] = 0;
			smessage[3] = 242;
			smessage[4] = 0;
			smessage[5] = 30;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 74:
			Parameters.MessageType = 74;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 3;
			smessage[2] = 1;
			smessage[3] = 16;
			smessage[4] = 0;
			smessage[5] = 30;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 75:
			Parameters.MessageType = 75;
			smessage[0] = Convert.ToByte(Parameters.Address);
			smessage[1] = 3;
			smessage[2] = 1;
			smessage[3] = 193;
			smessage[4] = 0;
			smessage[5] = 2;
			GetCRC(smessage, ref CRC);
			smessage[smessage.Length - 2] = CRC[0];
			smessage[smessage.Length - 1] = CRC[1];
			break;
		case 27:
		case 54:
		case 55:
		case 56:
		case 57:
		case 58:
		case 59:
		case 60:
		case 61:
		case 62:
		case 63:
		case 64:
		case 65:
		case 66:
			break;
		}
	}

	public void ChangeMessage(ref byte[] message)
	{
		message[3] = byte.MaxValue;
	}

	public void ChangeMessageToAllCharge(ref byte[] message)
	{
		message[1] = 32;
		message[2] = 7;
		message[3] = byte.MaxValue;
	}

	public bool GetResponse(ref byte[] response)
	{
		int num = 0;
		int num2 = 0;
		bool flag = true;
		if (Parameters.IsUse485)
		{
			try
			{
				while (flag && num2 < 30)
				{
					if (sp.BytesToRead < response.Length)
					{
						Thread.Sleep(300);
						num2++;
					}
					else
					{
						flag = false;
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		else
		{
			while (flag && num2 < 50)
			{
				if (sp.BytesToRead < response.Length)
				{
					Thread.Sleep(100);
					num2++;
				}
				else
				{
					flag = false;
				}
			}
		}
		num = sp.Read(response, 0, response.Length);
		if (num > 0)
		{
			return true;
		}
		return false;
	}

	public bool CheckResponse(byte[] response)
	{
		if (Parameters.MessageType < 0 || Parameters.MessageType > 4)
		{
			if (Parameters.MessageType == 18)
			{
				if (response.Length != 29)
				{
					return false;
				}
			}
			else if (Parameters.MessageType == 20)
			{
				if (response.Length != 11)
				{
					return false;
				}
			}
			else if (Parameters.MessageType == 23)
			{
				if (response.Length != 9)
				{
					return false;
				}
			}
			else if (Parameters.MessageType == 25)
			{
				if (response.Length != 9 && response.Length != 19)
				{
					return false;
				}
			}
			else if (Parameters.MessageType != 30)
			{
				if (Parameters.MessageType == 32)
				{
					if (response.Length != 75)
					{
						return false;
					}
				}
				else if (Parameters.MessageType == 41)
				{
					if (response.Length != 11)
					{
						return false;
					}
				}
				else if (Parameters.MessageType == 34 || Parameters.MessageType == 36)
				{
					if (response.Length != 47)
					{
						return false;
					}
				}
				else if (Parameters.MessageType == 38)
				{
					if (response.Length != 17)
					{
						return false;
					}
				}
				else if (Parameters.MessageType == 40)
				{
					if (response.Length != 85)
					{
						return false;
					}
				}
				else if (Parameters.MessageType == 43)
				{
					if (Parameters.IsAew100)
					{
						if (response.Length != 7)
						{
							return false;
						}
					}
					else if (response.Length != 9)
					{
						return false;
					}
				}
				else if (Parameters.MessageType == 47)
				{
					if (response.Length != 7)
					{
						return false;
					}
				}
				else if (Parameters.MessageType == 49)
				{
					if (response.Length != 7)
					{
						return false;
					}
				}
				else if (Parameters.MessageType == 45)
				{
					if (response.Length != 15)
					{
						return false;
					}
				}
				else if (Parameters.MessageType != 46)
				{
					if (Parameters.MessageType == 67)
					{
						if (response.Length != 17)
						{
							return false;
						}
					}
					else if (Parameters.MessageType == 68)
					{
						if (response.Length != 61)
						{
							return false;
						}
					}
					else if (Parameters.MessageType >= 69 && Parameters.MessageType <= 74)
					{
						if (response.Length != 65)
						{
							return false;
						}
					}
					else if (Parameters.MessageType == 75 && response.Length != 9)
					{
						return false;
					}
				}
			}
		}
		byte[] CRC = new byte[2];
		GetCRC(response, ref CRC);
		if (CRC[0] == response[^2] && CRC[1] == response[^1])
		{
			return true;
		}
		return false;
	}

	public void GetCRC(byte[] message, ref byte[] CRC)
	{
		int num = message.Length - 2;
		int num2 = 0;
		CRC[0] = byte.MaxValue;
		CRC[1] = byte.MaxValue;
		ushort num3 = 0;
		while (num-- > 0)
		{
			num3 = (ushort)(CRC[0] ^ message[num2++]);
			CRC[0] = (byte)(CRC[1] ^ aucCRCHi[num3]);
			CRC[1] = aucCRCLo[num3];
		}
	}

	public void GetStrCRC(byte[] message, int strLen, ref byte[] CRC)
	{
		int num = strLen;
		int num2 = 0;
		CRC[0] = byte.MaxValue;
		CRC[1] = byte.MaxValue;
		ushort num3 = 0;
		while (num-- > 0)
		{
			num3 = (ushort)(CRC[0] ^ message[num2++]);
			CRC[0] = (byte)(CRC[1] ^ aucCRCHi[num3]);
			CRC[1] = aucCRCLo[num3];
		}
	}

	static Modbus()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Expected Obj, but got Unknown
	}
}
