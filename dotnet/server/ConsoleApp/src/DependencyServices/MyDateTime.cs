using ConsoleApp.Services.Interface;
using Microsoft.Extensions.Logging;

namespace ConsoleApp.DependencyServices;

public class MyDateTime : IDateTimeService
{
    private DateTime Instance { get; } = DateTime.UtcNow;
    
    private ILogger<MyDateTime> Logger { get; }
    
    public MyDateTime(ILogger<MyDateTime> logger)
    {
        Logger = logger;
    }

    public DateTime UtcNow()
    {
        return Instance;
    }

    public TimeSpan Diff(DateTime start, DateTime end)
    {
        return end - start;
    }

    public void LogDateTime()
    {
        Logger.LogInformation(UtcNow().ToLongTimeString());
    }
}