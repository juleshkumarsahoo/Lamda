using PollingService_MLLP;

class Program

{
    static void Main(string[] args)

    {
        CreateHostBuilder(args).Build().Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>

        Host.CreateDefaultBuilder(args)

            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<Worker>();
            })
        .ConfigureLogging(logging =>
        {
            logging.ClearProviders();
            logging.AddConsole();
            logging.AddEventLog(settings =>
            {
                settings.LogName = "MLLPlogName";
                settings.SourceName = "PollingService_MLLP";
            });
        })
        .UseWindowsService(options =>
            {
                options.ServiceName = "MLLPWindowsService";
            });

}