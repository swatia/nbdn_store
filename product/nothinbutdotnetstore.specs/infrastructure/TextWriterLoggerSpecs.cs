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
            string message="Blah";

            protected override void arrange()
            {
                writer = new StringBuilder();
                a_text_writer = new StringWriter(writer);
                sut = new TextWriterLogger(a_text_writer,typeof(int));
            }

            protected override void act()
            {
                sut.informational(message);
            }

            [Test]
            public void should_write_out_a_message_containing_the_logged_message()
            {
                StringAssert.Contains(message,writer.ToString());
            }

            [Test]
            public void should_write_out_a_message_containing_the_type()
            {
                StringAssert.Contains(typeof(int).FullName,writer.ToString());
            }
        }

        public class when_logging_informational_with_the_provided_type : BaseConcern
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
            public void should_include_the_type_information_in_the_log_message()
            {
                Assert.AreEqual(string.Format("{0} - {1}\r\n", typeof(int).FullName, message), writer.ToString());
            }
        }
    }
}