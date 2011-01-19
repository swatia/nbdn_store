using System.IO;

namespace nothinbutdotnetstore.infrastructure.logging.simple
{
    public class TextWriterLogger : Logger
    {
        TextWriter writer;

        public TextWriterLogger(TextWriter writer)
        {
            this.writer = writer;
        }

        public void informational(string message)
        {
            writer.WriteLine(message);
        }
    }
}