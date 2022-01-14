using System;
using System.Threading;
using System.Threading.Tasks;
using NLog;
using NLog.Layouts;

namespace TestConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var config = new NLog.Config.LoggingConfiguration();

            // Targets where to log to: File and Console
            var logfile = new NLog.Targets.FileTarget("logfile") {FileName = "file.txt"};
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");
            var txt =
                @"${shortdate} ${time} [${level:uppercase=true}]: ${message:withException=true}${when:when=length('${exception:format=Data}')>0:Inner=${newline}--- Exception Data ---${newline}${exception:format=Data:exceptionDataSeparator=,\r\n}}";
            var layout = new SimpleLayout(txt);
            logfile.Layout = layout;
            logconsole.Layout = layout;

            // Rules for mapping loggers to targets            
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            // Apply config           
            NLog.LogManager.Configuration = config;
            var logger = LogManager.LogFactory.GetCurrentClassLogger();

            try
            {
                logger.Info("Application is starting...");
                var example = new Example();
                await example.Get(99999, CancellationToken.None);
                logger.Info("Application stopped");
            }
            catch (Exception exception)
            {
                logger.Error(exception, "Application stopped because of exception");
            }
            finally
            {
                LogManager.Shutdown();
            }
        }
    }

    public class Example
    {
        private readonly OrdersRepository _ordersRepository = new();

        public async Task<object> Get(int id, CancellationToken cancellationToken)
        {
            var invoice = new Invoice() {Id = 111111, Date = DateTimeOffset.Now, Status = "Unpaid"};
            const string userName = "AntonAntonov";
            try
            {
                return await _ordersRepository.Get(id, cancellationToken);
            }
            catch (Exception exception)
            {
                throw exception.With("Unable to get order info")
                    .DetailData(nameof(userName), userName)
                    .DetailData(nameof(id), id)
                    .DetailData(nameof(invoice), invoice);
            }
        }
    }

    public class OrdersRepository
    {
        public Task<object> Get(int id, CancellationToken cancellationToken)
        {
            throw new Exception("Some trouble with connection :)");
            return Task.FromResult(new object());
        }
    }
}