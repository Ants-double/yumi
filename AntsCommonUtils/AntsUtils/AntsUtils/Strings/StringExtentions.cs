using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntsUtils.Strings
{
    public static class StringExtentions
    {
        /// <summary>
        /// string trim
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string TrimString(this string str)
        {
            return str.Trim();
        }
        /// <summary>
        /// 运行dos命令
        /// </summary>
        /// <Param name="command"></Param>
        /// <returns></returns>
        public static string RunCmd(this string command)
        {
            string str = "";
            ProcessStartInfo startInfo = new ProcessStartInfo("cmd", "/c " + command)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                RedirectStandardError = true,
                CreateNoWindow = true
            };
            using (Process process = Process.Start(startInfo))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    str = reader.ReadToEnd();
                }
                process.WaitForExit();
            }
            return str.Trim();
        }
    }
}
