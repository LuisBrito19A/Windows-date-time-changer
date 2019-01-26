using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Net;

namespace Cambio_Hora
{
    class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool SetSystemTime(ref SYSTEMTIME time);

        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            public ushort Year;
            public ushort Month;
            public ushort DayOfWeek;
            public ushort Day;
            public ushort Hour;
            public ushort Minute;
            public ushort Second;
            public ushort Milliseconds;

            public SYSTEMTIME(DateTime dt)
            {
                Year = (ushort)dt.Year;
                Month = (ushort)dt.Month;
                DayOfWeek = (ushort)dt.DayOfWeek;
                Day = (ushort)dt.Day;
                Hour = (ushort)dt.Hour;
                Minute = (ushort)dt.Minute;
                Second = (ushort)dt.Second;
                Milliseconds = (ushort)dt.Millisecond;
            }
        }
        static void Main()
        {
           
            DateTime t = TCPClient.GetNetworkTime();

            DateTime date = new DateTime(t.Year, t.Month, t.Day, t.Hour, t.Minute, t.Second);
         
            SYSTEMTIME systime = new SYSTEMTIME(date);
            SetSystemTime(ref systime);

        }
    }
}


