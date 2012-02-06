using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Monkey.Processing.UI
{
    public class Log
    {
        private String m_logFilePath = String.Empty;
        private StreamWriter m_writer = null;
        
        /// <summary>
        /// 无参构造器，LogFile="Log_"+DataTime.Now+".txt"      
        /// </summary>
        public Log()
        {
            m_logFilePath = "Log_" + DateTime.Now + ".txt";
            Init();
          
        }

        private void Init()
        {
            if (File.Exists(m_logFilePath))
            {
                File.Delete(m_logFilePath);
            }
            m_writer = File.CreateText(m_logFilePath);
        }        
        
        /// <summary>
        /// 指定一个文件路径记录日志。
        /// </summary>
        /// <param name="logFilePath"></param>
        public Log(String logFilePath)
        {
            m_logFilePath = logFilePath;
            Init();
        }

        public String LogFile
        {
            get { return m_logFilePath; }
            set { m_logFilePath = value; }
        }

        public void Write(String message)
        {
            m_writer.Write(message);
            m_writer.Flush();
        }
        public void WriteLine(String message)
        {
            m_writer.WriteLine(DateTime.Now.ToString("yyyy年mm月dd日 HH时mm分ss秒") + "：    {0}", message);
            m_writer.Flush();
        }                
    }
}
