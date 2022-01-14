using System;

namespace TestConsoleApp
{
    public static class ExceptionExtensions
    {
        public static YourAppException With(this Exception exception, in string message)
        {
            return new(message, exception);
        }
    }
}