using System;
using System.Data;
using System.Security;
using System.Security.Principal;
using System.Threading;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{
    public class CalculatorSpecs
    {
        public abstract class concern : Observes<Calculator>
        {
            
        }

        public class when_shutting_off_the_calculator_and_they_are_not_in_the_super_user_role : concern
        {
            Establish c = () =>
            {
                fake_principal = an<IPrincipal>();

                fake_principal.Stub(x => x.IsInRole(Arg<string>.Is.Anything)).Return(false);

                change(() => Thread.CurrentPrincipal).to(fake_principal);
            };

            Because b = () =>
                catch_exception(() =>sut.shut_off());

            It should_get_a_security_exception = () =>
                exception_thrown_by_the_sut.ShouldBeAn<SecurityException>();

            static IPrincipal fake_principal;
        }
        public class when_shutting_off_the_calculator_and_they_are_in_the_super_user_role : concern
        {
            Establish c = () =>
            {
                fake_principal = an<IPrincipal>();

                fake_principal.Stub(x => x.IsInRole(Arg<string>.Is.Anything)).Return(true);

                change(() => Thread.CurrentPrincipal).to(fake_principal);
            };

            Because b = () =>
                sut.shut_off();

            It should_shut_off_without_any_problems = () =>
            {

            };

            static IPrincipal fake_principal;
        }

        public class when_adding_two_positive_numbers : concern
        {
            Establish c = () =>
            {
                command = an<IDbCommand>();
                connection = the_dependency<IDbConnection>();

                connection.Stub(x => x.CreateCommand()).Return(command);

            };

            Because b = () =>
                result = sut.add(2, 3);


            It should_open_a_connection_to_the_database = () =>
                connection.received(x => x.Open());


            It should_run_a_stored_procedure = () =>
                command.received(x => x.ExecuteNonQuery());
  
            It should_return_sum_of_the_numbers = () =>
                result.ShouldEqual(5);

            It should_dispose_both_the_command_and_connection = () =>
            {
                connection.received(x => x.Dispose());
                command.received(x => x.Dispose());
            };
  



            static int result;
            static IDbConnection connection;
            static IDbCommand command;
        }

        public class when_attempting_to_add_a_number_that_is_negative : concern
        {
            Because b = () =>
                catch_exception(() => sut.add(2, -3));


            It should_throw_an_argument_exception = () =>
                exception_thrown_by_the_sut.ShouldBeAn<ArgumentException>();

        }
    }
}