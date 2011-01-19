using System.IO;

namespace nothinbutdotnetstore.infrastructure.logging.simple
{
    public class FileLogger : Logger
    {
        string logging_path;

        public FileLogger(string logging_path)
        {
            this.logging_path = logging_path;
        }

        public void informational(string message)
        {
            File.AppendAllText(logging_path, message);
        }
    }
}