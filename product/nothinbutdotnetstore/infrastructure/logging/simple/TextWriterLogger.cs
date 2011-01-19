using System;
using System.IO;

namespace nothinbutdotnetstore.infrastructure.logging.simple
{
    public class TextWriterLogger : Logger
    {
        TextWriter writer;
        Type callType;

        public TextWriterLogger(TextWriter writer, Type callType)
        {
            this.writer = writer;
            this.callType = callType;
        }

        public TextWriterLogger(TextWriter writer) : this (writer, null)
        {
        }

        public void informational(string message)
        {
            writer.WriteLine(message);
        }
    }
}