using System.Data;
using nothinbutdotnetstore.specs.utility;
using NUnit.Framework;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{
    public class CalculatorSpecs
    {
        public class when_adding_two_positive_numbers : BaseConcern
        {
            Calculator sut;
            int result;
            IDbConnection connection;
            IDbCommand command;

            protected override void arrange()
            {
                connection = an<IDbConnection>();
                command = an<IDbCommand>();

                connection.Stub(x => x.CreateCommand()).Return(command);

                sut = new Calculator(connection);
            }

            protected override void act()
            {
                result = sut.add(2, 4);
            }

            [Test]
            public void should_return_the_sum()
            {
                result.ShouldEqual(6);
            }

            [Test]
            public void should_open_a_connection_to_the_database()
            {
                
            }
        }
    }
}