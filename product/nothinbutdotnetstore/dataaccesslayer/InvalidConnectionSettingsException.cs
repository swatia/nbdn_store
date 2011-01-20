using System;

namespace nothinbutdotnetstore.dataaccesslayer
{
    public class InvalidConnectionSettingsException : Exception
    {
        public InvalidConnectionSettingsException(Exception inner_exception) : base(string.Empty, inner_exception)
        {
        }
    }

}