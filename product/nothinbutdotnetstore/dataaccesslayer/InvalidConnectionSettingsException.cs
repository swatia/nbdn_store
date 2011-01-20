using System;

namespace nothinbutdotnetstore.dataaccesslayer
{
    public class InvalidConnectionSettingsException : Exception
    {
        public InvalidConnectionSettingsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

}