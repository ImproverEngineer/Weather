﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LIBWEATHER.LogManager
{
    public class LogManager
    {
        static string LogFileName
        {
            get
            {
                string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Log{0}.txt", DateTime.Now.ToString("yy-MM-dd")));
                if (!File.Exists(fileName))
                    File.Create(fileName).Close();
                return fileName;
            }
        }

        public static void Write(string message)
        {
            message = DateTime.Now.ToString("dd.MM.yy HH:mm:ss") + " " + message;
            Console.WriteLine(message);
            using (System.IO.FileStream file = new FileStream(LogFileName, FileMode.Append, FileAccess.Write, FileShare.Write))
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(file))
                {
                    sw.WriteLine(message);
                }
            }
        }

        public static void WriteException(Exception ex)
        {
            Write(string.Format(DateTime.Now.ToString("dd.MM.yyyy hh:mm") + "[ERROR] {0}", ex.ToString()));
        }

        public static void WriteException(Exception ex, string message)
        {
            Write(string.Format(DateTime.Now.ToString("dd.MM.yyyy hh:mm") + "[ERROR] {0}", message));
            Write(string.Format(DateTime.Now.ToString("dd.MM.yyyy hh:mm") + "[ERROR] {0}", ex.ToString()));
        }

    }
}
