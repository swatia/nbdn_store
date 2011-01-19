using System;
using System.IO;

namespace nothinbutdotnetstore.infrastructure.logging.simple
{
    public class FileLogger  : Logger
    {
        public void informational(string message)
        {
            File.AppendAllText(logging_file_path, message);
        }

        protected string logging_file_path
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                    "the_file.log");
            }
        }
    }
}