using System;

namespace WhoRobsMyFocus
{
    public class LogEntry : IEquatable<LogEntry>
    {
        public int PID { get; set; }
        public string WindowName { get; set; }
        public string ExecName { get; set; }
        public DateTime LogTime { get; set; }

        public override string ToString()
        {
            return string.Format("PID:{0}{3}窗口名:{1}{3}进程名:{2}", PID.ToString(), WindowName, ExecName, Environment.NewLine);
        }

        public string ToString(bool printTime)
        {
            if (printTime)
            {
                return string.Format("{0}{4}PID:{1}{4}窗口名:{2}{4}进程名:{3}", LogTime.ToShortTimeString(), PID.ToString(), WindowName, ExecName, Environment.NewLine);
            }
            else
            {
                return this.ToString();
            }
        }

        public bool Equals(LogEntry other)
        {
            if (null == other)
            {
                return false;
            }
            return (this.PID == other.PID) && (this.ExecName == other.ExecName) && (this.WindowName == other.WindowName);
        }

        //public static bool operator ==(LogEntry le1, LogEntry le2)
        //{
        //    if (null == le1)
        //    {
        //        if (null == le2)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        return le1.Equals(le2);
        //    }
        //}

        //public static bool operator !=(LogEntry le1, LogEntry le2)
        //{
        //    if (null == le1)
        //    {
        //        if (null == le2)
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            return true;
        //        }
        //    }
        //    else
        //    {
        //        return !le1.Equals(le2);
        //    }
        //}
    }
}
