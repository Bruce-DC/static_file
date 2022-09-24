using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WordsRepeatHandler
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string originalPath = "../../../../../words.txt";

            List<char> chars = new List<char>();
           
            string time = String.Format("{0}_{1}_{2}_{3}_{4}_{5}",DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,DateTime.Now.Hour,DateTime.Now.Minute,DateTime.Now.Second);
            string targetPath = "../../../../../words_"+time+".txt";
            if (File.Exists(originalPath))
            {
                char[] originalWordList = File.ReadAllText(originalPath, Encoding.UTF8).ToCharArray();

                Console.WriteLine("源文件的字符数:"+originalWordList.Length);
                
                for (int i = 0; i < originalWordList.Length; i++)
                {
                    if (!chars.Contains(originalWordList[i]))
                    {
                        chars.Add(originalWordList[i]);
                    }
                }
                
                Console.WriteLine("去重后的字符数:"+chars.Count);

                string result = String.Empty;
                
                for (int i = 0; i < chars.Count; i++)
                {
                    result += chars[i];
                }
                
                Console.WriteLine("去重后的文本内容:"+result);
                
                if (!File.Exists(targetPath))
                {
                    FileStream fs1 = new FileStream(targetPath, FileMode.Create, FileAccess.Write);//创建写入文件 
                    StreamWriter sw = new StreamWriter(fs1);
                    sw.WriteLine(result);//开始写入值
                    sw.Close();
                    fs1.Close();
                }
            }
            else
            {
                Console.WriteLine("源文件找不到！");
            }

            Console.ReadLine();
        }
    }
}