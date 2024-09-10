using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool
{
    public static class Logger
    {
        private static string _filepath = ConfigurationManager.AppSettings["LogFilePath"].ToString();
        private static string _exceptionFilepath = ConfigurationManager.AppSettings["ExceptionFilepath"].ToString();

        public static void WriteMassage(string massage)
        {

            string directory = Path.GetDirectoryName(_filepath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (!File.Exists(_filepath))
                using (System.IO.File.CreateText(_filepath)) ;

            Console.WriteLine(massage);
            using (StreamWriter sw = new StreamWriter(_filepath, true))
            {
                sw.WriteLine(massage);
            }
        }


        public static void WriteException(string massage)
        {

            string directory = Path.GetDirectoryName(_exceptionFilepath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (!File.Exists(_exceptionFilepath))
                using (System.IO.File.CreateText(_exceptionFilepath)) ;

            Console.WriteLine(massage);
            using (StreamWriter sw = new StreamWriter(_exceptionFilepath, true))
            {
                sw.WriteLine(massage);
            }
        }
    }
}
