using System;

namespace ParserServer.QueryBuilder.Exceptions
{
    public class UriEmptyException : Exception
    {
        public UriEmptyException() : base()
        {
        }
        
        public UriEmptyException(string message) : base(message)
        {
        }
    }
}