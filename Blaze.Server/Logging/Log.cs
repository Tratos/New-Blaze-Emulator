using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    public enum LogLevel
    {
        None = 0,
        Debug = 1,
        Info = 2,
        Warning = 4,
        Error = 8,
        Data = 16,
        All = 31
    }

    public static class Log
    {
        private static string _fileName;
        private static StringBuilder _writeString;

        public static void Initialize(string fileName)
        {
            _fileName = fileName;
            _writeString = new StringBuilder();

            try
            {
                File.Delete(fileName);
            }
            catch (Exception e)
            {
                Console.WriteLine("Log file couldn't be deleted: {0}", e.ToString());
            }
        }

        private static void Write(String message, LogLevel level)
        {
            StackTrace trace = new StackTrace();
            StackFrame frame = null;

            frame = trace.GetFrame(2);

            string caller = "";

            if (frame != null && frame.GetMethod().DeclaringType != null)
            {
                caller = frame.GetMethod().DeclaringType.Name + ": ";
            }

            switch (level)
            {
                case LogLevel.Debug:
                    message = "DEBUG: " + message;
                    break;
                case LogLevel.Info:
                    message = "INFO: " + message;
                    break;
                case LogLevel.Warning:
                    message = "WARNING: " + message;
                    break;
                case LogLevel.Error:
                    message = "ERROR: " + message;
                    break;
            }

            String text = caller + message;

            Console.WriteLine(text);

            _writeString.AppendLine(text);
        }

        public static void WriteAway()
        {
            String stringToWrite = _writeString.ToString();
            _writeString.Length = 0;

            StreamWriter _logWriter = new StreamWriter(_fileName, true);

            _logWriter.Write(stringToWrite);
            _logWriter.Flush();
            _logWriter.Close();
        }

        public static void Data(String message)
        {
            Write(message, LogLevel.Data);
        }

        public static void Error(String message)
        {
            Write(message, LogLevel.Error);
        }

        public static void Warn(String message)
        {
            Write(message, LogLevel.Warning);
        }

        public static void Info(String message)
        {
            Write(message, LogLevel.Info);
        }

        public static void Debug(String message)
        {
            Write(message, LogLevel.Debug);
        }
    }
}
