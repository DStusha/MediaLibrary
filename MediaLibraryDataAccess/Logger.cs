using System;
using System.IO;
using System.Reflection;

namespace MediaLibraryDataAccess
{
    public static class Logger
    {
        public static void Write(string text)
        {
            using (StreamWriter sw = new StreamWriter(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\log.txt", true))
            {
                sw.Write(text);
                sw.WriteLine();
            }
        }

        public static void WriteLine(string message)
        {
            using (StreamWriter sw = new StreamWriter(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\log.txt", true))
            {
                sw.WriteLine(String.Format("{0,-23} {1}", DateTime.Now.ToString() + ":", message));
            }
        }

        public static void Error(string message, string stackTrace)
        {
            try
            {
                WriteLine("Ошибка: " + message);
                Write(stackTrace);
            }
            catch { }
        }
    }
}
