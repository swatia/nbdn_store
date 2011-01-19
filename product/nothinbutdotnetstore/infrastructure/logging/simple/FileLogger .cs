using System;
using System.IO;

namespace nothinbutdotnetstore.infrastructure.logging.simple
{
    public class FileLogger : Logger
    {
        string logging_file_path;

        public FileLogger( string logging_file_path)
        {
            this.logging_file_path = logging_file_path;
        }

        public void informational(string message)
        {
            File.AppendAllText(logging_file_path, message);
        }
    }
}