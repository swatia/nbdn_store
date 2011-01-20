using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using nothinbutdotnetstore.dataaccesslayer;
using NUnit.Framework;

namespace nothinbutdotnetstore.specs.dataaccesslayer
{
    class DatabaseGatewaySpecs
    {
        public class when_creating_a_connection_from_a_legitimate_connection_settings_item
        {
            [Test]
            public void should_create_a_connection_with_the_right_details()
            {
                DataTable dt = DatabaseGateway.executequery("SELECT * FROM customers");

                Assert.IsInstanceOf(typeof(DataTable), dt);
            }
        }
    }
}
