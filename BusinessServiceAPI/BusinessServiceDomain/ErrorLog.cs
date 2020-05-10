using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BusinessServiceDomain
{
    public class ErrorLog
    {



        /// <summary>
        /// Write Errors in Log file
        /// </summary>
        /// <param name="functionName"></param>
        /// <param name="exception"></param>
        public static void Errorlogs(string functionName, string exception)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string dir = System.IO.Path.GetDirectoryName(path);
            string filename = dir + "\\Log\\Error_" + DateTime.Now.ToString("dd_MMM_yyyy") + ".Log";
            string logstr = null;
            try
            {
                if (!Directory.Exists(dir + "\\Log"))
                {
                    Directory.CreateDirectory(dir + "\\Log");
                }
                logstr = "\r\n" + DateTime.Now.ToString() + "\t" + functionName + "\t" + exception + "\n";
                FileStream fs = new FileStream(filename, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                try
                {
                    sw.Write(logstr);
                    sw.Close();
                    fs.Close();
                }
                catch (Exception)
                {
                    sw.Close();
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                FlushMemory();
            }

        }
        public static void FlushMemory()
        {
            GC.Collect();
        }
    }

}




