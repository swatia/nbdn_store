using System;
using System.IO;
using nothinbutdotnetstore.infrastructure.logging;
using nothinbutdotnetstore.infrastructure.logging.simple;
using nothinbutdotnetstore.specs.utility;
using NUnit.Framework;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class FileLoggerSpecs
    {
        public class when_logging_an_informational_message : BaseConcern
        {
            const string message = "A legitimate message";
            Logger sut;

            protected override void arrange()
            {
                sut = new FileLogger(logging_file_path);
            }

            protected override void act()
            {
                sut.informational(message);
            }

            [Test]
            public void should_create_the_log_file()
            {
                Assert.IsTrue(File.Exists(logging_file_path));
            }

            [Test]
            public void should_write_out_the_correct_message_to_the_log_file()
            {
                Assert.AreEqual(message,File.ReadAllText(logging_file_path)); 
            }

            protected string logging_file_path
            {
                get
                {
                    return Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                        "the_file.log");
                }
            }

            public override void cleanup()
            {
                File.Delete(logging_file_path);
            }
        }
    }
}