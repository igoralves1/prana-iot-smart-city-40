using System.Runtime.InteropServices;

namespace _645ClearE;

internal class Parameters
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct PortSet
	{
		public static string PortNumber = "COM1";

		public static string PortBaud = "9600";

		public static string PortData = "8";

		public static string PortStop = "1";

		public static string PortCheck = "N";
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct MessageSet
	{
		public static string func = "03";

		public static string Reg = "512";

		public static string RegCount = "29";
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct InitPara
	{
		public static short Un;

		public static ushort Ib;

		public static short Ec;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct ReadInCorrect
	{
		public static byte func = 19;

		public static byte RegH = 1;

		public static byte RegL = 0;

		public static byte RegCountH = 0;

		public static byte RegCountL = 9;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct ChangePortSet
	{
		public static byte func = 16;

		public static byte RegH = 0;

		public static byte RegL = 0;

		public static byte RegCountH = 0;

		public static byte RegCountL = 2;

		public static byte ByteCount = 4;

		public static byte Addr;

		public static byte Baud;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct CorrectTime
	{
		public static byte func = 6;

		public static byte RegH = 0;

		public static byte RegL = 140;

		public static byte RegCountH = 0;

		public static byte RegCountL = 3;

		public static byte ByteCount = 6;

		public static byte Second;

		public static byte Minute;

		public static byte Hour;

		public static byte Day;

		public static byte Month;

		public static byte Year;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct SetZM
	{
		public static byte ChannelNum;

		public static byte Chips;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct CorrectPara
	{
		public static ushort Un;

		public static ushort Ib;

		public static ushort Ec;

		public static uint UgainA;

		public static uint UgainB;

		public static uint UgainC;

		public static uint IgainA;

		public static uint IgainB;

		public static uint IgainC;

		public static uint IgainN;

		public static uint PgainA;

		public static uint PgainB;

		public static uint PgainC;

		public static uint PhA;

		public static uint PhB;

		public static uint PhC;

		public static uint HFConst;

		public static uint Pstart;

		public static uint Istart;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct TimeZone
	{
		public static byte Schedule1;

		public static byte Schedule2;

		public static byte Schedule3;

		public static byte Schedule4;

		public static byte Day1;

		public static byte Day2;

		public static byte Day3;

		public static byte Day4;

		public static byte Month1;

		public static byte Month2;

		public static byte Month3;

		public static byte Month4;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct TimeSchedule
	{
		public static byte Price1;

		public static byte Price2;

		public static byte Price3;

		public static byte Price4;

		public static byte Price5;

		public static byte Price6;

		public static byte Price7;

		public static byte Price8;

		public static byte Price9;

		public static byte Price10;

		public static byte Price11;

		public static byte Price12;

		public static byte Price13;

		public static byte Price14;

		public static byte Minute1;

		public static byte Minute2;

		public static byte Minute3;

		public static byte Minute4;

		public static byte Minute5;

		public static byte Minute6;

		public static byte Minute7;

		public static byte Minute8;

		public static byte Minute9;

		public static byte Minute10;

		public static byte Minute11;

		public static byte Minute12;

		public static byte Minute13;

		public static byte Minute14;

		public static byte Hour1;

		public static byte Hour2;

		public static byte Hour3;

		public static byte Hour4;

		public static byte Hour5;

		public static byte Hour6;

		public static byte Hour7;

		public static byte Hour8;

		public static byte Hour9;

		public static byte Hour10;

		public static byte Hour11;

		public static byte Hour12;

		public static byte Hour13;

		public static byte Hour14;
	}

	public static int IsRightAddr = 0;

	public static int IsPortOpen = 0;

	public static int MessageType = 0;

	public static string Address = "1";

	public static string TempAddress = "";

	public static byte AddrInADF = 0;

	public static byte[] AllSetResult = new byte[12];

	public static bool IsContinue = false;

	public static bool IsGiveUp = false;

	public static bool AutoCorrectFlag = false;

	public static bool Form2IsOpen = false;

	public static bool CorrectIsResponse = false;

	public static bool CorrectIsOver = false;

	public static bool IsUse485 = true;

	public static bool IsAew100 = true;

	public static byte CurrentScale;

	public static int ClearType;

	public static byte WorkType;

	public static byte[] MeterIDToSet = new byte[6];

	public static byte Parity;

	public static byte StopBytes;

	public static byte TmpEN;

	public static byte TmpPL;

	public static bool LenWrong = false;
}
