using System.IO;
using System.Text;
using nothinbutdotnetstore.infrastructure.logging;
using nothinbutdotnetstore.infrastructure.logging.simple;
using nothinbutdotnetstore.specs.utility;
using NUnit.Framework;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class TextWriterLoggerSpecs
    {
        public class when_logging_an_informational_message : BaseConcern
        {
            Logger sut;
            StringBuilder writer;
            TextWriter a_text_writer;

            protected override void arrange()
            {
                writer = new StringBuilder();
                a_text_writer = new StringWriter(writer);
                sut = new TextWriterLogger(a_text_writer);
            }

            protected override void act()
            {
                sut.informational("hello");
            }

            [Test]
            public void should_write_the_message_to_its_writer()
            {
              Assert.AreEqual("hello\r\n",writer.ToString());
            }
        }

        public class WhenLoggingInfoTypeIsIncluded : BaseConcern
        {
            Logger sut;
            StringBuilder writer;
            TextWriter testWriter;
            const string message = "hello";

            protected override void arrange()
            {
                writer = new StringBuilder();
                testWriter = new StringWriter(writer);
                sut = new TextWriterLogger(testWriter, typeof(int));
            }

            protected override void act()
            {
                sut.informational(message);
            }

            [Test]
            public void should_write_the_message_to_its_writer()
            {
                Assert.AreEqual(string.Format("{0} - {1}", typeof(int).FullName, message), writer.ToString());
            }
        }
    }
}