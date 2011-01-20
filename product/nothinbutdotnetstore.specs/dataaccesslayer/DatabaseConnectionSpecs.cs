using System;
using System.Data;
using nothinbutdotnetstore.dataaccesslayer;
using NUnit.Framework;

namespace nothinbutdotnetstore.specs.dataaccesslayer
{
    public class DatabaseConnectionSpecs
    {
        public class when_told_to_open
        {
            TheConnection underlying_connection;


            [Test]
            public void should_open_the_underlying_connection_to_the_database()
            {
                underlying_connection = new TheConnection();
                var sut = new DatabaseConnection(underlying_connection);
                sut.open();

                Assert.IsTrue(underlying_connection.was_opened);
            } 
        } 
    }

    class TheConnection : IDbConnection
    {
        public bool was_opened { get; set; }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IDbTransaction BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void ChangeDatabase(string databaseName)
        {
            throw new NotImplementedException();
        }

        public IDbCommand CreateCommand()
        {
            throw new NotImplementedException();
        }

        public void Open()
        {
            throw new NotImplementedException();
        }

        public string ConnectionString
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public int ConnectionTimeout
        {
            get { throw new NotImplementedException(); }
        }

        public string Database
        {
            get { throw new NotImplementedException(); }
        }

        public ConnectionState State
        {
            get { throw new NotImplementedException(); }
        }
    }
}