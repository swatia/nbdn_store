using nothinbutdotnetstore.infrastructure.logging;
using nothinbutdotnetstore.specs.utility;
using NUnit.Framework;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class LogSpecs
    {
        public class when_accessing_the_logging_static_gateway : BaseConcern
        {
            Logger result;
            Logger the_adapter;
            LoggerFactory logger_factory;

            protected override void arrange()
            {
                the_adapter = mock<Logger>();
                logger_factory = mock<LoggerFactory>();

                LogFactoryResolver resolver = () => logger_factory;

                Log.factory_resolver = resolver;

                logger_factory.Stub(x => x.create_logger_for(typeof(when_accessing_the_logging_static_gateway)))
                    .Return(the_adapter);
            }

            protected override void act()
            {
                result = Log.an;
            }

            [Test]
            public void should_return_client_adapter_to_the_underlying_logging_api()
            {
                result.should_equal(the_adapter);
            }
        }
    }
}