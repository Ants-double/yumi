using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntsUtils
{
   public class FileUtils
    {
        //测试测试方法
        public static int Add(int num1,int num2)
        {
            return num1 + num2;
        }

        //根据文件夹全路径创建文件夹
        public static void CreateDir(string subdir)
        {
            string path = subdir;
            if (Directory.Exists(path))
            {
                Console.WriteLine("此文件夹已经存在，无需创建！");
            }
            else
            {
                Directory.CreateDirectory(path);
                Console.WriteLine(path + " 创建成功!");
            }
        }
    }
}
