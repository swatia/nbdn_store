using System;
using System.IO;

namespace nothinbutdotnetstore.infrastructure.logging.simple
{
    public class TextWriterLogger : Logger
    {
        TextWriter writer;
        Type calling_type;

        public TextWriterLogger(TextWriter writer, Type calling_type)
        {
            this.writer = writer;
            this.calling_type = calling_type;
        }

        public void informational(string message)
        {
            writer.WriteLine(string.Format("{0} - {1}",calling_type.FullName,message));
        }
    }
}