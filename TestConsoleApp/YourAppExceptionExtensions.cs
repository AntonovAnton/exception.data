namespace TestConsoleApp
{
    public static class YourAppExceptionExtensions
    {
        public static YourAppException ProjectId(this YourAppException exception, in int projectId)
        {
            exception.DetailData(nameof(projectId), projectId);
            return exception;
        }

        public static YourAppException Version(this YourAppException exception, in string version)
        {
            exception.DetailData(nameof(version), version);
            return exception;
        }

        public static YourAppException Id(this YourAppException exception, in int id)
        {
            exception.DetailData(nameof(id), id);
            return exception;
        }

        public static YourAppException Name(this YourAppException exception, in string name)
        {
            exception.DetailData(nameof(name), name);
            return exception;
        }

        public static YourAppException DetailData<T>(this YourAppException exception, in string key, in T value)
            where T : struct
        {
            exception.Data[key] = value;
            return exception;
        }

        public static YourAppException DetailData(this YourAppException exception, in string key, in string value)
        {
            exception.Data[key] = value;
            return exception;
        }

        public static YourAppException DetailData(this YourAppException exception, in string key, in object value)
        {
            try
            {
                exception.Data[key] = ExceptionDataEntry.FromValue(value);
            }
            catch
            {
                // ignored, because we use it inside another exception catch block
                // so, we should avoid throw new exception to keep original exception
            }

            return exception;
        }
    }
}