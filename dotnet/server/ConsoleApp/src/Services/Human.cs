using ConsoleApp.DependencyServices.Interface;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ConsoleApp.Services;

public class Human : BackgroundService
{
    // property. IDateTimeService
    private IDateTimeService DateTimeService { get; }
    private ILogger<Human> Logger { get; }
    
    // constructor
    // Dependency Injection. IDateTImeService
    public Human(IDateTimeService dateTimeService, ILogger<Human> logger)
    {
        DateTimeService = dateTimeService;
        Logger = logger;
    }
    
    // questioned, what time?, Human class answer, DateTimeService.UtcNow()
    public void WhatTime()
    {
        Console.WriteLine(DateTimeService.UtcNow().ToLongTimeString());
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            Logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1_000, stoppingToken);
        }
    }
}