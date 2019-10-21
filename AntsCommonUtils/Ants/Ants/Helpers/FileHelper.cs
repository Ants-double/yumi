using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.AccessControl;

namespace Ants.Helpers
{
    public class FileHelper
    {
        /// <summary>
        /// 判断文件是否存在
        /// </summary>
        /// <param name="filePath">文件全路径</param>
        /// <returns></returns>
        public static bool Exists(string filePath)
        {
            if (filePath == null || filePath.Trim() == "")
            {
                return false;
            }

            if (File.Exists(filePath))
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="dirPath">文件夹路径</param>
        /// <returns></returns>
        public static bool CreateDir(string dirPath)
        {
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            return true;
        }


        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public static bool CreateFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                FileStream fs = File.Create(filePath);
                fs.Close();
                fs.Dispose();
            }
            return true;

        }
        public static List<FileInfo> GetAllFileName(string floderPath)
        {

            List<FileInfo> res = new List<FileInfo>();
            try
            {
                List<DirectoryInfo> dirall = new List<DirectoryInfo>();
                DirectoryInfo folder = new DirectoryInfo(floderPath);
                //res.AddRange(GetFileName(folder));
                dirall.Add(folder);
                foreach (DirectoryInfo d in folder.GetDirectories())
                {
                    dirall.Add(d);
                    dirall.AddRange(GetAllFileName(d));
                }

                foreach (var item in dirall)
                {
                    res.AddRange(GetFileName(item));
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
            }
            return res;
        }
        private static DirectoryInfo[] GetAllFileName(DirectoryInfo dir)
        {
            return dir.GetDirectories();
        }
        private static FileInfo[] GetFileName(DirectoryInfo dir)
        {
            return dir.GetFiles("*.*");
        }

        /// <summary>
        /// 读文件内容
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="encoding">编码格式</param>
        /// <returns></returns>
        public static string Read(string filePath, Encoding encoding)
        {
            if (!Exists(filePath))
            {
                return null;
            }
            //将文件信息读入流中
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                return new StreamReader(fs, encoding).ReadToEnd();
            }
        }

        /// <summary>
        /// 读取文件的一行内容
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="encoding">编码格式</param>
        /// <returns></returns>
        public static string ReadLine(string filePath, Encoding encoding)
        {
            if (!Exists(filePath))
            {
                return null;
            }
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                return new StreamReader(fs, encoding).ReadLine();
            }
        }


        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="content">文件内容</param>
        /// <returns></returns>
        public static bool Write(string filePath, string content)
        {
            if (!Exists(filePath) || content == null)
            {
                return false;
            }

            //将文件信息读入流中
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                lock (fs)//锁住流
                {
                    if (!fs.CanWrite)
                    {
                        throw new System.Security.SecurityException("文件filePath=" + filePath + "是只读文件不能写入!");
                    }

                    byte[] buffer = Encoding.Default.GetBytes(content);
                    fs.Write(buffer, 0, buffer.Length);
                    return true;
                }
            }
        }


        /// <summary>
        /// 写入一行
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="content">内容</param>
        /// <returns></returns>
        public static bool WriteLine(string filePath, string content)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate | FileMode.Append))
            {
                lock (fs)
                {
                    if (!fs.CanWrite)
                    {
                        throw new System.Security.SecurityException("文件filePath=" + filePath + "是只读文件不能写入!");
                    }

                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(content);
                    sw.Dispose();
                    sw.Close();
                    return true;
                }
            }
        }


        public static bool CopyDir(DirectoryInfo fromDir, string toDir)
        {
            return CopyDir(fromDir, toDir, fromDir.FullName);
        }


        /// <summary>
        /// 复制目录
        /// </summary>
        /// <param name="fromDir">被复制的目录路径</param>
        /// <param name="toDir">复制到的目录路径</param>
        /// <returns></returns>
        public static bool CopyDir(string fromDir, string toDir)
        {
            if (fromDir == null || toDir == null)
            {
                throw new NullReferenceException("参数为空");
            }

            if (fromDir == toDir)
            {
                throw new Exception("两个目录都是" + fromDir);
            }

            if (!Directory.Exists(fromDir))
            {
                throw new IOException("目录fromDir=" + fromDir + "不存在");
            }

            DirectoryInfo dir = new DirectoryInfo(fromDir);
            return CopyDir(dir, toDir, dir.FullName);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromDir"></param>
        /// <param name="toDir"></param>
        /// <returns></returns>
        public static bool CopyDirNotCopyFile(string fromDir, string toDir)
        {
            DirectorySecurity s = new DirectorySecurity(fromDir, AccessControlSections.Access);
            if (!s.AreAuditRulesProtected)
            {
                if (fromDir == null || toDir == null)
                {
                    throw new NullReferenceException("参数为空");
                }

                if (fromDir == toDir)
                {
                    throw new Exception("两个目录都是" + fromDir);
                }

                if (!Directory.Exists(fromDir))
                {
                    throw new IOException("目录fromDir=" + fromDir + "不存在");
                }

                DirectoryInfo dir = new DirectoryInfo(fromDir);
               
               
                    return CopyCreateDir(dir, toDir);
                

            }
            else
            {
                return false;
            }

            return true;
        }

        private static bool CopyCreateDir(DirectoryInfo fromDir, string toDir)
        {
            DirectorySecurity s = new DirectorySecurity(fromDir.FullName, AccessControlSections.Access);
            if (!s.AreAuditRulesProtected)
            {
                foreach (DirectoryInfo dir in fromDir.GetDirectories())
                {
                    string filePath = string.Empty;

                    if (dir.FullName.Length > 4)
                    {
                        filePath = toDir + dir.FullName.Substring(dir.FullName.IndexOf("\\"));

                        CreateDir(filePath);
                    }
                }
                foreach (var item in fromDir.GetDirectories())
                {
                    if (!((item.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden
                    || (item.Attributes & FileAttributes.System) == FileAttributes.System))
                    {
                        CopyCreateDir(item, toDir);
                    }

                }
            }
            return true;
        }
        /// <summary>
        /// 复制目录
        /// </summary>
        /// <param name="fromDir">被复制的目录路径</param>
        /// <param name="toDir">复制到的目录路径</param>
        /// <param name="rootDir">被复制的根目录路径</param>
        /// <returns></returns>
        private static bool CopyDir(DirectoryInfo fromDir, string toDir, string rootDir, bool copyFile = true)
        {
            string filePath = string.Empty;
            foreach (FileInfo f in fromDir.GetFiles())
            {
                filePath = toDir + f.FullName.Substring(rootDir.Length);
                string newDir = filePath.Substring(0, filePath.LastIndexOf("\\"));
                CreateDir(newDir);
                if (copyFile)
                {
                    File.Copy(f.FullName, filePath, true);
                }
            }

            foreach (DirectoryInfo dir in fromDir.GetDirectories())
            {
                CopyDir(dir, toDir, rootDir, copyFile);
            }

            return true;
        }


        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="filePath">文件的完整路径</param>
        /// <returns></returns>
        public static bool DeleteFile(string filePath)
        {
            if (Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            return false;
        }


        public static void DeleteDir(DirectoryInfo dir)
        {
            if (dir == null)
            {
                throw new NullReferenceException("目录不存在");
            }

            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                DeleteDir(d);
            }

            foreach (FileInfo f in dir.GetFiles())
            {
                DeleteFile(f.FullName);
            }

            dir.Delete();

        }


        /// <summary>
        /// 删除目录
        /// </summary>
        /// <param name="dir">指定目录路径</param>
        /// <param name="onlyDir">是否只删除目录</param>
        /// <returns></returns>
        public static bool DeleteDir(string dir, bool onlyDir)
        {
            if (dir == null || dir.Trim() == "")
            {
                throw new NullReferenceException("目录dir=" + dir + "不存在");
            }

            if (!Directory.Exists(dir))
            {
                return false;
            }

            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            if (dirInfo.GetFiles().Length == 0 && dirInfo.GetDirectories().Length == 0)
            {
                Directory.Delete(dir);
                return true;
            }


            if (!onlyDir)
            {
                return false;
            }
            else
            {
                DeleteDir(dirInfo);
                return true;
            }

        }


        /// <summary>
        /// 在指定的目录中查找文件
        /// </summary>
        /// <param name="dir">目录路径</param>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public static bool FindFile(string dir, string fileName)
        {
            if (dir == null || dir.Trim() == "" || fileName == null || fileName.Trim() == "" || !Directory.Exists(dir))
            {
                return false;
            }

            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            return FindFile(dirInfo, fileName);

        }


        public static bool FindFile(DirectoryInfo dir, string fileName)
        {
            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                if (File.Exists(d.FullName + "\\" + fileName))
                {
                    return true;
                }
                FindFile(d, fileName);
            }

            return false;
        }

    }
}