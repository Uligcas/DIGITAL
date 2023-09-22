using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonDigital
{
    public class LogWriter
    {
        private string m_exePath = string.Empty;

        private static volatile LogWriter _instance;

        public static LogWriter GetInstance()
        {
            if (_instance == null)
            {
                return _instance = new LogWriter();
            }
            else
            {
                return _instance;
            }
        }

        protected LogWriter()
        {
        }

        public void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception)
            {
            }
        }

        public void LogWrite(string logMessage)
        {
            this.m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                using (StreamWriter streamWriter = File.AppendText(string.Concat(this.m_exePath, "\\log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt")))
                {
                    this.Log(logMessage, streamWriter);
                }
            }
            catch
            {
            }
        }
    }
}
