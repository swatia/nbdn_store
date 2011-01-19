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
            Logger sut;

            protected override void arrange()
            {
                sut = new FileLogger();
            }

            protected override void act()
            {
                sut.informational("blah");
            }

            [Test]
            public void should_create_the_log_file()
            {
                Assert.IsTrue(File.Exists(logging_file_path));
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
}