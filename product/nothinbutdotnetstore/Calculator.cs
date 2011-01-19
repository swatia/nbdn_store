using System;
using System.Data;
using System.Security;
using System.Threading;

namespace nothinbutdotnetstore
{
    public class Calculator
    {
        IDbConnection connection;

        public Calculator(IDbConnection connection)
        {
            this.connection = connection;
        }

        public int add(int number1, int number2)
        {
            ensure_both_numbers_are_positive(number1, number2);

            using (connection)
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.ExecuteNonQuery();
            }

            return number1 + number2;
        }

        void ensure_both_numbers_are_positive(int number1, int number2)
        {
            if (number1 < 0 || number2 < 0) throw new ArgumentException();
        }

        public void shut_off()
        {
            if (Thread.CurrentPrincipal.IsInRole("SuperUser")) return;

            throw new SecurityException();
        }
    }
}